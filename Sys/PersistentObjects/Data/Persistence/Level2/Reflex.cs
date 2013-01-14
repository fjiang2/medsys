//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace Sys.Data
{
    class Reflex
    {

        public static FieldInfo[] GetPublicFields(object instance)
        {
            return GetPublicFields(instance.GetType());
        }

        public static FieldInfo[] GetPublicFields(Type type)
        {
            return type.GetFields(BindingFlags.Public | BindingFlags.Instance);    //ignore public const fields
        }


        public static ColumnAttribute GetColumnAttribute(DataRow dataRow, FieldInfo fieldInfo)
        {

            ColumnAttribute attribute = GetColumnAttribute(fieldInfo);

            if (attribute != null && dataRow.Table.Columns.Contains(attribute.ColumnName))
            {
                if (dataRow.Table.Columns[attribute.ColumnName].DataType == fieldInfo.FieldType)
                    return attribute;

                if (fieldInfo.FieldType.IsGenericType
                  && fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(Nullable<>)
                  && fieldInfo.FieldType.GetGenericArguments()[0] == dataRow.Table.Columns[attribute.ColumnName].DataType)
                    return attribute;
            }


            return null;
        }

        public static ColumnAttribute GetColumnAttribute(FieldInfo fieldInfo)
        {
            ColumnAttribute[] attributes = (ColumnAttribute[])fieldInfo.GetCustomAttributes(typeof(ColumnAttribute), true);

            foreach (ColumnAttribute attribute in attributes)
                return attribute;

            if (attributes.Length == 0)
            {
                Attribute[] non = (Attribute[])fieldInfo.GetCustomAttributes(typeof(NonPersistentAttribute), true);
                if (non.Length > 0)
                    return null;

                non = (Attribute[])fieldInfo.GetCustomAttributes(typeof(AssociationAttribute), true);
                if (non.Length > 0)
                    return null;

                //if (fieldInfo.GetCustomAttributes(true).Length == 0)        //no other attribute defined.
                {
                    if (fieldInfo.IsPublic)
                        try
                        {
                            return new ColumnAttribute(fieldInfo.Name, fieldInfo.FieldType);
                        }
                        catch (Exception)
                        {
                            return null;    //some type is not supported
                        }

                }
            }

            return null;
        }

        public static AssociationAttribute GetAssociationAttribute(FieldInfo fieldInfo)
        {
            AssociationAttribute[] attributes = (AssociationAttribute[])fieldInfo.GetCustomAttributes(typeof(AssociationAttribute), true);

            foreach (AssociationAttribute attribute in attributes)
                return attribute;

            return null;
        }

        public static void FillInstance(object instance, DataRow dataRow, bool defaultValueUsed)
        {

            foreach (FieldInfo fieldInfo in Reflex.GetPublicFields(instance))
            {
                FillField(instance, fieldInfo, dataRow, defaultValueUsed);
            }
        }


        public static object FillField(object instance, FieldInfo fieldInfo, DataRow dataRow, bool defaultValueUsed)
        {
            ColumnAttribute a = Reflex.GetColumnAttribute(dataRow, fieldInfo);
            if (a != null)
            {
                object value = dataRow[a.ColumnName];

                if (value == System.DBNull.Value)
                {
                    if (a.DefaultValue != null)
                    {
                        value = a.DefaultValue;
                    }
                    else if (defaultValueUsed)
                    {
                        Type dataType = dataRow.Table.Columns[a.ColumnName].DataType;
                        value = DefaultRowValue.SystemDefaultValue(dataType);
                    }
                    else
                        value = null;
                }

                fieldInfo.SetValue(instance, value);
            }

            return a;
        }


        /// <summary>
        /// Colllect from DPO instance and Fill into dataRow
        /// </summary>
        /// <param name="instance">data from</param>
        /// <param name="dataRow">data to</param>
        public static void CollectInstance(object instance, DataRow dataRow)
        {
            foreach (FieldInfo fieldInfo in Reflex.GetPublicFields(instance))
            {
                ColumnAttribute attribute = Reflex.GetColumnAttribute(dataRow, fieldInfo);

                if (attribute != null && dataRow.Table.Columns.Contains(attribute.ColumnNameSaved))
                {
                    if (fieldInfo.GetValue(instance) == null)
                        dataRow[attribute.ColumnNameSaved] = System.DBNull.Value;
                    else
                        dataRow[attribute.ColumnNameSaved] = fieldInfo.GetValue(instance);
                }
            }
        }



        public static DataTable GetEmptyDataTable<T>() where T : class, IDPObject
        {
            return GetEmptyDataTable(typeof(T));
        }


        /// <summary>
        /// Create Empty System.Data.DataTable from ColumnAttribute of DPO fields
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static DataTable GetEmptyDataTable(Type type)
        {
            DataTable dt = new DataTable();
            foreach (FieldInfo fieldInfo in Reflex.GetPublicFields(type))
            {
                ColumnAttribute a = Reflex.GetColumnAttribute(fieldInfo);
                if (a == null)
                    continue;

                Type ty = fieldInfo.FieldType.InnullableType();
                DataColumn column = new DataColumn(a.ColumnName, ty);
                column.AllowDBNull = a.Nullable;
                column.AutoIncrement = a.Identity;
                column.Caption = a.Caption;

                //may need complicated logic for differentg type
                if (ty == typeof(string))
                    column.MaxLength = a.Length;    

                dt.Columns.Add(column);
            }

            return dt;
        }

    }
}

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
using System.Text;
using System.Data;
using Sys.Data;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        private string columnName;
        private CType ctype;
        private Type type;

        public string ColumnNameSaved;
        public object DefaultValue = null;
        
        public bool Primary = false;
        public bool Identity = false;
        public bool Computed = false;
        public bool Saved = true;

        public short Length = 0;
        public bool Nullable = false;
        public byte Precision = 0;
        public byte Scale = 0;


        public string Caption;

        public ColumnAttribute(string columnName, CType ctype)
        {
            this.columnName = columnName;
            this.Caption = columnName;
            this.ColumnNameSaved = columnName;
            this.ctype = ctype;
            this.type = ctype.ToType();
        }

        //internal ColumnAttribute(string columnName, Type type)
        //{
        //    this.columnName = columnName;
        //    this.Caption = columnName;
        //    this.ColumnNameSaved = columnName;
        //    this.dbType = type;

        //    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        //    {
        //        this.Nullable = true;
        //        type = type.GetGenericArguments()[0];
        //    }

        //    if (type == typeof(int))
        //    {
        //        this.sqlDbType = SqlDbType.Int;
        //    }
        //    else if (type == typeof(string))
        //    {
        //        this.sqlDbType = SqlDbType.NVarChar;
        //        this.Nullable = true;
        //        this.Length = 100;
        //    }
        //    else if (type == typeof(decimal))
        //    {
        //        this.sqlDbType = SqlDbType.Decimal;
        //        this.Precision = 10;
        //        this.Scale = 2;
        //    }
        //    else if (type == typeof(bool))
        //    {
        //        this.sqlDbType = SqlDbType.Bit;
        //    }
        //    else if (type == typeof(DateTime))
        //    {
        //        this.sqlDbType = SqlDbType.DateTime;
        //    }
        //    else if (type == typeof(TimeSpan))
        //    {
        //        this.sqlDbType = SqlDbType.Timestamp;
        //    }
        //    else if (type == typeof(Single))
        //    {
        //        this.sqlDbType = SqlDbType.Real;
        //    }
        //    else if (type == typeof(double))
        //    {
        //        this.sqlDbType = SqlDbType.Float;
        //    }
        //    else if (type == typeof(byte))
        //    {
        //        this.sqlDbType = SqlDbType.TinyInt;
        //    }
        //    else if (type == typeof(Int16))
        //    {
        //        this.sqlDbType = SqlDbType.SmallInt;
        //    }
        //    else if (type == typeof(Int64))
        //    {
        //        this.sqlDbType = SqlDbType.BigInt;
        //    }
        //    else if (type == typeof(byte[]))
        //    {
        //        this.sqlDbType = SqlDbType.Binary;
        //    }
        //    else if (type == typeof(Guid))
        //    {
        //        this.sqlDbType = SqlDbType.UniqueIdentifier;
        //    }
        //    else
        //        throw new JException("{0} is not supported", type.FullName);
        //}

        public string ColumnName
        {
            get { return columnName; }
        }

        public CType CType
        {
            get { return this.ctype; }
        }


        public Type Type
        {
            get { return this.type; }
        }

        public override string ToString()
        {
            return string.Format("{0}(Type={1}, Null={2}, Length={3})",columnName, ctype, Nullable, Length);
        }
    }
}

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
using System.Data;
using System.Reflection;

namespace Sys.Data
{
    enum MappingType
    {
        One2One,
        One2Many,
        Many2Many
    }

    class Mapping
    {
        private AssociationAttribute association;
        private MappingType mappingType;
        private PersistentObject dpoInstance;

        
      
        FieldInfo fieldInfo1;              //fieldof(UserDpo._ID)
        FieldInfo fieldInfo2;              //fieldof(DPCollection<RoleDpo>)  or fieldof(xxxDpo)

        
        private SqlClause clause1;     //A := SELECT UserRoles.Role_ID FROM UserRoles WHERE UserRoles.User_ID=@[User.ID]
        private SqlClause clause2;     //B := SELECT * FROM Roles WHERE Roles.Role_ID IN (A)

        public Mapping(PersistentObject dpo, FieldInfo fieldInfo2)
        {
            this.association = Reflex.GetAssociationAttribute(fieldInfo2);

            if (association == null)
                return;

            this.dpoInstance = dpo;
            this.fieldInfo2 = fieldInfo2;

            Type dpoType2;            //typeof(RoleDpo)
            if (fieldInfo2.FieldType.IsGenericType)
            {
                dpoType2 = PersistentObject.GetCollectionGenericType(fieldInfo2);

                if (this.association.TRelation == null)
                    mappingType = MappingType.One2Many;
                else
                    mappingType = MappingType.Many2Many;
            }
            else
            {
                dpoType2 = fieldInfo2.FieldType;
                mappingType = MappingType.One2One;
            }

            

            this.fieldInfo1 = dpo.GetType().GetField(association.Column1);
           
           
            if (mappingType == MappingType.Many2Many)
            {
                this.clause1 = new SqlClause()
                    .SELECT.COLUMNS(association.Relation2)
                    .FROM(association.TRelation)
                    .WHERE(association.Relation1.ColumnName() == association.Column1.ParameterName());

                this.clause2 = new SqlClause()
                    .SELECT
                    .COLUMNS()
                    .FROM(dpoType2)
                    .WHERE(association.Relation2.ColumnName().IN(this.clause1));
                    
            }
            else
            {
                SqlExpr where = association.Column2.ColumnName() == association.Column1.ParameterName();
                if (association.Filter != null)
                    where = where & association.Filter;

                this.clause2 = new SqlClause()
                    .SELECT
                    .COLUMNS()
                    .FROM(dpoType2)
                    .WHERE(where);

                if(association.OrderBy != null)
                    this.clause2 = clause2.ORDER_BY(association.OrderBy);
            }
        }


   

        /// <summary>
        /// return -> { UserRoles.Role1, UserRoles.Role2, ...}
        /// </summary>
        private object[] Relation
        {
            get
            {
                object value1 = fieldInfo1.GetValue(dpoInstance);
                SqlCmd cmd = new SqlCmd(this.clause1);
                cmd.AddParameter(association.Column1.SqlParameterName(), value1);
                return cmd.FillDataTable().ToArray<object>(association.Relation1);
            }
        }

        public void SetValue()
        {
            if (association == null)
                return ;

            object value1 = fieldInfo1.GetValue(dpoInstance);
            SqlCmd cmd = new SqlCmd(this.clause2);
            cmd.AddParameter(association.Column1.SqlParameterName(), value1);
            DataTable dataTable =  cmd.FillDataTable();

            if (mappingType == MappingType.One2One)
            {
                //if association object was not instatiated
                if (fieldInfo2.GetValue(this) == null)
                {
                    PersistentObject dpo = (PersistentObject)Activator.CreateInstance(fieldInfo2.FieldType, null);
                    dpo.Fill(dataTable.Rows[0]);
                    fieldInfo2.SetValue(this, dpo);
                }
                else
                {
                    IDPObject dpo = (IDPObject)fieldInfo2.GetValue(this);
                    dpo.Fill(dataTable.Rows[0]);
                }
            }
            else
            {
                //if association collection was not instatiated
                if (fieldInfo2.GetValue(this) == null)
                    fieldInfo2.SetValue(this, Activator.CreateInstance(fieldInfo2.FieldType, new object[] { dataTable }));
                else
                {
                    IPersistentCollection collection = (IPersistentCollection)fieldInfo2.GetValue(this);
                    collection.Table = dataTable;
                }
            }

        }


        private bool IsColumn1Identity()
        {
            ColumnAttribute[] attributes = (ColumnAttribute[])fieldInfo1.GetCustomAttributes(typeof(ColumnAttribute), true);
            if (attributes.Length == 0)
                return false;

            return attributes[0].Identity;
        }


        public void FillIdentity()
        {
            if (association == null)
                return;

            if (!IsColumn1Identity())
                return;

            if (mappingType == MappingType.One2Many)
            {
                object value1 = fieldInfo1.GetValue(dpoInstance);
                IDPCollection collection = (IDPCollection)fieldInfo2.GetValue(this);
                foreach (DataRow row in collection.Table.Rows)
                {
                    row[association.Column2] = value1;
                    IDPObject dpo = (IDPObject)collection.GetObject(row);
                    dpo.FillIdentity(row);
                }
            }
        }

    }
}

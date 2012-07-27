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
        
        private object value1;      //UserDpo.ID  =100;
      
        FieldInfo fieldInfo1;              //fieldof(UserDpo._ID)
        FieldInfo fieldInfo2;              //fieldof(DPCollection<RoleDpo>)  or fieldof(xxxDpo)

        
        private SqlClause clause1;     //A := SELECT UserRoles.Role_ID FROM UserRoles WHERE UserRoles.User_ID=@[User.ID]
        private SqlClause clause2;     //B := SELECT * FROM Roles WHERE Roles.Role_ID IN (A)

        public Mapping(PersistentObject dpo, FieldInfo fieldInfo2)
        {
            this.association = Reflex.GetAssociationAttribute(fieldInfo2);

            if (association == null)
                return;

            this.fieldInfo2 = fieldInfo2;

            Type dpoType2;            //typeof(RoleDpo)
            if (fieldInfo2.FieldType.IsGenericType)
            {
                dpoType2 = GetCollectionGenericType(fieldInfo2);

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
            this.value1 = fieldInfo1.GetValue(dpo);
           
            if (mappingType == MappingType.Many2Many)
            {
                this.clause1 = new SqlClause()
                    .SELECT.COLUMNS(association.Relation2)
                    .FROM(association.TRelation)
                    .WHERE(association.Relation1.ColumName() == association.Column1.ParameterName());
                
                this.clause2 = new SqlClause()
                    .SELECT
                    .COLUMNS()
                    .FROM(dpoType2)
                    .WHERE(association.Relation2.ColumName().IN(this.clause1));
            }
            else
            {
                this.clause2 = new SqlClause()
                    .SELECT
                    .COLUMNS()
                    .FROM(dpoType2)
                    .WHERE(association.Column2.ColumName() == association.Column1.ParameterName());
            }
        }


        private static Type GetCollectionGenericType(FieldInfo fieldInfo)
        {
            Type fieldType = fieldInfo.FieldType;
            if (!fieldType.IsGenericType)
                throw new JException("DPCollection is not generic type");

            Type[] typeParameters = fieldType.GetGenericArguments();
            if (typeParameters.Length != 1)
                throw new JException("Too many generic parameters, DPCollection must declare like DPCollection<T> Children");

            if (typeParameters[0].IsSubclassOf(typeof(PersistentObject)))
                return typeParameters[0];

            return null;
        }


        /// <summary>
        /// return -> { UserRoles.Role1, UserRoles.Role2, ...}
        /// </summary>
        private object[] Relation
        {
            get
            {
                SqlCmd cmd = new SqlCmd(this.clause1);
                cmd.AddParameter(association.Column1.SqlParameterName(), value1);
                return cmd.FillDataTable().ToArray<object>(association.Relation1);
            }
        }

        public void SetValue()
        {
            if (association == null)
                return;


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

    

    }
}

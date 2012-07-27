using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Sys.Data
{
    class ManyToManyMapping
    {
        private Mapping_Many_To_ManyAttribute mapping;
        private Type TMany2;            //typeof(Roles)

        private object value;           //User.ID = 102
        private SqlClause clause1;      //A := SELECT UserRoles.Role_ID FROM UserRoles WHERE UserRoles.User_ID=@[User.ID]
        private SqlClause clause2;      //B := SELECT * FROM Roles WHERE Roles.Role_ID IN (A)

        public ManyToManyMapping(Mapping_Many_To_ManyAttribute mapping, Type tmany2, object value)
        {
            this.mapping = mapping;
            this.TMany2 = tmany2;
            this.value = value;
         
            this.clause1 = new SqlClause().SELECT.COLUMNS(mapping.Relation2).FROM(mapping.TRelation).WHERE(mapping.Relation1.ColumName() == mapping.Many1.ParameterName());
            this.clause2 = new SqlClause().SELECT.COLUMNS().FROM(TMany2).WHERE(mapping.Relation2.ColumName().IN(this.clause1));
        }


        /// <summary>
        /// return -> { UserRoles.Role1, UserRoles.Role2, ...}
        /// </summary>
        private object[] Relation
        {
            get
            {
                SqlCmd cmd = new SqlCmd(this.clause1);
                cmd.AddParameter(mapping.Many1.SqlParameterName(), value);
                return cmd.FillDataTable().ToArray<object>(mapping.Relation1);
            }
        }

        public DataTable GetTable()
        {
            SqlCmd cmd = new SqlCmd(this.clause2);
            cmd.AddParameter(mapping.Many1.SqlParameterName(), value);
            return cmd.FillDataTable();
        }

    

    }
}

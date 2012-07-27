using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data
{
    class ManyToManyMapping<TMany1, TMany2, T>
        where TMany1 : class, IDPObject, new()  //typeof(Users)
        where TMany2 : class, IDPObject, new()  //typeof(Roles)
    {
        private Mapping_Many_To_ManyAttribute mapping;

        private T value;                    //User.ID = 102
        private SqlClause clause1;          //A := SELECT UserRoles.Role_ID FROM UserRoles WHERE UserRoles.User_ID=@[User.ID]
        private SqlClause clause2;          //B := SELECT * FROM Roles WHERE Roles.Role_ID IN (A)

        public ManyToManyMapping(Mapping_Many_To_ManyAttribute mapping, T value)
        {
            this.mapping = mapping;
            this.value = value;
         
            this.clause1 = new SqlClause().SELECT.COLUMNS(mapping.Relation2).FROM(mapping.RelationDpo).WHERE(mapping.Relation1.ColumName() == mapping.Many1.ParameterName());
            this.clause2 = new SqlClause().SELECT.COLUMNS().FROM<TMany2>().WHERE(mapping.Relation2.ColumName().IN(this.clause1));
        }


        /// <summary>
        /// return -> { UserRoles.Role1, UserRoles.Role2, ...}
        /// </summary>
        public T[] Relation
        {
            get
            {
                SqlCmd cmd = new SqlCmd(this.clause1);
                cmd.AddParameter(mapping.Many1.SqlParameterName(), value);
                return cmd.FillDataTable().ToArray<T>(mapping.Relation1);
            }
        }

        public DPCollection<TMany2> Collection
        {
            get
            {
                SqlCmd cmd = new SqlCmd(this.clause2);
                cmd.AddParameter(mapping.Many1.SqlParameterName(), value);
                return new DPCollection<TMany2>(cmd.FillDataTable());
            }
        }

        

    }
}

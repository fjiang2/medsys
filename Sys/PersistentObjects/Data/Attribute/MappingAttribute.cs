using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tie;

namespace Sys.Data
{
   
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class Mapping_One_To_OneAttribute : NonValizedAttribute
    {
        private Locator locator;
        
        public readonly string One1;
        public readonly string One2;

        public Mapping_One_To_OneAttribute(string one1, string one2)
        {
            this.One1 = one1;
            this.One2 = one2;

            SqlExpr exp = one2.ColumName() == one1.ParameterName();
            this.locator = new Locator(exp.ToString());
            this.locator.Unique = true;

        }

        public Locator Locator
        {
            get
            {
                return this.locator;
            }
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class Mapping_One_To_ManyAttribute : NonValizedAttribute
    {
        private Locator locator;

        public readonly string One;
        public readonly string Many;

        public Mapping_One_To_ManyAttribute(string one, string many)
        {
            this.One = one;
            this.Many = many;

            SqlExpr exp = many.ColumName() == one.ParameterName();
            this.locator = new Locator(exp.ToString());
            this.locator.Unique = false;

        }

        public Locator Locator
        {
            get
            {
                return this.locator;
            }
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class Mapping_Many_To_ManyAttribute : NonValizedAttribute
    {

        public readonly string Many1;       //Users.ID
        public readonly string Relation1;   //UserRoles.User_ID
        
        public readonly string Many2;       //Roles.ID
        public readonly string Relation2;   //UserRoles.Role_ID
        
        public readonly Type RelationDpo;      //typeof(UserRoles)

        private SqlClause clause1;           //A := SELECT UserRoles.Role_ID FROM UserRoles WHERE UserRoles.User_ID=@[User.ID]
        private SqlClause clause2;           //B := SELECT * FROM Roles WHERE Roles.Role_ID IN (A)

        public Mapping_Many_To_ManyAttribute(string many1, string many2, Type relationDpo, string relation1, string relation2)
        {
            this.Many1 = many1;
            this.Many2 = many2;

            this.Relation1 = relation1;
            this.Relation2 = relation2;
            this.RelationDpo = relationDpo;

            
        }

    }
}

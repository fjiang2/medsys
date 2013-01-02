using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys;
using Sys.Data;
using Sys.Foundation.DpoClass;

namespace App.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlClause sql1 = new SqlClause()
                .SELECT.COLUMNS()
                .FROM<UserDpo>()
                .WHERE(
                    (UserDpo._Email.ColumnName() != "")
                    .AND(UserDpo._First_Name.ColumnName() == "Unknown")
                    );

            SqlClause sql2 = new SqlClause()
                .SELECT.COLUMNS()
                .FROM<UserDpo>()
                .WHERE(
                    (UserDpo._Email.ColumnName()!= "").AND(UserDpo._First_Name.ColumnName() == "Unknown").OR(UserDpo._Last_Name.ColumnName()=="Devel")
                    );

            string x1 = sql1.ToString();
            string x2 = sql2.ToString();
            Console.WriteLine(x1);
            Console.WriteLine(x2);
        }
    }
}

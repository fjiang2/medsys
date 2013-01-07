using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using Sys;
using Sys.Data;
using Sys.Foundation.DpoClass;
using Sys.ViewManager.DpoClass;
using Sys.ViewManager.Security;
using Sys.ViewManager.Forms;

namespace App.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProviderManager.RegisterDefaultProvider("data source=hmt-tmbsql;initial catalog=ENGR;integrated security=SSPI;packet size=4096");
            NTreeViewDemo();
        }

        static void SqlClauseDemo()
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




        public static void NTreeViewDemo()
        {
            NTreeView<UserMenuItem> tree = new NTreeView<UserMenuItem>(
                new TableReader<UserMenuItem>().ToList().Where(dpo => dpo.Released).OrderBy(dpo => dpo.OrderBy), 
                0);

            tree.Dock = DockStyle.Fill;
            Form form = new Form();
            form.Controls.Add(tree);
            Application.Run(form);
        }
    }
}

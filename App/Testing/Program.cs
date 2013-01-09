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
            //DataProviderManager.RegisterDefaultProvider("data source=hmt-tmbsql;initial catalog=ENGR;integrated security=SSPI;packet size=4096");
            DataProviderManager.RegisterDefaultProvider("data source=localhost\\sqlexpress;initial catalog=medsys;integrated security=SSPI;packet size=4096");
            //NTreeViewDemo();

            SqlClauseJoinDemo();
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
            var ntree = new NTree<UserMenuItem>(new TableReader<UserMenuItem>().ToList().Where(dpo => dpo.Released).OrderBy(dpo => dpo.OrderBy), 0);
            NTreeView<UserMenuItem> treeView = new NTreeView<UserMenuItem>();
            treeView.DataSource = ntree;
            treeView.Dock = DockStyle.Fill;
            Form form = new Form();
            form.Controls.Add(treeView);
            Application.Run(form);
        }

        static void SqlClauseJoinDemo()
        {
            int userId = 1;

            string U = "U";
            string UR = "UR";
            SqlClause clause = new SqlClause()
                .SELECT.COLUMNS(
                    UserDpo.AllColumnNames(U),       //U.*
                    UserRoleDpo._Role_ID.ColumnName(UR) //UR.Role_ID
                 )
                .FROM<UserDpo>(U)
                .INNER.JOIN<UserRoleDpo>(UR).ON(
                    UserRoleDpo._User_ID.ColumnName(UR) == UserDpo._User_ID.ColumnName(U)
                    )
                .WHERE(UserDpo._User_ID.ColumnName(U) == userId);
            
            System.Data.DataTable table = new SqlCmd(clause).FillDataTable();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Foundation.DpoClass;
using Sys.ViewManager.DpoClass;
using Sys.ViewManager.Security;
using Sys.ViewManager.Forms;
using Sys.Data.Comparison;
using Stock;

namespace App.Testing
{
    class Program
    {
        const string conn_localhost_medsys = "data source=localhost\\sqlexpress;initial catalog=medsys;integrated security=SSPI;packet size=4096";


        static void Main(string[] args)
        {

            ConnectionProviderManager.RegisterDefaultProvider(conn_localhost_medsys);

            //NTreeViewDemo();
           //SqlClauseDemo();
           //SqlClauseJoinDemo();

            //SqlServerCompactDemo();

            DailyFetch fetching = new DailyFetch();
            //DailyFetch.Test();


        }

     

        private static void SqlServerCompactDemo()
        {
            string conn1 = "data source=C:\\devel\\medsys\\database1.sdf";
            var pvd1 = ConnectionProviderManager.Register("Compact", ConnectionProviderType.SqlServerCe, conn1);

            var table = new SqlCmd(pvd1, "SELECT * FROM CtrlType").FillDataTable();
        }


        static void SqlClauseDemo()
        {
            SqlBuilder sql1 = new SqlBuilder()
                .SELECT.COLUMNS()
                .FROM<UserDpo>()
                .WHERE(
                    (UserDpo._Email.ColumnName() != "")
                    .AND(UserDpo._First_Name.ColumnName() == "Unknown")
                    );

            SqlBuilder sql2 = new SqlBuilder()
                .SELECT.COLUMNS()
                .FROM<UserDpo>()
                .WHERE(
                    (UserDpo._Email.ColumnName()!= "").AND(UserDpo._First_Name.ColumnName() == "Unknown").OR(UserDpo._Last_Name.ColumnName()=="devel")
                    );

            string x1 = sql1.ToString();
            string x2 = sql2.ToString();  //SELECT *  FROM medsys..[sys00101] WHERE (([Email] <> '') AND ([First_Name] = 'Unknown')) OR ([Last_Name] = 'devel')

            Console.WriteLine(x1);
            Console.WriteLine(x2);



            //potential bug, one user may open 1+ Image Windows
            SqlBuilder clause = new SqlBuilder()
                .UPDATE<UserDpo>()
                .SET(
                    UserDpo._Email.ColumnName() == "my.email.com", 
                    UserDpo._Start_Date.ColumnName() == DateTime.Today
                    )
                .WHERE(UserDpo._User_ID.ColumnName() ==  5);
            

            string sql = clause.ToString();
            Console.WriteLine(sql);
        }




        public static void NTreeViewDemo()
        {
            IEnumerable<UserMenuDpo> list = new TableReader<UserMenuDpo>(UserMenuItem._ParentID.ColumnName() == 10)
               .ToList()
               .Where(dpo => dpo.Released)
               .OrderBy(dpo => dpo.OrderBy);



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
            SqlBuilder clause = new SqlBuilder()
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

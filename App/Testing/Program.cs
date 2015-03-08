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

        const string conn_buildmachine = "data source=192.168.104.114,1433\\MSSQLSERVER;initial catalog=ATMS_4_5;User Id=sa;Password=naztec";
        const string conn_buildmachine2 = "data source=192.168.104.114,1433\\sqlexpress;initial catalog=Tes;User Id=sa;Password=naztec";
        const string conn_localhost = "data source=localhost\\sqlexpress;initial catalog=ATMS_4_5;integrated security=SSPI;packet size=4096";
        const string conn_palmdemo = "data source=192.168.104.2;initial catalog=palmdemo;User Id=sa;Password=";
        const string conn_ab = "data source=192.168.104.190,1433\\SQLEXPRESS;initial catalog=ATMS_4_5;User Id=sa;Password=naztec";
        const string conn_IP128 = "data source=192.168.104.128,1433\\SQLEXPRESS;initial catalog=ATMS_4_5;User Id=sa;Password=naztec";

        static void Main(string[] args)
        {

            DataProviderManager.RegisterDefaultProvider(conn_localhost_medsys);

            //NTreeViewDemo();
           //SqlClauseDemo();
           //SqlClauseJoinDemo();

            //SqlServerCompactDemo();
            TableCompareDemo(conn_localhost, conn_buildmachine);

            DailyFetch fetching = new DailyFetch();
            //DailyFetch.Test();


        }

        private static void TableCompareDemo(string pvd1, string pvd2)
        {
            string script;

            var compare = new Compare(pvd1, pvd2);

            script = compare.TableSchemaDifference("3M_IDS", "3M_IDS");

            script = compare.DatabaseSchemaDifference("ATMS_4_5", "ATMS_4_5");

            script = compare.TableDifference("Config", new string[] { "Key" });
            script = compare.TableDifference("AppFcn", new string[] { "FCN_ID" });
            script = compare.TableDifference("ScanShape", new string[] { "Shape" });

            script = compare.TableDifference("Report", new string[] { "ID" });
            script = compare.TableDifference("Rep_Parm", new string[] { "REP_ID", "NAME" });

            script = compare.DatabaseDifference("ATMS_4_5", "ATMS");
        }

        private static void SqlServerCompactDemo()
        {
            string conn1 = "data source=C:\\devel\\medsys\\database1.sdf";
            var pvd1 = DataProviderManager.Register("Compact", DataProviderType.SqlServerCe, conn1);

            var table = new SqlCmd(pvd1, "SELECT * FROM CtrlType").FillDataTable();
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
                    (UserDpo._Email.ColumnName()!= "").AND(UserDpo._First_Name.ColumnName() == "Unknown").OR(UserDpo._Last_Name.ColumnName()=="devel")
                    );

            string x1 = sql1.ToString();
            string x2 = sql2.ToString();  //SELECT *  FROM medsys..[sys00101] WHERE (([Email] <> '') AND ([First_Name] = 'Unknown')) OR ([Last_Name] = 'devel')

            Console.WriteLine(x1);
            Console.WriteLine(x2);



            //potential bug, one user may open 1+ Image Windows
            SqlClause clause = new SqlClause()
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

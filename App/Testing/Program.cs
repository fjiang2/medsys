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
using App.Stock;

namespace App.Testing
{
    class Program
    {
        const string conn_localhost_medsys = "data source=localhost\\sqlexpress;initial catalog=medsys;integrated security=SSPI;packet size=4096";
        
        const string conn_buildmachine = "data source=192.168.104.114,1433\\sqlexpress;initial catalog=ATMS;User Id=sa;Password=naztec";
        const string conn_localhost = "data source=localhost\\sqlexpress;initial catalog=ATMS_4_5;integrated security=SSPI;packet size=4096";
        const string conn_palmdemo = "data source=192.168.104.2;initial catalog=palmdemo;User Id=sa;Password=";
        const string conn_ab = "data source=192.168.104.190,1433\\SQLEXPRESS;initial catalog=ATMS_4_5;User Id=sa;Password=naztec";

        static void Main(string[] args)
        {

            DataProviderManager.RegisterDefaultProvider(conn_localhost_medsys);
           
            //NTreeViewDemo();
           //SqlClauseDemo();
           //SqlClauseJoinDemo();

            //SqlServerCompactDemo();
            //TableCompareDemo();

            Uri uri = new Uri(@"http://www.sec.gov/cgi-bin/own-disp?action=getowner&CIK=0001213732");
            Uri uri2 = new Uri("http://www.sec.gov/cgi-bin/browse-edgar?action=getcompany&CIK=0001590197");

            //var parser = new App.Stock.HtmlParser(uri);
            //var parser = new App.Stock.HtmlParser("c:\\devel\\html\\Ownership Information ALCOA INC.htm");
            //var table = parser.ToTable();

            //string path = "c:\\devel\\html\\Ownership Information ALCOA INC.htm";
            string path = "c:\\devel\\html\\Ownership Information INTERNATIONAL BUSINESS MACHINES CORP.htm";
            StreamReader reader = new StreamReader(path);
            string html = reader.ReadToEnd();

            var parser = new InsiderTransactionHtml(html);
            parser.ParseHtml();


        }

        private static void TableCompareDemo()
        {
            string script;
            script = TableCompare.Difference(conn_localhost, conn_buildmachine, "AppFcn", new string[] { "FCN_ID" });
            script = TableCompare.Difference(conn_palmdemo, conn_localhost, "Report", new string[] { "ID" });
            script = TableCompare.Difference(conn_palmdemo, conn_localhost, "Rep_Parm", new string[] { "REP_ID", "ORD" });

            script = DatabaseCompare.Difference(conn_localhost, conn_buildmachine, "ATMS_4_5", "ATMS");
        }

        private static void SqlServerCompactDemo()
        {
            string conn1 = "data source=C:\\devel\\medsys\\database1.sdf";
            var pvd1 = DataProviderManager.Register("Compact", DataProviderType.SqlServerCe, conn1);

            var table = new SqlCmd(pvd1, "SELECT * FROM CtrlType").FillDataTable();
        }


        //Create all INSERT Clauses
        private static string InsertIntoTableData(string conn, string tableName )
        {
            var pvd1 = DataProviderManager.Register("Source", DataProviderType.SqlServer, conn);
            string script = TableCompare.Rows(tableName, pvd1);
            return script;
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

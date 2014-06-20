using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
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



            //DataProviderManager.RegisterDefaultProvider("data source=localhost\\sqlexpress;initial catalog=medsys;integrated security=SSPI;packet size=4096");
           // NTreeViewDemo();
           //SqlClauseDemo();
           //SqlClauseJoinDemo();


            CompareTableData("AppFcn", new string[] {"FCN_ID"});
        }



        private static void CompareTableData(string tableName, string[] primaryKeys)
        {

            var pvd1 = DataProviderManager.Register("localhost", DataProviderType.SqlServer, "data source=localhost\\sqlexpress;initial catalog=ATMS_4_5;integrated security=SSPI;packet size=4096");
            var pvd2 = DataProviderManager.Register("buildmachine", DataProviderType.SqlServer, "data source=192.168.104.114,1433\\sqlexpress;initial catalog=ATMS;User Id=sa;Password=naztec");

            TableName name = new TableName(pvd1, tableName);
            Locator locator = new Locator(primaryKeys);

            string pk = primaryKeys[0];
            string SQL = string.Format("SELECT * FROM {0}", tableName);

            var dt1 = new SqlCmd(pvd1, SQL).FillDataTable();
            var dt2 = new SqlCmd(pvd2, SQL).FillDataTable();

            int count = 0;
            StringBuilder builder = new StringBuilder();
            TableCompare compare = new TableCompare(tableName, primaryKeys, dt1, dt2);

            string script = compare.Compare();


        }

        private static void CompareTableData1(string tableName, string[] primaryKeys)
        {

            var pvd1 = DataProviderManager.Register("localhost", DataProviderType.SqlServer, "data source=localhost\\sqlexpress;initial catalog=ATMS_4_5;integrated security=SSPI;packet size=4096");
            var pvd2 = DataProviderManager.Register("buildmachine", DataProviderType.SqlServer, "data source=192.168.104.114,1433\\sqlexpress;initial catalog=ATMS;User Id=sa;Password=naztec");

            TableName name = new TableName(pvd1, tableName);
            Locator locator = new Locator(primaryKeys);

            string pk = primaryKeys[0];
            string SQL = string.Format("SELECT * FROM {0}", tableName);

            var dt1 = new SqlCmd(pvd1, SQL).FillDataTable();
            var dt2 = new SqlCmd(pvd2, SQL).FillDataTable();

            int count = 0;
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row1 in dt1.Rows)
            {
                var row2 = dt2.AsEnumerable().Where(row => RowCompare.Compare(primaryKeys, row, row1)).FirstOrDefault();

                if (!row1["ORD"].Equals(row2["ORD"]))
                {
                    count++;
                    builder.AppendFormat("UPDATE {0} SET {1} = {2} WHERE {3}={4}\n", tableName, "ORD", row1["ORD"], pk, row1[pk]);
                    RowAdapter a = new RowAdapter(name, locator, row1);

                }
                else
                {
                    builder.AppendFormat("INSERT {0} ({1}) VALUES({2})\n", tableName, row1["ORD"], row1[pk]);
                }
            }

            string script = builder.ToString();


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

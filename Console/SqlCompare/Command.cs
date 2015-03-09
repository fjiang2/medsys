using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys.Data;
using Sys.Data.Comparison;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SqlCompare
{
    public enum CompareAction
    {
        Schema = 1,
        Data = 2,
        ParimaryKey = 3,
        ForeignKey = 4,
        AllRows = 5
    }


    class Command
    {
        public string OutputFile { get; set; }
        public string TableName1 { get; set; }
        public string TableName2 { get; set; }

        private SqlConnectionStringBuilder CS1;
        private SqlConnectionStringBuilder CS2;
        private DataProvider pvd1;
        private DataProvider pvd2;

        public Command(SqlConnectionStringBuilder cs1, SqlConnectionStringBuilder cs2)
        {
            this.CS1 = cs1;
            this.CS2 = cs2;

            this.pvd1 = DataProviderManager.Register("Source", DataProviderType.SqlServer, cs1.ConnectionString);
            this.pvd2 = DataProviderManager.Register("Sink", DataProviderType.SqlServer, cs2.ConnectionString);

            OutputFile = "sqlcompare.sql";
        }

        private bool Exists(TableName tname)
        {
            if (!tname.Exists())
            {
                Console.WriteLine("table not exists : {0}", tname);
                return false;
            }

            return true;
        }

        private bool Exists(DatabaseName dname)
        {
            if (!dname.Exists())
            {
                Console.WriteLine("table not exists : {0}", dname);
                return false;
            }

            return true;
        }

        public void AllRows(string tableName, string where)
        {
            var tname = new TableName(pvd1, tableName);
            if (Exists(tname))
            {
                string sql = Compare.AllRows(tname, where);
                Output(sql);
            }
        }

        public void DisplayPK(string tableName)
        {
            TableName tname = new TableName(pvd1, tableName);
            if (Exists(tname))
            {
                var dt = tname.PrimaryKeySchema();
                Display(dt);
            }
        }

        public void DisplayFK(string tableName)
        {
            TableName tname = new TableName(pvd1, tableName);
            if (Exists(tname))
            {
                var dt = tname.ForeignKeySchema();
                Display(dt);
            }
        }

        private void Display(DataTable dt)
        {
            StringBuilder builder = new StringBuilder();
            foreach(DataColumn column in dt.Columns)
            {
                builder.AppendFormat("{0}\t", column.ColumnName);
            }
            Console.WriteLine(builder.ToString());
            foreach (DataRow row in dt.Rows)
            {
                builder = new StringBuilder();
                foreach (DataColumn column in dt.Columns)
                {
                    builder.AppendFormat("{0}\t", row[column]);
                }
                
                Console.WriteLine(builder.ToString());
            }
        }

        public void Run(CompareAction CompareType, string[] excludedtables)
        {


            Console.WriteLine(string.Format("server1: {0} default database:{1}", CS1.DataSource, CS1.InitialCatalog));
            Console.WriteLine(string.Format("server2: {0} default database:{1}", CS2.DataSource, CS2.InitialCatalog));


            var compare = new Compare(pvd1, pvd2);
            DatabaseName db1 = new DatabaseName(pvd1, CS1.InitialCatalog);
            DatabaseName db2 = new DatabaseName(pvd2, CS2.InitialCatalog);

            if (!Exists(db1) || !Exists(db2))
                return;

            string sql = null;

            if (TableName1 != null && TableName2 != null)
            {
                TableName tname1 = new TableName(db1, TableName1);
                TableName tname2 = new TableName(db2, TableName2);

                if (!Exists(tname1) || !Exists(tname2))
                    return;

                Console.WriteLine(string.Format("compare table schema {0} => {1}", TableName1, TableName2));
                sql = compare.TableSchemaDifference(tname1, tname2);
                
                if (sql == string.Empty)
                {
                    Console.WriteLine(string.Format("compare table data {0} => {1}", TableName1, TableName2));
                    sql = compare.TableDifference(tname1, tname2);
                }
            }
            else if (CompareType == CompareAction.Schema)
            {
                Console.WriteLine(string.Format("compare database schema {0} => {1}", CS1.InitialCatalog, CS2.InitialCatalog));
                sql = compare.DatabaseSchemaDifference(db1, db2);
            }
            else if (CompareType == CompareAction.Data)
            {
                Console.WriteLine(string.Format("compare database data {0} => {1}", CS1.InitialCatalog, CS2.InitialCatalog));
                if (excludedtables != null && excludedtables.Length > 0)
                    Console.WriteLine(string.Format("ignore tables: {0}", string.Join(",", excludedtables)));
                sql = compare.DatabaseDifference(db1, db2, excludedtables);
            }


            Output(sql);
            
        }

        public void Output(string sql)
        {
            if (string.IsNullOrEmpty(sql))
            {
                if (File.Exists(OutputFile))
                {
                    File.Delete(OutputFile);
                    Console.WriteLine("Nothing is changed");
                }

                return;
            }

            using (var writer = new StreamWriter(OutputFile))
            {
                writer.Write(sql);
            }

            Console.WriteLine("output: {0}", OutputFile);
            Console.WriteLine("completed.", OutputFile);
        }
    }
}

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
    class Command
    {
        public string OutputFile { get; set; }

        public SqlConnectionStringBuilder CS1 { get; private set; }
        public SqlConnectionStringBuilder CS2 { get; private set; }

        public string TableName1 { get; set; }
        public string TableName2 { get; set; }

        public bool CompareSchema { get; set; }

        public Command(SqlConnectionStringBuilder cs1, SqlConnectionStringBuilder cs2)
        {
            this.CS1 = cs1;
            this.CS2 = cs2;

            OutputFile = "sqlcompare.sql";
            CompareSchema = true;

        }

        public void ExtractDataRows(string tableName, string where)
        {
            var compare = new Compare(CS1.ConnectionString, CS2.ConnectionString);
            string sql = compare.AllRows(tableName, where);
            Output(sql);
        }

        public void Run()
        {


            Console.WriteLine(string.Format("server1: {0} default database:{1}", CS1.DataSource, CS1.InitialCatalog));
            Console.WriteLine(string.Format("server2: {0} default database:{1}", CS2.DataSource, CS2.InitialCatalog));


            var compare = new Compare(CS1.ConnectionString, CS2.ConnectionString);

            string sql = null;

            if (TableName1 != null && TableName2 != null)
            {
                Console.WriteLine(string.Format("compare table schema {0} => {1}", TableName1, TableName2));
                sql = compare.TableSchemaDifference(TableName1, TableName2);
                
                if (sql == string.Empty)
                {
                    Console.WriteLine(string.Format("compare table data {0} => {1}", TableName1, TableName2));
                    sql = compare.TableDifference(TableName1, TableName2);
                }
            }
            else if (CompareSchema)
            {
                Console.WriteLine(string.Format("compare database schema {0} => {1}", CS1.InitialCatalog, CS2.InitialCatalog));
                sql = compare.DatabaseSchemaDifference(CS1.InitialCatalog, CS2.InitialCatalog);
            }
            else
            {
                Console.WriteLine(string.Format("compare database data {0} => {1}", CS1.InitialCatalog, CS2.InitialCatalog));
                sql = compare.DatabaseDifference(CS1.InitialCatalog, CS2.InitialCatalog);
            }


            Output(sql);
            
        }

        public void Output(string sql)
        {
            if (string.IsNullOrEmpty(sql))
            {
                if(File.Exists(OutputFile))
                    File.Delete(OutputFile);
                return;
            }

            using (var writer = new StreamWriter(OutputFile))
            {
                writer.Write(sql);
            }

            Console.WriteLine("completed.");
        }
    }
}

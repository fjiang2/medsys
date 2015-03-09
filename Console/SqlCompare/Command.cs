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
using System.Text.RegularExpressions;

namespace SqlCompare
{
   
    class Command
    {
        private Compare compare;

        public string OutputFile { get; set; }

        public Side Side1 {get; private set;}
        public Side Side2 {get; private set;}

        public Command(SqlConnectionStringBuilder cs1, SqlConnectionStringBuilder cs2, string tableNamePattern1, string tableNamePattern2)
        {
            this.Side1 = new Side(cs1, tableNamePattern1);
            this.Side2 = new Side(cs2, tableNamePattern2);

            OutputFile = "sqlcompare.sql";

            this.compare = new Compare(this.Side1.Provider, this.Side2.Provider);
        }


        public void AllRows()
        {
            Output(Side1.AllRows());
        }

        public void AllRows(string tableName, string where)
        {
            Output(Side1.AllRows(tableName,where));
        }


        public static bool Exists(TableName tname)
        {
            if (!tname.Exists())
            {
                Console.WriteLine("table not exists : {0}", tname);
                return false;
            }

            return true;
        }

        public static bool Exists(DatabaseName dname)
        {
            if (!dname.Exists())
            {
                Console.WriteLine("table not exists : {0}", dname);
                return false;
            }

            return true;
        }


        public void Run(CompareAction CompareType, string[] excludedtables, Dictionary<string,string[]> pk)
        {
            excludedtables = excludedtables.Select(row => row.ToUpper()).ToArray();
            DatabaseName db1 = Side1.DatabaseName;
            DatabaseName db2 = Side2.DatabaseName;


            Console.WriteLine(string.Format("server1: {0} default database:{1}", db1.Name, db2.Name));
            Console.WriteLine(string.Format("server2: {0} default database:{1}", db1.Name, db2.Name));


           
            if (!Exists(db1) || !Exists(db2))
                return;

            StringBuilder builder = new StringBuilder();

            var N1 = Side1.TableNames;
            var N2 = Side2.TableNames;


            if (N1.Length != 0 && N2.Length != 0)
            {
                if (N1.Length != N2.Length)
                {
                    Console.WriteLine("cannot compare,number of tables on the left and right are different");
                    return;
                }

                for(int i=0; i<N1.Length; i++)
                {
                    builder.Append(CompareTable(N1[i], N2[i], excludedtables, pk));
                }
            }
            else if (CompareType == CompareAction.Schema)
            {
                Console.WriteLine(string.Format("compare database schema {0} => {1}", db1.Name, db2.Name));
                builder.Append(compare.DatabaseSchemaDifference(db1, db2));
            }
            else if (CompareType == CompareAction.Data)
            {
                Console.WriteLine(string.Format("compare database data {0} => {1}", db1.Name, db2.Name));
                if (excludedtables != null && excludedtables.Length > 0)
                    Console.WriteLine(string.Format("ignore tables: {0}", string.Join(",", excludedtables)));
                builder.Append(compare.DatabaseDifference(db1, db2, excludedtables));
            }


            Output(builder.ToString());
            
        }

        private string CompareTable(string tableName1, string tableName2, string[] excludedtables, Dictionary<string, string[]> pk)
        {
            TableName tname1 = new TableName(Side1.DatabaseName, tableName1);
            TableName tname2 = new TableName(Side2.DatabaseName, tableName2);

            if (!Exists(tname1) || !Exists(tname2))
                return string.Empty;

            Console.WriteLine(string.Format("compare table schema {0} => {1}", tableName1, tableName2));
            string sql = compare.TableSchemaDifference(tname1, tname2);

            if (sql == string.Empty)
            {
                if (excludedtables.Contains(tname1.Name.ToUpper()))
                {
                    Console.WriteLine("skip to compare data on table {0}", tname1);
                }
                else if (excludedtables.Contains(tname2.Name.ToUpper()))
                {
                    Console.WriteLine("skip to compare data on table {0}", tname2);
                }
                else
                {
                    Console.WriteLine(string.Format("compare table data {0} => {1}", tableName1, tableName2));
                    bool hasPk;
                    sql = compare.TableDifference(tname1, tname2, out hasPk);

                    if (!hasPk)
                    {
                        Console.WriteLine("warning: no primary key found : {0}", tname1);
                        
                        string key = tname1.Name.ToUpper();
                        if (pk.ContainsKey(key))
                        {
                            Console.WriteLine("use predefine keys defined in ini file: {0}", tname1);
                            sql = compare.TableDifference(tname1, tname2, pk[key]);
                        }
                    }
                }
            }
            
            return sql;
        }

        public void Output(string sql)
        {
            if (string.IsNullOrEmpty(sql))
            {
                sql = string.Empty;
                Console.WriteLine("Nothing is changed");
            }

            using (var writer = new StreamWriter(OutputFile))
            {
                writer.Write(sql);
            }
            
            if (!string.IsNullOrEmpty(sql))
            {
                Console.WriteLine("output: {0}", OutputFile);
                Console.WriteLine("completed.", OutputFile);
            }
        }


    }
}

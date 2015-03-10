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

    class CompareAdapter : Logger
    {
        private Compare compare;

        public string InputFile { get; set; }
        public string OutputFile { get; set; }

        public Side Side1 {get; private set;}
        public Side Side2 {get; private set;}

        public CompareAdapter(SqlConnectionStringBuilder cs1, SqlConnectionStringBuilder cs2, string tableNamePattern1, string tableNamePattern2)
        {
            this.Side1 = new Side(cs1, tableNamePattern1);
            this.Side2 = new Side(cs2, tableNamePattern2);

            InputFile = "script.sql";
            OutputFile = "script.sql";

            this.compare = new Compare(this.Side1.Provider, this.Side2.Provider);
        }

        public void ExecuteScript()
        {
            if (!File.Exists(InputFile))
            {
                Log("input file not found: {0}", InputFile);
                return;
            }

            StringBuilder builder = new StringBuilder();
            using (var reader = new StreamReader(InputFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line == "GO")
                    {
                        string sql = builder.ToString();
                        new SqlCmd(Side2.Provider, sql).ExecuteNonQuery();
                        builder.Clear();
                    }
                    else if (line != string.Empty)
                        builder.AppendLine(line);
                }
            }
        }

        public void GenerateScript()
        {
            DatabaseName db1 = Side1.DatabaseName;
            StringBuilder builder = new StringBuilder();
            builder.Append(db1.GenerateDropTableScript());
            builder.Append(db1.GenerateScript());
            Output(builder.ToString());
        }

        public void AllRows(string[] excludedtables)
        {
            string[] names = Side1.TableNames;
            if (names == null)
                names = Side1.DatabaseName.GetTableNames();
            
            List<string> list = new List<string>();
            foreach (string name in names)
            {
                if(!excludedtables.Contains(name.ToUpper()))
                    list.Add(name);
            }

            Output(Side1.AllRows(list.ToArray()));
        }

     
        public static bool Exists(TableName tname)
        {
            if (!tname.Exists())
            {
                Logx("table not exists : {0}", tname);
                return false;
            }

            return true;
        }

        public static bool Exists(DatabaseName dname)
        {
            if (!dname.Exists())
            {
                Logx("table not exists : {0}", dname);
                return false;
            }

            return true;
        }


        public void Run(CompareAction CompareType, string[] excludedtables, Dictionary<string,string[]> pk)
        {
            DatabaseName db1 = Side1.DatabaseName;
            DatabaseName db2 = Side2.DatabaseName;


            Log("server1: {0} default database:{1}", db1.Name, db2.Name);
            Log("server2: {0} default database:{1}", db1.Name, db2.Name);
           
            if (!Exists(db1) || !Exists(db2))
                return;

            StringBuilder builder = new StringBuilder();

            var N1 = Side1.TableNames;
            var N2 = Side2.TableNames;
            string sql;

            if (N1 != null && N2 != null)
            {
                if (N1.Length != N2.Length)
                {
                    Log("number of comparing table are different: {0}!={1}", N1.Length, N2.Length);
                    return;
                }
                for(int i=0; i<N1.Length; i++)
                {
                    builder.Append(CompareTable(N1[i], N2[i], excludedtables, pk));
                }
            }
            else if (CompareType == CompareAction.Schema)
            {
                sql = CompareDatabaseSchema(db1, db2);

                if (sql != string.Empty)
                    builder.Append(sql);
            }
            else if (CompareType == CompareAction.Data)
            {
                sql = CompareDatabaseSchema(db1, db2);

                if (sql != string.Empty)
                    builder.Append(sql);

                sql = CompareDatabaseData(db1, db2, excludedtables);
                if (sql != string.Empty)
                    builder.Append(sql);

            }


            Output(builder.ToString());
            
        }

        private string CompareDatabaseSchema(DatabaseName db1, DatabaseName db2)
        {
            Log("compare database schema {0} => {1}", db1.Name, db2.Name);
            return compare.DatabaseSchemaDifference(db1, db2);
        }

        private string CompareDatabaseData(DatabaseName db1, DatabaseName db2, string[] excludedtables)
        {
            Log("compare database data {0} => {1}", db1.Name, db2.Name);
            if (excludedtables != null && excludedtables.Length > 0)
                Log("ignore tables: {0}", string.Join(",", excludedtables));
            return compare.DatabaseDifference(db1, db2, excludedtables);
        }

        private string CompareTable(string tableName1, string tableName2, string[] excludedtables, Dictionary<string, string[]> pk)
        {
            TableName tname1 = new TableName(Side1.DatabaseName, tableName1);
            TableName tname2 = new TableName(Side2.DatabaseName, tableName2);

            if (!Exists(tname1) || !Exists(tname2))
                return string.Empty;

            Log("compare table schema {0} => {1}", tableName1, tableName2);
            string sql = compare.TableSchemaDifference(tname1, tname2);

            if (sql == string.Empty)
            {
                if (excludedtables.Contains(tname1.Name.ToUpper()))
                {
                    Log("skip to compare data on table {0}", tname1);
                }
                else if (excludedtables.Contains(tname2.Name.ToUpper()))
                {
                    Log("skip to compare data on table {0}", tname2);
                }
                else
                {
                    Log("compare table data {0} => {1}", tableName1, tableName2);
                    bool hasPk;
                    sql = compare.TableDifference(tname1, tname2, out hasPk);

                    if (!hasPk)
                    {
                        Log("warning: no primary key found : {0}", tname1);
                        
                        string key = tname1.Name.ToUpper();
                        if (pk.ContainsKey(key))
                        {
                            Log("use predefine keys defined in ini file: {0}", tname1);
                            sql = compare.TableDifference(tname1, tname2, pk[key]);
                        }
                    }

                    if (sql != string.Empty)
                        Log(sql);
                }
            }
            
            return sql;
        }

        public void Output(string sql)
        {
            if (string.IsNullOrEmpty(sql))
            {
                sql = string.Empty;
                Log("Nothing is changed");
            }

            using (var writer = new StreamWriter(OutputFile))
            {
                writer.Write(sql);
            }
            
            if (!string.IsNullOrEmpty(sql))
            {
                Log("output: {0}", OutputFile);
                Log("completed.", OutputFile);
            }
        }

    }
}

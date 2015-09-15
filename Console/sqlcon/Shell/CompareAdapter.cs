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

namespace sqlcon
{

    class CompareAdapter  
    {

        public Side Side1 {get; private set;}
        public Side Side2 {get; private set;}

        public CompareAdapter(Side side1, Side side2)
        {
            this.Side1 = side1;
            this.Side2 = side2;
        }
     
        private static bool Exists(TableName tname)
        {
            if (!tname.Exists())
            {
                stdio.WriteLine("table not found : {0}", tname);
                return false;
            }

            return true;
        }

        private static bool Exists(DatabaseName dname)
        {
            if (!dname.Exists())
            {
                stdio.WriteLine("table not found : {0}", dname);
                return false;
            }

            return true;
        }


        public string Run(ActionType CompareType, MatchedDatabase m1, MatchedDatabase m2, Dictionary<string, string[]> pk)
        {
            DatabaseName db1 = Side1.DatabaseName;
            DatabaseName db2 = Side2.DatabaseName;


            stdio.WriteLine("server1: {0} default database:{1}", Side1.Provider.DataSource, db1.Name);
            stdio.WriteLine("server2: {0} default database:{1}", Side2.Provider.DataSource, db2.Name);
           
            if (!Exists(db1) || !Exists(db2))
                return string.Empty;

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("-- sqlcon:", Side1.Provider.DataSource, db1.Name).AppendLine();
            builder.AppendFormat("-- compare server={0} db={1}", Side1.Provider.DataSource, db1.Name).AppendLine();
            builder.AppendFormat("--         server={0} db={1} @ {2}", Side2.Provider.DataSource, db2.Name, DateTime.Now).AppendLine();
            var N1 = m1.MatchedTableNames;
            var N2 = m2.MatchedTableNames;
            string sql;

            if (N1 != null && N2 != null)
            {
                if (N1.Length == N2.Length)
                {
                    for (int i = 0; i < N1.Length; i++)
                    {
                        if (m1.Includes(N1[i]))
                        {
                            stdio.WriteLine("skip to compare data on table {0}", N1[i]);
                        }
                        else if (m2.Includes(N2[i]))
                        {
                            stdio.WriteLine("skip to compare data on table {0}", N2[i]);
                        }

                        builder.Append(CompareTable(CompareType, SideType.compare, N1[i], N2[i], pk));
                    }
                }
                else if (N1.Length > 0 && N2.Length == 0)
                {
                    foreach (var tname1 in N1)
                         builder.Append(tname1.GenerateScript());
                }
                else
                {
                    stdio.WriteLine("number of comparing table are different: {0}!={1}", N1.Length, N2.Length);
                    return string.Empty;
                }

            }
            else if (CompareType == ActionType.CompareSchema)
            {
                sql = CompareDatabaseSchema(db1, db2);

                if (sql != string.Empty)
                    builder.Append(sql);
            }
            else if (CompareType == ActionType.CompareData)
            {
                //sql = CompareDatabaseSchema(db1, db2);

                //if (sql != string.Empty)
                //    builder.Append(sql);

                sql = CompareDatabaseData(db1, db2, m1.Excludedtables);
                if (sql != string.Empty)
                    builder.Append(sql);

            }

            return builder.ToString();
        }

        private string CompareDatabaseSchema(DatabaseName db1, DatabaseName db2)
        {
            stdio.WriteLine("compare database schema {0} => {1}", db1.Name, db2.Name);
            return Compare.DatabaseSchemaDifference(db1, db2);
        }

        private string CompareDatabaseData(DatabaseName db1, DatabaseName db2, string[] excludedtables)
        {
            stdio.WriteLine("compare database data {0} => {1}", db1.Name, db2.Name);
            if (excludedtables != null && excludedtables.Length > 0)
                stdio.WriteLine("ignore tables: {0}", string.Join(",", excludedtables));
            return Compare.DatabaseDifference(db1, db2, excludedtables);
        }

  
        public string CompareTable(ActionType actiontype, SideType sidetype, TableName tname1, TableName tname2, Dictionary<string, string[]> pk)
        {
            TableSchema schema1 = new TableSchema(tname1);
            TableSchema schema2 = new TableSchema(tname2);

            if (!Exists(tname1) || !Exists(tname2))
                return string.Empty;

            string sql = string.Empty;

            if (actiontype == ActionType.CompareSchema)
            {
                stdio.WriteLine("{0} table schema {1} => {2}", sidetype, tname1, tname2);
                sql = Compare.TableSchemaDifference(tname1, tname2);
            }
            else if (actiontype == ActionType.CompareData)
            {
                stdio.WriteLine("{0} table data {1} => {2}", sidetype, tname1, tname2);
                bool hasPk = schema1.PrimaryKeys.Length > 0;
                sql = Compare.TableDifference(sidetype, schema1, schema2, schema1.PrimaryKeys.Keys);

                if (!hasPk)
                {
                    stdio.WriteLine("warning: no primary key found : {0}", tname1);

                    string key = tname1.Name.ToUpper();
                    if (pk.ContainsKey(key))
                    {
                        stdio.WriteLine("use predefine keys defined in ini file: {0}", tname1);
                        sql = Compare.TableDifference(sidetype, schema1, schema2, pk[key]);
                    }
                    else
                    {
                        stdio.WriteLine("use entire row as primary keys:{0}", tname1);
                        var keys = schema1.Columns.Select(row => row.ColumnName).ToArray();
                        sql = Compare.TableDifference(sidetype, schema1, schema2, keys);
                    }
                }
            }

            if (sql != string.Empty && sidetype == SideType.compare)
                stdio.WriteLine(sql);

            return sql;
        }

    }
}

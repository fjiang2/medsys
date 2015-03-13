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

    class CompareAdapter  
    {
        private Compare compare;

        public Side Side1 {get; private set;}
        public Side Side2 {get; private set;}

        public CompareAdapter(SqlConnectionStringBuilder cs1, SqlConnectionStringBuilder cs2)
        {
            this.Side1 = new Side(cs1);
            this.Side2 = new Side(cs2);
            this.compare = new Compare(this.Side1.Provider, this.Side2.Provider);
        }
     
        private static bool Exists(TableName tname)
        {
            if (!tname.Exists())
            {
                stdio.WriteLine("table not exists : {0}", tname);
                return false;
            }

            return true;
        }

        private static bool Exists(DatabaseName dname)
        {
            if (!dname.Exists())
            {
                stdio.WriteLine("table not exists : {0}", dname);
                return false;
            }

            return true;
        }


        public string Run(CompareAction CompareType, MatchedDatabase m1, MatchedDatabase m2, Dictionary<string, string[]> pk)
        {
            DatabaseName db1 = Side1.DatabaseName;
            DatabaseName db2 = Side2.DatabaseName;


            stdio.WriteLine("server1: {0} default database:{1}", db1.Name, db2.Name);
            stdio.WriteLine("server2: {0} default database:{1}", db1.Name, db2.Name);
           
            if (!Exists(db1) || !Exists(db2))
                return string.Empty;

            StringBuilder builder = new StringBuilder();

            var N1 = m1.MatchedTableNames;
            var N2 = m2.MatchedTableNames;
            string sql;

            if (N1 != null && N2 != null)
            {
                if (N1.Length != N2.Length)
                {
                    stdio.WriteLine("number of comparing table are different: {0}!={1}", N1.Length, N2.Length);
                    return string.Empty;
                }
                for(int i=0; i<N1.Length; i++)
                {
                    if (m1.Includes(N1[i]))
                    {
                        stdio.WriteLine("skip to compare data on table {0}", N1[i]);
                    }
                    else if (m2.Includes(N2[i]))
                    {
                        stdio.WriteLine("skip to compare data on table {0}", N2[i]);
                    }

                    builder.Append(CompareTable(N1[i], N2[i], pk));
                }
            }
            else if (CompareType == CompareAction.CompareSchema)
            {
                sql = CompareDatabaseSchema(db1, db2);

                if (sql != string.Empty)
                    builder.Append(sql);
            }
            else if (CompareType == CompareAction.CompareData)
            {
                sql = CompareDatabaseSchema(db1, db2);

                if (sql != string.Empty)
                    builder.Append(sql);

                sql = CompareDatabaseData(db1, db2, m1.Excludedtables);
                if (sql != string.Empty)
                    builder.Append(sql);

            }

            return builder.ToString();
        }

        private string CompareDatabaseSchema(DatabaseName db1, DatabaseName db2)
        {
            stdio.WriteLine("compare database schema {0} => {1}", db1.Name, db2.Name);
            return compare.DatabaseSchemaDifference(db1, db2);
        }

        private string CompareDatabaseData(DatabaseName db1, DatabaseName db2, string[] excludedtables)
        {
            stdio.WriteLine("compare database data {0} => {1}", db1.Name, db2.Name);
            if (excludedtables != null && excludedtables.Length > 0)
                stdio.WriteLine("ignore tables: {0}", string.Join(",", excludedtables));
            return compare.DatabaseDifference(db1, db2, excludedtables);
        }

        private string CompareTable(string tableName1, string tableName2, Dictionary<string, string[]> pk)
        {
            TableName tname1 = new TableName(Side1.DatabaseName, tableName1);
            TableName tname2 = new TableName(Side2.DatabaseName, tableName2);

            if (!Exists(tname1) || !Exists(tname2))
                return string.Empty;

            stdio.WriteLine("compare table schema {0} => {1}", tableName1, tableName2);
            string sql = compare.TableSchemaDifference(tname1, tname2);

            if (sql == string.Empty)
            {
                stdio.WriteLine("compare table data {0} => {1}", tableName1, tableName2);
                bool hasPk;
                sql = compare.TableDifference(tname1, tname2, out hasPk);

                if (!hasPk)
                {
                    stdio.WriteLine("warning: no primary key found : {0}", tname1);

                    string key = tname1.Name.ToUpper();
                    if (pk.ContainsKey(key))
                    {
                        stdio.WriteLine("use predefine keys defined in ini file: {0}", tname1);
                        sql = compare.TableDifference(tname1, tname2, pk[key]);
                    }
                }

                if (sql != string.Empty)
                    stdio.WriteLine(sql);
            }

            return sql;
        }

    

    }
}

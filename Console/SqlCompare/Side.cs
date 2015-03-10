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
    class Side : Logger
    {
        private SqlConnectionStringBuilder cs;
        private string tableNamePattern;

        public readonly DataProvider Provider;

        public Side(SqlConnectionStringBuilder cs, string tableNamePattern)
        {
            this.cs = cs;
            this.tableNamePattern = tableNamePattern;

            this.Provider = DataProviderManager.Register("side", DataProviderType.SqlServer, cs.ConnectionString);
            this.DatabaseName = new DatabaseName(Provider, cs.InitialCatalog);
        }

        public string[] TableNames
        {
            get
            {
                if (tableNamePattern == null)
                    return null;

                var names = Search(tableNamePattern, this.DatabaseName.GetTableNames());
                return names;
            }
        }

        public DatabaseName DatabaseName { get; private set; }

        public void ExecuteScript(string sql)
        {
            string[] S = sql.Split(new string[] { "\r\nGO\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in S)
            {
                if (s.Replace("\r\n", "").Replace(" ", "").Replace("\t", "") == string.Empty)
                    continue;

                new SqlCmd(Provider, s).ExecuteNonQuery();
            }
        }

        public string AllRows(string[] tableNames)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var tableName in tableNames)
            {
                Log("generate insert clauses on table : {0}", tableName);
                var tname = new TableName(Provider, tableName);
                string sql = Compare.AllRows(tname, null);
                if (sql != String.Empty)
                    builder.AppendLine(sql);
            }

            return builder.ToString();
        }

        public string AllRows(string tableName, string where)
        {
            var tname = new TableName(Provider, tableName);
            string sql = Compare.AllRows(tname, where);
            return sql;
        }

        public void DisplayColumns()
        {
            var names = TableNames;
            if(names.Length == 0)
            {
                Log("no table found");
                return;
            }

            foreach (string tableName in names)
            {
                Log("[{0}]",tableName);
                TableName tname = new TableName(Provider, tableName);
                var dt = tname.TableSchema();
                ConsoleTable.DisplayTable(dt);
            }
        }
        
        public void DisplayPK()
        {
            var names = TableNames;
            if (names.Length == 0)
            {
                Log("no table found");
                return;
            }

            foreach (string tableName in names)
            {
                Log("[{0}]", tableName);
                TableName tname = new TableName(Provider, tableName);
                var dt = tname.PrimaryKeySchema();
                ConsoleTable.DisplayTable(dt);
            }
        }

        public void DisplayFK()
        {
            var names = TableNames;
            if (names.Length == 0)
            {
                Log("no table found");
                return;
            }

            foreach (string tableName in names)
            {
                Log("[{0}]", tableName);
                TableName tname = new TableName(Provider, tableName);
                var dt = tname.ForeignKeySchema();
                ConsoleTable.DisplayTable(dt);
            }
        }


        public static string[] Search(string pattern, string[] tableNames)
        {
            string x = "^" + Regex.Escape(pattern)
                                  .Replace(@"\*", ".*")
                                  .Replace(@"\?", ".")
                           + "$";

            Regex regex = new Regex(x, RegexOptions.IgnoreCase);
            var result = tableNames.Where(row => regex.IsMatch(row)).ToArray();

            return result;
        }
    }
}

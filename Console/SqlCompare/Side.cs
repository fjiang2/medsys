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
    class Side : stdio
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

        public string[] MatchedTableNames
        {
            get
            {
                if (tableNamePattern == null)
                    return null;

                var names = Search(tableNamePattern, this.DatabaseName.GetDependencyTableNames());
                return names;
            }
        }

        public string[] DefaultTableNames
        {
            get
            {
                string[] names = this.DatabaseName.GetTableNames();
                if (tableNamePattern == null)
                    return names;

                names = Search(tableNamePattern, names);

                return names;
            }
        }


        public DatabaseName DatabaseName { get; private set; }


        public string GenerateScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(DatabaseName.GenerateDropTableScript());
            builder.Append(DatabaseName.GenerateScript());
            return builder.ToString();
        }

        public void ExecuteScript(string scriptFile)
        {
            if (!File.Exists(scriptFile))
            {
                WriteLine("input file not found: {0}", scriptFile);
                return;
            }

            StringBuilder builder = new StringBuilder();
            using (var reader = new StreamReader(scriptFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line == "GO")
                    {
                        string sql = builder.ToString();
                        new SqlCmd(this.Provider, sql).ExecuteNonQuery();
                        builder.Clear();
                    }
                    else if (line != string.Empty)
                        builder.AppendLine(line);
                }
            }
        }

        public string GenerateRowScript(string[] excludedtables)
        {
            List<string> list = new List<string>();
            foreach (string name in this.DefaultTableNames)
            {
                if (!excludedtables.Contains(name.ToUpper()))
                    list.Add(name);
            }
            
            return GenerateRows(list.ToArray());
        }



        private string GenerateRows(string[] tableNames)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var tableName in tableNames)
            {
                WriteLine("generate insert clauses on table : {0}", tableName);
                var tname = new TableName(Provider, tableName);
                string sql = Compare.GenerateRows(tname, null);
                if (sql != String.Empty)
                    builder.AppendLine(sql);
            }

            return builder.ToString();
        }

        private string GenerateRows(string tableName, string where)
        {
            var tname = new TableName(Provider, tableName);
            string sql = Compare.GenerateRows(tname, where);
            return sql;
        }

       


        public void DisplayMatchedTableNames(string pattern)
        {
            if (pattern == null)
                DisplayTableNames(this.DatabaseName.GetTableNames());
            else
            {
                var names = Search(pattern, this.DatabaseName.GetTableNames());
                DisplayTableNames(names);
            }
        }


        public void DisplayTableNames(string[] names)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Table Name");
            foreach (string item in names)
            {
                var newRow = dt.NewRow();
                newRow[0] = item;
                dt.Rows.Add(newRow);
            }

            ConsoleTable.DisplayTable(dt);
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

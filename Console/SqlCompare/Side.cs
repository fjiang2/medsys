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
    class Side
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
                    return new string[0];

                var names = Search(tableNamePattern, this.DatabaseName.GetTableNames());
                return names;
            }
        }

        public DatabaseName DatabaseName { get; private set; }
      

        public string AllRows()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var tableName in TableNames)
            {
                var tname = new TableName(Provider, tableName);
                string sql = Compare.AllRows(tname, null);
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

        public void DisplayPK()
        {
            var names = TableNames;
            if(names.Length == 0)
            {
                Console.WriteLine("no table found");
                return;
            }

            foreach (string tableName in names)
            {
                Console.WriteLine("[{0}]",tableName);
                DisplayPK(tableName);
            }
        }

        public void DisplayPK(string tableName)
        {
            TableName tname = new TableName(Provider, tableName);
            var dt = tname.PrimaryKeySchema();
            Display(dt);
        }

        public void DisplayFK()
        {
            var names = TableNames;
            if (names.Length == 0)
            {
                Console.WriteLine("no table found");
                return;
            }

            foreach (string tableName in names)
            {
                Console.WriteLine("[{0}]", tableName);
                DisplayFK(tableName);
            }
        }
        public void DisplayFK(string tableName)
        {
            TableName tname = new TableName(Provider, tableName);
            var dt = tname.ForeignKeySchema();
            Display(dt);
        }

        private void Display(DataTable dt)
        {
            StringBuilder builder = new StringBuilder();
            foreach (DataColumn column in dt.Columns)
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

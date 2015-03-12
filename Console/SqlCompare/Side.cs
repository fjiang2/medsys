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
        public readonly DataProvider Provider;
        public readonly DatabaseName DatabaseName;


        public Side(SqlConnectionStringBuilder cs)
        {
            this.cs = cs;

            this.Provider = DataProviderManager.Register("side", DataProviderType.SqlServer, cs.ConnectionString);
            this.DatabaseName = new DatabaseName(Provider, cs.InitialCatalog);
        }




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

        public string GenerateRowScript(string tableNamePattern, string[] excludedtables)
        {
            List<string> list = new List<string>();
            MatchedDatabase m = new MatchedDatabase(this.DatabaseName, tableNamePattern, excludedtables);
            foreach (string name in m.DefaultTableNames)
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

       



    }
}

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
        public readonly SqlConnectionStringBuilder CS;
        public readonly DataProvider Provider;
        public readonly DatabaseName DatabaseName;


        public Side(SqlConnectionStringBuilder cs)
        {
            this.CS = cs;

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
                stdio.WriteLine("input file not found: {0}", scriptFile);
                return;
            }

            StringBuilder builder = new StringBuilder();
            using (var reader = new StreamReader(scriptFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line == "GO" || line=="go")
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

        public void GenerateRowScript(StreamWriter writer, string tableNamePattern, string[] excludedtables)
        {
            List<string> list = new List<string>();
            MatchedDatabase m = new MatchedDatabase(this.DatabaseName, tableNamePattern, excludedtables);

            string[] history = this.DatabaseName.GetDependencyTableNames();

            foreach (string name in history)
            {
                if (m.DefaultTableNames.Contains(name))
                {
                    if (!excludedtables.Contains(name.ToUpper()))
                        list.Add(name);
                }
            }

            GenerateRows(writer, list.ToArray());
        }



        private void GenerateRows(StreamWriter writer, string[] tableNames)
        {
            foreach (var tableName in tableNames)
            {
                stdio.WriteLine("generate insert clauses on table : {0}", tableName);
                var tname = new TableName(Provider, tableName);
                Compare.GenerateRows(writer, new TableSchema(tname), null);
            }
        }

        private void GenerateRows(StreamWriter writer, string tableName, string where)
        {
            var tname = new TableName(Provider, tableName);
            Compare.GenerateRows(writer, new TableSchema(tname), where);
        }

       



    }
}

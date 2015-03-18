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

            this.Provider = DataProviderManager.Register(cs);
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
            List<TableName> list = new List<TableName>();
            MatchedDatabase m = new MatchedDatabase(this.DatabaseName, tableNamePattern, excludedtables);

            string[] history = this.DatabaseName.GetDependencyTableNames();

            foreach (string name in history)
            {
                if (m.DefaultTableNames.Contains(name))
                {
                    if (!excludedtables.Contains(name.ToUpper()))
                        list.Add(new TableName(this.DatabaseName, name));
                }
            }

            GenerateRows(writer, list.ToArray());
        }



        private void GenerateRows(StreamWriter writer, TableName[] tableNames)
        {
            foreach (var tableName in tableNames)
            {
                stdio.WriteLine("generate insert clauses on table : {0}", tableName);
                Compare.GenerateRows(writer, new TableSchema(tableName), null);
            }
        }

        public void GenerateRows(StreamWriter writer, TableName tableName, string where)
        {
            Compare.GenerateRows(writer, new TableSchema(tableName), where);
        }



        public override string ToString()
        {
            return string.Format("Side: Server= {0} Db={1}",CS.DataSource, this.DatabaseName.Name);
        }

    }
}

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
    class Side  : IDataPath
    {
        public DatabaseName DatabaseName { get; private set; }
        private ConnectionProvider provider;

        public Side(ConnectionProvider provider)
        {
            this.provider = provider;
            this.DatabaseName = new DatabaseName(provider, Provider.InitialCatalog);
        }


        public void UpdateDatabase(ConnectionProvider provider)
        {
            this.provider = provider;
            this.DatabaseName = new DatabaseName(provider, Provider.InitialCatalog);
        }
      
        public ConnectionProvider Provider
        {
            get { return this.provider; }
        }


        public string Path
        {
            get { return this.provider.Name; }
        }

        public string GenerateScript()
        {
            return DatabaseName.GenerateScript();
        }

        public void ExecuteScript(string scriptFile)
        {
            if (!File.Exists(scriptFile))
            {
                stdio.WriteLine("input file not found: {0}", scriptFile);
                return;
            }

            new SqlScript(this.Provider, scriptFile).Execute();
        }

        public void GenerateRowScript(StreamWriter writer, string tableNamePattern, string[] excludedtables)
        {
            List<TableName> list = new List<TableName>();
            MatchedDatabase m = new MatchedDatabase(this.DatabaseName, tableNamePattern, excludedtables);

            TableName[] history = this.DatabaseName.GetDependencyTableNames();

            foreach (var name in history)
            {
                if (m.DefaultTableNames.Contains(name))
                {
                    if (!excludedtables.Contains(name.ShortName.ToUpper()))
                        list.Add(name);
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

        public int GenerateRows(StreamWriter writer, TableName tableName, Locator where)
        {
            return Compare.GenerateRows(writer, new TableSchema(tableName), where);
        }


        public string GenerateTemplate(TableName tableName, SqlScriptType type)
        {
            return Compare.GenerateTemplate(new TableSchema(tableName), type);
        }
        
        public override string ToString()
        {
            return string.Format("Server={0}, Db={1}",Provider.DataSource, this.DatabaseName.Name);
        }

    }
}

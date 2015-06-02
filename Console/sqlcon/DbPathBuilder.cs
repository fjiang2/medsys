using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using Sys.Data;


namespace sqlcon
{

    enum DbPathLevel
    {
        DataSource,
        Catalog,
        Table,
        Locator,
        Column
    }

    class DbPathBuilder
    {
        Configuration cfg;
        ConnectionProvider provider;
        TableName TableName;
        Locator Locater;

        public DbPathBuilder(Configuration cfg, ConnectionProvider provider)
        {
            this.cfg = cfg;
            this.provider = provider;
        }

        public DbPathLevel current = DbPathLevel.Catalog;

        
        public void ChangePath(string path)
        {
            string[] paths = path.Split('\\');
            int n = paths.Length;

            if (string.IsNullOrEmpty(paths[0]))
            {
                if (n > 1)
                    ChangeDataSource(paths[1]);
                   
                if (n > 2)
                    this.provider.Catalog = paths[2];

                if (n > 3)
                    this.TableName = new TableName(this.provider, paths[3]);

                if (n > 4)
                    this.Locater = new Locator(paths[4]);

            }

        }


        private void ChangeDataSource(string alias)
        {
            var conn = cfg.GetConnectionString(alias);
            if (conn != null)
            {
                DbConnectionStringBuilder builder;
                if (conn.ToLower().IndexOf("sqloledb") >= 0)
                    builder = new OleDbConnectionStringBuilder(conn);
                else
                    builder = new SqlConnectionStringBuilder();

                this.provider.DataSource = builder["Data Source"].ToString();
            }
            else
            {
                stdio.ShowError("undefined database server alias : {0}", alias);
                return;
            }
        }
    }
}

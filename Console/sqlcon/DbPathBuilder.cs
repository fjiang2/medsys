using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using Sys.Data;
using Sys;

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
        private Configuration cfg;
        private Tree<IDataElementName> tree = new Tree<IDataElementName>();

        public DbPathBuilder(Configuration cfg)
        {
            this.cfg = cfg;
            var snames = cfg.GetServerNames();

            foreach (var sname in snames)
                AddDataSource(sname);

            if (tree.Nodes.Count > 0)
                current = tree.Nodes.First();
        }

        public TreeNode<IDataElementName> current;

        public void AddDataSource(ServerName name)
        {
            var snode = new TreeNode<IDataElementName>(name);
            tree.Nodes.Add(snode);
        }

        public void AddCatalog(DatabaseName name)
        {
            var snode = tree.Nodes.Find(node => (node.Item as ServerName) == name.ServerName);
            snode.Nodes.Add(new TreeNode<IDataElementName>(name));
        }

        public void AddTable(TableName name)
        {
            tree.Nodes.Add(new TreeNode<IDataElementName>(name));
        }

        public void AddLocator(TableName name)
        {
            tree.Nodes.Add(new TreeNode<IDataElementName>(name));
        }


        ConnectionProvider provider;

        public void ChangePath(string path)
        {
            string[] paths = path.Split('\\');
            int n = paths.Length;

            if (string.IsNullOrEmpty(paths[0]))
            {
                if (n > 1)
                    ChangeDataSource(paths[1]);
                   

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

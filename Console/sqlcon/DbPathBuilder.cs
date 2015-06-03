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
        Root,
        DataSource,
        Catalog,
        Table,
        Locator,
        Column
    }



    class DbPathBuilder 
    {
        private Configuration cfg;
        private Tree<IDataElementName> tree;
        private TreeNode<IDataElementName> current;

        public DbPathBuilder(Configuration cfg)
        {
            tree = new Tree<IDataElementName>();
            current = tree.RootNode;

            this.cfg = cfg;
            var snames = cfg.GetServerNames();

            foreach (var sname in snames)
                AddDataSource(sname);

        }


        public void AddDataSource(ServerName name)
        {
            var snode = new TreeNode<IDataElementName>(name);
            tree.Nodes.Add(snode);
        }

        public DbPathLevel Level
        {
            get
            {
                if (current == tree.RootNode)
                    return DbPathLevel.Root;

                if (current.Item is ServerName)
                    return DbPathLevel.DataSource;

                if (current.Item is DatabaseName)
                    return DbPathLevel.Catalog;

                if (current.Item is TableName)
                    return DbPathLevel.Table;

                if (current.Item is Locator)
                    return DbPathLevel.Locator;

                return DbPathLevel.Column;
            }
        }

        public IDataElementName Current
        {
            get { return this.current.Item; }
        }

        public ServerName ServerName
        {
            get
            {
                var p = current;
                while (!(p.Item is ServerName))
                {
                    p = p.Parent;
                }
                return (ServerName)p.Item;
            }
        }

        public void ChangePath(string path, bool refresh)
        {
            if (string.IsNullOrEmpty(path) || path == "\\")
            {
                current = tree.RootNode;
                return;
            }
            else if (path == ".")
            {
                return;
            }
            else if (path == "..")
            {
                if (current != tree.RootNode)
                    current = current.Parent;

                return;
            }

            if (current.Item is ServerName)
            {
                ServerName sname = (ServerName)current.Item;
                if (refresh || current.Nodes.Count == 0)
                {
                    if (refresh)
                        current.Nodes.Clear();

                    DatabaseName[] dnames = sname.GetDatabaseNames();
                    foreach (var dname in dnames)
                        current.Nodes.Add(new TreeNode<IDataElementName>(dname));
                }
            }
            else if (current.Item is DatabaseName)
            {
                DatabaseName dname = (DatabaseName)current.Item;
                if (refresh || current.Nodes.Count == 0)
                {
                    if (refresh)
                        current.Nodes.Clear();

                    TableName[] tnames = dname.GetTableNames();
                    foreach (var tname in tnames)
                        current.Nodes.Add(new TreeNode<IDataElementName>(tname));
                }
            }


            var node = current.Nodes.Find(x => x.Item.Name == path);
            if (node != null)
                current = node;
            else
                stdio.ShowError("invalid path:{0}", path);

            return;
        }

        
        public void ChangePath(string path)
        {
            string[] items = path.Split('\\');
            int n = items.Length;

            foreach(string item in items)
            {
                ChangePath(item, false);
            }

        }

        public override string ToString()
        {
            List<string> items = new List<string>();
            var p = current;
            while (p != tree.RootNode)
            {
                items.Add(current.Item.Name);
                p = p.Parent;
            }
            
            items.Reverse();
            return string.Join("\\", items);
        }
    }
}

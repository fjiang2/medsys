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



    class DbPathTree 
    {
        private Configuration cfg;
        private Tree<IDataElementName> tree;
        private TreeNode<IDataElementName> current;

        public DbPathTree(Configuration cfg)
        {
            tree = new Tree<IDataElementName>();
            current = tree.RootNode;

            this.cfg = cfg;
            var snames = cfg.ServerNames;

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

            Expand(current, refresh);

            var node = current.Nodes.Find(x => x.Item.Name == path);
            if (node != null)
                current = node;
            else
                stdio.ShowError("invalid path:{0}", path);

            return;
        }

        private void Expand(TreeNode<IDataElementName> node, bool refresh)
        {
            if (node == tree.RootNode)
            {
            }
            else if (node.Item is ServerName)
            {
                ExpandServerName(node, refresh);
            }
            else if (node.Item is DatabaseName)
            {
                ExpandDatabaseName(node, refresh);
            }
        }

        private static void ExpandServerName(TreeNode<IDataElementName> node, bool refresh)
        {
            ServerName sname = (ServerName)node.Item;
            if (refresh || node.Nodes.Count == 0)
            {
                if (refresh)
                    node.Nodes.Clear();

                DatabaseName[] dnames = sname.GetDatabaseNames();
                foreach (var dname in dnames)
                    node.Nodes.Add(new TreeNode<IDataElementName>(dname));
            }
        }

        private static void ExpandDatabaseName(TreeNode<IDataElementName> node, bool refresh)
        {
            DatabaseName dname = (DatabaseName)node.Item;
            if (refresh || node.Nodes.Count == 0)
            {
                if (refresh)
                    node.Nodes.Clear();

                TableName[] tnames = dname.GetTableNames();
                foreach (var tname in tnames)
                    node.Nodes.Add(new TreeNode<IDataElementName>(tname));
            }
        }

        public void ChangePath(ServerName serverName, DatabaseName databaseName)
        { 
            string path = string.Format(@"\{0}\{1}", serverName.Name, databaseName.Name);
            ChangePath(path);
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


        public void dir()
        {
            //ChangePath(path);

            if (current.Nodes.Count == 0)
                Expand(current, true);

            if (current.Item is DatabaseName)
            {
                foreach (var node in current.Nodes)
                {
                    TableName tname = (TableName)node.Item;
                    int count = new SqlCmd(tname.Provider, string.Format("SELECT COUNT(*) FROM {0}", tname)).FillObject<int>();
                    stdio.WriteLine("{0,20} {1,12} Row(s)", tname.Name, count);
                }

                stdio.WriteLine("\t{0} Table(s) {1} View(s)", current.Nodes.Count, 0);
            }
        }

        public override string ToString()
        {
            List<string> items = new List<string>();
            var p = current;
            while (p != tree.RootNode)
            {
                items.Add(p.Item.Name);
                p = p.Parent;
            }
            
            items.Reverse();
            return string.Join("\\", items);
        }
    }
}

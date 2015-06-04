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
        private Tree<IDataPath> tree;
        private TreeNode<IDataPath> current;

        public DbPathTree(Configuration cfg)
        {
            tree = new Tree<IDataPath>();
            current = tree.RootNode;

            this.cfg = cfg;
            var snames = cfg.ServerNames;

            foreach (var sname in snames)
                AddDataSource(sname);

        }

        public void AddDataSource(ServerName name)
        {
            var snode = new TreeNode<IDataPath>(name);
            tree.Nodes.Add(snode);
        }


        private bool IsRootNode
        {
            get { return current == tree.RootNode; }
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

        public IDataPath Current
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
            if (path == "\\")
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

            var node = current.Nodes.Find(x => x.Item.Path == path);
            if (node != null)
                current = node;
            else
                stdio.ShowError("invalid path", path);

            return;
        }

        private void Expand(TreeNode<IDataPath> node, bool refresh)
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
            else if (node.Item is TableName)
            {
                ExpandTableName(node, refresh);
            }
        }

        private static void ExpandServerName(TreeNode<IDataPath> node, bool refresh)
        {
            ServerName sname = (ServerName)node.Item;
            if (refresh || node.Nodes.Count == 0)
            {
                if (refresh)
                    node.Nodes.Clear();

                DatabaseName[] dnames = sname.GetDatabaseNames();
                foreach (var dname in dnames)
                    node.Nodes.Add(new TreeNode<IDataPath>(dname));
            }
        }

        private static void ExpandDatabaseName(TreeNode<IDataPath> node, bool refresh)
        {
            DatabaseName dname = (DatabaseName)node.Item;
            if (refresh || node.Nodes.Count == 0)
            {
                if (refresh)
                    node.Nodes.Clear();

                TableName[] tnames = dname.GetTableNames();
                foreach (var tname in tnames)
                    node.Nodes.Add(new TreeNode<IDataPath>(tname));
            }
        }

        private static void ExpandTableName(TreeNode<IDataPath> node, bool refresh)
        {
            TableName tname = (TableName)node.Item;
            if (refresh || node.Nodes.Count == 0)
            {
                if (refresh)
                    node.Nodes.Clear();

                //TableName[] tnames = tname.;
                //foreach (var tname in tnames)
                //    node.Nodes.Add(new TreeNode<IDataElementName>(tname));
            }
        }

        public void ChangePath(ServerName serverName, DatabaseName databaseName)
        { 
            string path = string.Format(@"\{0}\{1}", serverName.Path, databaseName.Path);
            ChangePath(path);
        }
        
        public void ChangePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            string[] items = path.Split('\\');
            if (string.IsNullOrEmpty(items[0]))
                items[0] = "\\";

            foreach(string item in items)
            {
                if(!string.IsNullOrEmpty(item))
                    ChangePath(item, false);
            }

        }


        public void dir()
        {
            //ChangePath(path);

            var pt = current;

            if (pt.Nodes.Count == 0)
                Expand(pt, true);

            if (pt == tree.RootNode)
            {
                foreach (var node in pt.Nodes)
                {
                    ServerName sname = (ServerName)node.Item;

                    int count = 0;
                    if (node.Nodes.Count == 0)
                        ExpandServerName(node, true);

                    count = node.Nodes.Count;

                    stdio.WriteLine("{0,26} <SVR> {1,10} Database(s)", sname.Path, count);
                }

                stdio.WriteLine("\t{0} Server(s)", pt.Nodes.Count);
            }
            else if (pt.Item is ServerName)
            {
                foreach (var node in pt.Nodes)
                {
                    DatabaseName dname = (DatabaseName)node.Item;
                    
                    int count = 0;
                    if (node.Nodes.Count == 0)
                        ExpandDatabaseName(node, true);

                    count = node.Nodes.Count;

                    stdio.WriteLine("{0,26} <DB> {1,10} Table(s)", dname.Name, count);
                }

                stdio.WriteLine("\t{0} Database(s)", pt.Nodes.Count);
            
            }
            else if (pt.Item is DatabaseName)
            {
                foreach (var node in pt.Nodes)
                {
                    TableName tname = (TableName)node.Item;
                    int count = new SqlCmd(tname.Provider, string.Format("SELECT COUNT(*) FROM {0}", tname)).FillObject<int>();
                    stdio.WriteLine("{0,16}.{1,-38} <TAB> {2,10} Row(s)", tname.SchemaName, tname.Name, count);
                }

                stdio.WriteLine("\t{0} Table(s)", pt.Nodes.Count);
                stdio.WriteLine("\t{0} View(s)", 0);
            }
        }

        public override string ToString()
        {
            List<string> items = new List<string>();
            var p = current;
            while (p != tree.RootNode)
            {
                items.Add(p.Item.Path);
                p = p.Parent;
            }
            
            items.Reverse();
            return string.Join("\\", items);
        }
    }
}

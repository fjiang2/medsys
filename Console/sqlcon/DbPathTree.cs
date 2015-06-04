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

        public bool Refreshing { get; set; }

        #region Navigate TreeNode

        private TreeNode<IDataPath> Navigate(string path)
        {
            if (string.IsNullOrEmpty(path))
                return current;

            string[] segments = path.Split('\\');
            if (string.IsNullOrEmpty(segments[0]))
                segments[0] = "\\";

            var node = current;
            foreach (string segment in segments)
            {
                if (string.IsNullOrEmpty(segment))
                    break;

                node = Navigate(node, segment);
                if (node == null)
                    return null;
            }

            return node;
        }

        private TreeNode<IDataPath> Navigate(TreeNode<IDataPath> node, string segment)
        {
            if (segment == "\\")
            {
                return tree.RootNode;
            }
            else if (segment == ".")
            {
                return node;
            }
            else if (segment == "..")
            {
                if (node != tree.RootNode)
                    return node.Parent;
                else
                    return node;
            }

            Expand(node);

            var xnode = node.Nodes.Find(x => x.Item.Path == segment);
            if (xnode != null)
                return xnode;
            else
            {
                int result;
                if (int.TryParse(segment, out result))
                {
                    result--;

                    if (result >= 0 && result < node.Nodes.Count)
                        return node.Nodes[result];
                }
                
                stdio.ShowError("invalid path", segment);
                return null;
            }
        }

        #endregion

        public void ChangePath(ServerName serverName, DatabaseName databaseName)
        {
            string path = string.Format(@"\{0}\{1}", serverName.Path, databaseName.Path);
            ChangePath(path);
        }

        public void ChangePath(string path)
        {
            var node = Navigate(path);
            if (node != null)
                current = node;

            return;
        }

        #region Expand TreeNode

        private void Expand(TreeNode<IDataPath> node)
        {
            if (node == tree.RootNode)
            {
            }
            else if (node.Item is ServerName)
            {
                ExpandServerName(node, this.Refreshing);
            }
            else if (node.Item is DatabaseName)
            {
                ExpandDatabaseName(node, this.Refreshing);
            }
            else if (node.Item is TableName)
            {
                ExpandTableName(node, this.Refreshing);
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
        
        #endregion

      

        public void dir(string path)
        {
            var pt = current;
            if (path != null)
            {
                pt = Navigate(path);
            }

            if (pt.Nodes.Count == 0)
                Expand(pt);

            if (pt == tree.RootNode)
            {
                int i = 0;
                foreach (var node in pt.Nodes)
                {
                    ServerName sname = (ServerName)node.Item;

                    int count = 0;
                    if (node.Nodes.Count == 0)
                        ExpandServerName(node, true);

                    count = node.Nodes.Count;

                    stdio.WriteLine("{0,2}. {1,26} <SVR> {2,10} Databases", ++i, sname.Path, count);
                }

                stdio.WriteLine("\t{0} Server(s)", pt.Nodes.Count);
            }
            else if (pt.Item is ServerName)
            {
                int i = 0;
                foreach (var node in pt.Nodes)
                {
                    DatabaseName dname = (DatabaseName)node.Item;
                    
                    int count = 0;
                    if (node.Nodes.Count == 0)
                        ExpandDatabaseName(node, true);

                    count = node.Nodes.Count;

                    stdio.WriteLine("{0,2}. {1,26} <DB> {2,10} Tables", ++i, dname.Name, count);
                }

                stdio.WriteLine("\t{0} Database(s)", pt.Nodes.Count);
            
            }
            else if (pt.Item is DatabaseName)
            {
                int i = 0;
                foreach (var node in pt.Nodes)
                {
                    TableName tname = (TableName)node.Item;
                    int count = new SqlCmd(tname.Provider, string.Format("SELECT COUNT(*) FROM {0}", tname)).FillObject<int>();
                    stdio.WriteLine("{0,2}. {1,15}.{2,-37} <TAB> {3,10} Rows", ++i, tname.SchemaName, tname.Name, count);
                }

                stdio.WriteLine("\t{0} Table(s)", pt.Nodes.Count);
                stdio.WriteLine("\t{0} View(s)", 0);
            }
            else if (pt.Item is TableName)
            {
                stdio.WriteLine("\t{0} Column(s)", pt.Nodes.Count);
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
            return "\\" + string.Join("\\", items);
        }
    }
}

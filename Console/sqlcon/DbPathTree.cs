using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text.RegularExpressions;
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

        public DatabaseName CurrentDatabaseName
        {
            get
            {
                if (current == tree.RootNode)
                    return null;

                var p = current;
                while (!(p.Item is DatabaseName))
                {
                    p = p.Parent;

                    if (p == null)
                        return null;
                }

                return (DatabaseName)p.Item;
            }
        }

        public bool Refreshing { get; set; }

        private string[] parsePath(string path, out string wildcard)
        {
            wildcard = null;

            if (string.IsNullOrEmpty(path))
                return new string[0];

            string[] segments = path.Split('\\');
            int n1 = 0;
            int n2 = segments.Length - 1;

            if (string.IsNullOrEmpty(segments[n1]))
                segments[n1] = "\\";

            if (segments[n2] == "")
                return segments.Take(n2).ToArray();
            else if (segments[n2].IndexOf('*') >= 0 || segments[n2].IndexOf('?') >= 0)
            {
                wildcard = segments[n2];
                return segments.Take(n2).ToArray();
            }
            
            return segments;
        }

        #region Navigate TreeNode

        private TreeNode<IDataPath> Navigate(string[] segments)
        {
            if (segments.Length == 0)
                return current;

            var node = current;
            foreach (string segment in segments)
            {
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

        public void chdir(ServerName serverName, DatabaseName databaseName)
        {
            string path = string.Format(@"\{0}\{1}", serverName.Path, databaseName.Path);
            chdir(path);
        }

        public bool chdir(string path)
        {
            string wildcard;
            string[] segments = parsePath(path, out wildcard);
            if (wildcard != null)
            {
                stdio.ShowError("invalid path");
                return false;
            }

            var node = Navigate(segments);
            if (node != null)
            {
                current = node;
                return true;
            }

            return false;
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
            string wildcard = null;

            if (path != null)
            {
                string[] segments = parsePath(path, out wildcard);
                pt = Navigate(segments);
            }

            if (pt.Nodes.Count == 0)
                Expand(pt);

            Func<IDataPath, bool> check = xname =>
                {
                    if (wildcard != null)
                    {
                        Regex regex = wildcard.WildcardRegex();
                        return regex.IsMatch(xname.Path);
                    }
                    return true;
                };

            if (pt == tree.RootNode)
            {
                int i = 0;
                int count = 0;
                foreach (var node in pt.Nodes)
                {
                    ServerName sname = (ServerName)node.Item;
                    ++i;

                    if (check(sname))
                    {
                        count++;
                        if (node.Nodes.Count == 0)
                            ExpandServerName(node, true);

                        stdio.WriteLine("{0,2}. {1,26} <SVR> {2,10} Databases", i, sname.Path, node.Nodes.Count);
                    }
                }

                stdio.WriteLine("\t{0} Server(s)", count);
            }
            else if (pt.Item is ServerName)
            {
                int i = 0;
                int count = 0;
                foreach (var node in pt.Nodes)
                {
                    DatabaseName dname = (DatabaseName)node.Item;
                    ++i;

                    if (check(dname))
                    {
                        count++;
                        if (node.Nodes.Count == 0)
                            ExpandDatabaseName(node, true);

                        stdio.WriteLine("{0,2}. {1,26} <DB> {2,10} Tables", i, dname.Name, node.Nodes.Count);
                    }
                }

                stdio.WriteLine("\t{0} Database(s)", count);
            
            }
            else if (pt.Item is DatabaseName)
            {
                int i = 0;
                int count = 0;
                foreach (var node in pt.Nodes)
                {
                    TableName tname = (TableName)node.Item;
                    ++i;

                    if (check(tname))
                    {
                        count++;
                        int rows = new SqlCmd(tname.Provider, string.Format("SELECT COUNT(*) FROM {0}", tname)).FillObject<int>();
                        stdio.WriteLine("{0,2}. {1,15}.{2,-37} <TAB> {3,10} Rows", i, tname.SchemaName, tname.Name, rows);
                    }
                }

                stdio.WriteLine("\t{0} Table(s)", count);
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

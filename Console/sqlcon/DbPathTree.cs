using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Text.RegularExpressions;
using Sys;
using Sys.Data;

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

        public T GetCurrent<T>() where T : IDataPath
        {
            if (current == tree.RootNode)
                return default(T);

            var p = current;
            while (!(p.Item is T))
            {
                p = p.Parent;

                if (p == null)
                    return default(T);
            }

            return (T)p.Item;
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

            string seg = segment;
            if (node.Item is DatabaseName && segment.IndexOf(".") == -1)
                seg = TableName.dbo + "." + segment;

            var xnode = node.Nodes.Find(x => x.Item.Path.ToUpper() == seg.ToUpper());
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

                if (sname.Disconnected)
                    return;

                try
                {
                    DatabaseName[] dnames = sname.GetDatabaseNames();
                    foreach (var dname in dnames)
                        node.Nodes.Add(new TreeNode<IDataPath>(dname));
                }
                catch (Exception)
                {
                    sname.Disconnected = true;
                }
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

                TableName[] vnames = dname.GetViewNames();

                foreach (var vname in vnames)
                    node.Nodes.Add(new TreeNode<IDataPath>(vname));

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

            Func<string, bool> check = xname =>
                {
                    if (wildcard != null)
                    {
                        Regex regex = wildcard.WildcardRegex();
                        return regex.IsMatch(xname);
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

                    if (check(sname.Path))
                    {
                        count++;
                        if (node.Nodes.Count == 0)
                        {
                            ExpandServerName(node, Refreshing);
                        }

                        stdio.WriteLine("[{0,2}] {1,26} <SVR> {2,10} Databases", i, sname.Path, sname.Disconnected ? "?" : node.Nodes.Count.ToString());
                    }
                }

                stdio.WriteLine("\t{0} Server(s)", count);
            }
            else if (pt.Item is ServerName)
            {
                ServerName sname = (ServerName)pt.Item;
                if (sname.Disconnected)
                {
                    stdio.WriteLine("\t? Database(s)");
                }
                else
                {
                    int i = 0;
                    int count = 0;
                    foreach (var node in pt.Nodes)
                    {
                        DatabaseName dname = (DatabaseName)node.Item;
                        ++i;

                        if (check(dname.Path))
                        {
                            count++;
                            if (node.Nodes.Count == 0)
                                ExpandDatabaseName(node, true);

                            stdio.WriteLine("[{0,2}] {1,26} <DB> {2,10} Tables", i, dname.Name, node.Nodes.Count);
                        }
                    }

                    stdio.WriteLine("\t{0} Database(s)", count);
                }
            }
            else if (pt.Item is DatabaseName)
            {
                int i = 0;
                int[] count = new int[] { 0, 0 };
                foreach (var node in pt.Nodes)
                {
                    TableName tname = (TableName)node.Item;
                    ++i;

                    if (check(tname.Path))
                    {
                        if (!tname.IsViewName) count[0]++;
                        if (tname.IsViewName) count[1]++;

                        stdio.WriteLine("[{0,3}] {1,15}.{2,-37} <{3}>", i, tname.SchemaName, tname.Name, tname.IsViewName ? "VIEW" : "TABLE");
                    }
                }

                stdio.WriteLine("\t{0} Table(s)", count[0]);
                stdio.WriteLine("\t{0} View(s)", count[1]);
            }
            else if (pt.Item is TableName)
            {
                TableName tname = (TableName)pt.Item;
                TableSchema schema = new TableSchema(tname);

                int i = 0;
                int count = 0;
                foreach (IColumn column in schema.Columns)
                {
                    if (check(column.ColumnName))
                    {
                        count++;
                        List<string> L = new List<string>();
                        if (column.IsIdentity) L.Add("++");
                        if (column.IsPrimary) L.Add("pk");
                        if ((column as ColumnSchema).FkContraintName != null) L.Add("fk");
                        string keys = string.Join(",", L);

                        stdio.WriteLine("({0:000}) {1,26} {2,-16} {3,10} {4,10}",
                            ++i,
                            string.Format("[{0}]", column.ColumnName),
                            ColumnSchema.GetSQLType(column),
                            keys,
                            column.Nullable ? "null" : "not null");
                    }
                }
                stdio.WriteLine("\t{0} Column(s)", count);
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

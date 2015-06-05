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

    partial class PathTree 
    {
        private Configuration cfg;
        private Tree<IDataPath> tree;
        private TreeNode<IDataPath> current;

        public PathTree(Configuration cfg)
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
            else if (segment == "...")
            {
                return Navigate(Navigate(node, ".."), "..");
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

        private static bool IsMatch(string wildcard, string text)
        {
            if (wildcard != null)
            {
                Regex regex = wildcard.WildcardRegex();
                return regex.IsMatch(text);
            }
            return true;
        }

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

            Display(pt, wildcard);

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

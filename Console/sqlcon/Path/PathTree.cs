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


        public PathTree(Configuration cfg)
        {
            tree = new Tree<IDataPath>();
            current = RootNode;

            this.cfg = cfg;
            var snames = cfg.ServerNames;

            foreach (var sname in snames)
            {
                var snode = new TreeNode<IDataPath>(sname);
                tree.Nodes.Add(snode);
            }
        }

        public bool Refreshing { get; set; }

        private static string[] parsePath(string path, out string wildcard)
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
            while (p != RootNode)
            {
                items.Add(p.Item.Path);
                p = p.Parent;
            }
            
            items.Reverse();
            return "\\" + string.Join("\\", items);
        }
    }
}

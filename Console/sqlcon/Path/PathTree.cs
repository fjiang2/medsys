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

       
        public void chdir(ServerName serverName, DatabaseName databaseName)
        {
            string path = string.Format(@"\{0}\{1}", serverName.Path, databaseName.Path);
            chdir(path);
        }

        public bool chdir(string path)
        {
            Command cmd = new Command(path);
            string[] segments = cmd.Segments;
            if (cmd.wildcard != null)
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

            Command cmd = new Command(path);

            if (cmd.Segments.Length != 0)
            {
                pt = Navigate(cmd.Segments);
            }

            if (pt.Nodes.Count == 0)
                Expand(pt, this.Refreshing);

            Display(pt, cmd);

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

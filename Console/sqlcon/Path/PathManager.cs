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

    partial class PathManager 
    {
        private Configuration cfg;
        private Tree<IDataPath> tree;


        public PathManager(Configuration cfg)
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
            string[] segments = new string[] { "\\", serverName.Path, databaseName.Path };
            var node = Navigate(segments);
            if (node != null)
            {
                current = node;
            }
        }

        public bool chdir(Command cmd)
        {
            if (cmd.wildcard != null)
            {
                stdio.ShowError("invalid path");
                return false;
            }

            var node = Navigate(cmd.Segments);
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

        public void dir(Command cmd)
        {
            var pt = current;

            
            if (cmd.Segments.Length != 0)
            {
                pt = Navigate(cmd.Segments);
                if (pt == null)
                    return;
            }

            if (pt.Nodes.Count == 0)
                Expand(pt, this.Refreshing);

            Display(pt, cmd);

        }

        public void set(Command cmd)
        {
            if (cmd.arg1 == null)
                return;

            var pt = current;
            if (!(pt.Item is Locator))
                return;

            Locator locator = (Locator)pt.Item;
            TableName tname = (TableName)pt.Parent.Item;

            try
            {
                int count = new SqlBuilder(tname.Provider).UPDATE(tname).SET(cmd.arg1).WHERE(locator).ExecuteNonQuery();
                stdio.WriteLine("{0} of row(s) affected", count);
            }
            catch (Exception ex)
            {
                stdio.ShowError(ex.Message);
            }
        }


        public void del(Command cmd)
        {
            var pt = current;
            if (!(pt.Item is Locator))
                return;

            Locator locator = (Locator)pt.Item;
            TableName tname = (TableName)pt.Parent.Item;
            stdio.Write("are you sure to delete (y/n)?");
            if (stdio.ReadKey() != ConsoleKey.Y)
                return;
            
            stdio.WriteLine();
            
            try
            {
                int count = new SqlBuilder(tname.Provider).DELETE(tname).WHERE(locator).ExecuteNonQuery();
                stdio.WriteLine("{0} of row(s) affected", count);
            }
            catch (Exception ex)
            {
                stdio.ShowError(ex.Message);
            }
        }


        public void where(Command cmd)
        {
            TreeNode<IDataPath> pt = current;

            if (!(pt.Item is TableName))
            {
                stdio.ShowError("cannot add where underneath non-Table");
                return;
            }

            string _where = cmd.args;

            if (string.IsNullOrEmpty(_where))
            {
                stdio.ShowError("argument cannot be empty");
            }

            TableName tname = (TableName)pt.Item;
            var locator = new Locator(_where);
            if (new SqlBuilder(tname.Provider).SELECT.TOP(1).COLUMNS().FROM(tname).WHERE(locator).Invalid())
            {
                stdio.ShowError("invalid expression");
                return;
            }

            var lnode = new TreeNode<IDataPath>(locator);
            pt.Nodes.Add(lnode);

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

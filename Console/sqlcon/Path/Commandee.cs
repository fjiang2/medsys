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
    class Commandee
    {
        private PathManager mgr;
        public Commandee(PathManager mgr)
        {
            this.mgr = mgr;
        }

        public void chdir(ServerName serverName, DatabaseName databaseName)
        {
            string[] segments = new string[] { "\\", serverName.Path, databaseName.Path };
            var node = mgr.Navigate(segments);
            if (node != null)
            {
                mgr.current = node;
            }
        }

        public bool chdir(Command cmd)
        {
            if (cmd.arg1 == "/?")
            {
                stdio.WriteLine("cd [path]              : change directory");
                stdio.WriteLine("cd \\                   : change to root directory");
                stdio.WriteLine("cd ..                  : change to the parent directory");
                stdio.WriteLine("cd ...                 : change to the grand parent directory");
                return true;
            }


            if (cmd.wildcard != null)
            {
                stdio.ShowError("invalid path");
                return false;
            }

            var node = mgr.Navigate(cmd.Segments);
            if (node != null)
            {
                mgr.current = node;
                return true;
            }

            return false;
        }

 

        public void dir(Command cmd)
        {
            if (cmd.arg1 == "/?")
            {
                stdio.WriteLine("dir [path]             : display current directory");
                stdio.WriteLine("options:   /topnnn     : display top nnn records");
                stdio.WriteLine("           /all        : display all records");
                stdio.WriteLine("           /s          : display table structure");
                stdio.WriteLine("           /w          : display where filters");
                stdio.WriteLine("           /t          : display table in vertical grid");
                return;
            }

            var pt = mgr.current;

            if (cmd.Segments.Length != 0)
            {
                pt = mgr.Navigate(cmd.Segments);
                if (pt == null)
                    return;
            }

            if (pt.Nodes.Count == 0)
                mgr.Expand(pt, true);

            mgr.Display(pt, cmd);

        }

        public void set(Command cmd)
        {
            if (cmd.args == null)
                return;

            var pt = mgr.current;
            if (!(pt.Item is Locator))
                return;

            Locator locator = (Locator)pt.Item;
            TableName tname = (TableName)pt.Parent.Item;

            try
            {
                int count = new SqlBuilder().UPDATE(tname).SET(cmd.args).WHERE(locator).SqlCmd.ExecuteNonQuery();
                stdio.WriteLine("{0} of row(s) affected", count);
            }
            catch (Exception ex)
            {
                stdio.ShowError(ex.Message);
            }
        }


        public void del(Command cmd)
        {
            var pt = mgr.current;
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
                int count = new SqlBuilder().DELETE(tname).WHERE(locator).SqlCmd.ExecuteNonQuery();
                stdio.WriteLine("{0} of row(s) affected", count);
            }
            catch (Exception ex)
            {
                stdio.ShowError(ex.Message);
            }
        }


        public void where(Command cmd)
        {
            TreeNode<IDataPath> pt = mgr.current;

            //search TableName node
            var x = mgr.GetCurrentNode<TableName>();
            if (x != null)
                pt = x;

            if (!(pt.Item is TableName))
            {
                stdio.ShowError("cannot add where underneath non-Table");
                return;
            }

            var xnode = mgr.TryAddWhereOrColumns(pt, cmd.args);
            if (xnode != pt)
            {
                //jump to the node just created
                mgr.current = xnode;
                mgr.Display(xnode, cmd);
            }
        }


    }
}

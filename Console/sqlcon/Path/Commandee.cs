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
            PathName pathName = new PathName(string.Format("\\{0}\\{1}\\", serverName.Path, databaseName.Path ));
            var node = mgr.Navigate(pathName);
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

            if (cmd.Path1 != null)
            {
                var node = mgr.Navigate(cmd.Path1);
                if (node != null)
                {
                    mgr.current = node;
                    return true;
                }
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

            if (cmd.Path1 != null)
            {
                pt = mgr.Navigate(cmd.Path1);
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


        public void mkdir(Command cmd)
        {
            TreeNode<IDataPath> pt = mgr.current;

            //search TableName node
            var x = mgr.GetCurrentNode<TableName>();
            if (x != null)
                pt = x;

            if (!(pt.Item is TableName))
            {
                stdio.ShowError("cannot add filter underneath non-Table");
                return;
            }

            var xnode = mgr.TryAddWhereOrColumns(pt, cmd.args);
            //if (xnode != pt)
            //{
            //    //jump to the node just created
            //    mgr.current = xnode;
            //    mgr.Display(xnode, cmd);
            //}
        }

        public void rmdir(Command cmd)
        {
            TreeNode<IDataPath> pt = mgr.current;

            if (cmd.Path1 != null)
            {
                pt = mgr.Navigate(cmd.Path1);
                if (pt == null)
                {
                    stdio.ShowError("invalid path");
                    return;
                }
            }


            pt = pt.Parent;

            if (!(pt.Item is TableName))
            {
                stdio.ShowError("cannot remove filter underneath non-Table");
                return;
            }


            var nodes = pt.Nodes.Where(node => node.Item is Locator && (node.Item as Locator).Path == cmd.args);
            if (nodes.Count() > 0)
            {
                stdio.Write("are you sure to delete (y/n)?");
                if (stdio.ReadKey() != ConsoleKey.Y)
                    return;

                foreach (var node in nodes)
                {
                    pt.Nodes.Remove(node);
                }

            }
            else
            {
                int result;
                if (int.TryParse(cmd.Path1.name, out result))
                {
                    result--;

                    if (result >= 0 && result < pt.Nodes.Count)
                    {
                        stdio.Write("are you sure to delete (y/n)?");
                        if (stdio.ReadKey() != ConsoleKey.Y)
                            return;

                        var node = pt.Nodes[result];
                        pt.Nodes.Remove(node);
                    }
                }
            }
        }

        public void type(Command cmd)
        {
            if (cmd.arg1 == "/?")
            {
                stdio.WriteLine("type [path]            : display current data");
                return;
            }

            var pt = mgr.current;

            if (cmd.Path1 != null)
            {
                pt = mgr.Navigate(cmd.Path1);
                if (pt == null)
                {
                    stdio.ShowError("invalid path");
                    return;
                }
            }

            mgr.TypeFile(pt, cmd);
        }
    }
}

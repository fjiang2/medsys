﻿using System;
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
using Sys.Data.Comparison;
using Tie;

namespace sqlcon
{
    class Commandee
    {
        private PathManager mgr;
        private TreeNode<IDataPath> pt;

        public Commandee(PathManager mgr)
        {
            this.mgr = mgr;
        }

        private bool Navigate(Command cmd)
        {
            this.pt = mgr.current;

            if (cmd.Path1 != null)
            {
                pt = mgr.Navigate(cmd.Path1);
                if (pt == null)
                {
                    stdio.ShowError("invalid path");
                    return false;
                }
            }

            return true;
        }

        public void chdir(ServerName serverName, DatabaseName databaseName)
        {
            string path = string.Format("\\{0}\\{1}\\", serverName.Path, databaseName.Path);
            PathName pathName = new PathName(path);
            var node = mgr.Navigate(pathName);
            if (node != null)
            {
                mgr.current = node;
            }
            else
                stdio.ShowError("invalid path:" + path);
        }

        public bool chdir(Command cmd)
        {
            if (cmd.arg1 == "/?")
            {
                stdio.WriteLine("command cd or chdir");
                stdio.WriteLine("cd [path]              : change directory");
                stdio.WriteLine("cd \\                  : change to root directory");
                stdio.WriteLine("cd ..                  : change to the parent directory");
                stdio.WriteLine("cd ...                 : change to the grand parent directory");
                return true;
            }


            if (cmd.wildcard != null)
            {
                stdio.ShowError("invalid path");
                return false;
            }

            if (!Navigate(cmd))
                return false;
            else
            {
                mgr.current = pt;
                return true;
            }
        }



        public void dir(Command cmd)
        {
            if (cmd.arg1 == "/?")
            {
                stdio.WriteLine("command dir or ls");
                stdio.WriteLine("dir [path]             : display current directory");
                stdio.WriteLine("options:   /def        : display table structure");
                stdio.WriteLine("options:   /refresh    : refresh table structure");
                return;
            }

            if (!Navigate(cmd))
                return;

            if (cmd.Refresh)
                pt.Nodes.Clear();

            if (pt.Nodes.Count == 0)
                mgr.Expand(pt, true);

            mgr.Display(pt, cmd);

        }

        public void set(Command cmd)
        {
            if (cmd.arg1 == "/?")
            {
                stdio.WriteLine("set assignment                      : update value by current table or locator");
                stdio.WriteLine("set col1=val1, col2= val2           : update column by current table or locator");
                stdio.WriteLine("set col[n1]=val1, col[n2]=val2      : update by row-id, n1,n2 is row-id");
                stdio.WriteLine("    --use command type /r to display row-id");
                return;
            }

            if (string.IsNullOrEmpty(cmd.args))
            {
                stdio.ShowError("argument cannot be empty");
                return;
            }

            var pt = mgr.current;
            if (!(pt.Item is Locator) && !(pt.Item is TableName))
            {
                stdio.ShowError("table is not selected");
                return;
            }

            Locator locator = mgr.GetCombinedLocator(pt);
            TableName tname = mgr.GetCurrentPath<TableName>();
            
            SqlBuilder builder = new SqlBuilder().UPDATE(tname).SET(cmd.args);
            if (locator != null)
            {
                builder.WHERE(locator);
            }
            else if (mgr.Tout != null && mgr.Tout.TableName == tname && mgr.Tout.HasPhysloc)
            {
                try
                {
                    var x = ParsePhysLocStatement(mgr.Tout.Table, cmd.args);
                    if (x != null)
                        builder = x;
                }
                catch (TieException)
                {
                    stdio.ShowError("invalid set assigment");
                    return;
                }
                catch (Exception ex2)
                {
                    stdio.ShowError(ex2.Message);
                    return;
                }
            }

            try
            {
                int count = builder.SqlCmd.ExecuteNonQuery();
                stdio.WriteLine("{0} of row(s) affected", count);
            }
            catch (Exception ex)
            {
                stdio.ShowError(ex.Message);
            }
        }

        private SqlBuilder ParsePhysLocStatement(UniqueTable table, string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            text = text.Trim();

            Memory ds = new Memory();

            Script.Evaluate(text, ds);
            if (ds.Names.Count() == 0)
                return null;

            SqlBuilder sum = null;

            foreach (VAR name in ds.Names)
            {
                string column = (string)name;
                VAL val = ds[name];

                if (!val.IsList)
                    continue;

                for (int i = 0; i < val.Size; i++)
                {
                    VAL s = val[i];
                    if (s.IsNull)
                        continue;

                    SqlBuilder builder = table.WriteValue(column, i, s.HostValue);

                    if (sum == null)
                        sum = builder;
                    else
                        sum += builder;
                }
            }

            return sum;
        }


        public void del(Command cmd)
        {
            if (cmd.arg1 == "/?")
            {
                stdio.WriteLine("command del or erase:  delete data rows");
                stdio.WriteLine("del [sql where clause]  : delete current table filtered rows");
                stdio.WriteLine("example:");
                stdio.WriteLine("del : delete all rows");
                stdio.WriteLine("del col1=1 and col2='match' : del rows matched on columns:c1 or c2");
                return;
            }

            var pt = mgr.current;
            if (!(pt.Item is Locator) && !(pt.Item is TableName))
            {
                stdio.ShowError("table is not selected");
                return;
            }


            TableName tname = null;
            Locator locator = null;
            if (pt.Item is Locator)
            {
                locator = mgr.GetCombinedLocator(pt);
                tname = mgr.GetCurrentPath<TableName>();
                if (!string.IsNullOrEmpty(cmd.args))
                    locator.And(new Locator(cmd.args));
            }

            if (pt.Item is TableName)
            {
                tname = (TableName)pt.Item;
                if(!string.IsNullOrEmpty(cmd.args))
                    locator = new Locator(cmd.args);
            }

            if (locator == null)
                stdio.Write("are you sure to delete all rows (y/n)?");
            else
                stdio.Write("are you sure to delete (y/n)?");

            if (stdio.ReadKey() != ConsoleKey.Y)
                return;

            stdio.WriteLine();

            try
            {
                int count;
                if (locator == null)
                    count = new SqlBuilder().DELETE(tname).SqlCmd.ExecuteNonQuery();
                else
                    count = new SqlBuilder().DELETE(tname).WHERE(locator).SqlCmd.ExecuteNonQuery();
                
                stdio.WriteLine("{0} of row(s) affected", count);
            }
            catch (Exception ex)
            {
                stdio.ShowError(ex.Message);
            }
        }


        public void mkdir(Command cmd)
        {
            if (cmd.arg1 == "/?")
            {
                stdio.WriteLine("command md or mkdir");
                stdio.WriteLine("md [sql where clause]  : filter current table rows");
                stdio.WriteLine("example:");
                stdio.WriteLine("md col1=1 and col2='match' : filter rows matched on columns:c1 or c2");
                return;
            }

            TreeNode<IDataPath> pt = mgr.current;

            if (!(pt.Item is TableName) && !(pt.Item is Locator))
            {
                stdio.ShowError("must add filter underneath table or locator");
                return;
            }

            if (string.IsNullOrEmpty(cmd.args))
                return;

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
            if (cmd.arg1 == "/?")
            {
                stdio.WriteLine("command rd or rmdir");
                stdio.WriteLine("rm [sql where clause] : remove locators");
                stdio.WriteLine("rm #1 : remove the locator node");
                return;
            }

            if (!Navigate(cmd))
                return;

            pt = pt.Parent;

            if (!(pt.Item is TableName))
            {
                stdio.ShowError("cannot remove filter underneath non-Table");
                return;
            }


            var nodes = pt.Nodes.Where(node => node.Item is Locator && (node.Item as Locator).Path == cmd.Path1.name);
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
                stdio.WriteLine("type [path]|[pattern]  : display current data, or search pattern");
                stdio.WriteLine("options:");
                stdio.WriteLine("   /top:n              : display top n records");
                stdio.WriteLine("   /all                : display all records");
                stdio.WriteLine("   /t                  : display table in vertical grid");
                stdio.WriteLine("   /r                  : display row-id");
                stdio.WriteLine("   /col:c1,c2,..       : display columns, or search on columns");
                stdio.WriteLine("example:");
                stdio.WriteLine("type match*s /col:c1,c2 : display rows matched on columns:c1 or c2");
                return;
            }

            this.pt = mgr.current;

            if (!Navigate(cmd))
                return;

            if (!mgr.TypeFile(pt, cmd))
                stdio.ShowError("invalid arguments");
        }



        public void xcopy(Command cmd, SideType sideType)
        {
            if (cmd.arg1 == "/?")
            {
                if (sideType == SideType.copy)
                {
                    stdio.WriteLine("command xcopy");
                    stdio.WriteLine("xcopy [table1] [table2]     : copy table1' records to table2");
                    stdio.WriteLine("xcopy [table1]              : copy table1' records to current table");
                }
                else if (sideType == SideType.sync)
                {
                    stdio.WriteLine("command xcopy");
                    stdio.WriteLine("sync [table1] [table2]     : sync table1' records to table2");
                    stdio.WriteLine("sync [table1]              : sync table1' records to current table");
                }
                return;
            }

            if (cmd.arg1 == null)
            {
                stdio.ShowError("invalid argument");
                return;
            }

            var path1 = new PathName(cmd.arg1);
            TreeNode<IDataPath> node1 = mgr.Navigate(path1);
            if (node1 == null)
            {
                stdio.ShowError("invalid path:" + path1);
                return;
            }

            TableName tname1 = mgr.GetPathFrom<TableName>(node1);
            if (tname1 == null)
            {
                stdio.ShowError("warning: source table is not available");
                return;
            }

            var server1 = mgr.GetPathFrom<ServerName>(node1);
            if (server1 == null)
            {
                stdio.ShowError("warning: source server is not available");
                return;
            }

            var pvd1 = server1.Provider;
            Side side1 = new Side(pvd1);
            //------------------------------------------------------------------------------

            TreeNode<IDataPath> node2 = mgr.Navigate(path1);
            if (cmd.arg2 != null)
            {
                var path2 = new PathName(cmd.arg2);
                node2 = mgr.Navigate(path2);
                if (node2 == null)
                {
                    stdio.ShowError("invalid path:" + path2);
                    return;
                }
            }
            else
                node2 = this.mgr.current;

            TableName tname2 = mgr.GetPathFrom<TableName>(node2);
            if (tname2 == null)
            {
                stdio.ShowError("warning: destination table is not available");
                return;
            }

            var server2 = mgr.GetPathFrom<ServerName>(node2);
            if (server2 == null)
            {
                stdio.ShowError("warning: destination server is not available");
                return;
            }

            var pvd2 = server2.Provider;
            Side side2 = new Side(pvd2);

            //------------------------------------------------------------------------------

            var adapter = new CompareAdapter(side1, side2);
            var sql = adapter.CompareTable(ActionType.CompareData, sideType, tname1, tname2,  mgr.Configuration.PK);

            if (sql == string.Empty)
            {
                stdio.WriteLine("nothing changed on destination {0}", tname2);
            }
            else
            {
                int count = new SqlCmd(pvd2, sql).ExecuteNonQuery();
                stdio.WriteLine("{0} row(s) changed at destination {1}", count, tname2);
            }
        }

    }
}

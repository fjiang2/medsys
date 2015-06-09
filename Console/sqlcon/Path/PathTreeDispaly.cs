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

namespace sqlcon
{

    

    partial class PathTree 
    {

        private void Display(TreeNode<IDataPath> pt, Command cmd)
        {
            if (DisplayServerName(pt, cmd)) return;
            if (DisplayDatabaseName(pt, cmd)) return;
            if (DisplayTableName(pt, cmd)) return;
            if (DisplayTableColumnName(pt, cmd)) return;
            if (DisplayViewColumnName(pt, cmd)) return;
        }

        private bool DisplayServerName(TreeNode<IDataPath> pt, Command cmd)
        {
            if (pt != RootNode)
                return false;

            int i = 0;
            int count = 0;
            foreach (var node in pt.Nodes)
            {
                ServerName sname = (ServerName)node.Item;
                ++i;

                if (IsMatch(cmd.wildcard, sname.Path))
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

            return true;
        }

        private static bool DisplayDatabaseName(TreeNode<IDataPath> pt, Command cmd)
        {
            if (!(pt.Item is ServerName))
                return false;

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

                    if (IsMatch(cmd.wildcard, dname.Path))
                    {
                        count++;
                        if (node.Nodes.Count == 0)
                            ExpandDatabaseName(node, true);

                        stdio.WriteLine("[{0,2}] {1,26} <DB> {2,10} Tables/Views", i, dname.Name, node.Nodes.Count);
                    }
                }

                stdio.WriteLine("\t{0} Database(s)", count);
            }

            return true;
        }


        private static bool DisplayTableName(TreeNode<IDataPath> pt, Command cmd)
        {
            if (!(pt.Item is DatabaseName))
                return false;

            int i = 0;
            int[] count = new int[] { 0, 0 };
            foreach (var node in pt.Nodes)
            {
                TableName tname = (TableName)node.Item;
                ++i;

                if (IsMatch(cmd.wildcard, tname.Path))
                {
                    if (!tname.IsViewName) count[0]++;
                    if (tname.IsViewName) count[1]++;

                    stdio.WriteLine("[{0,3}] {1,15}.{2,-37} <{3}>", i, tname.SchemaName, tname.Name, tname.IsViewName ? "VIEW" : "TABLE");
                }
            }

            stdio.WriteLine("\t{0} Table(s)", count[0]);
            stdio.WriteLine("\t{0} View(s)", count[1]);

            return true;
        }



        private static bool DisplayTableColumnName(TreeNode<IDataPath> pt, Command cmd)
        {
            if (!(pt.Item is TableName))
                return false;

            TableName tname = (TableName)pt.Item;
            if(tname.IsViewName)
                return false;

            if (cmd.IsStruct)
            {
                TableSchema schema = new TableSchema(tname);
                stdio.WriteLine("TABLE: {0}", tname.Path);

                int i = 0;
                int count = 0;
                foreach (IColumn column in schema.Columns)
                {
                    if (IsMatch(cmd.wildcard, column.ColumnName))
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
            else
            {
                DataTable table = new SqlCmd(new SqlBuilder(tname.Provider).SELECT.TOP(10).COLUMNS().FROM(tname))
                    .FillDataTable();
                if (cmd.IsVertical)
                    table.ToVConsole();
                else
                    table.ToConsole();
            }
            return true;
        }

        private static bool DisplayViewColumnName(TreeNode<IDataPath> pt, Command cmd)
        {
            if (!(pt.Item is TableName))
                return false;

            TableName vname = (TableName)pt.Item;
            if (!vname.IsViewName)
                return false;

            DataTable schema = vname.ViewSchema();
            stdio.WriteLine("VIEW: {0}", vname.Path);

            int i = 0;
            int count = 0;
            foreach (DataRow column in schema.Rows)
            {
                //if (IsMatch(wildcard, column.ColumnName))
                //{
                //    count++;

                //    stdio.WriteLine("({0:000}) {1,26} {2,-16} {3,10} {4,10}",
                //        ++i,
                //        string.Format("[{0}]", column.ColumnName),
                //        ColumnSchema.GetSQLType(column),
                //        column.Nullable ? "null" : "not null");
                //}
            }
            stdio.WriteLine("\t{0} Column(s)", count);

            return true;
        }
    
    }
}

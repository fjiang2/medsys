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
    
        private void Display(TreeNode<IDataPath> pt, string wildcard)
        {
            DisplayServerName(pt, wildcard);
            DisplayDatabaseName(pt, wildcard);
            DisplayPathNode(pt, wildcard);
            DisplayTableName(pt, wildcard);
            DisplayViewName(pt, wildcard);
            
            if (pt.Item is TableName)
            {
                DisplayColumnName((TableName)pt.Item, wildcard);
            }
        }

        private void DisplayServerName(TreeNode<IDataPath> pt, string wildcard)
        {
            if (pt != RootNode)
                return;

            int i = 0;
            int count = 0;
            foreach (var node in pt.Nodes)
            {
                ServerName sname = (ServerName)node.Item;
                ++i;

                if (IsMatch(wildcard, sname.Path))
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

        private static void DisplayDatabaseName(TreeNode<IDataPath> pt, string wildcard)
        {
            if (!(pt.Item is ServerName))
                return;

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

                    if (IsMatch(wildcard, dname.Path))
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

        private static void DisplayPathNode(TreeNode<IDataPath> pt, string wildcard)
        {
            if (!(pt.Item is DatabaseName))
                return;

            int i = 0;
            foreach (var node in pt.Nodes)
            {
                PathNode pname = (PathNode)node.Item;
                if (node.Nodes.Count == 0)
                {

                }
                stdio.WriteLine("[{0}] {1}", ++i, pname);
            }
        }

        private static void DisplayTableName(TreeNode<IDataPath> pt, string wildcard)
        {
            if (!(pt.Item is PathNode))
                return;

            PathNode pname = (PathNode)pt.Item;
            if (pname.Level != PathLevel.Tables)
                return;


            int i = 0;
            int count = 0;
            foreach (var node in pt.Nodes)
            {
                TableName tname = (TableName)node.Item;
                ++i;

                if (IsMatch(wildcard, tname.Path))
                {
                    count++;
                    stdio.WriteLine("[{0,3}] {1,15}.{2,-37} <TABLE>", i, tname.SchemaName, tname.Name);
                }
            }

            stdio.WriteLine("\t{0} Table(s)", count);
        }


        private static void DisplayViewName(TreeNode<IDataPath> pt, string wildcard)
        {
            if (!(pt.Item is PathNode))
                return;

            PathNode pname = (PathNode)pt.Item;
            if (pname.Level != PathLevel.Views)
                return;


            int i = 0;
            int count = 0;
            foreach (var node in pt.Nodes)
            {
                TableName tname = (TableName)node.Item;
                ++i;

                if (IsMatch(wildcard, tname.Path))
                {
                    count++;
                    stdio.WriteLine("[{0,3}] {1,15}.{2,-37} <VIEW>", i, tname.SchemaName, tname.Name);
                }
            }

            stdio.WriteLine("\t{0} View(s)", count);
        }

        private static void DisplayColumnName(TableName tname, string wildcard)
        {

            TableSchema schema = new TableSchema(tname);

            int i = 0;
            int count = 0;
            foreach (IColumn column in schema.Columns)
            {
                if (IsMatch(wildcard, column.ColumnName))
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
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys;
using Sys.Data;

namespace sqlcon
{
    partial class PathTree
    {
        private void Expand(TreeNode<IDataPath> node, bool refresh)
        {
            if (node == RootNode)
                return;

            ExpandServerName(node, refresh);
            ExpandDatabaseName(node, refresh);
            ExpandTables(node, refresh);
            ExpandViews(node, refresh);
            ExpandTableName(node, refresh);
        }

        private static void ExpandServerName(TreeNode<IDataPath> node, bool refresh)
        {
            if (!(node.Item is ServerName))
                return;

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
            if (!(node.Item is DatabaseName))
                return;

            DatabaseName dname = (DatabaseName)node.Item;
            if (node.Nodes.Count == 0)
            {
                node.Nodes.Add(new TreeNode<IDataPath>(new PathNode { Level = PathLevel.Tables, Parent = dname }));
                node.Nodes.Add(new TreeNode<IDataPath>(new PathNode { Level = PathLevel.Views, Parent = dname }));
                node.Nodes.Add(new TreeNode<IDataPath>(new PathNode { Level = PathLevel.Proc, Parent = dname }));
                node.Nodes.Add(new TreeNode<IDataPath>(new PathNode { Level = PathLevel.Func, Parent = dname }));

            }
        }

        private static void ExpandTables(TreeNode<IDataPath> node, bool refresh)
        {
            if (!(node.Item is PathNode))
                return;

            PathNode pname = (PathNode)node.Item;
            if (pname.Level != PathLevel.Tables)
                return;

            DatabaseName dname = (DatabaseName)pname.Parent;
            if (refresh || node.Nodes.Count == 0)
            {
                if (refresh)
                    node.Nodes.Clear();

                TableName[] tnames = dname.GetTableNames();
                foreach (var tname in tnames)
                    node.Nodes.Add(new TreeNode<IDataPath>(tname));
            }
        }

        private static void ExpandViews(TreeNode<IDataPath> node, bool refresh)
        {
            if (!(node.Item is PathNode))
                return;

            PathNode pname = (PathNode)node.Item;
            if (pname.Level != PathLevel.Views)
                return;

            DatabaseName dname = (DatabaseName)pname.Parent;
            if (refresh || node.Nodes.Count == 0)
            {
                if (refresh)
                    node.Nodes.Clear();

                TableName[] vnames = dname.GetViewNames();

                foreach (var vname in vnames)
                    node.Nodes.Add(new TreeNode<IDataPath>(vname));

            }
        }

        private static void ExpandTableName(TreeNode<IDataPath> node, bool refresh)
        {
            if (!(node.Item is TableName))
                return;

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
        
    }
}

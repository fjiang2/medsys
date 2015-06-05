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
        private void Expand(TreeNode<IDataPath> node)
        {
            if (node == tree.RootNode)
            {
            }
            else if (node.Item is ServerName)
            {
                ExpandServerName(node, this.Refreshing);
            }
            else if (node.Item is DatabaseName)
            {
                ExpandDatabaseName(node, this.Refreshing);
            }
            else if (node.Item is TableName)
            {
                ExpandTableName(node, this.Refreshing);
            }
        }

        private static void ExpandServerName(TreeNode<IDataPath> node, bool refresh)
        {
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
            DatabaseName dname = (DatabaseName)node.Item;
            if (refresh || node.Nodes.Count == 0)
            {
                if (refresh)
                    node.Nodes.Clear();

                TableName[] tnames = dname.GetTableNames();
                foreach (var tname in tnames)
                    node.Nodes.Add(new TreeNode<IDataPath>(tname));

                TableName[] vnames = dname.GetViewNames();

                foreach (var vname in vnames)
                    node.Nodes.Add(new TreeNode<IDataPath>(vname));

            }
        }

        private static void ExpandTableName(TreeNode<IDataPath> node, bool refresh)
        {
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

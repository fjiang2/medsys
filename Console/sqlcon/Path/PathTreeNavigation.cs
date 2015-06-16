﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys;
using Sys.Data;


namespace sqlcon
{
    partial class PathManager
    {
        internal TreeNode<IDataPath> current;

        public IDataPath Current
        {
            get { return this.current.Item; }
        }

        public TreeNode<IDataPath> RootNode
        {
            get { return tree.RootNode; }
        }
 
        public T GetCurrentPath<T>() where T : IDataPath
        {
            if (current == RootNode)
                return default(T);

            var pt = current;
            while (!(pt.Item is T))
            {
                pt = pt.Parent;

                if (pt == null)
                    return default(T);
            }

            return (T)pt.Item;
        }


        public TreeNode<IDataPath> GetCurrentNode<T>() where T : IDataPath
        {
            if (current == RootNode)
                return null;

            var pt = current;
            while (!(pt.Item is T))
            {
                pt = pt.Parent;

                if (pt == null)
                    return null;
            }

            return pt;
        }

  

        public TreeNode<IDataPath> Navigate(PathName pathName)
        {
            string[] segments = pathName.FullSegments;
      
            if (segments.Length == 0)
                return current;

            var node = current;
            foreach (string segment in segments)
            {
                node = Navigate(node, segment);
                if (node == null)
                    return null;
            }

            return node;
        }

        private TreeNode<IDataPath> Navigate(TreeNode<IDataPath> node, string segment)
        {
            if (segment == "\\")
            {
                return RootNode;
            }
            else if (segment == ".")
            {
                return node;
            }
            else if (segment == "..")
            {
                if (node != RootNode)
                    return node.Parent;
                else
                    return node;
            }
            else if (segment == "...")
            {
                return Navigate(Navigate(node, ".."), "..");
            }

            Expand(node, this.Refreshing);

            string seg = segment;
            if (node.Item is DatabaseName && segment.IndexOf(".") == -1)
                seg = TableName.dbo + "." + segment;

            var xnode = node.Nodes.Find(x => x.Item.Path.ToUpper() == seg.ToUpper());
            if (xnode != null)
                return xnode;
            else
            {
                int result;
                if (int.TryParse(segment, out result))
                {
                    result--;

                    if (result >= 0 && result < node.Nodes.Count)
                        return node.Nodes[result];
                }

                return null;
            }
        }


        public TreeNode<IDataPath> TryAddWhereOrColumns(TreeNode<IDataPath> pt, string segment)
        {
            if (!(pt.Item is Locator) && !(pt.Item is TableName))
            {
                return pt;
            }

            if (string.IsNullOrEmpty(segment))
            {
                stdio.ShowError("argument cannot be empty");
            }

            TableName tname = GetCurrentPath<TableName>();

            var locator = new Locator(segment);
            var builder = new SqlBuilder().SELECT.TOP(1).COLUMNS().FROM(tname).WHERE(locator);
            if (builder.Invalid())
            {
                stdio.ShowError("invalid path");
                return pt;
            }

            var xnode = new TreeNode<IDataPath>(locator);
            pt.Nodes.Add(xnode);

            return xnode;
        }

        

    }
}

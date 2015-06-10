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
        private TreeNode<IDataPath> current;

        public IDataPath Current
        {
            get { return this.current.Item; }
        }

        public TreeNode<IDataPath> RootNode
        {
            get { return tree.RootNode; }
        }
 
        public T GetCurrent<T>() where T : IDataPath
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


        private TreeNode<IDataPath> Navigate(string[] segments)
        {
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

             
                stdio.ShowError("invalid path", segment);
                return null;
            }
        }

    }
}

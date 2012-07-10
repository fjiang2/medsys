using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class IdentifierTree<T> : Tree<T> where T : class
    {

        private IEnumerable<ITreeIdentifierNode<T>> collection;
        private int parentID;

        public IdentifierTree(IEnumerable<ITreeIdentifierNode<T>> collection, int parentID)
        {
            this.collection = collection;
            this.parentID = parentID;

            BuildTree(base.Nodes, parentID);
        }

        private void BuildTree(TreeNodeCollection<T> nodes, int parentID)
        {
            foreach (ITreeIdentifierNode<T> node in collection)
            {
                if (node.NodeParentId != parentID)
                    continue;

                TreeNode<T> treeNode2 = new TreeNode<T>(node.NodeItem);
                nodes.Add(treeNode2);

                BuildTree(treeNode2.Nodes, node.NodeId);
            }

        }

        public override string ToString()
        {
            return string.Format("IdentifierTree<{0}>(Count={1})", typeof(T).Name, this.Nodes.Count);
        }
    }
}

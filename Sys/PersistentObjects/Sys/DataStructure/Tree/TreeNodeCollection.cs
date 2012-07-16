using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class TreeNodeCollection<T> : List<TreeNode<T>> where T : class
    {
        private TreeNode<T> parent;

        internal TreeNodeCollection(TreeNode<T> parent)
        {
            this.parent = parent;
        }

        public new void Add(TreeNode<T> node)
        {
            node.Parent = this.parent;
            node.Index = this.Count;
            base.Add(node);
        }

        public new void AddRange(IEnumerable<TreeNode<T>> collection)
        {
            foreach (TreeNode<T> node in collection)
                this.Add(node);
        }

        public void Add(Tree<T> tree, T rootItem)
        {
            tree.RootNode.Item = rootItem;
            this.Add(tree.RootNode);
        }

        private void ToList(List<TreeNode<T>> list, TreeNodeCollection<T> nodes)
        {
            foreach (TreeNode<T> child in nodes)
            {
                list.Add(child);
                ToList(list, child.Nodes);
            }
        }

        public IEnumerable<TreeNode<T>> AsEnumerable()
        {
            List<TreeNode<T>> list = new List<TreeNode<T>>();
            ToList(list, this);

            return list;
        }


        public override string ToString()
        {
            return string.Format("TreeNodeCollection<{0}>(Count={1})", typeof(T).Name, this.Count);
        }

    }
}

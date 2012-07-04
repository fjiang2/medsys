using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{

    public class Tree<T> where T : class
    {
        private TreeNode<T> root;
        public Tree()
        {
            this.root = new TreeNode<T>((T)null);
        }

     
        public void Clear()
        {
            this.root.Nodes.Clear();
        }


        public TreeNodeCollection<T> Nodes
        {
            get
            {
                return this.root.Nodes;
            }
        }

        public TreeNode<T> RootNode
        {
            get { return this.root; }
        }
            

        public T[] ToArray()
        {
            return AsEnumerable().Select(node => node.Item).ToArray();
        }

        public IEnumerable<TreeNode<T>> AsEnumerable()
        {
            return this.root.Nodes.AsEnumerable();
        }

        public override string ToString()
        {
            return string.Format("Tree<{0}>(Count={1})", typeof(T).Name, this.root.Nodes.Count);
        }

    }
}

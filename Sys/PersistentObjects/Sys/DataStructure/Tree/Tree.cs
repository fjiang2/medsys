using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    /// <summary>
    /// tree data structur represents a generic tree 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Tree<T> where T : class
    {
        private TreeNode<T> root;

        /// <summary>
        /// Create a empty tree
        /// </summary>
        public Tree()
        {
            this.root = new TreeNode<T>((T)null);
        }

     
        /// <summary>
        /// Clear all tree nodes
        /// </summary>
        public void Clear()
        {
            this.root.Nodes.Clear();
        }


        /// <summary>
        /// return 1st level of tree nodes from root
        /// </summary>
        public TreeNodeCollection<T> Nodes
        {
            get
            {
                return this.root.Nodes;
            }
        }

        /// <summary>
        /// return root node
        /// </summary>
        public TreeNode<T> RootNode
        {
            get { return this.root; }
        }
            

        /// <summary>
        /// Convert into array
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            return AsEnumerable().Select(node => node.Item).ToArray();
        }

        /// <summary>
        /// Convert into IEumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TreeNode<T>> AsEnumerable()
        {
            return this.root.Nodes.AsEnumerable();
        }


        /// <summary>
        /// return description of Tree
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Tree<{0}>(Count={1})", typeof(T).Name, this.root.Nodes.Count);
        }

    }
}

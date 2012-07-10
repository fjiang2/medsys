﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class TreeNode<T> where T : class
    {
        private T item;
        private TreeNode<T> parent;
        private int index;
        private TreeNodeCollection<T> nodes;

        public TreeNode(T item)
        {
            this.item = item;
            this.index = -1;
            this.parent = null;

            nodes = new TreeNodeCollection<T>(this);
        }


        /// <summary>
        /// Gets the collection of Node objects assigned to the current tree node.
        /// </summary>
        public TreeNodeCollection<T> Nodes
        {
            get { return this.nodes; }
        }


        /// <summary>
        /// Gets the parent tree node of the current tree node.
        /// </summary>
        public TreeNode<T> Parent
        {
            get { return this.parent; }
            internal set { this.parent = value; }
        }

        public TreeNode<T>[] Sibling
        {
            get
            {
                List<TreeNode<T>> sibling = new List<TreeNode<T>>();
                foreach(TreeNode<T> child in this.parent.Nodes)
                {
                    if(child != this)
                        sibling.Add(child);
                }

                return sibling.ToArray();
            }
        }

        public int Index
        {
            get { return this.index; }
            internal set { this.index = value; }
        }

        /// <summary>
        /// Gets the first child tree node in the tree node collection.
        /// </summary>
        public TreeNode<T> FirstNode
        {
            get
            {
                if (nodes.Count == 0)
                    return null;
                else
                    return nodes[0];
            }
        }


        /// <summary>
        /// Gets the last child tree node.
        /// </summary>
        public TreeNode<T> LastNode
        {
            get
            {
                if (nodes.Count == 0)
                    return null;
                else
                    return nodes[nodes.Count - 1];
            }
        }

        /// <summary>
        /// Gets the next sibling tree node.
        /// </summary>
        public TreeNode<T> NextNode
        {
            get
            {
                if (this.index < nodes.Count - 1)
                    return this.parent.Nodes[index + 1];
                else
                    return null;
            }
        }

        /// <summary>
        /// Gets the previous sibling tree node.
        /// </summary>
        public TreeNode<T> PrevNode
        {
            get
            {
                if (this.index > 0)
                    return this.parent.Nodes[index - 1];
                else
                    return null;
            }
        }


        /// <summary>
        /// Gets the path from the root tree node to the current tree node.
        /// </summary>
        public string FullPath
        {
            get
            {
                string path = this.item.ToString();
                TreeNode<T> node = this;
                while (node.Parent != null)
                {
                    path = node.Parent.item.ToString() + "\\" + path;
                    node = node.Parent;
                }

                return path;
            }
        }

        /// <summary>
        ///  Gets the zero-based depth of the tree node 
        /// </summary>
        public int Level
        {
            get
            {
                int level = 0;
                TreeNode<T> node = this;
                while (node.Parent != null)
                {
                    level++;
                    node = node.Parent;
                }

                return level;
            }
        }

        public void Remove()
        {
            this.parent.Nodes.Remove(this);
        }


        public T Item
        {
            get { return this.item; }
            set { this.item = value; }
        }

        public T[] ToArray()
        {
            return AsEnumerable().Select(node => node.Item).ToArray();
        }

        public IEnumerable<TreeNode<T>> AsEnumerable()
        {
            List<TreeNode<T>> list = new List<TreeNode<T>>();
            ToList(list, this);

            return list;
        }

        private void ToList(List<TreeNode<T>> list, TreeNode<T> node)
        {
            list.Add(node);
            foreach (TreeNode<T> child in this.nodes)
            {
                ToList(list, child);
            }
        }


        public override string ToString()
        {
            return string.Format("TreeNode<{0}>(Item={1}, Count={2})", typeof(T).Name, this.item, this.nodes.Count);
        }
    }
}

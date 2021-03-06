﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public enum TreeViewMode 
    { 
        Edit, 
        Consume
    }

    public class NTreeNode<T> : TreeNode where T : class, INTreeDpoNode
    {
        T item;

        public NTreeNode(T item)
        {
            this.Text = item.NodeText;

            this.item = item;
            if (item.IconImage != null)
            {
                this.ImageKey = item.NodeId.ToString();
            }
            else
            {
                if(item.NodeImageIndex >= 0 )
                    this.ImageIndex = item.NodeImageIndex;
            }

            this.SelectedImageKey = item.NodeSelectedImageKey;
            this.Checked = item.NodeChecked;
        }


        public NTreeNode(T item, Func<T, string> toText)
            :this(item)
        {
            this.Text = toText(item);
        }

        public T Item
        {
            get { return this.item; }
        }

        public override string ToString()
        {
            return this.Text;
        }

        public void AcceptChanges()
        {
            if (item is DPObject)
                ((DPObject)((INTreeDpoNode)item)).AcceptChanges();
        }
    }
}

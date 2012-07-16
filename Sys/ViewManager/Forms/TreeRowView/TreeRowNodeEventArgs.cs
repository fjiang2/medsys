using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.ViewManager.Forms
{
    public class TreeRowNodeEventArgs : EventArgs
    {
        TreeRowNode treeRowNode;

        public TreeRowNodeEventArgs(TreeRowNode treeRowNode)
        {
            this.treeRowNode = treeRowNode;
        }

        public TreeRowNode TreeRowNode 
        { 
            get 
            { 
                return this.treeRowNode; 
            } 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public delegate string DisplayTreeDpoNode(ITreeNodeDpo dpo);


    public class TreeDpoNode : TreeNode
    {
        private ITreeNodeDpo dpo;

        public TreeDpoNode(ITreeNodeDpo dpo, DisplayTreeDpoNode d)
        {
            this.dpo = dpo;
            this.Text =d(dpo);
            this.ImageIndex = dpo.NodeImageIndex;
            this.SelectedImageKey = dpo.NodeSelectedImageKey;
            this.Checked = dpo.NodeChecked;
        }

        public void Add(TreeRowNode dataRowTreeNode)
        {
            this.Nodes.Add(dataRowTreeNode);
        }

        public ITreeNodeDpo Dpo
        {
            get 
            {
                return (ITreeNodeDpo)this.dpo; 
            }
        }

        public override string ToString()
        {
            return this.Text;
        }

        public void AcceptChanges()
        {
            ((DPObject)dpo).AcceptChanges(); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
   


    public class TreeDpoNode : TreeNode
    {
        private INTreeDpoNode dpo;

        public TreeDpoNode(INTreeDpoNode dpo, DisplayNTreeNode d)
        {
            this.dpo = dpo;
            this.Text =d(dpo);
            this.ImageIndex = dpo.NodeImageIndex;
            this.SelectedImageKey = dpo.NodeSelectedImageKey;
            this.Checked = dpo.NodeChecked;
        }

    
        public INTreeDpoNode Item
        {
            get 
            {
                return this.dpo; 
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

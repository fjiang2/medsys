using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using X12.DpoClass;
using X12.Specification;
using Sys;


namespace X12.Forms
{
    class LoopNode : TreeDpoNode
    {

        public LoopNode(LoopTemplateDpo loop)
            : base(loop, loop.Text)
        {
            this.ImageIndex = 0;
            this.SelectedImageKey = TreeRowNode.TREE_ROW_NODE_SELECTED_IMAGE;
        }

        public LoopTemplateDpo LoopDpo
        {
            get { return (LoopTemplateDpo)this.dpo; }
        }


    }
}

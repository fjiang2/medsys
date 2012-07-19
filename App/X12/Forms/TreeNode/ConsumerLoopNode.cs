using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using X12.DpoClass;
using X12.Specification;
using Sys;
using X12.File;

namespace X12.Forms
{
    class ConsumerLoopNode : TreeNode
    {
        LoopLine loop;
        public ConsumerLoopNode(LoopLine loop)
            : base(loop.Text)
        {
            this.ImageIndex = 0;
            this.SelectedImageKey = TreeRowNode.TREE_ROW_NODE_SELECTED_IMAGE;
            this.loop = loop;
        }


        public LoopLine Loop
        {
            get { return this.loop; }
        }

    }
}

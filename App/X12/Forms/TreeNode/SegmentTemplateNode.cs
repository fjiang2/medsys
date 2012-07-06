using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using X12.Dpo;
using X12.Specification;
using Sys;

namespace X12.Forms
{
    class SegmentTemplateNode : TreeDpoNode
    {
        public SegmentTemplateNode(X12SegmentTemplateDpo segment)
            : base(segment, string.Format("{0} ({1})", segment.Name, segment.Description))
        {

            this.ImageIndex = 1;
            this.SelectedImageKey = TreeRowNode.TREE_ROW_NODE_SELECTED_IMAGE;
        }

        public X12SegmentTemplateDpo SegmentDpo
        {
            get { return (X12SegmentTemplateDpo)this.dpo; }
        }

    }
}

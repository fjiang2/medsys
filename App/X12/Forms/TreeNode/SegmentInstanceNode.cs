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
    class SegmentInstanceNode : TreeDpoNode
    {
        public SegmentInstanceNode(X12SegmentInstanceDpo segment)
            : base(segment, string.Format("{0} - {1}", segment.Name, segment.Description.ToSentence()))
        {

            this.ImageIndex = 1;
            this.SelectedImageKey = TreeRowNode.TREE_ROW_NODE_SELECTED_IMAGE;
        }

        public X12SegmentInstanceDpo SegmentDpo
        {
            get { return (X12SegmentInstanceDpo)this.dpo; }
        }

    }
}

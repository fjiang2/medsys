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
    class DataElementNode : TreeDpoNode
    {

        public DataElementNode(X12ElementTemplateDpo element)
            : base(element, string.Format("{0} - {1}", element.RefDes, element.Description.ToSentence()))
        {
            this.ImageIndex = 2;
            this.SelectedImageKey = TreeRowNode.TREE_ROW_NODE_SELECTED_IMAGE;
        }

        public X12ElementTemplateDpo ElementDpo
        {
            get { return (X12ElementTemplateDpo)this.dpo; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Data;

namespace X12.Forms
{
    class TreeDpoNode : TreeNode
    {
        protected DPObject dpo;

        public TreeDpoNode(DPObject dpo, string text)
            :base(text)
        {
            this.dpo = dpo;
        }


        public DPObject Dpo
        {
            get { return this.dpo; }
        }


      
    }
}

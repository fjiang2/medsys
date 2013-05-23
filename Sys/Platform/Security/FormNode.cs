using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sys.Platform.Securtity
{
    class FormNode2 : TreeNode
    {
          //Class
        public FormNode2(Type type)
        {
            this.Text = type.FullName;
            this.Name = type.FullName;
        }

        public FormNode2(string key, string label)
        {
            this.Text = label;
            this.Name = key;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JLabel : JWinControl
    {
        public JLabel(Label label, DataField field)
            : base(label, field)
        {
        }

        public override void Fill()
        {
            base.Fill();

            Control.Text = value.ToString().Trim();
            return;
        }

        public override void Collect()
        {
            base.Collect();
            return;
        }
    }
}

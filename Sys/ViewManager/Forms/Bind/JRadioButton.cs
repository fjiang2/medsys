using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    class JRadioButton : JWinControl
    {

        public JRadioButton(RadioButton radioButton, DataField field)
            : base(radioButton, field)
        {
        }


        public override void Fill()
        {
            base.Fill();

            (Control as RadioButton).Checked = value.IsNull<bool>(false);
            return;
        }

        public override void Collect()
        {
            value = (Control as RadioButton).Checked;

            base.Collect();
            return;
        }
    }
}

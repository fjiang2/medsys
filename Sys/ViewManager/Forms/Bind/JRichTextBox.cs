using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JRichTextBox : JWinControl
    {

        public JRichTextBox(RichTextBox textBox, DataField field)
            : base(textBox, field)
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
            value = Convert(Control.Text);
            Control.Text = value.ToString();
            base.Collect();
            return;
        }




    }
    
}

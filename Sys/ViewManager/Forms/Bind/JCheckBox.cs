using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    class JCheckBox : JWinControl
    {

        public JCheckBox(CheckBox checkBox, DataField field)
            : base(checkBox, field)
        {
        }


        public override void Fill()
        {
            base.Fill();

            if (value == System.DBNull.Value)
            {
                (Control as CheckBox).Checked = false;
                return;
            }

            if (dataType.Name == "Byte" || dataType.Name == "Int16" || dataType.Name == "Int32")
                (Control as CheckBox).Checked = value.ToString() != "0";
            else
                (Control as CheckBox).Checked = value.IsNull<bool>(false);
            return;
        }

        public override void Collect()
        {
            if (dataType.Name == "Byte" || dataType.Name == "Int16" || dataType.Name == "Int32")
                value = (Control as CheckBox).Checked? 1:0;
            else
                value = (Control as CheckBox).Checked;

            base.Collect();
            return;
        }
    }
}

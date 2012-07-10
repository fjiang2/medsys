using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sys.Data;
using DevExpress.XtraEditors;


namespace Sys.ViewManager.Forms
{
    class JCheckEdit : JWinControl
    {

        public JCheckEdit(CheckEdit checkBox, DataField field)
            : base(checkBox, field)
        {
        }


        public override void Fill()
        {
            base.Fill();

            if (value == System.DBNull.Value)
            {
                (Control as CheckEdit).Checked = false;
                return;
            }

            if (dataType.Name == "Byte" || dataType.Name == "Int16" || dataType.Name == "Int32")
                (Control as CheckEdit).Checked = value.ToString() != "0";
            else
                (Control as CheckEdit).Checked = value.IsNull<bool>(false);
            return;
        }

        public override void Collect()
        {
            if (dataType.Name == "Byte" || dataType.Name == "Int16" || dataType.Name == "Int32")
                value = (Control as CheckEdit).Checked ? 1 : 0;
            else
                value = (Control as CheckEdit).Checked;

            base.Collect();
            return;
        }
    }
}
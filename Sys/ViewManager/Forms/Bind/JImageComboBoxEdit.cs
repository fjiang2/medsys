using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    class JImageComboBoxEdit : JWinControl
    {
        public JImageComboBoxEdit(DevExpress.XtraEditors.ImageComboBoxEdit combo, DataField field)
            : base(combo, field)
        {

        }

        public override void Fill()
        {
            base.Fill();

            if (value == System.DBNull.Value)
                return;

            int i = 0;
            foreach (ImageComboBoxItem item in (Control as ImageComboBoxEdit).Properties.Items)
            {
                if (item.Value is Enum)
                {
                    if ((int)value == (int)(item.Value))
                    {
                        (Control as ImageComboBoxEdit).SelectedIndex = i;
                        break;
                    }
                }
                else if (value.Equals(item.Value))
                {
                    (Control as ImageComboBoxEdit).SelectedIndex = i;
                    break;
                }
             i++;
            }
            return;
        }

        public override void Collect()
        {
            int index = (Control as ImageComboBoxEdit).SelectedIndex;
            
            if (index == -1)
                return;

            value = (Control as ImageComboBoxEdit).Properties.Items[index].Value;

            base.Collect();
            return;
        }

    }
}

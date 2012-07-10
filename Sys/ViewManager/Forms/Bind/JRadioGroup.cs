using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Sys.Data;
using Sys.ViewManager.DevEx;

namespace Sys.ViewManager.Forms
{
    class JRadioGroup : JWinControl
    {

        public JRadioGroup(DevExpress.XtraEditors.RadioGroup radioGroup, DataField field)
            : base(radioGroup, field)
        {
        }


        public override void Fill()
        {
            base.Fill();

            if (value == System.DBNull.Value)
                return;

            int i = 0;
            foreach(RadioGroupItem item in (Control as RadioGroup).Properties.Items)
            {
                if (item.Value is Enum)
                {
                    if ((int)value == (int)(item.Value))
                    {
                        (Control as RadioGroup).SelectedIndex = i;
                        break;
                    }
                }
                else if (value.Equals(item.Value))
                {
                    (Control as RadioGroup).SelectedIndex = i;
                    break;
                }
             i++;
            }
            return;
        }

        public override void Collect()
        {
            int index=(Control as RadioGroup).SelectedIndex;
            
            if (index == -1)
                return;

            value = (Control as RadioGroup).Properties.Items[index].Value;

            base.Collect();
            return;
        }

        
    }
}

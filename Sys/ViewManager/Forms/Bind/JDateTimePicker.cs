using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    class JDateTimePicker : JWinControl
    {

        public JDateTimePicker(DateTimePicker dateTimePicker, DataField field)
            : base(dateTimePicker, field)
        {
        }


        public override void Fill()
        {
            base.Fill();

            (Control as DateTimePicker).Value = value.IsNull<DateTime>(new DateTime(1900, 1, 1)); ;
            return;
        }

        public override void Collect()
        {
            value = (Control as DateTimePicker).Value;

            base.Collect();
            return;
        }
    }
}

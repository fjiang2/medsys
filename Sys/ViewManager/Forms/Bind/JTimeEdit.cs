using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    class JTimeEdit : JWinControl
    {

        public JTimeEdit(DevExpress.XtraEditors.TimeEdit timeEdit, DataField field)
            : base(timeEdit, field)
        {
        }


        public override void Fill()
        {
            base.Fill();

            if (value != System.DBNull.Value)
                (Control as TimeEdit).Time = (DateTime)value;
            else
                (Control as TimeEdit).EditValue = null;

            return;
        }

        public override void Collect()
        {
            TimeEdit timeEdit = Control as TimeEdit;

            if (timeEdit.EditValue == null)
                value = System.DBNull.Value;
            else
                value = timeEdit.Time;

            base.Collect();
            return;
        }
    }
}

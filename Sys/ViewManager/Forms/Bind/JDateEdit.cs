using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    class JDateEdit : JWinControl
    {

        public JDateEdit(DevExpress.XtraEditors.DateEdit dateEdit, DataField field)
            : base(dateEdit, field)
        {
        }


        public override void Fill()
        {
            base.Fill();
            //(Control as DateEdit).DateTime = SqlCmd.DateTime(value, new DateTime(1900, 1, 1));

            if (value != System.DBNull.Value)
                (Control as DateEdit).DateTime = (DateTime)value;
            else
                (Control as DateEdit).EditValue = null;

            return;
        }

        public override void Collect()
        {
            DateEdit dateEdit = Control as DateEdit;
            
            if (dateEdit.EditValue == null)
                value = System.DBNull.Value;
            else
                value = dateEdit.DateTime;
            
            base.Collect();
            return;
        }
    }
}

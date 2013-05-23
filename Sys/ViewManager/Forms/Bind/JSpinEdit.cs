using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
	class JSpinEdit : JWinControl
	{

        public JSpinEdit(DevExpress.XtraEditors.SpinEdit spinEdit, DataField field)
			: base(spinEdit, field)
		{
		}


		public override void Fill()
		{
			base.Fill();

            if (value != System.DBNull.Value)
                (Control as SpinEdit).Value = System.Convert.ToDecimal(value);
            else
                (Control as SpinEdit).EditValue = null;

			return;
		}

		public override void Collect()
		{
			SpinEdit spinEdit = Control as SpinEdit;

			if (spinEdit.EditValue == null)
				value = System.DBNull.Value;
			else
				value = spinEdit.Value;

			base.Collect();
			return;
		}
	}
}

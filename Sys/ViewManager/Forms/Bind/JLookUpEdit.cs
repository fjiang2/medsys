using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    class JLookUpEdit : JWinControl
    {
        public JLookUpEdit(DevExpress.XtraEditors.LookUpEdit lookUpEdit, DataField field)
            : base(lookUpEdit, field)
        {
        }

        public JLookUpEdit(DevExpress.XtraEditors.LookUpEdit lookUpEdit, DataField field, TableReader tableReader)
            : base(lookUpEdit, field)
        {
            DataTable dataTable = tableReader.Table;
            lookUpEdit.Properties.Columns.Clear();
            lookUpEdit.Properties.DataSource = dataTable;
            lookUpEdit.Properties.DisplayMember = dataTable.Columns[0].ColumnName;
            lookUpEdit.Properties.ValueMember = dataTable.Columns[0].ColumnName;
            lookUpEdit.Properties.NullText = "";
        }

        public override void Fill()
        {
            base.Fill();
            LookUpEdit lookUpEdit = Control as LookUpEdit;

            if (value != System.DBNull.Value)
                lookUpEdit.EditValue = Convert(value);
            else
                lookUpEdit.EditValue = null;

            return;
        }

        public override void Collect()
        {
            LookUpEdit lookUpEdit = Control as LookUpEdit;
            object val = lookUpEdit.EditValue;

            if (val == null)
                value = System.DBNull.Value;
            else
                value = Convert(val);

            base.Collect();
            return;
        }
    }
}

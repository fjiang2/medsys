using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JDataTableControl : TableAdapter
    {
        DevExpress.XtraGrid.GridControl gridControl;
        DevExpress.XtraGrid.Views.Grid.GridView gridView;


        public JDataTableControl(DevExpress.XtraGrid.GridControl gridControl, DataTable dataTable, TableName tableName, Locator locator)
            : base(dataTable, tableName, locator)
        {
            this.gridControl =gridControl;
            this.gridControl.DataSource = dataTable;
            this.gridView = (DevExpress.XtraGrid.Views.Grid.GridView)gridControl.MainView;
            this.gridControl.DoubleClick += new System.EventHandler(this.gridControl_DoubleClick);
            this.gridControl.Click += new System.EventHandler(this.gridControl_Click);

        }

        private void gridControl_Click(object sender, System.EventArgs e)
        { 

        }

        private void gridControl_DoubleClick(object sender, System.EventArgs e)
        {
            //DataRow dataRow = GetClickRow(sender);
            //if (dataRow != null)
            //{
            //    //DialogResult = DialogResult.OK;
            //    //Close();
            //    return;
            //}
        }

        public DataRow GetClickRow(object pSender)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
                gridView.CalcHitInfo((pSender as Control).PointToClient(Control.MousePosition));

            try
            {
                if (hi.RowHandle >= 0)
                    return gridView.GetDataRow(hi.RowHandle);
                else if (gridView.FocusedRowHandle >= 0)
                    return null;
            }
            catch
            {
                return null; 
            }
            return null;
        }

        public override bool Load()
        {
            base.Load();
            this.gridView.RefreshData();
            return true;
        }

        public bool Reload(string SQL)
        {
            SqlCmd cmd = new SqlCmd(SQL);
            base.DataTable.Rows.Clear();
            cmd.FillDataTable(base.DataTable);

            this.gridView.RefreshData();
            return true;
        }


        public override bool Save()
        {
            return base.Save();
        }

        public override bool Delete()
        {
            bool deleted = false;
            if (gridView.RowCount == 0)
                return false;
            
            int[] selectedRows = gridView.GetSelectedRows();
            RowAdapter d = GetPersistentRow(); 

            foreach (int selectedRow in selectedRows)
            {
                DataRowView selected = (DataRowView)gridView.GetRow(selectedRow);
                DataRow dataRow = selected.Row;
                d.UpdateColumnValue(dataRow);

                if (DataRowChangedHandler != null)
                    d.RowChanged += DataRowChangedHandler;

                if (d.Delete())
                {
                    deleted = true;
                    dataRow.Delete();
                }
            }
            

            gridView.RefreshData();

            return deleted;
        }
    }
}

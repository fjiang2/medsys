using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using Sys.Data;
using Sys.ViewManager;
using Sys.ViewManager.Utils;

namespace Sys.ViewManager.Forms
{
    public partial class LookUp : Form
    {
        DataTable dataTable = null;
        DataRow dataRow = null;
        int pageSize = 25;

        public DataRow DataRow
        {
            get { return dataRow; }
        }

        public int PageSize
        {
            set { pageSize = value; }
        }




        public LookUp(string title, TableReader tableReader)
            : this(title, tableReader.Table)
        { 
        }

        public LookUp(string title, DataTable dataTable)
        {
            InitializeComponent();
            this.Text = title;

            DevEx.Grid.GridViewSetting(gridView);

            toolStrip1.Visible = false;

            Cursor.Current = Cursors.WaitCursor;
            this.dataTable = dataTable;

            DataSource(dataTable);

            Cursor.Current = Cursors.Default;
        }

        


        private void DataSource(DataTable dataTable)
        {
            this.gridSearch.DataSource = dataTable;
            gridView.RefreshData();
            BestFit();
        }

      
    
        public void BestFit()
        {
            DataTable dataTable = (DataTable) this.gridSearch.DataSource;

            if (dataTable.Rows.Count > 1500)
            {
                gridView.Columns[0].BestFit();
                return;
            }

            foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView.Columns)
            {
                gridColumn.BestFit();
            }
        }


    

        public GridView GridView
        { 
            get { return gridView; } 
        }

        private void gridSearch_Click(object sender, EventArgs e)
        {
        }

        private void gridSearch_DoubleClick(object sender, System.EventArgs e)
        {
            dataRow = DevEx.Grid.GetGridClickEx(this.gridView, sender);
            if (dataRow != null)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            int[] Rows = gridView.GetSelectedRows();
            if (Rows.Length >= 1)
            {
                int R = Rows[0];
                DataRowView dataRowView = (System.Data.DataRowView)gridView.GetRow(R);
                if (dataRowView == null)
                    return;

                dataRow = dataRowView.Row;
                Close();
            }

        }


     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }



        public DataRow[] SelectedRows()
        {
            return DevEx.Grid.GetGridSelectedRows(gridView);
        }


        public DataRow PopUp(IWin32Window owner)
        {
            if(owner is Control)
                this.Location = ((Control)owner).Location + new Size(60, 40);

            this.CenterToParent();

            if (dataTable.Rows.Count == 0)
                throw new JException("Row count == 0");

            
            this.ShowInTaskbar = false;
            DialogResult result = base.ShowDialog(owner);
            if (result == DialogResult.OK)
                  return dataRow;
              
            return null;            
            
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
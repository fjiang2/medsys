using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;


namespace Sys.ViewManager.Forms
{
    public partial class JSelector : UserControl
    {

        public JSelector()
        {
            InitializeComponent();

        }

        public Button ButtonAdd
        {
            get { return this.buttonAdd; }
        }

        public Button ButtonRemove
        {
            get { return this.buttonRemove; }
        }


        public bool AllowAddNew
        {
            set {
                this.gridView1.AllowAddNew = value;
                this.gridView2.AllowAddNew = value;
            }
        }

        public DataTable[] DataSource
        {
            set
            {
                this.gridView1.DataSource = value[0];
                this.gridView2.DataSource = value[1];
            }
            get
            {
                return new DataTable[] { this.gridView1.DataSource, this.gridView2.DataSource };
            }
        }


        public string[] Caption
        {
            set
            {
                string caption1 = value[0];
                string caption2 = value[1];

                int y = 0;
                Panel panel = splitContainer2.Panel1;

                JVerticalLabel L1 = new JVerticalLabel();
                L1.AutoSize = true;
                L1.Location = new Point(0, y);
                L1.Text = caption1;
                L1.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                L1.Size = new System.Drawing.Size(15, 160);

                JVerticalLabel L2 = new JVerticalLabel();
                L2.AutoSize = true;
                L2.Location = new Point(panel.Width - 15, y);
                L2.Text = caption2;
                L2.Anchor = AnchorStyles.Right | AnchorStyles.Top; 
                L2.Size = new System.Drawing.Size(15, 160);

                panel.Controls.Add(L1);
                panel.Controls.Add(L2);

            }
        }

        public JGridView GridView1
        {
            get
            {
                return this.gridView1;
            }
        }

        public JGridView GridView2
        {
            get
            {
                return this.gridView2;
            }
        }

        public JGridView[] GridView
        {
            get
            {
                return new JGridView[] { this.gridView1, this.gridView2};
            }
        }



        public SplitContainer SplitContainer1
        {
            get
            {
                return this.splitContainer1;
            }
        }

        public SplitContainer SplitContainer2
        {
            get
            {
                return this.splitContainer2;
            }
        }


        private void JSelector_Resize(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DataRow[] dataRows = this.gridView2.SelectedRows;
            if (dataRows.Length == 0)
                return;

            MoveDataRow(this.gridView2, this.gridView1);

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            DataRow[] dataRows = this.gridView1.SelectedRows;
            if (dataRows.Length == 0)
                return;

            MoveDataRow(this.gridView1, this.gridView2);
        }


        private void chkHideLeft_CheckedChanged(object sender, EventArgs e)
        {
			if (!this.chkHideRight.Checked)
				this.splitContainer1.Panel1Collapsed = this.chkHideLeft.Checked;
			else
				this.chkHideLeft.Checked = false;
        }


        int w1 = 0;
        int w2 = 0; 
        private void chkHideRight_CheckedChanged(object sender, EventArgs e)
        {

            if (!this.chkHideLeft.Checked)
            {
                if (this.chkHideRight.Checked)
                {
                    w1 = this.splitContainer2.Panel1.Width;
                    w2 = this.splitContainer2.Panel2.Width;
                    this.splitContainer2.Panel2Collapsed = this.chkHideRight.Checked;
                    this.splitContainer2.SplitterDistance = w1;
                    this.SplitContainer1.SplitterDistance += w2;
                }
                else
                {
                    this.SplitContainer1.SplitterDistance -= w2;
                    this.splitContainer2.Panel2Collapsed = this.chkHideRight.Checked;
                    this.SplitContainer2.SplitterDistance = w1;
                }
            }
            else
                this.chkHideRight.Checked = false;
        }

        private void chkCellMerge_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.GridView.OptionsView.AllowCellMerge = chkCellMerge.Checked;
           // gridView2.GridView.OptionsView.AllowCellMerge = chkCellMerge.Checked;

        }


        private static void MoveDataRow(JGridView src, JGridView dst)
        {
            DataRow[] dataRows = src.SelectedRows;
            if (dataRows.Length == 0)
                return;

            DataTable dataTable1 = dst.DataSource as DataTable;
            foreach (DataRow dataRow in dataRows)
            {
                DataRow newRow = dataTable1.Rows.Add();
                foreach (DataColumn c in dataRow.Table.Columns)
                {
                    if(dataTable1.Columns.Contains(c.ColumnName))
                        newRow[c.ColumnName] = dataRow[c.ColumnName];
                }
                
            }

            DataTable dataTable2 = src.DataSource as DataTable;
            src.GridView.DeleteSelectedRows();

        }


        public void SychronizeDataSource(string[] columnNames)
        {
            SychronizeDataSource(columnNames, columnNames);
        }

        public void SychronizeDataSource(string[] columnNames1, string[] columnNames2)
        {
            RemoveDataRow(this.gridView2.DataSource as DataTable, this.gridView1.DataSource as DataTable, columnNames1, columnNames2);
        }


        // dataTable2- dataTable1
        private static void RemoveDataRow(DataTable dataTable2, DataTable dataTable1, string[] columnNames1, string[] columnNames2)
        {
			if (dataTable1.Rows != null)
            foreach (DataRow dataRow1 in dataTable1.Rows)
            {
				if (dataTable2.Rows != null)
                foreach (DataRow dataRow2 in dataTable2.Rows)
                {
                    if (Equals(dataRow1, dataRow2, columnNames1, columnNames2))
                    {
                        dataRow2.Delete();
                        break;
                    }
                }

            }

        }

        private static bool Equals(DataRow dataRow1, DataRow dataRow2, string[] columnNames1, string[] columnNames2)
        {
            if (dataRow1.RowState == DataRowState.Deleted || dataRow2.RowState == DataRowState.Deleted)
                return false;

            for(int i=0; i< columnNames1.Length; i++)
            {
                if (
                       !dataRow1.Table.Columns.Contains(columnNames1[i])
                    || !dataRow2.Table.Columns.Contains(columnNames2[i])
                    || !dataRow1[columnNames1[i]].Equals(dataRow2[columnNames2[i]])
                    )
                    
                    return false;
            }

            return true;
        
        }


        public void DrawVerticalString(int x0, int y0, string drawString)
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float x = x0;
            float y = y0;
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }

    }
}

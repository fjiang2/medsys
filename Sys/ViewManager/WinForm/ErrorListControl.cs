using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Data;
using Sys;

namespace Sys.ViewManager.Forms
{
    public partial class ErrorListControl : UserControl
    {
        MassageManager manager;
        DataTable dt;

        public ErrorListControl()
        {
            InitializeComponent();

            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            this.dt = new DataTable();
            this.manager = new MassageManager();
            
            dt.Columns.Add(new DataColumn("ErrorTy", typeof(int)));
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Location", typeof(string)));


            imageList1.Images.Add(txtMessages.Image);
            imageList1.Images.Add(txtWarnings.Image);
            imageList1.Images.Add(txtErrors.Image);

            gridControl1.DataSource = dt;

            manager.MessageChanged += new MassageManager.MessageHandler(manager_MessageChanged);
        }

        private void manager_MessageChanged(object sender, MessageEventArgs e)
        {
            int errorCount = 0;
            int warningCount = 0;
            int informationCount = 0;

            foreach (Message item in e.Errors)
            {
                switch (item.Level)
                {
                    case MessageLevel.error:
                        errorCount++;
                        break;

                    case MessageLevel.warning:
                        warningCount++;
                        break;

                    case MessageLevel.information:
                        informationCount++;
                        break;
                }


                DataRow row = dt.NewRow();
                row[0] = (int)item.Level;
                
                if(item.ID != 0)
                    row[1] = item.ID;

                row[2] = item.Description;
                row[3] = item.Location;

                dt.Rows.Add(row);
            }

            txtErrors.Text = string.Format("{0} Errors", errorCount);
            txtWarnings.Text = string.Format("{0} Warnings", warningCount);
            txtMessages.Text = string.Format("{0} Messages", informationCount);

        }

        public MassageManager Manager
        {
            get { return this.manager; }
        }

        private void txtErrors_Click(object sender, EventArgs e)
        {
            this.gridColumnFlag.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(string.Format("ErrorTy = {0}", (int)MessageLevel.error));
        }

        private void txtWarnings_Click(object sender, EventArgs e)
        {
            this.gridColumnFlag.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(string.Format("ErrorTy = {0}", (int)MessageLevel.warning));
        }

        private void txtMessages_Click(object sender, EventArgs e)
        {
            this.gridColumnFlag.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(string.Format("ErrorTy = {0}", (int)MessageLevel.information));
        }

    }


  
}

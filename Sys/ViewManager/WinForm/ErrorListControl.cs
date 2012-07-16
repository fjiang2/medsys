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
using DevExpress.XtraBars.Docking;

namespace Sys.ViewManager.Forms
{
    public partial class ErrorListControl : UserControl, IDockable
    {
        MessageManager manager;
        DataTable dt;

        public ErrorListControl()
        {
            InitializeComponent();


            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            this.dt = new DataTable();
            this.manager = new MessageManager(this);
            
            dt.Columns.Add(new DataColumn("ErrorTy", typeof(int)));
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Location", typeof(string)));


            imageList1.Images.Add(txtMessages.Image);
            imageList1.Images.Add(txtWarnings.Image);
            imageList1.Images.Add(txtErrors.Image);

            gridControl1.DataSource = dt;

            manager.MessageChanged += new MessageManager.MessageHandler(manager_MessageChanged);
            manager.MessageCleared += new EventHandler(manager_MessageCleared);
        }

        public void ActivateDockPanel()
        {
            if (this.Tag is DockPanel)
            {
                DockPanel dockPanel = (DockPanel)this.Tag;
                dockPanel.DockManager.ActivePanel = dockPanel;
            }
        }

        void manager_MessageCleared(object sender, EventArgs e)
        {
            this.dt.Rows.Clear();
            this.dt.AcceptChanges();
        }

        private void manager_MessageChanged(object sender, MessageEventArgs e)
        {
            int errorCount = 0;
            int warningCount = 0;
            int informationCount = 0;

            foreach (Message item in e.Messages)
            {
                switch (item.Level)
                {
                    case MessageLevel.Error:
                        errorCount++;
                        break;

                    case MessageLevel.Warning:
                        warningCount++;
                        break;

                    case MessageLevel.Information:
                        informationCount++;
                        break;
                }


                DataRow row = dt.NewRow();
                row[0] = (int)item.Level;
                
                if(item.Code != 0)
                    row[1] = item.Code;

                row[2] = item.Description;
                row[3] = item.Location;

                dt.Rows.Add(row);
            }

            txtErrors.Text = string.Format("{0} Errors", errorCount);
            txtWarnings.Text = string.Format("{0} Warnings", warningCount);
            txtMessages.Text = string.Format("{0} Messages", informationCount);

        }

        public MessageManager Manager
        {
            get { return this.manager; }
        }

        private void txtErrors_Click(object sender, EventArgs e)
        {
            this.gridColumnFlag.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(string.Format("ErrorTy = {0}", (int)MessageLevel.Error));
        }

        private void txtWarnings_Click(object sender, EventArgs e)
        {
            this.gridColumnFlag.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(string.Format("ErrorTy = {0}", (int)MessageLevel.Warning));
        }

        private void txtMessages_Click(object sender, EventArgs e)
        {
            this.gridColumnFlag.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(string.Format("ErrorTy = {0}", (int)MessageLevel.Information));
        }

    }


  
}

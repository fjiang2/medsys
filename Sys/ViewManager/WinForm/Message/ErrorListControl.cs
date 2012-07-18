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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;


namespace Sys.ViewManager.Forms
{
    public partial class ErrorListControl : UserControl
    {
        const string MESSAGE_COLUMN = "Object";
        MessageManager manager;
        DataTable dt;

        public ErrorListControl()
        {
            InitializeComponent();


            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            this.dt = new DataTable();
            this.manager = MessageManager.Instance;

            
            dt.Columns.Add(new DataColumn("ErrorTy", typeof(int)));
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Location", typeof(string)));

            dt.Columns.Add(new DataColumn(MESSAGE_COLUMN, typeof(object)));

            imageList1.Images.Add(txtMessages.Image);
            imageList1.Images.Add(txtWarnings.Image);
            imageList1.Images.Add(txtErrors.Image);

            gridControl1.DataSource = dt;

            manager.Committed += new EventHandler(manager_Committed);
            manager.Cleared += new MessageHandler(manager_Cleared);

            this.gridControl1.MouseDoubleClick += new MouseEventHandler(gridControl1_MouseDoubleClick);
        }

        void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataRow dataRow = DevEx.Grid.GetGridClickEx(this.gridView1, sender);
            if (dataRow == null)
                return;

            Message selectedMessage = manager.Messages.FirstOrDefault(message => message == dataRow[MESSAGE_COLUMN]);

            if (selectedMessage != null)
                this.manager.OnMessageClicked(selectedMessage);
        }

        public void ActivateDockPanel()
        {
            if (this.Tag is DockPanel)
            {
                DockPanel dockPanel = (DockPanel)this.Tag;
                dockPanel.DockManager.ActivePanel = dockPanel;
            }
        }

        void manager_Cleared(object sender, MessageEventArgs e)
        {
            if ((e.Message.Place & MessagePlace.ErrorListWindow )== MessagePlace.ErrorListWindow)
            {
                this.dt.Rows.Clear();
                this.dt.AcceptChanges();
            }
        }

        private void manager_Committed(object sender, EventArgs e)
        {
            var messages = this.manager.GetMessages(MessagePlace.ErrorListWindow);
            if (messages.Count() == 0)
                return;

            int errorCount = 0;
            int warningCount = 0;
            int informationCount = 0;

            foreach (Message message in messages)
            {
                switch (message.Level)
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
                row[0] = (int)message.Level;
                
                if(message.Code != 0)
                    row[1] = message.Code;

                row[2] = message.Description;
                row[3] = message.Location;

                row[MESSAGE_COLUMN] = message;
                dt.Rows.Add(row);
            }

            txtErrors.Text = string.Format("{0} Errors", errorCount);
            txtWarnings.Text = string.Format("{0} Warnings", warningCount);
            txtMessages.Text = string.Format("{0} Messages", informationCount);

            manager.RemoveMessages(MessagePlace.ErrorListWindow);
            ActivateDockPanel();
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

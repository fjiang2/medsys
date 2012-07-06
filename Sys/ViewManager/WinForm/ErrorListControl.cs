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

            this.dt = new DataTable();
            this.manager = new MassageManager(dt);
            
            dt.Columns.Add(new DataColumn("ErrorTy", typeof(int)));
            dt.Columns.Add(new DataColumn("ID", typeof(int)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Location", typeof(string)));


            imageList1.Images.Add(txtMessages.Image);
            imageList1.Images.Add(txtWarnings.Image);
            imageList1.Images.Add(txtErrors.Image);

            gridControl1.DataSource = dt;

       //     Error(1, "Error Demo", "line 21");
       //     Warning(2, "Warning Demo", "line 300");

            manager.MessageChanged += new MassageManager.MessageHandler(manager_MessageChanged);
        }

        void manager_MessageChanged(object sender, MessageEventArgs e)
        {
            int errorCount = 0;
            int warningCount = 0;
            int informationCount = 0;

            foreach (MessageItem item in e.Errors)
            {
                switch (item.Type)
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
                row[0] = (int)item.Type;
                row[1] = item.ID;
                row[2] = item.Message;
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

    }


  
}

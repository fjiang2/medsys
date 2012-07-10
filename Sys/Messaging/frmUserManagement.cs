using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager;
using agsXMPP;
using agsXMPP.protocol;
using agsXMPP.Xml;
using agsXMPP.Xml.Dom;
using Sys.Xmpp;
using Tie;
using Sys.Workflow;
using Sys.Data;
using Sys.ViewManager.Forms;
using Sys.Foundation.Dpo;


namespace Sys.Messaging
{
    public partial class frmUserManagement : Sys.Workflow.Forms.ActivityWinForm  
    {
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void btnSyncUsers_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DataTable dataTable = SqlCmd.FillDataTable("SELECT * FROM {0} WHERE Inactive = 0 AND User_Name NOT IN (SELECT username FROM {1}..ofUser)",
                UserDpo.TABLE_NAME,
                Sys.Constant.DB_XMPP
                );
            
            XmppClientConnection XmppCon = XmppClient.XmppClientConnection;
            

            foreach (DataRow dataRow in dataTable.Rows)
            { 
                Sys.Security.Account account = new Sys.Security.Account(dataRow["User_Name"] as string);
                XmppAccount xmppAccount = new XmppAccount(XmppCon, account);
                xmppAccount.Register();
            
                textBox1.Text = string.Format("Processing {0} ...", dataRow["user_name"] );
                break;
            }
            
            textBox1.Text = "";
            Cursor = Cursors.Default;
            this.InformationMessage = "messaging users are synchronized.";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            //Task task = new Task();
            //task.Company = "Company";
            //task.Summary = this.tbSubject.Text;
            //task.Description = "N/A";
            //task.Category1 = "Sales Order";
            //task.Category2 = "Task Card";
            //task.Category3 = "Tracking#";
            //task.Start_Date = new DateTime(2011, 3, 1);
            //task.Due_Date = new DateTime(2011, 3, 23);
            

            //XmppChannel channel = new XmppChannel(1);
            //WorkflowRuntime.SyncNewTask(channel, task);
            //this.tbTaskID.Text = task.ID.ToString();
        }

        private void btnSendIM_Click(object sender, EventArgs e)
        {
            XmppClient.SendMessage(this.tbUserName.Text, "", this.tbSubject.Text);
        }

        
        private void btnWorkflow_Click(object sender, EventArgs e)
        {
            BaseForm form = new Sys.Workflow.Collaborative.Forms.WorkflowForm();
            form.PopUp(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TieEditor.Show(this, "TIE Debugger", "");
        }

      
    }
}

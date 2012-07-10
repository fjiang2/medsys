using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.Xmpp;
using Tie;
using Sys.Security;
using Sys.ViewManager.Forms;
using Sys.Workflow.Forms;
using Sys.DataManager;
using Sys.ViewManager;

namespace Sys.Workflow.Collaborative.Forms
{
    public partial class TaskForm :  ActivityWinForm
    {
        CollaborativeActivity activityInstance;
        TaskDpo task;
        DataRow taskRow;
        DataLocking taskLock;

        public TaskForm(DataRow taskRow)
        {
            InitializeComponent();

            this.allAccess = true;

            //priority and status
            foreach (TaskPriority ty in Enum.GetValues(typeof(TaskPriority)))
                this.dupPriority.Items.Add(ty);

            foreach (TaskStatus ty in Enum.GetValues(typeof(TaskStatus)))
                this.dupStatus.Items.Add(ty);


            this.taskRow = taskRow;
            this.Init();


            this.rtbProperties.AcceptsTab = true;
            this.taskRow.Table.RowChanged += Table_RowChanged;
            this.rtbProperties.SelectionChanged += richTextBox1_SelectionChanged;
            this.chkLocked.CheckedChanged += new System.EventHandler(this.chkLocked_CheckedChanged);

        }

        private void Table_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action != DataRowAction.Change)
                return;

            if (e.Row != this.taskRow)
                return;

            this.Init();
            this.InformationMessage = string.Format("Task {0} updated by {1}", task.Summary, (string)taskRow["Sender"]);
        }

        private void TaskForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.dataRow.Table.RowChanged -= Table_RowChanged;  
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            int line = JRichTextBox.Line(rtb);
            int col = JRichTextBox.Column(rtb);
            int pos = rtb.SelectionStart;

            this.InformationMessage  = "Ln " + line + ", Col " + col;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            this.taskRow.Table.RowChanged -= Table_RowChanged;  
        }


        private void Init()
        {
            int workflowInstanceID = (int)taskRow[TaskDpo._WorkflowInstance_ID];
            string stateName = (string)taskRow[TaskDpo._State_Name];

            activityInstance = CollaborativeActivity.NewInsance(workflowInstanceID, stateName, typeof(WorkflowInstanceDpo));
            task = (TaskDpo)activityInstance.Data;

            this.txtTaskId.Text = string.Format("Task#{0}", task.ID);

            //Window Form Title
            if(task.Enabled)
                this.Text = task.Summary;
            else
                this.Text = string.Format("{0} (waiting)",task.Summary);

            this.tbFrom.Text = (string)taskRow["Sender"];
            this.tbTo.Text = activityInstance.ReceivedCollection.UserCollectionProtocol.ToString();
            

            this.tbSummary.Text = task.Summary; 
            this.tbSubmitted.Text = task.Submitted_Date.ToString();
            this.tbModified.Text = task.Last_Action_Date.ToString();

            this.tbCompany.Text = task.Company;
            this.tbCategory1.Text = task.Category1;

            UserAccount acc = new UserAccount((int)task.Owner_ID);
            this.tbOwner.Text = acc.Name;
            this.tbAssignment.Text = activityInstance.AssignedCollection.UserCollectionProtocol.ToString(); 

            
            //priority and status
            this.dupPriority.SelectedItem = task.TaskPriority;
            this.dupStatus.SelectedItem = task.TaskStatus;
            
            //check out/task locked 
            this.taskLock = new DataLocking(activityInstance.Task);
            this.chkLocked.Enabled = !taskLock.Locked || account.UserID == taskLock.CheckedOutBy || account.IsAdmin;
            acc = new UserAccount(taskLock.CheckedOutBy);
            this.tbCheckOutBy.Text = acc.Name;
            this.tbCheckOutTime.Text = taskLock.TimeCheckedOut.ToString();
            this.chkLocked.Checked = taskLock.Locked;
     
            this.cbUnread.Checked = task.Unread;

            //task schedule
            if(task.Start_Date!=null)
                this.dtpStartDate.Value = (DateTime)task.Start_Date;

            if (task.Due_Date != null)
                this.dtpDueDate.Value = (DateTime)task.Due_Date;

            if (task.Reminder_Date != null)
                this.dtpReminderDate.Value = (DateTime)task.Reminder_Date;
            this.chkReminder.Checked = task.Reminder_Date != null;
            this.dtpReminderDate.Enabled = this.chkReminder.Checked;

            this.rtbDescription.Text = task.Description;
            this.rtbResolution.Text = task.Resolution;
            
            //task start/complete infomation
            if (task.Work_Date != null)
                this.dtpWorkDate.Value = (DateTime)task.Work_Date;
            if (task.Complete_Date != null)
                this.dtpComplete.Value = (DateTime)task.Complete_Date;
            this.tbTimeSpent.Text = task.Time_Spent.ToString();
            this.tbCompletePercentage.Text = task.Complete_Percentage.ToString();


            this.rtbProperties.Text = task.Heap;

            if (activityInstance.WorkflowInstance != null)
            {
                this.tbWorkflowInstanceID.Text = task.WorkflowInstance_ID.ToString();
                this.tbWorkflowName.Text = activityInstance.WorkflowInstance.Workflow.WorkflowName;
                this.tbStateName.Text = task.State_Name;
                this.tbPrevStates.Text = task.PS.ToString();
                this.tbNextStates.Text = task.NS.ToString();
            }

            //permission control
            if (!this.chkLocked.Enabled
             || !task.Enabled
             || task.TaskStatus == TaskStatus.Completed
             )
                this.WorkMode = WorkMode.Reading;
            else
                this.WorkMode = WorkMode.Working;


        }


     


        private void TaskForm_Load(object sender, EventArgs e)
        {
         

            //mark task read
            if (task.Unread)
            {
                task.Unread = false;
                WorkflowRuntime.SyncTask(activityInstance);
            }
        }

  

        private void chkReminder_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpReminderDate.Enabled = this.chkReminder.Checked;
            if (this.chkReminder.Checked)
                task.Reminder_Date = dtpReminderDate.Value;
        }
        
        private void chkLocked_CheckedChanged(object sender, EventArgs e)
        {
            activityInstance.Unlocked = !this.chkLocked.Checked;

            if (this.chkLocked.Checked)
            {
                this.tbCheckOutBy.Text = account.Name;
                this.tbCheckOutTime.Text = DateTime.Now.ToString();
            }
            else
            {
                this.tbCheckOutBy.Text = "";
                this.tbCheckOutTime.Text = "";
            }
        }


      
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void Save()
        {
            Cursor.Current = Cursors.WaitCursor;
            Collect();

            if (!chkLocked.Checked)
            {
                if (this.taskLock.Locked)
                {
                    if (account.IsAdmin)
                        this.taskLock.MustCheckIn();
                    else
                        this.taskLock.CheckInByMe();
                }
            }
            else
            {
                if (!this.taskLock.Locked)
                    this.taskLock.CheckOutByMe();
            }

            WorkflowRuntime.SyncTask(activityInstance);

            Cursor.Current = Cursors.Default;
        }

        private void Collect()
        {
            task.Summary = this.tbSummary.Text;

            task.Start_Date = this.dtpStartDate.Value;
            task.Due_Date = this.dtpDueDate.Value;

            task.Description = this.rtbDescription.Text;
            task.Resolution = this.rtbResolution.Text;
            
            task.Complete_Date = this.dtpComplete.Value;
            task.Time_Spent = Convert.ToDouble(this.tbTimeSpent.Text);
            task.Complete_Percentage = Convert.ToDouble(this.tbCompletePercentage.Text);

            task.TaskStatus = (TaskStatus)this.dupStatus.SelectedItem;
            task.TaskPriority = (TaskPriority)this.dupPriority.SelectedItem;
            task.Heap = this.rtbProperties.Text;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnAssignToMySelf_Click(object sender, EventArgs e)
        {
            if (!activityInstance.AssignTaskToMyself())
            {
                MessageBox.Show("cannot assign task to you.");
                return;
            }

            this.tbAssignment.Text = account.ToString();
            this.dupStatus.SelectedItem = task.TaskStatus;
        }

       
        private void toolStripButtonStartTask_Click(object sender, EventArgs e)
        {
            
            this.Collect();

            this.dtpStartDate.Value = (DateTime)task.Start_Date;
            DoActivityForm(taskRow);
            this.Close();
        }

        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            if (task.TaskStatus != TaskStatus.Opened || !this.chkLocked.Checked)
            {
                MessageBox.Show("cannot mark task complete");
                return;
            }

            task.Complete_Date = DateTime.Now;
            this.dtpComplete.Value = (DateTime)task.Complete_Date;

            task.Complete_Percentage = 100.0;
            this.tbCompletePercentage.Text = "100.00";
            
            task.TaskStatus = TaskStatus.Completed;
            this.dupStatus.SelectedItem = task.TaskStatus;

            activityInstance.Unlocked = true;
            this.chkLocked.Checked = false;
            this.tbCheckOutBy.Text = "";
            this.tbCheckOutTime.Text = "";
        }

        private void tbProperties_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbUnread_CheckedChanged(object sender, EventArgs e)
        {
            task.Unread = this.cbUnread.Checked;
        }

        protected override void Editable(WorkMode state)
        {
            base.Editable(state);

            if (state == WorkMode.Reviewing || state == WorkMode.Reading)
            {
                if ((task.TaskStatus != TaskStatus.Completed && task.TaskStatus != TaskStatus.Closed)
                    &&
                    (account.IsDeveloper
                    || account.IsAdmin
                    || activityInstance.AssignedCollection.ContainsChildID(account.User_ID)     //everybody can revoke his/her task
                    )
                    )
                {
                    btnRevokeTask.Enabled = true;
                }
            }

        }


        private void btnRevokeTask_Click(object sender, EventArgs e)
        {
            activityInstance.RevokeTask();

            this.tbAssignment.Text = "";
            this.dupStatus.SelectedItem = task.TaskStatus;

            this.chkLocked.Checked = false;
            this.tbCheckOutBy.Text = "";
            this.tbCheckOutTime.Text = "";

            Save();
        }


   
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.Xmpp;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using Tie;
using Sys.ViewManager.Forms;
using Sys.Workflow.Forms;
using Sys.Data;
using Sys.Workflow.Dpo;
using Sys.ViewManager.DevEx;
using Sys.Foundation.Dpo;
using Sys.PersistentObjects.Dpo;

namespace Sys.Workflow.Collaborative.Forms
{
    public partial class TaskListForm : ActivityWinForm
    {
        DataTable taskTable;
        enum AssignmentType
        {
            Received,
            AssignedMe,
            Unassigned,
            Completed,
            Queued
        };
        
        AssignmentType aTy = AssignmentType.Received;

        public TaskListForm()
        {
            Init();
            DataLoad();
        }

        private string workflowName;
        private string stateName;
        public TaskListForm(string workflowName, string stateName)
            :base(workflowName + stateName)
        {
            Init();

            aTy = AssignmentType.Queued;

            this.toolStripButtonCompleted.Visible = false;
            this.toolStripButtonMyAssignments.Visible = false;
            this.toolStripButtonUnassigned.Visible = false;
            this.toolStripButtonReceived.Visible = false;

            this.workflowName = workflowName;
            this.stateName = stateName;
            
            DataLoad();
        }


        private void Init()
        {

            InitializeComponent();
            this.allAccess = true;

            HostType.Register(typeof(StateNodeType), true);
            HostType.Register(typeof(TaskPriority), true);
            HostType.Register(typeof(TaskStatus), true);
            HostType.Register(typeof(ActivityResult), true);

            this.jGridView1.GridControl.MouseDoubleClick += new MouseEventHandler(this.gridControl_DoubleClick);
            this.jGridView1.GridControl.MouseClick += new MouseEventHandler(this.gridControl_MouseClick);
            this.ReceiveXmppMessageOn = true;
        }

        private void TaskListForm_Load(object sender, EventArgs e)
        {
           
        }


        public override bool  DataLoad()
        {
            //update all agents states
            RefreshAgentStates();

            string SQL = @"
                SELECT DISTINCT task.* ,
					   U.First_Name+' '+U.Last_Name AS Sender,
					   CASE WHEN L.CO_Time IS NULL THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS Unlocked
                FROM @Tasks task
                INNER JOIN @Nodes node ON task.ID = node.ParentID AND {0}
                INNER JOIN @Users U ON U.User_ID = task.Sender_ID
                LEFT JOIN @RecordLocks L ON L.Ty ={1} AND L.LockID = task.ID AND CI_Time IS NULL
                WHERE task.Deleted = 0 AND task.Visible = 1 AND {2}
                ORDER BY Submitted_Date
            ";

            string nodeTy = "";
            string nodeChildID = "";
            switch(aTy)
            {
            
                case AssignmentType.Received:
                    nodeTy = string.Format("node.Ty IN ({0}, {1})", (int)TaskNodeType.Receivers, (int)TaskNodeType.Assigned);
                    nodeChildID = string.Format("task.Enabled=1 AND node.ChildID = {0} AND task.Status <> {1}", account.UserID, (int)TaskStatus.Completed);
                    //to show unallowed tasks, uncomment statement below
                    nodeChildID = string.Format("node.ChildID = {0} AND task.Status <> {1}", account.UserID, (int)TaskStatus.Completed);
                    this.ChangeCaption("Task List");
                    break;

                case AssignmentType.AssignedMe:
                    nodeTy = string.Format("node.Ty IN ({0})", (int)TaskNodeType.Assigned);
                    nodeChildID = string.Format("task.Enabled=1 AND node.ChildID = {0} AND task.Status <> {1}", account.UserID, (int)TaskStatus.Completed);
                    //to show unallowed tasks, uncomment statement below
                    //nodeChildID = string.Format("node.ChildID = {0}", account.UserID);
                    this.ChangeCaption("Task List(My assignments)");
                    break;

                case AssignmentType.Completed:
                    nodeTy = string.Format("node.Ty IN ({0})", (int)TaskNodeType.Assigned);
                    nodeChildID = string.Format("node.ChildID = {0} AND task.Status={1}", account.UserID, (int)TaskStatus.Completed);
                    this.ChangeCaption("Task List(My completed assignments)");
                    break;
                
                case AssignmentType.Unassigned:
                    SQL = @"
                    SELECT DISTINCT task.* ,
					       U.First_Name+' '+U.Last_Name AS Sender,
					       CASE WHEN L.CO_Time IS NULL THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS Unlocked
                    FROM @Tasks task
                    LEFT JOIN @Nodes node ON task.ID = node.ParentID AND {0}
                    INNER JOIN @Users U ON U.User_ID = task.Sender_ID
                    LEFT JOIN @RecordLocks L ON L.Ty ={1} AND L.LockID = task.ID AND CI_Time IS NULL
                    WHERE node.ChildID IS NULL AND task.Visible = 1 AND task.ID IN (
					    SELECT DISTINCT task.ID
					    FROM @Tasks task
					    INNER JOIN @Nodes node ON task.ID = node.ParentID AND node.Ty =1
					    WHERE task.Deleted = 0 AND {2}
					    )
                   ORDER BY Submitted_Date
                    ";

                   nodeTy = string.Format("node.Ty IN ({0})", (int)TaskNodeType.Assigned);
                   nodeChildID = string.Format("node.ChildID = {0}", account.UserID);
                   this.ChangeCaption("Task List(Unassigned)");
                   break;

                case AssignmentType.Queued:
                   SQL = @"
                     SELECT DISTINCT task.* ,
					       U.First_Name+' '+U.Last_Name AS Sender,
					       CASE WHEN L.CO_Time IS NULL THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS Unlocked
                    FROM @Tasks task
                    INNER JOIN @Users U ON U.User_ID = task.Sender_ID
                    LEFT JOIN @RecordLocks L ON L.Ty ={1} AND L.LockID = task.ID AND CI_Time IS NULL
                    WHERE {0}
                        AND task.Visible = 1
                        AND task.WorkflowInstance_ID IN (
					    SELECT ID
						FROM @WorkflowInstances
						WHERE Workflow_Name = '{2}'
					    )
                   ORDER BY Submitted_Date
                    ";

                   
                   nodeTy = string.Format("task.Status <> {0} AND task.State_Name = '{1}'", (int)TaskStatus.Completed, this.stateName);
                   nodeChildID = this.workflowName;
                   break;
          }

            SQL = SQL
                       .Replace("@WorkflowInstances", wfWorkflowInstanceDpo.TABLE_NAME)
                       .Replace("@Tasks", wfTaskDpo.TABLE_NAME)
                       .Replace("@Nodes", wfNodeDpo.TABLE_NAME)
                       .Replace("@Users", UserDpo.TABLE_NAME)
                       .Replace("@RecordLocks", RecordLockDpo.TABLE_NAME);


            this.taskTable = SqlCmd.FillDataTable(SQL, 
                nodeTy, new TaskDpo().TableId, nodeChildID,
                wfTaskDpo.TABLE_NAME
                );
#if SLOW
            this.jGridView1.DataSource = taskTable;
#else
            AnchorStyles anchor = this.jGridView1.Anchor;
            Point location = this.jGridView1.Location;
            Size size = this.jGridView1.Size;
            this.Controls.Remove(this.jGridView1);
            this.jGridView1 = new Sys.ViewManager.Forms.JGridView();
            this.jGridView1.Location = location;
            this.jGridView1.Anchor = anchor;
            this.jGridView1.Size = size;
            this.jGridView1.Name = "jGridView1";
            this.Controls.Add(this.jGridView1);
            this.jGridView1.GridControl.MouseDoubleClick += new MouseEventHandler(this.gridControl_DoubleClick);
            this.jGridView1.GridControl.MouseClick += new MouseEventHandler(this.gridControl_MouseClick);

            this.jGridView1.DataSource = taskTable;
#endif


            DevExpress.XtraGrid.Views.Grid.GridView gridView = jGridView1.GridView;
            gridView.OptionsBehavior.Editable = false;

            string[] visibleColumns = new string[] {
                "Unlocked",
                TaskDpo._Unread,
                TaskDpo._Company,TaskDpo._Summary,TaskDpo._Category1,TaskDpo._Category2,TaskDpo._Category3,
                TaskDpo._Priority,TaskDpo._Status,
                TaskDpo._Submitted_Date, TaskDpo._Due_Date, TaskDpo._Last_Action_Date,
                //TaskDpo._Complete_Percentage,TaskDpo._Time_Spent
                "Sender"
            };

            foreach (GridColumn gridColumn in gridView.Columns)
            {
                gridColumn.Visible = false;
                foreach (string col in visibleColumns)
                {
                    if (col == gridColumn.FieldName)
                    {
                        gridColumn.Visible = true;
                        break;
                    }
                }
            }

//#if !DEBUG
//            gridView.Columns["ID"].Visible = false;
//#else
            gridView.Columns[TaskDpo._ID].Visible = true;
//#endif
            //gridView.Columns[TaskDpo._Category1].Caption = "Sale Order#";
            //gridView.Columns[TaskDpo._Category2].Caption = "Task Card#";
            //gridView.Columns[TaskDpo._Category3].Caption = "Tracking#";


            gridView.Columns[TaskDpo._Submitted_Date].Caption = "Submitted";
            gridView.Columns[TaskDpo._Submitted_Date].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            gridView.Columns[TaskDpo._Submitted_Date].Width = 140;

            gridView.Columns[TaskDpo._Last_Action_Date].Caption = "Updated";
            gridView.Columns[TaskDpo._Last_Action_Date].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            gridView.Columns[TaskDpo._Last_Action_Date].Width = 140;

            gridView.Columns[TaskDpo._Start_Date].Caption = "Start";
            gridView.Columns[TaskDpo._Due_Date].Caption = "Due";
            gridView.Columns[TaskDpo._Due_Date].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            gridView.Columns[TaskDpo._Reminder_Date].Caption = "Reminder";

            gridView.Columns[TaskDpo._Complete_Date].Caption = "Complete";
            gridView.Columns[TaskDpo._Complete_Percentage].Caption = "Complete%";
            gridView.Columns[TaskDpo._Complete_Percentage].Width = 40;
            gridView.Columns[TaskDpo._Time_Spent].Caption = "Spent(h)";
            gridView.Columns[TaskDpo._Time_Spent].Width = 40;

            gridView.Columns["Sender"].Width = 100;
            if (SystemInformation.PrimaryMonitorSize.Width < 1440)
            {
                gridView.Columns[TaskDpo._Submitted_Date].Visible = false;
                gridView.Columns[TaskDpo._Complete_Date].Visible = false;
                gridView.Columns[TaskDpo._Time_Spent].Visible = false;
            }

            //unread task row are bolded
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = gridView.Columns[TaskDpo._Unread];
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
            //not allowed task are Gray Color
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition2.Appearance.ForeColor = Color.Gray;
            styleFormatCondition2.Appearance.Options.UseForeColor = true;
            //styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = gridView.Columns[TaskDpo._Enabled];
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = false;
            //delayed task are Red color
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition3.Appearance.ForeColor = Color.Red;
            styleFormatCondition3.Appearance.Options.UseForeColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Expression = "[Due_Date] < Now() AND [Status] != 3";  //TaskStatusType.Completed=3
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            //styleFormatCondition3.Value1 = DateTime.Now;
            //styleFormatCondition3.Value2 = (int)TaskStatusType.Completed;

            gridView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { styleFormatCondition1, styleFormatCondition2, styleFormatCondition3 });

            gridView.FixedLineWidth = 2;
            gridView.Columns["Unlocked"].Fixed = FixedStyle.Left;
            gridView.Columns[TaskDpo._Unread].Fixed = FixedStyle.Left;
            


            //task locked/unlocked
            RepositoryItemImageComboBox lockedComboBox = new RepositoryItemImageComboBox();
            lockedComboBox.AutoHeight = false;
            lockedComboBox.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            lockedComboBox.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                        new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Locked", false, 0),
                        new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Unlocked", true, 1)});
            lockedComboBox.SmallImages = this.imageList1;
            gridView.Columns["Unlocked"].ColumnEdit = lockedComboBox;
            gridView.Columns["Unlocked"].ImageIndex = 0;
            gridView.Columns["Unlocked"].OptionsColumn.ShowCaption = false;
            gridView.Columns["Unlocked"].VisibleIndex = 1;
            gridView.Columns["Unlocked"].Width = 12;

            
            //task read/unread
            RepositoryItemImageComboBox unreadComboBox = new RepositoryItemImageComboBox();
            unreadComboBox.AutoHeight = false;
            unreadComboBox.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            unreadComboBox.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                        new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Unread", true, 2),
                        new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Read", false, 3)});
            unreadComboBox.SmallImages = this.imageList1;
            gridView.Columns[TaskDpo._Unread].ColumnEdit = unreadComboBox;
            gridView.Columns[TaskDpo._Unread].ImageIndex = 2;
            gridView.Columns[TaskDpo._Unread].OptionsColumn.ShowCaption = false;
            gridView.Columns[TaskDpo._Unread].VisibleIndex = 2;
            gridView.Columns[TaskDpo._Unread].Width = 12;


            //task status
            RepositoryItemImageComboBox statusComboBox = new RepositoryItemImageComboBox();
            foreach (TaskStatus ty in Enum.GetValues(typeof(TaskStatus)))
            {
                statusComboBox.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(ty.ToString(), (int)ty, 4));
            }
            statusComboBox.SmallImages = this.imageList1;
            gridView.Columns[TaskDpo._Status].ColumnEdit = statusComboBox;
            gridView.Columns[TaskDpo._Status].Width = 100;

            //task priority
            RepositoryItemImageComboBox priorityComboBox = new RepositoryItemImageComboBox();
            foreach (TaskPriority ty in Enum.GetValues(typeof(TaskPriority)))
            {
                priorityComboBox.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(ty.ToString(), (int)ty, ((int)ty)/10-1));
            }
            priorityComboBox.SmallImages = this.imageListPriority;
            gridView.Columns[TaskDpo._Priority].ColumnEdit = priorityComboBox;
            gridView.Columns[TaskDpo._Priority].Width = 12;

            return true;
        }

        private void RetrieveTaskList()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.DataLoad();
            Cursor.Current = Cursors.Default;
            this.InformationMessage = "Task list refreshed from database server.";

        }

        protected override void OnReceiveMessage(object sender, XmppEventArgs e)
        {
            base.OnReceiveMessage(sender, e);
            if (!e.confirmed)
                return;

            Cursor.Current = Cursors.WaitCursor;
            
            DataRow taskRow = SyncTaskDataRow(taskTable, e.Val);

            if (taskRow != null)
            {
                string msg = string.Format("Task {0} \"{1}\" synchronized by {2} in {3} at {4}.",
                    taskRow[TaskDpo._ID],
                    taskRow[TaskDpo._Summary],
                    e.Val[XmppClient.XMPP_SENDER][Sys.Xmpp.UserProtocol.USER_NAME].Str,
                    e.Val[XmppClient.XMPP_COMPUTER_NAME].Str,
                    DateTime.Now);

                this.ShowMessage(Message.Information(msg).To(MessageWindow.StatusBar2));
            }

            Cursor.Current = Cursors.Default;
        }

        //used in Task List
        private DataRow SyncTaskDataRow(DataTable taskTable, VAL val)
        {
            int taskID = val["ID"].Intcon;
            DataRow taskRow;
            DataRow[] rows = taskTable.Select(string.Format("ID={0}", taskID));

            TaskDpo taskDpo = new TaskDpo();
            taskDpo.ID = taskID;
            DataRow dpoRow = taskDpo.Load();

            if (rows.Length == 0)       //new created task
            {
                //suppress workflow/state not belonged to this QUEUE
                if (aTy == AssignmentType.Queued)
                {
                    if (taskDpo.State_Name != this.stateName)
                        return null;

                    WorkflowInstanceDpo wi = new WorkflowInstanceDpo((int)taskDpo.WorkflowInstance_ID);
                    if (wi.Workflow_Name != this.workflowName)
                        return null;

                }
                    
                taskRow = taskTable.NewRow();
            }
            else
                taskRow = rows[0];

#if TASK_VAL_MESSAGE
            Conversion.VAL2DataRow(val, dataRow);
#else
            dpoRow.CopyTo(taskRow); 
#endif

            Conversion.DataColumnAssign(taskRow, "Sender", val[XmppClient.XMPP_SENDER][Sys.Xmpp.UserProtocol.FULL_NAME].Str);      //this calculated field
            Conversion.DataColumnAssign(taskRow, "Unlocked", val["Unlocked"].Boolcon);

            if (rows.Length == 0)
                taskTable.Rows.Add(taskRow);

            return taskRow;
        }

        private void gridControl_DoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            DataRow taskRow = Grid.GetGridClickEx(this.jGridView1.GridView, sender);
            if (taskRow == null)
                return;


            //code below retrieve data from SQL server, in case that messaging server is disconnected and taskRow is not latest
            TaskDpo taskDpo = new TaskDpo();
            taskDpo.ID = (int)taskRow[TaskDpo._ID];
            DataRow dpoRow = taskDpo.Load();
            dpoRow.CopyTo(taskRow);   

            DoActivityForm(taskRow);

        }


       private void gridControl_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DataRow dataRow = Grid.GetGridClickEx(this.jGridView1.GridView, sender);
            if (dataRow == null)
                return;

            TaskForm form = new TaskForm(dataRow);
            form.PopUp(this, FormPlace.Floating);
            
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RetrieveTaskList();
        }

        private void toolStripButtonMyAssignments_Click(object sender, EventArgs e)
        {
            aTy = AssignmentType.AssignedMe;
            RetrieveTaskList();
        }

        private void toolStripButtonUnassigned_Click(object sender, EventArgs e)
        {
            aTy = AssignmentType.Unassigned;
            RetrieveTaskList();
        }

       

        private void toolStripButtonCompleted_Click(object sender, EventArgs e)
        {
            aTy = AssignmentType.Completed;
            RetrieveTaskList();
        }

        private void toolStripButtonReceived_Click(object sender, EventArgs e)
        {
            aTy = AssignmentType.Received;
            RetrieveTaskList();
        }


        private void RefreshAgentStates()
        {
            string SQL = @"
SELECT T.*
FROM {0} T
     INNER JOIN {1} WI ON T.WorkflowInstance_ID = WI.ID
     INNER JOIN {2} W ON W.Name = WI.Workflow_Name
     INNER JOIN {3} S ON S.Workflow_Name = W.Name AND S.Name = T.State_Name AND (S.Ty & {4} = {4})
WHERE Status= {5} OR Status= {6}
";
            DataTable tasks = SqlCmd.FillDataTable(SQL,
                wfTaskDpo.TABLE_NAME,
                wfWorkflowInstanceDpo.TABLE_NAME,
                wfWorkflowDpo.TABLE_NAME,
                wfStateDpo.TABLE_NAME,                 
                
                (int)StateNodeType.Agent, 
                (int)TaskStatus.NotStarted, 
                (int)TaskStatus.Opened
                );

            if (tasks.Rows.Count == 0)
                return;


            foreach (DataRow taskRow in tasks.Rows)
            {
                int workflowInstanceID = (int)taskRow[TaskDpo._WorkflowInstance_ID];
                string stateName = (string)taskRow[TaskDpo._State_Name];
                CollaborativeActivity activity = CollaborativeActivity.NewInsance(workflowInstanceID, stateName, typeof(WorkflowInstanceDpo));
                activity.RefreshAgentData();
            }
        }
     

    }
}

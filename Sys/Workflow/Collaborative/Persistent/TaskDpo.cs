using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using Sys.Xmpp;
using System.Data;
using System.Reflection;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Workflow.DpoClass;

namespace Sys.Workflow.Collaborative
{
    public class TaskDpo : wfTaskDpo, ICollaborativeTask, IActivityInstanceData
    {
        [ForeignKey(TaskDpo._ID, NodeDpo._ParentID)]
        [Association("Ty=1 AND ParentID=@ID")]
        public DPCollection<NodeDpo> ReceivedCollection;

        [ForeignKey(TaskDpo._ID, NodeDpo._ParentID)]
        [Association("Ty=2 AND ParentID=@ID")]
        public DPCollection<NodeDpo> AssignedCollection;

        [ForeignKey(TaskDpo._ID, NodeDpo._ParentID)]
        [Association("Ty=3 AND ParentID=@ID")]
        public DPCollection<NodeDpo> RepliedCollection;

        [ForeignKey(TaskDpo._ID, NodeDpo._ParentID)]
        [Association("Ty=4 AND ParentID=@ID")]
        public DPCollection<NodeDpo> NotifiedCollection;

        [ForeignKey(TaskDpo._ID, NodeDpo._ParentID)]
        [Association("Ty=5 AND ParentID=@ID")]
        public DPCollection<NodeDpo> AssociatedCollection;


        //Create new task
        public TaskDpo()
        {
            this.Sender_ID = Sys.Security.Account.CurrentUser.UserID;
            this.Owner_ID = this.Sender_ID;
 
            this.Status = (int)TaskStatus.NotStarted;
            this.Priority = (int)TaskPriority.Medium;
            this.Complete_Percentage = 0.0;
            this.Time_Spent = 0.0;

            this.Submitted_Date = DateTime.Now;
            this.Last_Action_Date = DateTime.Now;

            this.Activity_Status = (int)ActivityResult.None;

            this.Unread = true;
            this.Deleted = false;
            this.Enabled = false;
            this.Visible = true;

            this.Prev_States = "{}";
            this.Next_States = "{}";

            this.ReceivedCollection = new DPCollection<NodeDpo>();
            this.AssignedCollection = new DPCollection<NodeDpo>();
            this.RepliedCollection = new DPCollection<NodeDpo>();
            this.NotifiedCollection = new DPCollection<NodeDpo>();
            this.AssociatedCollection = new DPCollection<NodeDpo>();

        }

        //Read a task
        //public ActivityInstancePersistent(int taskID)
        //{
        //    this.ID = taskID;
        //    DataRow dataRow = this.Load();
            
        //    this.Last_Action_Date = DateTime.Now;

        //}
        
        //Read a task from DataTable/DataRow
        public TaskDpo(DataRow dataRow)
            : base(dataRow)
        {
            this.Last_Action_Date = DateTime.Now;
        }

        public TaskDpo(int taskID)
        {
            this.ID = taskID;
            this.Load();
        }

     
        [Valizable]
        public TaskPriority TaskPriority
        {
            get { return (TaskPriority)Priority; }
            set { Priority = (int)value; }
        }


        [Valizable]
        public TaskStatus TaskStatus
        {
            get { return (TaskStatus)Status; }
            set { Status = (int)value; }
        }

        [Valizable]
        public ActivityResult ActivityResult
        {
            get { return (ActivityResult)Activity_Status; }
            set { Activity_Status = (int)value; }
        }

        

        [Valizable]
        public bool Completed
        {
            get { return TaskStatus == TaskStatus.Completed; }
        }

        
        //this task is allowed to do.
        public bool Activated
        { 
            get { return this.Enabled; }
            set { this.Enabled = value; }
        }

        public bool Read
        { get { return !this.Unread; } set { this.Unread = !value; } }

        [Valizable]
        public VAL PS
        {
            get
            {
                if (this.Prev_States == "")
                    return VAL.Array();

                return Script.Evaluate(this.Prev_States); ;
            }
            set
            {
                this.Prev_States = value.ToString();
            }
        }
        
        [Valizable]
        public VAL NS
        {
            get
            {
                if (this.Next_States == "")
                    return VAL.Array();

                return Script.Evaluate(this.Next_States); ;
            }
            set
            {
                this.Next_States = value.ToString();
            }
        }

        public VAL Sender
        {
            get { return new VAL(this.Sender_ID); }
        }


        [Valizable]
        public string Name
        {
            get { return this.State_Name; }
            set { this.State_Name = value; }
        }


        public override DataRow Save()
        {
            this.Last_Action_Date = DateTime.Now;
            return base.Save();
        }
        
        
        
        #region Interface IActivityInstanceData

        public int PIN { get { return this.ID; } }
        public string StateName { get { return this.State_Name; } set { this.State_Name = value; } }

        public int SenderID { get { return this.Sender_ID; } set { this.Sender_ID = value; } }
        public string Subject { get { return this.Summary; } }

        public string ActivityHeap 
        { 
            get 
            { 
                return this.Heap; 
            }
            set
            {
                this.Heap = value;
            }
        }

        public DateTime?[] PlanTime
        {
            get
            {
                return new DateTime?[] { this.Start_Date, this.Due_Date };
            }
            set
            {
                this.Start_Date = value[0];
                this.Due_Date = value[1];
            }
        
        }
        
        public DateTime?[] WorkTime
        {
            get
            {
                return new DateTime?[] { this.Work_Date, this.Complete_Date };
            }
            set
            {
                this.Work_Date = value[0];
                this.Complete_Date = value[1];
            }
        }

        public double WorkDuration
        {
            get
            {
                return (double)this.Time_Spent;
            }
            set
            {
                this.Time_Spent = value;
            }
        }
   
        public IDPCollection DpcReceived { get { return this.ReceivedCollection; } }
        public IDPCollection DpcAssigned { get { return this.AssignedCollection; } }
        public IDPCollection DpcReplied { get { return this.RepliedCollection; } }
        public IDPCollection DpcNotified { get { return this.NotifiedCollection; } }
        public IDPCollection DpcAssociated { get { return this.AssociatedCollection; } }

        public ITaskNodeData NewTaskNode() 
        {
            NodeDpo persistent = new NodeDpo();
            persistent.ParentID = this.ID;
            return persistent;
        }
        #endregion
    }


}

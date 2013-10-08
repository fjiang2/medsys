using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tie;
using Sys.Xmpp;
using Sys.Data;
using Sys.Data.Manager;


namespace Sys.Workflow
{

    public class CollaborativeTask : Task, IValizable 
    {
        private bool unlocked = true;
      
        //Create new task
        public CollaborativeTask(CollaborativeWorkflowInstance workflowInstance, VAL val)
        {
            string stateName = val["Name"].Str;
            State state = workflowInstance.Workflow.States[stateName];
            this.taskData = workflowInstance.Data.NewInstance(workflowInstance, state);

          
        }

        //create an activity instance
        public CollaborativeTask(CollaborativeWorkflowInstance workflowInstance, State state)
        {
            this.taskData = workflowInstance.Data.NewInstance(workflowInstance, state);
        }

        //read existed task
        public CollaborativeTask(ICollaborativeTask taskData)
            :base(taskData)
        {
        }


        protected void InitData(VAL val)
        {
            Conversion.VAL2Class(val, this.taskData);
            Conversion.VAL2Class(val, this);
        }

        public TaskNodeCollection ReceivedCollection { get { return new TaskNodeCollection(Data,  TaskNodeType.Receivers); } }
        public TaskNodeCollection AssignedCollection { get { return new TaskNodeCollection(Data,  TaskNodeType.Assigned); } }
        private TaskNodeCollection RepliedCollection { get { return new TaskNodeCollection(Data,  TaskNodeType.Replier); } }
        private TaskNodeCollection NotifiedCollection { get { return new TaskNodeCollection(Data,  TaskNodeType.Notifier); } }
        private TaskNodeCollection AssociatedCollection { get { return new TaskNodeCollection(Data, TaskNodeType.Associated); } }

        public new ICollaborativeTask Data { get { return (ICollaborativeTask)this.taskData; } }
        public ICollaborativeTask Task { get { return (ICollaborativeTask)this.taskData; } }    //used for Workflow definition

        //calculated field
        public bool Unlocked
        {
            get { return unlocked; }
            set { unlocked = value; }
        }

        #region Task children operation

        public void AddReceivers(VAL val)
        {
            ReceivedCollection.Add(val);
        }


        public string SenderName
        {
            get
            {
                Sys.Security.UserAccount user = new Security.UserAccount(this.Data.SenderID);
                return user.FullName;
            }
        }
        //used for notifying subscriber and sender to sync task
        public UserCollectionProtocol SyncReceivers 
        {
            get
            {
                TaskNodeCollection nodes = ReceivedCollection;
                VAL userIDs = nodes.ChildrenNodeList();
                userIDs.Add(new VAL(this.Data.SenderID));   //include sender

                nodes = AssignedCollection;
                userIDs += nodes.ChildrenNodeList();    //inculude guys assigned

                UserCollectionProtocol receivers = XmppChannel.GetUserList(userIDs);
                
                return receivers;
            }
        }


        [Valizable]
        public VAL Recipients
        {
            get
            {
                UserCollectionProtocol users = this.ReceivedCollection.UserCollectionProtocol;
                return users.GetValData();
            }
            set
            {
                this.ReceivedCollection.SetValData(value);
            }

        }

        [Valizable]
        public VAL Workers
        {
            get
            {
                UserCollectionProtocol users = this.AssignedCollection.UserCollectionProtocol;
                return users.GetValData(); 
            }
            set
            {
                this.AssignedCollection.SetValData(value);
            }
        
        }

        #endregion








      






        #region Start/Complete/Assgin task
        public virtual DataRow Save()
        {
            return this.Data.Save();
        }

        public virtual DataRow Load()
        {
            return this.Data.Load();
        }

        public virtual VAL SaveTask(string toClass)
        {
            VAL val = new VAL();
            val["ToClass"] = new VAL(toClass);
            val["Unlocked"] = new VAL(Unlocked);    //calculated field

            DataRow dataRow = Save();      //task.ID created in this moment

            if (!Unlocked)
                DataLocking.CheckOut(this.Task);
            else
            {
                if(Task.TaskStatus == TaskStatus.Completed)
                   DataLocking.CheckIn(this.Task);
            }

#if TASK_VAL_MESSAGE
            Conversion.DataRow2VAL(dataRow, val);
#else
            val["ID"] = new VAL(this.Data.PIN);
#endif
            ((PersistentObject )(this.taskData)).SaveAssociations();
 
  
            return val;
        }


        protected bool CanStart
        {
            get
            {
                if (this.taskData.TaskStatus == TaskStatus.Closed || !this.Unlocked)
                    return false;
                
                return true;
            }
        }


   

        public const int MachineID = -1;

        public bool IsTaskAssignedToMe
        {
            get
            {
                return IsTaskAssignedTo(Sys.Security.Account.CurrentUser.UserID); 
            }
        }

        public bool AssignTaskToMyself()
        {
            return AssignTaskTo(Sys.Security.Account.CurrentUser.UserID);
        }

        public bool IsTaskAssignedTo(int userID)
        {
            TaskNodeCollection nodes = AssignedCollection;
            return nodes.ContainsChildID(userID);
        }

        public bool AssignTaskTo(int userID)
        {
            if (IsTaskAssignedTo(userID))
                return true;

            if (!CanStart)
                return false;

            this.AssignedCollection.Clear();
            this.AssignedCollection.Add(userID);

            this.taskData.TaskStatus = TaskStatus.Opened;
            return true;
        }


        protected virtual void TryStartWork()
        {

            if (this.taskData.TaskStatus == TaskStatus.Closed)
                throw new ApplicationException("Task is closed, you cannot start task.");

            if (!IsTaskAssignedTo(MachineID))
            {
                if (!IsTaskAssignedToMe)
                    throw new ApplicationException("It is not your assigned task, you cannot start task");
            }

            DataLocking taskLock = new DataLocking(this.Task);
            if (taskLock.OtherLocked)
            {
                Sys.Security.UserAccount acc = new Security.UserAccount(taskLock.CheckedOutBy);
                throw new JException("Task was checked out by {0} at {1}, you cannot start task.", acc.FullName, taskLock.TimeCheckedOut);
            }

            StartWork();
        }

        protected void StartWork()
        {
            this.taskData.TaskStatus = TaskStatus.Opened;
            
            this.taskData.WorkTime[0] = DateTime.Now;
            
            this.Unlocked = false;
            this.Data.Read = true;
            this.Data.SenderID = Sys.Security.Account.CurrentUser.UserID;

        }

        protected bool CanComplete
        {
            get
            {
                if (this.taskData.TaskStatus != TaskStatus.Opened || this.Unlocked)
                    return false;

                return true;
            }
        }

        protected virtual void CompleteTask()
        {
            if (!CanComplete)
                throw new ApplicationException(string.Format("Cannot complete task: {0}", taskData));

            this.taskData.WorkTime[1] = DateTime.Now;
            //this.Complete_Percentage = 100.0;

            this.taskData.TaskStatus = TaskStatus.Completed;

            this.Unlocked = true;
        }

        #endregion


        public VAL GetValData()
        {
            VAL val = Conversion.Class2VAL(this.taskData);
            VAL THIS = Conversion.Class2VAL(this);
            return val+THIS;
        }

        //reschedule work to another user
        public void RevokeTask()
        {
            DataLocking taskLock = new DataLocking(this.Task);
            if (taskLock.OtherLocked)
            {
                DataLocking.MustCheckIn(this.Task);
            }
            else
                DataLocking.CheckIn(this.Task);

            this.AssignedCollection.Clear();
            this.taskData.TaskStatus = TaskStatus.Opened;
        }
     
    }
}



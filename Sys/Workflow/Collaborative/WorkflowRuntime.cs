using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using Sys.ViewManager.Forms;
using Sys.Workflow.Collaborative.Protocols;
using Sys.Xmpp;
using Sys.Security ;
using System.Data;
using Sys.Workflow.Collaborative.Forms;
using Sys.Workflow.Forms;
using System.Windows.Forms;

namespace Sys.Workflow.Collaborative
{

    static class WorkflowRuntime
    {
        static Account account = Sys.Security.Account.CurrentUser;

        #region Sync Task

        public static void SyncNewTask(XmppChannel channel, CollaborativeTask task)
        {
            SyncNewTask(Sys.Security.Account.CurrentUser, channel, task);
        }

        public static void SyncTask(CollaborativeTask task)
        {
            SyncTask(Sys.Security.Account.CurrentUser, task);
        }

        public static void SyncNewTask(Account account, XmppChannel channel, CollaborativeTask task)
        {

            task.Data.SenderID = account.UserID;
            task.AddReceivers( channel.Subscribers.GetValData() );
            VAL val = task.SaveTask(typeof(TaskListForm).FullName);

            //Don't Sync Logical State
            if(task is CollaborativeActivity)
            {
                if (((CollaborativeActivity)task).State.IsLogicalState)
                    return;
            }

            //val["FromClass"] = new VAL(this.GetType().FullName);
            XmppClient.Instance.SendMessage(channel, val);

        }

        public static void SyncTask(Account account, CollaborativeTask task)
        {

            task.Data.SenderID = account.UserID;
            VAL val = task.SaveTask(typeof(TaskListForm).FullName);

            //Don't Sync Logical State
            if (task is CollaborativeActivity)
            {
                if (((CollaborativeActivity)task).State.IsLogicalState)
                    return;
            }

            //val["FromClass"] = new VAL(this.GetType().FullName);
            XmppClient.Instance.SendMessage(task.SyncReceivers, task.Data.Subject, val);

        }

        #endregion




      


        public static Message DoActivityForm(ContainerControl owner, int workflowInstanceID, string stateName)
        {
            CollaborativeActivity activity = CollaborativeActivity.NewInsance(workflowInstanceID, stateName, typeof(WorkflowInstanceDpo));
            return DoActivityForm(owner, activity);
        }


        public static Message DoActivityForm(ContainerControl owner, CollaborativeActivity activity)
        {

            //let not started task be completed since workflow instance has been completed
            if (activity.WorkflowInstance.Data.Completed && activity.Data.TaskStatus == TaskStatus.NotStarted)
            {
                activity.AssignTaskToMyself();
                activity.Start();
                MessageBox.Show("Workflow has been terminated", "Warning");
                activity.Complete();
                return null;
            }

            ActivityWinForm form;

            switch (activity.Data.TaskStatus)
            {
                case TaskStatus.Completed:
                    form = ActivityForm.NewInstance(owner, activity);
                    form.WorkMode = WorkMode.Reading;
                    form.PopUp(owner, FormPlace.Auto);
                    activity.DoAfterAction();
                    return new Message(MessageLevel.Information, "Completed {0} is readonly.", (CollaborativeTask)activity);

                case TaskStatus.NotStarted:
                case TaskStatus.Opened:
                    if (!activity.IsTaskAssignedToMe)
                    {
                        if (!activity.AssignTaskToMyself())
                            throw new SysException("Cannot assign task to myself.");

                    }
                    activity.Start();
                    form = ActivityForm.NewInstance(owner, activity);

                    if (activity.State.IsAgentState)
                        form.WorkMode = WorkMode.Reading;

                    form.PopUp(owner, FormPlace.Auto);
                    activity.DoAfterAction();   //do works such as monitor, Listen XMPP message
                    if (activity.State.IsAgentState)
                        if (!activity.StartAgent())
                            return new Message(MessageLevel.Error, "Agent is not defined in {0}", activity.State);
                    break;

                default:
                    return new Message(MessageLevel.Warning, "{0} is in status:{1}.", activity, activity.Data.TaskStatus);
            }

            return null;

        }




        /// <summary>
        /// Start a new Workflow instance, and then start 1st Activity/State
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="workflow"></param>
        public static void StartWorkflowInstance(ContainerControl owner, Workflow workflow)
        {

            CollaborativeWorkflowInstance workflowInstance = CollaborativeWorkflowInstance.NewInstance(workflow, typeof(WorkflowInstanceDpo));
            
            WorkflowInstanceDpo wfiDpo = (WorkflowInstanceDpo)workflowInstance.Data;
            WorkflowDpo wfDpo = (WorkflowDpo)workflow.Data;

            wfiDpo.Label = wfDpo.Label;
            wfiDpo.Description = wfDpo.Description;
            
            workflowInstance.Save();
            
            CollaborativeActivityCollection initialActivities = workflowInstance.Start();

            if (initialActivities.Count == 0)
                throw new ApplicationException("Workflow initial states are not defined.");
            
            CollaborativeActivity activity = initialActivities[0];

            DoActivityForm(owner, activity);
        }

        public static void StartLogicalActivity(ContainerControl owner, CollaborativeActivity activity)
        {
            activity.AssignTaskToMyself();
            activity.Start();
            ActivityWinForm form = ActivityForm.NewInstance(owner, activity);

            if (form == null)   //logical state without UI
            {
                activity.Complete();
                return;
            }

            //logical state having UI
            form.FormClosed += delegate(object sender, FormClosedEventArgs e)
            {
                form.CompleteActivity();
            };

            form.PopUp();
        }

       
    }
}

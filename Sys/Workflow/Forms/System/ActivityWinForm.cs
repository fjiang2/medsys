using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Sys.Workflow.Collaborative;
using System.Windows.Forms;
using Sys.Workflow.Collaborative.Protocols;
using Tie;
using Sys.Security;
using Sys.Xmpp;
using System.Reflection;
using System.Data;
using Sys.ViewManager.Forms;

namespace Sys.Workflow.Forms
{
    public class ActivityWinForm : BaseForm, IContext
    {
        protected CollaborativeActivity activity;
        

        public ActivityWinForm()
        {
        }

        public ActivityWinForm(string instanceID)
            :base(instanceID)
        {
        }


        /// <summary>
        /// Every activity instance can be opened on the tab, every State has its own Form layout setting
        /// </summary>
        /// <param name="activity"></param>
        public ActivityWinForm(CollaborativeActivity activity)
            : base(activity.Data.PIN.ToString(), activity.WorkflowInstance.Workflow.WorkflowName + "_" + activity.State.StateName)
        {
            this.activity = activity;
        }


        internal CollaborativeActivity Activity
        {
            get
            {
                return this.activity;
            }
        }

        /// <summary>
        /// Update Workflow Instance context, Invoked after activity completed
        /// </summary>
        /// <param name="workflowContext">Workflow Instance Context</param>
        /// <param name="activityContext">this Activity Context</param>
        public virtual void UpdateWorkflowContext(VAL workflowContext, VAL activityContext)
        {
            UpdateContext(this.Controls, workflowContext, activityContext);
        }



        private void UpdateContext(Control.ControlCollection Controls, VAL workflowContext,VAL activityContext)
        {
            foreach (Control control in Controls)
            {
                if (control is IContext)
                    ((IContext)control).UpdateWorkflowContext(workflowContext, activityContext);
                else if (control is ScrollableControl)
                    UpdateContext(((ScrollableControl)control).Controls, workflowContext, activityContext);
            }
        }

        public override DialogResult PopUp()
        {
            return base.PopUp(this.ParentControl, FormPlace.WindowForm);
        }


        /// <summary>
        /// Context shared by workflow instance
        /// </summary>
        public VAL WorkflowContext
        {
            get
            {
                if (this.activity == null)
                    return null;

                return this.activity.WorkflowInstance.Context;
            }
        }

        /// <summary>
        /// Context shared by activity, other activities may point to it
        /// </summary>
        public VAL ActivityContext
        {
            get
            {
                if (this.activity == null)
                    return null;

                return this.activity.Context;
            }
        }

        public virtual void CompleteActivity()
        {
            if (this.activity == null)
                throw new ApplicationException(string.Format("Activity({0}) has not been started yet.", this.GetType().FullName));


            if (this.activity.TaskStatus == TaskStatus.Completed)
            {
                this.WarningMessage = string.Format("Activity {0} completed already.", this.activity);
                return;
            }

            UpdateWorkflowContext(WorkflowContext, this.activity.Context);

            Cursor.Current = Cursors.WaitCursor;

            this.activity.Complete();
#if DEBUG            
            if (this.activity.State.IsFinalState)
                this.InformationMessage = string.Format("{0} completed.", this.activity.WorkflowInstance);
#endif
            
            Cursor.Current = Cursors.Default;
        }

       

        public override bool DataSave()
        {
            //ValidateProvide is linear
            if (!this.RuleValidated())
                return false;

            this.Cursor = Cursors.WaitCursor;
            bool result = DataSave(this.Controls);
            this.Cursor = Cursors.Default;
            
            if(result)
                this.InformationMessage = "Data is saved.";
            else
                this.InformationMessage = "Data is not saved.";
            
            return result;
        }

        private static bool DataSave(Control.ControlCollection Controls)
        {
            bool result = true;

            foreach (Control control in Controls)
            {
                if (control is ActivityUserControl)
                {
                    ActivityUserControl auc = (ActivityUserControl)control;
                    if (auc.WorkMode == WorkMode.Reading)   //in the review mode, some fields can be changed and saved
                        continue;

                    if (!auc.DataSave())
                        result = false;
                }
               
                else if (control is TabControl)
                {
                    foreach (TabPage page in ((TabControl)control).TabPages)
                    {
                        if (!DataSave(page.Controls))
                            result = false;
                    }
                }
                else if (control is ScrollableControl)
                {
                    if(!DataSave(((ScrollableControl)control).Controls))
                        result= false;
                }
            }
            
            return result;
        }


        public override bool DataCancel()
        {
            bool result = DataCancel(this.Controls);
            this.InformationMessage = "Data is not saved.";
            return result;
        }



        private static bool DataCancel(Control.ControlCollection Controls)
        {
            bool result = true;

            foreach (Control control in Controls)
            {
                if (control is ActivityUserControl)
                {
                    ActivityUserControl auc = (ActivityUserControl)control;
                    if (auc.WorkMode == WorkMode.Reading)
                        continue;

                    if (!auc.DataCancel())
                        result = false;
                }

                else if (control is TabControl)
                {
                    foreach (TabPage page in ((TabControl)control).TabPages)
                    {
                        if (!DataCancel(page.Controls))
                            result = false;
                    }
                }
                else if (control is ScrollableControl)
                {
                    if (!DataCancel(((ScrollableControl)control).Controls))
                        result = false;
                }
            }

            return result;
        }


        /// <summary>
        /// Save Data, Complete Activity and Close form
        /// </summary>
        /// <returns></returns>
        public virtual bool Submit()
        {
            //if (!this.validateProvider.Passed)
            //    return false;

            if (DataSave())
            {
                CompleteActivity();
                this.Close();

                return true;
            }

            return false;
        }

        public virtual bool DataSaveAsDraft()
        {
            if (DataSave())
            {
                this.InformationMessage = "Data is saved";
                return true;
            }

            this.WarningMessage = "Data is not saved";
            return false;
        }


        protected void DoActivityForm(DataRow taskRow)
        {
            int workflowInstanceID = (int)taskRow[TaskDpo._WorkflowInstance_ID];
            string stateName = (string)taskRow[TaskDpo._State_Name];

            DoActivityForm(workflowInstanceID, stateName);
        }

        public void DoActivityForm(int workflowInstanceID, string stateName)
        {
            this.InformationMessage = "";

            try
            {
                this.ShowMessage(WorkflowRuntime.DoActivityForm(this, workflowInstanceID, stateName));
            }
            catch (Exception ex)
            {
                this.ShowError(ex.Message);
            }
        }


        /// <summary>
        /// Don't allow adding Activity into Shortcuts
        /// </summary>
        /// <param name="pinned"></param>
        /// <returns></returns>
        protected override bool AddShortCut(bool pinned)
        {
            return false;
        }


        protected void ResizePanel(Panel panel)
        {
            int height = 0;
            int width = 0;
            foreach (Control control in panel.Controls)
            {
                height += control.Height;
                if (control.Width > width)
                    width = control.Width;
            }

            int diffWidth = 0;
            if (panel.Width < width)
                diffWidth = width - panel.Width;

            int diffHeight = 0;
            if (panel.Height < height)
                diffHeight = height - panel.Height;


            this.Size = new Size(this.Width + diffWidth, this.Height + diffWidth);
        }

        internal static ActivityWinForm NewInstance(ContainerControl owner, CollaborativeActivity activity)
        {
            ActivityWinForm Instance = (ActivityWinForm)activity.DoAction();

            //this is virtual state
            if (Instance == null)
                return null;

            Instance.ParentControl = owner;
            Instance.activity = activity;
            return Instance;
        }

  

    }
}

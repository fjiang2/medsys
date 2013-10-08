using System;
using System.Collections.Generic;
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
using Sys.Workflow.Forms;

namespace Sys.Workflow.Forms
{
    public class ActivityUserControl : BaseUserControl, IContext
    {
        public ActivityUserControl()
        {
        }

        public ActivityWinForm Form
        {
            get
            {
                if (form is ActivityWinForm)
                    return (ActivityWinForm)form;
                else
                    return null;
            }
        }


        protected CollaborativeActivity activity
        {
            get
            {
                if (Form != null)
                    return Form.Activity;

                return null;
            }
        }

        /// <summary>
        /// Update context when activity complemented
        /// </summary>
        /// <param name="workflowContext"></param>
        /// <param name="activityContext"></param>
        public virtual void UpdateWorkflowContext(VAL workflowContext, VAL activityContext)
        {
        }

        public VAL WorkflowContext
        {
            get
            {
                if (Form != null)
                    return this.Form.WorkflowContext;
                else
                    return new VAL();
            }
        }

        public VAL ActivityContext
        {
            get
            {
                if (Form != null)
                    return this.Form.ActivityContext;
                else
                    return new VAL();
            }
        }

        public virtual bool DataSave()
        {
            return true;
        }

        public virtual bool DataCancel()
        {
            return true;
        }
    }
}

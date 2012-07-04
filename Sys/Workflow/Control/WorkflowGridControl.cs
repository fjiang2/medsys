using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;

namespace Sys.Workflow
{
    public class WorkflowGridControl : JAssociator2
    {
        IWorkflowView workflowView;
        Workflow workflow;

        public WorkflowGridControl()
        {
            this.AllowAddNew = false;
        }

        public WorkflowGridControl(IWorkflowView workflowView)
            :this()
        {
            this.workflowView = workflowView;
            this.workflow = workflowView.Workflow;
        }

        public IWorkflowView Workflow 
        {

            set
            {
                this.workflowView = value;
            }
        }


        public override DataTable[] DataSource
        {
            set
            {
                base.DataSource = new DataTable[] 
                {
                    value[0],
                    value[1],
                    value[2]
                };

            }
        }

   

    }
}

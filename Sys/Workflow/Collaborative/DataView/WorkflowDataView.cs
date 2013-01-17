using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sys.Data;

namespace Sys.Workflow.Collaborative
{
    public class WorkflowDataView : WorkflowDpo, IWorkflowView 
    {

        [NonPersistent]  private DateTime baseDateTime;
        [NonPersistent]  private Workflow workflow;

        public WorkflowDataView(string workflowName)
            : base(workflowName)
        {
            this.baseDateTime = DateTime.Today;
            this.workflow = new Workflow(this);

        }
        public Workflow Workflow { get { return this.workflow; } }

        #region Interface IWorkflow

        public string Title { get { return this.Label; } }
        public DateTime BaseDateTime { get { return this.baseDateTime; } }

      
        #endregion
    }
}

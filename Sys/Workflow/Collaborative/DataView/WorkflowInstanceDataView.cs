using System;
using System.Collections.Generic;
using System.Text;
using Sys.Data;

namespace Sys.Workflow.Collaborative
{
    public class WorkflowInstanceDataView : WorkflowInstanceDpo, IWorkflowInstanceData 
    {
        [Association("WorkflowInstance_ID=@ID"), Aggregated]
        public PersistentCollection<TaskDpo> ActivityInstanceList;

        public WorkflowInstanceDataView(int instantID)
            : base(instantID)
        { 
        
        }

        public IDPCollection DpcActivityInstance
        {
            get
            {
                return this.ActivityInstanceList;
            }
        }
    }
}

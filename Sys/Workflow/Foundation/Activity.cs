using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Workflow.Foundation
{
    public class Activity: Task
    {
        private WorkflowInstance workflowInstance;
        private State state;

        public Activity(WorkflowInstance workflowInstance, State state)
        {

            this.workflowInstance = workflowInstance;
            this.state = state;
        }
    }
}

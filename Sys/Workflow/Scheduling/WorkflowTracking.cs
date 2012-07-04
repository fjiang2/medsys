using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Workflow
{
    public class WorkflowTracking
    {
        private Dictionary<State, Task> tasks = new Dictionary<State, Task>();  
        private Workflow workflow;

        public WorkflowTracking(CollaborativeWorkflowInstance workflowInstance)
        {
            this.workflow = workflowInstance.Workflow;
            CollaborativeActivityCollection activities = workflowInstance.Activities;
            foreach (State state in workflow.States.Values)
            {
                CollaborativeActivity activity = activities[state];
                tasks.Add(state, activity);
            }
        }

        public WorkflowTracking(WorkflowInstance workflowInstance)
        {
            this.workflow = workflowInstance.Workflow;
            tasks = workflowInstance.Tasks;
        }

        public Workflow Workflow { get { return this.workflow; } }

        public Dictionary<State, Task> Tasks
        {
            get
            {
                return this.tasks;
            }
        }
  
    }
}

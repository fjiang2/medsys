using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Workflow
{
    public class WorkflowInstance
    {
        private Dictionary<State, Task> tasks = new Dictionary<State, Task>();
        
        private Workflow workflow;
        private IWorkflowInstanceData workflowInstance;

        public WorkflowInstance(Workflow workflow, IWorkflowInstanceData workflowInstance)

        {
            this.workflow = workflow;
            this.workflowInstance = workflowInstance;

            foreach (IActivityInstanceData activity in workflowInstance.DpcActivityInstance)
            {
                tasks.Add(workflow.States[activity.StateName], new Task(activity)); 
            }
        }

        public Workflow Workflow { get { return this.workflow; } }
        public Dictionary<State, Task> Tasks { get { return this.tasks; } }

        public bool CanStartTask(string stateName)
        {
            return CanStartTask(workflow.States[stateName]);
        }

        public bool CanStartTask(State state)
        {
            if (state.PrevStates.Count == 0)
                return true;

            foreach (State S in state.PrevStates)
            {
                if (tasks[S].Data.TaskStatus != TaskStatus.Completed)
                    return false;
                else
                {
                    if (!CanStartTask(S))
                        return false;
                }
            }

            return true;

        }


        public TaskCollection ReadyToWorkTasks()
        {
            TaskCollection taskCollection = new TaskCollection();

            foreach (State state in workflow.States.Values)
            {
                if (CanStartTask(state))
                {
                    taskCollection.Add(tasks[state]);
                }
            }

            return taskCollection;
        
        }
    }
}

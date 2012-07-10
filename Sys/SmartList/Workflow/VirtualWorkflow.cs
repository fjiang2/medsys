using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sys.Workflow;
using Sys.Data;

namespace Sys.SmartList
{
    class VirtualWorkflow : PersistentObject, IWorkflowData, IWorkflowInstanceData, IWorkflowView
    {

        private IDPCollection StateList;
        private IDPCollection TransitionList;
        private IDPCollection ActivityList;

        private Sys.Workflow.Workflow workflow;
        private WorkflowTracking workflowTracking;

        public VirtualWorkflow(DataSet dataSet)
        {
            StateList = new DPCollection<VirtualStatePersistent>(dataSet.Tables[0]);
            TransitionList = new DPCollection<VirtualTransitionPersistent>(dataSet.Tables[1]);

            if(dataSet.Tables.Count==3)
                ActivityList = new DPCollection<VirtualActivityPersistent>(dataSet.Tables[2]);

            this.workflow = new Sys.Workflow.Workflow(this);

            if (dataSet.Tables.Count == 3)
            {
                WorkflowInstance workflowInstance = new WorkflowInstance(workflow, this);
                this.workflowTracking = new WorkflowTracking(workflowInstance);
            }
        }

        public Sys.Workflow.Workflow Workflow { get { return this.workflow; } }
        public WorkflowTracking WorkflowTracking { get { return this.workflowTracking; } }

        public string WorkflowName { get { return "VM"; } }
        public string CompanyName { get { return ""; } }

        public IDPCollection DpcState { get { return this.StateList; } }
        public IDPCollection DpcTransition { get { return this.TransitionList; } }
        public IDPCollection DpcActivityInstance { get { return this.ActivityList; } }

        public ITransitionData NewTransition()
        {
            return null;
        }

        public IStateData NewState()
        {
            return null;
        }


        public string Title
        {
            get { return null; }
        }

        public DateTime BaseDateTime
        {
            get
            {
                    return DateTime.Today;
            }
        }

    }
}

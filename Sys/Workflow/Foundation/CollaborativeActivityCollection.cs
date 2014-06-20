using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.Workflow
{
    public class CollaborativeActivityCollection : List<CollaborativeActivity>, IValizable 
    {
        CollaborativeWorkflowInstance workflowInstance;
        
        public CollaborativeActivityCollection(CollaborativeWorkflowInstance workflowInstance)
        {
            this.workflowInstance = workflowInstance;
        }


        public string Path
        {
            get
            {
                return string.Format("{0}.{1}", this.workflowInstance.Path, CollaborativeWorkflowInstance.NS_STATES);
            }
        }


        public VAL GetVAL()
        {
            return workflowInstance.Evaluate(this.Path);
        }

        public void SetVAL(VAL val)
        {
            throw new NotImplementedException();
        }

        public VAL GetValData(string stateName)
        {
            VAL val = this.GetVAL();
             return val[stateName];
        }


        public CollaborativeActivity Search(State state)
        {
            foreach (CollaborativeActivity activity in this)
            {
                if (activity.State == state)
                    return activity;
            }

            return null;
        }

        public CollaborativeActivity this[string stateName]
        {
            get
            {
                State state = this.workflowInstance.Workflow.States[stateName];
                return this[state];
            }
        }

        public CollaborativeActivity this[State state]
        {
            get
            {
                CollaborativeActivity activity = Search(state);
                if (activity != null)
                    return activity;

                VAL val = GetValData(state.StateName);
                
                if (val["ID"].Defined)
                   activity = new CollaborativeActivity(this.workflowInstance, val);       //load existed 
                else
                {
                   activity = new CollaborativeActivity(this.workflowInstance, state);     //create an ActivityInstance
                }

                this.Add(activity);
                return activity;
            }
            
        }

    }
}

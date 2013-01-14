using System;
using System.Collections.Generic;
using System.Text;
using Sys.ViewManager;
using Sys.Data;

namespace Sys.Workflow
{
    public class AutoScheduling
    {
        private Workflow workflow;

        public AutoScheduling(Workflow workflow)
        {
            this.workflow = workflow;
        }

        public void CalculateOffset()
        {
 
            foreach (State state in workflow.States.Values)
            {
                if (state.NextStates.Count == 0)
                {
                    CalculateOffset(state, new Stack<State>());
                }
            }

            workflow.Data.DpcState.Sender = this;
            foreach (State state in workflow.States.Values)
                workflow.Data.DpcState.UpdateDataRow((IPersistentObject)state.Data);
        }

        private double CalculateOffset(State state, Stack<State> path)
        {
            if (path.Contains(state))
                throw new ApplicationException(string.Format("Cyclic graph detected in state {0}",  state.StateName));

            if (state.PrevStates.Count == 0)
                return state.Data.PlanOffset;


            path.Push(state);
            foreach (State p in state.PrevStates)
            {
         
                double t = CalculateOffset(p, path) + p.Data.PlanDuration;
                if (state.Data.PlanOffset < t)
                    state.Data.PlanOffset = t;
            }
            
            path.Pop();

            return state.Data.PlanOffset;
        }



        public void VerifyOffset()
        {

            foreach (State state in workflow.States.Values)
            {
                foreach (State p in state.PrevStates)
                {
                    if (state.Data.PlanOffset < p.Data.PlanOffset + p.Data.PlanDuration)
                        throw new ApplicationException(string.Format("state {0} and {1} are overlapped.", state.StateName, p.StateName));
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.Workflow
{
    public class TransitionInstance
    {
        private CollaborativeWorkflowInstance workflowInstance;
        private Transition transition;


        public TransitionInstance(CollaborativeWorkflowInstance workflowInstance, Transition transition)
        {
            this.workflowInstance = workflowInstance;
            this.transition = transition;
        }

        public VAL Expr()
        {
            return workflowInstance.Evaluate("", transition.Expr); 
        }
    }
}

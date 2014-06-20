using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using System.Data;
using Sys.Data;

namespace Sys.Workflow
{
    public class Transition :   IValizable 
    {
        Workflow workflow;
        ITransitionData transitionData;

  

        public Transition(Workflow workflow, ITransitionData transitionData)
        {
            this.workflow = workflow;
            this.transitionData = transitionData;
        }



        public Transition(Workflow workflow, VAL val)
        {
            this.workflow = workflow;
            this.transitionData = NewTransition(val);
        }


        private ITransitionData NewTransition(VAL val)
        {
            ITransitionData persistent = workflow.Data.NewTransition();
            Conversion.VAL2Class(val, persistent);
            return persistent;
        }


        public ITransitionData Data { get { return this.transitionData; } } 
      
        //from state (Source)
        public State State1
        {
            get
            {
                return workflow.States[this.S1Name];
            }
        }
        
        //to state (Sink)
        public State State2
        {
            get
            {
                return workflow.States[this.S2Name];
            }
        }

        public string Path
        {
            get
            {
                return string.Format("{0}.T.{1}.{2}", workflow.Path, this.S1Name, this.S2Name);
            }
        }

        [Valizable]
        public string Expr
        {
            get
            {
                return
                    transitionData.Expr
                    .Replace("this.s1", this.State1.Path)
                    .Replace("this.s2", this.State2.Path)
                    .Replace("base", this.workflow.Path+".States");
            }
                
        }

        public string Name
        {
            get { return this.S1Name + "_" + this.S2Name; }
        }

        public VAL GetVAL()
        {
            return transitionData.GetVAL();
        }

        public void SetVAL(VAL val)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("Transition(Workflow={0}, {1}-->{2})", workflow.WorkflowName, this.S1Name, this.S2Name);
        }



        public string S1Name { get { return transitionData.S1Name; }}
        public string S2Name { get { return transitionData.S2Name; }}
    }
}

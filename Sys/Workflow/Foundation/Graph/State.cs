using System;
using System.Collections.Generic;
using System.Text;
using Sys.Xmpp;
using Tie;
using System.Data;
using System.Reflection;
using Sys.Data;

namespace Sys.Workflow
{

    public class State : IValizable
    {
        private Workflow workflow;
        private TransitionCollection transitions;
        private IStateData stateData;


        public Workflow Workflow { get { return this.workflow; } }
        public IStateData Data { get { return this.stateData; } }
        public TransitionCollection Transitions { get { return this.transitions; } }
        public StateCollection NextStates { get { return this.transitions.InboundStates; } }
        public StateCollection PrevStates { get { return this.transitions.OutboundStates; } }


        public State(Workflow workflow, VAL val)
        {
            this.workflow = workflow;

            this.stateData = NewState(workflow, val);
            this.transitions = new TransitionCollection(this);
       }



        public State(Workflow workflow, IStateData stateData)
        {
            this.workflow = workflow;
            this.stateData = stateData;
            this.transitions = new TransitionCollection(this);
        }


        private IStateData NewState(Workflow workflow, VAL val)
        {
            IStateData persistent = workflow.Data.NewState();
            Conversion.VAL2Class(val, persistent);
            return persistent;
        }


        public bool IsInitialState
        {
            get 
            {
                return (stateData.StateNodeType & StateNodeType.Initial) == StateNodeType.Initial;
            }
        }

        public bool IsFinalState
        {
            get
            {
                return (stateData.StateNodeType & StateNodeType.Final) == StateNodeType.Final;
            }
        }


        public bool IsLogicalState
        {
            get
            {
                return (stateData.StateNodeType & StateNodeType.Logical) == StateNodeType.Logical;
            }
        }

        public bool IsAgentState
        {
            get
            {
                return (stateData.StateNodeType & StateNodeType.Agent) == StateNodeType.Agent;
            }
        }

        public override string ToString()
        {
            return string.Format("State(Name={0}, Workflow={1}, #Transition={2})", this.StateName, this.workflow.WorkflowName, this.transitions.Count);
        }

        internal VAL NotifiedStates(string BASE)
        {
            VAL states = VAL.Array();
            Memory memory = new Memory();

            string THIS = BASE + "." + this.StateName;
            try
            {
                Script.Evaluate(THIS, this.stateData.StateDependency, memory, new WorkflowFunction());
                VAL nodes = Script.Evaluate(BASE, memory);

                if (nodes.Undefined)
                    return states;

                for (int i = 0; i < nodes.Size; i++)
                {
                    VAL node = nodes[i];
                    if (node[0].Str != this.StateName && !(node[0] < states))    //because Denpendency here does not have all variables available, some variables's value is VOID.
                        states.Add(node[0]);
                }
            }
            catch (Exception)
            {

            }
            return states;

        }
        
        public VAL GetValData()
        {
            return stateData.GetValData();
        }

        public string Path
        {
            get
            {
                return string.Format("{0}.{1}.{2}", workflow.Path, Workflow.NS_STATES, this.StateName);
            }
        }


        public string StateName 
        {
            get 
            { 
                return stateData.StateName; 
            } 
        }
    }
}

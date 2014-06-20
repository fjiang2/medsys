using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using System.Reflection;
using System.Data;
using Sys.Data;

namespace Sys.Workflow
{
    public class Workflow :  IValizable
    {
        public const string NS_WORKFLOW = "Workflow";
        public const string NS_STATES = "States";
        public const string NS_TRANSITIONS = "Transitions";
        public const string NS_EDGES = "Edges";

        private Dictionary<string, State> states = new Dictionary<string, State>();
        private Dictionary<string, Transition> transitions = new Dictionary<string, Transition>();
        private IWorkflowData workflowData;

        public string WorkflowName { get { return workflowData.WorkflowName; } }
        public Dictionary<string, State> States  { get { return states; }  }
        public Dictionary<string, Transition> Transitions    {  get { return transitions; } }
        public IWorkflowData Data { get { return this.workflowData; } }
        

        //read a workflow for workflow TreeView display
        public Workflow(IWorkflowData workflowData)
        {
            this.workflowData = workflowData;
            
            //this.workflowData.NewWorkflow(this);
            BuildGraph();

            this.workflowData.DpcState.ObjectChanged += this.StateHandler;
            this.workflowData.DpcTransition.ObjectChanged += this.TransitionHandler;
            BuildConnectedStates();
        }



        //used for workflow parters
        public Workflow(VAL val)
        {
            this.workflowData = (IWorkflowData)NewInstance(val);

            VAL S = val[NS_STATES];

            for (int i = 0; i < S.Size; i++)
            {
                State state = new State(this, S[i][1]);
                this.states.Add(state.StateName, state);
            }

            VAL T = val[NS_TRANSITIONS];

            for (int i = 0; i < T.Size; i++)
            {
                Transition transition = new Transition(this, T[i]);
                this.transitions.Add(transition.Name, transition);
            }

            BuildConnectedStates();
        }


        public static object NewInstance(VAL val)
        {
            string className = val["ClassName"].Str;
            object persistent = HostType.NewInstance(className, new object[] { });
            Conversion.VAL2Class(val, persistent);
            return persistent;
        }

        private void BuildGraph()
        {
            for (int i = 0; i < this.workflowData.DpcState.Count; i++)
            {
                IStateData persistent = (IStateData)this.workflowData.DpcState.GetObject(i);
                if (persistent != null)
                {
                    State state = new State(this, persistent);
                    this.States.Add(state.StateName, state);
                }
            }

            //build prev_states and next_states
            for (int i = 0; i < this.workflowData.DpcTransition.Count; i++)
            {
                ITransitionData persistent = (ITransitionData)this.workflowData.DpcTransition.GetObject(i);
                if (persistent != null)
                {
                    Transition transition = new Transition(this, persistent);
                    this.Transitions.Add(transition.Name, transition);
                }
            }

        }
        private void BuildConnectedStates()
        {
            //build prev_states and next_states
            foreach(Transition transition in  this.transitions.Values)
            {
                this.states[transition.S1Name].Transitions.Add(transition);
                this.states[transition.S2Name].Transitions.Add(transition);
            }
        }

        public void PredictConnectedStates()
        {
            string BASE = this.Path + "." + NS_STATES;

            //build prev_states and next_states
            this.transitions.Clear();
            foreach (State state in states.Values)
            {
                VAL ps = state.NotifiedStates(BASE);
                for (int i = 0; i < ps.Size; i++)
                {
                    string name = ps[i].Str;
                    ITransitionData T = workflowData.NewTransition();
                    T.WorkflowName = this.WorkflowName;
                    T.S1Name = name;
                    T.S2Name = state.StateName;

                    Transition transition = new Transition(this, T);
                    
                    if(name!=state.StateName)
                        this.transitions.Add(transition.Name, transition);
                }

            }
        }

        public StateCollection InitialStates
        {
            get
            {
                StateCollection initialStates = new StateCollection(this);

                foreach(State state in states.Values)
                {
                    if (state.IsInitialState)
                        initialStates.Add(state);
                }

                return initialStates;
            }
        }

        public StateCollection FinalStates
        {
            get
            {
                StateCollection finalStates = new StateCollection(this);

                foreach (State state in states.Values)
                {
                    if (state.IsFinalState)
                        finalStates.Add(state);
                }

                return finalStates;
            }
        }

   


        public override string ToString()
        {
            return string.Format("workflow(Name={0},#States={1},#Transition={2})", this.WorkflowName, this.states.Count, this.transitions.Count);
        }

        public VAL GetVAL()
        {
            VAL V1 = workflowData.GetVAL();


            VAL V2 = new VAL();
            V1[NS_STATES] = V2;
            foreach (KeyValuePair<string, State> kvp in states)
            {
                V2[kvp.Key] = kvp.Value.GetVAL();
            }
   
            VAL V3 = VAL.Array();
            V1[NS_TRANSITIONS] = V3;
            foreach (Transition transition in this.transitions.Values)
            {
                V3.Add(transition.GetVAL());
            }

            /***
             * 
            VAL V4 = VAL.Array();
            V1["T"] = V4;   //used for TIE script easily searching, e.g. base.base.T[this.Name]["S2"] returns Expression of (this.State --> S2)
            foreach (Transition transition in this.transitions.Values)
            {
                if(V4[transition.S1Name].Undefined)
                    V4[transition.S1Name] = new VAL();
                V4[transition.S1Name][transition.S2Name] = transition.GetValData();
                
            }
             
             * ****/
   
            return V1;
        
        }

        public void SetVAL(VAL val)
        {
            throw new NotImplementedException();
        }

        public string Path
        {
            get
            {
                return string.Format("{0}.{1}", NS_WORKFLOW, this.WorkflowName);
            }
        }











        public void AddState(IStateData stateData)
        {
            //add new state
            State state = new State(this, stateData);
            this.States.Add(state.StateName, state);
        }


        public void RemoveState(string stateName)
        {
            State state = this.States[stateName];


            foreach (Transition T in state.Transitions)
            {
                //delete transitions xxxx->state1
                if (T.S2Name == stateName)
                {
                    this.States[T.S1Name].Transitions.Remove(T);
                }

                //delete transitions state1->xxxx
                else if (T.S1Name == stateName)
                {
                    this.States[T.S2Name].Transitions.Remove(T);
                }
            }

            //deltete State, and its NextStates and PrevStates
            this.States.Remove(state.StateName);
        }



        public void AddTransition(ITransitionData transition)
        {
            //add new transition
            Transition T = new Transition(this, transition);
            
            if (this.Transitions.ContainsKey(T.Name))
                return;

            this.Transitions.Add(T.Name, T);

            //add S1.NextStates
            this.States[T.S1Name].Transitions.Add(T);

            //add S2.PrevState
            this.States[T.S2Name].Transitions.Add(T);
        }


        public void RemoveTransition(string S1Name, string S2Name)
        {

            Transition T = this.Transitions[S1Name + "_" + S2Name];

            foreach (State S in this.States.Values)
            {
                if (S.Transitions.Contains(T))
                    S.Transitions.Remove(T);
            }

            //delete transition
            this.Transitions.Remove(S1Name + "_" + S2Name); //refer to:  File: Transition.cs, Property: Name
        }


        private void StateHandler(object sender, PersistentEventArgs e)
        {
            //if (!(e.Sender is DataTable))
            //    return;

            IStateView state = (IStateView)e.Object1;
            
            switch (e.ObjectState)
            {
                case  PersistentObjectState.Added:
                    if (!states.ContainsKey(state.StateName))       //new point does not exist
                    {
                        state.WorkflowName = WorkflowName;
                        this.AddState((IStateData)state);
                    }
                    break;

                case PersistentObjectState.Deleted:
                    this.RemoveState(state.StateName);
                    break;
            }
        }

        private void TransitionHandler(object sender, PersistentEventArgs e)
        {
            //if (!(e.Sender is DataTable))
            //    return;

            ITransitionView transition = (ITransitionView)e.Object1;

            switch(e.ObjectState)
            {
                case PersistentObjectState.Added:
                    this.AddTransition((ITransitionData)transition);                  
                    break;

                case PersistentObjectState.Deleted:
                    this.RemoveTransition(transition.S1Name, transition.S2Name);
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Workflow
{
    public class TransitionCollection : List<Transition> 
    {
        State state;
        public TransitionCollection(State state)
        {
            this.state = state;
        }


        public StateCollection OutboundStates
        {
            get
            {
                StateCollection states = new StateCollection(state.Workflow);
                foreach (Transition transition in this)
                {
                    if (state.StateName == transition.State2.StateName && !states.Contains(transition.State1))
                        states.Add(transition.State1);
                }
                
                return states;
            }
        }

        public StateCollection InboundStates
        {
            get
            {
                StateCollection states = new StateCollection(state.Workflow);
                foreach (Transition transition in this)
                {
                    if (state.StateName == transition.State1.StateName && !states.Contains(transition.State2))
                        states.Add(transition.State2);
                }

                return states;
            }
        }



    }
}

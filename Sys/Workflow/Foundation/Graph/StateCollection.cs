using System;
using System.Collections.Generic;
using System.Text;
using Tie;


namespace Sys.Workflow
{
    public class StateCollection: List<State>
    {
        Workflow workflow;
        public StateCollection(Workflow workflow)
        {
            this.workflow = workflow;
        }


        public override string ToString()
        {
            VAL states = VAL.Array();
            foreach (State state in this)
            {
                states.Add(new VAL(state.StateName));
            }
            
            return states.ToString();
        }


        //public VAL VAL
        //{
        //    get
        //    {
        //        VAL val = VAL.Array(0);
        //        foreach (State state in this)
        //            val.List.Add(state.VAL);

        //        return val;
        //    }
        //}

        public string Path
        {
            get
            {
                return string.Format("{0}.{1}", this.workflow.Path, Workflow.NS_STATES);
            }
        }
    }
}

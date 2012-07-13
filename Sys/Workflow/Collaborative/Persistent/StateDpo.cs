using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using System.Reflection;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Workflow.Dpo;
using System.Data;

namespace Sys.Workflow.Collaborative
{
    public class StateDpo : wfStateDpo, IStateData, IStateView
    {

        //create a state, used by designer tools
        public StateDpo()
        {
            this.StateNodeType = StateNodeType.Normal;
        }

        public StateDpo(DataRow dataRow)
            : base(dataRow)
        { 
        
        }
    
        [Valizable]
        public StateNodeType StateNodeType
        {
            get { return (StateNodeType)this.Ty; }
            set { this.Ty = (int)value; }
        }


        public TimeSpan TimeSpan
        {
            get
            {
                return TimeSpan.FromHours(this.Duration);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
        


        //interface 
        public string WorkflowName { get { return this.Workflow_Name; } set { this.Workflow_Name = value; } }
        public string StateName { get { return this.Name; } set { this.Name = value; } }
        public double PlanOffset { get { return this.Offset; } set { this.Offset = value; } }
        public double PlanDuration { get { return this.Duration; } set { this.Duration = value; } }
        public string StateDependency { get { return this.Dependency; } }
        public string StatePreaction { get { return this.Preaction; } }
        public string StateAction { get { return this.Action; } }
        public string StateAfterAction { get { return this.AfterAction; } }
        public string StatePostaction { get { return this.Postaction; } }
        public string StateAgent { get { return this.Agent; } }
        public string Title { get { return this.Label; } }

        public int StateChannel 
        { 
            get 
            { 
                //return this.Channel; 
                return this.ID; //Column ID must be [Valiable] in order to restore Channel
            } 
        }


    }
}



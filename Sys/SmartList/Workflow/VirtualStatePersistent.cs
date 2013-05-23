using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using System.Reflection;
using Sys.Workflow;
using Sys.Data;

namespace Sys.SmartList
{
#pragma warning disable

    public class VirtualStatePersistent : PersistentObject, IStateData, IStateView
    {
        public string State_Name; 
        public double Offset; 
        public double Duration;

        public VirtualStatePersistent()
        {
        }

        public StateNodeType StateNodeType
        {
            get { return StateNodeType.Normal; }
            set { ;}
        }


        public TimeSpan TimeSpan
        {
            get
            {
                return TimeSpan.FromHours(this.Duration);
            }
        }

  
        //interface 
        public string WorkflowName { get { return ""; } set { ; } }
        public string StateName { get { return this.State_Name; } set { this.State_Name = value; } }
        public double PlanOffset { get { return this.Offset; } set { this.Offset = value; } }
        public double PlanDuration { get { return this.Duration; } set { this.Duration = value; } }
        public int StateChannel { get { return 0; } }
        public string StateDependency { get { return ""; } }
        public string StatePreaction { get { return ""; } }
        public string StateAction { get { return ""; } }
        public string StateAfterAction { get { return ""; } }
        public string StatePostaction { get { return ""; } }
        public string StateAgent { get { return ""; } }
        public string Title { get { return ""; } }

    }
}



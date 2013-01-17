using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tie;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Workflow.DpoClass;
using System.Data;

namespace Sys.Workflow.Collaborative
{
    public class TransitionDpo : wfTransitionDpo, ITransitionData, ITransitionView 
    {
        public TransitionDpo()
        {
            this.Directional = false;
        }

        public TransitionDpo(DataRow dataRow)
            : base(dataRow)
        { 
        
        }

        [Valizable] 
        public virtual string Expr
        {
            get
            {
                if (this.Expression == "")
                    return string.Format("this.s1.Completed");
                else
                    return this.Expression;
            }
            set 
            {
                this.Expression = value;
            }
        }


        public override string ToString()
        {
            if (!this.Directional)
            {
                if (this.Expression != "")
                    return string.Format("{0} --({1})--> {2}", this.S1_Name, this.Expression, this.S2_Name);
                else
                    return string.Format("{0} --> {1}",  this.S1_Name, this.S2_Name);
            }
            else
            {
                if (this.Expression != "")
                    return string.Format("{0} <--({1})--> {2}", this.S1_Name, this.Expression, this.S2_Name);
                else
                    return string.Format("{0} <--> {1}", this.S1_Name, this.S2_Name);
            }

        }

        //public VAL GetValData()
        //{
        //    return Conversion.Class2VAL(this);
        //}

        //interface
        #region interface ITransitionView

        public string WorkflowName { get { return this.Workflow_Name; } set { this.Workflow_Name = value; } }
        public string S1Name { get { return this.S1_Name; } set { this.S1_Name = value; } }
        public string S2Name { get { return this.S2_Name; } set { this.S2_Name = value; } }

        #endregion
    }
}

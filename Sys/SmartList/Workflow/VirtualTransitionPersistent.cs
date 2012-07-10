using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tie;
using Sys.Workflow;
using Sys.Data;

namespace Sys.SmartList
{

#pragma warning disable


    public class VirtualTransitionPersistent : PersistentObject, ITransitionData, ITransitionView
    {
        public string S1_Name;    //nvarchar(100)
        public string S2_Name;    //nvarchar(100)

        public VirtualTransitionPersistent()
        {
        }

        public virtual string Expr
        {
            get{  return ""; }
        }


        //interface
        #region interface ITransitionView

        public string WorkflowName { get { return ""; } set { ; } }
        public string S1Name { get { return this.S1_Name; } set { this.S1_Name = value; } }
        public string S2Name { get { return this.S2_Name; } set { this.S2_Name = value; } }

        #endregion
    }
}

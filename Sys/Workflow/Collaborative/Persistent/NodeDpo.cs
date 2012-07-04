using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using Sys.Data;
using Sys.Workflow.Dpo;
using System.Data;

namespace Sys.Workflow.Collaborative 
{
    public class NodeDpo : wfNodeDpo, ITaskNodeData
    {
        public NodeDpo()
        {
        }

        public NodeDpo(DataRow dataRow)
            : base(dataRow)
        { 
        }

        public int Offspring { get { return this.ChildID; } set { this.ChildID = value; } }
        public TaskNodeType TaskNodeType { get { return (TaskNodeType)Ty; } set { Ty = (int)value; } }
    }
}




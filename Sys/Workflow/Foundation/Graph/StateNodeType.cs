using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Workflow
{
    public enum StateNodeType
    {
        Normal = 0,      //regular state
        Initial = 1,     //entrance state
        Final = 2,       //exit state
        Logical = 4,     //logical state does not have UI
        Agent = 8        //Messaging agent / timer agent   
    }
}

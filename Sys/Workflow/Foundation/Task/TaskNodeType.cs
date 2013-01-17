using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Workflow
{
    public enum TaskNodeType
    {
        Receivers     = 1,        //task receiver list
        Assigned      = 2,        //task assigned to 
        Replier       = 3,        //reply task to 
        Notifier      = 4,        //notify task to
        Associated    = 5         //associated task list
    }
}

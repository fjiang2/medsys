using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Workflow
{
    public enum TaskStatus
    {
        NotStarted  = 1,        //task created, new task
        Opened      = 2,        //in progress
        Completed   = 3,        //finished task but not verified or released
        Closed      = 4,        //verified after completed
        Suspended   = 5,        //pause/hold task
        Cancelled   = 6,        //task cancelled
        Aborted     = 7         //throw an exception

    }

}

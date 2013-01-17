using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.Workflow
{
    //result value when activity is terminated
    public enum ActivityResult
    {

        None = 0,

        //current state status
        Approved = 11,
        Rejected = 12,
        Disputed = 13,
        Ignored = 14,
        Accepted = 15,

        Yes = 31,
        No = 32,
        OK = 33,

        //command to other states
        Reopen = 101,
        Retry = 102,


        UserDefined = 9999
    }

}

    


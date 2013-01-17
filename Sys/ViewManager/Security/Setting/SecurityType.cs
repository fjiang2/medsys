using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.ViewManager.Security
{
   
    public enum SecurityType
    {
        WinForm = 1,
        MenuItem = 2,
        
        SmartList = 4,
        Workflow = 5,
        Report = 6,

        AppLink = 7        //external application shortcuts
    }
}

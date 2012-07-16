using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public enum MessageCode
    {
        None = 0,

        PasswordExpried =1001,
        AccountClosed = 1002,
        AccountLocked = 1003,

        RecordOverwritten =2011
    }

}

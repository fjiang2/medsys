using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public enum ExceptionLevel
    {
        None,
        PasswordExpried,
        AccountClosed,
        AccountLocked,

        RecordOverwritten
    }

}

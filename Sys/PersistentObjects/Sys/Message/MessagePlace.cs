using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    [Flags]
    public enum MessagePlace
    {
        MessageBox          = 1,
        ErrorListWindow     = 2,
        OutputWindow        = 4,
        StatusBar           = 8,
        StatusBar2          = 16
    }
}

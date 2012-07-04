using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.DataManager
{
    [Flags]
    public enum AccessModifier
    {
        Public = 0x01,
        Internal = 0x02,
        Protected = 0x04,
        Private = 0x08,
        Const = 0x10,
        Static = 0x20,
        Virtual = 0x40,
        Override = 0x80,
        Abstract = 0x100
    }
}

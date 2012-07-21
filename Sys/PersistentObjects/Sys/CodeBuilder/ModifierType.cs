using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.CodeBuilder
{
    [Flags]
    public enum ModifierType
    {
        Public = 0x01,
        Internal = 0x02,
        Protected = 0x04,
        Private = 0x08,
        Const = 0x10,
        Static = 0x20,
        Virtual = 0x40,
        Override = 0x80,
        Abstract = 0x100,
        Sealed = 0x200,
        Readonly = 0x400,
        Event = 0x800,
        Extern = 0x10000,
        Unsafe = 0x20000,
        Volatile = 0x40000
    }
}

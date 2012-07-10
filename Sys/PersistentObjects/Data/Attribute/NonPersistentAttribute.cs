using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class NonPersistentAttribute : Attribute
    {
    }
}

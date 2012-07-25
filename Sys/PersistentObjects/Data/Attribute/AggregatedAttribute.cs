using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class AggregatedAttribute : Attribute
    {
        public AggregatedAttribute()
        { 
        }
    }
}

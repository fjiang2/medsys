using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Enum)]
    public class DataEnumAttribute : Attribute
    {
        public DataEnumAttribute()
        {
        }

        public override string ToString()
        {
            string attribute = typeof(DataEnumAttribute).Name.Replace("Attribute", "");
            return string.Format("[{0}]", attribute);
        }
    }

   
}

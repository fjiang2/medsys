using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Enum)]
    public class EnumTypeAttribute : Attribute
    {
        public string Name;


        public EnumTypeAttribute(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            string attribute = typeof(EnumTypeAttribute).Name.Replace("Attribute", "");
            return string.Format("[{0}(\"{1}\")]", attribute, Name);
        }
    }

   
}

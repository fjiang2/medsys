using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class EnumFieldAttribute : Attribute
    {
        public string Caption;


        public EnumFieldAttribute(string caption)
        {
            this.Caption = caption;
        }

        public override string ToString()
        {
            string attribute = typeof(EnumFieldAttribute).Name.Replace("Attribute", "");
            return string.Format("[{0}(\"{1}\")]", attribute, Caption);
        }
    }

   
}

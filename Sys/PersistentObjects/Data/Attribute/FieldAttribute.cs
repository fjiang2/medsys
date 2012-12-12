using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class FieldAttribute : Attribute
    {
        public string Caption;


        public FieldAttribute(string caption)
        {
            this.Caption = caption;
        }

        public override string ToString()
        {
            string attribute = typeof(FieldAttribute).Name.Replace("Attribute", "");
            
            //handling escape letter in the Caption
            string field = new VAL(Caption).ToString();

            return string.Format("[{0}({1})]", attribute, field);
        }
    }

   
}

using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.Data
{
    /// <summary>
    /// describe a field in class or enum
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class FieldAttribute : Attribute
    {
        /// <summary>
        /// description of field
        /// </summary>
        public string Caption;

        /// <summary>
        /// construct by description
        /// </summary>
        /// <param name="caption"></param>
        public FieldAttribute(string caption)
        {
            this.Caption = caption;
        }


        /// <summary>
        /// return attribute description
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string attribute = typeof(FieldAttribute).Name.Replace("Attribute", "");
            
            //handling escape letter in the Caption
            string field = new VAL(Caption).ToString();

            return string.Format("[{0}({1})]", attribute, field);
        }
    }

   
}

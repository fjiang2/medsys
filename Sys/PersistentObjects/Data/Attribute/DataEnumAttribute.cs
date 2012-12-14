using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.Data
{
    /// <summary>
    /// used for user defined data enum type from database
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Enum)]
    public class DataEnumAttribute : Attribute
    {
        /// <summary>
        /// description of DataEnum
        /// </summary>
        public readonly string Caption;
        
        /// <summary>
        /// no description
        /// </summary>
        public DataEnumAttribute()
        {
        }

        /// <summary>
        /// constuct by description
        /// </summary>
        /// <param name="caption"></param>
        public DataEnumAttribute(string caption)
        {
            this.Caption = caption;
        }

        /// <summary>
        /// return name of DataEnum Attribute
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string attribute = typeof(DataEnumAttribute).Name.Replace("Attribute", "");
            return string.Format("[{0}]", attribute);
        }
    }

   
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class MapAttribute : Attribute
    {
        public readonly string Column1;
        public readonly string Column2;
        
        /// <summary>
        /// Get value from parent table, assign value to child table
        /// </summary>
        internal object ReferenceValue = null;

    
        public MapAttribute(string referenceColumnName, string thisColumnName)
        {
            this.Column2 = thisColumnName;

            this.Column1 = referenceColumnName;
        }

        public override string ToString()
        {
            return string.Format("[{0}]=@{1}", this.Column2, this.Column1);
        }
    }
}

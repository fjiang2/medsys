using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class MapAttribute : Attribute
    {
        public readonly string ReferenceColumnName;
        public readonly string ThisColumnName;
        
        /// <summary>
        /// Get value from parent table, assign value to child table
        /// </summary>
        internal object ReferenceValue = null;

    
        public MapAttribute(string referenceColumnName, string thisColumnName)
        {
            this.ThisColumnName = thisColumnName;

            this.ReferenceColumnName = referenceColumnName;
        }

        public override string ToString()
        {
            return string.Format("[{0}]=@{1}", this.ThisColumnName, this.ReferenceColumnName);
        }
    }
}

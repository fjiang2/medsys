using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class ForeignKeyAttribute : Attribute
    {
        public string ParentColumnName;
        public string ChildColumnName;
        
        /// <summary>
        /// Get value from parent table, assign value to child table
        /// </summary>
        internal object value = null;

        public ForeignKeyAttribute(string parentColumnName, string childColumnName)
        {
            this.ParentColumnName = parentColumnName;
            this.ChildColumnName = childColumnName;
        }


        public override string ToString()
        {
            return string.Format("{0}=@{1}", this.ChildColumnName, this.ParentColumnName);
        }
    }
}

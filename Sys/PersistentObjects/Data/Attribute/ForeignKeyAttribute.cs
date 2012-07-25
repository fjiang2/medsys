using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class ForeignKeyAttribute : Attribute
    {
        public readonly Type ReferenceTableName;
        public readonly string ReferenceColumnName;
        public readonly string ForeignKey;
        
        /// <summary>
        /// Get value from parent table, assign value to child table
        /// </summary>
        internal object ReferenceValue = null;

        /// <summary>
        /// FOREIGN KEY (P_Id) REFERENCES Persons(P_Id)
        /// </summary>
        /// <param name="foreignKey"></param>
        /// <param name="ReferenceTableName"></param>
        /// <param name="referenceColumnName"></param>
        public ForeignKeyAttribute(string foreignKey, Type referenceTableName, string referenceColumnName)
        {
            this.ForeignKey = foreignKey;

            this.ReferenceTableName = referenceTableName;
            this.ReferenceColumnName = referenceColumnName;
        }

        public override string ToString()
        {
            return string.Format("[{0}]=@{1}", this.ForeignKey, this.ReferenceColumnName);
        }
    }
}

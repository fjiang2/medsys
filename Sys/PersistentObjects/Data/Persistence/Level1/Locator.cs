using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    /// <summary>
    /// Modeling SQL WHERE clause
    /// </summary>
    public class Locator
    {
        private string where;
        bool unique = true;

        /// <summary>
        /// WHERE [column1]=@column1 AND [column2]=@column2 AND ... 
        /// </summary>
        /// <param name="columns"></param>
        public Locator(string[] columns)
        {
            this.where = string.Join(" AND ", columns.Select(key => string.Format("[{0}]=@{0}", key)));
        }

        public Locator(PrimaryKeys primary)
            :this(primary.Keys)
        {
        }

        public Locator(string any)
        {
            this.where = any;
        }

        public Locator(TableName tname)
            :this(tname.GetCachedMetaTable().Primary)
        {
        }

        public Locator(SqlExpr exp)
        {
            this.where = exp.ToString();
        }

        /// <summary>
        /// One record is operated when [Unique] is true; Treat all records like one record when [Unique] is false
        /// </summary>
        public bool Unique
        {
            get { return this.unique; }
            internal set { this.unique = value; }
        }

        public static bool operator!(Locator locator)
        {
            return string.IsNullOrEmpty(locator.where);
        }

        public override string ToString()
        {
            return this.where;
        }

    }
}

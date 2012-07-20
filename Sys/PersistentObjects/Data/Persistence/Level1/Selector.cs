using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    /// <summary>
    /// Modeling SQL SELECT clause
    /// </summary>
    public class Selector
    {
        string[] columns;


        /// <summary>
        /// select all columns from table(SELECT * FROM table)
        /// </summary>
        public Selector()
        {
            columns = new string[0];
        }


        /// <summary>
        /// SELECT column1, column2,....
        /// </summary>
        /// <param name="columns"></param>
        public Selector(string[] columns)
        {
            this.columns = columns;
        }

        public Selector(IEnumerable<string> columns)
        {
            this.columns = columns.ToArray();
        }


        public bool Exists(string columnName)
        {
            if (columns.Length == 0)
                return true;

            foreach (string name in columns)
            {
                if (columnName == name)
                    return true;
            }

            return false;
        }


        public override string ToString()
        {
            if (columns.Length == 0)
                return "*";         //SELECT * FROM tableName

            return string.Join(",", columns.Select(column => string.Format("[{0}]", column))); ;
        }
    }
}

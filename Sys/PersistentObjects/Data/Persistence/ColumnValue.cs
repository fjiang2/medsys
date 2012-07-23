using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

namespace Sys.Data
{
    public class ColumnValue
    {
        private string columnName;
        private object value;

        public ColumnValue(string columnName, object value)
        {
            this.columnName = columnName;
            this.value = value;
        }

        public ColumnValue(DataColumn column, object value)
            :this(column.ColumnName, value)
        {
        }

        public override string ToString()
        {
            if (value is IEnumerable)
            {
                List<SqlValue> list = new List<SqlValue>();
                foreach (object obj in (IEnumerable)value)
                {
                    list.Add(new SqlValue(obj));
                }
                return string.Format("[{0}] in ({1})", columnName, string.Join(",", list));
            }
            else
                return string.Format("[{0}] = {1}", columnName, new SqlValue(value));
        }

    }
}

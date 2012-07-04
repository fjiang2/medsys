using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Sys.Data
{
    public class ColumnValue
    {
        private DataColumn column;
        private object value;

        public ColumnValue(string columnName, object value)
        {
            if (value != null && value != DBNull.Value)
                this.column = new DataColumn(columnName, value.GetType());
            else
                this.column = new DataColumn(columnName);

            this.value = value;
        }

        public ColumnValue(DataColumn column, object value)
        {
            this.column = column;
            this.value = value;
        }

        public override string ToString()
        {
            return string.Format("[{0}] = {1}", column.ColumnName, new SqlValue(value));
        }

    }
}

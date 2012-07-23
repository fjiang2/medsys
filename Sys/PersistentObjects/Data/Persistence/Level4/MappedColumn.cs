using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public class MappedColumn
    {
        public readonly string ColumnName;
        public readonly string MappedColumnName;

        public MappedColumn(string columnName, string mappedColumnName)
        {
            this.ColumnName = columnName;
            this.MappedColumnName = mappedColumnName;
        }

        public MappedColumn(string columnName)
        {
            this.ColumnName = columnName;
            this.MappedColumnName = columnName;
        }
    }
}

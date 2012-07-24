using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public class MappedColumn
    {
        public readonly string RelationName;
        public readonly string Name;

        public MappedColumn(string columnName, string mappedColumnName)
        {
            this.RelationName = columnName;
            this.Name = mappedColumnName;
        }

        public MappedColumn(string columnName)
        {
            this.RelationName = columnName;
            this.Name = columnName;
        }
    }
}

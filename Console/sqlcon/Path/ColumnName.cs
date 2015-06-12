using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys.Data;

namespace sqlcon
{
    class ColumnPath : IDataPath
    {
        public readonly string Columns;

        public ColumnPath(string columns)
        {
            this.Columns = columns;
        }

        public string FirstColumn
        {
            get { return Columns.Split(',')[0]; }
        }

        public string Path
        {
            get { return this.Columns; }
        }

        public override string ToString()
        {
            return Columns;
        }
    }
}

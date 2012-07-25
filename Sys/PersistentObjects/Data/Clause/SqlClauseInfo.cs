using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public abstract class SqlClauseInfo
    {
        private List<string> columnNames = new List<string>();
        private List<string> parameters = new List<string>();

        public SqlClauseInfo()
        { 
        }

        internal List<string> Columns
        {
            get { return this.columnNames; }
        }

        internal List<string> Parameters
        {
            get { return this.parameters; }
        }

        private static List<string> Merge(List<string> L1, List<string> L2)
        {
            foreach (string name in L2)
            {
                if (!L1.Exists(x => x == name))
                    L1.Add(name);
            }
            
            return L1;
        }

        internal SqlClauseInfo Merge(SqlClauseInfo info)
        {
            Merge(this.columnNames, info.columnNames);
            Merge(this.parameters, info.parameters);

            return this;
        }
    }
}

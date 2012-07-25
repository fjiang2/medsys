using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public abstract class SqlClauseInfo
    {
        //<parameter, column>
        private Dictionary<string, string> parameters = new Dictionary<string,string>();

        public SqlClauseInfo()
        { 
        }

        internal Dictionary<string, string> Parameters
        {
            get { return this.parameters; }
        }

        protected void Add(string parameterName, string columnName)
        {
            if (!this.parameters.ContainsKey(parameterName))
                this.parameters.Add(parameterName, columnName);
        }

        internal SqlClauseInfo Merge(SqlClauseInfo info)
        {
            foreach (KeyValuePair<string, string> kvp in info.parameters)
                 this.Add(kvp.Key, kvp.Value);

            return this;
        }
    }
}

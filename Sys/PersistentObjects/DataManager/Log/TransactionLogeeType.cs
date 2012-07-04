using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.DataManager
{
    public class TransactionLogeeType
    {
        string type;

        public TransactionLogeeType(string type)
        {
            this.type = type;
        }

        public override int GetHashCode()
        {
            return type.GetHashCode();
        }
    }
}

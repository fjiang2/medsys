using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data.Manager
{
    public class TransactionType
    {
        string signature;

        public TransactionType(Type type)
        {
            this.signature = type.FullName;
        }


        public string Signature
        {
            get { return this.signature; }
        }

        public override string ToString()
        {
            return signature;
        }
    }
}

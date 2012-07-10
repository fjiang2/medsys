using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.DataManager
{
    public class Transaction
    {
        int transactionId;

        public Transaction(int transactionId)
        {
            this.transactionId = transactionId;
        }

        public Transaction()
            :this(-1)
        {
        }

        public int Id
        {
            get { return this.transactionId; }
        }


        public static bool operator !(Transaction transaction)
        {
            return transaction.transactionId == -1;
        }

        public override string ToString()
        {
            return transactionId.ToString();
        }
    }
}

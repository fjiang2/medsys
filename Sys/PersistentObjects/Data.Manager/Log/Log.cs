using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data.Manager
{
    public class Log
    {
        private LogTransaction logTransaction = null;
        private TransactionType type;

        public Log(TransactionType type)
        {
            this.type = type;
        }

        /// <summary>
        /// Begin Log Transaction, all DPOs in Form are logged as a Transaction
        /// </summary>
        public LogTransaction BeginLog()
        {
            return this.logTransaction = LogTransaction.BeginTransaction(type);
        }

        public LogTransaction BeginLog(TransactionLogeeType typeName)
        {
            return this.logTransaction = LogTransaction.BeginTransaction(typeName, type);

        }

     

        /// <summary>
        /// Begin log Transaction, and register DPO into Logger
        /// </summary>
        /// <param name="logs"></param>
        public LogTransaction BeginLog(params ILogable[] logs)
        {
            BeginLog();
            AddLog(logs);

            return logTransaction;
        }

        public LogTransaction BeginLog(TransactionLogeeType typeName, params ILogable[] logs)
        {
            BeginLog(typeName);
            AddLog(logs);

            return this.logTransaction;
        }

        public void AddLog(params ILogable[] logs)
        {
            foreach (ILogable log in logs)
                this.logTransaction.Add(log);
        }

        public void RemoveLog(ILogable log)
        {
            this.logTransaction.Remove(log);
        }

        /// <summary>
        /// Close log transaction, it can be closed many times
        /// </summary>
        public void EndLog()
        {
            this.logTransaction.EndTransaction();
        }


        public LogTransaction Transaction
        {
            get { return this.logTransaction; }
        }

        public override string ToString()
        {
            return string.Format("Log: {0}", type.ToString());
        }
    }
}

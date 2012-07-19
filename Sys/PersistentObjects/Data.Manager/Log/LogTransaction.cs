using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.PersistentObjects.DpoClass;

namespace Sys.Data.Manager
{
    public class LogTransaction
    {
        public readonly Transaction transaction = new Transaction();

        private List<ILogable> logList = new List<ILogable>();
        private ITransactionLogee logee;

        private LogTransaction(Transaction transaction, ITransactionLogee logee)
        {
            this.transaction = transaction;
            this.logee = logee;
        }

        public void Add(ILogable log)
        {
            log.AddLog(this);
            this.logList.Add(log);
        }


        public void Remove(ILogable log)
        {
            log.RemoveLog();
            this.logList.Remove(log);
        }


        public void RemoveAll()
        {
            foreach (ILogable log in logList)
                log.RemoveLog();
            
            logList = new List<ILogable>();
        }


        public void EndTransaction()
        {
            bool logged = false;
            foreach (ILogable log in logList)
            {
                if (log.Logged())
                {
                    logged = true;
                    break;
                }
            }

            RemoveAll();

            if (!logged)
            {
                logee.RemoveTransaction(this.transaction);
            }
        }

        /// <summary>
        /// Use Default Transaction Logee
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static LogTransaction BeginTransaction(TransactionType formName)
        {
            ITransactionLogee logee = LogManager.Instance.TransactionLogee();

            Transaction transaction = logee.LogTransaction(formName, Active.Account.UserID);
            return new LogTransaction(transaction, logee);
        }


        public static LogTransaction BeginTransaction(TransactionLogeeType typeName, TransactionType formName)
        {
            ITransactionLogee logee = LogManager.Instance.TransactionLogee(typeName);

            Transaction transaction = logee.LogTransaction(formName, Active.Account.UserID);
            return new LogTransaction(transaction, logee);
        }

    }
}

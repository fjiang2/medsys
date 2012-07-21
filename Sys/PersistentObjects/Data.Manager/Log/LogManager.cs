using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;

namespace Sys.Data.Manager
{
    class LogManager
    {
        static LogManager manager;

        Dictionary<TableName, IRowLogee> rowLogees = new Dictionary<TableName, IRowLogee>();
        Dictionary<TransactionLogeeType, ITransactionLogee> transactionLogees = new Dictionary<TransactionLogeeType, ITransactionLogee>();

        private LogManager()
        { 
        
        }

        public static LogManager Instance
        {
            get
            {
                if (manager == null)
                    manager = new LogManager();

                return manager;
            }
        }

        public IRowLogee RowLogee(TableName tableName)
        {
            if (rowLogees.ContainsKey(tableName))
                return rowLogees[tableName];
            else
                return new DefaultLogee();
        }


        public IRowLogee RowLogee(DPObject dpo)
        {
           return RowLogee(dpo.TableName);
        }


        /// <summary>
        /// Register Logee Implement
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="tableId"></param>
        /// <param name="logee"></param>
        public void Register(TableName tableName, IRowLogee logee)
        {
            if (rowLogees.ContainsKey(tableName))
                rowLogees.Remove(tableName);

            rowLogees.Add(tableName, logee);
        }


        public ITransactionLogee TransactionLogee(TransactionLogeeType transactionType)
        {
            if (transactionLogees.ContainsKey(transactionType))
                return transactionLogees[transactionType];
            else
            {
#if DEBUG
                throw new Sys.JException("Logee type {0} is defined", transactionType);
#else
                return new DefaultLogee();  //use default logee
#endif
            }
        }

        public ITransactionLogee TransactionLogee()
        {
             return new DefaultLogee();
        }


        public void Register(TransactionLogeeType transactionType, ITransactionLogee logee)
        {
            if (transactionLogees.ContainsKey(transactionType))
                transactionLogees.Remove(transactionType);

            transactionLogees.Add(transactionType, logee);
        }


    }
}

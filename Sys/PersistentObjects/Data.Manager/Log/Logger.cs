using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sys.Data;
using Tie;
using Sys.PersistentObjects.DpoClass;

namespace Sys.Data.Manager
{
    class Logger
    {
        private Transaction log_transaction;
        private int log_row_id = -1;


        TableName tableName;
        int tableId;

        int rowID;
        bool logged = false;

        Type dpoType;
        string rowIdColumnName;

        IRowLogee logee;

        public Logger(Transaction transaction, TableName tableName, string rowIdColumnName, int rowID)
        {
            this.log_transaction = transaction;
            this.tableName = tableName;
            this.tableId = this.tableName.Id;
            this.rowID = rowID;

            this.logee = LogManager.Instance.RowLogee(tableName);

            this.rowIdColumnName = rowIdColumnName;
        }

        public Logger(Transaction transaction, DPObject dpo)
        {
            this.log_transaction = transaction;
            this.tableName = dpo.TableName;
            this.tableId = dpo.TableId;
            this.rowID = dpo.RowId;

            this.logee = LogManager.Instance.RowLogee(dpo);

            dpoType = dpo.GetType();
        }
      

      

        public bool Logged
        {
            get
            {
                return this.logged;
            }
        }


        private bool modified = false;
        public void RowChanged(object sender, RowChangedEventArgs e)
        {
            if (e.state == ObjectState.Added || e.state == ObjectState.Deleted || e.state == ObjectState.Modified)
            {

                if (!log_transaction)
                    throw new SysException("TransactionID is not assgined yet.");

                if (this.rowID == 0)
                {
                    if (e.saved)      //log after save with identity value created
                    {
                        if (dpoType != null)
                        {
                            DPObject dpo = (DPObject)Activator.CreateInstance(dpoType, new object[] { e.adapter.Row });
                            this.rowID = dpo.RowId;
                        }
                        else if (this.rowIdColumnName != null)
                        {
                            this.rowID = (int)e.adapter.Row[this.rowIdColumnName];
                        }
                        else
                            throw new SysException("DPO Type is not defined");
                    }
                    else
                        return;
                }

                modified = e.state == ObjectState.Modified;

                if (e.state == ObjectState.Modified || e.state == ObjectState.Added || e.state == ObjectState.Deleted)
                {
                    log_row_id = this.logee.LogRow(log_transaction, this.tableName, this.tableId,  this.rowID, e.state, e.adapter.Row1, e.adapter.Row);

                    logged = log_row_id > 0 ;
                }

           
            }
        }

        public void ValueChanged(object sender, ValueChangedEventArgs e)
        {
    
            if (!modified)      //log UPDATE, does not log INSERT/DELETE here
                return;

            if (log_row_id == -1)
                return;         // throw new ApplicationException("Log Table has not been not ready yet.");


            this.logee.LogColumn(log_row_id, this.tableName, this.tableId, e.columnName, e.originValue, e.value);
        }



        
     
    }
}

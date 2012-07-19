using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sys.Data;
using Tie;
using Sys.PersistentObjects.DpoClass;
using Sys.Data.Manager;

namespace Sys.Data.Manager
{
    class DefaultLogee : IRowLogee, ITransactionLogee
    {
        /// <summary>
        /// Default logee uses 3 tables
        ///    log
        /// </summary>
        public DefaultLogee()
        {
        }

        public virtual Transaction LogTransaction(TransactionType type, int userID)
        {
            logDataSetDpo logDataset = new logDataSetDpo();

            logDataset.form_name = type.Signature;
            logDataset.date = DateTime.Now;
            logDataset.user_id = userID;
            logDataset.machine_name = Const.COMPUTER_NAME; 
            logDataset.Save();

            return new Transaction(logDataset.log_dataset_id);
        }

        public virtual void RemoveTransaction(Transaction transaction)
        {
            logDataSetDpo logDataset = new logDataSetDpo();
            logDataset.SetLocator(new string[]{logDataSetDpo._log_dataset_id});
            logDataset.log_dataset_id = transaction.Id;
            logDataset.Delete();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionID"></param>
        /// <param name="tableName"></param>
        /// <param name="tableId"></param>
        /// <param name="rowID"></param>
        /// <param name="state"></param>
        /// <param name="row1"></param>
        /// <param name="row2"></param>
        /// <returns></returns> -1: not logged, >0: logged
        public virtual int LogRow(Transaction transaction, TableName tableName, int tableId, int rowID, ObjectState state, DataRow row1, DataRow row2)
        {
            logDataTableDpo logTable = new logDataTableDpo();
            
            logTable.log_dataset_id = transaction.Id;
            logTable.table_id = tableId;
            logTable.row_id = rowID;
            logTable.operation = (int)state;

            logTable.table_name = tableName.FullName;
            logTable.action = state.ToString();

            string v1, v2;
            if (Row2Json(state, row1, row2, out v1, out v2))
            {

                logTable.value_from = v1;
                logTable.value_to = v2;

                logTable.Save();

                return logTable.log_table_id;
            }
            else
                return -1;  
        }



        public virtual int LogColumn(int log_table_id, TableName tableName, int tableId, string columnName, object v1, object v2)
        {
            logDataColumnDpo logColumn = new logDataColumnDpo();
            logColumn.log_table_id = log_table_id;
            logColumn.table_name = tableName.FullName;
            logColumn.column_name = columnName;
            logColumn.column_id = DictColumn.GetId(tableId, columnName);

            logColumn.data_type = v2.GetType().FullName;
            logColumn.value_from = v1.ToString();
            logColumn.value_to = v2.ToString();
            logColumn.Save();

            return logColumn.log_column_id;
        }



        protected static bool Row2Json(ObjectState state, DataRow row1, DataRow row2, out string s1, out string s2)
        {
            VAL v1 = new VAL();
            VAL v2 = new VAL();

            if (state == ObjectState.Modified)
            {
                foreach (DataColumn dataColumn in row2.Table.Columns)
                {
                    string x = dataColumn.ColumnName;
                    if (!row1[x].ToString().Equals(row2[x].ToString()))
                    {
                        if (row1[x] != System.DBNull.Value)
                            v1.Add(x, row1[x]);

                        if (row2[x] != System.DBNull.Value)
                            v2.Add(x, row2[x]);
                    }
                }

            }
            else if (state == ObjectState.Added)
            {
                foreach (DataColumn dataColumn in row2.Table.Columns)
                {
                    string x = dataColumn.ColumnName;
                    if (row2[x] != System.DBNull.Value)
                        v2.Add(x, row2[x]);
                }

            }
            else if (state == ObjectState.Deleted)
            {
                foreach (DataColumn dataColumn in row1.Table.Columns)
                {
                    string x = dataColumn.ColumnName;
                    if (row1[x] != System.DBNull.Value)
                        v1.Add(x, row1[x]);
                }

            }

            if (!v1.IsNull || !v2.IsNull)
            {
                s1 = v1.ToJson();
                s2 = v2.ToJson();

                return true;
            }

            s1 = "";
            s2 = "";

            return false;
        }
    }
}

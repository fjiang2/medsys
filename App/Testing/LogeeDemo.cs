using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Foundation.DpoClass;
using Sys.ViewManager.DpoClass;
using Sys.ViewManager.Security;
using Sys.ViewManager.Forms;
using Sys.Data.Log;

namespace App.Testing
{
    class LogeeDemo
    {

        public const string SysLog = "SysLog";
        public static TransactionLogeeType SysLogType = new TransactionLogeeType(SysLog);
        public static void RegisterLogee()
        {
            //register LOG transaction implementation
            SysLogType.Register(new SysLogLogee());

            //register LOG datarow implemention
            typeof(UserDpo).TableName().Register(new UserDpoLogee());

        }


        public void Demo()
        {
            RegisterLogee();
            Log log = new Log(new TransactionType(GetType()));
            
            UserDpo user = new UserDpo("devel");
            user.Plain_Password = "pass";
            user.Password = null;


            log.BeginLog(SysLogType);
            log.AddLog(user);
            user.Save();
            log.EndLog();
        }
    }



    class SysLogLogee : ITransactionLogee
    {
        public SysLogLogee()
        {
        }

        public virtual Transaction LogTransaction(TransactionType type, int userID)
        {
            //sysLOG1Dpo logTransaction = new sysLOG1Dpo();

            //logTransaction.form_name = type.FullName;
            //logTransaction.date = DateTime.Now;
            //logTransaction.user_id = userID;
            //logTransaction.machine_name = System.Windows.Forms.SystemInformation.ComputerName;
            //logTransaction.app_name = (string)Sys.Security.Profile.Instance["ApplicationName"];

            //logTransaction.Save();

            //return new Transaction(logTransaction.transaction_id);
            return new Transaction(0);
        }

        public virtual void RemoveTransaction(Transaction transaction)
        {
            //sysLOG1Dpo logTransaction = new sysLOG1Dpo();
            //logTransaction.transaction_id = transaction.Id;
            //logTransaction.Delete();
        }
    }


    class UserDpoLogee : IRowLogee
    {

        public UserDpoLogee()
        {
        }

        public virtual int LogRow(Transaction transaction, TableName tableName, int tableId, int rowID, ObjectState state, DataRow row1, DataRow row2)
        {
        //    UserLogDpo logRow = new UserLogDpo();

        //    logRow.transaction_id = transaction.Id;
        //    logRow.table_id = tableId;
        //    logRow.row_id = rowID;
        //    logRow.operation = (int)state;
        //    logRow.action = state.ToString();

        //    if (state ==  ObjectState.Modified)
        //    {
        //        foreach (DataColumn dataColumn in row2.Table.Columns)
        //        {
        //            string x = dataColumn.ColumnName;
        //            string v1 = row1[x].ToString().Trim();  //because some columns data type are char(n)
        //            string v2 = row2[x].ToString().Trim();
        //            if (!v1.Equals(v2))
        //                goto L1;
        //        }

        //        return -1;
        //    }

        //L1:
        //    if (state !=  ObjectState.Deleted)
        //        logRow.Fill(row2);

        //    logRow.Save();

        //    return logRow.log_row_id;

            return 0;
        }


        public virtual int LogColumn(int log_row_id, TableName tableName, int tableId, string columnName, object v1, object v2)
        {
            return -1;
        }




    }
}

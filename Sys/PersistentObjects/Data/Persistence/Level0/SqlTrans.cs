using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace Sys.Data
{
   
    public sealed class SqlTrans
    {
        private SqlConnection connection;
        private SqlTransaction sqlTransaction;

        public SqlTrans()
        {
            this.connection = (SqlConnection)DataProviderManager.DefaultProvider.DbConnection;
            this.connection.Open();
            this.sqlTransaction = connection.BeginTransaction();
        }


        
        public void Add(SqlCmd cmd)
        {
            if (cmd.SqlCommand.Connection.State != ConnectionState.Closed)
                cmd.SqlCommand.Connection.Close();


            cmd.SqlCommand.Transaction = sqlTransaction;
            cmd.SqlCommand.Connection = this.connection;
     
        }

        public void Add(PersistentObject dpo)
        {
            dpo.SetTransaction(this);
        }

        public void Add(RowAdapter row)
        {
            row.SetTransaction(this);
        }



        public void Commit()
        {
            try
            {
                sqlTransaction.Commit();
            }
            catch (Exception e)
            {
                try
                {
                    sqlTransaction.Rollback();
                }
                catch (SqlException ex)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        throw new JException("An exception of type " + ex.GetType() + " was encountered while attempting to roll back the transaction.");
                    }
                }

                throw new JException(e.Message);
            }
            finally
            {
                connection.Close();
            }

        }


        public static void DpoExample()
        {
            var transaction = new SqlTrans();
            var dpo1 = new Sys.PersistentObjects.DpoClass.dictDatabaseDpo();
            var dpo2 = new Sys.PersistentObjects.DpoClass.dictDataTableDpo();

            transaction.Add(dpo1);
            transaction.Add(dpo2);

            dpo1.Save();
            dpo2.Insert();

            transaction.Commit();
        }

        public static void SqlCmdExample()
        {
            var transaction = new SqlTrans();
            var cmd1 = new SqlCmd("UPDATE ... ");
            var cmd2 = new SqlCmd("INSERT ...");

            transaction.Add(cmd1);
            transaction.Add(cmd2);

            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            transaction.Commit();
        }
    }
}

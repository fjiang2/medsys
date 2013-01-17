//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using DataProviderHandle = System.Int32;

namespace Sys.Data
{
    public abstract class DbCmd
    {
        protected string script;
        protected DbCommand command;
        protected DbConnection connection;

        private DataProviderConnection providerConnection;

        public DbCmd(DataProvider provider, string script)
        {
            this.providerConnection = DataProviderManager.Instance.GetConnection(provider);
            if (this.providerConnection == null)
                throw new JException("provider connection not registered.");

            this.script = script
                          .Replace("$DB_SYSTEM", Const.DB_SYSTEM)
                          .Replace("$DB_APPLICATION", Const.DB_APPLICATION);

            this.connection= providerConnection.DbConnection;

            if (providerConnection.DbType == DbType.SqlDb)
                this.command = new SqlCommand(this.script, (SqlConnection)connection);
            else
                this.command = new OleDbCommand(this.script, (OleDbConnection)connection);

            if (this.script.Contains(" "))  //Stored Procedure Name does not contain a space letter
                this.command.CommandType = CommandType.Text;
            else
                this.command.CommandType = CommandType.StoredProcedure;

        }

        protected bool SQLDB
        {
            get { return this.providerConnection.DbType == DbType.SqlDb; }
        }

        public virtual void ChangeConnection(DataProviderConnection provider)
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();

            this.providerConnection = provider;
            this.connection = provider.DbConnection;

            if (provider.DbType == DbType.SqlDb)
                this.command.Connection = (SqlConnection)connection;
            else
                this.command.Connection = (OleDbConnection)connection;
        }


      

        public void ChangeDatabase(string database)
        {
            this.connection.ChangeDatabase(database);
        }


        protected virtual void ExceptionHandler(string message)
        {
            if (JException.DefaultExceptionHandler != null)
                JException.DefaultExceptionHandler("SQL Exception", message);
            else
                throw new Exception(message);

            //System.Windows.Forms.MessageBox.Show(message, "SQL Exception", System.Windows.Forms.MessageBoxButtons.OK);
        }


        public DbDataAdapter DbDataAdapter
        {
            get
            {
                if (providerConnection.DbType == DbType.SqlDb)
                    return new SqlDataAdapter();
                else
                    return new OleDbDataAdapter();
            }
        }

        public object ExecuteScalar()
        {

            try
            {
                connection.Open();
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return null;
        }

        public int ExecuteNonQuery()
        {
            int n = 0;
            try
            {
                //
                //Transaction on INSERT/UPDATE/DELETE
                //these commands use ExecuteNonQuery()
                //
                if (command.Transaction == null)
                    connection.Open();

                n = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex.Message);
            }
            finally
            {
                if (command.Transaction == null)
                    connection.Close();
            }

            return n;
        }


        /// <summary>
        /// Get stored procedure's return value
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public object GetReturnValue(string parameterName)
        {
            return command.Parameters[parameterName].Value;
        }



        public abstract DataSet FillDataSet(DataSet dataSet);
        public abstract DataTable FillDataTable(DataSet dataSet, string tableName);
        public abstract DataTable FillDataTable(DataTable table);

        public DataSet FillDataSet()
        {

            DataSet ds = new DataSet();

            if (FillDataSet(ds) == null)
                return null;

            return ds;
        }

        public DataTable FillDataTable()
        {
            DataSet ds = FillDataSet();
            if (ds == null)
                return null;

            if (ds.Tables.Count >= 1)
                return ds.Tables[0];

            return null;
        }

        public DataRow FillDataRow()
        {
            DataTable dt = FillDataTable();
            if (dt == null)
                return null;

            if (dt.Rows.Count >= 1)
                return dt.Rows[0];

            return null;
        }


        public DataTable ReadDataTable()
        {
            try
            {
                connection.Open();
                DbDataReader reader = this.command.ExecuteReader();

                DataTable table = new DataTable();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    DataColumn column = new DataColumn(reader.GetName(i), reader.GetFieldType(i));
                    table.Columns.Add(column);
                }

                try
                {
                    DataRow row;
                    while (reader.Read())
                    {
                        row = table.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader.GetValue(i);
                        }

                        table.Rows.Add(row);
                    }
                }
                finally
                {
                    reader.Close();
                }

                table.AcceptChanges();
                return table;
            }
            catch (Exception ex)
            {
#if DEBUG
                ExceptionHandler(ex.Message + " :: " + command.CommandText);
#else
                ExceptionHandler(ex.Message);
#endif
            }
            finally
            {
                connection.Close();
            }

            return null;
        }

        public override string ToString()
        {
            return this.script;
        }



    }
}

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

        private DataProvider provider;

        public DbCmd(DataProviderHandle handle, string script)
        {
            this.provider = DataProviderManager.GetProvider(handle);
            
            this.script = script
                          .Replace("$DB_SYSTEM", Const.DB_SYSTEM)
                          .Replace("$DB_APPLICATION", Const.DB_APPLICATION);

            this.connection= provider.DbConnection;

            if (provider.DbType == DbType.SqlDb)
                this.command = new SqlCommand(script, (SqlConnection)connection);
            else
                this.command = new OleDbCommand(script, (OleDbConnection)connection);

            if (script.Contains(" "))  //Stored Procedure Name does not contain a space letter
                this.command.CommandType = CommandType.Text;
            else
                this.command.CommandType = CommandType.StoredProcedure;

        }


        public virtual void ChangeConnection(DataProvider provider)
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();

            this.provider = provider;
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
                if (provider.DbType == DbType.SqlDb)
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

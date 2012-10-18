using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Sys.Data
{
    public class OleDbCmd
    {
        string script;

        protected OleDbCommand command;

        public OleDbCmd(string script, params object[] args)
        {
            this.script = string.Format(script, args)
                        .Replace("$DB_SYSTEM", Const.DB_SYSTEM)
                        .Replace("$DB_APPLICATION", Const.DB_APPLICATION);


            OleDbConnection connection = new OleDbConnection(Const.CONNECTION_STRING);
            this.command = new OleDbCommand(this.script, connection);

            if (this.script.Contains(" "))  //Stored Procedure Name does not contain a space letter
                command.CommandType = CommandType.Text;
            else
                command.CommandType = CommandType.StoredProcedure;

        }

        public OleDbCmd(ISqlClause sql)
            : this(sql.Clause)
        { 
        
        }

        protected OleDbConnection Connection
        {
            get {  return this.command.Connection;  }
        }

        public override string ToString()
        {
            return this.script;
        }

        public void ChangeConnection(string connectionString)
        {
            if (this.Connection.State != ConnectionState.Closed)
                this.Connection.Close();

            this.command.Connection = new OleDbConnection(connectionString);
        }


        public void ChangeDatabase(string database)
        {
            this.Connection.ChangeDatabase(database);
        }

        protected virtual void ExceptionHandler(string message)
        {
            if (JException.DefaultExceptionHandler != null)
                JException.DefaultExceptionHandler("SQL Exception", message);
            else
                throw new Exception(message);

            //System.Windows.Forms.MessageBox.Show(message, "SQL Exception", System.Windows.Forms.MessageBoxButtons.OK);
        }

        public OleDbCmd AddParameter(String parameterName, OleDbType dbType)
        {
            OleDbParameter param = new OleDbParameter(parameterName, dbType);
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);
            return this;
        }

        public OleDbCmd AddParameter(String parameterName, int size)
        {
            OleDbParameter param = new OleDbParameter(parameterName, OleDbType.WChar, size);
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);
            return this;
        }

        public OleDbCmd AddParameter(String parameterName, Object value)
        {
            OleDbType dbType = OleDbType.WChar;
            if (value is Int32)
                dbType = OleDbType.Integer;
            else if (value is DateTime)
                dbType = OleDbType.Date;
            else if (value is Double)
                dbType = OleDbType.Double;
            else if (value is Decimal)
                dbType = OleDbType.Decimal;
            else if (value is Boolean)
                dbType = OleDbType.Boolean;
            else if (value is string && ((string)value).Length > 4000 )
                dbType = OleDbType.BSTR;

            OleDbParameter param = new OleDbParameter(parameterName, dbType);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            command.Parameters.Add(param);
            return this;
        }

        public OleDbCmd AddParameter(String parameterName, OleDbType dbType, object value)
        {
            OleDbParameter param = new OleDbParameter(parameterName, dbType);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            command.Parameters.Add(param);
            return this;
        }

        public OleDbCmd AddParameter(String parameterName, int size, object value)
        {
            OleDbParameter param = new OleDbParameter(parameterName, OleDbType.WChar, size);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            command.Parameters.Add(param);
            return this;
        }


        public OleDbCmd AddParameter(String parameterName, OleDbType dbType, int size)
        {
            OleDbParameter param = new OleDbParameter(parameterName, dbType, size);
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);
            return this;
        }

        public OleDbCmd AddParameter(String parameterName, OleDbType dbType, int size, object value)
        {
            OleDbParameter param = new OleDbParameter(parameterName, dbType, size);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            command.Parameters.Add(param);
            return this;
        }


        //native in .net 3.0+
        public OleDbCmd SetParameter(String parameterName, Object value)
        {
            command.Parameters[parameterName].Value = value;
            return this;
        }

        public OleDbCommand Command
        {
            get { return command; }
        }

        public OleDbConnection OleDbConnection
        {
            get { return Connection; }
        }


        public DataTable ReadDataTable()
        {
            try
            {
                Connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                
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
                Connection.Close();
            }

            return null;
        }

        public object ExecuteScalar()
        {

            try
            {
                 Connection.Open();

                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex.Message);
            }
            finally
            {
                Connection.Close();
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
				    Connection.Open();

				n = command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
                ExceptionHandler(ex.Message);
			}
			finally
			{
                if (command.Transaction == null)
				    Connection.Close();
			}

            return n;
		}
		 
        public DataSet FillDataSet()
        {

            DataSet ds = new DataSet();
            
            if(FillDataSet(ds) == null)
                return null;
            
            return ds;
        }

        public DataSet FillDataSet(DataSet ds)
        {
            try
            {
                Connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                return ds;
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
                Connection.Close();
            }

            return null;
        }


        public DataTable FillDataTable(DataSet ds, string tableName)
        {
            try
            {
                Connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(ds, tableName);
             
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return ds.Tables[tableName];
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

        public DataTable FillDataTable(DataTable dt)
        {
            try
            {
                Connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

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

        /// <summary>
        /// Get stored procedure's return value
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public object GetReturnValue(string parameterName)
        {
             return command.Parameters[parameterName].Value;
        }


        //--------------------------------------------------------------------------------------
        public static object ExecuteScalar(string script, params object[] args)
        {
            OleDbCmd cmd = new OleDbCmd(script, args);
            return cmd.ExecuteScalar();
        }

       
        public static int ExecuteNonQuery(string script, params object[] args)
        {
            OleDbCmd cmd = new OleDbCmd(script, args);
            return cmd.ExecuteNonQuery();
        }

        public static DataSet FillDataSet(string script, params object[] args)
        {
            OleDbCmd cmd = new OleDbCmd(script, args);
            return cmd.FillDataSet();
        }

        public static DataTable FillDataTable(string script, params object[] args)
        {
            OleDbCmd cmd = new OleDbCmd(script, args);
            return cmd.FillDataTable();
        }

        

        public static DataRow FillDataRow(string script, params object[] args)
        {
            OleDbCmd cmd = new OleDbCmd(script, args);
            return cmd.FillDataRow();
        }

     
//------------------------------------------------------------------------------------------------------

     

   
     


       
    }
}


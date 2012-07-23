using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sys.Data
{
    public class SqlCmd
    {
        string script;
       
        protected SqlCommand sqlCommand;

        public SqlCmd(string script, params object[] args)
        {
            this.script = string.Format(script, args)
                        .Replace("$DB_SYSTEM", Const.DB_SYSTEM)
                        .Replace("$DB_APPLICATION", Const.DB_APPLICATION);


            SqlConnection sqlConnection = new SqlConnection(Const.CONNECTION_STRING);
            this.sqlCommand = new SqlCommand(this.script, sqlConnection);

            if (this.script.Contains(" "))  //Stored Procedure Name does not contain a space letter
                sqlCommand.CommandType = CommandType.Text;
            else
                sqlCommand.CommandType = CommandType.StoredProcedure;

        }

        public SqlCmd(ISqlScript sql)
            : this(sql.Script)
        { 
        
        }

        protected SqlConnection sqlConnection
        {
            get {  return this.sqlCommand.Connection;  }
        }

        public override string ToString()
        {
            return this.script;
        }

        public void ChangeConnection(string serverName, bool integratedSecurity, string initialCatalog, string userName, string password)
        {
            string security = "integrated security=SSPI;";
            if(!integratedSecurity)
                security = string.Format("user id= {0}; password={1};", userName, password);

            string connectionString = string.Format("data source={0}; initial catalog={1}; {2} pooling=false", serverName, initialCatalog, security);

            ChangeConnection(connectionString);
        }

        public void ChangeConnection(string userName, string password)
        {
            string serverName = "";
            string initialCatalog = "";
            string[] L1 = Const.CONNECTION_STRING.Split(new char[] { ';' });
            foreach (string s1 in L1)
            {
                string[] L2 = s1.Split(new char[] { '=' });
                if (L2[0] == "data source")
                    serverName = L2[1];
                else if (L2[0] == "initial catalog")
                    initialCatalog = L2[1];

            }

            string connectionString = string.Format("data source={0};initial catalog={1};user id={2};password={3};persist security info=True;packet size=4096", 
                serverName,
                initialCatalog, 
                userName, 
                password);

            ChangeConnection(connectionString);
        }

        public void ChangeConnection(string connectionString)
        {
            if (this.sqlConnection.State != ConnectionState.Closed)
                this.sqlConnection.Close();

            this.sqlCommand.Connection = new SqlConnection(connectionString);
        }


        public void ChangeDatabase(string database)
        {
            this.sqlConnection.ChangeDatabase(database);
        }

        protected virtual void ExceptionHandler(string message)
        {
            if (JException.DefaultExceptionHandler != null)
                JException.DefaultExceptionHandler("SQL Exception", message);
            else
                throw new Exception(message);

            //System.Windows.Forms.MessageBox.Show(message, "SQL Exception", System.Windows.Forms.MessageBoxButtons.OK);
        }

        public SqlCmd AddParameter(String parameterName, SqlDbType dbType)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(param);
            return this;
        }

        public SqlCmd AddParameter(String parameterName, int size)
        {
            SqlParameter param = new SqlParameter(parameterName, SqlDbType.NVarChar, size);
            param.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(param);
            return this;
        }

        public SqlCmd AddParameter(String parameterName, Object value)
        {
            SqlDbType dbType = SqlDbType.NVarChar;
            if (value is Int32)
                dbType = SqlDbType.Int;
            else if (value is DateTime)
                dbType = SqlDbType.DateTime;
            else if (value is Double)
                dbType = SqlDbType.Float;
            else if (value is Decimal)
                dbType = SqlDbType.Decimal;
            else if (value is Boolean)
                dbType = SqlDbType.Bit;
            else if (value is string && ((string)value).Length > 4000 )
                dbType = SqlDbType.NText;

            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(param);
            return this;
        }

        public SqlCmd AddParameter(String parameterName, SqlDbType dbType, object value)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(param);
            return this;
        }

        public SqlCmd AddParameter(String parameterName, int size, object value)
        {
            SqlParameter param = new SqlParameter(parameterName, SqlDbType.NVarChar, size);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(param);
            return this;
        }


        public SqlCmd AddParameter(String parameterName, SqlDbType dbType, int size)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType, size);
            param.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(param);
            return this;
        }

        public SqlCmd AddParameter(String parameterName, SqlDbType dbType, int size, object value)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType, size);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            sqlCommand.Parameters.Add(param);
            return this;
        }


        //native in .net 3.0+
        public SqlCmd SetParameter(String parameterName, Object value)
        {
            sqlCommand.Parameters[parameterName].Value = value;
            return this;
        }

        public SqlCommand SqlCommand
        {
            get { return sqlCommand; }
        }

        public SqlConnection SqlConnection
        {
            get { return sqlConnection; }
        }


        public DataTable ReadDataTable()
        {
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                
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
                ExceptionHandler(ex.Message + " :: " + sqlCommand.CommandText);
#else
                ExceptionHandler(ex.Message);
#endif
            }
            finally
            {
                sqlConnection.Close();
            }

            return null;
        }

        public object ExecuteScalar()
        {

            try
            {
                 sqlConnection.Open();

                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
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
                if (sqlCommand.Transaction == null)
				    sqlConnection.Open();

				n = sqlCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
                ExceptionHandler(ex.Message);
			}
			finally
			{
                if (sqlCommand.Transaction == null)
				    sqlConnection.Close();
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
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = sqlCommand;
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
#if DEBUG
                ExceptionHandler(ex.Message + " :: " + sqlCommand.CommandText);
#else
                ExceptionHandler(ex.Message);
#endif
            }
            finally
            {
                sqlConnection.Close();
            }

            return null;
        }


        public DataTable FillDataTable(DataSet ds, string tableName)
        {
            try
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = sqlCommand;
                adapter.Fill(ds, tableName);
             
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
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
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = sqlCommand;
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
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
             return sqlCommand.Parameters[parameterName].Value;
        }


        //--------------------------------------------------------------------------------------
        public static object ExecuteScalar(string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(script, args);
            return cmd.ExecuteScalar();
        }

       
        public static int ExecuteNonQuery(string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(script, args);
            return cmd.ExecuteNonQuery();
        }

        public static DataSet FillDataSet(string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(script, args);
            return cmd.FillDataSet();
        }

        public static DataTable FillDataTable(string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(script, args);
            return cmd.FillDataTable();
        }

        

        public static DataRow FillDataRow(string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(script, args);
            return cmd.FillDataRow();
        }

     
//------------------------------------------------------------------------------------------------------

     

   
     


       
    }
}


using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Sys.Data
{
    public class OleDbCmd : DbCmd
    {
        protected OleDbCmd(string script, string connectionString)
            :base(script)
        {
            this.connection = new OleDbConnection(connectionString);
            this.command = new OleDbCommand(this.script, (OleDbConnection)connection);

            if (this.script.Contains(" "))  //Stored Procedure Name does not contain a space letter
                command.CommandType = CommandType.Text;
            else
                command.CommandType = CommandType.StoredProcedure;

        
        }

        public OleDbCmd(string script)
            :this(script, Const.CONNECTION_STRING)
        {
        }

        public OleDbCmd(ISqlClause sql)
            : this(sql.Clause)
        { 
        
        }


        public void ChangeConnection(string connectionString)
        {
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();

            this.command.Connection = new OleDbConnection(connectionString);
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
            get { return (OleDbCommand)command; }
        }


     

       
     

        public override DataSet FillDataSet(DataSet ds)
        {
            try
            {
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = this.Command;
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
                connection.Close();
            }

            return null;
        }


        public DataTable FillDataTable(DataSet ds, string tableName)
        {
            try
            {
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = this.Command;
                adapter.Fill(ds, tableName);
             
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return ds.Tables[tableName];
        }

     

        public DataTable FillDataTable(DataTable dt)
        {
            try
            {
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = this.Command;
                adapter.Fill(dt);
                return dt;
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

      

        //--------------------------------------------------------------------------------------
        public static object ExecuteScalar(string script, params object[] args)
        {
            OleDbCmd cmd = new OleDbCmd(string.Format(script, args));
            return cmd.ExecuteScalar();
        }

       
        public static int ExecuteNonQuery(string script, params object[] args)
        {
            OleDbCmd cmd = new OleDbCmd(string.Format(script, args));
            return cmd.ExecuteNonQuery();
        }

        public static DataSet FillDataSet(string script, params object[] args)
        {
            OleDbCmd cmd = new OleDbCmd(string.Format(script, args));
            return cmd.FillDataSet();
        }

        public static DataTable FillDataTable(string script, params object[] args)
        {
            OleDbCmd cmd = new OleDbCmd(string.Format(script, args));
            return cmd.FillDataTable();
        }

        

        public static DataRow FillDataRow(string script, params object[] args)
        {
            OleDbCmd cmd = new OleDbCmd(string.Format(script, args));
            return cmd.FillDataRow();
        }

     
//------------------------------------------------------------------------------------------------------

     

   
     


       
    }
}


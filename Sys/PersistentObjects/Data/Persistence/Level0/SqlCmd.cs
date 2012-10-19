using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Sys.Data
{
    public class SqlCmd : DbCmd
    {

        protected SqlCmd(string script, string connectionString)
            :base(script)
        {
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand(this.script, (SqlConnection)connection);

            if (this.script.Contains(" "))  //Stored Procedure Name does not contain a space letter
                command.CommandType = CommandType.Text;
            else
                command.CommandType = CommandType.StoredProcedure;

        
        }

        public SqlCmd(string script)
            : this(script, Const.CONNECTION_STRING)
        {
        }

        public SqlCmd(ISqlClause sql)
            : this(sql.Clause)
        { 
        
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
            if (this.connection.State != ConnectionState.Closed)
                this.connection.Close();

            this.command.Connection = new SqlConnection(connectionString);
        }


      

        //public SqlCmd AddParameter(String parameterName, SqlDbType dbType)
        //{
        //    SqlParameter param = new SqlParameter(parameterName, dbType);
        //    param.Direction = ParameterDirection.Output;
        //    command.Parameters.Add(param);
        //    return this;
        //}

        //public SqlCmd AddParameter(String parameterName, int size)
        //{
        //    SqlParameter param = new SqlParameter(parameterName, SqlDbType.NVarChar, size);
        //    param.Direction = ParameterDirection.Output;
        //    command.Parameters.Add(param);
        //    return this;
        //}

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
            command.Parameters.Add(param);
            return this;
        }

        //public SqlCmd AddParameter(String parameterName, SqlDbType dbType, object value)
        //{
        //    SqlParameter param = new SqlParameter(parameterName, dbType);
        //    param.Value = value;
        //    param.Direction = ParameterDirection.Input;
        //    command.Parameters.Add(param);
        //    return this;
        //}

        public SqlCmd AddParameter(String parameterName, int size, object value)
        {
            SqlParameter param = new SqlParameter(parameterName, SqlDbType.NVarChar, size);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            command.Parameters.Add(param);
            return this;
        }


        //public SqlCmd AddParameter(String parameterName, SqlDbType dbType, int size)
        //{
        //    SqlParameter param = new SqlParameter(parameterName, dbType, size);
        //    param.Direction = ParameterDirection.Output;
        //    command.Parameters.Add(param);
        //    return this;
        //}

        //public SqlCmd AddParameter(String parameterName, SqlDbType dbType, int size, object value)
        //{
        //    SqlParameter param = new SqlParameter(parameterName, dbType, size);
        //    param.Value = value;
        //    param.Direction = ParameterDirection.Input;
        //    command.Parameters.Add(param);
        //    return this;
        //}


        //native in .net 3.0+
        public SqlCmd SetParameter(String parameterName, Object value)
        {
            command.Parameters[parameterName].Value = value;
            return this;
        }

        public SqlCommand Command
        {
            get { return (SqlCommand)command; }
        }

      

      


     

        public override DataSet FillDataSet(DataSet ds)
        {
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
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
                SqlDataAdapter adapter = new SqlDataAdapter();
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
                SqlDataAdapter adapter = new SqlDataAdapter();
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
            SqlCmd cmd = new SqlCmd(string.Format(script, args));
            return cmd.ExecuteScalar();
        }

       
        public static int ExecuteNonQuery(string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(string.Format(script, args));
            return cmd.ExecuteNonQuery();
        }

        public static DataSet FillDataSet(string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(string.Format(script, args));
            return cmd.FillDataSet();
        }

        public static DataTable FillDataTable(string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(string.Format(script, args));
            return cmd.FillDataTable();
        }

        

        public static DataRow FillDataRow(string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(string.Format(script, args));
            return cmd.FillDataRow();
        }

     
//------------------------------------------------------------------------------------------------------

     

   
     


       
    }
}


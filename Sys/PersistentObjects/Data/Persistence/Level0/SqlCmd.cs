using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace Sys.Data
{
    public class SqlCmd : DbCmd
    {

        public SqlCmd(DataProviderHandle handle, string script)
            : base(handle, script)
        {
        }

        public SqlCmd(string script)
            : this(DataProviderHandle.DefaultProviderHandle, script)
        {
        }

        public SqlCmd(ISqlClause sql)
            : this(sql.Clause)
        { 
        
        }


        public void ChangeConnection(string userName, string password)
        {
            string serverName = "";
            string initialCatalog = "";
            string[] L1 = connection.ConnectionString.Split(new char[] { ';' });
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

            ChangeConnection(new DataProvider(serverName, DataProviderType.SqlServer, connectionString));
        }

  

        public SqlParameter AddParameter(string parameterName, SqlDbType dbType)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);
            return param;
        }

        public OleDbParameter AddParameter(string parameterName, OleDbType dbType)
        {
            OleDbParameter param = new OleDbParameter(parameterName, dbType);
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);
            return param;
        }


        public DbParameter AddParameter(string parameterName, object value)
        {
            if (SQLDB)
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
                else if (value is string && ((string)value).Length > 4000)
                    dbType = SqlDbType.NText;

                SqlParameter param = new SqlParameter(parameterName, dbType);
                param.Value = value;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);
                return param;
            }
            else
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
                else if (value is string && ((string)value).Length > 4000)
                    dbType = OleDbType.BSTR;

                OleDbParameter param = new OleDbParameter(parameterName, dbType);
                param.Value = value;
                param.Direction = ParameterDirection.Input;
                command.Parameters.Add(param);
                return param;

            }
        }


        public SqlCommand SqlCommand
        {
            get { return (SqlCommand)command; }
        }

        public OleDbCommand OleDbCommand
        {
            get { return (OleDbCommand)command; }
        }

    
        public override DataSet FillDataSet(DataSet dataSet)
        {
            try
            {
                connection.Open();
                if (SQLDB)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = this.SqlCommand;
                    adapter.Fill(dataSet);
                }
                else
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = this.OleDbCommand;
                    adapter.Fill(dataSet);
                }
                return dataSet;
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


        public override DataTable FillDataTable(DataSet dataSet, string tableName)
        {
            try
            {
                connection.Open();
                if (SQLDB)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = this.SqlCommand;
                    adapter.Fill(dataSet, tableName);
                }
                else
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = this.OleDbCommand;
                    adapter.Fill(dataSet, tableName);
                }
             
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dataSet.Tables[tableName];
        }



        public override DataTable FillDataTable(DataTable table)
        {
            try
            {
                connection.Open();
                if (SQLDB)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = this.SqlCommand;
                    adapter.Fill(table);
                }
                else
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = this.OleDbCommand;
                    adapter.Fill(table);
                }
                return table;
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

       
    }
}


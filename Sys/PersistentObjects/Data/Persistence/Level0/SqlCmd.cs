using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataProviderHandle = System.Int32;

namespace Sys.Data
{
    public class SqlCmd : DbCmd
    {

        public SqlCmd(DataProviderHandle handle, string script)
            : base(handle, script)
        {
        }

        public SqlCmd(string script)
            : this(DataProviderManager.DEFAULT_PROVIDER, script)
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

            ChangeConnection(new DataProvider(DataProviderType.SqlServer, connectionString));
        }

  

        public SqlParameter AddParameter(string parameterName, SqlDbType dbType)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);
            return param;
        }

        public SqlParameter AddParameter(string parameterName, object value)
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
            return param;
        }


        public SqlCommand Command
        {
            get { return (SqlCommand)command; }
        }

    
        public override DataSet FillDataSet(DataSet dataSet)
        {
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = this.Command;
                adapter.Fill(dataSet);
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
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = this.Command;
                adapter.Fill(dataSet, tableName);
             
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
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = this.Command;
                adapter.Fill(table);
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


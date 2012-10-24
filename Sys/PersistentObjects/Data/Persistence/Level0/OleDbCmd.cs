using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Sys.Data
{
    public class OleDbCmd : DbCmd
    {
        public OleDbCmd(DataProvider provider, string script)
            : base(provider,script)
        {
        }

        public OleDbCmd(string script)
            : this(DataProviderManager.ActiveProvider, script)
        {
        }

        public OleDbCmd(ISqlClause sql)
            : this(sql.Clause)
        { 
        
        }


        public override void ChangeConnection(string connectionString)
        {
            base.ChangeConnection(connectionString);
            this.connection = new OleDbConnection(connectionString);
            this.command.Connection = (OleDbConnection)connection;
        }




        public OleDbParameter AddParameter(string parameterName, OleDbType dbType)
        {
            OleDbParameter param = new OleDbParameter(parameterName, dbType);
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);
            return param;
        }



        public OleDbParameter AddParameter(string parameterName, object value)
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
            return param;
        }

        public OleDbCommand Command
        {
            get { return (OleDbCommand)command; }
        }


        public override DataSet FillDataSet(DataSet dataSet)
        {
            try
            {
                connection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
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
                OleDbDataAdapter adapter = new OleDbDataAdapter();
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
                OleDbDataAdapter adapter = new OleDbDataAdapter();
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


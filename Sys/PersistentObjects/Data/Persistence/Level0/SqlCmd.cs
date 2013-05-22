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
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.SqlServerCe;
using System.Data;

namespace Sys.Data
{
    public class SqlCmd : DbCmd
    {

        public SqlCmd(DataProvider provider, string script)
            : base(provider, script)
        {
        }

        public SqlCmd(string script)
            : this(DataProvider.DefaultProvider, script)
        {
        }

        public SqlCmd(ISqlClause sql)
            : this(sql.Provider, sql.Clause)
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

            ChangeConnection(new DataProviderConnection(serverName, DataProviderType.SqlServer, connectionString));
        }

  

     

        public DbParameter AddParameter(string parameterName, object value)
        {
            DbParameter param = dbProvider.AddParameter(parameterName, value);
            command.Parameters.Add(param);
            return param;
        }


        public SqlCommand SqlCommand
        {
            get { return (SqlCommand)command; }
        }

     
    
        public override DataSet FillDataSet(DataSet dataSet)
        {
            try
            {
                connection.Open();
                dbProvider.FillDataSet(dataSet);
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
                dbProvider.FillDataTable(dataSet, tableName);
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
                dbProvider.FillDataTable(table);
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
        public static object ExecuteScalar(DataProvider provider, string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(provider, string.Format(script, args));
            return cmd.ExecuteScalar();
        }

        public static int ExecuteNonQuery(DataProvider provider, string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(provider, string.Format(script, args));
            return cmd.ExecuteNonQuery();
        }

        public static DataTable FillDataTable(string script, params object[] args)
        {
            return FillDataTable(DataProviderManager.DefaultProvider, script, args);
        }

        public static DataTable FillDataTable<T>(string script, params object[] args) where T : class,  IDPObject, new()
        {
            TableName tableName = typeof(T).TableName();
            return FillDataTable(tableName.Provider, script, args);
        }

        public static DataTable FillDataTable(DataProvider provider, string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(provider, string.Format(script, args));
            return cmd.FillDataTable();
        }

        public static DataRow FillDataRow(DataProvider provider, string script, params object[] args)
        {
            SqlCmd cmd = new SqlCmd(provider, string.Format(script, args));
            return cmd.FillDataRow();
        }


      


        /// <summary>
        /// Delete records
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        public static void Delete<T>(SqlExpr where) where T : class,  IDPObject, new()
        {
            TableName tableName = typeof(T).TableName();
            SqlCmd.ExecuteScalar(tableName.Provider,
                    "DELETE FROM {0} WHERE {1}",
                    tableName.FullName,
                    where);
        }
    }
}


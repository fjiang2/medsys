﻿//--------------------------------------------------------------------------------------------------//
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
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SqlClient;

namespace Sys.Data
{
    public class SqlServer
    {
        private const int SQL_NEED_DATA = 99;
        private const int SQL_SUCCESS = 0;

        [DllImport("odbc32.dll", SetLastError = true)]
        private static extern short SQLAllocConnect(int hEnv, ref int phdbc);

        [DllImport("odbc32.dll", SetLastError = true)]
        private static extern short SQLAllocEnv(ref int phenv);

        [DllImport("odbc32.dll", SetLastError = true)]
        private static extern short SQLBrowseConnect(int hdbc, string inConnectionString, short stringLength1, StringBuilder outConnectionString, short stringLength2, ref short stringLengt2hPtr);

        [DllImport("odbc32.dll", SetLastError = true)]
        private static extern short SQLDisconnect(int hdbc);

        [DllImport("odbc32.dll", SetLastError = true)]
        private static extern short SQLFreeEnv(int henv);

        [DllImport("odbc32.dll", SetLastError = true)]
        private static extern short SQLFreeConnect(int hdbc);

        public static string[] GetAvailableServers()
        {
            string[] servers = null;
            short rc;
            int henv = 0;
            int hdbc = 0;


            SQLAllocEnv(ref henv);
            SQLAllocConnect(henv, ref hdbc);
            string connectionString = "DRIVER=SQL Server";

            //10k should be way enough
            StringBuilder outString = new StringBuilder(10000);

            short realLength = 0;

            rc = SQLBrowseConnect(hdbc, connectionString, (short)connectionString.Length, outString, (short)(outString.Capacity + 1), ref realLength);

            if (rc == SQL_SUCCESS || rc == SQL_NEED_DATA)
            {

                string serverString = outString.ToString();
                int i = serverString.ToLower().IndexOf("server={") + 8;
                int pos = serverString.IndexOf('}', i);
                serverString = serverString.Substring(i, pos - i);
                servers = serverString.Split(',');
            }

            SQLDisconnect(hdbc);
            SQLFreeConnect(hdbc);
            SQLFreeEnv(henv);


            return servers;
        }

        public static string[] GetDatabases(string serverName, bool integratedSecurity, string userName, string password)
        {
            string connectionString = "initial catalog=master; Data Source=" + serverName + ";" + (integratedSecurity ? "integrated security=SSPI;" : "user id=" + userName + "; password=" + password + ";") + "pooling=false";

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT name FROM dbo.sysdatabases ORDER BY name", connectionString);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            int j = dataTable.Rows.Count;

            string[] databases = new string[j];

            for (int i = 0; i < j; i++)
            {
                databases[i] = (string)dataTable.Rows[i]["name"];
            }

            dataTable.Dispose();
            adapter.Dispose();

            return databases;

        }

        public static string[] GetCollations(string serverName, bool integratedSecurity, string userName, string password)
        {
            string[] collations = null;
            try
            {
                string connectionString = "initial catalog=master; Data Source=" + serverName + ";" + (integratedSecurity ? "integrated security=SSPI;" : "user id=" + userName + "; password=" + password + ";") + "pooling=false";

                using (SqlDataAdapter adapter = new SqlDataAdapter("select name From ::fn_helpcollations() order by name", connectionString))
                {

                    using (DataTable dataTable = new DataTable())
                    {
                        adapter.Fill(dataTable);
                        int j = dataTable.Rows.Count;
                        collations = new string[j];

                        for (int i = 0; i < j; i++)
                        {
                            collations[i] = (string)dataTable.Rows[i]["name"];
                        }
                    }

                }
            }
            catch
            {

            }
            return collations;


        }


        public static bool IsGoodConnectionString()
        {
            SqlConnection conn = (SqlConnection)DataProviderManager.DefaultConnection.NewDbConnection;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(name) FROM sys.tables", conn);
                cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }


        #region Register SQL SERVER

        public static DataProvider Register(string connectionString)
        {
            const string SERVER = "data source";
            string server = connectionString.Split(new char[] { ';' }).Where(segment => segment.Trim().StartsWith(SERVER)).First();
            string serverName = server.Replace(SERVER, "").Replace("=", "").Trim();


            return DataProviderManager.Register(serverName, DataProviderType.SqlServer, connectionString);
        }


        private static DataProvider Register(string serverName, bool integratedSecurity, string database, string userName, string password)
        {
            string security = "integrated security=SSPI;";
            if (!integratedSecurity)
                security = string.Format("user id= {0}; password={1};", userName, password);

            string connectionString = string.Format("data source={0}; initial catalog={1}; {2} pooling=false", serverName, database, security);

            return DataProviderManager.Register(serverName, DataProviderType.SqlServer, connectionString);
        }

        public static DataProvider Register(string serverName, string database, string userName, string password)
        {
            return Register(serverName, false, database, userName, password);
        }

        public static DataProvider Register(string serverName, string database)
        {
            return Register(serverName, true, database, null, null);
        }

        #endregion

    }
}

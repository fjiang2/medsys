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
using System.Linq;
using System.Text;
using System.Data;


namespace Sys.Data
{
    public static class MetaDatabase
    {

        public static bool DatabaseExists(this DatabaseName databaseName)
        {
            try
            {
                return SqlCmd.FillDataRow(databaseName.Provider, "SELECT * FROM sys.databases WHERE name = '{0}'", databaseName.Name) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void CreateDatabase(this DatabaseName databaseName)
        {
            SqlCmd.ExecuteNonQuery(databaseName.Provider, "CREATE DATABASE {0}", databaseName.Name);
        }

        public static bool TableExists(this TableName tname)
        {
            try
            {
                if (!DatabaseExists(tname.DatabaseName))
                    return false;

                return SqlCmd.FillDataRow(tname.Provider, "USE [{0}] ; SELECT * FROM sys.Tables WHERE Name='{1}'", tname.DatabaseName.Name, tname.Name) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static string CurrentDatabaseName(DataProvider provider)
        {
            return (string)SqlCmd.ExecuteScalar(provider, "SELECT DB_NAME()");
        }

        public static DateTime ServerTime
        {
            get
            {
                return (DateTime)SqlCmd.ExecuteScalar(DataProviderManager.DefaultProvider,  "SELECT GETDATE()");
            }
        }


        public static string[] GetDatabaseNames()
        {
             return GetDatabaseNames(DataProvider.DefaultProvider);
        }

        public static string[] GetDatabaseNames(DataProvider handle)
        {
            return SqlCmd.FillDataTable(handle, "SELECT name FROM sys.databases ORDER BY Name").ToArray<string>("name");
        }

        public static string[] GetTableNames(DatabaseName databaseName)
        {
            DataTable dt = SqlCmd.FillDataTable(databaseName.Provider, "USE [{0}] ; SELECT Name FROM sys.Tables ORDER BY Name", databaseName.Name);
            return dt.ToArray<string>("name");
        }
    }
}

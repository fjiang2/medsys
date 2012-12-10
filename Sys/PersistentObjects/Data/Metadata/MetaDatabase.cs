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

        public static void CreateDatabase(this string databaseName)
        {
            SqlCmd.ExecuteNonQuery("CREATE DATABASE {0}", databaseName);
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


        public static string CurrentDatabaseName
        {
            get
            {
                return (string)SqlCmd.ExecuteScalar("SELECT DB_NAME()");
            }
        }

        public static DateTime ServerTime
        {
            get
            {
                return (DateTime)SqlCmd.ExecuteScalar("SELECT GETDATE()");
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

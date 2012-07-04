using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Sys.Data
{
    public static class MetaDatabase
    {

        public static bool DatabaseExists(this string databaseName)
        {
            try
            {
                return SqlCmd.FillDataRow("SELECT * FROM sys.databases WHERE name = '{0}'", databaseName) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool TableExists(this TableName tname)
        {
            try
            {
                if (!DatabaseExists(tname.DatabaseName))
                    return false;

                return SqlCmd.FillDataRow("USE {0} ; SELECT * FROM sys.Tables WHERE Name='{1}'", tname.DatabaseName, tname.Name) != null;
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
             return "SELECT name FROM sys.databases ORDER BY Name".FillDataTable().GetArray<string>("name");
        }


        public static string[] GetTableNames(string databaseName)
        {
            DataTable dt = SqlCmd.FillDataTable("USE {0} ; SELECT Name FROM sys.Tables ORDER BY Name", databaseName);
            return dt.GetArray<string>("name");
        }
    }
}

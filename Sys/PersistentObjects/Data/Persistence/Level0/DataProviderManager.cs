using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using DataProviderHandle = System.Int32;

namespace Sys.Data
{
    
    public class DataProviderManager
    {
        private static DataProviderManager instance = null;

        Dictionary<DataProviderHandle, DataProvider> providers = new Dictionary<DataProviderHandle, DataProvider>();

        private DataProviderManager()
        { 
        }

        private static DataProviderManager Instance
        {
            get
            {
                if (DataProviderManager.instance == null)
                    DataProviderManager.instance = new DataProviderManager();
                
                return DataProviderManager.instance;
            }

        }

        private DataProvider Add(DataProviderHandle handle, DataProvider provider)
        {
            if (providers.ContainsKey(handle))
            {
                return providers[handle];
            }

            providers.Add(handle, provider);

            return provider;
        }

        private DataProvider this[DataProviderHandle handle]
        {
            get
            {
                return providers[handle];
            }
        }

        private void Remove(DataProviderHandle handle)
        {
             providers.Remove(handle);
        }



        public override string ToString()
        {
            return string.Format("Registered Providers = #{0}", providers.Count);
        }




//-----------------------------------------------------------------------------------------------------------------------------------



 
        #region Default Data Provider

        internal const DataProviderHandle DEFAULT_PROVIDER = 0;

        public static void RegisterDefaultProvider(string connectionString)
        {
            RegisterDefaultProvider(connectionString, null);
        }

        public static void RegisterDefaultProvider(string connectionString, string sysDatabase)
        {
            const string INITIAL = "initial catalog";
            string initial = connectionString.Split(new char[] { ';' }).Where(segment => segment.StartsWith(INITIAL)).First();
            string appDatabase = initial.Replace(INITIAL, "").Replace("=", "").Trim();


            Sys.Const.DB_APPLICATION = appDatabase;
            if (sysDatabase == null)
                Sys.Const.DB_SYSTEM = appDatabase;
            else
                Sys.Const.DB_SYSTEM = sysDatabase;

            Instance.Add(DEFAULT_PROVIDER, new DataProvider(DataProviderType.SqlServer, connectionString));
        }

        public static DataProvider DefaultProvider
        {
            get
            {
                return Instance[DEFAULT_PROVIDER];
            }
        }

        #endregion



        private static DataProviderHandle handle = DEFAULT_PROVIDER + 1000;
        public static DataProviderHandle Register(DataProviderType type, string connectionString)
        {
            handle++;

            Instance.Add(handle, new DataProvider(type, connectionString));
            return handle;
        }

        public static DataProvider GetProvider(DataProviderHandle handle)
        {
            return Instance[handle];
        }


        public static void Unregister(DataProviderHandle handle)
        {
            Instance.Remove(handle);
        }

      
    }
}


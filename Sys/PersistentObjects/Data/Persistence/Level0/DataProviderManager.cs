using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using Tie;

namespace Sys.Data
{
    
    public class DataProviderManager 
    {
        private static DataProviderManager instance = null;

        private Dictionary<DataProviderHandle, DataProvider> providers = new Dictionary<DataProviderHandle, DataProvider>();

        private DataProviderManager()
        { 
        }

        public static DataProviderManager Instance
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
                if(providers.ContainsKey(handle))
                    return providers[handle];
                else
                    return null;
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

        public VAL Json
        {
            get
            {
                VAL val = VAL.Array(this.providers.Count);
                int i = 0;
                foreach (var pair in this.providers)
                {
                    val[i]["handle"] = pair.Key.GetValData();
                    val[i]["provider"] = pair.Value.GetValData();
                    i++;
                }

                return val;

            }
            set
            {
                VAL val = value;
                for (int i = 0; i < val.Size; i++)
                {
                    DataProviderHandle handle = new DataProviderHandle(val[i]["handle"]);
                    DataProvider provider = new DataProvider(val[i]["provider"]);
                    Add(handle, provider);
                }
            }
        }

        



//-----------------------------------------------------------------------------------------------------------------------------------



 
        #region Default Data Provider

        
        public static void RegisterDefaultProvider(string connectionString)
        {
            RegisterDefaultProvider(connectionString, null);
        }

        public static void RegisterDefaultProvider(string connectionString, string sysDatabase)
        {
            const string INITIAL = "initial catalog";
            string initial = connectionString.Split(new char[] { ';' }).Where(segment => segment.Trim().StartsWith(INITIAL)).First();
            string appDatabase = initial.Replace(INITIAL, "").Replace("=", "").Trim();


            Sys.Const.DB_APPLICATION = appDatabase;
            if (sysDatabase == null)
                Sys.Const.DB_SYSTEM = appDatabase;
            else
                Sys.Const.DB_SYSTEM = sysDatabase;

            Instance.Add(DataProviderHandle.DefaultProviderHandle, new DataProvider("Default", DataProviderType.SqlServer, connectionString));
        }

        public static DataProvider DefaultProvider
        {
            get
            {
                return Instance[DataProviderHandle.DefaultProviderHandle];
            }
        }

        #endregion



        private static DataProviderHandle handle = DataProviderHandle.USER_PROVIDER_HANDLE_BASE;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">used to display and search</param>
        /// <param name="type"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataProviderHandle Register(string name, DataProviderType type, string connectionString)
        {
            handle++;
            Instance.Add(handle, new DataProvider(name, type, connectionString));
            return handle;
        }


        public static void Unregister(DataProviderHandle handle)
        {
            Instance.Remove(handle);
        }


        internal static DataProvider GetProvider(DataProviderHandle handle)
        {
            return Instance[handle];
        }

        public static DataProviderHandle GetProviderHandle(string name)
        {
            foreach (KeyValuePair<DataProviderHandle, DataProvider> pair in Instance.providers)
            {
                if (pair.Value.Name == name)
                    return pair.Key;
            }
            
            return DataProviderHandle.DefaultProviderHandle;
            
        }

       
      
    }
}


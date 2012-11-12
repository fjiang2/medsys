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

        private Dictionary<DataProvider, DataProviderDefinition> providers = new Dictionary<DataProvider, DataProviderDefinition>();

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

        private DataProviderDefinition Add(DataProvider handle, DataProviderDefinition provider)
        {
            if (providers.ContainsKey(handle))
            {
                return providers[handle];
            }

            providers.Add(handle, provider);

            return provider;
        }

        private DataProviderDefinition this[DataProvider handle]
        {
            get
            {
                if(providers.ContainsKey(handle))
                    return providers[handle];
                else
                    return null;
            }
        }

        private void Remove(DataProvider handle)
        {
             providers.Remove(handle);
        }


        public override string ToString()
        {
            return string.Format("Registered Providers = #{0}", providers.Count);
        }

        internal DataProvider GetHandle(int handle)
        {
            foreach (DataProvider provider in this.providers.Keys)
            {
                if (provider.Handle == handle)
                    return provider;
            }

            return DataProvider.DefaultProvider;
        }

        internal DataProviderDefinition GetProvider(DataProvider handle)
        {
            return this[handle];
        }

        public IEnumerable<KeyValuePair<DataProvider, DataProviderDefinition>> Providers
        {
            get { return this.providers; }
        }

        public DataProvider GetProviderHandle(string name)
        {
            foreach (KeyValuePair<DataProvider, DataProviderDefinition> pair in this.providers)
            {
                if (pair.Value.Name == name)
                    return pair.Key;
            }

            return DataProvider.DefaultProvider;

        }


        public VAL Configuration
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
                    DataProvider handle = new DataProvider(val[i]["handle"]);
                    DataProviderDefinition provider = new DataProviderDefinition(val[i]["provider"]);
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

            Instance.Add(DataProvider.DefaultProvider, new DataProviderDefinition("Default", DataProviderType.SqlServer, connectionString));
        }

        public static DataProviderDefinition DefaultProvider
        {
            get
            {
                return Instance[DataProvider.DefaultProvider];
            }
        }

        #endregion



        private static DataProvider handle = DataProvider.USER_PROVIDER_HANDLE_BASE;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">used to display and search</param>
        /// <param name="type"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataProvider Register(string name, DataProviderType type, string connectionString)
        {
            handle++;
            Instance.Add(handle, new DataProviderDefinition(name, type, connectionString));
            return handle;
        }


        public static void Unregister(DataProvider handle)
        {
            Instance.Remove(handle);
        }


    
       
      
    }
}


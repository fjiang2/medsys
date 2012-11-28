using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using Tie;
using Sys.PersistentObjects.DpoClass;

namespace Sys.Data
{
    
    public class DataProviderManager 
    {
        private static DataProviderManager instance = null;

        private Dictionary<DataProvider, DataProviderConnection> providers = new Dictionary<DataProvider, DataProviderConnection>();

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

        private DataProviderConnection Add(DataProvider handle, DataProviderConnection provider)
        {
            if (providers.ContainsKey(handle))
            {
                return providers[handle];
            }

            providers.Add(handle, provider);

            return provider;
        }

        private DataProviderConnection this[DataProvider handle]
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

        public DataProvider GetProvider(int handle)
        {
            foreach (DataProvider provider in this.providers.Keys)
            {
                if ((int)provider == handle)
                    return provider;
            }

            return DataProvider.DefaultProvider;
        }

        internal DataProviderConnection GetProvider(DataProvider handle)
        {
            return this[handle];
        }

        public IEnumerable<KeyValuePair<DataProvider, DataProviderConnection>> Providers
        {
            get { return this.providers; }
        }

        public DataProvider GetProviderHandle(string name)
        {
            foreach (KeyValuePair<DataProvider, DataProviderConnection> pair in this.providers)
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
                    DataProviderConnection provider = new DataProviderConnection(val[i]["provider"]);
                    Add(handle, provider);
                }

              
            }
        }


        public void LoadDataProviders()
        {
            var list = new TableReader<DataProviderDpo>(DataProviderDpo._inactive.ColumnName() == 0).ToList();
            foreach (DataProviderDpo dpo in list)
            {
                DataProvider handle = new DataProvider(dpo.handle);
                DataProviderConnection provider = new DataProviderConnection(dpo.name, (DataProviderType)dpo.type, dpo.connection);
                Add(handle, provider);
            }
        }



//-----------------------------------------------------------------------------------------------------------------------------------



 
        #region Default Data Provider


        public static DataProvider RegisterDefaultProvider(string connectionString)
        {
            return RegisterDefaultProvider(connectionString, null);
        }

        public static DataProvider RegisterDefaultProvider(string connectionString, string sysDatabase)
        {
            const string INITIAL = "initial catalog";
            string initial = connectionString.Split(new char[] { ';' }).Where(segment => segment.Trim().StartsWith(INITIAL)).First();
            string appDatabase = initial.Replace(INITIAL, "").Replace("=", "").Trim();


            Sys.Const.DB_APPLICATION = appDatabase;
            if (sysDatabase == null)
                Sys.Const.DB_SYSTEM = appDatabase;
            else
                Sys.Const.DB_SYSTEM = sysDatabase;

            Instance.Add(DataProvider.DefaultProvider, new DataProviderConnection("Default", DataProviderType.SqlServer, connectionString));
            
            return DataProvider.DefaultProvider;
        }

        public static DataProviderConnection DefaultProvider
        {
            get
            {
                return Instance[DataProvider.DefaultProvider];
            }
        }

        #endregion


        /// <summary>
        /// provider's handle is assigned during runtime
        /// </summary>
        private static DataProvider dynamicProvider = new DataProvider(DataProvider.USER_HANDLE_BASE);
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">used to display and search</param>
        /// <param name="type"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataProvider Register(string name, DataProviderType type, string connectionString)
        {
            dynamicProvider = new DataProvider((int)dynamicProvider + 1);
            Instance.Add(dynamicProvider, new DataProviderConnection(name, type, connectionString));
            return dynamicProvider;
        }


        public static void Unregister(DataProvider handle)
        {
            Instance.Remove(handle);
        }


    
       
      
    }
}


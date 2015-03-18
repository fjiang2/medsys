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
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using Tie;

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

        private DataProviderConnection Add(DataProvider provider, DataProviderConnection connection)
        {
            if (providers.ContainsKey(provider))
            {
                providers.Remove(provider);
            }

            providers.Add(provider, connection);

            return connection;
        }

     
        private void Remove(DataProvider provider)
        {
             providers.Remove(provider);
        }


        public override string ToString()
        {
            return string.Format("Registered Providers = #{0}", providers.Count);
        }

      

        internal DataProviderConnection GetConnection(DataProvider provider)
        {
            if (providers.ContainsKey(provider))
                return providers[provider];
            else
                return null;
        }

        public DataProviderConnection GetConnection(int handle)
        {
            return GetConnection(GetProvider(handle));
        }


        public IEnumerable<KeyValuePair<DataProvider, DataProviderConnection>> Providers
        {
            get { return this.providers; }
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

        public DataProvider GetProvider(string name)
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
                    val[i]["handle"] = pair.Key.GetVAL();
                    val[i]["provider"] = pair.Value.GetVAL();
                    i++;
                }

                return val;

            }
            set
            {
                VAL val = value;
                for (int i = 0; i < val.Size; i++)
                {
                    DataProvider provider = new DataProvider(val[i]["handle"]);
                    DataProviderConnection connection = new DataProviderConnection(val[i]["provider"]);
                    Add(provider, connection);
                }

              
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
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);

            Const.CONNECTION_STRING = connectionString;
            Const.DB_APPLICATION = builder.InitialCatalog;
            if (sysDatabase == null)
                Const.DB_SYSTEM = builder.InitialCatalog;
            else
                Const.DB_SYSTEM = sysDatabase;

            Instance.Add(DataProvider.DefaultProvider, new DataProviderConnection("Default", DataProviderType.SqlServer, connectionString));
            
            return DataProvider.DefaultProvider;
        }

        public static DbConnection DefaultDbConnection
        {
            get
            {
                return Instance.GetConnection(DataProvider.DefaultProvider).NewDbConnection;
            }
        }

        public static DataProvider DefaultProvider
        {
            get
            {
                return DataProvider.DefaultProvider;
            }
        }

        #endregion


        /// <summary>
        /// provider's handle is assigned during runtime
        /// </summary>
        private static int PROVIDER = DataProvider.USER_HANDLE_BASE;
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">used to display and search</param>
        /// <param name="type"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataProvider Register(string name, DataProviderType type, string connectionString)
        {
            DataProvider dynamicProvider = new DataProvider(PROVIDER++ + 1) { Name = name };
            Instance.Add(dynamicProvider, new DataProviderConnection(name, type, connectionString));
            return dynamicProvider;
        }


        public static void Unregister(DataProvider provider)
        {
            Instance.Remove(provider);
        }


        public static DataProvider Register(SqlConnectionStringBuilder builder)
        {
            return Register(builder.DataSource, DataProviderType.SqlServer, builder.ConnectionString);
        }

        public static DataProvider Register(OleDbConnectionStringBuilder builder)
        {
            return Register(builder.DataSource, DataProviderType.OleDbServer, builder.ConnectionString);
        }

    }
}


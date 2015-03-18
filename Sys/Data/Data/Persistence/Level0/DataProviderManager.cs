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

        private Dictionary<int, DataProvider> providers = new Dictionary<int, DataProvider>();

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

        private void Add(DataProvider provider)
        {
            if (providers.ContainsKey(provider.Handle))
            {
                providers.Remove(provider.Handle);
            }

            providers.Add(provider.Handle, provider);

        }

     
        private void Remove(DataProvider provider)
        {
             providers.Remove(provider.Handle);
        }


        public override string ToString()
        {
            return string.Format("Registered Providers = #{0}", providers.Count);
        }

        

        public IEnumerable<DataProvider> Providers
        {
            get { return this.providers.Values; }
        }

        public DataProvider GetProvider(int handle)
        {
            if (providers.ContainsKey(handle))
                return providers[handle];

            return DataProviderManager.DefaultProvider;
        }

        public DataProvider GetProvider(string name)
        {
            foreach (var provider in this.providers.Values)
            {
                if (provider.Name == name)
                    return provider;
            }

            return DataProviderManager.DefaultProvider;

        }


        public VAL Configuration
        {
            get
            {
                VAL val = VAL.Array(this.providers.Count);
                int i = 0;
                foreach (var pair in this.providers)
                {
                    val[i]["handle"] = pair.Value.GetVAL();
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
                    Add(provider );
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

            defaultProvider = new DataProvider(DataProvider.DEFAULT_HANDLE, "Default", DataProviderType.SqlServer, connectionString);
            Instance.Add(DataProviderManager.DefaultProvider);

            return DataProviderManager.DefaultProvider;
        }

        public static DbConnection DefaultDbConnection
        {
            get
            {
                return DataProviderManager.DefaultProvider.NewDbConnection;
            }
        }

        private static DataProvider defaultProvider;

        public static DataProvider DefaultProvider
        {
            get
            {
                return defaultProvider;
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
            DataProvider dynamicProvider = new DataProvider(++PROVIDER, name, type, connectionString);
            Instance.Add(dynamicProvider);
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


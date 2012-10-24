using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Sys.Data
{
    public class DataProviderManager
    {
        private static DataProviderManager instance = null;

        Dictionary<string, DataProvider> providers = new Dictionary<string, DataProvider>();
        Stack<DataProvider> stacks = new Stack<DataProvider>();

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

        private DataProvider Add(DataProvider provider)
        {
            if (providers.ContainsKey(provider.ConnectionString))
            {
                return providers[provider.ConnectionString];
            }

            providers.Add(provider.ConnectionString, provider);
            stacks.Push(provider);

            return provider;
        }

        private void Remove()
        {
             DataProvider provider = stacks.Pop();
             providers.Remove(provider.ConnectionString);
        }

        private DataProvider Top
        {
            get
            {
                return stacks.Peek();
            }
        }

        public override string ToString()
        {
            return string.Format("Registered Providers = #{0}", providers.Count);
        }




//-----------------------------------------------------------------------------------------------------------------------------------



        const string Excel2010 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=@XLS;Extended Properties=\"Excel 12.0 Xml;HDR=No\"";
        const string Excel2007 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=@XLS;Extended Properties=\"Excel 8.0;HDR=NO;\"";
        const string SqlServer = "data source=@SVR;initial catalog=@DB;integrated security=SSPI;packet size=4096";

        public static DataProvider Register(DataProviderType type, string connectionString)
        {
            return Instance.Add(new DataProvider(type, connectionString));
        }

        public static DataProvider RegisterSqlServerSSPI(string serverName, string database)
        {
            string connectionString = SqlServer.Replace("@SVR", serverName).Replace("@DB", database);
            return Instance.Add(new DataProvider(DataProviderType.SqlServer, connectionString));
        }

        public static DataProvider RegisterExcel2007(string xlsName)
        {
            string connectionString = Excel2007.Replace("@XLS", xlsName);
            return Instance.Add(new DataProvider(DataProviderType.Excel2007, connectionString));
        }

        public static DataProvider RegisterExcel2010(string xlsName)
        {
            string connectionString = Excel2007.Replace("@XLS", xlsName);
            return Instance.Add(new DataProvider(DataProviderType.Excel2010, connectionString));
        }


        public static void Unregister(DataProvider provider)
        {
            Instance.providers.Remove(provider.ConnectionString);
        }

        public static DataProvider ActiveProvider
        {
            get
            {
                return Instance.Top;
            }
        }
    }
}


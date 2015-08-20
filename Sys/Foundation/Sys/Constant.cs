using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tie;
using System.Reflection;
using Sys.Data;
using Sys.PersistentObjects.DpoClass;

namespace Sys
{
    public class Constant : Const
    {
        public static int XMPP_DATA_PROVIDER = 0;
        public static string XMPP_DATABASE_NAME = DB_APPLICATION;

        public static bool USE_XMPP                     { get { return Configuration.Instance.GetValue<bool>("Xmpp.Active"); } }
        public static int POLICY_PASSWORD_EXPRIED_DAYS  { get { return Configuration.Instance.GetValue<int>("Policy.Password.Expired.Days"); }  }
        public static string POLICY_DEFAULT_PASSWORD    { get { return Configuration.Instance.GetValue<string>("Policy.Password.Default"); }    }
        public static string PATH_EXECUTABLE_INSTALL    { get { return Configuration.Instance.GetValue<string>("Path.Executable.Install"); } }

        public static bool SINGLE_USER_SYSTEM = false;

        public static EventHandler<SqlExceptionEventArgs> DefaultExceptionHandler= (sender, e) =>
        {
                System.Windows.Forms.MessageBox.Show(e.Exception.Message, "SQL Error", System.Windows.Forms.MessageBoxButtons.OK);
        };

    private static FieldInfo[] GetFields()
        {
            return 
                       typeof(Constant).BaseType.GetFields()
                .Union(typeof(Constant).GetFields())
                .ToArray();
        }


        public static void Save(string ini)
        {
            VAL json = new VAL();

            FieldInfo[] fields = GetFields();
            foreach (FieldInfo field in fields)
            {
                json[field.Name] = VAL.Boxing(field.GetValue(null));
            }

           // json["dataprovider"] = DataProviderManager.Instance.Configuration;

            string config = json.ToJson();
#if !DEBUG
            config = config.Encrypt();
#else
            ini += ".debug";
#endif
            Sys.IO.File.WriteFile(ini, config);
        }

        public static bool Load(string ini)
        {

#if DEBUG
            ini += ".debug";
#endif
            string config = Sys.IO.File.ReadFile(ini);

            if (config == null)
                return false;

#if !DEBUG
            config = config.Decrypt();
#endif
            VAL json = Script.Evaluate(config);

            FieldInfo[] fields = GetFields();
            foreach (FieldInfo field in fields)
            {
                VAL val = json[field.Name];
                if(val.Defined)
                    field.SetValue(null, val.HostValue);
            }

            //DataProviderManager.Instance.Configuration = json["dataprovider"];

            ConnectionProviderManager.RegisterDefaultProvider(Const.CONNECTION_STRING);
            LoadDataProviders();

            Const.DB_REVISION = Configuration.Instance.GetValue<int>("Revision");
            
            return SqlServer.IsGoodConnectionString();
        }

        public static void LoadDataProviders()
        {
            var list = new TableReader<DataProviderDpo>(DataProviderDpo._inactive.ColumnName() == 0).ToList();
            foreach (DataProviderDpo dpo in list)
            {
                ConnectionProviderManager.Register(dpo.name, (ConnectionProviderType)dpo.type, dpo.connection);
            }
        }

    }

}
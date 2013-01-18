using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tie;
using System.Reflection;
using Sys.Data;

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

            DataProviderManager.RegisterDefaultProvider(Const.CONNECTION_STRING);
            DataProviderManager.Instance.LoadDataProviders();

            Const.Revision = Configuration.Instance.GetValue<int>("Revision");
            Const.COMPUTER_NAME = System.Windows.Forms.SystemInformation.ComputerName;

            JException.DefaultExceptionHandler = delegate(string title, string message)
            {
                System.Windows.Forms.MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OK);
            };


            return SqlServer.IsGoodConnectionString();
        }
    }

}
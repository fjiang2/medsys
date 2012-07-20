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
        public static string DB_XMPP = DB_APPLICATION;

        public static bool USE_XMPP                     { get { return (bool)Configuration.Instance["Xmpp.Active"]; } }
        public static int POLICY_PASSWORD_EXPRIED_DAYS  { get { return (int)Configuration.Instance["Policy.Password.Expired.Days"]; }  }
        public static string POLICY_DEFAULT_PASSWORD    { get { return (string)Configuration.Instance["Policy.Password.Default"]; }    }
        public static string PATH_EXECUTABLE_INSTALL    { get { return (string)Configuration.Instance["Path.Executable.Install"]; } }



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




            Const.Revision = (int)Configuration.Instance["Revision"];
            Const.COMPUTER_NAME = System.Windows.Forms.SystemInformation.ComputerName;

            SysException.DefaultExceptionHandler = delegate(string title, string message)
            {
                System.Windows.Forms.MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OK);
            };



            return SqlServer.IsGoodConnectionString();
        }
    }

}
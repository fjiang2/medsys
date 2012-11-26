using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tie;
using Sys.Data;
using Sys.Foundation.DpoClass;

namespace Sys
{
    public class Configuration
    {
        static Configuration appConfig = null;
        Memory memory = new Memory();

        private Configuration()
        {
            DataTable dataTable = new TableReader<ConfigurationDpo>(ConfigurationDpo._Inactive.ColumnName() == false).Table;
            StringBuilder code = new StringBuilder();
            foreach (DataRow dataRow in dataTable.Rows)
            { 
                code.Append(string.Format("{0}={1};\n",dataRow[ConfigurationDpo._key_name], dataRow[ConfigurationDpo._value])); 
            }

            Script.Execute(code.ToString(), memory);
        }

        public static Configuration Instance
        {
            get
            {
                if (appConfig == null)
                    return appConfig = new Configuration();

                else
                    return appConfig;
            }

        }

        public VAL GetValue(string key)
        {
            return Script.Evaluate(key, memory);
        }

        public object this[string key]
        {
            get
            {
                VAL v = Script.Evaluate(key, memory);
                return v.HostValue;
            }
        }

        public void Save(string key, object value)
        {
            string val = VAL.Boxing(value).Valor;
            string code = string.Format("{0}={1};", key, val);
            Script.Execute(code, memory);

            ConfigurationDpo dpo = new ConfigurationDpo();
            dpo.key_name = key;
            dpo.value = val;
            dpo.Inactive = false;
            dpo.Save();
        }

    }
}

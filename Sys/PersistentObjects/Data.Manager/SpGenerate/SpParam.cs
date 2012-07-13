using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;

namespace Sys.Data.Manager
{
    class SpParam
    {
        SpParamDpo param;
        SqlDbType dbType;

        string name;
        string type;

        public SpParam(SpParamDpo param)
        {
            this.param = param;
            this.name = param.name.Substring(1);
            this.type = MetaColumn.GetFieldType(param.type, false);
            this.dbType = MetaColumn.GetSqlDbType(param.type);

        }


        public string signuture1()
        {
            if(param.is_output)
                return string.Format("ref {0} {1}", type, name);
            else
                return string.Format("{0} {1}", type, name);
        }


        public string signuture2()
        {
            if (param.is_output)
                return string.Format("ref {0}", name);
            else
                return name;
        }

        public string param1()
        {
            if (param.is_output)
                return string.Format("cmd.AddParameter(\"{0}\", SqlDbType.{1}, {2});\r\n", param.name, dbType, param.max_length);
            else
                return string.Format("cmd.AddParameter(\"{0}\", SqlDbType.{1}, {2}, {3});\r\n", param.name, dbType, param.max_length, name);
        }

        public string param2()
        {
            if (param.is_output)
                return string.Format("{0} = ({1})cmd[\"{2}\"];\r\n", name, type, param.name);

            return "";
        }

        
    }


  
}

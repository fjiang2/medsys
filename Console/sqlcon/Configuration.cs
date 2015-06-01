using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using Tie;

namespace sqlcon
{
    class Configuration
    {
        private Memory Cfg = new Memory();


        public ActionType Action = ActionType.CompareSchema;

        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public string SchemaFile { get; set; }

        public string[] excludedtables = new string[] { };
        public readonly Dictionary<string, string[]> PK = new Dictionary<string, string[]>();

        public Configuration()
        {
            Script.FunctionChain.Add(functions);
            HostType.Register(typeof(DateTime), true);
        }


        private static VAL functions(string func, VAL parameters, Memory DS)
        {
            switch (func)
            {
                case "config":
                    var conn = SearchConnectionString(parameters);
                    if (conn != null)
                        return new VAL(conn);
                    else
                        return new VAL();
            }

            return null;
        }

        private bool TryReadCfg(string cfgFile)
        {
            if (!File.Exists(cfgFile))
            {
                Console.WriteLine("configuration file {0} not exists", cfgFile);
                return false;
            }

            using (var reader = new StreamReader(cfgFile))
            {
                string code = reader.ReadToEnd();
                try
                {
                    Script.Execute(code, Cfg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("configuration file format error in {0}, {1}", cfgFile, ex.Message);
                    return false;
                }
            }

            return true;
        }

      

     
        public VAL GetValue(VAR variable)
        {
            return Cfg[variable];
        }

        public string GetConnectionString(string aliasName)
        {
            var aliasMap = Cfg.GetValue("alias");
            if (aliasMap.Undefined)
                return null;

            var x = aliasMap[aliasName];
            if (x.Undefined)
                return null;

            else
                return (string)x;
        }

        public bool Initialize(string cfgFile)
        {
            if (!TryReadCfg(cfgFile))
                return false;

            this.excludedtables = Cfg.GetValue<string[]>("excludedtables", new string[] { });
            this.Action = Cfg.GetValue<ActionType>("actiontype", ActionType.CompareSchema);

            this.InputFile = Cfg.GetValue<string>("input", "script.sql");
            this.OutputFile = Cfg.GetValue<string>("output", "script.sql");
            this.SchemaFile = Cfg.GetValue<string>("schema", "schema.xml");

        
            var log = Cfg["log"];
            if(log.Defined)
                Context.DS.Add("log", log);

             Context.DS.Add("output", new VAL(this.OutputFile));

            

            var pk = Cfg["primary_key"];
            if (pk.Defined)
            {
                foreach (var item in pk)
                {
                    string tableName = (string)item[0];
                    PK.Add(tableName.ToUpper(), (string[])item[1].HostValue);
                }
            }

         

            var x = Cfg["query"];
            if (x.Defined)
            {
                foreach (var pair in x)
                    Context.DS.Add((string)pair[0], pair[1]);
            }

            return true;

        }

        private static string SearchConnectionString(VAL val)
        {
            if(val.Count != 2)
            {
                Console.WriteLine("required 2 parameters on function config(file,path), 1: app.config/web.config name; 2: path to reach connection string");
                return null;
            }

            if (val[0].VALTYPE != VALTYPE.stringcon || val[1].VALTYPE != VALTYPE.stringcon)
            {
                Console.WriteLine("error on function config(file,path) argument type, 1: string, 2: string");
                return null;
            }

            string xmlFile = (string)val[0];
            string path = (string)val[1];

            try
            {
                return SearchConnectionString(xmlFile, path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("cannot find connection string on file {0}, {1}", xmlFile, ex.Message);
                return null;
            }
        }

        private static string SearchConnectionString(string xmlFile, string path)
        {
            if (!File.Exists(xmlFile))
            {
                Console.WriteLine("warning: not exists {0}", xmlFile);
                return null;
            }

            string[] segments = path.Split('|');
            XElement X = XElement.Load(xmlFile);
            for (int i = 0; i < segments.Length - 1; i++)
            {
                X = X.Element(segments[i]);
            }

            string attr = segments.Last();
            string[] pair = attr.Split('=');
            var connectionString = X.Elements()
                .Where(x => x.Attribute(pair[0]).Value == pair[1])
                .Select(x => x.Attribute("value").Value)
                .FirstOrDefault();

            return connectionString;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using Tie;
using Sys.Data;

namespace sqlcon
{
    class Configuration
    {
        
        public const string _COMPARISON = "comparison";
        public const string _SERVER0 = "server";
        public const string _SERVER1 = "server1";
        public const string _SERVER2 = "server2";
        
        const string _FUNC_CONFIG = "config";
        const string _SERVERS = "servers";

        const string _FILE_SYSTEM_CONFIG = "sqlcon.cfg"; 
        const string _FILE_INPUT = "input";
        const string _FILE_OUTPUT = "output";
        const string _FILE_SCHEMA = "schema";
        const string _FILE_LOG = "log";
        const string _FILE_EDITOR = "editor";

        const string _LIMIT = "limit";
        const string _ACTION_TYPE = "actiontype";
        const string _EXCLUDED_TABLES = "excludedtables";

        const string _QUEREY = "query";
        const string _PRIMARY_KEY = "primary_key";

        private Memory Cfg = new Memory();


        public ActionType Action = ActionType.CompareSchema;

        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public string SchemaFile { get; set; }

        public string[] excludedtables = new string[] { };
        public int Limit_Top = 20;

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
                case _FUNC_CONFIG:
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
                Console.WriteLine("configuration file {0} not found", cfgFile);
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

        public T GetValue<T>(string variable, T defaultValue = default(T))
        {
            return Cfg.GetValue<T>(variable, defaultValue);
        }

        private static string PeelOleDb(string connectionString)
        {
            if (connectionString.ToLower().IndexOf("sqloledb") >= 0)
            {
                var x1 = new OleDbConnectionStringBuilder(connectionString);
                var x2 = new SqlConnectionStringBuilder();
                x2.DataSource = x1.DataSource;
                x2.InitialCatalog = (string)x1["Initial Catalog"];
                x2.UserID = (string)x1["User Id"];
                x2.Password = (string)x1["Password"];
                return x2.ConnectionString;
            }

            return connectionString;
        }

        private List<ConnectionProvider> providers = null;
        public List<ConnectionProvider> Providers
        {
            get
            {
                if (providers == null)
                    providers = GetConnectionProviders();

                return providers;
            }
        }

        private List<ConnectionProvider> GetConnectionProviders()
        {
            List<ConnectionProvider> pvds = new List<ConnectionProvider>();

            var machines = Cfg.GetValue(_SERVERS);
            if (machines.Undefined)
                return pvds;

            foreach (var pair in machines)
            {
                if (pair[0].IsNull || pair[1].IsNull)
                {
                    stdio.ShowError("warning: undefined connection string at servers.{0}", pair[0].ToSimpleString());
                    continue;
                }

                string serverName = pair[0].Str;
                string connectionString = PeelOleDb(pair[1].Str);
                if (connectionString.ToLower().IndexOf("provider=xmlfile") >= 0)
                {
                    ConnectionProvider provider = ConnectionProviderManager.Register(serverName, ConnectionProviderType.XmlFile, connectionString);
                    pvds.Add(provider);
                }
                else
                {
                    ConnectionProvider provider = ConnectionProviderManager.Register(serverName, new SqlConnectionStringBuilder(connectionString));
                    pvds.Add(provider);
                }
            }
             
            return pvds;
        }


        public List<ServerName> ServerNames
        {
            get
            {
                var names = Providers.Select(pvd => pvd.ServerName)
                    .Distinct()
                    .ToList();

                return names;
            }
        }

        public ConnectionProvider GetProvider(string path)
        {
            string[] x = path.Split('\\');
            if (x.Length != 3)
            {
                stdio.ShowError("invalid server path: {0}, correct format is server\\database", path);
                return null;
            }

            return GetProvider(x[1], x[2]);
        }


        private ConnectionProvider GetProvider(string serverName, string databaseName)
        {
            var provider = Providers.Find(x => x.Name == serverName);
            if (provider != null)
            {
                return ConnectionProviderManager.CloneConnectionProvider(provider, serverName, databaseName);
            }
            else
            {
                stdio.ShowError("invalid server path: \\{0}\\{1}", serverName, databaseName);
                return null;
            }
        }

        public bool Initialize(string cfgFile)
        {

            string theDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (!TryReadCfg(Path.Combine(theDirectory, _FILE_SYSTEM_CONFIG)))
                return false;

            if (!string.IsNullOrEmpty(cfgFile))
            {
                if (!TryReadCfg(cfgFile))
                    return false;
            }

            this.excludedtables = Cfg.GetValue<string[]>(_EXCLUDED_TABLES, new string[] { });
            this.Action = Cfg.GetValue<ActionType>(_ACTION_TYPE, ActionType.CompareSchema);

            this.InputFile = Cfg.GetValue<string>(_FILE_INPUT, "script.sql");
            this.OutputFile = Cfg.GetValue<string>(_FILE_OUTPUT, "script.sql");
            this.SchemaFile = Cfg.GetValue<string>(_FILE_SCHEMA, "schema.xml");
            
            var limit = Cfg[_LIMIT];
            if (limit["top"].Defined)
                this.Limit_Top = (int)limit["top"];

            var log = Cfg[_FILE_LOG];
            if (log.Defined) Context.DS.Add(_FILE_LOG, log);

            var editor = Cfg.GetValue<string>(_FILE_EDITOR, "notepad.exe");
            Context.DS.Add(_FILE_EDITOR, new VAL(editor));


            var pk = Cfg[_PRIMARY_KEY];
            if (pk.Defined)
            {
                foreach (var item in pk)
                {
                    string tableName = (string)item[0];
                    PK.Add(tableName.ToUpper(), (string[])item[1].HostValue);
                }
            }



            var x = Cfg[_QUEREY];
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


        /// <summary>
        /// search *.config file
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string SearchConnectionString(string xmlFile, string path)
        {
            if (!File.Exists(xmlFile))
            {
                Console.WriteLine("warning: not found {0}", xmlFile);
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

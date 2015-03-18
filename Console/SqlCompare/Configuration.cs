﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using Tie;

namespace SqlCompare
{
    class Configuration
    {
        private Memory Cfg = new Memory();


        public ActionType Action = ActionType.CompareSchema;

        private string directory;
        private string inputFile;
        private string outputFile;
        private string schemaFile;

        public string[] excludedtables = new string[] { };
        public readonly Dictionary<string, string[]> PK = new Dictionary<string, string[]>();

        public Configuration()
        {
            Script.FunctionChain.Add(functions);
        }


        public string InputFile
        { 
            get
            {
                return string.Format("{0}\\{1}", directory, inputFile);
            }
            set
            {
                this.inputFile = value;
            }
        }
        
        public string OutputFile
        {
            get
            {
                return string.Format("{0}\\{1}", directory, outputFile);
            }
            set
            {
                this.outputFile = value;
            }
        }

        public string SchemaFile
        {
            get
            {
                return string.Format("{0}\\{1}", directory, schemaFile);
            }
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
                stdio.WriteLine("configuration file {0} not exists", cfgFile);
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
                    stdio.WriteLine("configuration file format error in {0}, {1}", cfgFile, ex.Message);
                    return false;
                }
            }

            return true;
        }

      

        public T GetValue<T>(VAR variable, T defaultValue = default(T))
        {
            VAL val = Cfg[variable];

            if (val.Defined && val.HostValue is T)
                return (T)val.HostValue;
            else
                return defaultValue;
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

            this.excludedtables = GetValue<string[]>("excludedtables", new string[] { });
            this.Action = GetValue<ActionType>("comparetype", ActionType.CompareSchema);

            this.directory = GetValue<string>("directory", "."); 
            this.inputFile = GetValue<string>("input", "script.sql");
            this.outputFile = GetValue<string>("output", "script.sql");
            this.schemaFile = GetValue<string>("schema", "schema.xml");


            if (this.directory != "." && !System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(this.directory);
            }

            var log = Cfg["log"];
            if(log.Defined)
                Context.DS.Add("log", new VAL(string.Format("{0}\\{1}", directory, log.Str)));


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
                stdio.WriteLine("required 2 parameters on function config(file,path), 1: app.config/web.config name; 2: path to reach connection string");
                return null;
            }

            if (val[0].ty != VALTYPE.stringcon || val[1].ty != VALTYPE.stringcon)
            {
                stdio.WriteLine("error on function config(file,path) argument type, 1: string, 2: string");
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
                stdio.WriteLine("cannot find connection string on file {0}, {1}", xmlFile, ex.Message);
                return null;
            }
        }

        private static string SearchConnectionString(string xmlFile, string path)
        {
            if (!File.Exists(xmlFile))
            {
                stdio.WriteLine("warning: not exists {0}", xmlFile);
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

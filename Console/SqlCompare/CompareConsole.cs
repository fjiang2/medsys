using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys.Data;
using Sys.Data.Comparison;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Tie;

namespace SqlCompare
{
    class CompareConsole : stdio
    {
        private VAL ini;
        private VAL alias;

        private string scriptFileName = "script.sql";
        private string[] excludedtables = new string[] { };
        private CompareAction compareType = CompareAction.CompareSchema;
        private Dictionary<string, string[]> PK = new Dictionary<string, string[]>();

        SqlConnectionStringBuilder cs1;
        SqlConnectionStringBuilder cs2;

        public CompareConsole()
        {

        }

        private static bool TryReadCfg(string fileName, out VAL ini)
        {
            ini = new VAL();
            if (!File.Exists(fileName))
            {
                Console.WriteLine("configuration file {0} not exists", fileName);
                return false;
            }

            using (var reader = new StreamReader(fileName))
            {
                string code = reader.ReadToEnd();
                try
                {
                    ini = Script.Evaluate(code);
                }
                catch (Exception)
                {
                    Console.WriteLine("json format error in {0}", fileName);
                    return false;
                }
            }

            return true;
        }

        private void WriteFile(string sql)
        {
            if (string.IsNullOrEmpty(sql))
            {
                sql = string.Empty;
                WriteLine("Nothing is changed");
            }

            using (var writer = new StreamWriter(scriptFileName))
            {
                writer.Write(sql);
            }

            if (!string.IsNullOrEmpty(sql))
            {
                WriteLine("output: {0}", scriptFileName);
                WriteLine("completed.");
            }
        }


        public bool Initialize(string fileName)
        {
            if (!TryReadCfg(fileName, out ini))
                return false;

            this.alias = ini["alias"];

            if (alias.Defined)
            {
                var alias1 = (string)ini["alias1"];
                var alias2 = (string)ini["alias2"];
                this.cs1 = new SqlConnectionStringBuilder((string)alias[alias1]);
                this.cs2 = new SqlConnectionStringBuilder((string)alias[alias2]);
            }
            else
            {
                this.cs1 = new SqlConnectionStringBuilder();
                this.cs2 = new SqlConnectionStringBuilder();
            }

            var x = ini["excludedtables"];
            if (x.Defined)
                this.excludedtables = x.HostValue as string[];

            x = ini["comparetype"];
            if (x.Defined)
                this.compareType = (CompareAction)(int)x;

            x = ini["output"];
            if (x.Defined)
                this.scriptFileName = (string)x;

            var pk = ini["primary_key"];
            if (pk.Defined)
            {
                foreach (var item in pk)
                {
                    string tableName = (string)item[0];
                    PK.Add(tableName.ToUpper(), (string[])item[1].HostValue);
                }
            }

            return true;
        }


        public void Run(string[] args)
        {
            string tableNamePattern1 = null;
            string tableNamePattern2 = null;

            int i = 0;
            string t1, t2;

            while (i < args.Length)
            {

                switch (args[i++])
                {
                    case "/cfg":
                        i++;
                        break;


                    case "/s":
                        if (i < args.Length && args[i++].parse(out t1, out t2))
                        {
                            var s1 = alias[t1];
                            var s2 = alias[t2];
                            if (s1.Undefined)
                            {
                                WriteLine("undefined server alias ({0}) in configuration file", t1);
                                return;
                            }
                            if (s2.Undefined)
                            {
                                WriteLine("undefined server alias ({0}) in configuration file", t2);
                                return;
                            }

                            cs1 = new SqlConnectionStringBuilder((string)s1);
                            cs2 = new SqlConnectionStringBuilder((string)s2);
                            break;
                        }
                        else
                        {
                            WriteLine("/s database server alias undefined");
                            return;
                        }

                    case "/c":
                        if (i < args.Length && !args[i].StartsWith("/"))
                        {
                            switch (args[i++])
                            {
                                case "schema":
                                    compareType = CompareAction.CompareSchema;
                                    break;
                                case "data":
                                    compareType = CompareAction.CompareData;
                                    break;
                                case "column":
                                    compareType = CompareAction.ShowTableStructure;
                                    break;
                                case "pk":
                                    compareType = CompareAction.ShowParimaryKey;
                                    break;
                                case "fk":
                                    compareType = CompareAction.ShowForeignKey;
                                    break;
                                case "table":
                                    compareType = CompareAction.ShowTableName;
                                    break;
                                case "gen":
                                    compareType = CompareAction.GenerateScript;
                                    break;
                                case "row":
                                    compareType = CompareAction.GenerateTableRows;
                                    break;
                                case "cmd":
                                    compareType = CompareAction.Shell;
                                    break;
                                case "exec":
                                    compareType = CompareAction.Execute;
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            WriteLine("/c argument undefined");
                            return;
                        }


                    case "/S":
                        if (i < args.Length && args[i++].parse(out t1, out t2))
                        {
                            var server1 = ini["server1"];
                            var server2 = ini["server2"];
                            cs1.DataSource = t1;
                            cs1.DataSource = t2;
                            cs1.InitialCatalog = (string)server1["initial_catalog"];
                            cs1.InitialCatalog = (string)server2["initial_catalog"];
                            cs1.UserID = (string)server1["user_id"];
                            cs2.UserID = (string)server2["user_id"];
                            cs1.Password = (string)server1["password"];
                            cs1.Password = (string)server2["password"];
                            break;
                        }
                        else
                        {
                            WriteLine("/S server name undefined");
                            return;
                        }

                    case "/U":
                        if (i < args.Length && args[i++].parse(out t1, out t2))
                        {
                            cs1.UserID = t1;
                            cs1.UserID = t2;
                            break;
                        }
                        else
                        {
                            WriteLine("/U user name undefined");
                            return;
                        }

                    case "/P":
                        if (i < args.Length && args[i++].parse(out t1, out t2))
                        {
                            cs1.Password = t1;
                            cs1.Password = t2;
                            break;
                        }
                        else
                        {
                            WriteLine("/P server password undefined");
                            return;
                        }

                    case "/db":
                        if (i < args.Length && args[i++].parse(out t1, out t2))
                        {
                            cs1.InitialCatalog = t1;
                            cs2.InitialCatalog = t2;
                            break;
                        }
                        else
                        {
                            WriteLine("undefined database name");
                            return;
                        }

                    case "/dt":
                        if (i < args.Length && args[i++].parse(out t1, out t2))
                        {
                            tableNamePattern1 = t1;
                            tableNamePattern2 = t2;
                            break;
                        }
                        else
                        {
                            WriteLine("undefined table name");
                            return;
                        }


                    case "/e":
                        if (i < args.Length && !args[i].StartsWith("/"))
                        {
                            excludedtables = args[i++].Split(',');
                            break;
                        }
                        else
                        {
                            WriteLine("/e undefined excluded table names");
                            return;
                        }



                    case "/f":
                        if (i < args.Length && !args[i].StartsWith("/"))
                        {
                            scriptFileName = args[i++];
                            break;
                        }
                        else
                        {
                            WriteLine("/f undefined sql script file name");
                            return;
                        }

                    default:
                        Program.Help();
                        return;

                }
            }

            if (!cs1.IsGoodConnectionString())
            {
                WriteLine("invalid connection string: {0}", cs1.ConnectionString);
                return;
            }

            if (!cs2.IsGoodConnectionString())
            {
                WriteLine("invalid connection string: {0}", cs2.ConnectionString);
                return;
            }

            CompareAdapter adapter = new CompareAdapter(cs1, cs2, tableNamePattern1, tableNamePattern2);
            excludedtables = excludedtables.Select(row => row.ToUpper()).ToArray();

            try
            {
                switch (compareType)
                {
                    case CompareAction.Execute:
                        adapter.Side2.ExecuteScript(scriptFileName);

                        break;

                    case CompareAction.GenerateTableRows:
                        WriteFile(adapter.Side1.AllRowScript(excludedtables));
                        break;

                    case CompareAction.GenerateScript:
                        WriteFile(adapter.Side1.GenerateScript());
                        break;

                    case CompareAction.ShowTableName:
                        WriteLine("server1:");
                        adapter.Side1.DisplayMatchedTableNames();
                        WriteLine("server2:");
                        adapter.Side2.DisplayMatchedTableNames();
                        break;

                    case CompareAction.ShowTableStructure:
                        WriteLine("server1:");
                        adapter.Side1.DisplayColumns();
                        WriteLine("server2:");
                        adapter.Side2.DisplayColumns();
                        break;

                    case CompareAction.ShowParimaryKey:
                        WriteLine("server1:");
                        adapter.Side1.DisplayPK();
                        WriteLine("server2:");
                        adapter.Side2.DisplayPK();
                        break;

                    case CompareAction.ShowForeignKey:
                        WriteLine("server1:");
                        adapter.Side1.DisplayFK();
                        WriteLine("server2:");
                        adapter.Side2.DisplayFK();
                        break;

                    case CompareAction.CompareData:
                    case CompareAction.CompareSchema:
                        WriteFile(adapter.Run(compareType, excludedtables, PK));
                        break;

                    case CompareAction.Shell:
                        new SqlShell(adapter).DoCommand();
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Sys.Data;
using Sys.Data.Comparison;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Tie;

namespace SqlCompare
{
    class CompareConsole  
    {
        Configuration cfg;
        private SqlConnectionStringBuilder cs1;
        private SqlConnectionStringBuilder cs2;
        private ActionType action;

        public CompareConsole(Configuration cfg)
        {
            this.cfg = cfg;
            this.action = cfg.Action;

            var comparison = cfg.GetValue("comparison");
            if (comparison.Defined)
            {
                this.cs1 = new SqlConnectionStringBuilder((string)comparison[0]);
                this.cs2 = new SqlConnectionStringBuilder((string)comparison[1]);
            }
            else
            {
                this.cs1 = new SqlConnectionStringBuilder();
                this.cs2 = new SqlConnectionStringBuilder();
            }
        }

   
        private void WriteFile(string sql)
        {
            if (string.IsNullOrEmpty(sql))
            {
                sql = string.Empty;
                stdio.WriteLine("Nothing is changed");
            }

            using (var writer = cfg.OutputFile.NewStreamWriter())
            {
                writer.Write(sql);
            }

            if (!string.IsNullOrEmpty(sql))
            {
                stdio.WriteLine("output: {0}", cfg.OutputFile);
                stdio.WriteLine("completed.");
            }
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
                            var conn1 = cfg.GetConnectionString(t1);
                            var conn2 = cfg.GetConnectionString(t1);
                            if (conn1==null)
                            {
                                stdio.WriteLine("undefined server alias ({0}) in configuration file", t1);
                                return;
                            }
                            if (conn2== null)
                            {
                                stdio.WriteLine("undefined server alias ({0}) in configuration file", t2);
                                return;
                            }

                            cs1 = new SqlConnectionStringBuilder(conn1);
                            cs2 = new SqlConnectionStringBuilder(conn1);
                            break;
                        }
                        else
                        {
                            stdio.WriteLine("/s database server alias undefined");
                            return;
                        }

                    case "/c":
                        if (i < args.Length && !args[i].StartsWith("/"))
                        {
                            switch (args[i++])
                            {
                                case "schema":
                                    action = ActionType.CompareSchema;
                                    break;
                                case "data":
                                    action = ActionType.CompareData;
                                    break;
                                case "gen":
                                    action = ActionType.GenerateScript;
                                    break;
                                case "row":
                                    action = ActionType.GenerateTableRows;
                                    break;
                                case "struct":
                                    action = ActionType.GenerateSchema;
                                    break;
                                case "shell":
                                    action = ActionType.Shell;
                                    break;
                                case "exec":
                                    action = ActionType.Execute;
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            stdio.WriteLine("/c argument undefined");
                            return;
                        }


                    case "/S":
                        if (i < args.Length && args[i++].parse(out t1, out t2))
                        {
                            var server1 = cfg.GetValue("server1");
                            if (server1.Defined)
                            {
                                cs1.DataSource = t1;
                                cs1.InitialCatalog = (string)server1["initial_catalog"];
                                cs1.UserID = (string)server1["user_id"];
                                cs1.Password = (string)server1["password"];
                            }

                            var server2 = cfg.GetValue("server2");
                            if (server2.Defined)
                            {
                                cs1.DataSource = t2;
                                cs1.InitialCatalog = (string)server2["initial_catalog"];
                                cs2.UserID = (string)server2["user_id"];
                                cs1.Password = (string)server2["password"];
                            }
                            break;
                        }
                        else
                        {
                            stdio.WriteLine("/S server name undefined");
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
                            stdio.WriteLine("/U user name undefined");
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
                            stdio.WriteLine("/P server password undefined");
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
                            stdio.WriteLine("undefined database name");
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
                            stdio.WriteLine("undefined table name");
                            return;
                        }


                    case "/e":
                        if (i < args.Length && !args[i].StartsWith("/"))
                        {
                            cfg.excludedtables = args[i++].Split(',');
                            break;
                        }
                        else
                        {
                            stdio.WriteLine("/e undefined excluded table names");
                            return;
                        }



                    case "/i":
                        if (i < args.Length && !args[i].StartsWith("/"))
                        {
                            cfg.InputFile = args[i++];
                            break;
                        }
                        else
                        {
                            stdio.WriteLine("/i undefined sql script file name");
                            return;
                        }

                    case "/o":
                        if (i < args.Length && !args[i].StartsWith("/"))
                        {
                            cfg.OutputFile = args[i++];
                            break;
                        }
                        else
                        {
                            stdio.WriteLine("/o undefined sql script file name");
                            return;
                        }

                    default:
                        Program.Help();
                        return;

                }
            }

            if (!cs1.IsGoodConnectionString())
            {
                stdio.WriteLine("invalid connection string: {0}", cs1.ConnectionString);
                return;
            }

            if (!cs2.IsGoodConnectionString())
            {
                stdio.WriteLine("invalid connection string: {0}", cs2.ConnectionString);
                return;
            }

            CompareAdapter adapter = new CompareAdapter(cs1, cs2);
            MatchedDatabase m1 = new MatchedDatabase(adapter.Side1.DatabaseName, tableNamePattern1, cfg.excludedtables);
            MatchedDatabase m2 = new MatchedDatabase(adapter.Side2.DatabaseName, tableNamePattern2, cfg.excludedtables);

            switch (action)
            {
                case ActionType.Execute:
                    adapter.Side2.ExecuteScript(cfg.InputFile);

                    break;

                case ActionType.GenerateTableRows:
                    using (var writer = cfg.OutputFile.NewStreamWriter())
                    {
                        adapter.Side1.GenerateRowScript(writer, tableNamePattern1, cfg.excludedtables);
                    }
                    break;
                case ActionType.GenerateScript:
                    WriteFile(adapter.Side1.GenerateScript());
                    break;

                case ActionType.GenerateSchema:
                    stdio.WriteLine("start to generate database schema to file: {0}", cfg.SchemaFile);
                    using (var writer = cfg.SchemaFile.NewStreamWriter())
                    {
                        DataSet ds = adapter.Side1.DatabaseName.DatabaseSchema();
                        ds.WriteXml(writer, XmlWriteMode.WriteSchema);
                    }
                    stdio.WriteLine("completed");
                    break;

                case ActionType.CompareData:
                case ActionType.CompareSchema:
                    WriteFile(adapter.Run(cfg.Action, m1, m2, cfg.PK));
                    break;

                case ActionType.Shell:
                    new SqlShell(cfg, adapter).DoCommand();
                    break;
            }

        }
    }
}

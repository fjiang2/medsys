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
    class Program
    {
        static VAL ini;
        static VAL alias;

        static void Main(string[] args)
        {
        
            if (!TryReadIni("SqlCompare.ini", out ini))
                return;
            
            alias = ini["alias"];
            string output = (string)ini["output"];

            var alias1 = (string)ini["alias1"];
            var alias2 = (string)ini["alias2"];
            
            SqlConnectionStringBuilder cs1 = new SqlConnectionStringBuilder((string)alias[alias1]);
            SqlConnectionStringBuilder cs2 = new SqlConnectionStringBuilder((string)alias[alias2]);
            string[] excludedtables = ini["excludedtables"].HostValue as string[];

            string tableName1 = null;
            string tableName2 = null;

            bool compareSchema = (bool)ini["compareschema"];

            bool allRows = false;
            string where = null;

            int i = 0;
            string t1, t2;

            while (i < args.Length)
            {

                switch (args[i++])
                {
                    case "/s":
                        if (i < args.Length && parse(args[i++], out t1, out t2))
                        {
                            var s1 = alias[t1];
                            var s2 = alias[t2];
                            if (s1.Undefined)
                            {
                                Console.WriteLine("undefined server alias", t1);
                                return;
                            }
                            if (s2.Undefined)
                            {
                                Console.WriteLine("undefined server alias", t2);
                                return;
                            }

                            cs1 = new SqlConnectionStringBuilder((string)s1);
                            cs2 = new SqlConnectionStringBuilder((string)s2);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("undefined database server alias");
                            return;
                        }

                    case "/schema":
                        compareSchema = true;
                        break;

                    case "/data":
                        compareSchema = false;
                        break;

                    case "/S":
                        if (i < args.Length && parse(args[i++], out t1, out t2))
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
                            Console.WriteLine("undefined server name");
                            return;
                        }

                    case "/U":
                        if (i < args.Length && parse(args[i++], out t1, out t2))
                        {
                            cs1.UserID = t1;
                            cs1.UserID = t2;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("undefined user name");
                            return;
                        }

                    case "/P":
                        if (i < args.Length && parse(args[i++], out t1, out t2))
                        {
                            cs1.Password = t1;
                            cs1.Password = t2;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("undefined server password");
                            return;
                        }

                    case "/db":
                        if (i < args.Length && parse(args[i++], out t1, out t2))
                        {
                            cs1.InitialCatalog = t1;
                            cs2.InitialCatalog = t2;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("undefined database name");
                            return;
                        }

                    case "/dt":
                        if (i < args.Length && parse(args[i++], out t1, out t2))
                        {
                            tableName1 = t1;
                            tableName2 = t2;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("undefined table name");
                            return;
                        }

                    case "/a":
                        if (i < args.Length)
                        {
                            tableName1 = args[i++];
                            allRows = true;

                            if (i < args.Length && !args[i].StartsWith("/"))
                            {
                                where = args[i++];
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("undefined table name");
                            return;
                        }
                    
                    case "/e":
                        if (i < args.Length)
                        {
                            excludedtables = args[i++].Split(',');
                            break;
                        }
                        else
                        {
                            Console.WriteLine("undefined excluded table names");
                            return;
                        }
                    case "/h":
                    case "/?":
                        Help();
                        return;

                    case "/o":
                        if (i < args.Length)
                        {
                            output = args[i++];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("undefined output file name");
                            return;
                        }

                    default:
                        Help();
                        return;

                }
            }

            if (!IsGoodConnectionString(cs1))
            {
                Console.WriteLine("invalid connection string: {0}",  cs1.ConnectionString);
                return;
            }
            
            if (!IsGoodConnectionString(cs2))
            {
                Console.WriteLine("invalid connection string: {0}",  cs2.ConnectionString);
                return;
            }

            Command cmd = new Command(cs1, cs2)
            {
                TableName1 = tableName1,
                TableName2 = tableName2,
                OutputFile = output,
                CompareSchema = compareSchema
            };

            try
            {
                if (allRows)
                    cmd.ExtractDataRows(tableName1, where);
                else
                    cmd.Run(excludedtables);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool parse(string arg, out string t1, out string t2)
        {
            if (string.IsNullOrEmpty(arg))
            {
                t1 = null;
                t2 = null;
                return false;
            }

            string[] x = arg.Split(':');
            if(x.Length == 1)
            {
                t1 = x[0];
                t2 = x[0];
            }
            else
            {
                t1 = x[0];
                t2 = x[1];
            }

            return true;
        }

        private static bool TryReadIni(string inifile, out VAL ini)
        {
            ini = new VAL();
            if (!File.Exists(inifile))
                return false;

            using (var reader = new StreamReader(inifile))
            {
                string code = reader.ReadToEnd();
                try
                {
                    ini = Script.Evaluate(code);
                }
                catch (Exception)
                {
                    Console.WriteLine("error in " + inifile);
                    return false;
                }
            }

            return true;
        }

        public static bool IsGoodConnectionString(SqlConnectionStringBuilder cs)
        {
            SqlConnection conn = new SqlConnection(cs.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(name) FROM sys.tables", conn);
                cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        private static void Help()
        {
            Console.WriteLine("SqlCompare v1.0");
            Console.WriteLine("Usage: SqlCompare");
            Console.WriteLine("     [/s alias1:alias2]|[/s alias]");
            Console.WriteLine("     [/S server1:server2] [/U user1:user2] [/P password1:password2]");
            Console.WriteLine("     [/schema]|[/data]");
            Console.WriteLine("     [/a table [where]]");
            Console.WriteLine("     [/e table1,table2,...,table");
            Console.WriteLine("     [/db datbase1:datbase2]|[/db datbase]");
            Console.WriteLine("     [/dt table1:table2]|[/dt table]");
            Console.WriteLine("     [/o output file]");
            Console.WriteLine("/h,/?    : this help");
            Console.WriteLine("/s       : server alias defined on SqlCompare.ini]");
            Console.WriteLine("/schema  : compare schmea (default)");
            Console.WriteLine("/data    : compare data");
            Console.WriteLine("/db      : database name");
            Console.WriteLine("/dt      : table name");
            Console.WriteLine("/a       : generate rows from table");
            Console.WriteLine("/e       : excluded table list during 2 databases data comparing");
            Console.WriteLine("examples:");
            Console.WriteLine("SqlCompare /s localhost /db northwind:southwind /schema");
            Console.WriteLine("SqlCompare /S localhost /U sa /P password /db northwind:southwind /schema");
            Console.WriteLine("SqlCompare /a table1 id=20");
        }
    }
}

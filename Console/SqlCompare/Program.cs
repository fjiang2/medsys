using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Sys.Data;
using Sys.Data.Comparison;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SqlCompare
{
    class Program
    {
        static void Main(string[] args)
        {

            var output = ConfigurationManager.AppSettings["output"];

            var server1 = ConfigurationManager.AppSettings["server1"];
            var server2 = ConfigurationManager.AppSettings["server2"];
            
            SqlConnectionStringBuilder cs1 = new SqlConnectionStringBuilder(ConfigurationManager.AppSettings[server1]);
            SqlConnectionStringBuilder cs2 = new SqlConnectionStringBuilder(ConfigurationManager.AppSettings[server2]);


            string tableName1 = null;
            string tableName2 = null;

            bool compareSchema = Convert.ToBoolean(ConfigurationManager.AppSettings["compareschema"] ?? "true");

            bool allRows = false;
            string where=null;

            int i = 0;
            string t1, t2;

            while (i < args.Length)
            {

                switch (args[i++])
                {
                    case "/s":
                        if (i < args.Length && parse(args[i++], out t1, out t2))
                        {
                            cs1 = new SqlConnectionStringBuilder(ConfigurationManager.AppSettings[t1]);
                            cs2 = new SqlConnectionStringBuilder(ConfigurationManager.AppSettings[t2]);
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
                            cs1.DataSource = t1;
                            cs1.DataSource = t2;
                            cs1.UserID = "sa";
                            cs2.UserID = "sa";
                            cs1.Password = "";
                            cs1.Password = "";
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

            Command cmd = new Command(cs1,cs2)
            {
                TableName1 = tableName1,
                TableName2 = tableName2,
                OutputFile = output,
                CompareSchema = compareSchema
            };

            if (allRows)
                cmd.ExtractDataRows(tableName1, where);
            else
                cmd.Run();
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

        private static void Help()
        {
            Console.WriteLine("SqlCompare v1.0");
            Console.WriteLine("Usage: SqlCompare");
            Console.WriteLine("     [/s alias1:alias2]|[/s alias]");
            Console.WriteLine("     [/S server1:server2] [/U user1:user2] [/P password1:password2]");
            Console.WriteLine("     [/schema]|[/data]");
            Console.WriteLine("     [/a table [where]]");
            Console.WriteLine("     [/db datbase1:datbase2]|[/db datbase]");
            Console.WriteLine("     [/dt table1:table2]|[/dt table]");
            Console.WriteLine("     [/o output file]");
            Console.WriteLine("/h,/?    : this help");
            Console.WriteLine("/s       : server alias defined on SqlCompare.exe.config]");
            Console.WriteLine("/schema  : compare schmea (default)");
            Console.WriteLine("/data    : compare data");
            Console.WriteLine("/db      : database name");
            Console.WriteLine("/dt      : table name");
            Console.WriteLine("/a       : generate rows from table");
            Console.WriteLine("examples:");
            Console.WriteLine("SqlCompare /s localhost /db northwind:southwind /schema");
            Console.WriteLine("SqlCompare /a table1 id=20");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Sys.Data.Comparison;
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
            var connectionString1 = ConfigurationManager.AppSettings[server1];
            var connectionString2 = ConfigurationManager.AppSettings[server2];

            string databaseName1 = ConfigurationManager.AppSettings["db1"];
            string databaseName2 = ConfigurationManager.AppSettings["db2"];
            string tableName1 = null;
            string tableName2 = null;

            bool compareSchema = Convert.ToBoolean(ConfigurationManager.AppSettings["compareschema"] ?? "true");
            bool allRows = false;
            string where = "";

            int i = 0;

            while (i < args.Length)
            {

                switch (args[i++])
                {
                    case "/s":
                        if (i < args.Length)
                        {
                            string x = args[i++];
                            if (x.StartsWith("\"") && x.EndsWith("\""))
                                connectionString1 = x.Substring(1, x.Length - 2);
                            else
                                connectionString1 = ConfigurationManager.AppSettings[x];

                            connectionString2 = connectionString1;

                            if (i < args.Length)
                            {
                                x = args[i];
                                if (x.StartsWith("/"))
                                    break;

                                i++;

                                if (x.StartsWith("\"") && x.EndsWith("\""))
                                    connectionString2 = x.Substring(1, x.Length - 2);
                                else
                                    connectionString2 = ConfigurationManager.AppSettings[x];
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Undefined server");
                            return;
                        }


                    case "/schema":
                        compareSchema = true;
                        break;

                    case "/data":
                        compareSchema = false;
                        break;

                    case "/db":
                        if (i < args.Length)
                        {
                            databaseName1 = args[i++];
                            databaseName2 = databaseName1;

                            if (i < args.Length)
                            {
                                var x = args[i];
                                if (x.StartsWith("/"))
                                    break;

                                i++;
                                databaseName2 = x;
                            }
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Undefined database name");
                            return;
                        }

                    case "/dt":
                        if (i < args.Length)
                        {
                            tableName1 = args[i++];
                            tableName2 = tableName1;

                            if (i < args.Length)
                            {
                                var x = args[i];
                                if (x.StartsWith("/"))
                                    break;

                                i++;
                                tableName2 = x;
                            }

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

                            if (i < args.Length)
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
                            Console.WriteLine("undefined ouput file name");
                            return;
                        }

                    default:
                        Help();
                            return;

                }
            }

            Console.WriteLine("server1: " + connectionString1);
            Console.WriteLine("server2: " + connectionString2);

            var compare = new Compare(connectionString1, connectionString2);

            string sql = null;

            if (allRows)
            {
                sql = compare.AllRows(tableName1, where);
            }
            else
            {
                if (compareSchema)
                {
                    Console.WriteLine("Compare Schema...");
                    if (tableName1 != null && tableName2 != null)
                    {
                        Console.WriteLine(string.Format("Compare table {0} => {1}", tableName1, tableName2));
                        sql = compare.TableSchemaDifference(tableName1, tableName2);
                    }
                    else if (databaseName1 != null && databaseName2 != null)
                    {
                        Console.WriteLine(string.Format("Compare database {0} => {1}", databaseName1, databaseName2));
                        sql = compare.DatabaseSchemaDifference(databaseName1, databaseName2);
                    }
                }
                else
                {
                    Console.WriteLine("Compare Data...");
                    if (tableName1 != null && tableName2 != null)
                    {
                        Console.WriteLine(string.Format("Compare table {0} => {1}", tableName1, tableName2));
                        sql = compare.TableDifference(tableName1, tableName2);
                    }
                    else if (databaseName1 != null && databaseName2 != null)
                    {
                        Console.WriteLine(string.Format("Compare database {0} => {1}", databaseName1, databaseName2));
                        sql = compare.DatabaseDifference(databaseName1, databaseName2);
                    }
                }
            }

            if (!string.IsNullOrEmpty(sql))
            {
                using (var writer = new StreamWriter(output))
                {
                    writer.Write(sql);
                }
                
            }
            else
                Console.WriteLine("Completed: nothing is different.");

            Console.WriteLine("Completed.");
        }

        private static void Help()
        {
            Console.WriteLine("SqlCompare v1.0");
            Console.WriteLine("Usage: SqlCompare [/s server1 server2] | [/s server] ");
            Console.WriteLine("     [+schema]|[-schema] [+data]|[-data]");
            Console.WriteLine("     [/a table [where]]");
            Console.WriteLine("     [/db datbase1 datbase2] | [/db datbase]");
            Console.WriteLine("     [/dt table1 table2] | [/dt table]");
            Console.WriteLine("     [/o output file]");
            Console.WriteLine("/h,/?     : this help");
            Console.WriteLine("/s        : sql server connection string");
            Console.WriteLine("/schema   : compare schmea (default)");
            Console.WriteLine("/data     : compare data");
            Console.WriteLine("/db       : database name");
            Console.WriteLine("/dt       : table name");
            Console.WriteLine("/a        : generate rows from table");
        }
    }
}

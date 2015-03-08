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
                            connectionString1 = ConfigurationManager.AppSettings[x];
                            connectionString2 = connectionString1;

                            if (i < args.Length && !args[i].StartsWith("/"))
                            {
                                x = args[i++];
                                connectionString2 = ConfigurationManager.AppSettings[x];
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine("undefined database server alias");
                            return;
                        }

                    case "/cs":
                        if (i < args.Length)
                        {
                            connectionString1 = args[i++];
                            connectionString2 = connectionString1;

                            if (i < args.Length && !args[i].StartsWith("/"))
                                connectionString2 = args[i++];

                            break;
                        }
                        else
                        {
                            Console.WriteLine("undefined sql server connection string");
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

                            if (i < args.Length && !args[i].StartsWith("/"))
                                databaseName2 = args[i++];

                            break;
                        }
                        else
                        {
                            Console.WriteLine("undefined database name");
                            return;
                        }

                    case "/dt":
                        if (i < args.Length)
                        {
                            tableName1 = args[i++];
                            tableName2 = tableName1;

                            if (i < args.Length && args[i].StartsWith("/"))
                                tableName2 = args[i++];

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

            SqlConnectionStringBuilder s1 = new SqlConnectionStringBuilder(connectionString1);
            SqlConnectionStringBuilder s2 = new SqlConnectionStringBuilder(connectionString2);

            Console.WriteLine(string.Format("server1: {0} default database:{1}", s1.DataSource, s1.InitialCatalog));
            Console.WriteLine(string.Format("server2: {0} default database:{1}", s2.DataSource, s2.InitialCatalog));

            
            var compare = new Compare(connectionString1, connectionString2);

            string sql = null;

            if (allRows)
            {
                sql = compare.AllRows(tableName1, where);
            }
            else if (compareSchema)
            {
                if (tableName1 != null && tableName2 != null)
                {
                    Console.WriteLine(string.Format("compare table schema {0} => {1}", tableName1, tableName2));

                    sql = compare.TableSchemaDifference(tableName1, tableName2);
                }
                else if (databaseName1 != null && databaseName2 != null)
                {
                    Console.WriteLine(string.Format("compare database schema {0} => {1}", databaseName1, databaseName2));
                    sql = compare.DatabaseSchemaDifference(databaseName1, databaseName2);
                }
            }
            else
            {
                if (tableName1 != null && tableName2 != null)
                {
                    Console.WriteLine(string.Format("compare table data {0} => {1}", tableName1, tableName2));
                    sql = compare.TableDifference(tableName1, tableName2);
                }
                else if (databaseName1 != null && databaseName2 != null)
                {
                    Console.WriteLine(string.Format("compare database data {0} => {1}", databaseName1, databaseName2));
                    sql = compare.DatabaseDifference(databaseName1, databaseName2);
                }
            }


            if (!string.IsNullOrEmpty(sql))
            {
                using (var writer = new StreamWriter(output))
                {
                    writer.Write(sql);
                }

            }

            Console.WriteLine("completed.");
        }

        private static void Help()
        {
            Console.WriteLine("SqlCompare v1.0");
            Console.WriteLine("Usage: SqlCompare");
            Console.WriteLine("     [/s server1 server2] | [/s server] | [/cs string1 string2] | [/cs string1]");
            Console.WriteLine("     [/schema]|[/data]");
            Console.WriteLine("     [/a table [where]]");
            Console.WriteLine("     [/db datbase1 datbase2] | [/db datbase]");
            Console.WriteLine("     [/dt table1 table2] | [/dt table]");
            Console.WriteLine("     [/o output file]");
            Console.WriteLine("/h,/?     : this help");
            Console.WriteLine("/s        : server alias defined on SqlCompare.exe.config");
            Console.WriteLine("/cs       : sql server connection string");
            Console.WriteLine("/schema   : compare schmea (default)");
            Console.WriteLine("/data     : compare data");
            Console.WriteLine("/db       : database name");
            Console.WriteLine("/dt       : table name");
            Console.WriteLine("/a        : generate rows from table");
            Console.WriteLine("examples:");
            Console.WriteLine("SqlCompare /s localhost /db northwind southwind /schema");
            Console.WriteLine("SqlCompare /a table1 id=20");
        }
    }
}

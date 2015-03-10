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
       
        static void Main(string[] args)
        {
            var cfg = "SqlCompare.ini";

            int i = 0;
            while (i < args.Length)
            {
                switch (args[i++])
                {
                    case "/i":
                        if (i < args.Length)
                        {
                            cfg = args[i++];
                            goto L1;
                        }
                        else
                        {
                            Console.WriteLine("undefined configuration file");
                            return;
                        }

                    case "/h":
                    case "/?":
                        Help();
                        return;
                }                

            }

            L1:

            var site = new CompareConsole();
            if (!site.Initialize(cfg))
                return;

            site.Run(args);
        }
       
        public static void Help()
        {
            Console.WriteLine("SqlCompare v1.0");
            Console.WriteLine("Usage: SqlCompare");
            Console.WriteLine("     [/i configuration(ini) file]");
            Console.WriteLine("     [/s alias1:alias2]|[/s alias]");
            Console.WriteLine("     [/S server1:server2] [/U user1:user2] [/P password1:password2]");
            Console.WriteLine("     [/schema]|[/data]");
            Console.WriteLine("     [/a table [where]]");
            Console.WriteLine("     [/e table1,table2,...,table");
            Console.WriteLine("     [/db datbase1:datbase2]|[/db datbase]");
            Console.WriteLine("     [/dt table1:table2]|[/dt table(wildcard*,?)]");
            Console.WriteLine("     [/o output file]");
            Console.WriteLine("/h,/?    : this help");
            Console.WriteLine("/i       : ini file default file:sqlcompare.ini]");
            Console.WriteLine("/s       : server alias defined on ini file]");
            Console.WriteLine("/schema  : compare schmea (default)");
            Console.WriteLine("/data    : compare data");
            Console.WriteLine("/name    : display table names matched by /dt table");
            Console.WriteLine("/pk      : display primary key defined on /dt table");
            Console.WriteLine("/fk      : display foreign key defined on /dt table");
            Console.WriteLine("/db      : database name");
            Console.WriteLine("/dt      : table name");
            Console.WriteLine("/a       : generate rows from table");
            Console.WriteLine("/g       : generate table script from database");
            Console.WriteLine("/e       : excluded table list during 2 databases data comparing");
            Console.WriteLine("examples:");
            Console.WriteLine("SqlCompare /s localhost /db northwind:southwind /schema");
            Console.WriteLine("SqlCompare /S localhost /U sa /P password /db northwind /schema");
            Console.WriteLine("SqlCompare /data /db northwind /dt Cust*");
            Console.WriteLine("SqlCompare /a Products ProductID=20");
        }
    }
}

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
            var cfg = "sqlcompare.cfg";

            int i = 0;
            while (i < args.Length)
            {
                switch (args[i++])
                {
                    case "/cfg":
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
            Console.WriteLine("     [/cfg configuration file(.cfg)]");
            Console.WriteLine("     [/s alias1:alias2]|[/s alias]");
            Console.WriteLine("     [/S server1:server2] [/U user1:user2] [/P password1:password2]");
            Console.WriteLine("     [/schema|/data|/pk|/fk|/row|/exec]");
            Console.WriteLine("     [/e table1,table2,...,table");
            Console.WriteLine("     [/db datbase1:datbase2]|[/db datbase]");
            Console.WriteLine("     [/dt table1:table2]|[/dt table(wildcard*,?)]");
            Console.WriteLine("     [/f sql script file(.sql)]");
            Console.WriteLine("");
            Console.WriteLine("/h,/?    : this help");
            Console.WriteLine("/cfg     : congfiguration file default file:sqlcompare.cfg]");
            Console.WriteLine("/s       : server alias defined on ini file]");
            Console.WriteLine("/schema  : compare schmea (default)");
            Console.WriteLine("/data    : compare data");
            Console.WriteLine("/name    : display table names matched by /dt table");
            Console.WriteLine("/pk      : display primary key defined on /dt table");
            Console.WriteLine("/fk      : display foreign key defined on /dt table");
            Console.WriteLine("/row     : generate rows from table on server1");
            Console.WriteLine("/exec    : run sql script on server 2, let server2 += diff");
            Console.WriteLine("/g       : generate table script from database on server1");
            Console.WriteLine("/db      : database name");
            Console.WriteLine("/dt      : table name (wildcard*,?)");
            Console.WriteLine("/e       : excluded table list during 2 databases data comparing");
            Console.WriteLine("/f       : result of comparsion(diff=server1-server2),sql script file");
            Console.WriteLine("examples:");
            Console.WriteLine("SqlCompare /s localhost /db northwind:southwind /schema");
            Console.WriteLine("SqlCompare /S localhost /U sa /P password /db northwind /schema");
            Console.WriteLine("SqlCompare /data /db northwind /dt Cust*");
            Console.WriteLine("SqlCompare /a /dt Products");
        }
    }
}

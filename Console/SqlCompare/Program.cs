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
                        if (i < args.Length && !args[i].StartsWith("/"))
                        {
                            cfg = args[i++];
                            goto L1;
                        }
                        else
                        {
                            stdio.WriteLine("/cfg configuration file missing");
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

            try
            {
                if (!site.Initialize(cfg))
                    return;
            }
            catch (Exception ex)
            {
                stdio.WriteLine("error on configuration file {0}, {1}:", cfg, ex.Message);
                return;
            }

            try
            {
                site.Run(args);
            }
            catch (Exception ex)
            {
                stdio.WriteLine(ex.Message);
            }
            finally
            {
                stdio.Close();
            }
        }
       
        public static void Help()
        {
            stdio.WriteLine("SqlCompare v1.0");
            stdio.WriteLine("Usage: SqlCompare");
            stdio.WriteLine("     [/cfg configuration file(.cfg)]");
            stdio.WriteLine("     [/s alias1:alias2]|[/s alias]");
            stdio.WriteLine("     [/S server1:server2] [/U user1:user2] [/P password1:password2]");
            stdio.WriteLine("     [/c schema|data|row|exec|gen|shell]");
            stdio.WriteLine("     [/e table1,table2,...,table");
            stdio.WriteLine("     [/db datbase1:datbase2]|[/db datbase]");
            stdio.WriteLine("     [/dt table1:table2]|[/dt table(wildcard*,?)]");
            stdio.WriteLine("     [/f sql script file(.sql)]");
            stdio.WriteLine("");
            stdio.WriteLine("/h,/?      : this help");
            stdio.WriteLine("/cfg       : congfiguration file default file:sqlcompare.cfg]");
            stdio.WriteLine("/s         : server alias defined on ini file]");
            stdio.WriteLine("/c schema  : compare schmea (default)");
            stdio.WriteLine("/c data    : compare data");
            stdio.WriteLine("/c gen     : generate table script from database on server1");
            stdio.WriteLine("/c row     : generate rows from table on server1");
            stdio.WriteLine("/c exec    : run sql script on server 2, let server2 += diff");
            stdio.WriteLine("/c shell     : enter command window");
            stdio.WriteLine("/db        : database name");
            stdio.WriteLine("/dt        : table name (wildcard*,?)");
            stdio.WriteLine("/e         : excluded table list during 2 databases data comparing");
            stdio.WriteLine("/f         : result of comparsion(diff=server1-server2),sql script file");
            stdio.WriteLine("examples:");
            stdio.WriteLine("SqlCompare /s localhost /db northwind:southwind /schema");
            stdio.WriteLine("SqlCompare /S localhost /U sa /P password /db northwind /c schema");
            stdio.WriteLine("SqlCompare /c data /db northwind /dt Cust*");
            stdio.WriteLine("SqlCompare /c gen /dt Products");
        }
    }
}

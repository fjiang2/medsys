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
    class CompareConsole
    {
        private VAL ini;
        private VAL alias;

        private string output = "script.sql";
        private string[] excludedtables = new string[]{};
        private CompareAction compareType = CompareAction.Schema;
        private Dictionary<string, string[]> PK = new Dictionary<string, string[]>();

        SqlConnectionStringBuilder cs1;
        SqlConnectionStringBuilder cs2;

        public CompareConsole()
        { 
        
        }

        private static bool TryReadIni(string fileName, out VAL ini)
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


        public bool Initialize(string fileName)
        {
            if (!TryReadIni(fileName, out ini))
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
            if(x.Defined)
                this.excludedtables = x.HostValue as string[];
            
            x = ini["comparetype"];
            if (x.Defined)
                this.compareType = (CompareAction)(int)x;

            x = ini["output"];
            if (x.Defined)
                this.output = (string)x;

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
            string tableName = null;


            string where = null;

            int i = 0;
            string t1, t2;

            while (i < args.Length)
            {

                switch (args[i++])
                {
                    case "/i":
                        if (i < args.Length)
                        {
                            i++;
                            break;
                        }
                        else
                        {
                            return;
                        }

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
                        compareType = CompareAction.Schema;
                        break;
                    case "/data":
                        compareType = CompareAction.Data;
                        break;
                    case "/pk":
                        compareType = CompareAction.ParimaryKey;
                        break;
                    case "/fk":
                        compareType = CompareAction.ForeignKey;
                        break;
                    case "/name":
                        compareType = CompareAction.Name;
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
                            tableNamePattern1 = t1;
                            tableNamePattern2 = t2;
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
                            tableName = args[i++];
                            compareType = CompareAction.AllRows;

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
                        Program.Help();
                        return;

                }
            }

            if (!IsGoodConnectionString(cs1))
            {
                Console.WriteLine("invalid connection string: {0}", cs1.ConnectionString);
                return;
            }

            if (!IsGoodConnectionString(cs2))
            {
                Console.WriteLine("invalid connection string: {0}", cs2.ConnectionString);
                return;
            }

            CompareAdapter cmd = new CompareAdapter(cs1, cs2, tableNamePattern1, tableNamePattern2) { OutputFile = output };

            try
            {
                switch (compareType)
                {
                    case CompareAction.AllRows:
                        if (tableName != null)
                            cmd.AllRows(tableName, where);
                        else
                            cmd.AllRows();
                        break;

                    case CompareAction.ParimaryKey:
                        cmd.Side1.DisplayPK();
                        break;

                    case CompareAction.ForeignKey:
                        cmd.Side1.DisplayFK();
                        break;

                    case CompareAction.Data:
                    case CompareAction.Schema:
                        cmd.Run(compareType, excludedtables, PK);
                        break;

                    case CompareAction.Name:
                        foreach (string item in new Side(cs1, tableNamePattern1).TableNames)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                }
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

    }
}

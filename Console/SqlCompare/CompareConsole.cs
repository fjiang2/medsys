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
    class CompareConsole : Logger
    {
        private VAL ini;
        private VAL alias;

        private string scriptFileName = "script.sql";
        private string[] excludedtables = new string[]{};
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
                Logx("configuration file {0} not exists", fileName);
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
                    Logx("json format error in {0}", fileName);
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
                Log("Nothing is changed");
            }

            using (var writer = new StreamWriter(scriptFileName))
            {
                writer.Write(sql);
            }

            if (!string.IsNullOrEmpty(sql))
            {
                Log("output: {0}", scriptFileName);
                Log("completed.");
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
            if(x.Defined)
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
                        if (i < args.Length && parse(args[i++], out t1, out t2))
                        {
                            var s1 = alias[t1];
                            var s2 = alias[t2];
                            if (s1.Undefined)
                            {
                                Log("undefined server alias ({0}) in configuration file", t1);
                                return;
                            }
                            if (s2.Undefined)
                            {
                                Log("undefined server alias ({0}) in configuration file", t2);
                                return;
                            }

                            cs1 = new SqlConnectionStringBuilder((string)s1);
                            cs2 = new SqlConnectionStringBuilder((string)s2);
                            break;
                        }
                        else
                        {
                            Log("/s database server alias undefined");
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
                                    compareType = CompareAction.Command;
                                    break;
                                case "exec":
                                    compareType = CompareAction.Execute;
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            Log("/c argument undefined");
                            return;
                        }


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
                            Log("/S server name undefined");
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
                            Log("/U user name undefined");
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
                            Log("/P server password undefined");
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
                            Log("undefined database name");
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
                            Log("undefined table name");
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
                            Log("/e undefined excluded table names");
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
                            Log("/f undefined sql script file name");
                            return;
                        }

                    default:
                        Program.Help();
                        return;

                }
            }

            if (!IsGoodConnectionString(cs1))
            {
                Log("invalid connection string: {0}", cs1.ConnectionString);
                return;
            }

            if (!IsGoodConnectionString(cs2))
            {
                Log("invalid connection string: {0}", cs2.ConnectionString);
                return;
            }

            CompareAdapter cmd = new CompareAdapter(cs1, cs2, tableNamePattern1, tableNamePattern2);
            excludedtables = excludedtables.Select(row => row.ToUpper()).ToArray();

            try
            {
                switch (compareType)
                {
                    case CompareAction.Execute:
                        cmd.Side2.ExecuteScript(scriptFileName);

                        break;

                    case CompareAction.GenerateTableRows:
                        WriteFile(cmd.Side1.AllRowScript(excludedtables));
                        break;

                    case CompareAction.GenerateScript:
                        WriteFile(cmd.Side1.GenerateScript());
                        break;

                    case CompareAction.ShowTableName:
                        Log("server1:");
                        cmd.Side1.DisplayMatchedTableNames();
                        Log("server2:");
                        cmd.Side2.DisplayMatchedTableNames();
                        break;

                    case CompareAction.ShowTableStructure:
                        Log("server1:");
                        cmd.Side1.DisplayColumns();
                        Log("server2:");
                        cmd.Side2.DisplayColumns();
                        break;

                    case CompareAction.ShowParimaryKey:
                        Log("server1:");
                        cmd.Side1.DisplayPK();
                        Log("server2:");
                        cmd.Side2.DisplayPK();
                        break;

                    case CompareAction.ShowForeignKey:
                        Log("server1:");
                        cmd.Side1.DisplayFK();
                        Log("server2:");
                        cmd.Side2.DisplayFK();
                        break;

                    case CompareAction.CompareData:
                    case CompareAction.CompareSchema:
                        WriteFile(cmd.Run(compareType, excludedtables, PK));
                        break;

                    case CompareAction.Command:
                        DoCommand(cmd);
                        break;
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }


      
        private static bool parse(string arg, out string t1, out string t2)
        {
            if (string.IsNullOrEmpty(arg) || arg.StartsWith("/"))
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


        private Side theSide;

        private void DoCommand(CompareAdapter adapter)
        {
            this.theSide = adapter.Side1;

            Console.WriteLine("SqlCompare SQL command console");
            Console.WriteLine("type [help] to help, [;] to execute a command, [exit] to quit");
            StringBuilder builder = new StringBuilder();
            string line = null;
            while (line != "exit")
            {
                Console.Write("#:");
                line = Console.ReadLine();

                if (line == "help" || line == "?")
                {
                    Help();
                    continue;
                }

                if (line != "\r\n" && line != ";")
                    builder.AppendLine(line);

                if (line.EndsWith(";"))
                {
                    string text = builder.ToString().Trim();
                    builder.Clear();

                    if (text.EndsWith(";"))
                        text = text.Substring(0, text.Length - 1);

                    DoCommand(adapter, text);
                }
            }
        }
   
        private void DoCommand(CompareAdapter adapter, string text)
        {
            string[] A = text.Split(' ');
            string cmd = null;
            string arg1 = null;

            int n = A.Length;

            if (n > 0)
                cmd = A[0].ToLower();

            if (n == 2)
                arg1 = A[1].Trim();

            switch (cmd)
            {
                case "column":
                case "pk":
                case "fk":
                    if (n == 2)
                    {
                        TableName tname = new TableName(theSide.Provider, arg1);
                        DataTable dt = null;
                        switch (cmd)
                        {
                            case "column":
                                dt = tname.TableSchema();
                                break;

                            case "pk":
                                dt = tname.PrimaryKeySchema();
                                break;

                            case "fk":
                                dt = tname.ForeignKeySchema();
                                break;
                        }

                        if (dt != null)
                            ConsoleTable.DisplayTable(dt);
                    }
                    else
                    {
                        Console.WriteLine("invalid command");
                    }
                    break;
                
                case "table":
                    if (arg1 == null)
                        theSide.DisplayAllTableNames();
                    else
                        theSide.DisplayMatchedTableNames(arg1);
                    break;

                case "find":
                    if (arg1 != null)
                        FindColumn(arg1);
                    else
                        Log("find object undefined");
                    break;

                case "select":
                    DataSet ds = new SqlCmd(theSide.Provider, text).FillDataSet();
                    if (ds != null)
                    {
                        foreach (DataTable dt in ds.Tables)
                        {
                            ConsoleTable.DisplayTable(dt);
                            Console.WriteLine("<{0} rows>", dt.Rows.Count);
                        }
                    }
                    break;

                case "server1":
                    this.theSide = adapter.Side1;
                    Console.WriteLine("server 1 selected");
                    break;

                case "server2":
                    this.theSide = adapter.Side2;
                    Console.WriteLine("server 2 selected");
                    break;

                case "help":
                case "?":
                    Help();
                    break;

                default:
                    if (char.IsDigit(cmd[0]))
                    {
                        Log("invalid command");
                        break;
                    }

                    try
                    {
                        new SqlCmd(theSide.Provider, text).ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;
            }
        }

        private void FindColumn(string match)
        {
            string sql = @"
 SELECT 
	t.name as TableName,
    c.name AS ColumnName,
    ty.name AS DataType,
    c.max_length AS Length,
    CASE c.is_nullable WHEN 0 THEN 'NOT NULL' WHEN 1 THEN 'NULL' END AS Nullable
FROM sys.tables t 
        INNER JOIN sys.columns c ON t.object_id = c.object_id 
        INNER JOIN sys.types ty ON ty.system_type_id =c.system_type_id AND ty.name<>'sysname'
        LEFT JOIN sys.Computed_columns d ON t.object_id = d.object_id AND c.name = d.name
WHERE c.name LIKE '%{0}%'
ORDER BY c.name, c.column_id
";
            sql = string.Format(sql, match);
            var dt = new SqlCmd(theSide.Provider, sql).FillDataTable();
            ConsoleTable.DisplayTable(dt);
        }

        private static void Help()
        {
            Console.WriteLine("<Commands>");
            Console.WriteLine("server1          : switch to source server 1 (default)");
            Console.WriteLine("server2          : switch to sink server 2");
            Console.WriteLine("find pattern     : find columns");
            Console.WriteLine("table            : show all table names");
            Console.WriteLine("table pattern    : show matched table names (wildcard*,?)");
            Console.WriteLine("column tablename : show table structure");
            Console.WriteLine("pk tablename     : show table primary keys");
            Console.WriteLine("fk tablename     : show table foreign keys");
            Console.WriteLine("all sql clauses, e.g. select * from table, update...");
            Console.WriteLine("exit             : quit application");
            Console.WriteLine("help             : this help");
            Console.WriteLine("?                : this help");
        }
    }
}

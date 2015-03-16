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
using Sys;
using Tie;

namespace SqlCompare
{
    class SqlShell  
    {
        private Side theSide;
        private CompareAdapter adapter;
        private int server = 0;
        private Configuration cfg;

        public SqlShell( Configuration cfg, CompareAdapter adapter)
        {
            this.cfg = cfg;
            this.adapter =adapter;
            this.theSide = adapter.Side1;
            this.server = 1;
            
        }

        public void DoCommand()
        {

            stdio.WriteLine("SqlCompare SQL command console");
            stdio.WriteLine("type [help] to help, [;] to execute a command, [exit] to quit");
            StringBuilder builder = new StringBuilder();
            string line = null;
            while (true)
            {
            L1:
                stdio.Write("{0}> ", server);
            L2:
                line = stdio.ReadLine();

                if (line == "exit")
                    break;
                else if (line == "help" || line == "?")
                {
                    Help();
                    builder.Clear();
                    goto L1;
                }
                else if (line == "cls")
                {
                    Console.Clear();
                    goto L1;
                }

                if (line != "" && line != ";")
                    builder.AppendLine(line);

                if (line.EndsWith(";"))
                {
                    string text = builder.ToString().Trim();
                    builder.Clear();

                    if (text.EndsWith(";"))
                        text = text.Substring(0, text.Length - 1);

                    try
                    {
                        DoCommand(text);
                    }
                    catch(Exception ex)
                    {
                        stdio.WriteLine(ex.Message);
                    }
                }
                else if (builder.ToString() != "")
                {
                    stdio.Write("...");
                    goto L2;
                }
            }
        }
   
        private void DoCommand(string text)
        {
            text = text.Trim();
            if (text == string.Empty)
                return;

            string[] A = text.Split(' ', '\r');
            string cmd = null;
            string arg1 = null;
            string arg2 = null;

            int n = A.Length;

            if (n > 0)
                cmd = A[0].ToLower();

            if (n > 1)
                arg1 = A[1].Trim();

            if (n > 2)
                arg2 = A[2].Trim();

            Func<SqlConnectionStringBuilder, string> showConnection = cs=> string.Format("S={0} db={1} U={2} P={3}", cs.DataSource, cs.InitialCatalog, cs.UserID, cs.Password);
            switch (cmd)
            {
                case "show":
                    if (arg1 != null)
                        Show(arg1.ToLower(), arg2);
                    else
                        stdio.WriteLine("invalid argument");
                    break;

                case "find":
                    if (arg1 != null)
                        theSide.Provider.FindColumn(arg1);
                    else
                        stdio.WriteLine("find object undefined");
                    break;

                case "set":
                    Context.Execute(text.Replace("set", "") + ";");
                    break;

                case "run":
                    {
                        VAL result = Context.Evaluate(arg1);
                        if(result.IsNull)
                            stdio.WriteLine("undefined query function");
                        else if (result.IsInt)
                        {
                            //show error code
                        }
                        else
                        {
                            DataSet ds = new SqlCmd(theSide.Provider, (string)result[0], result[1]).FillDataSet();
                            if (ds != null)
                            {
                                foreach (DataTable dt in ds.Tables)
                                    dt.ToConsole();
                            }
                        }
                    }
                    break;

                case "select":
                    if (!Context.GetValue<bool>(Context.DATAREADER))
                    {
                        DataSet ds = new SqlCmd(theSide.Provider, text).FillDataSet();
                        if (ds != null)
                        {
                            foreach (DataTable dt in ds.Tables)
                                dt.ToConsole();
                        }
                    }
                    else
                        new SqlCmd(theSide.Provider, text).Execute(reader => reader.ToConsole(Context.GetValue<int>(Context.MAXROWS, 100)));
                    break;

                case "1":
                    this.theSide = adapter.Side1;
                    this.server = 1;
                    stdio.WriteLine("server 1 selected({0})", showConnection(theSide.CS));
                    break;

                case "2":
                    this.theSide = adapter.Side2;
                    this.server = 2;
                    stdio.WriteLine("server 2 selected({0})", showConnection(theSide.CS));
                    break;

                case "goto":
                    {
                        var conn = cfg.GetConnectionString(arg1);
                        if (conn != null)
                        {
                            this.theSide = new Side(new SqlConnectionStringBuilder(conn));
                            this.server = 3;
                            stdio.WriteLine("server 3 selected({0})", showConnection(theSide.CS));
                        }

                        else
                            stdio.WriteLine("undefined database server alias : {0}", arg1);
                    }
                    break;

                default:
                    if (char.IsDigit(cmd[0]))
                    {
                        stdio.WriteLine("invalid command");
                        break;
                    }

                    try
                    {
                        new SqlCmd(theSide.Provider, text).ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        stdio.WriteLine(ex.Message);
                    }

                    break;
            }
        }


        private void Show(string arg1, string arg2)
        {
            string[] names;

            names = new MatchedDatabase(theSide.DatabaseName, arg2, null).DefaultTableNames;
            if (names.Length == 0)
            {
                stdio.WriteLine("cannot find any table name like \"{0}\"", arg2);
                return;
            }

            switch (arg1)
            {
                case "column":
                case "pk":
                case "fk":
                    foreach (var name in names)
                    {
                        TableName tname = new TableName(theSide.Provider, name);
                        DataTable dt = null;
                        switch (arg1)
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

                        stdio.WriteLine("<{0}>", name);
                        dt.ToConsole();
                    }
                    break;

                case "table":
                    names.Select(name => new { Table = name })
                        .ToConsole();
                    break;

                case "alias":
                    {
                        var list = cfg.GetValue("alias");
                        if (list.Defined)
                        {
                            list.Select(kvp => new { Alias = (string)kvp[0].HostValue, Connection = kvp[1].ToString() })
                            .ToConsole();
                        }
                        else
                            stdio.WriteLine("connection string alias not found");
                    }
                    break;

                case "var":
                    Context.ToConsole();
                    break;
                default:
                    stdio.WriteLine("invalid argument");
                    break;
            }
        }


        private static void Help()
        {
            stdio.WriteLine("<Commands>");
            stdio.WriteLine("find pattern;         : find table name and column name");
            stdio.WriteLine("show table;           : show all table names");
            stdio.WriteLine("show table pattern;   : show matched table names (wildcard*,?)");
            stdio.WriteLine("show column tablename;: show table structure");
            stdio.WriteLine("show pk tablename;    : show table primary keys");
            stdio.WriteLine("show fk tablename;    : show table foreign keys");
            stdio.WriteLine("show alias;           : show connection-string alias list");
            stdio.WriteLine("show var;             : show variable list");
            stdio.WriteLine("set var = value;      : assign value to variable");
            stdio.WriteLine("run query(..);        : run predefined query. e.g. run query(var1=val1, var2=val2,...);");
            stdio.WriteLine("all sql clauses, e.g. select * from table, update...");
            stdio.WriteLine("1                     : switch to source server 1 (default)");
            stdio.WriteLine("2                     : switch to sink server 2");
            stdio.WriteLine("goto alias;           : switch to database server");
            stdio.WriteLine("exit                  : quit application");
            stdio.WriteLine("help                  : this help");
            stdio.WriteLine("?                     : this help");
            stdio.WriteLine("<Variable>");
            stdio.WriteLine("maxrows      : max number of row shown on select query");
            stdio.WriteLine("DataReader   : true: use SqlDataReader; false: use Fill DataSet");
        }
    }
}

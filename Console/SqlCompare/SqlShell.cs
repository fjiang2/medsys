using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys.Data;
using Sys.Data.Comparison;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
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
            this.server = 1;

            ChangeSide(adapter.Side1);
            
        }

        private void ChangeSide(Side side)
        {
            this.theSide = side;
            Context.DS.AddHostObject(Context.THESIDE, side);
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
                stdio.Write("{0}> ", theSide.Alias);
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
                            else
                                stdio.WriteLine("cannot retrieve data from server");
                        }
                    }
                    break;

                case "use":
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

                case "update":
                case "delete":
                case "insert":
                case "exec":
                case "create":
                case "alter":
                case "drop":
                    stdio.WriteLine("{0} of rows affected", new SqlCmd(theSide.Provider, text).ExecuteNonQuery());
                    break;

                case "1":
                    ChangeSide(adapter.Side1);
                    this.server = 1;
                    stdio.WriteLine("server 1 selected({0})", showConnection(theSide.CS));
                    break;

                case "2":
                    ChangeSide(adapter.Side2);
                    this.server = 2;
                    stdio.WriteLine("server 2 selected({0})", showConnection(theSide.CS));
                    break;

                case "goto":
                    {
                        var conn = cfg.GetConnectionString(arg1);
                        if (conn != null)
                        {
                            if (conn.ToLower().IndexOf("sqloledb")>=0)
                            {
                                var x1 = new OleDbConnectionStringBuilder(conn);
                                var x2 = new SqlConnectionStringBuilder();
                                x2.DataSource = x1.DataSource;
                                x2.InitialCatalog = (string)x1["Initial Catalog"];
                                x2.UserID = (string)x1["User Id"];
                                x2.Password = (string)x1["Password"];
                                conn = x2.ConnectionString;
                            }

                            ChangeSide(new Side(arg1, new SqlConnectionStringBuilder(conn)));
                            this.server = 3;
                            stdio.WriteLine("({0}) selected", showConnection(theSide.CS));
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
                    else
                    {
                        if (text.EndsWith(";"))
                            Tie.Script.Execute(text, Context.DS);
                        else
                            Tie.Script.Evaluate(text, Context.DS);
                    }

                    break;
            }
        }


        private void Show(string arg1, string arg2)
        {
            string[] tnames;
            string[] vnames;

            vnames = new MatchedDatabase(theSide.DatabaseName, arg2, null).DefaultViewNames;
            tnames = new MatchedDatabase(theSide.DatabaseName, arg2, null).DefaultTableNames;

            if (tnames.Length == 0)
            {
                stdio.WriteLine("cannot find any table name like \"{0}\"", arg2);
                return;
            }

            switch (arg1)
            {
                case "dt":
                case "pk":
                case "fk":
                case "ik":
                    foreach (var name in tnames)
                    {
                        TableName tname = new TableName(theSide.Provider, name);
                        DataTable dt = null;
                        switch (arg1)
                        {
                            case "dt":
                                dt = tname.TableSchema();
                                break;

                            case "pk":
                                dt = tname.PrimaryKeySchema();
                                break;

                            case "fk":
                                dt = tname.ForeignKeySchema();
                                break;

                            case "ik":
                                dt = tname.IdentityKeySchema();
                                break;
                        }

                        if (dt.Rows.Count > 0)
                        {
                            stdio.WriteLine("<{0}>", name);
                            dt.ToConsole();
                        }
                        else
                            stdio.WriteLine("not found at <{0}>", name);
                    }
                    break;

                case "vw":
                    foreach (var name in vnames)
                    {
                        TableName tname = new TableName(theSide.Provider, name);
                        DataTable dt = null;
                        dt = tname.ViewSchema();
                        if (dt.Rows.Count > 0)
                        {
                            stdio.WriteLine("<{0}>", name);
                            dt.ToConsole();
                        }
                        else
                            stdio.WriteLine("not found at <{0}>", name);
                    }
                    break;

                case "db":
                    new SqlCmd(theSide.Provider, "SELECT name FROM sys.databases ORDER BY name")
                        .FillDataTable()
                        .ToConsole();
                    break;

                case "table":
                    tnames.Select(name => new { Table = name })
                        .ToConsole();
                    break;
                
                case "view":
                    vnames.Select(name => new { View = name })
                        .ToConsole();
                    break;

                case "proc":
                    theSide.DatabaseName.AllProc().ToConsole();
                    break;
                
                case "index":
                    theSide.DatabaseName.AllIndices().ToConsole();
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
            stdio.WriteLine("show db;              : show all database names");
            stdio.WriteLine("show table;           : show all table names");
            stdio.WriteLine("show view;            : show all views");
            stdio.WriteLine("show proc;            : show all stored proc and func");
            stdio.WriteLine("show index;           : show all indices");
            stdio.WriteLine("show dt tablename;    : show table structure");
            stdio.WriteLine("show pk tablename;    : show table primary keys");
            stdio.WriteLine("show fk tablename;    : show table foreign keys");
            stdio.WriteLine("show ik tablename;    : show table identity keys");
            stdio.WriteLine("show vw viewnames;    : show view structure");
            stdio.WriteLine("show alias;           : show connection-string alias list");
            stdio.WriteLine("show var;             : show variable list");
            stdio.WriteLine("run query(..);        : run predefined query. e.g. run query(var1=val1,...);");
            stdio.WriteLine("all sql clauses, e.g. select/update/delete/create/drop...");
            stdio.WriteLine("1                     : switch to source server 1 (default)");
            stdio.WriteLine("2                     : switch to sink server 2");
            stdio.WriteLine("goto alias;           : switch to database server");
            stdio.WriteLine("exit                  : quit application");
            stdio.WriteLine("help                  : this help");
            stdio.WriteLine("?                     : this help");
            stdio.WriteLine("<Functions>");
            stdio.WriteLine("export(tablename, where, filename)");
            stdio.WriteLine("                      : export INSERT claues(SELECT * FROM tablename WHERE");
            stdio.WriteLine("export(tablename, filename)");
            stdio.WriteLine("                      : export INSERT claues(SELECT * FROM tablename");
            stdio.WriteLine("<Variable>");
            stdio.WriteLine("maxrows      : max number of row shown on select query");
            stdio.WriteLine("DataReader   : true: use SqlDataReader; false: use Fill DataSet");
        }
    }
}

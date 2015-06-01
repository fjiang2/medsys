﻿using System;
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

namespace sqlcon
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
            stdio.WriteLine("sqlcon(SQL Command Console)");
            stdio.WriteLine("type [help] to help, [;] to execute a command, [exit] to quit");
            StringBuilder builder = new StringBuilder();
            string line = null;
            while (true)
            {
            L1:
                stdio.Write("{0}/{1}> ", theSide.Alias, theSide.DatabaseName.Name);
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
                        stdio.ShowError("invalid argument");
                    break;

                case "find":
                    if (arg1 != null)
                        theSide.FindName(arg1);
                    else
                        stdio.ShowError("find object undefined");
                    break;

                case "run":
                    {
                        VAL result = Context.Evaluate(arg1);
                        if(result.IsNull)
                            stdio.ShowError("undefined query function");
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
                                stdio.ShowError("cannot retrieve data from server");
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
                    if (arg1 != null)
                    {
                        var conn = cfg.GetConnectionString(arg1);
                        if (conn != null)
                        {
                            Side side = new Side(arg1, new SqlConnectionStringBuilder(conn));
                            adapter = new CompareAdapter(side, adapter.Side2);
                        }
                    }

                    ChangeSide(adapter.Side1);
                    this.server = 1;
                    stdio.WriteLine("server 1 selected({0})", showConnection(theSide.CS));
                    break;

                case "2":
                    if (arg1 != null)
                    {
                        var conn = cfg.GetConnectionString(arg1);
                        if (conn != null)
                        {
                            Side side = new Side(arg1, new SqlConnectionStringBuilder(conn));
                            adapter = new CompareAdapter(adapter.Side1, side);
                        }
                    }
                    ChangeSide(adapter.Side2);
                    this.server = 2;
                    stdio.WriteLine("server 2 selected({0})", showConnection(theSide.CS));
                    break;

                case "goto":
                    if(arg1 != null)
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

                            Side side = new Side(arg1, new SqlConnectionStringBuilder(conn));
                            ChangeSide(side);
                            this.server = 3;
                          
                        }

                        else
                            stdio.ShowError("undefined database server alias : {0}", arg1);
                    }
                    else
                        stdio.ShowError("command argument missing");
                    break;
                
                case "template":
                    if (arg1 != null)
                    {
                        string sql = theSide.GenerateRowTemplate(new TableName(theSide.DatabaseName, "dbo", arg1));
                        stdio.WriteLine(sql);
                        using (var writer = cfg.OutputFile.NewStreamWriter())
                        {
                            writer.WriteLine(sql);
                        }
                    }
                    else
                        stdio.ShowError("command argument missing");
                    break;

                case "copy":
                    if (arg1 == "result")
                    {
                        if (!File.Exists(this.cfg.OutputFile))
                        {
                            stdio.ShowError("no output file found : {0}", this.cfg.OutputFile);
                            break;
                        }
                        using (var reader = new StreamReader(this.cfg.OutputFile))
                        {
                            string data = reader.ReadToEnd();
                            System.Windows.Clipboard.SetText(data);
                            stdio.WriteLine("copied to clipboard");
                        }
                    }
                    break;

                case "open":
                    if (arg1 == "log")
                    {
                        stdio.OpenLog();
                    }
                    break;

                case "compare":
                    if (arg1 != null)
                    {
                        string t1 = null;
                        string t2 = null;
                        if(arg2 != null)
                            arg2.parse(out t1, out t2);

                        MatchedDatabase m1 = new MatchedDatabase(adapter.Side1.DatabaseName, t1, cfg.excludedtables);
                        MatchedDatabase m2 = new MatchedDatabase(adapter.Side2.DatabaseName, t2, cfg.excludedtables);
                        using (var writer = cfg.OutputFile.NewStreamWriter())
                        {
                            var type = ActionType.CompareSchema;
                            if (arg1 == "data")
                                type = ActionType.CompareData;
                            else if (arg1 == "schema")
                                type = ActionType.CompareSchema;
                            else
                            {
                                stdio.ShowError("invalid command argument");
                                break;
                            }

                            var sql = adapter.Run(type, m1, m2, cfg.PK);
                            writer.Write(sql);
                        }
                        stdio.WriteLine("completed");
                    }
                    else
                        stdio.ShowError("command argument missing");
                    break;

                default:
                    if (char.IsDigit(cmd[0]))
                    {
                        stdio.ShowError("invalid command");
                        break;
                    }
                    else
                    {
                        if (text.EndsWith(";"))
                            Tie.Script.Execute(text, Context.DS);
                        else
                        {
                            var val = Tie.Script.Evaluate(text, Context.DS);
                            stdio.WriteLine(string.Format("{0} = {1}", text, val));
                        }
                    }

                    break;
            }
        }


        private void Show(string arg1, string arg2)
        {
            TableName[] tnames;
            TableName[] vnames;

            vnames = new MatchedDatabase(theSide.DatabaseName, arg2, null).DefaultViewNames;
            tnames = new MatchedDatabase(theSide.DatabaseName, arg2, null).DefaultTableNames;

            if (tnames.Length == 0 && vnames.Length == 0)
            {
                stdio.ShowError("cannot find any table/view name like \"{0}\"", arg2);
                return;
            }

            switch (arg1)
            {
                case "dt":
                case "pk":
                case "fk":
                case "ik":
                    {
                        List<string> list = new List<string>();
                        foreach (var tname in tnames)
                        {
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
                                stdio.WriteLine("<{0}>", tname.ShortName);
                                dt.ToConsole();
                            }
                            else
                            {
                                list.Add(tname.ShortName);
                                stdio.WriteLine("not found at " + tname.ShortName);
                            }
                        }

                        if (list.Count > 0)
                        {
                            stdio.WriteLine("not found on tables below");
                            list.Select(row => new { TableName = row }).ToConsole();
                        }
                    }
                    break;

                case "vw":
                    foreach (var vname in vnames)
                    {
                        DataTable dt = null;
                        dt = vname.ViewSchema();
                        if (dt.Rows.Count > 0)
                        {
                            stdio.WriteLine("<{0}>", vname.ShortName);
                            dt.ToConsole();
                        }
                        else
                            stdio.WriteLine("not found at <{0}>", vname.ShortName);
                    }
                    break;

                case "db":
                    new SqlCmd(theSide.Provider, "SELECT name FROM sys.databases ORDER BY name")
                        .FillDataTable()
                        .ToConsole();
                    break;

                case "table":
                    tnames.Select(tname => new { Schema = tname.SchemaName, Table = tname.Name })
                        .ToConsole();
                    break;
                
                case "view":
                    vnames.Select(tname => new { Schema = tname.SchemaName, View = tname.Name })
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
                            stdio.ShowError("connection string alias not found");
                    }
                    break;

                case "var":
                    Context.ToConsole();
                    break;
                default:
                    stdio.ShowError("invalid argument");
                    break;
            }
        }


        private static void Help()
        {
            stdio.WriteLine("Notes: table names support wildcard matching, e.g. Prod*,Pro?ucts");
            stdio.WriteLine("<Commands>");
            stdio.WriteLine("<compare schema> tables : compare schema of tables");
            stdio.WriteLine("<compare data> tables   : compare data of tables");
            stdio.WriteLine("<find> pattern          : find table name or column name");
            stdio.WriteLine("<show db>               : show all database names");
            stdio.WriteLine("<show table>            : show all table names");
            stdio.WriteLine("<show view>             : show all views");
            stdio.WriteLine("<show proc>             : show all stored proc and func");
            stdio.WriteLine("<show index>            : show all indices");
            stdio.WriteLine("<show dt> tablename     : show table structure");
            stdio.WriteLine("<show pk> tablename     : show table primary keys");
            stdio.WriteLine("<show fk> tablename     : show table foreign keys");
            stdio.WriteLine("<show ik> tablename     : show table identity keys");
            stdio.WriteLine("<show vw> viewnames     : show view structure");
            stdio.WriteLine("<show alias>            : show connection-string alias list");
            stdio.WriteLine("<show var>              : show variable list");
            stdio.WriteLine("<run> query(..)         : run predefined query. e.g. run query(var1=val1,...);");
            stdio.WriteLine("<1> [alias]             : switch to source server 1 (default)");
            stdio.WriteLine("<2> [alias]             : switch to sink server 2");
            stdio.WriteLine("<goto> alias            : switch to database server");
            stdio.WriteLine("<copy result>           : copy sql script ouput to clipboard");
            stdio.WriteLine("<open log>              : open log file");
            stdio.WriteLine("<exit>                  : quit application");
            stdio.WriteLine("<help>                  : this help");
            stdio.WriteLine("<?>                     : this help");
            stdio.WriteLine("<SQL>");
            stdio.WriteLine("select ... from table where ...");
            stdio.WriteLine("update table set ... where ...");
            stdio.WriteLine("delete from table where...");
            stdio.WriteLine("create table ...");
            stdio.WriteLine("drop table ...");
            stdio.WriteLine("alter ...");
            stdio.WriteLine("exec ...");
            stdio.WriteLine("<Functions>");
            stdio.WriteLine("  export(tablename, where)");
            stdio.WriteLine("                        : export INSERT script, SELECT * FROM table WHERE ...");
            stdio.WriteLine("  export(tablename)     : export INSERT script, SELECT * FROM table");
            stdio.WriteLine("<Variables>");
            stdio.WriteLine("  maxrows               : max number of row shown on select query");
            stdio.WriteLine("  DataReader            : true: use SqlDataReader; false: use Fill DataSet");
        }
    }
}

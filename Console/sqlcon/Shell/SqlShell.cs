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
        private Configuration cfg;

        private PathManager mgr;
        private Commandee commandee;

        public SqlShell(Configuration cfg, CompareAdapter adapter)
        {
            this.cfg = cfg;
            this.adapter = adapter;
            this.mgr = new PathManager(cfg);
            this.commandee = new Commandee(mgr);

            string server = cfg.GetValue<string>(Configuration._SERVER0);
            var pvd = cfg.GetProvider(server);
            if (pvd != null)
            {
                theSide = new Side(pvd);
                ChangeSide(theSide);
            }
            else if (cfg.Providers.Count() > 0)
            {
                theSide = new Side(cfg.Providers.First());
                ChangeSide(theSide);
            }
            else
            {
                throw new Exception("SQL Server not defined");
            }
        }

        private void ChangeSide(Side side)
        {
            this.theSide = side;
            Context.DS.AddHostObject(Context.THESIDE, side);

            commandee.chdir(theSide.Provider.ServerName, theSide.DatabaseName); 
        }

        public void DoCommand()
        {
            StringBuilder builder = new StringBuilder();
            string line = null;
            bool multipleLineMode = false;

            while (true)
            {
            L1:
                stdio.Write("{0}> ", mgr);
            L2:
                line = stdio.ReadLine();
            
                //ctrl-c captured
                if (line == null)
                    return;


                if (!multipleLineMode)
                {

                    if (line == "exit")
                        break;

                    switch (line)
                    {
                        case "help":
                        case "?":
                            Help();
                            builder.Clear();
                            goto L1;

                        case "cls":
                            Console.Clear();
                            goto L1;

                        default:
                            if (DoSingleLineCommand(line))
                            {
                                stdio.WriteLine();
                                goto L1;
                            }
                            break;
                    }
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
                        DoMultipleLineCommand(text);
                        multipleLineMode = false;
                        stdio.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        stdio.WriteLine(ex.Message);
                    }
                }
                else if (builder.ToString() != "")
                {
                    multipleLineMode = true;
                    stdio.Write("...");
                    goto L2;
                }
            }
        }

        private bool DoSingleLineCommand(string text)
        {
            text = text.Trim();
            if (text == string.Empty)
                return false;


            Command cmd = new Command(text, cfg);
            switch (cmd.Action)
            {
                case "set":
                    commandee.set(cmd);
                    return true;

                case "md":
                case "mkdir":
                    commandee.mkdir(cmd);
                    return true;

                case "rd":
                case "rmdir":
                    commandee.rmdir(cmd);
                    return true;
            }


            switch (cmd.Action)
            {
                case "ls":
                case "dir":
                    commandee.dir(cmd);
                    return true;

                case "cd":
                case "chdir":
                    if (cmd.arg1 != null)
                        chdir(cmd);
                    else
                        stdio.WriteLine(mgr.ToString());
                    return true;

                case "type":
                    commandee.type(cmd);
                    return true;

                case "del":
                case "erase":
                    commandee.del(cmd);
                    return true;

                case "ren":
                case "rename":
                    return true;

                case "echo":
                    stdio.WriteLine(text);
                    return true;

                case "rem":
                    return true;

                case "ver":
                    stdio.WriteLine("sqlcon [Version {0}]", System.Reflection.Assembly.GetEntryAssembly().GetName().Version);
                    return true;

                case "show":
                    if (cmd.arg1 != null)
                        Show(cmd.arg1.ToLower(), cmd.arg2);
                    else
                        stdio.ShowError("invalid argument");
                    return true;

                case "find":
                    if (cmd.arg1 != null)
                        theSide.FindName(cmd.arg1);
                    else
                        stdio.ShowError("find object undefined");
                    return true;

                case "side":
                    switch (cmd.arg1)
                    {
                        case "1":
                        case "source":
                            if (cmd.arg2 != null)
                            {
                                ConnectionProvider pvd;
                                if (cmd.arg2 == "current")
                                    pvd = theSide.Provider;
                                else
                                    pvd = cfg.GetProvider(cmd.arg2);

                                if (pvd != null)
                                {
                                    Side side = new Side(pvd);
                                    adapter = new CompareAdapter(side, adapter.Side2);
                                }
                            }

                            ChangeSide(adapter.Side1);
                            stdio.WriteLine("comparison server 1 selected({0})", showConnection(theSide.Provider));
                            return true;

                        case "2":
                        case "sink":
                            if (cmd.arg2 != null)
                            {
                                ConnectionProvider pvd;
                                if (cmd.arg2 == "current")
                                    pvd = theSide.Provider;
                                else
                                    pvd = cfg.GetProvider(cmd.arg2);

                                if (pvd != null)
                                {
                                    Side side = new Side(pvd);
                                    adapter = new CompareAdapter(adapter.Side1, side);
                                }
                            }
                            ChangeSide(adapter.Side2);
                            stdio.WriteLine("comparison server 2 selected({0})", showConnection(theSide.Provider));
                            return true;

                        case "swap":
                            adapter = new CompareAdapter(adapter.Side2, adapter.Side1);
                            stdio.WriteLine("comparison servers has been swapped, source:{0}, sink:{1}", adapter.Side1, adapter.Side2);
                            return true;

                        default:
                            ChangeSide(theSide);
                            stdio.WriteLine("working server selected({0})", showConnection(theSide.Provider));
                            return true;
                    }

                case "goto":
                    if (cmd.arg1 != null)
                    {
                        var sname = cfg.GetProvider(cmd.arg1);
                        if (sname != null)
                        {
                            Side side = new Side(sname);
                            ChangeSide(side);
                        }
                        else
                            stdio.ShowError("undefined database server name : {0}", cmd.arg1);
                    }
                    else
                        stdio.ShowError("command argument missing");
                    return true;

                case "template":
                    {
                        TableName tname = mgr.GetCurrentPath<TableName>();
                        if (tname == null)
                        {
                            stdio.ShowError("warning: table is not available");
                        }
                        else
                        {
                            string sql = theSide.GenerateRowTemplate(tname);
                            stdio.WriteLine(sql);
                            using (var writer = cfg.OutputFile.NewStreamWriter())
                            {
                                writer.WriteLine(sql);
                            }
                        }
                    }
                    return true;

                case "copy":
                    if (cmd.arg1 == "output")
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
                    return true;

                case "execute":
                    {
                        string inputfile = cfg.InputFile;
                        if (cmd.arg1 != null)
                            inputfile = cmd.arg1;
                        if (!File.Exists(inputfile))
                        {
                            stdio.ShowError("no input file found : {0}", inputfile);
                            return true;
                        }

                        var script = new SqlScript(theSide.Provider, inputfile);
                        script.Reported += (sender, e) =>
                        {
                            stdio.WriteLine("processed: {0}>{1}", e.Value1, e.Value2);
                        };
                        script.Error += (sender, e) =>
                        {
                            stdio.ShowError("line:{0}, {1}, SQL:{2}", e.Line, e.Exception.Message, e.Command);
                        };

                        script.Execute();
                        stdio.WriteLine("completed");
                    }

                    return true;

                case "open":
                    switch (cmd.arg1)
                    {
                        case "input":
                            stdio.OpenEditor(cfg.InputFile);
                            break;

                        case "output":
                            stdio.OpenEditor(cfg.OutputFile);
                            break;

                        case "schema":
                            stdio.OpenEditor(cfg.SchemaFile);
                            break;

                        case "log":
                            stdio.OpenEditor(Context.GetValue<string>("log"));
                            break;
                    }

                    return true;

                case "comp":
                case "compare":
                    if (cmd.arg1 != null)
                    {
                        string t1 = null;
                        string t2 = null;
                        if (cmd.arg2 != null)
                            cmd.arg2.parse(out t1, out t2);

                        MatchedDatabase m1 = new MatchedDatabase(adapter.Side1.DatabaseName, t1, cfg.excludedtables);
                        MatchedDatabase m2 = new MatchedDatabase(adapter.Side2.DatabaseName, t2, cfg.excludedtables);
                        using (var writer = cfg.OutputFile.NewStreamWriter())
                        {
                            var type = ActionType.CompareSchema;
                            if (cmd.arg1 == "data")
                                type = ActionType.CompareData;
                            else if (cmd.arg1 == "schema")
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
                    return true;

                //example: run func(id=20)
                case "run":
                    {
                        VAL result = Context.Evaluate(cmd.args);
                        if (result.IsNull)
                            stdio.ShowError("undefined query function");
                        else if (result.IsInt)
                        {
                            //show error code
                        }
                        else
                        {
                            if (!result.IsList && result.Size != 2)
                            {
                                stdio.ShowError("invalid format, run query like >run query(id=1)");
                                return true;
                            }

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
                    return true;

                case "export":
                    return ExportSqlScript(cmd);

                default:
                    break;
            }

            return false;
        }

        private bool ExportSqlScript(Command cmd)
        {
            string fileName = cfg.OutputFile;
            TableName tname = mgr.GetCurrentPath<TableName>();
            DatabaseName dname = mgr.GetCurrentPath<DatabaseName>();


            switch (cmd.arg1)
            {
                case "insert":
                    var node = mgr.GetCurrentNode<Locator>();
                    if (tname == null)
                    {
                        stdio.ShowError("warning: table is not available");
                        return true;
                    }

                    int count;

                    using (var writer = fileName.NewStreamWriter())
                    {
                        if (node != null)
                        {
                            stdio.WriteLine("start to generate {0} INSERT script to file: {1}", tname, fileName);
                            Locator locator = mgr.GetCombinedLocator(node);
                            count = theSide.GenerateRows(writer, tname, locator);
                            stdio.WriteLine("insert clauses (SELECT * FROM {0} WHERE {1}) generated to {2}", tname, locator, fileName);
                        }
                        else
                        {
                            count = theSide.GenerateRows(writer, tname, null);
                            stdio.WriteLine("insert clauses (SELECT * FROM {0}) generated to {1}", tname, fileName);
                        }
                    }

                    return true;

                case "create":
                    if (tname != null)
                    {
                        stdio.WriteLine("start to generate {0} CREATE TABLE script to file: {1}", tname, fileName);
                        using (var writer = fileName.NewStreamWriter())
                        {
                            writer.WriteLine(tname.GenerateScript());
                        }
                        stdio.WriteLine("completed");
                    }
                    else
                    {
                        stdio.ShowError("warning: select table first");
                    }
                    return true;

                case "database":
                    if (dname != null)
                    {
                        stdio.WriteLine("start to generate {0} script to file: {1}", dname, fileName);
                        using (var writer = fileName.NewStreamWriter())
                        {
                            writer.WriteLine(dname.GenerateScript());
                        }
                        stdio.WriteLine("completed");
                    }
                    else
                    {
                        stdio.ShowError("warning: select table first");
                    }
                    return true;

                case "schema":
                    if (dname != null)
                    {
                        stdio.WriteLine("start to generate database {0} schema to file: {1}", dname, cfg.SchemaFile);
                        using (var writer = cfg.SchemaFile.NewStreamWriter())
                        {
                            DataTable dt = dname.DatabaseSchema();
                            dt.WriteXml(writer, XmlWriteMode.WriteSchema);
                        }
                        stdio.WriteLine("completed");
                    }
                    else
                    {
                        ServerName sname = mgr.GetCurrentPath<ServerName>();
                        if (sname != null)
                        {
                            stdio.WriteLine("start to generate server {0} schema to file: {1}", sname, cfg.SchemaFile);
                            using (var writer = cfg.SchemaFile.NewStreamWriter())
                            {
                                DataSet ds = sname.ServerSchema();
                                ds.WriteXml(writer, XmlWriteMode.WriteSchema);
                            }
                            stdio.WriteLine("completed");
                        }
                        else
                            stdio.ShowError("warning: server or database is not selected");
                    }

                    return true;

                default:
                    stdio.ShowError("warning: correct format: export [insert|create|database|schema]");
                    break;
            }

            return true;
        }


        private void chdir(Command cmd)
        {
            if (commandee.chdir(cmd))
            {
                var dname = mgr.GetCurrentPath<DatabaseName>();
                if (dname != null)
                    theSide.UpdateDatabase(dname.Provider);
            }
        }

        private static string showConnection(ConnectionProvider cs)
        {
            return string.Format("S={0} db={1} U={2} P={3}", cs.DataSource, cs.InitialCatalog, cs.UserId, cs.Password);
        }

        private void DoMultipleLineCommand(string text)
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

            switch (cmd)
            {
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
                    try
                    {
                        stdio.WriteLine("{0} of row(s) affected", new SqlCmd(theSide.Provider, text).ExecuteNonQuery());
                    }
                    catch (Exception ex)
                    {
                        stdio.ShowError(ex.Message);
                    }
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
                            stdio.WriteLine(string.Format("{0} results {1}", text, val));
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
                
                case "connection":
                    {
                        var list = cfg.GetValue("servers");
                        if (list.Defined)
                        {
                            list.Select(kvp => new { Alias = (string)kvp[0].HostValue, Connection = kvp[1].ToString() })
                            .ToConsole();
                        }
                        else
                            stdio.ShowError("connection string not found");
                    }
                    break;

                case "current":
                    stdio.WriteLine("current: {0}({1})", theSide.Provider.Name, showConnection(theSide.Provider));
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
            stdio.WriteLine("exit                    : quit application");
            stdio.WriteLine("help                    : this help");
            stdio.WriteLine("?                       : this help");
            stdio.WriteLine("cls                     : clears the screen");
            stdio.WriteLine("dir,ls /?               : see more info");
            stdio.WriteLine("cd,chdir /?             : see more info");
            stdio.WriteLine("md,mkdir /?             : see more info");
            stdio.WriteLine("rd,rmdir /?             : see more info");
            stdio.WriteLine("type /?                 : see more info");
            stdio.WriteLine("set /?                  : see more info");
            stdio.WriteLine("del,erase /?            : see more info");
            stdio.WriteLine("ren,rename /?           : see more info");
            stdio.WriteLine("echo                    : display message");
            stdio.WriteLine("rem                     : records comments/remarks");
            stdio.WriteLine("ver                     : display version");
            stdio.WriteLine();
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
            stdio.WriteLine("<show connection>       : show connection-string list");
            stdio.WriteLine("<show current>          : show current active connection-string");
            stdio.WriteLine("<show var>              : show variable list");
            stdio.WriteLine("<run> query(..)         : run predefined query. e.g. run query(var1=val1,...);");
            stdio.WriteLine("<side>                  : switch to default server");
            stdio.WriteLine("<side 1> [path]|current : switch to comparison source server 1");
            stdio.WriteLine("<side 2> [path]|current : switch to comparison sink server 2");
            stdio.WriteLine("<side swap>             : swap source server and sink server");
            stdio.WriteLine("<goto> path             : switch to database server");
            stdio.WriteLine("<copy output>           : copy sql script ouput to clipboard");
            stdio.WriteLine("<schema>                : generate current database schema");
            stdio.WriteLine("<open log>              : open log file");
            stdio.WriteLine("<open input>            : open input file");
            stdio.WriteLine("<open output>           : open output file");
            stdio.WriteLine("<open schema>           : open schema file");
            stdio.WriteLine("<export insert>         : export INSERT INTO script");
            stdio.WriteLine("<export create>         : export CREATE TABLE script");
            stdio.WriteLine("<export database>       : export CREATE TABLE script for all tables");
            stdio.WriteLine("<export schema>         : export database schema xml file");
            stdio.WriteLine("<execute inputfile>     : execute sql script file");
            stdio.WriteLine();
            stdio.WriteLine("type [;] to execute following SQL script or functions");
            stdio.WriteLine("<SQL>");
            stdio.WriteLine("select ... from table where ...");
            stdio.WriteLine("update table set ... where ...");
            stdio.WriteLine("delete from table where...");
            stdio.WriteLine("create table ...");
            stdio.WriteLine("drop table ...");
            stdio.WriteLine("alter ...");
            stdio.WriteLine("exec ...");
            stdio.WriteLine("<Variables>");
            stdio.WriteLine("  maxrows               : max number of row shown on select query");
            stdio.WriteLine("  DataReader            : true: use SqlDataReader; false: use Fill DataSet");
            stdio.WriteLine();
        }
    }
}

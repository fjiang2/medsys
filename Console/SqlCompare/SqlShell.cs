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
    class SqlShell : stdio
    {

        private Side theSide;
        private CompareAdapter adapter;
        private int server = 0;
        public SqlShell(CompareAdapter adapter)
        {
            this.adapter =adapter;
            this.theSide = adapter.Side1;
            this.server = 1;
        }

        public void DoCommand()
        {

            WriteLine("SqlCompare SQL command console");
            WriteLine("type [help] to help, [;] to execute a command, [exit] to quit");
            StringBuilder builder = new StringBuilder();
            string line = null;
            while (true)
            {
            L1:
                Write("{0}> ", server);
            L2:
                line = ReadLine();

                if (line == "exit")
                    break;
                else if (line == "help" || line == "?")
                {
                    Help();
                    builder.Clear();
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

                    DoCommand(text);
                }
                else if (builder.ToString() != "")
                {
                    Console.Write("...");
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
                    if(arg1 != null)
                        Show(arg1.ToLower(), arg2);
                    else
                        WriteLine("invalid argument");
                    break;

                case "find":
                    if (arg1 != null)
                        FindColumn(arg1);
                    else
                        WriteLine("find object undefined");
                    break;

                case "select":
                    DataSet ds = new SqlCmd(theSide.Provider, text).FillDataSet();
                    if (ds != null)
                    {
                        foreach (DataTable dt in ds.Tables)
                        {
                            dt.ToConsole();
                            WriteLine("<{0} row{0}>", dt.Rows.Count, dt.Rows.Count > 1 ? "s" : "");
                        }
                    }
                    break;

                case "1":
                    this.theSide = adapter.Side1;
                    this.server = 1;
                    WriteLine("server 1 selected({0})", showConnection(theSide.CS));
                    break;

                case "2":
                    this.theSide = adapter.Side2;
                    this.server = 2;
                    WriteLine("server 2 selected({0})", showConnection(theSide.CS));
                    break;

                case "goto":
                    if (CompareConsole.binding.ContainsKey(arg1))
                    {
                        this.theSide = new Side(new SqlConnectionStringBuilder(CompareConsole.binding[arg1]));
                        this.server = 3;
                        WriteLine("server 3 selected({0})", showConnection(theSide.CS));
                    }

                    else
                        WriteLine("undefined database server alias : {0}", arg1);
                    break;

                case "help":
                case "?":
                    Help();
                    break;

                default:
                    if (char.IsDigit(cmd[0]))
                    {
                        WriteLine("invalid command");
                        break;
                    }

                    try
                    {
                        new SqlCmd(theSide.Provider, text).ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        WriteLine(ex.Message);
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
                WriteLine("cannot find any table name like \"{0}\"", arg2);
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

                        WriteLine("<{0}>", name);
                        dt.ToConsole();
                    }
                    break;

                case "table":
                    names.Select(name => new { Table = name })
                        .ToConsole(row => new object[] { row.Table });
                    break;

                case "alias":
                    CompareConsole.binding
                        .Select(kvp => new { Alias = kvp.Key, Connection = kvp.Value })
                        .ToConsole(row => new object[] { row.Alias, row.Connection });
                    break;

                default:
                    WriteLine("invalid argument");
                    break;
            }
        }


        private void FindColumn(string match)
        {
            string sql = "SELECT name AS TableName FROM sys.tables WHERE name LIKE @PATTERN";
            var dt = new SqlCmd(theSide.Provider, sql, new { PATTERN = "%" + match + "%" }).FillDataTable();
            dt.ToConsole();
            WriteLine("<{0} Table{1}>", dt.Rows.Count, dt.Rows.Count > 1 ? "s" : "");

            sql = @"
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
WHERE c.name LIKE @PATTERN
ORDER BY c.name, c.column_id
";
            dt = new SqlCmd(theSide.Provider, sql, new { PATTERN = "%" + match + "%" }).FillDataTable();
            dt.ToConsole();
            WriteLine("<{0} Column{1}>", dt.Rows.Count, dt.Rows.Count > 1 ? "s" : "");
        }

        private static void Help()
        {
            Console.WriteLine("<Commands>");
            Console.WriteLine("find pattern          : find table name and column name");
            Console.WriteLine("show table            : show all table names");
            Console.WriteLine("show table pattern    : show matched table names (wildcard*,?)");
            Console.WriteLine("show column tablename : show table structure");
            Console.WriteLine("show pk tablename     : show table primary keys");
            Console.WriteLine("show fk tablename     : show table foreign keys");
            Console.WriteLine("all sql clauses, e.g. select * from table, update...");
            Console.WriteLine("1                     : switch to source server 1 (default)");
            Console.WriteLine("2                     : switch to sink server 2");
            Console.WriteLine("goto alias            : switch to database server");
            Console.WriteLine("exit                  : quit application");
            Console.WriteLine("help                  : this help");
            Console.WriteLine("?                     : this help");
        }
    }
}

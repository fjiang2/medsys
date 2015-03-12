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
                        WriteLine("invalid command");
                    }
                    break;
                
                case "table":
                    DisplayTableNames(new MatchedTable(theSide.DatabaseName, arg1).DefaultTableNames);
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
                            ConsoleTable.DisplayTable(dt);
                            WriteLine("<{0} rows>", dt.Rows.Count);
                        }
                    }
                    break;

                case "1":
                    this.theSide = adapter.Side1;
                    this.server = 1;
                    WriteLine("server 1 selected");
                    break;

                case "2":
                    this.theSide = adapter.Side2;
                    this.server = 2;
                    WriteLine("server 2 selected");
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


        public void DisplayTableNames(string[] names)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Table Name");
            foreach (string item in names)
            {
                var newRow = dt.NewRow();
                newRow[0] = item;
                dt.Rows.Add(newRow);
            }

            ConsoleTable.DisplayTable(dt);
        }


        private void FindColumn(string match)
        {
            string sql = "SELECT name AS TableName FROM sys.tables WHERE name LIKE @PATTERN";
            var dt = new SqlCmd(theSide.Provider, sql, new { PATTERN = "%" + match + "%" }).FillDataTable();
            ConsoleTable.DisplayTable(dt);
            WriteLine("<Table>");
            
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
            dt = new SqlCmd(theSide.Provider, sql, new { PATTERN = "%"+ match+"%" }).FillDataTable();
            ConsoleTable.DisplayTable(dt);
            WriteLine("<Column>");
        }

        private static void Help()
        {
            Console.WriteLine("<Commands>");
            Console.WriteLine("1                : switch to source server 1 (default)");
            Console.WriteLine("2                : switch to sink server 2");
            Console.WriteLine("find pattern     : find table name and column name");
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

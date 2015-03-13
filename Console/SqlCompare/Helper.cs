using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace SqlCompare
{
    static class Helper
    {


        public static void ToConsole<T>(this IEnumerable<T> source, Func<T, object[]> selector)
        {
            string[] columns = typeof(T).GetProperties().Select(p => p.Name).ToArray();

            var D = new ConsoleTable(columns.Length);

            D.MeasureWidth(columns);
            foreach (var row in source)
            {
                D.MeasureWidth(selector(row));
            }

            D.DisplayLine();
            D.DisplayLine(columns);
            D.DisplayLine();

            if (source.Count() == 0)
                return;

            foreach (var row in source)
            {
                D.DisplayLine(selector(row));
            }

            D.DisplayLine();
        }


        public static void ToConsole(this DbDataReader reader, int maxRow = 0)
        {
            while (reader.HasRows)
            {
                DataTable schemaTable = reader.GetSchemaTable();

                var schema = schemaTable.AsEnumerable().Select(row => new { Name = row.Field<string>("ColumnName"), Type = row.Field<Type>("DataType") });

                string[] columns = schema.Select(row => row.Name).ToArray();
                Type[] types = schema.Select(row => row.Type).ToArray();

                var D = new ConsoleTable(columns.Length);

                D.MeasureWidth(columns);
                D.MeasureWidth(types);

                D.DisplayLine();
                D.DisplayLine(columns);
                D.DisplayLine();

                if (!reader.HasRows)
                    return;

                object[] values = new object[columns.Length];
                int count = 0;
                bool limited = false;
                while (reader.Read())
                {
                    reader.GetValues(values);
                    D.DisplayLine(values);

                    if (++count == maxRow)
                    {
                        limited = true;
                        break;
                    }

                }

                D.DisplayLine();
                Console.WriteLine("<{0} row{1}> {2}",
                    count,
                    count > 1 ? "s" : "",
                    limited ? "limit reached" : ""
                    );

                reader.NextResult();
            }

        }


        public static void ToConsole(this DataTable table)
        {

            List<string> list = new List<string>();
            foreach (DataColumn column in table.Columns)
                list.Add(column.ColumnName);

            string[] columns = list.ToArray();

            var D = new ConsoleTable(columns.Length);

            D.MeasureWidth(columns);
            foreach (DataRow row in table.Rows)
            {
                D.MeasureWidth(row.ItemArray);
            }

            D.DisplayLine();
            D.DisplayLine(columns);
            D.DisplayLine();

            if (table.Rows.Count == 0)
                return;

            foreach (DataRow row in table.Rows)
            {
                D.DisplayLine(row.ItemArray);
            }

            D.DisplayLine();
            Console.WriteLine("<{0} row{1}>", table.Rows.Count, table.Rows.Count > 1 ? "s" : "");
        }


        public static bool parse(this string arg, out string t1, out string t2)
        {
            if (string.IsNullOrEmpty(arg) || arg.StartsWith("/"))
            {
                t1 = null;
                t2 = null;
                return false;
            }

            string[] x = arg.Split(':');
            if (x.Length == 1)
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



        public static bool IsGoodConnectionString(this SqlConnectionStringBuilder cs)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlCompare
{
    static class Helper
    {

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SqlCompare
{
    public class ConsoleTable
    {
        const char SPACE = ' ';
        const char CROSS = '+';
        const char VER = '|';
        const char HOR = '-';

        private int[] W;
        private DataTable dt;

        private ConsoleTable(DataTable table)
        {
            this.dt = table;

            W = new int[table.Columns.Count];
            for (int i = 0; i < W.Length; i++)
            {
                DataColumn c = table.Columns[i];

                if (c.ColumnName.Length > W[i])
                    W[i] = c.ColumnName.Length;
            }

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < W.Length; i++)
                {
                    string item = "NULL";
                    if (row[i] != DBNull.Value)
                        item = row[i].ToString();

                    if (item.Length > W[i])
                        W[i] = item.Length;
                }
            }
        }

        private void Display()
        {
            var line = Enumerable.Repeat("",W.Length).ToArray();
            DisplayLine(line, CROSS, HOR);

            List<string> list = new List<string>();
            foreach (DataColumn column in dt.Columns)
                list.Add(column.ColumnName);

            DisplayLine(list.ToArray(), VER, SPACE);
            DisplayLine(line, CROSS, HOR);

            if (dt.Rows.Count == 0)
                return;

            string[] L = new string[W.Length];
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < W.Length; i++)
                {
                    L[i] = "NULL";
                    if (row[i] != DBNull.Value)
                        L[i] = row[i].ToString();
                }

                DisplayLine(L, VER, SPACE);
            }
            
            DisplayLine(line, CROSS, HOR);
        }

        private void DisplayLine(string[] row, char delimiter, char sp)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(delimiter).Append(sp);

            for (int i = 0; i < W.Length; i++)
            {

                int d = W[i] - row[i].Length;

                if (d > 0)
                    builder.Append(row[i]).Append(new string(sp, d));
                else
                    builder.Append(row[i].Substring(0, W[i]));

                if (i < W.Length - 1)
                    builder.Append(sp).Append(delimiter).Append(sp);
                else
                    builder.Append(sp).Append(delimiter);
            }

            Console.WriteLine(builder.ToString());
        }

        public static void DisplayTable(DataTable dt)
        {
            var x = new ConsoleTable(dt);
            x.Display();
        }
    }
}

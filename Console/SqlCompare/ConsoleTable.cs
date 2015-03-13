using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SqlCompare
{
    class ConsoleTable : stdio
    {
        private const char SPACE = ' ';
        private const char CROSS = '+';
        private const char VER = '|';
        private const char HOR = '-';
        private const char DOT = '.';

        private int[] W;

        public ConsoleTable(int length)
        {
            this.W = new int[length];
        }

        public void DisplayLine()
        {
            var line = Enumerable.Repeat("", W.Length).ToArray();
            DisplayLine(line, CROSS, HOR);
        }

        public void DisplayLine(object[] row)
        {
            DisplayLine(row, VER, SPACE);
        }

        private void DisplayLine(object[] columns, char delimiter, char sp)
        {
       
            StringBuilder builder = new StringBuilder();

            builder.Append(delimiter).Append(sp);

            for (int i = 0; i < W.Length; i++)
            {
                string cell = Cell(columns[i]);
                int d = W[i] - cell.Length;

                if (d > 0)
                    builder.Append(cell).Append(new string(sp, d));
                else
                    builder.Append(cell.Substring(0, W[i]));


                builder.Append(d >= 0 ? sp : DOT).Append(delimiter);
                if (i < W.Length - 1)
                    builder.Append(sp);
            }

            string text = builder.ToString();
            int w = Console.WindowWidth;
            
            if(text.Length > w)
                WriteLine(text.Substring(0,w-1));
            else
                WriteLine(text);
        }

        public void MeasureWidth(Type[] types)
        {
            for (int i = 0; i < W.Length; i++)
            {
                if (types[i] == typeof(DateTime))
                {
                    if (W[i] < 22)
                        W[i] = 22;
                }
            }

        }
        public void MeasureWidth(object[] columns)
        {
            for (int i = 0; i < W.Length; i++)
            {
                string item = Cell(columns[i]);

                if (item.Length > W[i])
                    W[i] = item.Length;
            }

        }

        private string Cell(object cell)
        {
            if (cell == null)
                return "null";

            else if (cell == DBNull.Value)
                return "NULL";

            else
                return cell.ToString().Trim();
        }

     
    }
}

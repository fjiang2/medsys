﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace sqlcon
{
    class ConsoleTable  
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

            stdio.TrimWriteLine(text);
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

        public void MeasureWidth(int[] maxWidth)
        {
            for (int i = 0; i < W.Length; i++)
            {
                if (maxWidth[i] < 20)
                    W[i] = maxWidth[i];
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
            else if (cell is byte[])
            {
                return "0x" + BitConverter.ToString((byte[])cell).Replace("-", "");
            }
            else
            {
                string result = cell.ToString().Trim();

                //when cell includes a big string with letter [\n]
                if (result.Length > 200)
                    result = result
                        .Replace("\r\n", " ")
                        .Replace("\n", " ")
                        .Replace("\t", " ");

                return result;
            }
        }

     
    }
}

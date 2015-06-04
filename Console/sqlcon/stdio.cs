﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sqlcon
{
    sealed class stdio
    {

        private static StreamWriter writer = null;
        static stdio()
        {
            string fileName = Context.GetValue<string>("log", "sqlcon.log");
            writer = fileName.NewStreamWriter();
        }

        public static void Close()
        {
            if(writer != null)
                writer.Close();
        }

        public static void OpenEditor(string fileName)
        {
            string editor = Context.GetValue<string>("editor");
            
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.ErrorDialog = true;
            process.StartInfo.UseShellExecute = false;
            //process.StartInfo.WorkingDirectory = startin;
            process.StartInfo.FileName = editor;
            process.StartInfo.Arguments = fileName;
            if (File.Exists(fileName))
                process.Start();
            else
                stdio.ShowError("file not found: {0}", fileName);
        }

        public static void Write(string format, params object[] args)
        {
            Console.Write(format, args);

            if (writer != null)
            {
                writer.Write(format, args);
                writer.Flush();
            }
        }

        public static void WriteLine()
        {
            WriteLine("");
        }

        public static void WriteLine(string value)
        {
            Console.WriteLine(value);

            if (writer != null)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public static void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            writer.WriteLine(format, args);
            writer.Flush();
        }

        public static void DisplayTitle(string value)
        {
            var keep = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(value);
            Console.ForegroundColor =keep;

            if (writer != null)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public static void ShowError(string format, params object[] args)
        {
            string value = string.Format(format, args);
            var keep = Console.ForegroundColor;
            //Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(value);
            Console.ForegroundColor = keep;

            if (writer != null)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public static void TrimWriteLine(string value)
        {
            int w = Console.WindowWidth;

            if (value.Length > w)
                Console.WriteLine(value.Substring(0, w - 1));
            else
                Console.WriteLine(value);

            if (writer != null)
            {
                writer.WriteLine(value);
                writer.Flush();
            }
        }

        public static string ReadLine()
        {
            string line = Console.ReadLine();
            
            if (writer != null)
            {
                writer.WriteLine(line);
                writer.Flush();
            }
            
            return line;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SqlCompare
{
    sealed class stdio
    {

        private static StreamWriter writer = null;
        static stdio()
        {
            var log = Context.cfg["log"];
            if (log.Defined)
            {
                writer = new StreamWriter((string)log);
            }
        }

        public static void Close()
        {
            if(writer != null)
                writer.Close();
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

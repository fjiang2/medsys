using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCompare
{
    sealed class stdio
    {
        public static void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }

        public static void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public static void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

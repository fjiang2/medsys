using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCompare
{
    class stdio
    {
        protected void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }

        protected void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        protected void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        protected string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

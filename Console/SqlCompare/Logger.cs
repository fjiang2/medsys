using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCompare
{
    class Logger
    {
        public static void Logx(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        protected void Log(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}

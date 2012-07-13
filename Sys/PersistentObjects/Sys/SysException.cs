using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{

   
    public class SysException : Exception
    {
        public static Action<string, string> DefaultExceptionHandler =
            delegate(string title, string message)
            {
                Console.WriteLine(title);
                Console.WriteLine(message);
            };

        MessageLevel level;
        ExceptionLevel clss;



        public SysException(MessageLevel level, string format, params object[] args)
            :base(string.Format(format, args))
        {
            this.level = level;
            this.clss = ExceptionLevel.None;
        }

        public SysException(string format, params object[] args)
            : this(MessageLevel.Error, format, args)
        {

        }

        public SysException(ExceptionLevel clss, string message)
            :base(message)
        {
            this.level = MessageLevel.Error; 
            this.clss = clss;
        }

        public MessageLevel Level
        {
            get
            {
                return this.level;
            }
        }


        public ExceptionLevel ExceptionClass
        {
            get { return this.clss; }
        }

        public override string  ToString()
        {
 	        return this.Message;
        }
    }
}

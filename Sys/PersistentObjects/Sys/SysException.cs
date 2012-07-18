﻿using System;
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

        private Message msg;

        public SysException(MessageLevel level, string format, params object[] args)
            :base(string.Format(format, args))
        {
            this.msg = new Message(level, string.Format(format, args))
                .HasCode((int)MessageCode.None);
        }

        public SysException(string format, params object[] args)
            : this(MessageLevel.Error, format, args)
        {

        }

        public SysException(MessageCode code, string message)
            :base(message)
        {
            this.msg = new Message(MessageLevel.Error, message)
                .HasCode((int)code);
        }

        public Message SysMessage
        {
            get
            {
                return this.msg;
            }
        }


        public MessageCode MessageCode
        {
            get { return (MessageCode)this.msg.Code; }
        }

        public override string  ToString()
        {
 	        return this.msg.ToString();
        }
    }
}

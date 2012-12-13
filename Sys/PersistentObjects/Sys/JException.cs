using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    /// <summary>
    /// Exception class 
    /// </summary>
    public class JException : Exception
    {
        /// <summary>
        /// define default exception handler
        /// </summary>
        public static Action<string, string> DefaultExceptionHandler =
            delegate(string title, string message)
            {
                Console.WriteLine(title);
                Console.WriteLine(message);
            };

        
        private Message msg;


        /// <summary>
        /// construct Exception by message and level
        /// </summary>
        /// <param name="level"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public JException(MessageLevel level, string format, params object[] args)
            :base(string.Format(format, args))
        {
            this.msg = new Message(level, string.Format(format, args))
                .HasCode((int)MessageCode.None);
        }


        /// <summary>
        /// construct Exception by message
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public JException(string format, params object[] args)
            : this(MessageLevel.Error, format, args)
        {

        }


        /// <summary>
        /// construct Exception by message code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public JException(MessageCode code, string message)
            :base(message)
        {
            this.msg = new Message(MessageLevel.Error, message)
                .HasCode((int)code);
        }

        /// <summary>
        /// return message
        /// </summary>
        /// <returns></returns>
        public Message GetMessage()
        {
            return this.msg;
        }

        /// <summary>
        /// return message code
        /// </summary>
        public MessageCode MessageCode
        {
            get { return (MessageCode)this.msg.Code; }
        }


        /// <summary>
        /// return message
        /// </summary>
        /// <returns></returns>
        public override string  ToString()
        {
 	        return this.msg.ToString();
        }
    }
}

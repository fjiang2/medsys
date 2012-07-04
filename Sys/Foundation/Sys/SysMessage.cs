using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
  

    public class SysMessage
    {
        string message;
        MessageLevel level;

        public SysMessage(MessageLevel level, string format, params object[] args)
            : base()
        {
            this.level = level;
            this.message = string.Format(format, args);
        }

        public SysMessage(string format, params object[] args)
            : this(MessageLevel.error, format, args)
        {

        }

        public MessageLevel Level
        {
            get
            {
                return this.level;
            }
        }

        public override string ToString()
        {
            return this.message;
        }
    }
}

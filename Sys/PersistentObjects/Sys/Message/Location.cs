using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class MessageLocation
    {
        public readonly int line;
        public readonly string location;

        public MessageLocation(int line)
        {
            this.line = line;
        }
        public MessageLocation(string location)
        {
            this.location = location;
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(location))
                return string.Format("Line {0}", line);
            else
                return location;
        }
    }
}

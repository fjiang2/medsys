using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class MessageLocation
    {
        public readonly object location;

        //string file;
        //int line;
        //int column;

        public MessageLocation(int line)
        {
            this.location = line;
        }
        public MessageLocation(string location)
        {
            this.location = location;
        }

        public int Line
        {
            get
            {
                if (location is int)
                    return (int)location;
                
                throw new InvalidCastException();
            }
        }

        public override string ToString()
        {
            if (location is int)
                return string.Format("Line {0}", location);
            else
                return location.ToString();
        }
    }
}

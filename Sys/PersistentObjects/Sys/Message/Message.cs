using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class Message
    {
        public int ID;
        public MessageLevel Level;
        public string Description;
        public string Location;

        public Message()
        {
            this.ID = 0;
            this.Level = MessageLevel.error;
        }

        public Message(MessageLevel level, string format, params object[] args)
            : base()
        {
            this.Level = level;
            this.Description = string.Format(format, args);
        }

        public Message(string format, params object[] args)
            : this(MessageLevel.error, format, args)
        {

        }


        public override int GetHashCode()
        {
            return Location.GetHashCode() + Level.GetHashCode() + Description.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Message item = (Message)obj;
            return this.Location == item.Location && this.Level == item.Level && this.Description == item.Description;
        }

        public override string ToString()
        {
            return string.Format("{0} @ {1}", this.Description, this.Location);
        }
    }
}

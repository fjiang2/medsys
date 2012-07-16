using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class Message
    {
        public int Code;
        public MessageLevel Level;
        private string description;
        public string Location;

        /// <summary>
        /// Message's owner
        /// </summary>
        public object sender;

        public Message(string description)
        {
            this.Code = 0;
            this.description = description;
            this.Level = MessageLevel.Error;
        }

        public Message(MessageLevel level, string format, params object[] args)
            : base()
        {
            this.Level = level;
            this.description = string.Format(format, args);
        }

        public string Description
        {
            get { return this.description; }
        }

        public override int GetHashCode()
        {
            return Location.GetHashCode() + Level.GetHashCode() + description.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Message message = (Message)obj;
            return this.Code == message.Code && this.Location == message.Location && this.Level == message.Level && this.description == message.description;
        }

        public override string ToString()
        {
            return string.Format("{0} @ {1}", this.description, this.Location);
        }
    }
}

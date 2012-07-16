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
            this.Level = MessageLevel.None;
        }

        public Message(MessageLevel level, string description)
            : base()
        {
            this.Level = level;
            this.description = description;
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
            StringBuilder builder = new StringBuilder();
            if (Code != 0)
                builder.AppendFormat("{0}({1})", this.Level, this.Code);
            else
                builder.Append(this.Level);

            builder.Append(" : ");

            if(string.IsNullOrEmpty(this.Location))
                builder.Append(this.description);
            else
                builder.AppendFormat("{0} @ {1}", this.description, this.Location);

            return builder.ToString();
        }
    }
}

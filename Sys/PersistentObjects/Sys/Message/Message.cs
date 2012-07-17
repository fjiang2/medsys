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



        public static Message Error(string description)
        {
            return Error(0, description, "");
        }

        public static Message Error(string description, string location)
        {
            return Error(0, description, location);
        }

        public static Message Error(int code, string description, string location)
        {
            Message message = new Message(MessageLevel.Error, description);
            message.Code = code;
            message.Location = location;
            return message;
        }

        public static Message Warning(string description, string location)
        {
            return Warning(0, description, location);
        }

        public static Message Warning(int code, string description, string location)
        {
            Message message = new Message(MessageLevel.Warning, description);
            message.Code = code;
            message.Location = location;
            return message;
        }

        public static Message Information(string description)
        {
            return Information(0, description, "");
        }

        public static Message Information(string description, string location)
        {
            return Information(0, description, location);
        }

        public static Message Information(int code, string description, string location)
        {
            Message message = new Message(MessageLevel.Information, description);
            message.Code = code;
            message.Location = location;
            return message;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class Message
    {
        public readonly MessageLevel Level;
        public readonly string Description;

        private int code;
        private MessageLocation location;

        /// <summary>
        /// Message's owner
        /// </summary>
        private object sender;



        public Message(MessageLevel level, string description)
        {
            this.Level = level;
            this.Description = description;
        }


        public Message HasCode(int code)
        {
            this.code = code;
            return this;
        }
        
        public Message From(object sender)
        {
            this.sender = sender;
            return this;
        }
        
        public Message At(MessageLocation location)
        {
            this.location = location;
            return this;
        }


        public int Code
        {
            get { return this.code; }
        }

      
        public MessageLocation Location
        {
            get { return this.location;}
        }

        public object Sender
        {
            get { return this.sender; }
        }

        #region GetHashCode/Equals/ToString

        public override int GetHashCode()
        {
            return location.GetHashCode() + Level.GetHashCode() + Description.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Message message = (Message)obj;
            return this.code == message.code && this.location == message.location && this.Level == message.Level && this.Description == message.Description;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if (Code != 0)
                builder.AppendFormat("{0}({1})", this.Level, this.code);
            else
                builder.Append(this.Level);

            builder.Append(" : ");

            if(this.location == null)
                builder.Append(this.Description);
            else
                builder.AppendFormat("{0} @ {1}", this.Description, this.location);

            return builder.ToString();
        }
        
        #endregion

        public static Message Error(string description)
        {
            return Error(0, description);
        }

        public static Message Error(int code, string description)
        {
            Message message = new Message(MessageLevel.Error, description);
            message.code = code;
            return message;
        }


        public static Message Warning(string description)
        {
            return Warning(0, description);
        }

        public static Message Warning(int code, string description)
        {
            Message message = new Message(MessageLevel.Warning, description);
            message.code = code;
            return message;
        }

        public static Message Information(string description)
        {
            return Information(0, description);
        }


        public static Message Information(int code, string description)
        {
            Message message = new Message(MessageLevel.Information, description);
            message.code = code;
            return message;
        }
    }
}

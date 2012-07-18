using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class Message
    {
        public int Code;
        public readonly MessageLevel Level;
        public readonly string Description;
        public MessageLocation Location;

        /// <summary>
        /// Message's owner
        /// </summary>
        public object sender;
        private MessagePlace place;



        public Message(MessageLevel level, string description)
        {
            this.Level = level;
            this.Description = description;
            this.place = MessagePlace.StatusBar;
        }

        public Message At(MessageLocation location)
        {
            this.Location = location;
            return this;
        }

        public Message To(MessagePlace place)
        {
            this.place = place;
            return this;
        }

        #region GetHashCode/Equals/ToString

        public override int GetHashCode()
        {
            return Location.GetHashCode() + Level.GetHashCode() + Description.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Message message = (Message)obj;
            return this.Code == message.Code && this.Location == message.Location && this.Level == message.Level && this.Description == message.Description;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if (Code != 0)
                builder.AppendFormat("{0}({1})", this.Level, this.Code);
            else
                builder.Append(this.Level);

            builder.Append(" : ");

            if(this.Location == null)
                builder.Append(this.Description);
            else
                builder.AppendFormat("{0} @ {1}", this.Description, this.Location);

            return builder.ToString();
        }
        
        #endregion


        public static Message Error(string description)
        {
            return Error(description, null);
        }

        public static Message Error(string description, MessageLocation location)
        {
            return Error(0, description, location);
        }

        public static Message Error(int code, string description, MessageLocation location)
        {
            Message message = new Message(MessageLevel.Error, description);
            message.Code = code;
            message.Location = location;
            return message;
        }

        public static Message Warning(string description)
        {
            return Warning(description, null);
        }

        public static Message Warning(string description, MessageLocation location)
        {
            return Warning(0, description, location);
        }

        public static Message Warning(int code, string description, MessageLocation location)
        {
            Message message = new Message(MessageLevel.Warning, description);
            message.Code = code;
            message.Location = location;
            return message;
        }

        public static Message Information(string description)
        {
            return Information(description, null);
        }

        public static Message Information(string description, MessageLocation location)
        {
            return Information(0, description, location);
        }

        public static Message Information(int code, string description, MessageLocation location)
        {
            Message message = new Message(MessageLevel.Information, description);
            message.Code = code;
            message.Location = location;
            return message;
        }
    }
}

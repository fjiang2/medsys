using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using System.Data;

namespace Sys
{
    public class MassageManager
    {
        List<MessageItem> errors = new List<MessageItem>();

        public delegate void MessageHandler(object sender, MessageEventArgs e);
    
        public event MessageHandler MessageChanged;

        public MassageManager()
        {
        }

        public void Post()
        {
            if (MessageChanged != null)
                MessageChanged(this, new MessageEventArgs(this.errors));
        }


        public void Clear()
        {
            errors.Clear();
        }

        public void Error(int code, string description, string location)
        {
            MessageItem item = new MessageItem();
            item.ID = code;
            item.Level = MessageLevel.error;
            item.Message = description;
            item.Location = location;
            Add(item);
        }

        public void Warning(int code, string description, string location)
        {
            MessageItem item = new MessageItem();
            item.ID = code;
            item.Level = MessageLevel.warning;
            item.Message = description;
            item.Location = location;
            Add(item);
        }

        public void Message(int code, string description, string location)
        {
            MessageItem item = new MessageItem();
            item.ID = code;
            item.Level = MessageLevel.information;
            item.Message = description;
            item.Location = location;

            Add(item);
        }

        private void Add(MessageItem item)
        {
            if (errors.Contains(item))
                return ;

            this.errors.Add(item);
        }
    }

    public class MessageEventArgs : EventArgs
    {
        public readonly List<MessageItem> Errors;

        public MessageEventArgs(List<MessageItem> errors)
        {
            this.Errors = errors;
        }
    }

    public class MessageItem  
    {
        public int ID;
        public MessageLevel Level;
        public string Message;
        public string Location;

        public MessageItem()
        {
            this.ID = 0;
            this.Level = MessageLevel.error;
        }

        public MessageItem(MessageLevel level, string format, params object[] args)
            : base()
        {
            this.Level = level;
            this.Message = string.Format(format, args);
        }

        public MessageItem(string format, params object[] args)
            : this(MessageLevel.error, format, args)
        {

        }


        public override int GetHashCode()
        {
            return Location.GetHashCode() + Level.GetHashCode() + Message.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            MessageItem item = (MessageItem)obj;
            return this.Location == item.Location && this.Level == item.Level && this.Message == item.Message;
        }

        public override string ToString()
        {
            return string.Format("{0} @ {1}", this.Message, this.Location);
        }
    }
}

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
    

        DataTable dt;

        public event MessageHandler MessageChanged;

        public MassageManager(DataTable dt)
        {
            this.dt = dt;
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
            item.Type = MessageLevel.error;
            item.Message = description;
            item.Location = location;
            Add(item);
        }

        public void Warning(int code, string description, string location)
        {
            MessageItem item = new MessageItem();
            item.ID = code;
            item.Type = MessageLevel.warning;
            item.Message = description;
            item.Location = location;
            Add(item);
        }

        public void Message(int code, string description, string location)
        {
            MessageItem item = new MessageItem();
            item.ID = code;
            item.Type = MessageLevel.information;
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
        private int level;
        public string Message;
        public string Location;

        public MessageItem()
        {
        }

        public MessageLevel Type
        {
            get { return (MessageLevel)level; }
            set { this.level = (int)value; }
        }

        public override int GetHashCode()
        {
            return Location.GetHashCode() + level.GetHashCode() + Message.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            MessageItem item = (MessageItem)obj;
            return this.Location == item.Location && this.level == item.level && this.Message == item.Message;
        }
    }
}

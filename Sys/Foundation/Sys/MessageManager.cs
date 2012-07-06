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
        List<Message> errors = new List<Message>();

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
            Message item = new Message();
            item.ID = code;
            item.Level = MessageLevel.error;
            item.Description = description;
            item.Location = location;
            Add(item);
        }

        public void Warning(int code, string description, string location)
        {
            Message item = new Message();
            item.ID = code;
            item.Level = MessageLevel.warning;
            item.Description = description;
            item.Location = location;
            Add(item);
        }

        public void Information(int code, string description, string location)
        {
            Message item = new Message();
            item.ID = code;
            item.Level = MessageLevel.information;
            item.Description = description;
            item.Location = location;

            Add(item);
        }

        private void Add(Message item)
        {
            if (errors.Contains(item))
                return ;

            this.errors.Add(item);
        }
    }

    public class MessageEventArgs : EventArgs
    {
        public readonly List<Message> Errors;

        public MessageEventArgs(List<Message> errors)
        {
            this.Errors = errors;
        }
    }

   
}

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
        List<Message> messages = new List<Message>();

        public delegate void MessageHandler(object sender, MessageEventArgs e);

        public event MessageHandler MessageChanged;
        public event EventHandler MessageCleared;

        public MassageManager()
        {
        }

        public void Commit()
        {
            if (MessageChanged != null)
                MessageChanged(this, new MessageEventArgs(this.messages));
        }


        public void Clear()
        {
            messages.Clear();
            if (MessageCleared != null)
                MessageCleared(this, new EventArgs());
        }

        public void Error(string description)
        {
            Error(0, description, "");
        }

        public void Error(string description, string location)
        {
            Error(0, description, location);
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

        public void Warning(string description, string location)
        {
            Warning(0, description, location);
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

        public void Information(string description, string location)
        {
            Information(0, description, location);
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
            if (messages.Contains(item))
                return ;

            this.messages.Add(item);
        }

        public void Add(IEnumerable<Message> messages)
        {
            foreach (Message message in messages)
               this.messages.Add(message);
        }

        public override string ToString()
        {
            return string.Format("{0} error(s) found",this.messages.Where(message => message.Level == MessageLevel.error).Count());
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

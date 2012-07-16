using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using System.Data;

namespace Sys
{
    public interface IDockable
    { 
        void ActivateDockPanel();
    }

    public class MessageManager
    {
        List<Message> messages = new List<Message>();

        public delegate void MessageHandler(object sender, MessageEventArgs e);

        public event MessageHandler MessageChanged;
        public event EventHandler MessageCleared;

        IDockable dock;

        public MessageManager(IDockable dock)
        {
            this.dock = dock;
        }

        public void Commit()
        {
            if (MessageChanged != null)
                MessageChanged(this, new MessageEventArgs(this.messages));

            dock.ActivateDockPanel();
        }


        public void Clear()
        {
            messages.Clear();
            if (MessageCleared != null)
                MessageCleared(this, new EventArgs());
        }

        public Message Error(string description)
        {
            return Error(0, description, "");
        }

        public Message Error(string description, string location)
        {
            return Error(0, description, location);
        }

        public Message Error(int code, string description, string location)
        {
            Message message = new Message(description);
            message.Code = code;
            message.Level = MessageLevel.Error;
            message.Location = location;
            return Add(message);
        }

        public Message Warning(string description, string location)
        {
            return Warning(0, description, location);
        }

        public Message Warning(int code, string description, string location)
        {
            Message message = new Message(description);
            message.Code = code;
            message.Level = MessageLevel.Warning;
            message.Location = location;
            return Add(message);
        }

        public Message Information(string description)
        {
            return Information(0, description, "");
        }

        public Message Information(string description, string location)
        {
            return Information(0, description, location);
        }

        public Message Information(int code, string description, string location)
        {
            Message message = new Message(description);
            message.Code = code;
            message.Level = MessageLevel.Information;
            message.Location = location;

            return Add(message);
        }

        private Message Add(Message item)
        {
            if (messages.Contains(item))
                return item;

            this.messages.Add(item);

            return item;
        }

        public bool Remove(Message message)
        {
            return this.messages.Remove(message);
        }

        public void Add(IEnumerable<Message> messages)
        {
            this.messages.AddRange(messages);
        }

        public int Count
        {
            get { return this.messages.Count; }
        }

        public override string ToString()
        {
            return string.Format("{0} error(s) found",this.messages.Where(message => message.Level == MessageLevel.Error).Count());
        }
    }

    public class MessageEventArgs : EventArgs
    {
        public readonly IEnumerable<Message> Messages;

        public MessageEventArgs(IEnumerable<Message> messages)
        {
            this.Messages = messages;
        }
    }

   
}

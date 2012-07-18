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

        public event EventHandler Committed;
        public event EventHandler Cleared;
        public event MessageHandler MessageClicked;

        IDockable dock;

        public MessageManager(IDockable dock)
        {
            this.dock = dock;
        }

        public void Commit()
        {
            if (Committed != null)
                Committed(this, new EventArgs());

            dock.ActivateDockPanel();
        }


        public void Clear()
        {
            messages.Clear();
            if (Cleared != null)
                Cleared(this, new EventArgs());
        }

        public void OnMessageClicked(Message message)
        {
            if (MessageClicked != null)
                MessageClicked(this, new MessageEventArgs(message));
        }

       
        public Message Add(Message message)
        {
            if (messages.Contains(message))
                return message;

            this.messages.Add(message);
            return message;
        }

        public Message Add(SysException ex)
        {
            this.messages.Add(ex.SysMessage);
            return ex.SysMessage;
        }

        public bool Remove(Message message)
        {
            return this.messages.Remove(message);
        }

        public void Add(IEnumerable<Message> messages)
        {
            this.messages.AddRange(messages);
        }

       
        public IEnumerable<Message> Messages
        {
            get { return this.messages; }
        }

        public override string ToString()
        {
            return string.Format("{0} error(s) found",this.messages.Where(message => message.Level == MessageLevel.Error).Count());
        }


    }

   

   
}

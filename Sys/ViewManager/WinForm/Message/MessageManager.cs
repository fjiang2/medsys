using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using System.Data;

namespace Sys.ViewManager.Forms
{
    public class MessageManager
    {
        private static MessageManager instance = null;
        public static MessageManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new MessageManager();
                return instance;
            }
        }

        List<Message> messages = new List<Message>();

        public event EventHandler Committed;
        public event MessageHandler Cleared;
        public event MessageHandler MessageClicked;

        private MessageManager()
        {
        }

        public void Commit()
        {
            if (Committed != null)
                Committed(this, new EventArgs());

        }


        public void ClearWindow(MessagePlace place)
        {
            messages.Clear();
            Message message = new Message(MessageLevel.None, null).To(place);
            if (Cleared != null)
                Cleared(this, new MessageEventArgs(message));
        }

    

        public void OnMessageClicked(Message message)
        {
            if (MessageClicked != null)
                MessageClicked(this, new MessageEventArgs(message));
        }

       
        public Message Add(Message message)
        {
            lock (this.messages)
            {
                if (messages.Contains(message))
                    return message;

                this.messages.Add(message);
            }
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

        public void Add(MessageBuilder builder)
        {
            this.messages.AddRange(builder);
        }

       
        public IEnumerable<Message> Messages
        {
            get { return this.messages; }
        }

        internal IEnumerable<Message> GetMessages(MessagePlace place)
        {
            return this.messages.Where(message => (message.Place & place) == place);
        }

        internal void RemoveMessages(MessagePlace place)
        {
            messages.RemoveAll(message => (message.Place & place) == place);
        }

        public override string ToString()
        {
            return string.Format("{0} error(s) found",this.messages.Where(message => message.Level == MessageLevel.Error).Count());
        }


    }

   

   
}

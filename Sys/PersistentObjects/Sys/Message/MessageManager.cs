﻿using System;
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

        public event EventHandler Comitted;
        public event EventHandler Cleared;
        public event MessageHandler MessageClicked;

        IDockable dock;

        public MessageManager(IDockable dock)
        {
            this.dock = dock;
        }

        public void Commit()
        {
            if (Comitted != null)
                Comitted(this, new EventArgs());

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

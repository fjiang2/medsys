using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class MessageEventArgs : EventArgs
    {
        public readonly IEnumerable<Message> Messages;

        public MessageEventArgs(IEnumerable<Message> messages)
        {
            this.Messages = messages;
        }
    }
}

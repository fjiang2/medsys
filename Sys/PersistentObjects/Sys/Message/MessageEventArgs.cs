using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public delegate void MessageHandler(object sender, MessageEventArgs e);

    public class MessageEventArgs : EventArgs
    {
        public readonly Message Message;

        public MessageEventArgs(Message message)
        {
            this.Message = message;
        }
    }

}

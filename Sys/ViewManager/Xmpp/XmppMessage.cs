using System;
using System.Collections.Generic;
using System.Text;
using agsXMPP.protocol.client;
using Sys.Security;
using Tie;

namespace Sys.Xmpp
{
    class XmppMessage : Message
    {
     
        //used for sending message via channel
        public XmppMessage(VAL val)
        {
            this.Type = agsXMPP.protocol.client.MessageType.chat;
            this.From = XmppAccount.NewJid(Account.CurrentUser.UserName);

            //this.To = to;
            this.AddChild(new XmppElement(val));
        }

        public XmppMessage(string json)
        {
            this.Type = agsXMPP.protocol.client.MessageType.chat;
            this.From = XmppAccount.NewJid(Account.CurrentUser.UserName);

            //this.To = to;
            this.AddChild(new XmppElement(json));
        }

        public XmppMessage(Account toAccount, VAL val)
        {
            agsXMPP.Jid to = XmppAccount.NewJid(toAccount.UserName);

            this.Type = agsXMPP.protocol.client.MessageType.chat;
            this.To = to;
            this.From = XmppAccount.NewJid(Account.CurrentUser.UserName);
            this.AddChild(new XmppElement(val));

        }


    }
}

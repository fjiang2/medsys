using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using agsXMPP;

namespace Sys.Xmpp
{

    public class XmppEventArgs : EventArgs
    {
        public readonly Jid From;
        public readonly UserProtocol Sender;
        public readonly string SenderFullName;
        public readonly DateTime SentTime;
       // public readonly VAL Receivers;
        public readonly string Subject;

        public readonly VAL Val;
        public bool confirmed;

        public XmppEventArgs(Jid from, string subject, VAL val)
        {
            this.From = from;
            this.Val = val;
            this.confirmed = false;

            this.Sender = new UserProtocol(val[XmppClient.XMPP_SENDER]);
            this.SentTime = (DateTime)val[XmppClient.XMPP_SENT_TIME];
            //this.Receivers = val[XmppClient.XMPP_RECEIVERS];

            this.Subject = subject;
        }
    }
}

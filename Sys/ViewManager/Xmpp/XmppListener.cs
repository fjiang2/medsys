using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Xmpp
{
    class XmppListener
    {

        XmppClient xmppClient;
        public XmppListener(XmppClient xmppClient)
        {
            this.xmppClient = xmppClient;
        }

        protected void AddListener(agsXMPP.Jid from)
        {
            xmppClient.XmppClientConnection.MessageGrabber.Add(from, new agsXMPP.Collections.BareJidComparer(), MessageListener, null);
        }


        protected void AddListener(agsXMPP.Jid from, agsXMPP.MessageCB messageListener)
        {
            xmppClient.XmppClientConnection.MessageGrabber.Add(from, new agsXMPP.Collections.BareJidComparer(), messageListener, null);
        }


        protected void RemoveListener(agsXMPP.Jid from)
        {
            xmppClient.XmppClientConnection.MessageGrabber.Remove(from);
        }


        protected virtual void MessageListener(object sender, agsXMPP.protocol.client.Message msg, object data)
        {
            XmppMessage message = msg as XmppMessage;
            //switch()
           // {
            
           // }
        }
    }
}

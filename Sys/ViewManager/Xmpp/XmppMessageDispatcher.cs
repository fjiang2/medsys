using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using agsXMPP.protocol.client;
using agsXMPP;

namespace Sys.Xmpp
{
    public class XmppMessageDispatcher
    {
        #region Singleton
        
        private static XmppMessageDispatcher dispatcher = null;
        private XmppMessageDispatcher()
        { 
        }

        public static XmppMessageDispatcher Instance
        {
            get
            {
                if (dispatcher == null)
                    dispatcher = new XmppMessageDispatcher();
                
                return dispatcher;
            }
        }
        
        #endregion


        public delegate void XmppEvelentHandler(object sender, XmppEventArgs e);
        public event XmppEvelentHandler XmppEvent;
 
        public void OnXmppEvent(agsXMPP.protocol.client.Message msg, XmppElement xmppElement)
        {
            VAL json = xmppElement.VAL;

            if (XmppEvent != null)
            {
                XmppEventArgs args = new XmppEventArgs(msg.From, msg.Subject, json);
                XmppEvent(this, args);
            }
        }


    }
}

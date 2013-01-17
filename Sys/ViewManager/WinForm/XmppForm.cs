using System;
using System.Collections.Generic;
using System.Text;
using Sys.Xmpp;
using Tie;


namespace Sys.ViewManager.Forms
{
    public class XmppForm : System.Windows.Forms.Form
    {
        protected XmppClient XmppClient
        {
            get
            {
                return XmppClient.Instance;
            }
        }


        public XmppForm()
        { 
        
        }


        protected bool ReceiveXmppMessageOn
        {
            set
            {
                if (value)
                    XmppMessageDispatcher.Instance.XmppEvent += this.OnReceiveMessage;
                else
                    XmppMessageDispatcher.Instance.XmppEvent -= this.OnReceiveMessage;
            }
        }

        protected virtual void OnReceiveMessage(object sender, XmppEventArgs e)
        {
            VAL val = e.Val;
            if (val["ToClass"].Undefined)
                return;

            string formClass = val["ToClass"].Str;

            if (this.GetType().FullName != formClass)
                return;

            e.confirmed = true;
        }

      
    }
}

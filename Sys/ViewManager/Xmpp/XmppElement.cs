using System;
using System.Collections.Generic;
using System.Text;
using agsXMPP.Xml.Dom;
using Tie;
using Sys;

namespace Sys.Xmpp
{
    public class XmppElement : Element
    {

        public XmppElement()
        {
            this.TagName = "XmppElement";
            this.Namespace = "Xmpp:XmppElement";
        }

        public XmppElement(VAL val)
            : this()
        {
            this.VAL = val;
        }

        public XmppElement(string json)
            : this()
        {
            this.JSON = json;
        }

        public VAL VAL
        {
            get 
            {
                return Script.Evaluate(JSON); 
            }
            set 
            {
                JSON = value.ToJson("");
            }
        }

        public string JSON
        {
            get
            {
                string encryption = GetTag("JSON");
                return encryption.Decrypt();
            }
            set
            {
                string encryption = value.Encrypt();
                SetTag("JSON", encryption);
            }
        }

      

    }
}

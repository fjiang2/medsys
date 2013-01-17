using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using System.Data;
using ViewManager.Reflection;
using ViewManager.WinForm;
using System.Reflection;
using System.Windows.Forms;
using Xmpp.Protocols;

namespace ViewManager.Workflow.Protocols
{
    class ActivityHeapProtocol : IValable
    {
        public VAL Action;
        public UserCollectionProtocol Listeners = new UserCollectionProtocol();

        public ActivityHeapProtocol(string action)
        {
            this.Action = new VAL(action);
        }

        public ActivityHeapProtocol(VAL val)
        {
            Action = val["Action"];
            if(val["Listeners"].Defined)
                this.Listeners = new UserCollectionProtocol(val["Listeners"]);
        }

        public void AddListener(VAL workers)
        {
            Listeners.Add(new UserCollectionProtocol(workers));
        }


        public VAL GetValData()
        {
            VAL val = new VAL();
            val["Action"] = Action;
            val["Listeners"] = this.Listeners.GetValData();

            return val;
        
        }
    }
}

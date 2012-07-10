using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using agsXMPP.protocol;
using agsXMPP.protocol.iq;
using agsXMPP.protocol.iq.disco;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.version;
using agsXMPP.protocol.iq.oob;
using agsXMPP.protocol.client;
using agsXMPP.protocol.extensions.shim;
using agsXMPP.protocol.extensions.si;
using agsXMPP.protocol.extensions.bytestreams;

using agsXMPP.protocol.x;
using agsXMPP.protocol.x.data;

using agsXMPP.Xml;
using agsXMPP.Xml.Dom;

namespace agsXMPP.ui.pubsub
{

 
    public partial class PubsubControl : UserControl
    {
        public List<Jid> PubSub = new List<Jid>();

        public PubsubControl()
        {
            InitializeComponent();
        }

       
        public void ListNodes(DiscoManager discoManager, IQ iq)
         {
              Jid jid = iq.From;
              if (!PubSub.Contains(jid))
                 PubSub.Add(jid);
            
            discoManager.DiscoverItems(jid, new IqCB(OnDiscoPubSubResult), null);
         }

        private void OnDiscoPubSubResult(object sender, IQ iq, object data)
        {
            if (iq.Type == IqType.result)
            {
                if (iq.Query is DiscoItems)
                {
                    DiscoItems discoItems = iq.Query as DiscoItems;
                    DiscoItem[] items = discoItems.GetDiscoItems();

                    foreach (DiscoItem item in items)
                    {
                        TreeNode n = new TreeNode(item.Node);
                        n.Tag = item.Name;
                        n.ImageIndex = n.SelectedImageIndex = 1;
                        this.treeView1.Nodes.Add(n);
                    }
                }
            }
        }


     

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Sys.ViewManager;
using Sys.Data;

namespace Sys.Xmpp
{

    public enum SubscriberType
    {
        Group = 1, 
        Individual = 2
    }

    [Table("xmppChannelSubscribers", Level.System)]
    public class XmppChannelSubscriber : PersistentObject
    {
        public int Channel_ID;          //int(4)
        public int Subscriber_Type;     //int(4)
        public int Subscriber_ID;       //int(4)
        public bool Enabled;            //bool,subscribed or not

        public XmppChannelSubscriber()
            :this(Sys.Security.Account.CurrentUser.UserID)
        {
        }

        public XmppChannelSubscriber(int subscriberID)
        {
            this.Subscriber_ID = subscriberID;
            this.Subscriber_Type = (int)SubscriberType.Individual;
        }

        public void Subscribe(int channelID)
        {
            this.Channel_ID = channelID;
            this.Enabled = true;
            Save();
        }

        public void Unsubscribe(int channelID)
        {
            this.Channel_ID = channelID;
            this.Enabled = false;
            Save();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using agsXMPP;
using agsXMPP.protocol.client;
using Sys.Security;

namespace Sys.Xmpp
{
    public class XmppClient
    {

        public const string XMPP_SENDER = "Sender";
        public const string XMPP_SENT_TIME = "SentTime";
        public const string XMPP_RECEIVERS = "Receivers";
        public const string XMPP_COMPUTER_NAME = "ComputerName";

        #region Singleton Instance
        
        private static XmppClient xmppClient = null;
        public static XmppClient Instance
        {
            get
            {
                if (xmppClient == null)
                    xmppClient = new XmppClient();

                return xmppClient;
            }
        }
        
        #endregion


        agsXMPP.XmppClientConnection xmppClientConnection;

        public XmppClient()
        {
            this.xmppClientConnection = new agsXMPP.XmppClientConnection();
            this.xmppClientConnection.SocketConnectionType = agsXMPP.net.SocketConnectionType.Direct;
        }

        public agsXMPP.XmppClientConnection XmppClientConnection
        {
            get { return this.xmppClientConnection; }
        }


        /***************************************
         receivers = 
           [
            {
              "ID" : 585,
              "UserName" : "00585",
              "FullName" : "Cory Cogdill"
            },
            {
              "ID" : 1227,
              "UserName" : "01227",
              "FullName" : "Fuhua Jiang"
            }
          ]
         *******************************************/
        public void SendMessage(UserCollectionProtocol receivers, string subject, VAL val)
        {
            UserProtocol sender = new UserProtocol(Account.CurrentUser);
            val[XMPP_SENDER] = sender.GetValData();
            val[XMPP_SENT_TIME] = VAL.Boxing(DateTime.Now);
            //val[XMPP_RECEIVERS] = receivers.GetValData();
            val[XMPP_COMPUTER_NAME] = new VAL(System.Windows.Forms.SystemInformation.ComputerName);

            string JSON = val.ToJson("");
            foreach (UserProtocol user in receivers)
            {
                Jid jid = XmppAccount.NewJid(user.UserName);
                XmppMessage message = new XmppMessage(JSON);
                message.To = jid;
                message.Subject = subject;
                this.xmppClientConnection.Send(message);
            }
        }

        public void SendMessage(XmppChannel channel, VAL val)
        {
            this.SendMessage(channel.Subscribers, channel.ToString(), val);
        }

        public void SendMessage(XmppChannel[] channels, string subject, VAL val)
        {
            UserCollectionProtocol subscribers = new UserCollectionProtocol();
            foreach (XmppChannel channel in channels)
                subscribers.Add(channel.Subscribers);

            this.SendMessage(subscribers, subject, val);
        }


        
        
        
        #region Instance Messaging

        public void SendMessage(UserCollectionProtocol receivers, string subject, string text)
        {
            foreach (UserProtocol user in receivers)
                SendMessage(user.UserName, subject, text);
        }

        public void SendMessage(XmppChannel channel, string subject, string text)
        {
            this.SendMessage(channel.Subscribers, channel.ToString(), text);
        }

        public void SendMessage(string userName, string subject, string body)
        {
            agsXMPP.Jid to = XmppAccount.NewJid(userName);
            agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();

            msg.Type = agsXMPP.protocol.client.MessageType.chat;
            msg.To = to;
            msg.Subject = subject;
            msg.Body = body;

            this.xmppClientConnection.Send(msg);
        }
        
        #endregion
    }
}

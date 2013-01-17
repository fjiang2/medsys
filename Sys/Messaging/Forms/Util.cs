using System;
using System.Collections;
using System.Collections.Generic;

using agsXMPP;
using agsXMPP.protocol.client;

namespace Sys.Messaging.Forms
{
	/// <summary>
	/// Summary description for Util.
	/// </summary>
	public class Util
	{
        public static Dictionary<string, frmChat> ChatForms = new Dictionary<string, frmChat>();
        public static Dictionary<string,frmGroupChat> GroupChatForms  = new Dictionary<string,frmGroupChat>();

        public class XmppServices
        {
            public XmppServices()
            {
            }

            public List<Jid> Search = new List<Jid>();
            public List<Jid> Proxy = new List<Jid>();
            public List<Jid> PubSub = new List<Jid>();
        }

        public static XmppServices Services = new XmppServices();


        public static string AppPath
        {
            get
            {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }

        public static int GetRosterImageIndex(Presence pres)
        {
            if (pres.Type == PresenceType.unavailable)
            {
                return 0;
            }
            else if (pres.Type == PresenceType.error)
            {
                // presence error, we dont care in the Messaging here
            }
            else
            {
                switch (pres.Show)
                {
                    case ShowType.NONE:
                        return 1;
                    case ShowType.away:
                        return 2;
                    case ShowType.chat:
                        return 4;
                    case ShowType.xa:
                        return 3;
                    case ShowType.dnd:
                        return 5;
                }
            }
            return 0;
        }
	}   
}

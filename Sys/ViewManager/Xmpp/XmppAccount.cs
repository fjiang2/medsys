using System;
using System.Collections.Generic;
using System.Text;

using agsXMPP;
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

using agsXMPP.sasl;

using agsXMPP.protocol.iq.vcard;
using Sys.OS;

namespace Sys.Xmpp
{
    public class XmppAccount
    {
        private XmppClientConnection XmppCon;
        private Sys.Security.Account account;

        Jid jid;

        public XmppAccount(XmppClientConnection XmppCon, Sys.Security.Account account)
        {
            this.XmppCon = XmppCon;
            this.account = account;
            jid = NewJid(account.UserName);

            agsXMPP.Factory.ElementFactory.AddElementType("XmppElement", "Xmpp:XmppElement", typeof(XmppElement));
        }


        public void Login()
        {
            string resource = Configuration.Instance.GetValue<string>("Xmpp.Resource");
            string caps = Configuration.Instance.GetValue<string>("Xmpp.Caps");

            resource = System.Windows.Forms.SystemInformation.ComputerName;
                
            Login(
                    XmppCon, 
                    jid, 
                    "password", 
                    resource, 
                    caps);
        }


        private static string host = null;
        public static string XmppHost
        {
            get
            {
                if(host==null)
                    host = Configuration.Instance.GetValue<string>("Xmpp.Host");

                return host;
            }
        }

        public static Jid NewJid(string userName)
        {
            return new Jid(userName + "@" + XmppHost);
        }

        public void Register()
        {
            registerAccount = true;
            Login();
        }

        public void UpdateVcard()
        {
            UpdateVcard(account);
        }

        public void UpdateVcard(Sys.Security.Account account)
        {

            VcardIq viq = new VcardIq(IqType.set, new Jid(jid.Bare));

            Element name = new Element("N");
            name.AddTag("FAMILY", account.LastName);
            name.AddTag("GIVEN", account.FirstName);
            name.AddTag("MIDDLE", account.Middle_Name);
            viq.Vcard.AddChild(name);

            viq.Vcard.Description = string.Format("Login on {0} at {1}, version{2}",
                System.Windows.Forms.SystemInformation.ComputerName, 
                DateTime.Now,
                App.ApplicationVersion() 
                );

            viq.Vcard.Fullname = account.Name;
            viq.Vcard.Nickname = account.Nickname;
            viq.Vcard.AddEmailAddress(new Email(EmailType.WORK, account.EmailAddress, true));
            viq.Vcard.Organization = new Organization(account.Group_Name, account.Department);
            viq.Vcard.AddTelephoneNumber(new Telephone(TelephoneLocation.WORK, TelephoneType.NUMBER, account.WorkPhone));
            viq.Vcard.Title = account.Job_Title;
            
            if(account.Avatar !=null)
                viq.Vcard.Photo = new Photo(account.AvatarImage, System.Drawing.Imaging.ImageFormat.Jpeg);  

            XmppCon.Send(viq);

        }


        //const int port = 5222;
        //const int priority = 10;
        bool registerAccount = false;

        public void Login(XmppClientConnection XmppCon, Jid jid, string password, string resource, string caps)
        {
        
            XmppCon.Server = jid.Server;
            XmppCon.Username = jid.User;
            XmppCon.Password = password;
            XmppCon.Resource = resource;
            XmppCon.Priority = Configuration.Instance.GetValue<int>("Xmpp.Priority");
            XmppCon.Port = Configuration.Instance.GetValue<int>("Xmpp.Port");
            XmppCon.UseSSL = false;
            XmppCon.AutoResolveConnectServer = true;
            XmppCon.UseCompression = false;
            XmppCon.RegisterAccount = registerAccount;


            // Caps
            XmppCon.EnableCapabilities = true;
            XmppCon.ClientVersion = "1.0";
            XmppCon.Capabilities.Node = caps;


            XmppCon.DiscoInfo.AddIdentity(new DiscoIdentity("pc", "Messaging", "client"));

            XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.DISCO_INFO));
            XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.DISCO_ITEMS));
            XmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.MUC));


            XmppCon.Open();


        }




     
    }
}

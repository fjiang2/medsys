using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

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

using agsXMPP.ui;
using agsXMPP.ui.roster;
using agsXMPP.ui.pubsub;

using System.Security.Cryptography;
using System.Text;

using agsXMPP.protocol.stream.feature.compression;
using agsXMPP.protocol.extensions.pubsub;
using Sys.ViewManager.Forms;
using Sys.Xmpp;
using Sys.Data;
using Sys.OS;

namespace Sys.Messaging.Forms
{
	/// <summary>
	/// MainForm
	/// </summary>
	public class Messenger : UserControl
    {
        private System.Windows.Forms.StatusBar statusBar1;
        private System.ComponentModel.IContainer components;
        
        
        private ContextMenuStrip contextMenuConferences;        
        private ContextMenuStrip contextMenuStripRoster;
        private ContextMenuStrip contextMenuPubSub;

        private ToolStripMenuItem chatToolStripMenuItem;
        private ToolStripMenuItem vcardToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem sendFileToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripMenuItem movetoToolStripMenuItem;
        private ToolStripMenuItem joinToolStripMenuItem;        

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonConnect;
        private ToolStripButton toolStripButtonDisconnect;

        private ToolStrip ToolStripGC;
        private ToolStripButton toolStripButtonFindRooms;
        private ToolStripButton toolStripButtonFindPart;
        private ToolStripButton toolStripButtonSearch;

        public ToolStripLabel toolStripLabelLogon;
        private ToolStripSeparator toolStripSeparator1;

        private TabControl tabControl1;
        private TabPage tabRoster;
        private TabPage tabGC;
        private TabPage tabPubSub;
        private TabPage tabSocket;
        private TabPage tabDebug;

        private RosterControl rosterControl;
        private TreeView treeViewConferences;
        private PubsubControl treeViewPubSub;
        private RichTextBox rtfDebug;
        private RichTextBox rtfDebugSocket;

        private ComboBox cboStatus;
        private ImageList ils16;
        const int IMAGE_PARTICIPANT = 3;
        const int IMAGE_CHATROOM = 4;
        const int IMAGE_SERVER = 5;
        

        delegate void OnMessageDelegate(object sender, agsXMPP.protocol.client.Message msg);
		delegate void OnPresenceDelegate(object sender, Presence pres);


        private XmppClientConnection XmppCon;
        //private DiscoHelper discoHelper;
        DiscoManager discoManager;
        PubSubManager pubSubManager;


        //Sys.Security.Account account = Sys.Security.Account.CurrentUser;
        XmppAccount xmppAccount;
        private ToolStripButton toolStripButtonEditProfile;
        private ToolStripMenuItem toolStripMenuItemCreateNode;
        private ToolStripMenuItem toolStripMenuItemDeleteNode;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuItemSubcribe;
        private ToolStripMenuItem toolStripMenuItemPublish;
        List<string> groups = new List<string>();

        Sys.Security.Account account;

        public Messenger()
		{			
			InitializeComponent();

            treeViewConferences.TreeViewNodeSorter = new TreeNodeSorter();
            account = Sys.Security.Account.CurrentUser;
            

#if !DEBUG
            this.tabControl1.Controls.Remove(this.tabPubSub);
            this.tabControl1.Controls.Remove(this.tabDebug);
            this.tabControl1.Controls.Remove(this.tabSocket);
#endif

            treeViewConferences.ContextMenuStrip = contextMenuConferences;
	
			// initialize Combo Status
			cboStatus.Items.AddRange( new object[] {"offline",
													ShowType.away.ToString(),
													ShowType.xa.ToString(),
													ShowType.chat.ToString(),
													ShowType.dnd.ToString(),
													"online" });
			cboStatus.SelectedIndex = 0;

			// initilaize XmppConnection
            XmppCon = XmppClient.Instance.XmppClientConnection;
            
			XmppCon.OnReadXml		    += new XmlHandler(XmppCon_OnReadXml);
			XmppCon.OnWriteXml		    += new XmlHandler(XmppCon_OnWriteXml);
			
			XmppCon.OnRosterStart	    += new ObjectHandler(XmppCon_OnRosterStart);
			XmppCon.OnRosterEnd		    += new ObjectHandler(XmppCon_OnRosterEnd);
			XmppCon.OnRosterItem	    += new agsXMPP.XmppClientConnection.RosterHandler(XmppCon_OnRosterItem);

			XmppCon.OnAgentStart	    += new ObjectHandler(XmppCon_OnAgentStart);
			XmppCon.OnAgentEnd		    += new ObjectHandler(XmppCon_OnAgentEnd);
			XmppCon.OnAgentItem		    += new agsXMPP.XmppClientConnection.AgentHandler(XmppCon_OnAgentItem);

			XmppCon.OnLogin			    += new ObjectHandler(XmppCon_OnLogin);
			XmppCon.OnClose			    += new ObjectHandler(XmppCon_OnClose);
			XmppCon.OnError			    += new ErrorHandler(XmppCon_OnError);
			XmppCon.OnPresence		    += new PresenceHandler(XmppCon_OnPresence);
            XmppCon.OnMessage           += new agsXMPP.protocol.client.MessageHandler(XmppCon_OnMessage);
			XmppCon.OnIq			    += new IqHandler(XmppCon_OnIq);
			XmppCon.OnAuthError		    += new XmppElementHandler(XmppCon_OnAuthError);
            XmppCon.OnSocketError += new ErrorHandler(XmppCon_OnSocketError);
            XmppCon.OnStreamError += new XmppElementHandler(XmppCon_OnStreamError);

           
            XmppCon.OnReadSocketData    += new agsXMPP.net.BaseSocket.OnSocketDataHandler(ClientSocket_OnReceive);
            XmppCon.OnWriteSocketData   += new agsXMPP.net.BaseSocket.OnSocketDataHandler(ClientSocket_OnSend);

            XmppCon.ClientSocket.OnValidateCertificate += new System.Net.Security.RemoteCertificateValidationCallback(ClientSocket_OnValidateCertificate);
            
						
			XmppCon.OnXmppConnectionStateChanged		+= new XmppConnectionStateHandler(XmppCon_OnXmppConnectionStateChanged);
            XmppCon.OnSaslStart                         += new SaslEventHandler(XmppCon_OnSaslStart);

            discoManager = new DiscoManager(XmppCon);
            pubSubManager = new PubSubManager(XmppCon);

            agsXMPP.Factory.ElementFactory.AddElementType("Login", null, typeof(Settings.Login));
            //LoadChatServers();

           
            


		}

        void XmppCon_OnStreamError(object sender, Element e)
        {
            // Stream errors <stream:error/>
        }       

        private void XmppCon_OnSocketError(object sender, Exception ex)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ErrorHandler(XmppCon_OnSocketError), new object[] { sender, ex });
                return;
            }

            MessageBox.Show(ex.Message + "\r\n" + ex.InnerException, "Messaging Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }           

        private void XmppCon_OnSaslStart(object sender, SaslEventArgs args)
        {
            // You can define the SASL mechanism here when needed, or implement your own SASL mechanisms
            // for authentication

            //args.Auto = false;
            //args.Mechanism = agsXMPP.protocol.sasl.Mechanism.GetMechanismName(agsXMPP.protocol.sasl.MechanismType.PLAIN);            


            //args.Auto = false;
            //args.Mechanism = agsXMPP.protocol.sasl.Mechanism.GetMechanismName(agsXMPP.protocol.sasl.MechanismType.ANONYMOUS);
        }

        private void LoadChatServers()
        {
            treeViewConferences.TreeViewNodeSorter = new TreeNodeSorter();

            object mucServices = Configuration.Instance.GetValue<object>("Xmpp.MucServices");
            if (mucServices == null)
                return;

            if (mucServices.GetType().IsArray)
            {
                object[] services = (object[])mucServices;
                foreach (object service in services)
                {
                    TreeNode n = new TreeNode(service as string);
                    n.Tag = "server";
                    n.ImageIndex = n.SelectedImageIndex = IMAGE_SERVER;
                    this.treeViewConferences.Nodes.Add(n);
                }
            }
            else
            {
                TreeNode n = new TreeNode(mucServices as string);
                n.Tag = "server";
                n.ImageIndex = n.SelectedImageIndex = IMAGE_SERVER;
                this.treeViewConferences.Nodes.Add(n);
            }
        
        }
		/// <summary>
		/// 
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code
		
		/// <summary>
		/// 
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Messenger));
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.contextMenuConferences = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.joinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripRoster = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vcardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movetoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelLogon = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditProfile = new System.Windows.Forms.ToolStripButton();
            this.tabSocket = new System.Windows.Forms.TabPage();
            this.rtfDebugSocket = new System.Windows.Forms.RichTextBox();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.rtfDebug = new System.Windows.Forms.RichTextBox();
            this.tabGC = new System.Windows.Forms.TabPage();
            this.treeViewConferences = new System.Windows.Forms.TreeView();
            this.ils16 = new System.Windows.Forms.ImageList(this.components);
            this.ToolStripGC = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonFindRooms = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFindPart = new System.Windows.Forms.ToolStripButton();
            this.tabRoster = new System.Windows.Forms.TabPage();
            this.rosterControl = new agsXMPP.ui.roster.RosterControl();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPubSub = new System.Windows.Forms.TabPage();
            this.treeViewPubSub = new agsXMPP.ui.pubsub.PubsubControl();
            this.contextMenuPubSub = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCreateNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSubcribe = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPublish = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuConferences.SuspendLayout();
            this.contextMenuStripRoster.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabSocket.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.tabGC.SuspendLayout();
            this.ToolStripGC.SuspendLayout();
            this.tabRoster.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPubSub.SuspendLayout();
            this.contextMenuPubSub.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 400);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(331, 24);
            this.statusBar1.TabIndex = 1;
            this.statusBar1.Text = "Offline";
            // 
            // contextMenuConferences
            // 
            this.contextMenuConferences.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joinToolStripMenuItem});
            this.contextMenuConferences.Name = "contextMenuConferences";
            this.contextMenuConferences.Size = new System.Drawing.Size(96, 26);
            // 
            // joinToolStripMenuItem
            // 
            this.joinToolStripMenuItem.Name = "joinToolStripMenuItem";
            this.joinToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.joinToolStripMenuItem.Text = "Join";
            this.joinToolStripMenuItem.Click += new System.EventHandler(this.joinToolStripMenuItem_Click);
            // 
            // contextMenuStripRoster
            // 
            this.contextMenuStripRoster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatToolStripMenuItem,
            this.vcardToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.sendFileToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.movetoToolStripMenuItem});
            this.contextMenuStripRoster.Name = "contextMenuStripRoster";
            this.contextMenuStripRoster.Size = new System.Drawing.Size(122, 136);
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.Image = global::Sys.Messaging.Properties.Resources.comment;
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            this.chatToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.chatToolStripMenuItem.Text = "chat";
            this.chatToolStripMenuItem.Click += new System.EventHandler(this.chatToolStripMenuItem_Click);
            // 
            // vcardToolStripMenuItem
            // 
            this.vcardToolStripMenuItem.Image = global::Sys.Messaging.Properties.Resources.vcard;
            this.vcardToolStripMenuItem.Name = "vcardToolStripMenuItem";
            this.vcardToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.vcardToolStripMenuItem.Text = "vcard";
            this.vcardToolStripMenuItem.Click += new System.EventHandler(this.vcardToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Sys.Messaging.Properties.Resources.user_delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // sendFileToolStripMenuItem
            // 
            this.sendFileToolStripMenuItem.Image = global::Sys.Messaging.Properties.Resources.package;
            this.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            this.sendFileToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.sendFileToolStripMenuItem.Text = "Send File";
            this.sendFileToolStripMenuItem.ToolTipText = "Send File to Buddy";
            this.sendFileToolStripMenuItem.Click += new System.EventHandler(this.sendFileToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // movetoToolStripMenuItem
            // 
            this.movetoToolStripMenuItem.Name = "movetoToolStripMenuItem";
            this.movetoToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.movetoToolStripMenuItem.Text = "Move to";
            this.movetoToolStripMenuItem.Click += new System.EventHandler(this.movetoToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelLogon,
            this.toolStripSeparator1,
            this.toolStripButtonConnect,
            this.toolStripButtonDisconnect,
            this.toolStripButtonAdd,
            this.toolStripButtonSearch,
            this.toolStripButtonEditProfile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(331, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelLogon
            // 
            this.toolStripLabelLogon.Image = global::Sys.Messaging.Properties.Resources.user_gray;
            this.toolStripLabelLogon.Name = "toolStripLabelLogon";
            this.toolStripLabelLogon.Size = new System.Drawing.Size(16, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonConnect
            // 
            this.toolStripButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonConnect.Image = global::Sys.Messaging.Properties.Resources.connect;
            this.toolStripButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConnect.Name = "toolStripButtonConnect";
            this.toolStripButtonConnect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonConnect.Text = "Connect to server";
            this.toolStripButtonConnect.Click += new System.EventHandler(this.toolStripButtonConnect_Click);
            // 
            // toolStripButtonDisconnect
            // 
            this.toolStripButtonDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDisconnect.Image = global::Sys.Messaging.Properties.Resources.disconnect;
            this.toolStripButtonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDisconnect.Name = "toolStripButtonDisconnect";
            this.toolStripButtonDisconnect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDisconnect.Text = "Disconnect to server";
            this.toolStripButtonDisconnect.Click += new System.EventHandler(this.toolStripButtonDisconnect_Click);
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = global::Sys.Messaging.Properties.Resources.user_add;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAdd.Text = "Add new contact";
            this.toolStripButtonAdd.ToolTipText = "Add User";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = global::Sys.Messaging.Properties.Resources.zoom;
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearch.Text = "Search contact";
            this.toolStripButtonSearch.ToolTipText = "User Search";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripButtonEditProfile
            // 
            this.toolStripButtonEditProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditProfile.Image = global::Sys.Messaging.Properties.Resources.vcard;
            this.toolStripButtonEditProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditProfile.Name = "toolStripButtonEditProfile";
            this.toolStripButtonEditProfile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEditProfile.Text = "Edit My Profile";
            this.toolStripButtonEditProfile.Click += new System.EventHandler(this.toolStripButtonEditProfile_Click);
            // 
            // tabSocket
            // 
            this.tabSocket.Controls.Add(this.rtfDebugSocket);
            this.tabSocket.ImageIndex = 0;
            this.tabSocket.Location = new System.Drawing.Point(4, 23);
            this.tabSocket.Name = "tabSocket";
            this.tabSocket.Size = new System.Drawing.Size(323, 348);
            this.tabSocket.TabIndex = 2;
            this.tabSocket.Text = "Socket Debug";
            this.tabSocket.UseVisualStyleBackColor = true;
            // 
            // rtfDebugSocket
            // 
            this.rtfDebugSocket.BackColor = System.Drawing.SystemColors.Window;
            this.rtfDebugSocket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfDebugSocket.Location = new System.Drawing.Point(0, 0);
            this.rtfDebugSocket.Name = "rtfDebugSocket";
            this.rtfDebugSocket.ReadOnly = true;
            this.rtfDebugSocket.Size = new System.Drawing.Size(323, 348);
            this.rtfDebugSocket.TabIndex = 1;
            this.rtfDebugSocket.Text = "";
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.rtfDebug);
            this.tabDebug.ImageIndex = 0;
            this.tabDebug.Location = new System.Drawing.Point(4, 23);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Size = new System.Drawing.Size(323, 348);
            this.tabDebug.TabIndex = 1;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            this.tabDebug.Visible = false;
            // 
            // rtfDebug
            // 
            this.rtfDebug.BackColor = System.Drawing.SystemColors.Window;
            this.rtfDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfDebug.Location = new System.Drawing.Point(0, 0);
            this.rtfDebug.Name = "rtfDebug";
            this.rtfDebug.ReadOnly = true;
            this.rtfDebug.Size = new System.Drawing.Size(323, 348);
            this.rtfDebug.TabIndex = 0;
            this.rtfDebug.Text = "";
            // 
            // tabGC
            // 
            this.tabGC.Controls.Add(this.treeViewConferences);
            this.tabGC.Controls.Add(this.ToolStripGC);
            this.tabGC.ImageIndex = 2;
            this.tabGC.Location = new System.Drawing.Point(4, 23);
            this.tabGC.Name = "tabGC";
            this.tabGC.Padding = new System.Windows.Forms.Padding(3);
            this.tabGC.Size = new System.Drawing.Size(323, 348);
            this.tabGC.TabIndex = 3;
            this.tabGC.Text = "Conferences";
            this.tabGC.UseVisualStyleBackColor = true;
            // 
            // treeViewConferences
            // 
            this.treeViewConferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewConferences.ImageIndex = 0;
            this.treeViewConferences.ImageList = this.ils16;
            this.treeViewConferences.Location = new System.Drawing.Point(3, 28);
            this.treeViewConferences.Name = "treeViewConferences";
            this.treeViewConferences.SelectedImageIndex = 0;
            this.treeViewConferences.Size = new System.Drawing.Size(317, 317);
            this.treeViewConferences.TabIndex = 20;
            this.treeViewConferences.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeGC_AfterSelect);
            // 
            // ils16
            // 
            this.ils16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ils16.ImageStream")));
            this.ils16.TransparentColor = System.Drawing.Color.Transparent;
            this.ils16.Images.SetKeyName(0, "application_xp_terminal.png");
            this.ils16.Images.SetKeyName(1, "folder_user.png");
            this.ils16.Images.SetKeyName(2, "group.png");
            this.ils16.Images.SetKeyName(3, "user.png");
            this.ils16.Images.SetKeyName(4, "comments.png");
            this.ils16.Images.SetKeyName(5, "server.png");
            this.ils16.Images.SetKeyName(6, "DisplayInColorHS.png");
            // 
            // ToolStripGC
            // 
            this.ToolStripGC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonFindRooms,
            this.toolStripButtonFindPart});
            this.ToolStripGC.Location = new System.Drawing.Point(3, 3);
            this.ToolStripGC.Name = "ToolStripGC";
            this.ToolStripGC.Size = new System.Drawing.Size(317, 25);
            this.ToolStripGC.TabIndex = 19;
            this.ToolStripGC.Text = "toolStrip2";
            // 
            // toolStripButtonFindRooms
            // 
            this.toolStripButtonFindRooms.Image = global::Sys.Messaging.Properties.Resources.comments;
            this.toolStripButtonFindRooms.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFindRooms.Name = "toolStripButtonFindRooms";
            this.toolStripButtonFindRooms.Size = new System.Drawing.Size(90, 22);
            this.toolStripButtonFindRooms.Text = "Find Rooms";
            this.toolStripButtonFindRooms.Click += new System.EventHandler(this.toolStripButtonFindRooms_Click);
            // 
            // toolStripButtonFindPart
            // 
            this.toolStripButtonFindPart.Image = global::Sys.Messaging.Properties.Resources.group;
            this.toolStripButtonFindPart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFindPart.Name = "toolStripButtonFindPart";
            this.toolStripButtonFindPart.Size = new System.Drawing.Size(115, 22);
            this.toolStripButtonFindPart.Text = "Find Participants";
            this.toolStripButtonFindPart.Click += new System.EventHandler(this.toolStripButtonFindPart_Click);
            // 
            // tabRoster
            // 
            this.tabRoster.Controls.Add(this.rosterControl);
            this.tabRoster.Controls.Add(this.cboStatus);
            this.tabRoster.ImageIndex = 3;
            this.tabRoster.Location = new System.Drawing.Point(4, 23);
            this.tabRoster.Name = "tabRoster";
            this.tabRoster.Size = new System.Drawing.Size(323, 348);
            this.tabRoster.TabIndex = 0;
            this.tabRoster.Text = "Contacts";
            this.tabRoster.UseVisualStyleBackColor = true;
            // 
            // rosterControl
            // 
            this.rosterControl.ColorGroup = System.Drawing.SystemColors.Highlight;
            this.rosterControl.ColorResource = System.Drawing.SystemColors.ControlText;
            this.rosterControl.ColorRoot = System.Drawing.SystemColors.Highlight;
            this.rosterControl.ColorRoster = System.Drawing.SystemColors.ControlText;
            this.rosterControl.DefaultGroupName = "ungrouped";
            this.rosterControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rosterControl.HideEmptyGroups = true;
            this.rosterControl.Location = new System.Drawing.Point(0, 21);
            this.rosterControl.Name = "rosterControl";
            this.rosterControl.Size = new System.Drawing.Size(323, 327);
            this.rosterControl.TabIndex = 13;
            this.rosterControl.SelectionChanged += new System.EventHandler(this.rosterControl_SelectionChanged);
            this.rosterControl.TreeViewMouseDown += new System.Windows.Forms.MouseEventHandler(this.rosterControl_TreeViewMouseDown);
            // 
            // cboStatus
            // 
            this.cboStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboStatus.Location = new System.Drawing.Point(0, 0);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(323, 21);
            this.cboStatus.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRoster);
            this.tabControl1.Controls.Add(this.tabGC);
            this.tabControl1.Controls.Add(this.tabPubSub);
            this.tabControl1.Controls.Add(this.tabDebug);
            this.tabControl1.Controls.Add(this.tabSocket);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.ils16;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(331, 375);
            this.tabControl1.TabIndex = 9;
        
            // 
            // tabPubSub
            // 
            this.tabPubSub.Controls.Add(this.treeViewPubSub);
            this.tabPubSub.ImageIndex = 5;
            this.tabPubSub.Location = new System.Drawing.Point(4, 23);
            this.tabPubSub.Name = "tabPubSub";
            this.tabPubSub.Padding = new System.Windows.Forms.Padding(3);
            this.tabPubSub.Size = new System.Drawing.Size(323, 348);
            this.tabPubSub.TabIndex = 4;
            this.tabPubSub.Text = "Pubsub";
            this.tabPubSub.UseVisualStyleBackColor = true;
            // 
            // treeViewPubSub
            // 
            this.treeViewPubSub.ContextMenuStrip = this.contextMenuPubSub;
            this.treeViewPubSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewPubSub.Location = new System.Drawing.Point(3, 3);
            this.treeViewPubSub.Name = "treeViewPubSub";
            this.treeViewPubSub.Size = new System.Drawing.Size(317, 342);
            this.treeViewPubSub.TabIndex = 0;
            // 
            // contextMenuPubSub
            // 
            this.contextMenuPubSub.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCreateNode,
            this.toolStripMenuItemDeleteNode,
            this.toolStripSeparator2,
            this.toolStripMenuItemSubcribe,
            this.toolStripMenuItemPublish});
            this.contextMenuPubSub.Name = "contextMenuPubSub";
            this.contextMenuPubSub.Size = new System.Drawing.Size(156, 98);
            // 
            // toolStripMenuItemCreateNode
            // 
            this.toolStripMenuItemCreateNode.Name = "toolStripMenuItemCreateNode";
            this.toolStripMenuItemCreateNode.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItemCreateNode.Text = "Create Node";
            this.toolStripMenuItemCreateNode.Click += new System.EventHandler(this.toolStripMenuItemCreateNode_Click);
            // 
            // toolStripMenuItemDeleteNode
            // 
            this.toolStripMenuItemDeleteNode.Name = "toolStripMenuItemDeleteNode";
            this.toolStripMenuItemDeleteNode.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItemDeleteNode.Text = "Delete Node";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // toolStripMenuItemSubcribe
            // 
            this.toolStripMenuItemSubcribe.Name = "toolStripMenuItemSubcribe";
            this.toolStripMenuItemSubcribe.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItemSubcribe.Text = "Subcribe";
            // 
            // toolStripMenuItemPublish
            // 
            this.toolStripMenuItemPublish.Name = "toolStripMenuItemPublish";
            this.toolStripMenuItemPublish.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItemPublish.Text = "Publish";
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(331, 424);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusBar1);
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.contextMenuConferences.ResumeLayout(false);
            this.contextMenuStripRoster.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabSocket.ResumeLayout(false);
            this.tabDebug.ResumeLayout(false);
            this.tabGC.ResumeLayout(false);
            this.tabGC.PerformLayout();
            this.ToolStripGC.ResumeLayout(false);
            this.ToolStripGC.PerformLayout();
            this.tabRoster.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPubSub.ResumeLayout(false);
            this.contextMenuPubSub.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        //[STAThread]
        //static void Main() 
        //{
        //    Application.EnableVisualStyles();
        //    Application.DoEvents();
        //    Application.Run(new frmMain());
        //}

		#region << XmppConnection events >>
		private void XmppCon_OnReadXml(object sender, string xml)
		{			
			if (InvokeRequired)
			{	
				// Windows Forms are not Thread Safe, we need to invoke this :(
				// We're not in the UI thread, so we need to call BeginInvoke				
				BeginInvoke(new XmlHandler(XmppCon_OnReadXml), new object[]{sender, xml});
				return;
			}
#if DEBUG
			rtfDebug.SelectionStart		= rtfDebug.Text.Length;
			rtfDebug.SelectionLength	= 0;
			rtfDebug.SelectionColor		= Color.Red;
			rtfDebug.AppendText("RECV: ");
			rtfDebug.SelectionColor		= Color.Black;
			rtfDebug.AppendText(xml);
			rtfDebug.AppendText("\r\n"); 
#endif
		}

		private void XmppCon_OnWriteXml(object sender, string xml)
		{
			if (InvokeRequired)
			{	
				// Windows Forms are not Thread Safe, we need to invoke this :(
				// We're not in the UI thread, so we need to call BeginInvoke				
				BeginInvoke(new XmlHandler(XmppCon_OnWriteXml), new object[]{sender, xml});
				return;
			}
#if DEBUG
            rtfDebug.SelectionStart = rtfDebug.Text.Length;
            rtfDebug.SelectionLength = 0;
            rtfDebug.SelectionColor = Color.Blue;
            rtfDebug.AppendText("SEND: ");
            rtfDebug.SelectionColor = Color.Black;
            rtfDebug.AppendText(xml);
            rtfDebug.AppendText("\r\n");
#endif
		}

		private void XmppCon_OnRosterStart(object sender)
		{
			if (InvokeRequired)
			{	
				// Windows Forms are not Thread Safe, we need to invoke this :(
				// We're not in the UI thread, so we need to call BeginInvoke				
				BeginInvoke(new ObjectHandler(XmppCon_OnRosterStart), new object[]{this});
				return;
			}
			// Disable redraw for faster updating
			rosterControl.BeginUpdate();
		}
		
		private void XmppCon_OnRosterEnd(object sender)
		{
			if (InvokeRequired)
			{	
				// Windows Forms are not Thread Safe, we need to invoke this :(
				// We're not in the UI thread, so we need to call BeginInvoke				
				BeginInvoke(new ObjectHandler(XmppCon_OnRosterEnd), new object[]{this});
				return;
			}
			// enable redraw again
            rosterControl.EndUpdate();
            rosterControl.ExpandOnline();

            
            //// Send our Online Presence now, this is done in the cboStatus SelectionChanges event
            //// after the next line
            //cboStatus.SelectedIndex = 5;
			// since 0.97 we don't need this anymore ==> AutoPresence property
            
            cboStatus.Text = "online";
            this.cboStatus.SelectedValueChanged += new System.EventHandler(this.cboStatus_SelectedValueChanged);
		}
		
		private void XmppCon_OnRosterItem(object sender, agsXMPP.protocol.iq.roster.RosterItem item)
		{
			if (InvokeRequired)
			{	
				// Windows Forms are not Thread Safe, we need to invoke this :(
				// We're not in the UI thread, so we need to call BeginInvoke				
				BeginInvoke(new agsXMPP.XmppClientConnection.RosterHandler(XmppCon_OnRosterItem), new object[]{this, item});
				return;
			}

			if (item.Subscription != SubscriptionType.remove)
			{
                rosterControl.AddRosterItem(item);

                AddRosterGroup(item);
			}
			else
			{                
                rosterControl.RemoveRosterItem(item);
			}			
		}

        private void AddRosterGroup(agsXMPP.protocol.iq.roster.RosterItem item)
        {

            ElementList elements = item.GetGroups();
            foreach (Element element in elements)
            {
                if (!groups.Contains(element.Value))
                {
                    groups.Add(element.Value);
                    System.Windows.Forms.ToolStripMenuItem g = new System.Windows.Forms.ToolStripMenuItem(element.Value);
                    this.movetoToolStripMenuItem.DropDownItems.Add(g);
                    g.Click += delegate(object s, EventArgs e)
                    {
                        System.Windows.Forms.ToolStripMenuItem grp = (System.Windows.Forms.ToolStripMenuItem)s;

                        RosterNode node = rosterControl.SelectedItem();
                        if (node != null)
                        {
                            XmppCon.RosterManager.UpdateRosterItem(node.RosterItem.Jid, node.RosterItem.Name, grp.Text);
                        }
                    };
                }
            }
        }
		
		private void XmppCon_OnAgentStart(object sender)
		{

		}

		private void XmppCon_OnAgentEnd(object sender)
		{

		}

		private void XmppCon_OnAgentItem(object sender, agsXMPP.protocol.iq.agent.Agent agent)
		{

		}

		private void XmppCon_OnLogin(object sender)
		{
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(XmppCon_OnLogin), new object[] { sender});
                return;
            }
			
            toolStripButtonConnect.Enabled	= false;
            toolStripButtonDisconnect.Enabled = true;
            statusBar1.Text = "Online";

            toolStripLabelLogon.Text = XmppCon.MyJID.User;

            DiscoServer();

            xmppAccount.UpdateVcard();
		}

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void XmppCon_OnAuthError(object sender, Element e)
		{
			if (InvokeRequired)
			{	
				// Windows Forms are not Thread Safe, we need to invoke this :(
				// We're not in the UI thread, so we need to call BeginInvoke				
				BeginInvoke(new XmppElementHandler(XmppCon_OnAuthError), new object[]{sender, e});
				return;
			}
			
			if (XmppCon.XmppConnectionState != XmppConnectionState.Disconnected)
                XmppCon.Close();

			MessageBox.Show("Authentication Error!\r\nWrong password or username.", 
				"Error", 
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation,
				MessageBoxDefaultButton.Button1);
            
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="pres"></param>
		private void XmppCon_OnPresence(object sender, Presence pres)
		{
			if (InvokeRequired)
			{	
				// Windows Forms are not Thread Safe, we need to invoke this :(
				// We're not in the UI thread, so we need to call BeginInvoke				
				BeginInvoke(new OnPresenceDelegate(XmppCon_OnPresence), new object[]{sender, pres});
				return;
			}

			if (pres.Type == PresenceType.subscribe)
			{
				frmSubscribe f = new frmSubscribe(XmppCon, pres.From);
                f.PopUp(this);
			}
			else if(pres.Type == PresenceType.subscribed)
			{

			}
			else if(pres.Type == PresenceType.unsubscribe)
			{

			}
			else if(pres.Type == PresenceType.unsubscribed)
			{

			}
			else
			{
                try
                {
                    rosterControl.SetPresence(pres);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
			}

		}

        private void XmppCon_OnIq(object sender, agsXMPP.protocol.client.IQ iq)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new IqHandler(XmppCon_OnIq), new object[] { sender, iq });
                return;
            }
                       

            if (iq != null)
            {
                // No Iq with query
                if (iq.HasTag(typeof(agsXMPP.protocol.extensions.si.SI)))
                {
                    if (iq.Type == IqType.set)
                    {
                        agsXMPP.protocol.extensions.si.SI si = iq.SelectSingleElement(typeof(agsXMPP.protocol.extensions.si.SI)) as agsXMPP.protocol.extensions.si.SI;

                        agsXMPP.protocol.extensions.filetransfer.File file = si.File;
                        if (file != null)
                        {
                            // somebody wants to send a file to us
                            Console.WriteLine(file.Size.ToString());
                            Console.WriteLine(file.Name);
                            frmFileTransfer frmFile = new frmFileTransfer(XmppCon, iq);
                            frmFile.PopUp(this);
                        }
                    }
                }                
                else
                {
                    Element query = iq.Query;

                    if (query != null)
                    {
                        if (query.GetType() == typeof(agsXMPP.protocol.iq.version.Version))
                        {
                            // its a version IQ VersionIQ
                            agsXMPP.protocol.iq.version.Version version = query as agsXMPP.protocol.iq.version.Version;
                            if (iq.Type == IqType.get)
                            {
                                // Somebody wants to know our client version, so send it back
                                iq.SwitchDirection();
                                iq.Type = IqType.result;

                                version.Name = "Messaging";
                                version.Ver = "0.5";
                                version.Os = Environment.OSVersion.ToString();

                                XmppCon.Send(iq);
                            }
                        }                        
                    }
                }
            }
        }

        /// <summary>
		/// We received a message
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="msg"></param>
		private void XmppCon_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
		{
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new OnMessageDelegate(XmppCon_OnMessage), new object[] { sender, msg });
                return;
            }

            // Dont handle GroupChat Messages here, they have their own callbacks in the
            // GroupChat Form
            if (msg.Type == MessageType.groupchat)
                return;

            if (msg.Type == MessageType.error)
            {
                //Handle errors here
                // we dont handle them in this example
                return;
            }


            if (msg.HasTag(typeof(XmppElement)))
            {
                Element e = msg.SelectSingleElement(typeof(XmppElement));
                XmppElement xdata = e as XmppElement;
                XmppMessageDispatcher.Instance.OnXmppEvent(msg, xdata);
            }
            // check for xData Message
            else if (msg.HasTag(typeof(agsXMPP.protocol.x.data.Data)))
			{
                Element e = msg.SelectSingleElement(typeof(agsXMPP.protocol.x.data.Data));
                agsXMPP.protocol.x.data.Data xdata = e as agsXMPP.protocol.x.data.Data;
				if (xdata.Type == XDataFormType.form)
				{
					frmXData fXData = new frmXData(xdata);
					fXData.Text = "xData Form from " + msg.From.ToString();
                    fXData.PopUp(this);
				}
			}
            else if(msg.HasTag(typeof(agsXMPP.protocol.extensions.ibb.Data)))
            {
                // ignore IBB messages
                return;
            }
			else
			{
                if (msg.Body != null)
                {
                    if (!Util.ChatForms.ContainsKey(msg.From.Bare))
                    {
                        RosterNode rn = rosterControl.GetRosterItem(msg.From);
                        string nick = msg.From.Bare;
                        if (rn != null)
                            nick = rn.Text;

                        frmChat f = new frmChat(msg.From, XmppCon, nick);
                        f.PopUp(this, FormPlace.Floating);
                        f.IncomingMessage(msg);
                    }
                }
			}
		}

		private void XmppCon_OnClose(object sender)
		{
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new ObjectHandler(XmppCon_OnClose), new object[] {sender});
                return;
            }

            toolStripButtonConnect.Enabled = true;
            toolStripButtonDisconnect.Enabled = false;
            cboStatus.SelectedValueChanged -= new System.EventHandler(this.cboStatus_SelectedValueChanged);

			cboStatus.Text = "offline";
            statusBar1.Text = "OffLine";
            rosterControl.Clear();
           // this.treeViewConferences.Nodes.Clear();

		}
		
		private void XmppCon_OnError(object sender, Exception ex)
		{

		}
		#endregion

        private bool ClientSocket_OnValidateCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
			return true;
		}

		private void ClientSocket_OnReceive(object sender, byte[] data, int count)
		{
			if (InvokeRequired)
			{	
				// Windows Forms are not Thread Safe, we need to invoke this :(
				// We're not in the UI thread, so we need to call BeginInvoke				
				BeginInvoke(new agsXMPP.net.ClientSocket.OnSocketDataHandler(ClientSocket_OnReceive), new object[]{sender, data, count});
				return;
			}
#if DEBUG
            try
            {
                rtfDebugSocket.SelectionStart = rtfDebug.Text.Length;
                rtfDebugSocket.SelectionLength = 0;
                rtfDebugSocket.SelectionColor = Color.Red;
                rtfDebugSocket.AppendText("RECV: ");

                rtfDebugSocket.SelectionStart = rtfDebug.Text.Length;
                rtfDebugSocket.SelectionLength = 0;
                rtfDebugSocket.SelectionColor = Color.Black;
                rtfDebugSocket.AppendText(System.Text.Encoding.Default.GetString(data, 0, count));
                rtfDebugSocket.AppendText("\r\n\r\n");
            }
            catch { }
#endif
		}

		private void ClientSocket_OnSend(object sender, byte[] data, int count)
		{
			if (InvokeRequired)
			{	
				// Windows Forms are not Thread Safe, we need to invoke this :(
				// We're not in the UI thread, so we need to call BeginInvoke				
				BeginInvoke(new agsXMPP.net.ClientSocket.OnSocketDataHandler(ClientSocket_OnSend), new object[]{sender, data, count});
				return;
			}
#if DEBUG
            try
            {
                rtfDebugSocket.SelectionStart = rtfDebug.Text.Length;
                rtfDebugSocket.SelectionLength = 0;
                rtfDebugSocket.SelectionColor = Color.Blue;
                rtfDebugSocket.AppendText("SEND: ");

                rtfDebugSocket.SelectionStart = rtfDebug.Text.Length;
                rtfDebugSocket.SelectionLength = 0;
                rtfDebugSocket.SelectionColor = Color.Black;
                rtfDebugSocket.AppendText(System.Text.Encoding.Default.GetString(data, 0, count));
                rtfDebugSocket.AppendText("\r\n\r\n");
            }
            catch { }
#endif
		}
        
		private void XmppCon_OnXmppConnectionStateChanged(object sender, XmppConnectionState state)
		{
			Console.WriteLine("OnXmppConnectionStateChanged: " + state.ToString());
		}
		
		private void OnBrowseIQ(object sender, IQ iq, object data)
		{			
			Element s = iq.SelectSingleElement(typeof(agsXMPP.protocol.iq.browse.Service));
			if (s!=null)
			{
				agsXMPP.protocol.iq.browse.Service service = s as agsXMPP.protocol.iq.browse.Service;
				string[] ns = service.GetNamespaces();
			}			
		}

        #region << RequestDiscover >>
        public void RequestDiscovery()
        {
            //DiscoItemsIq discoIq = new DiscoItemsIq(IqType.get);
            ////TreeNode node = treeGC.SelectedNode;
            ////discoIq.To = new Jid(this.XmppCon.Server);
            //discoIq.To = new Jid("amessage.info");
            //this.XmppCon.IqGrabber.SendIq(discoIq, new IqCB(OnGetDiscovery), null);
        }

        /// <summary>
        /// Callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="iq"></param>
        /// <param name="data"></param>
        private void OnGetDiscovery(object sender, IQ iq, object data)
        {
            DiscoItems items = iq.Query as DiscoItems;
            if (items == null)
                return;

            DiscoItem[] rooms = items.GetDiscoItems();
            foreach (DiscoItem item in rooms)
            {
                Console.WriteLine(item.Name);
            }
        }
        #endregion

        #region << lookup chatrooms on a chatserver using service discovery >>

        /// <summary>
        /// Discover chatromms of a chat server using disco (service discovery)
        /// </summary>
        private void FindChatRooms()
        {
            TreeNode node = treeViewConferences.SelectedNode;
            if (node == null || node.Level != 0)
                return;

            DiscoItemsIq discoIq = new DiscoItemsIq(IqType.get);
            discoIq.To = new Jid(node.Text);
            this.XmppCon.IqGrabber.SendIq(discoIq, new IqCB(OnGetChatRooms), node);
            
        }

        /// <summary>
        /// Callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="iq"></param>
        /// <param name="data"></param>
        private void OnGetChatRooms(object sender, IQ iq, object data)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new IqCB(OnGetChatRooms), new object[] { sender, iq, data });
                return;
            }

            TreeNode node = data as TreeNode;
            node.Nodes.Clear();

            DiscoItems items = iq.Query as DiscoItems;
            if (items == null)
                return;

            DiscoItem[] rooms = items.GetDiscoItems();
            foreach (DiscoItem item in rooms)
            {
                TreeNode n = new TreeNode(item.Name);
                n.Tag           = item.Jid.ToString();
                n.ImageIndex    = n.SelectedImageIndex  = IMAGE_CHATROOM;
                
                node.Nodes.Add(n);
            }

            node.ExpandAll();
        }

        private void FindParticipants()
        {
            TreeNode node = treeViewConferences.SelectedNode;
            if (node == null || node.Level != 1)
                return;

            DiscoItemsIq discoIq = new DiscoItemsIq(IqType.get);
            discoIq.To = new Jid((string) node.Tag);
            this.XmppCon.IqGrabber.SendIq(discoIq, new IqCB(OnGetParticipants), node);

           
        }

        private void OnGetParticipants(object sender, IQ iq, object data)
        {
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new IqCB(OnGetParticipants), new object[] { sender, iq, data });
                return;
            }

            TreeNode node = data as TreeNode;
            node.Nodes.Clear();

            DiscoItems items = iq.Query as DiscoItems;
            if (items == null)
                return;

            DiscoItem[] rooms = items.GetDiscoItems();
            foreach (DiscoItem item in rooms)
            {
                TreeNode n = new TreeNode(item.Jid.Resource);
                n.Tag           = item.Jid.ToString();
                n.ImageIndex    = n.SelectedImageIndex  = IMAGE_PARTICIPANT;
                node.Nodes.Add(n);
            }

            node.ExpandAll();
        }
        #endregion

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RosterNode node = rosterControl.SelectedItem();
            if (node != null)
            {
                if (!Util.ChatForms.ContainsKey(node.RosterItem.Jid.ToString()))
                {
                    frmChat f = new frmChat(node.RosterItem.Jid, XmppCon, node.Text);
                    f.PopUp(this, FormPlace.Floating);
                }
                else
                {
                    frmChat f = Util.ChatForms[node.RosterItem.Jid.ToString()];
                    f.BringFormToFront();
                }
            }	
        }

        private void vcardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RosterNode node = rosterControl.SelectedItem();
            if (node != null)
            {
                frmVcard f = new frmVcard(node.RosterItem.Jid, XmppCon);
                f.PopUp(this);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RosterNode node = rosterControl.SelectedItem();
            if (node != null)
            {
                RosterIq riq = new RosterIq();
                riq.Type = IqType.set;

                XmppCon.RosterManager.RemoveRosterItem(node.RosterItem.Jid);
            }
        }

        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RosterNode node = rosterControl.SelectedItem();

            if (node != null)
            {
                if (node.Nodes.Count > 0)
                {
                    Jid jid = node.RosterItem.Jid;
                    jid.Resource = node.FirstNode.Text;
                    frmFileTransfer ft = new frmFileTransfer(XmppCon, jid);
                    ft.PopUp(this);
                }               
            }
        }


        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RosterNode node = rosterControl.SelectedItem();
            if (node != null)
            {
                frmInputBox input = new frmInputBox("Rename to:", "Input", node.RosterItem.Name);
                if (input.ShowDialog() == DialogResult.OK)
                {
                    string nickname = input.Result;
                    ElementList elements = node.RosterItem.GetGroups();
                    
                    string[] groups = null;
                    if(elements.Count >0)
                    {
                        groups = new string[elements.Count];
                        int i=0;
                        foreach (Element element in elements)
                            groups[i++] = element.Value;
                    }

                    if(groups!=null)
                        XmppCon.RosterManager.UpdateRosterItem(node.RosterItem.Jid, nickname, groups);
                    else
                        XmppCon.RosterManager.UpdateRosterItem(node.RosterItem.Jid, nickname);
                }
            }			
        }


        private void movetoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RosterNode node = rosterControl.SelectedItem();
            if (node != null)
            {
            }			
        }

   

        private void rosterControl_SelectionChanged(object sender, EventArgs e)
        {
            RosterNode node = rosterControl.SelectedItem();
            if (node != null)
            {
                if (node.NodeType == RosterNodeType.RosterNode)
                    rosterControl.ContextMenuStrip = this.contextMenuStripRoster;
                else if (node.NodeType == RosterNodeType.GroupNode)
                    rosterControl.ContextMenuStrip = null;    // Add Group context menu here
                else if (node.NodeType == RosterNodeType.RootNode)
                    rosterControl.ContextMenuStrip = null;    // Add RootNode context menu here
                else if (node.NodeType == RosterNodeType.ResourceNode)
                    rosterControl.ContextMenuStrip = null;    // Add Resource Context Menu here

               
            }
        }

        private void rosterControl_TreeViewMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            RosterNode node = rosterControl.SelectedItem();

            if (node != null && node.NodeType == RosterNodeType.RosterNode)
            {
                chatToolStripMenuItem_Click(sender, e);
            }
        }



        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            frmAddRoster f = new frmAddRoster(new Jid(""), "", groups, XmppCon);
            f.PopUp(this);    
        }

        private void cboStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (XmppCon != null && XmppCon.Authenticated)
			{
				if (cboStatus.Text == "online")
				{
					XmppCon.Show = ShowType.NONE;
				}
                else if (cboStatus.Text == "offline")
                {
                    XmppCon.Close(); 
                }
                else
                {
                    XmppCon.Show = (ShowType)Enum.Parse(typeof(ShowType), cboStatus.Text);
                }
				XmppCon.SendMyPresence();
			}		
        }       

        private void joinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Join a ChatRoom
            if (XmppCon.XmppConnectionState == XmppConnectionState.Disconnected)
                return;

            TreeNode node = this.treeViewConferences.SelectedNode;
            if (node != null && node.Level == 1)
            {
                // Ask for the Nickname for this GroupChat
                frmInputBox input = new frmInputBox("Enter your Nickname for the conference room: " + node.Text, "Nickname", account.Name);
                if (input.ShowDialog() == DialogResult.OK)
                {
                    Jid jid = new Jid((string)node.Tag);
                    string nickname = input.Result;

                    if (!Util.GroupChatForms.ContainsKey(jid.Bare.ToLower()))
                    {
                        frmGroupChat gc = new frmGroupChat(this.XmppCon, jid, nickname);
                        gc.Text = node.Text;
                        gc.PopUp(this);
                    }
                }
            }
        }             

        private void toolStripButtonFindRooms_Click(object sender, EventArgs e)
        {
            if (XmppCon.XmppConnectionState == XmppConnectionState.Disconnected)
                return;

            FindChatRooms(); 
        }

        private void toolStripButtonFindPart_Click(object sender, EventArgs e)
        {
            if (XmppCon.XmppConnectionState == XmppConnectionState.Disconnected)
                return;

            FindParticipants();
        }

        #region << Disco Server >>
        // Sending Disco request to the server we are connected to for discovering
        // the services runing on our server
        private void DiscoServer()
        {           
            discoManager.DiscoverItems(new Jid(XmppCon.Server), new IqCB(OnDiscoServerResult), null);            
        }

        /// <summary>
        /// Callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="iq"></param>
        /// <param name="data"></param>
        private void OnDiscoServerResult(object sender, IQ iq, object data)
        {
            if (iq.Type == IqType.result)
            {
                Element query = iq.Query;
                if (query != null && query.GetType() == typeof(DiscoItems))
                {
                    DiscoItems items = query as DiscoItems;
                    DiscoItem[] itms = items.GetDiscoItems();
                    
                    foreach (DiscoItem itm in itms)
                    {
                        if (itm.Jid == null)
                            continue;
                        
                        switch (itm.Name)
                        {
                            case "Public Chatrooms":
                                AddChatServers(itm);
                                break;

                            default:
                                discoManager.DiscoverInformation(itm.Jid, new IqCB(OnDiscoInfoResult), itm);
                                break;
                        }
                    
                    }
                }
            }
        }

        private void OnDiscoInfoResult(object sender, IQ iq, object data)
        {
            // <iq from='proxy.cachet.myjabber.net' to='gnauck@jabber.org/Exodus' type='result' id='jcl_19'>
            //  <query xmlns='http://jabber.org/protocol/disco#info'>
            //      <identity category='proxy' name='SOCKS5 Bytestreams Service' type='bytestreams'/>
            //      <feature var='http://jabber.org/protocol/bytestreams'/>
            //      <feature var='http://jabber.org/protocol/disco#info'/>
            //  </query>
            // </iq>
            if (iq.Type == IqType.result)
            {
                if (iq.Query is DiscoInfo)
                {
                    DiscoInfo di = iq.Query as DiscoInfo;
                    if (di.HasFeature(agsXMPP.Uri.IQ_SEARCH))
                    {
                        Jid jid = iq.From;
                        if (!Util.Services.Search.Contains(jid))
                            Util.Services.Search.Add(jid);
                    }
                    else if (di.HasFeature(agsXMPP.Uri.BYTESTREAMS))
                    {
                        Jid jid = iq.From;
                        if (!Util.Services.Proxy.Contains(jid))
                            Util.Services.Proxy.Add(jid);
                    }                    
                    else if(di.HasFeature(agsXMPP.Uri.PUBSUB))
                    {
                        Jid jid = iq.From;
                        if (!Util.Services.PubSub.Contains(jid))
                            Util.Services.PubSub.Add(jid);

                        //discoManager.DiscoverItems(jid, new IqCB(OnDiscoPubSubResult), null);
                        treeViewPubSub.ListNodes(discoManager, iq);
                    }
                }
            }
        }

        //private void OnDiscoPubSubResult(object sender, IQ iq, object data)
        //{
        //    if (iq.Type == IqType.result)
        //    {
        //        if (iq.Query is DiscoItems)
        //        {
        //            DiscoItems discoItems = iq.Query as DiscoItems;
        //            DiscoItem[] items = discoItems.GetDiscoItems();
                    
        //            foreach (DiscoItem item in items)
        //            {
        //                TreeNode n = new TreeNode(item.Node);
        //                n.Tag = item.Name;
        //                n.ImageIndex = n.SelectedImageIndex = IMAGE_SERVER;
        //                this.treeViewPubSub.Nodes.Add(n);
        //            }
        //        }
        //    }
        //}

        private void AddChatServers(DiscoItem discoItem)
        {
            //treeViewConferences.TreeViewNodeSorter = new TreeNodeSorter();
            TreeNode n = new TreeNode(discoItem.Jid.ToString());
            n.Tag = "server";
            n.ImageIndex = n.SelectedImageIndex = IMAGE_SERVER;
            this.treeViewConferences.Nodes.Add(n);
        }

        #endregion

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            frmSearch fSearch = new frmSearch(this.XmppCon);
            fSearch.PopUp(this);
        }

        private void toolStripButtonConnect_Click(object sender, EventArgs e)
        {

            frmLogin f = new frmLogin(XmppCon);

            if (f.ShowDialog() == DialogResult.OK)
            {
                XmppCon.Open();
                // for compression debug statistics
                // XmppCon.ClientSocket.OnIncomingCompressionDebug += new agsXMPP.net.BaseSocket.OnSocketCompressionDebugHandler(ClientSocket_OnIncomingCompressionDebug);
                // XmppCon.ClientSocket.OnOutgoingCompressionDebug += new agsXMPP.net.BaseSocket.OnSocketCompressionDebugHandler(ClientSocket_OnOutgoingCompressionDebug);
            }
        }


        private void toolStripButtonDisconnect_Click(object sender, EventArgs e)
        {
            XmppCon.Close();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!Sys.Constant.USE_XMPP)
                return;

            xmppAccount = new XmppAccount(XmppCon, account);

            if (null == SqlCmd.FillDataRow(
                DataProviderManager.Instance.GetProvider(Constant.XMPP_DATA_PROVIDER),
                "SELECT * FROM {0}..ofUser WHERE username='{1}'", 
                Sys.Constant.XMPP_DATABASE_NAME, 
                account.UserName)
                )

                xmppAccount.Register();
            else
                xmppAccount.Login();

        }

        private void treeGC_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                TreeNode node = treeViewConferences.SelectedNode;
                if (node == null)
                    return;

                if (node.Level == 0)
                {
                    FindChatRooms();
                    return;
                }
                else if (node.Level == 1)
                {
                    FindParticipants();
                    return;
                }
                    //joinToolStripMenuItem_Click(sender, e);
            }
        }

        private void toolStripButtonEditProfile_Click(object sender, EventArgs e)
        {
            frmProfile profile = new frmProfile(xmppAccount, this.XmppCon);
            profile.PopUp(this);
        }


        
        
        #region PubSub
        private void toolStripMenuItemCreateNode_Click(object sender, EventArgs e)
        {
            frmInputBox inputBox = new frmInputBox("Channel Name:", "Create Channel", "");
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                string channel = inputBox.Result;
                if (channel == "")
                    return;

                if (Util.Services.PubSub.Count > 0)
                {
                    Jid jid = Util.Services.PubSub[0];
                    pubSubManager.CreateNode(jid, channel, true, new IqCB(OnPubSubCreateNodeResult));
                }

            }

        }

      
        private void OnPubSubCreateNodeResult(object sender, IQ iq, object data)
        {
            switch(iq.Type)
            {
                case IqType.error:
                  //  this.ErrorMessage = string.Format("Error in creating channel: {0} {1}",iq.Error.Code,iq.Error.Message);
                    break;
                
                case IqType.result:
                   // this.InformationMessage = "Channel is created.";
                    break;
            }
        }

        #endregion


    }
}
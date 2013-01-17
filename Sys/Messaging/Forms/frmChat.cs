using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using agsXMPP;
using agsXMPP.protocol;
using agsXMPP.protocol.client;
using agsXMPP.Collections;
using Sys.Messaging.DpoClass;
using Sys.ViewManager.Forms;

namespace Sys.Messaging.Forms
{
	/// <summary>
	/// 
	/// </summary>
	public class frmChat : BaseForm 
	{
				
		private System.ComponentModel.Container components = null;

		private XmppClientConnection	xmppCon;
		private Jid						m_Jid;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button cmdSend;
		private System.Windows.Forms.RichTextBox rtfSend;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.RichTextBox rtfChat;
		private string					nickname;
        
        LogChat log;
        int position;
		
		public frmChat(Jid jid, XmppClientConnection con, string nickname)
		{
			m_Jid		= jid;
			xmppCon = con;
			this.nickname	= nickname;

			InitializeComponent();
            this.allAccess = true;

            this.Text = "Chat with " + this.nickname;
			Util.ChatForms.Add(m_Jid.Bare.ToLower(), this);

            log = new LogChat(account, jid);
            string history = log.LatestChat();
            if (history != null)
            {
                rtfChat.SelectionStart = rtfChat.Text.Length;
                rtfChat.SelectionLength = 0;
                rtfChat.SelectionColor = Color.Brown;
                rtfChat.AppendText(history);
                rtfChat.AppendText("\r\n");
            }

            rtfChat.SelectionColor = Color.Beige;
            rtfChat.AppendText(DateTime.Now.ToString());
            rtfChat.AppendText("\r\n");

            position = rtfChat.Text.Length;

			// Setup new Message Callback
            con.MessageGrabber.Add(jid, new BareJidComparer(), new MessageCB(MessageCallback), null);
		}

        //public frmChat(Jid jid, XmppClientConnection con, string nickname, bool privateChat)
        //{
        //    m_Jid = jid;
        //    _connection = con;
        //    _nickname = nickname;



        //    InitializeComponent();

        //    this.Text = "Chat with " + nickname;

        //    Util.ChatForms.Add(m_Jid.Bare.ToLower(), this);

        //    rtfChat.SelectionColor = Color.Beige;
        //    rtfChat.AppendText(DateTime.Now.ToString());
        //    rtfChat.AppendText("\r\n");

        //    // Setup new Message Callback
        //    if (privateChat)
        //        con.MessageGrabber.Add(jid, new BareJidComparer(), new MessageCB(MessageCallback), null);
        //    else
        //        con.MessageGrabber.Add(jid, new FullJidComparer(), new MessageCB(MessageCallback), null);
        //}

		public Jid Jid
		{
			get { return m_Jid; }
			set { m_Jid = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		protected override void Dispose( bool disposing )
		{
            log.Save(rtfChat.Text.Substring(position));

			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
			
			Util.ChatForms.Remove(m_Jid.Bare.ToLower());
            xmppCon.MessageGrabber.Remove(m_Jid);
			xmppCon = null;
		}

		#region Form-Designer Code
		
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChat));
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.rtfSend = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.rtfChat = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 327);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(412, 24);
            this.statusBar1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 291);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(412, 36);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // cmdSend
            // 
            this.cmdSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSend.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSend.Location = new System.Drawing.Point(332, 297);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(72, 24);
            this.cmdSend.TabIndex = 7;
            this.cmdSend.Text = "&Send";
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click);
            // 
            // rtfSend
            // 
            this.rtfSend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtfSend.Location = new System.Drawing.Point(0, 243);
            this.rtfSend.Name = "rtfSend";
            this.rtfSend.Size = new System.Drawing.Size(412, 48);
            this.rtfSend.TabIndex = 8;
            this.rtfSend.Text = "";
            this.rtfSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtfSend_KeyPress);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 235);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(412, 8);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // rtfChat
            // 
            this.rtfChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfChat.Location = new System.Drawing.Point(0, 0);
            this.rtfChat.Name = "rtfChat";
            this.rtfChat.ReadOnly = true;
            this.rtfChat.Size = new System.Drawing.Size(412, 235);
            this.rtfChat.TabIndex = 10;
            this.rtfChat.Text = "";
            // 
            // frmChat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(412, 351);
            this.Controls.Add(this.rtfChat);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.rtfSend);
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChat";
            this.Text = "frmChat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChat_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChat_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void OutgoingMessage(agsXMPP.protocol.client.Message msg)
		{
			rtfChat.SelectionColor = Color.Blue;
            rtfChat.AppendText(string.Format("({0:HH:mm}) Me: ", DateTime.Now));
			rtfChat.SelectionColor = Color.Black;
			rtfChat.AppendText(msg.Body);
			rtfChat.AppendText("\r\n");

            rtfChat.SelectionStart = rtfChat.Text.Length;
            rtfChat.ScrollToCaret();
		}

		public void IncomingMessage(agsXMPP.protocol.client.Message msg)
		{
            this.BringFormToFront();

			rtfChat.SelectionColor = Color.Red;
            rtfChat.AppendText(string.Format("({0:HH:mm}) {1}: ",DateTime.Now, nickname ));
			rtfChat.SelectionColor = Color.Black;
			rtfChat.AppendText(msg.Body);
			rtfChat.AppendText("\r\n");

            rtfChat.SelectionStart = rtfChat.Text.Length;
            rtfChat.ScrollToCaret();

		}

		private void cmdSend_Click(object sender, System.EventArgs e)
		{
			agsXMPP.protocol.client.Message msg = new agsXMPP.protocol.client.Message();

			msg.Type	= MessageType.chat;
			msg.To		= m_Jid;
			msg.Body	= rtfSend.Text;
			
			xmppCon.Send(msg);
			OutgoingMessage(msg);
			rtfSend.Text = "";
		}

		private void MessageCallback(object sender, agsXMPP.protocol.client.Message msg, object data)
		{
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new MessageCB(MessageCallback), new object[] { sender, msg, data });
                return;
            }
            
            if (msg.Body != null)
			    IncomingMessage(msg);
		}

        private void frmChat_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void rtfSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                cmdSend_Click(sender, null);
        }

		
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using agsXMPP;
using agsXMPP.Xml;
using agsXMPP.Xml.Dom;

using agsXMPP.protocol.iq.disco;
using Sys.OS;
using Sys.ViewManager.Forms;


namespace Sys.Messaging.Forms
{
	/// <summary>
	/// Summary for frmLogin.
	/// </summary>
	public class frmLogin : BaseForm 
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtJid;
		private System.Windows.Forms.Button cmdLogin;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;		
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtResource;
		private System.Windows.Forms.NumericUpDown numPriority;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.CheckBox chkSSL;
        private CheckBox chkRegister;

		private XmppClientConnection xmppCon;

		public frmLogin(XmppClientConnection con)
		{			
			InitializeComponent();
            this.allAccess = true;

			LoadSettings();
			this.DialogResult = DialogResult.Cancel;
			xmppCon = con;

            if (account.IsDeveloper)
                chkRegister.Enabled = true;
		}

		/// <summary>
		/// 
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode f�r die Designerunterst�tzung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.txtJid = new System.Windows.Forms.TextBox();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResource = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.chkSSL = new System.Windows.Forms.CheckBox();
            this.chkRegister = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Badge ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtJid
            // 
            this.txtJid.Location = new System.Drawing.Point(80, 8);
            this.txtJid.Name = "txtJid";
            this.txtJid.Size = new System.Drawing.Size(168, 20);
            this.txtJid.TabIndex = 0;
            // 
            // cmdLogin
            // 
            this.cmdLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdLogin.Location = new System.Drawing.Point(32, 213);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(88, 24);
            this.cmdLogin.TabIndex = 7;
            this.cmdLogin.Text = "Login";
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancel.Location = new System.Drawing.Point(139, 213);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(88, 24);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(80, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "user@server.org";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(80, 56);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(168, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numPriority
            // 
            this.numPriority.Enabled = false;
            this.numPriority.Location = new System.Drawing.Point(80, 88);
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(40, 20);
            this.numPriority.TabIndex = 2;
            this.numPriority.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Priority:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Resource:";
            // 
            // txtResource
            // 
            this.txtResource.Enabled = false;
            this.txtResource.Location = new System.Drawing.Point(80, 120);
            this.txtResource.Name = "txtResource";
            this.txtResource.Size = new System.Drawing.Size(168, 20);
            this.txtResource.TabIndex = 4;
            this.txtResource.Text = "APP";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(136, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(176, 88);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(72, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "5222";
            // 
            // chkSSL
            // 
            this.chkSSL.Enabled = false;
            this.chkSSL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSSL.Location = new System.Drawing.Point(80, 152);
            this.chkSSL.Name = "chkSSL";
            this.chkSSL.Size = new System.Drawing.Size(160, 16);
            this.chkSSL.TabIndex = 5;
            this.chkSSL.Text = "use SSL (old style SSL)";
            this.chkSSL.CheckedChanged += new System.EventHandler(this.chkSSL_CheckedChanged);
            // 
            // chkRegister
            // 
            this.chkRegister.Enabled = false;
            this.chkRegister.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRegister.Location = new System.Drawing.Point(80, 174);
            this.chkRegister.Name = "chkRegister";
            this.chkRegister.Size = new System.Drawing.Size(160, 16);
            this.chkRegister.TabIndex = 6;
            this.chkRegister.Text = "register new Account";
            // 
            // frmLogin
            // 
            this.AcceptButton = this.cmdLogin;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(258, 249);
            this.Controls.Add(this.chkRegister);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtResource);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtJid);
            this.Controls.Add(this.chkSSL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numPriority);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdLogin);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login form";
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void cmdLogin_Click(object sender, System.EventArgs e)
		{
			Jid jid = new Jid(txtJid.Text+"@" + Configuration.Instance.GetValue<string>("Xmpp.Host"));
			
			xmppCon.Server			            = jid.Server;
			xmppCon.Username		            = jid.User;
			xmppCon.Password		            = txtPassword.Text;
            xmppCon.Resource                    = txtResource.Text;
			xmppCon.Priority		            = (int) numPriority.Value;
			xmppCon.Port			            = int.Parse(txtPort.Text);
			xmppCon.UseSSL			            = chkSSL.Checked;
            xmppCon.AutoResolveConnectServer    = true;
            xmppCon.UseCompression              = false;

            //_connection.SocketConnectionType    = agsXMPP.net.SocketConnectionType.Bosh;
            //_connection.ConnectServer = "http://vm-2k:8080/http-bind/";            
			

            if (chkRegister.Checked)                
                xmppCon.RegisterAccount = true;            
            else
                xmppCon.RegisterAccount = false;


            // Caps
            xmppCon.EnableCapabilities = true;
            xmppCon.ClientVersion = "1.0";
            xmppCon.Capabilities.Node = "http://www.ag-software.de/miniclient/caps";
            

            // overwrite some settings for debugging
            //_connection.UseStartTLS     = false;
            //_connection.UseSSL          = false;

            // overwrite some settings for Polling Test
            //_connection.SocketConnectionType	      = agsXMPP.net.SocketConnectionType.HttpPolling;
            //_connection.UseCompression              = false;
            //_connection.UseStartTLS	              = false;
            //_connection.UseSSL                      = false;
            //_connection.AutoResolveConnectServer    = false;
            //_connection.ConnectServer               = "http://vm-2000:5280/http-poll";

            
            SetDiscoInfo();
            
			this.DialogResult = DialogResult.OK;
			
			SaveSettings();
			
			this.Close();
		}

        private void SetDiscoInfo()
        {
            xmppCon.DiscoInfo.AddIdentity(new DiscoIdentity("pc", "Messaging", "client"));

            xmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.DISCO_INFO));
            xmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.DISCO_ITEMS));
            xmppCon.DiscoInfo.AddFeature(new DiscoFeature(agsXMPP.Uri.MUC));
            
            // for testing to bypass disco caches
            //_connection.DiscoInfo.AddFeature(new DiscoFeature(Guid.NewGuid().ToString())); 
        }

		private string SettingsFilename
		{
			get
			{
				string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
				return path + @"\Settings.xml";
			}
		}

		private void LoadSettings()
		{
            //if (System.IO.File.Exists(SettingsFilename))
            //{
            //    Document doc = new Document();

            //    doc.LoadFile(SettingsFilename);
            //    Settings.Login login = doc.RootElement.SelectSingleElement(typeof(Settings.Login)) as Settings.Login;

            //    txtJid.Text = login.Jid.ToString();
            //    txtPassword.Text = login.Password;
            //    txtResource.Text = login.Resource;
            //    numPriority.Value = login.Priority;
            //    chkSSL.Checked = login.Ssl;
            //}
            //else
            {
                txtJid.Text = account.UserName;
                txtPassword.Text = "password";
            }
		}

		private void SaveSettings()
		{
            //Document doc = new Document();
			
            //Settings.Settings settings = new Settings.Settings();

            //Settings.Login login = new Settings.Login();

            //login.Jid = new Jid(txtJid.Text);
            //login.Password  = txtPassword.Text;
            //login.Resource  = txtResource.Text;
            //login.Priority  = (int) numPriority.Value;
            //login.Port      = int.Parse(txtPort.Text);
            //login.Ssl       = chkSSL.Checked;

            //doc.ChildNodes.Add(settings);
            //settings.Login = login;
		
            //doc.Save(SettingsFilename);
		}

		private void chkSSL_CheckedChanged(object sender, System.EventArgs e)
		{
			txtPort.Text = "5223";
		}
	}
}
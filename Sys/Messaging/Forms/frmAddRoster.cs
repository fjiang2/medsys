using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using agsXMPP.protocol.iq.roster;

using agsXMPP;
using Sys.Xmpp;
using Sys.ViewManager.Forms;

namespace Sys.Messaging.Forms
{
	/// <summary>
	/// Summary description for femAddRoster.
	/// </summary>
    public class frmAddRoster : BaseForm 
	{
		private System.Windows.Forms.TextBox txtNickname;
		private System.Windows.Forms.TextBox txtJid;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdAdd;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Label label2;
        private ComboBox comboGroup;
        private Button cmdCancel;

		private XmppClientConnection xmppCon;
        
		public frmAddRoster(XmppClientConnection con)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            this.allAccess = true;

			xmppCon = con;

            
		}

        public frmAddRoster(Jid jid, XmppClientConnection con)
            : this(con)
        {
            txtJid.Text = jid.Bare;

        }

        public frmAddRoster(Jid jid, string nickname, XmppClientConnection con)
            : this(jid, con)
        {
            txtNickname.Text = nickname;
        }

        public frmAddRoster(Jid jid, string nickname, List<string> groups, XmppClientConnection con)
            : this(jid, nickname, con)
        {
            foreach(string group in groups)
                comboGroup.Items.Add(group);
        }


		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.txtJid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboGroup = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNickname
            // 
            this.txtNickname.Location = new System.Drawing.Point(80, 56);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(217, 20);
            this.txtNickname.TabIndex = 2;
            // 
            // txtJid
            // 
            this.txtJid.Location = new System.Drawing.Point(80, 27);
            this.txtJid.Name = "txtJid";
            this.txtJid.Size = new System.Drawing.Size(217, 20);
            this.txtJid.TabIndex = 1;
            this.txtJid.TextChanged += new System.EventHandler(this.txtJid_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nickname:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Badge ID:";
            // 
            // cmdAdd
            // 
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdAdd.Location = new System.Drawing.Point(96, 130);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(80, 24);
            this.cmdAdd.TabIndex = 4;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Group:";
            // 
            // comboGroup
            // 
            this.comboGroup.FormattingEnabled = true;
            this.comboGroup.Location = new System.Drawing.Point(80, 92);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.Size = new System.Drawing.Size(217, 21);
            this.comboGroup.TabIndex = 3;
            // 
            // cmdCancel
            // 
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancel.Location = new System.Drawing.Point(205, 130);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 24);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmAddRoster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(374, 181);
            this.Controls.Add(this.comboGroup);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.txtJid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddRoster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Contact";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
            string id = txtJid.Text;

            Jid jid;
            if (id.IndexOf('@') < 0)
                jid = XmppAccount.NewJid(id); 
            else
                jid = new Jid(id);

			// Add the Rosteritem using the Rostermanager
            if (comboGroup.Text.Length > 0)
                xmppCon.RosterManager.AddRosterItem(jid, txtNickname.Text,comboGroup.Text);
            else if (txtNickname.Text.Length > 0)
                xmppCon.RosterManager.AddRosterItem(jid, txtNickname.Text);
            else
                xmppCon.RosterManager.AddRosterItem(jid);

			// Ask for subscription now
			xmppCon.PresenceManager.Subscribe(jid);
						
			this.Close();
		}

        private void txtJid_TextChanged(object sender, EventArgs e)
        {
            if (txtJid.Text == "")
                return;

            Sys.Security.Account account = new Sys.Security.Account(txtJid.Text);
            txtNickname.Text = account.Name;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdNewGroup_Click(object sender, EventArgs e)
        {
            frmInputBox input = new frmInputBox("Enter new group name:", "New Roster Group", "");
            if (input.ShowDialog() == DialogResult.OK)
            {
                //_connection.RosterManager.AddRosterItem(); 
                //string nickname = input.Result;
            }
        }
	}
}

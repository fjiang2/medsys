using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using agsXMPP;
using agsXMPP.protocol;
using agsXMPP.protocol.client;
using agsXMPP.protocol.iq.vcard;
using Sys.ViewManager.Forms;


namespace Sys.Messaging.Forms
{
	/// <summary>
	/// Zusammenfassung für frmVcard.
	/// </summary>
    public class frmVcard : BaseForm 
	{
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private XmppClientConnection _connection;
		private System.Windows.Forms.TextBox txtFullname;
		private System.Windows.Forms.TextBox txtNickname;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Button cmdClose;
        private Label label6;
        private Label label7;
        private TextBox txtDepartment;
        private TextBox txtJobTitle;
        private Label label8;
        private TextBox txtWorkPhone;
        private Label label3;
        private TextBox txtDescription;
		string	packetId;

		public frmVcard(Jid jid, XmppClientConnection con)
		{
			
			InitializeComponent();

            this.allAccess = true;
			
			_connection = con;

			this.Text = "Vcard from: " + jid.Bare;

			VcardIq viq = new VcardIq(IqType.get, new Jid(jid.Bare));
			packetId = viq.Id;
			con.IqGrabber.SendIq(viq, new IqCB(VcardResult), null);			
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
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
			// Remove the packet from the Tracker in case we Close the from before getting
			// the result. The callback yould cause a nullpointer exception
			if (_connection.IqGrabber != null)
				_connection.IqGrabber.Remove(packetId);
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWorkPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full Name:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nick Name:";
            // 
            // txtFullname
            // 
            this.txtFullname.Location = new System.Drawing.Point(99, 12);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.ReadOnly = true;
            this.txtFullname.Size = new System.Drawing.Size(176, 20);
            this.txtFullname.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(99, 80);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(176, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // txtNickname
            // 
            this.txtNickname.Location = new System.Drawing.Point(99, 45);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.ReadOnly = true;
            this.txtNickname.Size = new System.Drawing.Size(176, 20);
            this.txtNickname.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Photo:";
            // 
            // picPhoto
            // 
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.Location = new System.Drawing.Point(59, 162);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(234, 156);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhoto.TabIndex = 9;
            this.picPhoto.TabStop = false;
            // 
            // cmdClose
            // 
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdClose.Location = new System.Drawing.Point(220, 347);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(96, 24);
            this.cmdClose.TabIndex = 4;
            this.cmdClose.Text = "Close";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(321, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Department:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(335, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Job Title:";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(404, 16);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(176, 20);
            this.txtDepartment.TabIndex = 0;
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Location = new System.Drawing.Point(404, 48);
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.ReadOnly = true;
            this.txtJobTitle.Size = new System.Drawing.Size(176, 20);
            this.txtJobTitle.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(321, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Work Phone:";
            // 
            // txtWorkPhone
            // 
            this.txtWorkPhone.Location = new System.Drawing.Point(404, 80);
            this.txtWorkPhone.Name = "txtWorkPhone";
            this.txtWorkPhone.ReadOnly = true;
            this.txtWorkPhone.Size = new System.Drawing.Size(176, 20);
            this.txtWorkPhone.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(99, 107);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(481, 20);
            this.txtDescription.TabIndex = 0;
            // 
            // frmVcard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(592, 407);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtWorkPhone);
            this.Controls.Add(this.txtJobTitle);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtFullname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmVcard";
            this.Text = "frmVcard";
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void VcardResult(object sender, IQ iq, object data)
		{
            if (InvokeRequired)
            {
                // Windows Forms are not Thread Safe, we need to invoke this :(
                // We're not in the UI thread, so we need to call BeginInvoke				
                BeginInvoke(new IqCB(VcardResult), new object[] { sender, iq, data });
                return;
            }
			if (iq.Type == IqType.result)
			{
				Vcard vcard = iq.Vcard;
				if (vcard!=null)
				{
					txtFullname.Text	= vcard.Fullname;
					txtNickname.Text	= vcard.Nickname;

                    try
                    {
                        txtEmail.Text = vcard.GetPreferedEmailAddress().UserId;
                        txtDepartment.Text = vcard.Organization.Unit;
                        txtWorkPhone.Text = vcard.GetTelephoneNumber(TelephoneType.NUMBER, TelephoneLocation.WORK).Number;
                    }
                    catch (Exception)
                    { 
                    
                    }
                    
                    txtJobTitle.Text = vcard.Title;
                    txtDescription.Text = vcard.Description;

                    Photo photo = vcard.Photo;
					if (photo != null)
						picPhoto.Image		= vcard.Photo.Image;
				}
                
                
			}
		}

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        
	}
}

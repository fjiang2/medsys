using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.Data;
using Sys.Data.Manager;

namespace Sys.Platform.Forms
{
	/// <summary>
	/// Summary description for FormSelectDatabase.
	/// </summary>
	public class Connect2ServerForm : Form
	{
		private Button buttonOK;
		private IContainer components = null;

        private Button buttonCancel;
        private Platform.Forms.SqlServerControl sqlServerControl1;
        private PictureBox pictureBox1;

       

		public Connect2ServerForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sqlServerControl1 = new Sys.Platform.Forms.SqlServerControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(123, 271);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(80, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "&Connect";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(223, 271);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sys.Platform.Properties.Resources.SQLServer2008;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(413, 70);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // sqlServerControl1
            // 
            this.sqlServerControl1.Location = new System.Drawing.Point(65, 81);
            this.sqlServerControl1.Name = "sqlServerControl1";
            this.sqlServerControl1.Size = new System.Drawing.Size(278, 175);
            this.sqlServerControl1.TabIndex = 7;
            // 
            // Connect2ServerForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(411, 306);
            this.Controls.Add(this.sqlServerControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Connect2ServerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect to Server";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

     

		private void buttonOK_Click(object sender, EventArgs e)
		{
            if (!sqlServerControl1.Connect())
                return;


            if (!SysInformation.ValidDatabase())
            {
                if (MessageBox.Show("Data cannot be found. Are you sure to install data into SQL Server?", "Confirmation", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    var form = new Sys.Platform.Forms.InstallWizard();
                    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        this.Close();
                        return;
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            // Manager.UpdateSystemDatabaseName();
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}


	
		protected override bool ProcessDialogKey(Keys keyData)
		{
			if(keyData == Keys.Escape) //Escape key
			{
				this.DialogResult = DialogResult.Cancel;
				this.Close();
				return true;
			}

			return base.ProcessDialogKey(keyData);
		}

	

	}
}

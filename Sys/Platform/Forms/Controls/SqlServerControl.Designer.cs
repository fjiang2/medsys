namespace Sys.Platform.Forms
{
    partial class SqlServerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelAuthentication = new System.Windows.Forms.Panel();
            this.radioButtonWindowsAuthentication = new System.Windows.Forms.RadioButton();
            this.radioButtonSQLServerAuthentication = new System.Windows.Forms.RadioButton();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
            this.panelAuthentication.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAuthentication
            // 
            this.panelAuthentication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAuthentication.Controls.Add(this.radioButtonWindowsAuthentication);
            this.panelAuthentication.Controls.Add(this.radioButtonSQLServerAuthentication);
            this.panelAuthentication.Location = new System.Drawing.Point(79, 30);
            this.panelAuthentication.Name = "panelAuthentication";
            this.panelAuthentication.Size = new System.Drawing.Size(193, 48);
            this.panelAuthentication.TabIndex = 8;
            // 
            // radioButtonWindowsAuthentication
            // 
            this.radioButtonWindowsAuthentication.Location = new System.Drawing.Point(15, 29);
            this.radioButtonWindowsAuthentication.Name = "radioButtonWindowsAuthentication";
            this.radioButtonWindowsAuthentication.Size = new System.Drawing.Size(172, 16);
            this.radioButtonWindowsAuthentication.TabIndex = 0;
            this.radioButtonWindowsAuthentication.Text = "&Windows authentication";
            this.radioButtonWindowsAuthentication.CheckedChanged += new System.EventHandler(this.radioButtonWindowsAuthentication_CheckedChanged);
            // 
            // radioButtonSQLServerAuthentication
            // 
            this.radioButtonSQLServerAuthentication.Checked = true;
            this.radioButtonSQLServerAuthentication.Location = new System.Drawing.Point(15, 7);
            this.radioButtonSQLServerAuthentication.Name = "radioButtonSQLServerAuthentication";
            this.radioButtonSQLServerAuthentication.Size = new System.Drawing.Size(172, 16);
            this.radioButtonSQLServerAuthentication.TabIndex = 1;
            this.radioButtonSQLServerAuthentication.TabStop = true;
            this.radioButtonSQLServerAuthentication.Text = "SQL Server &authentication";
            this.radioButtonSQLServerAuthentication.CheckedChanged += new System.EventHandler(this.radioButtonSQLServerAuthentication_CheckedChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPassword.Location = new System.Drawing.Point(14, 119);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(64, 16);
            this.labelPassword.TabIndex = 11;
            this.labelPassword.Text = "&Password:";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelUserName
            // 
            this.labelUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelUserName.Location = new System.Drawing.Point(14, 90);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(64, 16);
            this.labelUserName.TabIndex = 9;
            this.labelUserName.Text = "&User name:";
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(80, 114);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(192, 20);
            this.textBoxPassword.TabIndex = 12;
            // 
            // labelServer
            // 
            this.labelServer.Location = new System.Drawing.Point(-31, 6);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(101, 16);
            this.labelServer.TabIndex = 7;
            this.labelServer.Text = "&Server name:";
            this.labelServer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserName.Location = new System.Drawing.Point(80, 87);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(192, 20);
            this.textBoxUserName.TabIndex = 10;
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxServer.Location = new System.Drawing.Point(80, 3);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(192, 21);
            this.comboBoxServer.TabIndex = 6;
            this.comboBoxServer.Text = "(local)";
            this.comboBoxServer.DropDown += new System.EventHandler(this.comboBoxServer_DropDown);
            // 
            // labelDatabase
            // 
            this.labelDatabase.Location = new System.Drawing.Point(14, 147);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(64, 16);
            this.labelDatabase.TabIndex = 14;
            this.labelDatabase.Text = "&Database:";
            this.labelDatabase.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBoxDatabase
            // 
            this.comboBoxDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDatabase.Location = new System.Drawing.Point(80, 142);
            this.comboBoxDatabase.Name = "comboBoxDatabase";
            this.comboBoxDatabase.Size = new System.Drawing.Size(189, 21);
            this.comboBoxDatabase.TabIndex = 13;
            this.comboBoxDatabase.DropDown += new System.EventHandler(this.comboBoxDatabase_DropDown);
            // 
            // SqlServerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDatabase);
            this.Controls.Add(this.comboBoxDatabase);
            this.Controls.Add(this.panelAuthentication);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelServer);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.comboBoxServer);
            this.Name = "SqlServerControl";
            this.Size = new System.Drawing.Size(278, 175);
            this.panelAuthentication.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAuthentication;
        private System.Windows.Forms.RadioButton radioButtonWindowsAuthentication;
        private System.Windows.Forms.RadioButton radioButtonSQLServerAuthentication;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.ComboBox comboBoxServer;
        private System.Windows.Forms.Label labelDatabase;
        private System.Windows.Forms.ComboBox comboBoxDatabase;
    }
}

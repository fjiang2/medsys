namespace Sys.Platform.Forms
{
    partial class InstallWizard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallWizard));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.pageWelcome = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.pageConnectServer = new DevExpress.XtraWizard.WizardPage();
            this.btnNewDatabase = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlServerControl1 = new Sys.Platform.Forms.SqlServerControl();
            this.btnConnectServer = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pageCompletion = new DevExpress.XtraWizard.CompletionWizardPage();
            this.pageCreateSystemTables = new DevExpress.XtraWizard.WizardPage();
            this.progressCreateSystemTables = new Sys.Platform.Forms.ProgressControl();
            this.pageUnpackSystemdata = new DevExpress.XtraWizard.WizardPage();
            this.progressUnpackSystemData = new Sys.Platform.Forms.ProgressControl();
            this.pageCreateService = new DevExpress.XtraWizard.WizardPage();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCreateServiceMessage = new System.Windows.Forms.TextBox();
            this.btnCreateService = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboxDefaultDatabase = new System.Windows.Forms.ComboBox();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pageUnpackDefaultData = new DevExpress.XtraWizard.WizardPage();
            this.progressUnpackDefaultData = new Sys.Platform.Forms.ProgressControl();
            this.pageCreateDefaultTables = new DevExpress.XtraWizard.WizardPage();
            this.progressCreateDefaultTables = new Sys.Platform.Forms.ProgressControl();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.pageConnectServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pageCreateSystemTables.SuspendLayout();
            this.pageUnpackSystemdata.SuspendLayout();
            this.pageCreateService.SuspendLayout();
            this.pageUnpackDefaultData.SuspendLayout();
            this.pageCreateDefaultTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.Controls.Add(this.pageWelcome);
            this.wizardControl1.Controls.Add(this.pageConnectServer);
            this.wizardControl1.Controls.Add(this.pageCompletion);
            this.wizardControl1.Controls.Add(this.pageCreateSystemTables);
            this.wizardControl1.Controls.Add(this.pageUnpackSystemdata);
            this.wizardControl1.Controls.Add(this.pageCreateService);
            this.wizardControl1.Controls.Add(this.pageUnpackDefaultData);
            this.wizardControl1.Controls.Add(this.pageCreateDefaultTables);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.pageWelcome,
            this.pageConnectServer,
            this.pageCreateSystemTables,
            this.pageUnpackSystemdata,
            this.pageCreateService,
            this.pageCreateDefaultTables,
            this.pageUnpackDefaultData,
            this.pageCompletion});
            this.wizardControl1.Size = new System.Drawing.Size(630, 422);
            this.wizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_FinishClick);
            this.wizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_NextClick);
            this.wizardControl1.PrevClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_PrevClick);
            // 
            // pageWelcome
            // 
            this.pageWelcome.IntroductionText = "System is going to install database, tables structure and data into SQL Server";
            this.pageWelcome.Name = "pageWelcome";
            this.pageWelcome.Size = new System.Drawing.Size(413, 289);
            // 
            // pageConnectServer
            // 
            this.pageConnectServer.Controls.Add(this.btnNewDatabase);
            this.pageConnectServer.Controls.Add(this.label2);
            this.pageConnectServer.Controls.Add(this.sqlServerControl1);
            this.pageConnectServer.Controls.Add(this.btnConnectServer);
            this.pageConnectServer.Controls.Add(this.pictureBox1);
            this.pageConnectServer.DescriptionText = "You have to be database administraor";
            this.pageConnectServer.Name = "pageConnectServer";
            this.pageConnectServer.Size = new System.Drawing.Size(598, 277);
            this.pageConnectServer.Text = "Connect to SQL Server";
            // 
            // btnNewDatabase
            // 
            this.btnNewDatabase.Enabled = false;
            this.btnNewDatabase.Location = new System.Drawing.Point(368, 250);
            this.btnNewDatabase.Name = "btnNewDatabase";
            this.btnNewDatabase.Size = new System.Drawing.Size(117, 23);
            this.btnNewDatabase.TabIndex = 18;
            this.btnNewDatabase.Text = "New Database...";
            this.btnNewDatabase.UseVisualStyleBackColor = true;
            this.btnNewDatabase.Click += new System.EventHandler(this.btnNewDatabase_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "(System Database)";
            // 
            // sqlServerControl1
            // 
            this.sqlServerControl1.Location = new System.Drawing.Point(75, 81);
            this.sqlServerControl1.Name = "sqlServerControl1";
            this.sqlServerControl1.Size = new System.Drawing.Size(278, 175);
            this.sqlServerControl1.TabIndex = 16;
            // 
            // btnConnectServer
            // 
            this.btnConnectServer.Enabled = false;
            this.btnConnectServer.Location = new System.Drawing.Point(491, 250);
            this.btnConnectServer.Name = "btnConnectServer";
            this.btnConnectServer.Size = new System.Drawing.Size(88, 24);
            this.btnConnectServer.TabIndex = 15;
            this.btnConnectServer.Text = "&Connect";
            this.btnConnectServer.Click += new System.EventHandler(this.btnConnectServer_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sys.Platform.Properties.Resources.SQLServer2008;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(413, 70);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pageCompletion
            // 
            this.pageCompletion.FinishText = "You have successfully completed installation";
            this.pageCompletion.Name = "pageCompletion";
            this.pageCompletion.Size = new System.Drawing.Size(413, 289);
            this.pageCompletion.Text = "Completing SQL Server Data Installation";
            // 
            // pageCreateSystemTables
            // 
            this.pageCreateSystemTables.Controls.Add(this.progressCreateSystemTables);
            this.pageCreateSystemTables.DescriptionText = "create new system table structures";
            this.pageCreateSystemTables.Name = "pageCreateSystemTables";
            this.pageCreateSystemTables.Size = new System.Drawing.Size(598, 277);
            this.pageCreateSystemTables.Text = "Create System Tables in the SQL Server";
            // 
            // progressCreateSystemTables
            // 
            this.progressCreateSystemTables.Action = null;
            this.progressCreateSystemTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressCreateSystemTables.Location = new System.Drawing.Point(0, 0);
            this.progressCreateSystemTables.Name = "progressCreateSystemTables";
            this.progressCreateSystemTables.Size = new System.Drawing.Size(598, 277);
            this.progressCreateSystemTables.TabIndex = 0;
            // 
            // pageUnpackSystemdata
            // 
            this.pageUnpackSystemdata.Controls.Add(this.progressUnpackSystemData);
            this.pageUnpackSystemdata.DescriptionText = "";
            this.pageUnpackSystemdata.Name = "pageUnpackSystemdata";
            this.pageUnpackSystemdata.Size = new System.Drawing.Size(598, 277);
            this.pageUnpackSystemdata.Text = "Unpack data into SQL Server";
            // 
            // progressUnpackSystemData
            // 
            this.progressUnpackSystemData.Action = null;
            this.progressUnpackSystemData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressUnpackSystemData.Location = new System.Drawing.Point(0, 0);
            this.progressUnpackSystemData.Name = "progressUnpackSystemData";
            this.progressUnpackSystemData.Size = new System.Drawing.Size(598, 277);
            this.progressUnpackSystemData.TabIndex = 0;
            // 
            // pageCreateService
            // 
            this.pageCreateService.Controls.Add(this.button1);
            this.pageCreateService.Controls.Add(this.txtCreateServiceMessage);
            this.pageCreateService.Controls.Add(this.btnCreateService);
            this.pageCreateService.Controls.Add(this.label1);
            this.pageCreateService.Controls.Add(this.comboxDefaultDatabase);
            this.pageCreateService.Controls.Add(this.txtServiceName);
            this.pageCreateService.Controls.Add(this.label3);
            this.pageCreateService.DescriptionText = "each service works in its own data space";
            this.pageCreateService.Name = "pageCreateService";
            this.pageCreateService.Size = new System.Drawing.Size(598, 277);
            this.pageCreateService.Text = "Create Service";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "New Database...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnNewDatabase_Click);
            // 
            // txtCreateServiceMessage
            // 
            this.txtCreateServiceMessage.Location = new System.Drawing.Point(133, 94);
            this.txtCreateServiceMessage.Multiline = true;
            this.txtCreateServiceMessage.Name = "txtCreateServiceMessage";
            this.txtCreateServiceMessage.ReadOnly = true;
            this.txtCreateServiceMessage.Size = new System.Drawing.Size(267, 143);
            this.txtCreateServiceMessage.TabIndex = 17;
            // 
            // btnCreateService
            // 
            this.btnCreateService.Location = new System.Drawing.Point(449, 194);
            this.btnCreateService.Name = "btnCreateService";
            this.btnCreateService.Size = new System.Drawing.Size(111, 43);
            this.btnCreateService.TabIndex = 16;
            this.btnCreateService.Text = "Create Service";
            this.btnCreateService.UseVisualStyleBackColor = true;
            this.btnCreateService.Click += new System.EventHandler(this.btnCreateService_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(100, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "&Service Database:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboxDefaultDatabase
            // 
            this.comboxDefaultDatabase.Location = new System.Drawing.Point(211, 56);
            this.comboxDefaultDatabase.Name = "comboxDefaultDatabase";
            this.comboxDefaultDatabase.Size = new System.Drawing.Size(189, 21);
            this.comboxDefaultDatabase.TabIndex = 14;
            this.comboxDefaultDatabase.DropDown += new System.EventHandler(this.comboxDefaultDatabase_DropDown);
            // 
            // txtServiceName
            // 
            this.txtServiceName.Location = new System.Drawing.Point(211, 21);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(189, 20);
            this.txtServiceName.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Service:";
            // 
            // pageUnpackDefaultData
            // 
            this.pageUnpackDefaultData.Controls.Add(this.progressUnpackDefaultData);
            this.pageUnpackDefaultData.DescriptionText = "copy service or company level data";
            this.pageUnpackDefaultData.Name = "pageUnpackDefaultData";
            this.pageUnpackDefaultData.Size = new System.Drawing.Size(598, 277);
            this.pageUnpackDefaultData.Text = "Unpack Service Data into SQL Server";
            // 
            // progressUnpackDefaultData
            // 
            this.progressUnpackDefaultData.Action = null;
            this.progressUnpackDefaultData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressUnpackDefaultData.Location = new System.Drawing.Point(0, 0);
            this.progressUnpackDefaultData.Name = "progressUnpackDefaultData";
            this.progressUnpackDefaultData.Size = new System.Drawing.Size(598, 277);
            this.progressUnpackDefaultData.TabIndex = 1;
            // 
            // pageCreateDefaultTables
            // 
            this.pageCreateDefaultTables.Controls.Add(this.progressCreateDefaultTables);
            this.pageCreateDefaultTables.DescriptionText = "create new  service table structures, each service must have its own database";
            this.pageCreateDefaultTables.Name = "pageCreateDefaultTables";
            this.pageCreateDefaultTables.Size = new System.Drawing.Size(598, 277);
            this.pageCreateDefaultTables.Text = "Create Service Data Tables";
            // 
            // progressCreateDefaultTables
            // 
            this.progressCreateDefaultTables.Action = null;
            this.progressCreateDefaultTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressCreateDefaultTables.Location = new System.Drawing.Point(0, 0);
            this.progressCreateDefaultTables.Name = "progressCreateDefaultTables";
            this.progressCreateDefaultTables.Size = new System.Drawing.Size(598, 277);
            this.progressCreateDefaultTables.TabIndex = 1;
            // 
            // InstallWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 422);
            this.Controls.Add(this.wizardControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InstallWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Installing Data";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.pageConnectServer.ResumeLayout(false);
            this.pageConnectServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pageCreateSystemTables.ResumeLayout(false);
            this.pageUnpackSystemdata.ResumeLayout(false);
            this.pageCreateService.ResumeLayout(false);
            this.pageCreateService.PerformLayout();
            this.pageUnpackDefaultData.ResumeLayout(false);
            this.pageCreateDefaultTables.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage pageWelcome;
        private DevExpress.XtraWizard.WizardPage pageConnectServer;
        private DevExpress.XtraWizard.WizardPage pageCreateSystemTables;
        private DevExpress.XtraWizard.WizardPage pageUnpackSystemdata;
        private DevExpress.XtraWizard.WizardPage pageCreateService;
        private DevExpress.XtraWizard.WizardPage pageCreateDefaultTables;
        private DevExpress.XtraWizard.WizardPage pageUnpackDefaultData;
        private DevExpress.XtraWizard.CompletionWizardPage pageCompletion;
        private ProgressControl progressCreateSystemTables;
        private ProgressControl progressUnpackSystemData;
        private ProgressControl progressUnpackDefaultData;
        private ProgressControl progressCreateDefaultTables;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnConnectServer;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboxDefaultDatabase;
        private System.Windows.Forms.TextBox txtCreateServiceMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNewDatabase;
        private SqlServerControl sqlServerControl1;
        private System.Windows.Forms.Button button1;
    }
}
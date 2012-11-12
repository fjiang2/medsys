namespace Sys.Platform.Forms
{
    partial class GenDpoForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkFolder = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboDatabase = new System.Windows.Forms.ComboBox();
            this.chkMustGenerate = new System.Windows.Forms.CheckBox();
            this.btnCreateDpo = new System.Windows.Forms.Button();
            this.rgModifier = new DevExpress.XtraEditors.RadioGroup();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rgDpoLevel = new DevExpress.XtraEditors.RadioGroup();
            this.treeTables = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDatabaseId = new System.Windows.Forms.TextBox();
            this.chkCheckAll = new System.Windows.Forms.CheckBox();
            this.chkShowNewTables = new System.Windows.Forms.CheckBox();
            this.chkPack = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTableId = new System.Windows.Forms.TextBox();
            this.txtCounter = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnUpgradeDpo = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnGenDpoClass = new System.Windows.Forms.Button();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtAssembly = new System.Windows.Forms.TextBox();
            this.comboModule = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Assembly = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonGenDict = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGenSP = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Path:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(91, 184);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(351, 20);
            this.txtPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Database:";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(91, 132);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(351, 20);
            this.txtNamespace.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Class Modifier:";
            // 
            // chkFolder
            // 
            this.chkFolder.AutoSize = true;
            this.chkFolder.Location = new System.Drawing.Point(20, 352);
            this.chkFolder.Name = "chkFolder";
            this.chkFolder.Size = new System.Drawing.Size(330, 17);
            this.chkFolder.TabIndex = 3;
            this.chkFolder.Text = "Create folder and sub-namesapce for database when Level fixed";
            this.chkFolder.UseVisualStyleBackColor = true;
            this.chkFolder.CheckedChanged += new System.EventHandler(this.chkFolder_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Namespace:";
            // 
            // comboDatabase
            // 
            this.comboDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboDatabase.Location = new System.Drawing.Point(74, 38);
            this.comboDatabase.Name = "comboDatabase";
            this.comboDatabase.Size = new System.Drawing.Size(160, 21);
            this.comboDatabase.TabIndex = 1;
            this.comboDatabase.SelectedIndexChanged += new System.EventHandler(this.comboDatabase_SelectedIndexChanged);
            // 
            // chkMustGenerate
            // 
            this.chkMustGenerate.AutoSize = true;
            this.chkMustGenerate.Location = new System.Drawing.Point(20, 375);
            this.chkMustGenerate.Name = "chkMustGenerate";
            this.chkMustGenerate.Size = new System.Drawing.Size(121, 17);
            this.chkMustGenerate.TabIndex = 3;
            this.chkMustGenerate.Text = "Must generate class";
            this.chkMustGenerate.UseVisualStyleBackColor = true;
            // 
            // btnCreateDpo
            // 
            this.btnCreateDpo.Location = new System.Drawing.Point(388, 342);
            this.btnCreateDpo.Name = "btnCreateDpo";
            this.btnCreateDpo.Size = new System.Drawing.Size(135, 35);
            this.btnCreateDpo.TabIndex = 4;
            this.btnCreateDpo.Text = "Create new Dpo classes for new tables";
            this.btnCreateDpo.UseVisualStyleBackColor = true;
            this.btnCreateDpo.Click += new System.EventHandler(this.btnCreateNewDpo_Click);
            // 
            // rgModifier
            // 
            this.rgModifier.Location = new System.Drawing.Point(32, 236);
            this.rgModifier.Name = "rgModifier";
            this.rgModifier.Size = new System.Drawing.Size(133, 110);
            this.rgModifier.TabIndex = 5;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(448, 184);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Table Level:";
            // 
            // rgDpoLevel
            // 
            this.rgDpoLevel.Location = new System.Drawing.Point(194, 236);
            this.rgDpoLevel.Name = "rgDpoLevel";
            this.rgDpoLevel.Size = new System.Drawing.Size(133, 110);
            this.rgDpoLevel.TabIndex = 5;
            this.rgDpoLevel.SelectedIndexChanged += new System.EventHandler(this.rgDpoLevel_SelectedIndexChanged);
            // 
            // treeTables
            // 
            this.treeTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeTables.CheckBoxes = true;
            this.treeTables.Location = new System.Drawing.Point(0, 135);
            this.treeTables.Name = "treeTables";
            this.treeTables.Size = new System.Drawing.Size(274, 501);
            this.treeTables.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtDatabaseId);
            this.splitContainer1.Panel1.Controls.Add(this.treeTables);
            this.splitContainer1.Panel1.Controls.Add(this.comboDatabase);
            this.splitContainer1.Panel1.Controls.Add(this.chkCheckAll);
            this.splitContainer1.Panel1.Controls.Add(this.chkShowNewTables);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkPack);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.txtTableId);
            this.splitContainer1.Panel2.Controls.Add(this.txtCounter);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel2.Controls.Add(this.btnUpgradeDpo);
            this.splitContainer1.Panel2.Controls.Add(this.txtOutput);
            this.splitContainer1.Panel2.Controls.Add(this.btnGenDpoClass);
            this.splitContainer1.Panel2.Controls.Add(this.txtClass);
            this.splitContainer1.Panel2.Controls.Add(this.txtAssembly);
            this.splitContainer1.Panel2.Controls.Add(this.comboModule);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.Assembly);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnBrowse);
            this.splitContainer1.Panel2.Controls.Add(this.txtPath);
            this.splitContainer1.Panel2.Controls.Add(this.rgDpoLevel);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.rgModifier);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txtTableName);
            this.splitContainer1.Panel2.Controls.Add(this.txtNamespace);
            this.splitContainer1.Panel2.Controls.Add(this.btnCreateDpo);
            this.splitContainer1.Panel2.Controls.Add(this.chkMustGenerate);
            this.splitContainer1.Panel2.Controls.Add(this.chkFolder);
            this.splitContainer1.Size = new System.Drawing.Size(832, 636);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Id#";
            // 
            // txtDatabaseId
            // 
            this.txtDatabaseId.Location = new System.Drawing.Point(36, 105);
            this.txtDatabaseId.Name = "txtDatabaseId";
            this.txtDatabaseId.ReadOnly = true;
            this.txtDatabaseId.Size = new System.Drawing.Size(96, 20);
            this.txtDatabaseId.TabIndex = 22;
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Location = new System.Drawing.Point(15, 86);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new System.Drawing.Size(71, 17);
            this.chkCheckAll.TabIndex = 3;
            this.chkCheckAll.Text = "Check All";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
            // 
            // chkShowNewTables
            // 
            this.chkShowNewTables.AutoSize = true;
            this.chkShowNewTables.Location = new System.Drawing.Point(15, 67);
            this.chkShowNewTables.Name = "chkShowNewTables";
            this.chkShowNewTables.Size = new System.Drawing.Size(193, 17);
            this.chkShowNewTables.TabIndex = 3;
            this.chkShowNewTables.Text = "Show tables without Dpo class only";
            this.chkShowNewTables.UseVisualStyleBackColor = true;
            this.chkShowNewTables.CheckedChanged += new System.EventHandler(this.chkShowNewTables_CheckedChanged);
            // 
            // chkPack
            // 
            this.chkPack.AutoSize = true;
            this.chkPack.Location = new System.Drawing.Point(359, 220);
            this.chkPack.Name = "chkPack";
            this.chkPack.Size = new System.Drawing.Size(51, 17);
            this.chkPack.TabIndex = 24;
            this.chkPack.Text = "Pack";
            this.chkPack.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(362, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Id#";
            // 
            // txtTableId
            // 
            this.txtTableId.Location = new System.Drawing.Point(388, 53);
            this.txtTableId.Name = "txtTableId";
            this.txtTableId.ReadOnly = true;
            this.txtTableId.Size = new System.Drawing.Size(96, 20);
            this.txtTableId.TabIndex = 22;
            // 
            // txtCounter
            // 
            this.txtCounter.Location = new System.Drawing.Point(388, 29);
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.ReadOnly = true;
            this.txtCounter.Size = new System.Drawing.Size(96, 20);
            this.txtCounter.TabIndex = 21;
            this.txtCounter.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(4, 28);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(378, 21);
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Visible = false;
            // 
            // btnUpgradeDpo
            // 
            this.btnUpgradeDpo.Location = new System.Drawing.Point(388, 302);
            this.btnUpgradeDpo.Name = "btnUpgradeDpo";
            this.btnUpgradeDpo.Size = new System.Drawing.Size(135, 34);
            this.btnUpgradeDpo.TabIndex = 19;
            this.btnUpgradeDpo.Text = "Upgrade existing Dpo classes for this database";
            this.btnUpgradeDpo.UseVisualStyleBackColor = true;
            this.btnUpgradeDpo.Click += new System.EventHandler(this.btnUpgradeDpo_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(20, 413);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(519, 211);
            this.txtOutput.TabIndex = 18;
            // 
            // btnGenDpoClass
            // 
            this.btnGenDpoClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenDpoClass.Location = new System.Drawing.Point(388, 262);
            this.btnGenDpoClass.Name = "btnGenDpoClass";
            this.btnGenDpoClass.Size = new System.Drawing.Size(135, 34);
            this.btnGenDpoClass.TabIndex = 17;
            this.btnGenDpoClass.Text = "Create/Upgrade Dpo class for table selected";
            this.btnGenDpoClass.UseVisualStyleBackColor = true;
            this.btnGenDpoClass.Click += new System.EventHandler(this.btnGenDpoClass_Click);
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(91, 158);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(351, 20);
            this.txtClass.TabIndex = 16;
            // 
            // txtAssembly
            // 
            this.txtAssembly.Location = new System.Drawing.Point(89, 79);
            this.txtAssembly.Name = "txtAssembly";
            this.txtAssembly.ReadOnly = true;
            this.txtAssembly.Size = new System.Drawing.Size(395, 20);
            this.txtAssembly.TabIndex = 15;
            // 
            // comboModule
            // 
            this.comboModule.FormattingEnabled = true;
            this.comboModule.Location = new System.Drawing.Point(91, 105);
            this.comboModule.Name = "comboModule";
            this.comboModule.Size = new System.Drawing.Size(351, 21);
            this.comboModule.TabIndex = 14;
            this.comboModule.SelectedIndexChanged += new System.EventHandler(this.comboModule_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Class:";
            // 
            // Assembly
            // 
            this.Assembly.AutoSize = true;
            this.Assembly.Location = new System.Drawing.Point(29, 82);
            this.Assembly.Name = "Assembly";
            this.Assembly.Size = new System.Drawing.Size(54, 13);
            this.Assembly.TabIndex = 12;
            this.Assembly.Text = "Assembly:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Module:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Table Name:";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(91, 53);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.ReadOnly = true;
            this.txtTableName.Size = new System.Drawing.Size(265, 20);
            this.txtTableName.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonGenDict,
            this.toolStripButtonGenSP,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(832, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonGenDict
            // 
            this.toolStripButtonGenDict.Image = global::Sys.Platform.Properties.Resources.book_open;
            this.toolStripButtonGenDict.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGenDict.Name = "toolStripButtonGenDict";
            this.toolStripButtonGenDict.Size = new System.Drawing.Size(131, 22);
            this.toolStripButtonGenDict.Text = "Generate Dictionary";
            this.toolStripButtonGenDict.ToolTipText = "Generate database/table/column dictionary";
            this.toolStripButtonGenDict.Click += new System.EventHandler(this.toolStripButtonGenDict_Click);
            // 
            // toolStripButtonGenSP
            // 
            this.toolStripButtonGenSP.Image = global::Sys.Platform.Properties.Resources.FormRunHS;
            this.toolStripButtonGenSP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGenSP.Name = "toolStripButtonGenSP";
            this.toolStripButtonGenSP.Size = new System.Drawing.Size(90, 22);
            this.toolStripButtonGenSP.Text = "Generate SP";
            this.toolStripButtonGenSP.ToolTipText = "Generate stored procedure class";
            this.toolStripButtonGenSP.Click += new System.EventHandler(this.toolStripButtonGenSP_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // GenDpoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 636);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GenDpoForm";
            this.Text = "Generate Dpo Class";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboDatabase;
        private System.Windows.Forms.CheckBox chkMustGenerate;
        private System.Windows.Forms.Button btnCreateDpo;
        private DevExpress.XtraEditors.RadioGroup rgModifier;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.RadioGroup rgDpoLevel;
        private System.Windows.Forms.TreeView treeTables;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonGenDict;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtAssembly;
        private System.Windows.Forms.ComboBox comboModule;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Assembly;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton toolStripButtonGenSP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button btnGenDpoClass;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkShowNewTables;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.CheckBox chkCheckAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnUpgradeDpo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtCounter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTableId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDatabaseId;
        private System.Windows.Forms.CheckBox chkPack;
    }
}
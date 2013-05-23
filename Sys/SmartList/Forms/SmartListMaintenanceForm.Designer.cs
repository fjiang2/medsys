namespace Sys.SmartList.Forms
{
    partial class SmartListMaintenanceForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSaveOrderBy = new System.Windows.Forms.ToolStripButton();
            this.btnSaveCommand = new System.Windows.Forms.ToolStripButton();
            this.btnHistory = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.btnEditReport = new System.Windows.Forms.Button();
            this.btnBuildReport = new System.Windows.Forms.Button();
            this.icbImage = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.rgViewMode = new DevExpress.XtraEditors.RadioGroup();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbVisible = new System.Windows.Forms.CheckBox();
            this.cbControlled = new System.Windows.Forms.CheckBox();
            this.cbReleased = new System.Windows.Forms.CheckBox();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.tbLabel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbParentID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFooter1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHeader2 = new System.Windows.Forms.TextBox();
            this.tbHeader1 = new System.Windows.Forms.TextBox();
            this.tbHeader3 = new System.Windows.Forms.TextBox();
            this.tbFooter2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFooter3 = new System.Windows.Forms.TextBox();
            this.tabSQL = new System.Windows.Forms.TabPage();
            this.tbScript = new System.Windows.Forms.RichTextBox();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.tbSetting = new System.Windows.Forms.RichTextBox();
            this.tabForm = new System.Windows.Forms.TabPage();
            this.tbParameter = new System.Windows.Forms.RichTextBox();
            this.tabHep = new System.Windows.Forms.TabPage();
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.comboDataProviders = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgViewMode.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabSQL.SuspendLayout();
            this.tabScript.SuspendLayout();
            this.tabForm.SuspendLayout();
            this.tabHep.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveOrderBy,
            this.btnSaveCommand,
            this.btnHistory});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(995, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSaveOrderBy
            // 
            this.btnSaveOrderBy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSaveOrderBy.Image = global::Sys.SmartList.Properties.Resources.saveHS;
            this.btnSaveOrderBy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveOrderBy.Name = "btnSaveOrderBy";
            this.btnSaveOrderBy.Size = new System.Drawing.Size(141, 22);
            this.btnSaveOrderBy.Text = "Sorting Tree and Save";
            this.btnSaveOrderBy.Click += new System.EventHandler(this.btnSaveOrderBy_Click);
            // 
            // btnSaveCommand
            // 
            this.btnSaveCommand.Image = global::Sys.SmartList.Properties.Resources.saveHS;
            this.btnSaveCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveCommand.Name = "btnSaveCommand";
            this.btnSaveCommand.Size = new System.Drawing.Size(111, 22);
            this.btnSaveCommand.Text = "Save Command";
            this.btnSaveCommand.Click += new System.EventHandler(this.btnSaveCommand_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Image = global::Sys.SmartList.Properties.Resources.time;
            this.btnHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(65, 22);
            this.btnHistory.Text = "History";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(995, 680);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBasic);
            this.tabControl1.Controls.Add(this.tabSQL);
            this.tabControl1.Controls.Add(this.tabScript);
            this.tabControl1.Controls.Add(this.tabForm);
            this.tabControl1.Controls.Add(this.tabHep);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(774, 680);
            this.tabControl1.TabIndex = 40;
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.comboDataProviders);
            this.tabBasic.Controls.Add(this.btnEditReport);
            this.tabBasic.Controls.Add(this.btnBuildReport);
            this.tabBasic.Controls.Add(this.icbImage);
            this.tabBasic.Controls.Add(this.rgViewMode);
            this.tabBasic.Controls.Add(this.label7);
            this.tabBasic.Controls.Add(this.label5);
            this.tabBasic.Controls.Add(this.groupBox2);
            this.tabBasic.Controls.Add(this.tbLabel);
            this.tabBasic.Controls.Add(this.label1);
            this.tabBasic.Controls.Add(this.label6);
            this.tabBasic.Controls.Add(this.label9);
            this.tabBasic.Controls.Add(this.label2);
            this.tabBasic.Controls.Add(this.tbDescription);
            this.tabBasic.Controls.Add(this.tbID);
            this.tabBasic.Controls.Add(this.label10);
            this.tabBasic.Controls.Add(this.tbParentID);
            this.tabBasic.Controls.Add(this.groupBox1);
            this.tabBasic.Location = new System.Drawing.Point(4, 22);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(766, 654);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // btnEditReport
            // 
            this.btnEditReport.Location = new System.Drawing.Point(35, 612);
            this.btnEditReport.Name = "btnEditReport";
            this.btnEditReport.Size = new System.Drawing.Size(119, 23);
            this.btnEditReport.TabIndex = 41;
            this.btnEditReport.Text = "Edit Report...";
            this.btnEditReport.UseVisualStyleBackColor = true;
            this.btnEditReport.Click += new System.EventHandler(this.btnEditReport_Click);
            // 
            // btnBuildReport
            // 
            this.btnBuildReport.Location = new System.Drawing.Point(35, 582);
            this.btnBuildReport.Name = "btnBuildReport";
            this.btnBuildReport.Size = new System.Drawing.Size(119, 23);
            this.btnBuildReport.TabIndex = 40;
            this.btnBuildReport.Text = "Report Builder ...";
            this.btnBuildReport.UseVisualStyleBackColor = true;
            this.btnBuildReport.Visible = false;
            this.btnBuildReport.Click += new System.EventHandler(this.btnBuildReport_Click);
            // 
            // icbImage
            // 
            this.icbImage.Location = new System.Drawing.Point(19, 554);
            this.icbImage.Name = "icbImage";
            this.icbImage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbImage.Size = new System.Drawing.Size(164, 20);
            this.icbImage.TabIndex = 39;
            // 
            // rgViewMode
            // 
            this.rgViewMode.Location = new System.Drawing.Point(195, 463);
            this.rgViewMode.Name = "rgViewMode";
            this.rgViewMode.Properties.Columns = 3;
            this.rgViewMode.Size = new System.Drawing.Size(411, 142);
            this.rgViewMode.TabIndex = 38;
            this.rgViewMode.SelectedIndexChanged += new System.EventHandler(this.rgViewMode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 537);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Image";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 445);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "View Mode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbVisible);
            this.groupBox2.Controls.Add(this.cbControlled);
            this.groupBox2.Controls.Add(this.cbReleased);
            this.groupBox2.Controls.Add(this.cbEnabled);
            this.groupBox2.Location = new System.Drawing.Point(10, 445);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 86);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Security";
            // 
            // cbVisible
            // 
            this.cbVisible.AutoSize = true;
            this.cbVisible.Location = new System.Drawing.Point(88, 29);
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Size = new System.Drawing.Size(56, 17);
            this.cbVisible.TabIndex = 34;
            this.cbVisible.Text = "Visible";
            this.cbVisible.UseVisualStyleBackColor = true;
            // 
            // cbControlled
            // 
            this.cbControlled.AutoSize = true;
            this.cbControlled.Location = new System.Drawing.Point(9, 52);
            this.cbControlled.Name = "cbControlled";
            this.cbControlled.Size = new System.Drawing.Size(73, 17);
            this.cbControlled.TabIndex = 34;
            this.cbControlled.Text = "Controlled";
            this.cbControlled.UseVisualStyleBackColor = true;
            // 
            // cbReleased
            // 
            this.cbReleased.AutoSize = true;
            this.cbReleased.Location = new System.Drawing.Point(88, 52);
            this.cbReleased.Name = "cbReleased";
            this.cbReleased.Size = new System.Drawing.Size(71, 17);
            this.cbReleased.TabIndex = 35;
            this.cbReleased.Text = "Released";
            this.cbReleased.UseVisualStyleBackColor = true;
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(9, 29);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbEnabled.TabIndex = 34;
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.UseVisualStyleBackColor = true;
            // 
            // tbLabel
            // 
            this.tbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLabel.Location = new System.Drawing.Point(10, 91);
            this.tbLabel.Name = "tbLabel";
            this.tbLabel.Size = new System.Drawing.Size(722, 20);
            this.tbLabel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(10, 130);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(722, 64);
            this.tbDescription.TabIndex = 4;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(78, 20);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(105, 20);
            this.tbID.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Parent ID";
            // 
            // tbParentID
            // 
            this.tbParentID.Location = new System.Drawing.Point(78, 46);
            this.tbParentID.Name = "tbParentID";
            this.tbParentID.Size = new System.Drawing.Size(105, 20);
            this.tbParentID.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbFooter1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbHeader2);
            this.groupBox1.Controls.Add(this.tbHeader1);
            this.groupBox1.Controls.Add(this.tbHeader3);
            this.groupBox1.Controls.Add(this.tbFooter2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbFooter3);
            this.groupBox1.Location = new System.Drawing.Point(10, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 239);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print";
            // 
            // tbFooter1
            // 
            this.tbFooter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFooter1.Location = new System.Drawing.Point(10, 152);
            this.tbFooter1.Name = "tbFooter1";
            this.tbFooter1.Size = new System.Drawing.Size(577, 20);
            this.tbFooter1.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Footer";
            // 
            // tbHeader2
            // 
            this.tbHeader2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHeader2.Location = new System.Drawing.Point(10, 67);
            this.tbHeader2.Name = "tbHeader2";
            this.tbHeader2.Size = new System.Drawing.Size(577, 20);
            this.tbHeader2.TabIndex = 12;
            // 
            // tbHeader1
            // 
            this.tbHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHeader1.Location = new System.Drawing.Point(10, 41);
            this.tbHeader1.Name = "tbHeader1";
            this.tbHeader1.Size = new System.Drawing.Size(577, 20);
            this.tbHeader1.TabIndex = 11;
            // 
            // tbHeader3
            // 
            this.tbHeader3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHeader3.Location = new System.Drawing.Point(10, 93);
            this.tbHeader3.Name = "tbHeader3";
            this.tbHeader3.Size = new System.Drawing.Size(577, 20);
            this.tbHeader3.TabIndex = 13;
            // 
            // tbFooter2
            // 
            this.tbFooter2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFooter2.Location = new System.Drawing.Point(10, 178);
            this.tbFooter2.Name = "tbFooter2";
            this.tbFooter2.Size = new System.Drawing.Size(577, 20);
            this.tbFooter2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Header";
            // 
            // tbFooter3
            // 
            this.tbFooter3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFooter3.Location = new System.Drawing.Point(10, 204);
            this.tbFooter3.Name = "tbFooter3";
            this.tbFooter3.Size = new System.Drawing.Size(577, 20);
            this.tbFooter3.TabIndex = 16;
            // 
            // tabSQL
            // 
            this.tabSQL.Controls.Add(this.tbScript);
            this.tabSQL.Location = new System.Drawing.Point(4, 22);
            this.tabSQL.Name = "tabSQL";
            this.tabSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabSQL.Size = new System.Drawing.Size(766, 654);
            this.tabSQL.TabIndex = 1;
            this.tabSQL.Text = "SQL";
            this.tabSQL.UseVisualStyleBackColor = true;
            // 
            // tbScript
            // 
            this.tbScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbScript.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScript.Location = new System.Drawing.Point(3, 3);
            this.tbScript.Name = "tbScript";
            this.tbScript.Size = new System.Drawing.Size(760, 648);
            this.tbScript.TabIndex = 21;
            this.tbScript.Text = "";
            this.tbScript.WordWrap = false;
            // 
            // tabScript
            // 
            this.tabScript.Controls.Add(this.tbSetting);
            this.tabScript.Location = new System.Drawing.Point(4, 22);
            this.tabScript.Name = "tabScript";
            this.tabScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabScript.Size = new System.Drawing.Size(766, 654);
            this.tabScript.TabIndex = 2;
            this.tabScript.Text = "Script";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // tbSetting
            // 
            this.tbSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSetting.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSetting.Location = new System.Drawing.Point(3, 3);
            this.tbSetting.Name = "tbSetting";
            this.tbSetting.Size = new System.Drawing.Size(760, 648);
            this.tbSetting.TabIndex = 21;
            this.tbSetting.Text = "";
            this.tbSetting.WordWrap = false;
            // 
            // tabForm
            // 
            this.tabForm.Controls.Add(this.tbParameter);
            this.tabForm.Location = new System.Drawing.Point(4, 22);
            this.tabForm.Name = "tabForm";
            this.tabForm.Padding = new System.Windows.Forms.Padding(3);
            this.tabForm.Size = new System.Drawing.Size(766, 654);
            this.tabForm.TabIndex = 3;
            this.tabForm.Text = "Form";
            this.tabForm.UseVisualStyleBackColor = true;
            // 
            // tbParameter
            // 
            this.tbParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbParameter.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbParameter.Location = new System.Drawing.Point(3, 3);
            this.tbParameter.Name = "tbParameter";
            this.tbParameter.Size = new System.Drawing.Size(760, 648);
            this.tbParameter.TabIndex = 21;
            this.tbParameter.Text = "";
            this.tbParameter.WordWrap = false;
            // 
            // tabHep
            // 
            this.tabHep.Controls.Add(this.richEditControl1);
            this.tabHep.Location = new System.Drawing.Point(4, 22);
            this.tabHep.Name = "tabHep";
            this.tabHep.Padding = new System.Windows.Forms.Padding(3);
            this.tabHep.Size = new System.Drawing.Size(766, 654);
            this.tabHep.TabIndex = 4;
            this.tabHep.Text = "Help";
            this.tabHep.UseVisualStyleBackColor = true;
            // 
            // richEditControl1
            // 
            this.richEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControl1.Location = new System.Drawing.Point(3, 3);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(760, 648);
            this.richEditControl1.TabIndex = 0;
            this.richEditControl1.Text = "richEditControl1";
            // 
            // comboDataProviders
            // 
            this.comboDataProviders.FormattingEnabled = true;
            this.comboDataProviders.Location = new System.Drawing.Point(590, 16);
            this.comboDataProviders.Name = "comboDataProviders";
            this.comboDataProviders.Size = new System.Drawing.Size(142, 21);
            this.comboDataProviders.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(512, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Data Provider";
            // 
            // SmartListMaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 705);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SmartListMaintenanceForm";
            this.Text = "SmartList Maintenance";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icbImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgViewMode.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabSQL.ResumeLayout(false);
            this.tabScript.ResumeLayout(false);
            this.tabForm.ResumeLayout(false);
            this.tabHep.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnSaveOrderBy;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBasic;
        private DevExpress.XtraEditors.RadioGroup rgViewMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbVisible;
        private System.Windows.Forms.CheckBox cbControlled;
        private System.Windows.Forms.CheckBox cbReleased;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.TextBox tbLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbParentID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbFooter1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHeader2;
        private System.Windows.Forms.TextBox tbHeader1;
        private System.Windows.Forms.TextBox tbHeader3;
        private System.Windows.Forms.TextBox tbFooter2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFooter3;
        private System.Windows.Forms.TabPage tabSQL;
        private System.Windows.Forms.RichTextBox tbScript;
        private System.Windows.Forms.TabPage tabScript;
        private System.Windows.Forms.RichTextBox tbSetting;
        private System.Windows.Forms.TabPage tabForm;
        private System.Windows.Forms.RichTextBox tbParameter;
        private System.Windows.Forms.TabPage tabHep;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private System.Windows.Forms.ToolStripButton btnSaveCommand;
        private System.Windows.Forms.ToolStripButton btnHistory;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbImage;
        private System.Windows.Forms.Button btnBuildReport;
        private System.Windows.Forms.Button btnEditReport;
        private System.Windows.Forms.ComboBox comboDataProviders;
        private System.Windows.Forms.Label label6;
    }
}
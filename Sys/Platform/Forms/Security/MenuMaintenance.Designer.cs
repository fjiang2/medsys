namespace Sys.Platform.Forms
{
    partial class MenuMaintenance
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.chkControlled = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.chkReleased = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCreateMenuItem = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeMenu = new Sys.ViewManager.Forms.TreeDpoView();
            this.treeForm = new System.Windows.Forms.TreeView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.comboModule = new System.Windows.Forms.ComboBox();
            this.txtParentID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOrderBy = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rgFormPlace = new DevExpress.XtraEditors.RadioGroup();
            this.label10 = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.rgMenuType = new DevExpress.XtraEditors.RadioGroup();
            this.txtFormClass = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgFormPlace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgMenuType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Label";
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(12, 171);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(397, 20);
            this.txtLabel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Module";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 210);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(397, 88);
            this.txtDescription.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Form Command (select form first)";
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(15, 342);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(394, 87);
            this.txtCommand.TabIndex = 5;
            // 
            // chkControlled
            // 
            this.chkControlled.AutoSize = true;
            this.chkControlled.Location = new System.Drawing.Point(15, 532);
            this.chkControlled.Name = "chkControlled";
            this.chkControlled.Size = new System.Drawing.Size(73, 17);
            this.chkControlled.TabIndex = 21;
            this.chkControlled.Text = "Controlled";
            this.chkControlled.UseVisualStyleBackColor = true;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(179, 532);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 22;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(247, 532);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(56, 17);
            this.chkVisible.TabIndex = 23;
            this.chkVisible.Text = "Visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // chkReleased
            // 
            this.chkReleased.AutoSize = true;
            this.chkReleased.Location = new System.Drawing.Point(102, 532);
            this.chkReleased.Name = "chkReleased";
            this.chkReleased.Size = new System.Drawing.Size(71, 17);
            this.chkReleased.TabIndex = 24;
            this.chkReleased.Text = "Released";
            this.chkReleased.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonCreateMenuItem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(866, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = global::Sys.Platform.Properties.Resources.saveHS;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonCreateMenuItem
            // 
            this.toolStripButtonCreateMenuItem.Image = global::Sys.Platform.Properties.Resources.add;
            this.toolStripButtonCreateMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCreateMenuItem.Name = "toolStripButtonCreateMenuItem";
            this.toolStripButtonCreateMenuItem.Size = new System.Drawing.Size(122, 22);
            this.toolStripButtonCreateMenuItem.Text = "Create Menu Item";
            this.toolStripButtonCreateMenuItem.Click += new System.EventHandler(this.toolStripButtonCreateMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(428, 18);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeMenu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeForm);
            this.splitContainer1.Size = new System.Drawing.Size(426, 619);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 4;
            // 
            // treeMenu
            // 
            this.treeMenu.DataSource = null;
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMenu.Location = new System.Drawing.Point(0, 0);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.Size = new System.Drawing.Size(426, 295);
            this.treeMenu.TabIndex = 0;
            // 
            // treeForm
            // 
            this.treeForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeForm.Location = new System.Drawing.Point(0, 0);
            this.treeForm.Name = "treeForm";
            this.treeForm.Size = new System.Drawing.Size(426, 320);
            this.treeForm.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(66, 32);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(82, 20);
            this.txtID.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::Sys.Platform.Properties.Resources.ZoomHS;
            this.btnSearch.Location = new System.Drawing.Point(154, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(28, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // comboModule
            // 
            this.comboModule.FormattingEnabled = true;
            this.comboModule.Location = new System.Drawing.Point(61, 129);
            this.comboModule.Name = "comboModule";
            this.comboModule.Size = new System.Drawing.Size(242, 21);
            this.comboModule.TabIndex = 6;
            // 
            // txtParentID
            // 
            this.txtParentID.Location = new System.Drawing.Point(66, 58);
            this.txtParentID.Name = "txtParentID";
            this.txtParentID.Size = new System.Drawing.Size(82, 20);
            this.txtParentID.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Parent ID";
            // 
            // txtOrderBy
            // 
            this.txtOrderBy.Location = new System.Drawing.Point(66, 84);
            this.txtOrderBy.Name = "txtOrderBy";
            this.txtOrderBy.Size = new System.Drawing.Size(82, 20);
            this.txtOrderBy.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Order By";
            // 
            // rgFormPlace
            // 
            this.rgFormPlace.Location = new System.Drawing.Point(15, 456);
            this.rgFormPlace.Name = "rgFormPlace";
            this.rgFormPlace.Size = new System.Drawing.Size(394, 59);
            this.rgFormPlace.TabIndex = 25;
            this.rgFormPlace.SelectedIndexChanged += new System.EventHandler(this.rgFormPlace_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 440);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Form Place (then select place)";
            // 
            // picIcon
            // 
            this.picIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picIcon.Location = new System.Drawing.Point(327, 28);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(82, 66);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 26;
            this.picIcon.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(327, 100);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(82, 23);
            this.btnLoadImage.TabIndex = 27;
            this.btnLoadImage.Text = "Browse ...";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnClearImage
            // 
            this.btnClearImage.Location = new System.Drawing.Point(327, 129);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(82, 23);
            this.btnClearImage.TabIndex = 28;
            this.btnClearImage.Text = "Clear Image";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // rgMenuType
            // 
            this.rgMenuType.Location = new System.Drawing.Point(207, 28);
            this.rgMenuType.Name = "rgMenuType";
            this.rgMenuType.Size = new System.Drawing.Size(96, 59);
            this.rgMenuType.TabIndex = 25;
            this.rgMenuType.SelectedIndexChanged += new System.EventHandler(this.rgMenuType_SelectedIndexChanged);
            // 
            // txtFormClass
            // 
            this.txtFormClass.Location = new System.Drawing.Point(179, 316);
            this.txtFormClass.Name = "txtFormClass";
            this.txtFormClass.ReadOnly = true;
            this.txtFormClass.Size = new System.Drawing.Size(230, 20);
            this.txtFormClass.TabIndex = 29;
            // 
            // MenuMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 649);
            this.Controls.Add(this.txtFormClass);
            this.Controls.Add(this.btnClearImage);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.rgMenuType);
            this.Controls.Add(this.rgFormPlace);
            this.Controls.Add(this.comboModule);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.chkReleased);
            this.Controls.Add(this.chkVisible);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.chkControlled);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOrderBy);
            this.Controls.Add(this.txtParentID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "MenuMaintenance";
            this.Text = "Menu Maintenance";
            this.Load += new System.EventHandler(this.MenuMaintenance_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgFormPlace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgMenuType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.CheckBox chkControlled;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.CheckBox chkReleased;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Sys.ViewManager.Forms.TreeDpoView treeMenu;
        private System.Windows.Forms.TreeView treeForm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox comboModule;
        private System.Windows.Forms.TextBox txtParentID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOrderBy;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.RadioGroup rgFormPlace;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnClearImage;
        private DevExpress.XtraEditors.RadioGroup rgMenuType;
        private System.Windows.Forms.TextBox txtFormClass;
        private System.Windows.Forms.ToolStripButton toolStripButtonCreateMenuItem;
    }
}
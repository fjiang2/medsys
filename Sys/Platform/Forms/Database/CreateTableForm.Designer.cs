namespace Sys.Platform.Forms
{
    partial class CreateTableForm
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
            this.comboModule = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.txtOuput = new System.Windows.Forms.TextBox();
            this.lblAssembly = new System.Windows.Forms.Label();
            this.txtAssembly = new System.Windows.Forms.TextBox();
            this.txtDpoClass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateAllTable = new System.Windows.Forms.Button();
            this.btnPackModule = new System.Windows.Forms.Button();
            this.btnPackAll = new System.Windows.Forms.Button();
            this.btnUnpackModule = new System.Windows.Forms.Button();
            this.btnBrowseModule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboModule
            // 
            this.comboModule.FormattingEnabled = true;
            this.comboModule.Location = new System.Drawing.Point(60, 12);
            this.comboModule.Name = "comboModule";
            this.comboModule.Size = new System.Drawing.Size(217, 21);
            this.comboModule.TabIndex = 8;
            this.comboModule.SelectedIndexChanged += new System.EventHandler(this.comboModule_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Module:";
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateTable.Location = new System.Drawing.Point(25, 546);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(118, 40);
            this.btnCreateTable.TabIndex = 9;
            this.btnCreateTable.Text = "Create Tables of selected module";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // txtOuput
            // 
            this.txtOuput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOuput.Location = new System.Drawing.Point(12, 235);
            this.txtOuput.Multiline = true;
            this.txtOuput.Name = "txtOuput";
            this.txtOuput.ReadOnly = true;
            this.txtOuput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOuput.Size = new System.Drawing.Size(630, 305);
            this.txtOuput.TabIndex = 10;
            // 
            // Assembly
            // 
            this.lblAssembly.AutoSize = true;
            this.lblAssembly.Location = new System.Drawing.Point(11, 47);
            this.lblAssembly.Name = "Assembly";
            this.lblAssembly.Size = new System.Drawing.Size(54, 13);
            this.lblAssembly.TabIndex = 7;
            this.lblAssembly.Text = "Assembly:";
            // 
            // txtAssembly
            // 
            this.txtAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssembly.Location = new System.Drawing.Point(60, 39);
            this.txtAssembly.Name = "txtAssembly";
            this.txtAssembly.ReadOnly = true;
            this.txtAssembly.Size = new System.Drawing.Size(582, 20);
            this.txtAssembly.TabIndex = 11;
            // 
            // txtDpoClass
            // 
            this.txtDpoClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDpoClass.Location = new System.Drawing.Point(60, 85);
            this.txtDpoClass.Multiline = true;
            this.txtDpoClass.Name = "txtDpoClass";
            this.txtDpoClass.ReadOnly = true;
            this.txtDpoClass.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDpoClass.Size = new System.Drawing.Size(582, 135);
            this.txtDpoClass.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "DPO:";
            // 
            // btnCreateAllTable
            // 
            this.btnCreateAllTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateAllTable.Location = new System.Drawing.Point(25, 592);
            this.btnCreateAllTable.Name = "btnCreateAllTable";
            this.btnCreateAllTable.Size = new System.Drawing.Size(116, 36);
            this.btnCreateAllTable.TabIndex = 12;
            this.btnCreateAllTable.Text = "Create Tables of all modules";
            this.btnCreateAllTable.UseVisualStyleBackColor = true;
            this.btnCreateAllTable.Click += new System.EventHandler(this.btnCreateAllTable_Click);
            // 
            // btnPackModule
            // 
            this.btnPackModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPackModule.Location = new System.Drawing.Point(428, 546);
            this.btnPackModule.Name = "btnPackModule";
            this.btnPackModule.Size = new System.Drawing.Size(94, 40);
            this.btnPackModule.TabIndex = 13;
            this.btnPackModule.Text = "Pack selected module";
            this.btnPackModule.UseVisualStyleBackColor = true;
            this.btnPackModule.Click += new System.EventHandler(this.btnPackModule_Click);
            // 
            // btnPackAll
            // 
            this.btnPackAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPackAll.Location = new System.Drawing.Point(428, 588);
            this.btnPackAll.Name = "btnPackAll";
            this.btnPackAll.Size = new System.Drawing.Size(94, 36);
            this.btnPackAll.TabIndex = 13;
            this.btnPackAll.Text = "Pack all modules";
            this.btnPackAll.UseVisualStyleBackColor = true;
            this.btnPackAll.Click += new System.EventHandler(this.btnPackAll_Click);
            // 
            // btnUnpackModule
            // 
            this.btnUnpackModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnpackModule.Location = new System.Drawing.Point(529, 546);
            this.btnUnpackModule.Name = "btnUnpackModule";
            this.btnUnpackModule.Size = new System.Drawing.Size(95, 40);
            this.btnUnpackModule.TabIndex = 14;
            this.btnUnpackModule.Text = "Unpack Selected Module";
            this.btnUnpackModule.UseVisualStyleBackColor = true;
            this.btnUnpackModule.Click += new System.EventHandler(this.btnUnpackModule_Click);
            // 
            // btnBrowseModule
            // 
            this.btnBrowseModule.Location = new System.Drawing.Point(297, 10);
            this.btnBrowseModule.Name = "btnBrowseModule";
            this.btnBrowseModule.Size = new System.Drawing.Size(142, 23);
            this.btnBrowseModule.TabIndex = 15;
            this.btnBrowseModule.Text = "Browse External Module...";
            this.btnBrowseModule.UseVisualStyleBackColor = true;
            this.btnBrowseModule.Click += new System.EventHandler(this.btnBrowseModule_Click);
            // 
            // CreateTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 636);
            this.Controls.Add(this.btnBrowseModule);
            this.Controls.Add(this.btnUnpackModule);
            this.Controls.Add(this.btnPackAll);
            this.Controls.Add(this.btnPackModule);
            this.Controls.Add(this.btnCreateAllTable);
            this.Controls.Add(this.txtAssembly);
            this.Controls.Add(this.txtDpoClass);
            this.Controls.Add(this.txtOuput);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.comboModule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAssembly);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CreateTableForm";
            this.ShowIcon = false;
            this.Text = "Create Table from DPO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboModule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.TextBox txtOuput;
        private System.Windows.Forms.Label lblAssembly;
        private System.Windows.Forms.TextBox txtAssembly;
        private System.Windows.Forms.TextBox txtDpoClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateAllTable;
        private System.Windows.Forms.Button btnPackModule;
        private System.Windows.Forms.Button btnPackAll;
        private System.Windows.Forms.Button btnUnpackModule;
        private System.Windows.Forms.Button btnBrowseModule;
    }
}
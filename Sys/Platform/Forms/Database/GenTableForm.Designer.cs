namespace Sys.Platform.Forms
{
    partial class GenTableForm
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
            this.lblAssembly = new System.Windows.Forms.Label();
            this.txtAssembly = new System.Windows.Forms.TextBox();
            this.btnCreateAllTable = new System.Windows.Forms.Button();
            this.btnPackModule = new System.Windows.Forms.Button();
            this.btnPackAll = new System.Windows.Forms.Button();
            this.btnBrowseModule = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.jGridView1 = new Sys.ViewManager.Forms.JGridView();
            this.SuspendLayout();
            // 
            // comboModule
            // 
            this.comboModule.FormattingEnabled = true;
            this.comboModule.Location = new System.Drawing.Point(60, 12);
            this.comboModule.Name = "comboModule";
            this.comboModule.Size = new System.Drawing.Size(374, 21);
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
            this.btnCreateTable.Location = new System.Drawing.Point(2, 530);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(92, 55);
            this.btnCreateTable.TabIndex = 9;
            this.btnCreateTable.Text = "Create Tables of selected module";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // lblAssembly
            // 
            this.lblAssembly.AutoSize = true;
            this.lblAssembly.Location = new System.Drawing.Point(11, 47);
            this.lblAssembly.Name = "lblAssembly";
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
            this.txtAssembly.Size = new System.Drawing.Size(766, 20);
            this.txtAssembly.TabIndex = 11;
            this.txtAssembly.TextChanged += new System.EventHandler(this.txtAssembly_TextChanged);
            // 
            // btnCreateAllTable
            // 
            this.btnCreateAllTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateAllTable.Location = new System.Drawing.Point(100, 530);
            this.btnCreateAllTable.Name = "btnCreateAllTable";
            this.btnCreateAllTable.Size = new System.Drawing.Size(89, 55);
            this.btnCreateAllTable.TabIndex = 12;
            this.btnCreateAllTable.Text = "Create Tables of all modules";
            this.btnCreateAllTable.UseVisualStyleBackColor = true;
            this.btnCreateAllTable.Click += new System.EventHandler(this.btnCreateAllTable_Click);
            // 
            // btnPackModule
            // 
            this.btnPackModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPackModule.Location = new System.Drawing.Point(642, 530);
            this.btnPackModule.Name = "btnPackModule";
            this.btnPackModule.Size = new System.Drawing.Size(92, 55);
            this.btnPackModule.TabIndex = 13;
            this.btnPackModule.Text = "Pack selected module";
            this.btnPackModule.UseVisualStyleBackColor = true;
            this.btnPackModule.Click += new System.EventHandler(this.btnPackModule_Click);
            // 
            // btnPackAll
            // 
            this.btnPackAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPackAll.Location = new System.Drawing.Point(740, 530);
            this.btnPackAll.Name = "btnPackAll";
            this.btnPackAll.Size = new System.Drawing.Size(88, 55);
            this.btnPackAll.TabIndex = 13;
            this.btnPackAll.Text = "Pack all modules";
            this.btnPackAll.UseVisualStyleBackColor = true;
            this.btnPackAll.Click += new System.EventHandler(this.btnPackAll_Click);
            // 
            // btnBrowseModule
            // 
            this.btnBrowseModule.Location = new System.Drawing.Point(440, 12);
            this.btnBrowseModule.Name = "btnBrowseModule";
            this.btnBrowseModule.Size = new System.Drawing.Size(142, 23);
            this.btnBrowseModule.TabIndex = 15;
            this.btnBrowseModule.Text = "Browse External Module...";
            this.btnBrowseModule.UseVisualStyleBackColor = true;
            this.btnBrowseModule.Click += new System.EventHandler(this.btnBrowseModule_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dpo Class:";
            // 
            // jGridView1
            // 
            this.jGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jGridView1.DataSource = null;
            this.jGridView1.Location = new System.Drawing.Point(2, 85);
            this.jGridView1.Name = "jGridView1";
            this.jGridView1.ReadOnly = false;
            this.jGridView1.Size = new System.Drawing.Size(836, 428);
            this.jGridView1.TabIndex = 16;
            // 
            // GenTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 586);
            this.Controls.Add(this.jGridView1);
            this.Controls.Add(this.btnBrowseModule);
            this.Controls.Add(this.btnPackAll);
            this.Controls.Add(this.btnPackModule);
            this.Controls.Add(this.btnCreateAllTable);
            this.Controls.Add(this.txtAssembly);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.comboModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAssembly);
            this.Controls.Add(this.label4);
            this.Name = "GenTableForm";
            this.ShowIcon = false;
            this.Text = "Generate Table from DPO";
            this.Load += new System.EventHandler(this.CreateTableForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboModule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.Label lblAssembly;
        private System.Windows.Forms.TextBox txtAssembly;
        private System.Windows.Forms.Button btnCreateAllTable;
        private System.Windows.Forms.Button btnPackModule;
        private System.Windows.Forms.Button btnPackAll;
        private System.Windows.Forms.Button btnBrowseModule;
        private System.Windows.Forms.Label label2;
        private ViewManager.Forms.JGridView jGridView1;
    }
}
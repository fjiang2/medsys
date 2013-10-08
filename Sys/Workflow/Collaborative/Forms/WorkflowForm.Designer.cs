namespace Sys.Workflow.Collaborative.Forms
{
    partial class WorkflowForm
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
            this.tbLabel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbKeyName = new System.Windows.Forms.TextBox();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.cbVisible = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbScript = new System.Windows.Forms.RichTextBox();
            this.cbReleased = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jGridView1 = new Sys.ViewManager.Forms.JGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jGridView2 = new Sys.ViewManager.Forms.JGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTransistion = new System.Windows.Forms.Button();
            this.btnWorkflow = new System.Windows.Forms.Button();
            this.btnNewWorkflow = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // tbLabel
            // 
            this.tbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLabel.Location = new System.Drawing.Point(78, 39);
            this.tbLabel.Name = "tbLabel";
            this.tbLabel.Size = new System.Drawing.Size(847, 20);
            this.tbLabel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(78, 64);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(847, 20);
            this.tbDescription.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(769, 646);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(850, 646);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Company";
            // 
            // tbCompany
            // 
            this.tbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCompany.Location = new System.Drawing.Point(450, 15);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(475, 20);
            this.tbCompany.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Name";
            // 
            // tbKeyName
            // 
            this.tbKeyName.Location = new System.Drawing.Point(78, 15);
            this.tbKeyName.Name = "tbKeyName";
            this.tbKeyName.Size = new System.Drawing.Size(292, 20);
            this.tbKeyName.TabIndex = 1;
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(171, 19);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbEnabled.TabIndex = 34;
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.UseVisualStyleBackColor = true;
            // 
            // cbVisible
            // 
            this.cbVisible.AutoSize = true;
            this.cbVisible.Location = new System.Drawing.Point(96, 19);
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Size = new System.Drawing.Size(56, 17);
            this.cbVisible.TabIndex = 34;
            this.cbVisible.Text = "Visible";
            this.cbVisible.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(688, 647);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 30;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tbScript
            // 
            this.tbScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbScript.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbScript.Location = new System.Drawing.Point(3, 3);
            this.tbScript.Name = "tbScript";
            this.tbScript.Size = new System.Drawing.Size(932, 609);
            this.tbScript.TabIndex = 21;
            this.tbScript.Text = "";
            this.tbScript.WordWrap = false;
            // 
            // cbReleased
            // 
            this.cbReleased.AutoSize = true;
            this.cbReleased.Location = new System.Drawing.Point(9, 19);
            this.cbReleased.Name = "cbReleased";
            this.cbReleased.Size = new System.Drawing.Size(71, 17);
            this.cbReleased.TabIndex = 35;
            this.cbReleased.Text = "Released";
            this.cbReleased.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabBasic);
            this.tabControl1.Controls.Add(this.tabScript);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(946, 641);
            this.tabControl1.TabIndex = 36;
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.tabControl2);
            this.tabBasic.Controls.Add(this.groupBox2);
            this.tabBasic.Controls.Add(this.tbLabel);
            this.tabBasic.Controls.Add(this.label1);
            this.tabBasic.Controls.Add(this.label2);
            this.tabBasic.Controls.Add(this.tbDescription);
            this.tabBasic.Controls.Add(this.label8);
            this.tabBasic.Controls.Add(this.label6);
            this.tabBasic.Controls.Add(this.tbCompany);
            this.tabBasic.Controls.Add(this.tbKeyName);
            this.tabBasic.Location = new System.Drawing.Point(4, 22);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(938, 615);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(15, 106);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(920, 477);
            this.tabControl2.TabIndex = 38;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.jGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(912, 451);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "States";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // jGridView1
            // 
            this.jGridView1.DataSource = null;
            this.jGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jGridView1.Location = new System.Drawing.Point(3, 3);
            this.jGridView1.Name = "jGridView1";
            this.jGridView1.Size = new System.Drawing.Size(906, 445);
            this.jGridView1.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(912, 451);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transitions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // jGridView2
            // 
            this.jGridView2.DataSource = null;
            this.jGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jGridView2.Location = new System.Drawing.Point(3, 3);
            this.jGridView2.Name = "jGridView2";
            this.jGridView2.Size = new System.Drawing.Size(906, 445);
            this.jGridView2.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.cbVisible);
            this.groupBox2.Controls.Add(this.cbReleased);
            this.groupBox2.Controls.Add(this.cbEnabled);
            this.groupBox2.Location = new System.Drawing.Point(10, 570);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 39);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Security";
            // 
            // tabScript
            // 
            this.tabScript.Controls.Add(this.tbScript);
            this.tabScript.Location = new System.Drawing.Point(4, 22);
            this.tabScript.Name = "tabScript";
            this.tabScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabScript.Size = new System.Drawing.Size(938, 615);
            this.tabScript.TabIndex = 2;
            this.tabScript.Text = "Script";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(6, 647);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Check Script";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTransistion
            // 
            this.btnTransistion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTransistion.Location = new System.Drawing.Point(143, 647);
            this.btnTransistion.Name = "btnTransistion";
            this.btnTransistion.Size = new System.Drawing.Size(144, 23);
            this.btnTransistion.TabIndex = 37;
            this.btnTransistion.Text = "Auto Transitions";
            this.btnTransistion.UseVisualStyleBackColor = true;
            this.btnTransistion.Click += new System.EventHandler(this.btnTransistion_Click);
            // 
            // btnWorkflow
            // 
            this.btnWorkflow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWorkflow.Location = new System.Drawing.Point(296, 647);
            this.btnWorkflow.Name = "btnWorkflow";
            this.btnWorkflow.Size = new System.Drawing.Size(148, 23);
            this.btnWorkflow.TabIndex = 38;
            this.btnWorkflow.Text = "Workflow Chart";
            this.btnWorkflow.UseVisualStyleBackColor = true;
            this.btnWorkflow.Click += new System.EventHandler(this.btnWorkflow_Click);
            // 
            // btnNewWorkflow
            // 
            this.btnNewWorkflow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewWorkflow.Location = new System.Drawing.Point(591, 647);
            this.btnNewWorkflow.Name = "btnNewWorkflow";
            this.btnNewWorkflow.Size = new System.Drawing.Size(91, 23);
            this.btnNewWorkflow.TabIndex = 39;
            this.btnNewWorkflow.Text = "New Workflow";
            this.btnNewWorkflow.UseVisualStyleBackColor = true;
            this.btnNewWorkflow.Click += new System.EventHandler(this.btnNewWorkflow_Click);
            // 
            // WorkflowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 681);
            this.Controls.Add(this.btnNewWorkflow);
            this.Controls.Add(this.btnWorkflow);
            this.Controls.Add(this.btnTransistion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Name = "WorkflowForm";
            this.Text = "Workflow Configuration";
            this.tabControl1.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabScript.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbKeyName;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.CheckBox cbVisible;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.RichTextBox tbScript;
        private System.Windows.Forms.CheckBox cbReleased;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.TabPage tabScript;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private Sys.ViewManager.Forms.JGridView jGridView1;
        private System.Windows.Forms.Button btnTransistion;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Sys.ViewManager.Forms.JGridView jGridView2;
        private System.Windows.Forms.Button btnWorkflow;
        private System.Windows.Forms.Button btnNewWorkflow;
    }
}
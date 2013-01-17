namespace Sys.Workflow.Collaborative.Forms
{
    partial class StateEditor
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
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cblNodeType = new Sys.ViewManager.Forms.CheckBoxList();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStateName = new System.Windows.Forms.TextBox();
            this.txtWorkflowName = new System.Windows.Forms.TextBox();
            this.tabPageMetadata = new System.Windows.Forms.TabPage();
            this.txtMetadata = new System.Windows.Forms.RichTextBox();
            this.tabPageDependency = new System.Windows.Forms.TabPage();
            this.txtDependency = new System.Windows.Forms.RichTextBox();
            this.tabPagePreaction = new System.Windows.Forms.TabPage();
            this.txtPreaction = new System.Windows.Forms.RichTextBox();
            this.tabPageAction = new System.Windows.Forms.TabPage();
            this.txtAction = new System.Windows.Forms.RichTextBox();
            this.tabPageAfterAction = new System.Windows.Forms.TabPage();
            this.txtAfterAction = new System.Windows.Forms.RichTextBox();
            this.tabPagePostaction = new System.Windows.Forms.TabPage();
            this.txtPostaction = new System.Windows.Forms.RichTextBox();
            this.tabPageAgent = new System.Windows.Forms.TabPage();
            this.txtAgent = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.tabPageMetadata.SuspendLayout();
            this.tabPageDependency.SuspendLayout();
            this.tabPagePreaction.SuspendLayout();
            this.tabPageAction.SuspendLayout();
            this.tabPageAfterAction.SuspendLayout();
            this.tabPagePostaction.SuspendLayout();
            this.tabPageAgent.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(832, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = global::Sys.Workflow.Properties.Resources.disk;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonCancel
            // 
            this.toolStripButtonCancel.Image = global::Sys.Workflow.Properties.Resources.cancel;
            this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(63, 22);
            this.toolStripButtonCancel.Text = "Cancel";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageBasic);
            this.tabControl1.Controls.Add(this.tabPageMetadata);
            this.tabControl1.Controls.Add(this.tabPageDependency);
            this.tabControl1.Controls.Add(this.tabPagePreaction);
            this.tabControl1.Controls.Add(this.tabPageAction);
            this.tabControl1.Controls.Add(this.tabPageAfterAction);
            this.tabControl1.Controls.Add(this.tabPagePostaction);
            this.tabControl1.Controls.Add(this.tabPageAgent);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(832, 497);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.Controls.Add(this.txtOffset);
            this.tabPageBasic.Controls.Add(this.txtDuration);
            this.tabPageBasic.Controls.Add(this.txtIndex);
            this.tabPageBasic.Controls.Add(this.txtID);
            this.tabPageBasic.Controls.Add(this.cblNodeType);
            this.tabPageBasic.Controls.Add(this.txtLabel);
            this.tabPageBasic.Controls.Add(this.label1);
            this.tabPageBasic.Controls.Add(this.label6);
            this.tabPageBasic.Controls.Add(this.label2);
            this.tabPageBasic.Controls.Add(this.txtDescription);
            this.tabPageBasic.Controls.Add(this.label9);
            this.tabPageBasic.Controls.Add(this.label7);
            this.tabPageBasic.Controls.Add(this.label3);
            this.tabPageBasic.Controls.Add(this.label5);
            this.tabPageBasic.Controls.Add(this.label4);
            this.tabPageBasic.Controls.Add(this.label8);
            this.tabPageBasic.Controls.Add(this.txtStateName);
            this.tabPageBasic.Controls.Add(this.txtWorkflowName);
            this.tabPageBasic.Location = new System.Drawing.Point(4, 22);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasic.Size = new System.Drawing.Size(824, 471);
            this.tabPageBasic.TabIndex = 0;
            this.tabPageBasic.Text = "Basic";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(434, 241);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(100, 20);
            this.txtOffset.TabIndex = 14;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(434, 218);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 20);
            this.txtDuration.TabIndex = 14;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(372, 51);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.ReadOnly = true;
            this.txtIndex.Size = new System.Drawing.Size(100, 20);
            this.txtIndex.TabIndex = 13;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(372, 25);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 13;
            // 
            // cblNodeType
            // 
            this.cblNodeType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cblNodeType.Location = new System.Drawing.Point(14, 203);
            this.cblNodeType.Name = "cblNodeType";
            this.cblNodeType.Size = new System.Drawing.Size(273, 171);
            this.cblNodeType.TabIndex = 12;
            this.cblNodeType.Value = -1;
            // 
            // txtLabel
            // 
            this.txtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabel.Location = new System.Drawing.Point(105, 84);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(711, 20);
            this.txtLabel.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Title";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(105, 109);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(711, 47);
            this.txtDescription.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(369, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Offset";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(369, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Duration";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "State Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Index";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Workflow Name";
            // 
            // txtStateName
            // 
            this.txtStateName.Location = new System.Drawing.Point(105, 51);
            this.txtStateName.Name = "txtStateName";
            this.txtStateName.ReadOnly = true;
            this.txtStateName.Size = new System.Drawing.Size(182, 20);
            this.txtStateName.TabIndex = 9;
            // 
            // txtWorkflowName
            // 
            this.txtWorkflowName.Location = new System.Drawing.Point(105, 25);
            this.txtWorkflowName.Name = "txtWorkflowName";
            this.txtWorkflowName.ReadOnly = true;
            this.txtWorkflowName.Size = new System.Drawing.Size(182, 20);
            this.txtWorkflowName.TabIndex = 9;
            // 
            // tabPageMetadata
            // 
            this.tabPageMetadata.Controls.Add(this.txtMetadata);
            this.tabPageMetadata.Location = new System.Drawing.Point(4, 22);
            this.tabPageMetadata.Name = "tabPageMetadata";
            this.tabPageMetadata.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMetadata.Size = new System.Drawing.Size(824, 471);
            this.tabPageMetadata.TabIndex = 1;
            this.tabPageMetadata.Text = "Metadata";
            this.tabPageMetadata.UseVisualStyleBackColor = true;
            // 
            // txtMetadata
            // 
            this.txtMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMetadata.Location = new System.Drawing.Point(3, 3);
            this.txtMetadata.Name = "txtMetadata";
            this.txtMetadata.Size = new System.Drawing.Size(818, 465);
            this.txtMetadata.TabIndex = 0;
            this.txtMetadata.Text = "";
            // 
            // tabPageDependency
            // 
            this.tabPageDependency.Controls.Add(this.txtDependency);
            this.tabPageDependency.Location = new System.Drawing.Point(4, 22);
            this.tabPageDependency.Name = "tabPageDependency";
            this.tabPageDependency.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDependency.Size = new System.Drawing.Size(824, 471);
            this.tabPageDependency.TabIndex = 2;
            this.tabPageDependency.Text = "Dependency";
            this.tabPageDependency.UseVisualStyleBackColor = true;
            // 
            // txtDependency
            // 
            this.txtDependency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDependency.Location = new System.Drawing.Point(3, 3);
            this.txtDependency.Name = "txtDependency";
            this.txtDependency.Size = new System.Drawing.Size(818, 465);
            this.txtDependency.TabIndex = 0;
            this.txtDependency.Text = "";
            // 
            // tabPagePreaction
            // 
            this.tabPagePreaction.Controls.Add(this.txtPreaction);
            this.tabPagePreaction.Location = new System.Drawing.Point(4, 22);
            this.tabPagePreaction.Name = "tabPagePreaction";
            this.tabPagePreaction.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreaction.Size = new System.Drawing.Size(824, 471);
            this.tabPagePreaction.TabIndex = 3;
            this.tabPagePreaction.Text = "Preaction";
            this.tabPagePreaction.UseVisualStyleBackColor = true;
            // 
            // txtPreaction
            // 
            this.txtPreaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreaction.Location = new System.Drawing.Point(3, 3);
            this.txtPreaction.Name = "txtPreaction";
            this.txtPreaction.Size = new System.Drawing.Size(818, 465);
            this.txtPreaction.TabIndex = 0;
            this.txtPreaction.Text = "";
            // 
            // tabPageAction
            // 
            this.tabPageAction.Controls.Add(this.txtAction);
            this.tabPageAction.Location = new System.Drawing.Point(4, 22);
            this.tabPageAction.Name = "tabPageAction";
            this.tabPageAction.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAction.Size = new System.Drawing.Size(824, 471);
            this.tabPageAction.TabIndex = 4;
            this.tabPageAction.Text = "Action";
            this.tabPageAction.UseVisualStyleBackColor = true;
            // 
            // txtAction
            // 
            this.txtAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAction.Location = new System.Drawing.Point(3, 3);
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(818, 465);
            this.txtAction.TabIndex = 0;
            this.txtAction.Text = "";
            // 
            // tabPageAfterAction
            // 
            this.tabPageAfterAction.Controls.Add(this.txtAfterAction);
            this.tabPageAfterAction.Location = new System.Drawing.Point(4, 22);
            this.tabPageAfterAction.Name = "tabPageAfterAction";
            this.tabPageAfterAction.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAfterAction.Size = new System.Drawing.Size(824, 471);
            this.tabPageAfterAction.TabIndex = 5;
            this.tabPageAfterAction.Text = "After Action";
            this.tabPageAfterAction.UseVisualStyleBackColor = true;
            // 
            // txtAfterAction
            // 
            this.txtAfterAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAfterAction.Location = new System.Drawing.Point(3, 3);
            this.txtAfterAction.Name = "txtAfterAction";
            this.txtAfterAction.Size = new System.Drawing.Size(818, 465);
            this.txtAfterAction.TabIndex = 0;
            this.txtAfterAction.Text = "";
            // 
            // tabPagePostaction
            // 
            this.tabPagePostaction.Controls.Add(this.txtPostaction);
            this.tabPagePostaction.Location = new System.Drawing.Point(4, 22);
            this.tabPagePostaction.Name = "tabPagePostaction";
            this.tabPagePostaction.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePostaction.Size = new System.Drawing.Size(824, 471);
            this.tabPagePostaction.TabIndex = 6;
            this.tabPagePostaction.Text = "Postaction";
            this.tabPagePostaction.UseVisualStyleBackColor = true;
            // 
            // txtPostaction
            // 
            this.txtPostaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPostaction.Location = new System.Drawing.Point(3, 3);
            this.txtPostaction.Name = "txtPostaction";
            this.txtPostaction.Size = new System.Drawing.Size(818, 465);
            this.txtPostaction.TabIndex = 0;
            this.txtPostaction.Text = "";
            // 
            // tabPageAgent
            // 
            this.tabPageAgent.Controls.Add(this.txtAgent);
            this.tabPageAgent.Location = new System.Drawing.Point(4, 22);
            this.tabPageAgent.Name = "tabPageAgent";
            this.tabPageAgent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAgent.Size = new System.Drawing.Size(824, 471);
            this.tabPageAgent.TabIndex = 7;
            this.tabPageAgent.Text = "Agent";
            this.tabPageAgent.UseVisualStyleBackColor = true;
            // 
            // txtAgent
            // 
            this.txtAgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAgent.Location = new System.Drawing.Point(3, 3);
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Size = new System.Drawing.Size(818, 465);
            this.txtAgent.TabIndex = 0;
            this.txtAgent.Text = "";
            // 
            // StateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 522);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "StateEditor";
            this.Text = "Workflow/State Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            this.tabPageBasic.PerformLayout();
            this.tabPageMetadata.ResumeLayout(false);
            this.tabPageDependency.ResumeLayout(false);
            this.tabPagePreaction.ResumeLayout(false);
            this.tabPageAction.ResumeLayout(false);
            this.tabPageAfterAction.ResumeLayout(false);
            this.tabPagePostaction.ResumeLayout(false);
            this.tabPageAgent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBasic;
        private System.Windows.Forms.TabPage tabPageMetadata;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStateName;
        private System.Windows.Forms.TextBox txtWorkflowName;
        private System.Windows.Forms.TabPage tabPageDependency;
        private System.Windows.Forms.TabPage tabPagePreaction;
        private System.Windows.Forms.TabPage tabPageAction;
        private System.Windows.Forms.TabPage tabPageAfterAction;
        private System.Windows.Forms.TabPage tabPagePostaction;
        private System.Windows.Forms.TabPage tabPageAgent;
        private Sys.ViewManager.Forms.CheckBoxList cblNodeType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtMetadata;
        private System.Windows.Forms.RichTextBox txtDependency;
        private System.Windows.Forms.RichTextBox txtPreaction;
        private System.Windows.Forms.RichTextBox txtAction;
        private System.Windows.Forms.RichTextBox txtAfterAction;
        private System.Windows.Forms.RichTextBox txtPostaction;
        private System.Windows.Forms.RichTextBox txtAgent;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
    }
}
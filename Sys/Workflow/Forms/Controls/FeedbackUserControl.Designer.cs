namespace Sys.Workflow.Forms
{
    partial class FeedbackUserControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbHistory = new System.Windows.Forms.RichTextBox();
            this.tbNote = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.dudStates = new System.Windows.Forms.DomainUpDown();
            this.lblAction = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.cbReopen = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbHistory);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbNote);
            this.splitContainer1.Size = new System.Drawing.Size(274, 490);
            this.splitContainer1.SplitterDistance = 370;
            this.splitContainer1.TabIndex = 2;
            // 
            // tbHistory
            // 
            this.tbHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbHistory.Location = new System.Drawing.Point(0, 0);
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.ReadOnly = true;
            this.tbHistory.Size = new System.Drawing.Size(274, 370);
            this.tbHistory.TabIndex = 0;
            this.tbHistory.Text = "";
            // 
            // tbNote
            // 
            this.tbNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNote.Location = new System.Drawing.Point(0, 0);
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(274, 116);
            this.tbNote.TabIndex = 1;
            this.tbNote.Text = "";
            this.tbNote.TextChanged += new System.EventHandler(this.tbNote_TextChanged);
            this.tbNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNote_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSend.Location = new System.Drawing.Point(3, 546);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 32);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // dudStates
            // 
            this.dudStates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dudStates.Location = new System.Drawing.Point(3, 521);
            this.dudStates.Name = "dudStates";
            this.dudStates.Size = new System.Drawing.Size(122, 20);
            this.dudStates.TabIndex = 4;
            this.dudStates.SelectedItemChanged += new System.EventHandler(this.dudStates_SelectedItemChanged);
            // 
            // lblAction
            // 
            this.lblAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(131, 523);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(23, 13);
            this.lblAction.TabIndex = 5;
            this.lblAction.Text = "To:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(274, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Image = global::Sys.Workflow.Properties.Resources.RefreshDocViewHS;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // cbReopen
            // 
            this.cbReopen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbReopen.AutoSize = true;
            this.cbReopen.Location = new System.Drawing.Point(84, 555);
            this.cbReopen.Name = "cbReopen";
            this.cbReopen.Size = new System.Drawing.Size(64, 17);
            this.cbReopen.TabIndex = 10;
            this.cbReopen.Text = "Reopen";
            this.cbReopen.UseVisualStyleBackColor = true;
            // 
            // FeedbackUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbReopen);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.dudStates);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FeedbackUserControl";
            this.Size = new System.Drawing.Size(274, 586);
            this.Load += new System.EventHandler(this.FeedbackUserControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox tbHistory;
        private System.Windows.Forms.RichTextBox tbNote;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.DomainUpDown dudStates;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.CheckBox cbReopen;

    }
}

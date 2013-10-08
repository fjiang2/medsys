namespace Sys.Workflow.Forms
{
    partial class ReviewForm
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
            this.toolStripLabelStateName = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSubmit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonValidate = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.feedbackUserControl1 = new Sys.Workflow.Forms.FeedbackUserControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelStateName,
            this.toolStripButtonSave,
            this.toolStripButtonSubmit,
            this.toolStripButtonHistory,
            this.toolStripButtonExit,
            this.toolStripButtonValidate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelStateName
            // 
            this.toolStripLabelStateName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripLabelStateName.Image = global::Sys.Workflow.Properties.Resources.page_white_wrench;
            this.toolStripLabelStateName.Name = "toolStripLabelStateName";
            this.toolStripLabelStateName.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabelStateName.Text = "State";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DoubleClickEnabled = true;
            this.toolStripButtonSave.Image = global::Sys.Workflow.Properties.Resources.disk;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.ToolTipText = "Save as draft";
            this.toolStripButtonSave.Visible = false;
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonSubmit
            // 
            this.toolStripButtonSubmit.Image = global::Sys.Workflow.Properties.Resources.accept;
            this.toolStripButtonSubmit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSubmit.Name = "toolStripButtonSubmit";
            this.toolStripButtonSubmit.Size = new System.Drawing.Size(65, 22);
            this.toolStripButtonSubmit.Text = "Submit";
            this.toolStripButtonSubmit.Click += new System.EventHandler(this.toolStripButtonSubmit_Click);
            // 
            // toolStripButtonHistory
            // 
            this.toolStripButtonHistory.Image = global::Sys.Workflow.Properties.Resources.time;
            this.toolStripButtonHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHistory.Name = "toolStripButtonHistory";
            this.toolStripButtonHistory.Size = new System.Drawing.Size(65, 22);
            this.toolStripButtonHistory.Text = "History";
            this.toolStripButtonHistory.Click += new System.EventHandler(this.toolStripButtonHistory_Click);
            // 
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonExit.Image = global::Sys.Workflow.Properties.Resources.door_out;
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Size = new System.Drawing.Size(45, 22);
            this.toolStripButtonExit.Text = "Exit";
            this.toolStripButtonExit.ToolTipText = "Close current window";
            this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // toolStripButtonValidate
            // 
            this.toolStripButtonValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonValidate.Image = global::Sys.Workflow.Properties.Resources.tick;
            this.toolStripButtonValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonValidate.Name = "toolStripButtonValidate";
            this.toolStripButtonValidate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonValidate.Text = "Validate Data Fields";
            this.toolStripButtonValidate.Click += new System.EventHandler(this.toolStripButtonValidate_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.feedbackUserControl1);
            this.splitContainer1.Size = new System.Drawing.Size(834, 582);
            this.splitContainer1.SplitterDistance = 575;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Size = new System.Drawing.Size(575, 582);
            this.splitContainer2.SplitterDistance = 370;
            this.splitContainer2.TabIndex = 0;
            // 
            // feedbackUserControl1
            // 
            this.feedbackUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feedbackUserControl1.Location = new System.Drawing.Point(0, 0);
            this.feedbackUserControl1.Name = "feedbackUserControl1";
            this.feedbackUserControl1.ParentControl = null;
            this.feedbackUserControl1.ReviewMode = true;
            this.feedbackUserControl1.Size = new System.Drawing.Size(255, 582);
            this.feedbackUserControl1.TabIndex = 0;
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 607);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ReviewForm";
            this.Text = "Review Form";
            this.Load += new System.EventHandler(this.ReviewForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonSubmit;
        private System.Windows.Forms.ToolStripButton toolStripButtonHistory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private FeedbackUserControl feedbackUserControl1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelStateName;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.ToolStripButton toolStripButtonValidate;
    }
}
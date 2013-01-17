namespace Sys.Workflow.Forms
{
    partial class SimpleForm
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
            this.toolStrip1.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(899, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelStateName
            // 
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
            // SimpleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 587);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SimpleForm";
            this.Text = "Simple Form";
            this.Load += new System.EventHandler(this.Form_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton toolStripButtonSave;
        protected System.Windows.Forms.ToolStripButton toolStripButtonSubmit;
        protected System.Windows.Forms.ToolStripButton toolStripButtonHistory;
        protected System.Windows.Forms.ToolStripLabel toolStripLabelStateName;
        protected System.Windows.Forms.ToolStripButton toolStripButtonExit;
        protected System.Windows.Forms.ToolStripButton toolStripButtonValidate;
    }
}
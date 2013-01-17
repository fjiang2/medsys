namespace Sys.Workflow.Collaborative.Forms
{
    partial class TaskListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskListForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCompleted = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUnassigned = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReceived = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMyAssignments = new System.Windows.Forms.ToolStripButton();
            this.jGridView1 = new Sys.ViewManager.Forms.JGridView();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.imageListPriority = new System.Windows.Forms.ImageList();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripButtonPrint,
            this.toolStripSeparator1,
            this.toolStripButtonCompleted,
            this.toolStripButtonUnassigned,
            this.toolStripButtonReceived,
            this.toolStripButtonMyAssignments});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(856, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripButtonPrint
            // 
            this.toolStripButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrint.Image = global::Sys.Workflow.Properties.Resources.PrintHS;
            this.toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrint.Name = "toolStripButtonPrint";
            this.toolStripButtonPrint.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPrint.Text = "Print";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonCompleted
            // 
            this.toolStripButtonCompleted.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonCompleted.Image = global::Sys.Workflow.Properties.Resources.application_view_list;
            this.toolStripButtonCompleted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCompleted.Name = "toolStripButtonCompleted";
            this.toolStripButtonCompleted.Size = new System.Drawing.Size(86, 22);
            this.toolStripButtonCompleted.Text = "Completed";
            this.toolStripButtonCompleted.Click += new System.EventHandler(this.toolStripButtonCompleted_Click);
            // 
            // toolStripButtonUnassigned
            // 
            this.toolStripButtonUnassigned.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonUnassigned.Image = global::Sys.Workflow.Properties.Resources.application_view_list;
            this.toolStripButtonUnassigned.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUnassigned.Name = "toolStripButtonUnassigned";
            this.toolStripButtonUnassigned.Size = new System.Drawing.Size(88, 22);
            this.toolStripButtonUnassigned.Text = "Unassigned";
            this.toolStripButtonUnassigned.Click += new System.EventHandler(this.toolStripButtonUnassigned_Click);
            // 
            // toolStripButtonReceived
            // 
            this.toolStripButtonReceived.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonReceived.Image = global::Sys.Workflow.Properties.Resources.application_view_list;
            this.toolStripButtonReceived.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReceived.Name = "toolStripButtonReceived";
            this.toolStripButtonReceived.Size = new System.Drawing.Size(74, 22);
            this.toolStripButtonReceived.Text = "Received";
            this.toolStripButtonReceived.Click += new System.EventHandler(this.toolStripButtonReceived_Click);
            // 
            // toolStripButtonMyAssignments
            // 
            this.toolStripButtonMyAssignments.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonMyAssignments.Image = global::Sys.Workflow.Properties.Resources.application_form_edit;
            this.toolStripButtonMyAssignments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMyAssignments.Name = "toolStripButtonMyAssignments";
            this.toolStripButtonMyAssignments.Size = new System.Drawing.Size(115, 22);
            this.toolStripButtonMyAssignments.Text = "My Assignments";
            this.toolStripButtonMyAssignments.Click += new System.EventHandler(this.toolStripButtonMyAssignments_Click);
            // 
            // jGridView1
            // 
            this.jGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jGridView1.DataSource = null;
            this.jGridView1.Location = new System.Drawing.Point(0, 28);
            this.jGridView1.Name = "jGridView1";
            this.jGridView1.Size = new System.Drawing.Size(856, 223);
            this.jGridView1.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "lock_add.png");
            this.imageList1.Images.SetKeyName(1, "lock_open.png");
            this.imageList1.Images.SetKeyName(2, "email.png");
            this.imageList1.Images.SetKeyName(3, "email_open_image.png");
            this.imageList1.Images.SetKeyName(4, "timeline_marker.png");
            // 
            // imageListPriority
            // 
            this.imageListPriority.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPriority.ImageStream")));
            this.imageListPriority.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPriority.Images.SetKeyName(0, "bullet_black.png");
            this.imageListPriority.Images.SetKeyName(1, "bullet_blue.png");
            this.imageListPriority.Images.SetKeyName(2, "bullet_red.png");
            // 
            // TaskListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 251);
            this.Controls.Add(this.jGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TaskListForm";
            this.Text = "Task List";
            this.Load += new System.EventHandler(this.TaskListForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrint;
        private Sys.ViewManager.Forms.JGridView jGridView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageListPriority;
        private System.Windows.Forms.ToolStripButton toolStripButtonMyAssignments;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonUnassigned;
        private System.Windows.Forms.ToolStripButton toolStripButtonCompleted;
        private System.Windows.Forms.ToolStripButton toolStripButtonReceived;
    }
}
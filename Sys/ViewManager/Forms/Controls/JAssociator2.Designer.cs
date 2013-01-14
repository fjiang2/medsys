namespace Sys.ViewManager.Forms
{
    partial class JAssociator2
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
            this.gridView1 = new Sys.ViewManager.Forms.JGridView();
            this.gridView2 = new Sys.ViewManager.Forms.JGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridView2);
            this.splitContainer1.Size = new System.Drawing.Size(736, 553);
            this.splitContainer1.SplitterDistance = 346;
            this.splitContainer1.TabIndex = 0;
            // 
            // gridView1
            // 
            this.gridView1.DataSource = null;
            this.gridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView1.Location = new System.Drawing.Point(0, 0);
            this.gridView1.Name = "gridView1";
            this.gridView1.Size = new System.Drawing.Size(346, 553);
            this.gridView1.TabIndex = 0;
            // 
            // gridView2
            // 
            this.gridView2.DataSource = null;
            this.gridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView2.Location = new System.Drawing.Point(0, 0);
            this.gridView2.Name = "gridView2";
            this.gridView2.Size = new System.Drawing.Size(386, 553);
            this.gridView2.TabIndex = 0;
            // 
            // JAssociator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "JAssociator";
            this.Size = new System.Drawing.Size(736, 553);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private JGridView gridView1;
        private JGridView gridView2;
    }
}

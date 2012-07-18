namespace X12.Forms
{
    partial class SegmentEditor
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
            this.segmentEdit1 = new X12.Forms.SegmentEdit();
            this.SuspendLayout();
            // 
            // segmentEdit1
            // 
            this.segmentEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.segmentEdit1.Location = new System.Drawing.Point(0, 0);
            this.segmentEdit1.Name = "segmentEdit1";
            this.segmentEdit1.SegmentLine = null;
            this.segmentEdit1.Size = new System.Drawing.Size(521, 366);
            this.segmentEdit1.TabIndex = 0;
            // 
            // SegmentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 366);
            this.Controls.Add(this.segmentEdit1);
            this.Name = "SegmentEditor";
            this.ShowInTaskbar = false;
            this.Text = "SegmentEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private SegmentEdit segmentEdit1;
    }
}
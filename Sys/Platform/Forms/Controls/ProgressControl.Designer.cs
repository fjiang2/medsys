namespace Sys.Platform.Forms
{
    partial class ProgressControl
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
            this.txtCounter2 = new System.Windows.Forms.TextBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.btnAction = new System.Windows.Forms.Button();
            this.txtCounter1 = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtCounter2
            // 
            this.txtCounter2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCounter2.Location = new System.Drawing.Point(325, 38);
            this.txtCounter2.Name = "txtCounter2";
            this.txtCounter2.ReadOnly = true;
            this.txtCounter2.Size = new System.Drawing.Size(99, 20);
            this.txtCounter2.TabIndex = 28;
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar2.Location = new System.Drawing.Point(8, 38);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(311, 23);
            this.progressBar2.TabIndex = 27;
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.Location = new System.Drawing.Point(331, 179);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(93, 47);
            this.btnAction.TabIndex = 26;
            this.btnAction.Text = "Action";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // txtCounter1
            // 
            this.txtCounter1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCounter1.Location = new System.Drawing.Point(325, 12);
            this.txtCounter1.Name = "txtCounter1";
            this.txtCounter1.ReadOnly = true;
            this.txtCounter1.Size = new System.Drawing.Size(99, 20);
            this.txtCounter1.TabIndex = 24;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(8, 73);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(311, 153);
            this.txtMessage.TabIndex = 25;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(8, 9);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(311, 23);
            this.progressBar1.TabIndex = 23;
            // 
            // ProgressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCounter2);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtCounter1);
            this.Name = "ProgressControl";
            this.Size = new System.Drawing.Size(428, 248);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCounter2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.TextBox txtCounter1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

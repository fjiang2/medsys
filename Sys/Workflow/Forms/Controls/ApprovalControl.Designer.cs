namespace Sys.Workflow.Forms
{
    partial class ApprovalControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.radioDispute = new System.Windows.Forms.RadioButton();
            this.radioApprove = new System.Windows.Forms.RadioButton();
            this.radioReject = new System.Windows.Forms.RadioButton();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.jVerticalLabel1 = new Sys.ViewManager.Forms.JVerticalLabel();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.linkTitle = new System.Windows.Forms.LinkLabel();
            this.grpAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "By :";
            // 
            // tbUserName
            // 
            this.tbUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbUserName.Location = new System.Drawing.Point(28, 87);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.ReadOnly = true;
            this.tbUserName.Size = new System.Drawing.Size(118, 20);
            this.tbUserName.TabIndex = 1;
            this.tbUserName.TextChanged += new System.EventHandler(this.tbUserName_TextChanged);
            this.tbUserName.Leave += new System.EventHandler(this.tbUserName_Leave);
            // 
            // radioDispute
            // 
            this.radioDispute.AutoSize = true;
            this.radioDispute.Location = new System.Drawing.Point(17, 57);
            this.radioDispute.Name = "radioDispute";
            this.radioDispute.Size = new System.Drawing.Size(61, 17);
            this.radioDispute.TabIndex = 6;
            this.radioDispute.Text = "Dispute";
            this.radioDispute.UseVisualStyleBackColor = true;
            // 
            // radioApprove
            // 
            this.radioApprove.AutoSize = true;
            this.radioApprove.Location = new System.Drawing.Point(17, 19);
            this.radioApprove.Name = "radioApprove";
            this.radioApprove.Size = new System.Drawing.Size(65, 17);
            this.radioApprove.TabIndex = 6;
            this.radioApprove.Text = "Approve";
            this.radioApprove.UseVisualStyleBackColor = true;
            // 
            // radioReject
            // 
            this.radioReject.AutoSize = true;
            this.radioReject.Location = new System.Drawing.Point(17, 38);
            this.radioReject.Name = "radioReject";
            this.radioReject.Size = new System.Drawing.Size(56, 17);
            this.radioReject.TabIndex = 6;
            this.radioReject.Text = "Reject";
            this.radioReject.UseVisualStyleBackColor = true;
            // 
            // txtReason
            // 
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReason.Location = new System.Drawing.Point(28, 118);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(418, 48);
            this.txtReason.TabIndex = 7;
            // 
            // jVerticalLabel1
            // 
            this.jVerticalLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.jVerticalLabel1.Location = new System.Drawing.Point(7, 106);
            this.jVerticalLabel1.Name = "jVerticalLabel1";
            this.jVerticalLabel1.Size = new System.Drawing.Size(24, 60);
            this.jVerticalLabel1.TabIndex = 8;
            this.jVerticalLabel1.Text = "Reason:";
            // 
            // grpAction
            // 
            this.grpAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAction.Controls.Add(this.radioApprove);
            this.grpAction.Controls.Add(this.radioReject);
            this.grpAction.Controls.Add(this.radioDispute);
            this.grpAction.Location = new System.Drawing.Point(452, 81);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(103, 85);
            this.grpAction.TabIndex = 9;
            this.grpAction.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsTab = true;
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(0, 28);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(551, 53);
            this.txtDescription.TabIndex = 10;
            this.txtDescription.Text = "";
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(152, 87);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(294, 20);
            this.txtFullName.TabIndex = 11;
            // 
            // txtLabel
            // 
            this.linkTitle.AutoSize = true;
            this.linkTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkTitle.Location = new System.Drawing.Point(4, 9);
            this.linkTitle.Name = "txtLabel";
            this.linkTitle.Size = new System.Drawing.Size(32, 13);
            this.linkTitle.TabIndex = 12;
            this.linkTitle.Text = "Title";
            // 
            // ApprovalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkTitle);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.jVerticalLabel1);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUserName);
            this.Name = "ApprovalControl";
            this.Size = new System.Drawing.Size(558, 177);
            this.Load += new System.EventHandler(this.ApprovalControl_Load);
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.RadioButton radioDispute;
        private System.Windows.Forms.RadioButton radioApprove;
        private System.Windows.Forms.RadioButton radioReject;
        private System.Windows.Forms.TextBox txtReason;
        private Sys.ViewManager.Forms.JVerticalLabel jVerticalLabel1;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.LinkLabel linkTitle;
    }
}

namespace Sys.Workflow.Forms
{
    partial class ActivityForm
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
            this.btnComplete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStateId = new System.Windows.Forms.TextBox();
            this.chkBranch = new System.Windows.Forms.CheckBox();
            this.btnNotify = new System.Windows.Forms.Button();
            this.tbListenedState = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(237, 212);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(125, 23);
            this.btnComplete.TabIndex = 0;
            this.btnComplete.Text = "Complete";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current State#";
            // 
            // tbStateId
            // 
            this.tbStateId.Location = new System.Drawing.Point(94, 20);
            this.tbStateId.Name = "tbStateId";
            this.tbStateId.Size = new System.Drawing.Size(100, 20);
            this.tbStateId.TabIndex = 2;
            // 
            // chkBranch
            // 
            this.chkBranch.AutoSize = true;
            this.chkBranch.Location = new System.Drawing.Point(237, 22);
            this.chkBranch.Name = "chkBranch";
            this.chkBranch.Size = new System.Drawing.Size(60, 17);
            this.chkBranch.TabIndex = 3;
            this.chkBranch.Text = "Branch";
            this.chkBranch.UseVisualStyleBackColor = true;
            // 
            // btnNotify
            // 
            this.btnNotify.Location = new System.Drawing.Point(237, 183);
            this.btnNotify.Name = "btnNotify";
            this.btnNotify.Size = new System.Drawing.Size(125, 23);
            this.btnNotify.TabIndex = 0;
            this.btnNotify.Text = "Notify Listeners";
            this.btnNotify.UseVisualStyleBackColor = true;
            this.btnNotify.Click += new System.EventHandler(this.btnNotify_Click);
            // 
            // tbListenedState
            // 
            this.tbListenedState.Location = new System.Drawing.Point(94, 105);
            this.tbListenedState.Name = "tbListenedState";
            this.tbListenedState.Size = new System.Drawing.Size(100, 20);
            this.tbListenedState.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Listen to state:";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(201, 101);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(75, 23);
            this.btnListen.TabIndex = 4;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // ActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 258);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.chkBranch);
            this.Controls.Add(this.tbListenedState);
            this.Controls.Add(this.tbStateId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNotify);
            this.Controls.Add(this.btnComplete);
            this.Name = "ActivityForm";
            this.Text = "Activity Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStateId;
        private System.Windows.Forms.CheckBox chkBranch;
        private System.Windows.Forms.Button btnNotify;
        private System.Windows.Forms.TextBox tbListenedState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnListen;
    }
}
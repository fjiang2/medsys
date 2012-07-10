namespace Sys.Messaging
{
    partial class frmUserManagement
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFormClass = new System.Windows.Forms.TextBox();
            this.btnSendIM = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTaskID = new System.Windows.Forms.TextBox();
            this.btnWorkflow = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(170, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 20);
            this.textBox1.TabIndex = 1;
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(12, 177);
            this.tbSubject.Multiline = true;
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(506, 92);
            this.tbSubject.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Message";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(12, 305);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(194, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "New Task and Send to Channel";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Send to (WinForm Class)";
            // 
            // tbFormClass
            // 
            this.tbFormClass.Location = new System.Drawing.Point(15, 129);
            this.tbFormClass.Name = "tbFormClass";
            this.tbFormClass.Size = new System.Drawing.Size(503, 20);
            this.tbFormClass.TabIndex = 6;
            this.tbFormClass.Text = "ViewManager.Workflow.TaskListForm";
            // 
            // btnSendIM
            // 
            this.btnSendIM.Location = new System.Drawing.Point(364, 411);
            this.btnSendIM.Name = "btnSendIM";
            this.btnSendIM.Size = new System.Drawing.Size(95, 23);
            this.btnSendIM.TabIndex = 7;
            this.btnSendIM.Text = "Send to IM";
            this.btnSendIM.UseVisualStyleBackColor = true;
            this.btnSendIM.Click += new System.EventHandler(this.btnSendIM_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Send to (Badge ID)";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(364, 385);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(229, 20);
            this.tbUserName.TabIndex = 9;
            this.tbUserName.Text = "fjiang2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Task ID";
            // 
            // tbTaskID
            // 
            this.tbTaskID.Location = new System.Drawing.Point(63, 273);
            this.tbTaskID.Name = "tbTaskID";
            this.tbTaskID.Size = new System.Drawing.Size(137, 20);
            this.tbTaskID.TabIndex = 11;
            // 
            // btnWorkflow
            // 
            this.btnWorkflow.Location = new System.Drawing.Point(374, 305);
            this.btnWorkflow.Name = "btnWorkflow";
            this.btnWorkflow.Size = new System.Drawing.Size(162, 23);
            this.btnWorkflow.TabIndex = 13;
            this.btnWorkflow.Text = "Workflow Configurate";
            this.btnWorkflow.UseVisualStyleBackColor = true;
            this.btnWorkflow.Click += new System.EventHandler(this.btnWorkflow_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 446);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnWorkflow);
            this.Controls.Add(this.tbTaskID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSendIM);
            this.Controls.Add(this.tbFormClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.textBox1);
            this.Name = "frmUserManagement";
            this.Text = "Messaging User Management";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFormClass;
        private System.Windows.Forms.Button btnSendIM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTaskID;
        private System.Windows.Forms.Button btnWorkflow;
        private System.Windows.Forms.Button button1;
    }
}
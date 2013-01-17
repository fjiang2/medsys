namespace Sys.Workflow.Collaborative.Forms
{
    partial class WorkflowInstanceForm
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
            this.tbWorkflowName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbWorkflowInstanceID = new System.Windows.Forms.TextBox();
            this.tbWorkflowDescription = new System.Windows.Forms.TextBox();
            this.btnNewWorkflowInstance = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLabel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCompleteDate = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnInstanceLookup = new System.Windows.Forms.Button();
            this.linkWorkflow = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEditHeap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbWorkflowName
            // 
            this.tbWorkflowName.Location = new System.Drawing.Point(101, 24);
            this.tbWorkflowName.Name = "tbWorkflowName";
            this.tbWorkflowName.Size = new System.Drawing.Size(116, 20);
            this.tbWorkflowName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Instance ID";
            // 
            // tbWorkflowInstanceID
            // 
            this.tbWorkflowInstanceID.Enabled = false;
            this.tbWorkflowInstanceID.Location = new System.Drawing.Point(101, 57);
            this.tbWorkflowInstanceID.Name = "tbWorkflowInstanceID";
            this.tbWorkflowInstanceID.Size = new System.Drawing.Size(116, 20);
            this.tbWorkflowInstanceID.TabIndex = 5;
            // 
            // tbWorkflowDescription
            // 
            this.tbWorkflowDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWorkflowDescription.Location = new System.Drawing.Point(223, 24);
            this.tbWorkflowDescription.Name = "tbWorkflowDescription";
            this.tbWorkflowDescription.ReadOnly = true;
            this.tbWorkflowDescription.Size = new System.Drawing.Size(353, 20);
            this.tbWorkflowDescription.TabIndex = 4;
            this.tbWorkflowDescription.TabStop = false;
            // 
            // btnNewWorkflowInstance
            // 
            this.btnNewWorkflowInstance.Location = new System.Drawing.Point(212, 201);
            this.btnNewWorkflowInstance.Name = "btnNewWorkflowInstance";
            this.btnNewWorkflowInstance.Size = new System.Drawing.Size(115, 23);
            this.btnNewWorkflowInstance.TabIndex = 100;
            this.btnNewWorkflowInstance.Text = "Start Workflow";
            this.btnNewWorkflowInstance.UseVisualStyleBackColor = true;
            this.btnNewWorkflowInstance.Click += new System.EventHandler(this.btnNewWorkflowInstance_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Label";
            // 
            // tbLabel
            // 
            this.tbLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLabel.Location = new System.Drawing.Point(101, 89);
            this.tbLabel.Name = "tbLabel";
            this.tbLabel.Size = new System.Drawing.Size(464, 20);
            this.tbLabel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(101, 118);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(464, 20);
            this.tbDescription.TabIndex = 7;
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorkDate.Location = new System.Drawing.Point(76, 151);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(104, 20);
            this.dtpWorkDate.TabIndex = 8;
            // 
            // dtpCompleteDate
            // 
            this.dtpCompleteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCompleteDate.Location = new System.Drawing.Point(251, 149);
            this.dtpCompleteDate.Name = "dtpCompleteDate";
            this.dtpCompleteDate.Size = new System.Drawing.Size(104, 20);
            this.dtpCompleteDate.TabIndex = 9;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(41, 151);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "From:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(191, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Complete:";
            // 
            // btnInstanceLookup
            // 
            this.btnInstanceLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstanceLookup.Image = global::Sys.Workflow.Properties.Resources.ZoomHS;
            this.btnInstanceLookup.Location = new System.Drawing.Point(223, 56);
            this.btnInstanceLookup.Name = "btnInstanceLookup";
            this.btnInstanceLookup.Size = new System.Drawing.Size(23, 20);
            this.btnInstanceLookup.TabIndex = 6;
            this.btnInstanceLookup.UseVisualStyleBackColor = true;
            this.btnInstanceLookup.Click += new System.EventHandler(this.btnInstanceLookup_Click);
            // 
            // linkWorkflow
            // 
            this.linkWorkflow.AutoSize = true;
            this.linkWorkflow.Location = new System.Drawing.Point(22, 27);
            this.linkWorkflow.Name = "linkWorkflow";
            this.linkWorkflow.Size = new System.Drawing.Size(52, 13);
            this.linkWorkflow.TabIndex = 0;
            this.linkWorkflow.TabStop = true;
            this.linkWorkflow.Text = "Workflow";
            this.linkWorkflow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWorkflow_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(440, 201);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 23);
            this.btnSave.TabIndex = 100;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEditHeap
            // 
            this.btnEditHeap.Location = new System.Drawing.Point(333, 201);
            this.btnEditHeap.Name = "btnEditHeap";
            this.btnEditHeap.Size = new System.Drawing.Size(101, 23);
            this.btnEditHeap.TabIndex = 101;
            this.btnEditHeap.Text = "Edit Heap";
            this.btnEditHeap.UseVisualStyleBackColor = true;
            this.btnEditHeap.Click += new System.EventHandler(this.btnEditHeap_Click);
            // 
            // WorkflowInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 247);
            this.Controls.Add(this.btnEditHeap);
            this.Controls.Add(this.linkWorkflow);
            this.Controls.Add(this.dtpWorkDate);
            this.Controls.Add(this.dtpCompleteDate);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNewWorkflowInstance);
            this.Controls.Add(this.tbWorkflowDescription);
            this.Controls.Add(this.btnInstanceLookup);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbLabel);
            this.Controls.Add(this.tbWorkflowInstanceID);
            this.Controls.Add(this.tbWorkflowName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WorkflowInstanceForm";
            this.Text = "Workflow Instance";
            this.Load += new System.EventHandler(this.WorkflowInstanceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWorkflowName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbWorkflowInstanceID;
        private System.Windows.Forms.TextBox tbWorkflowDescription;
        private System.Windows.Forms.Button btnNewWorkflowInstance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.DateTimePicker dtpCompleteDate;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnInstanceLookup;
        private System.Windows.Forms.LinkLabel linkWorkflow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEditHeap;
    }
}
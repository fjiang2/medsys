namespace Sys.Workflow.Collaborative.Forms
{
    partial class TaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtTaskId = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStartTask = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkReminder = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.tbSummary = new System.Windows.Forms.TextBox();
            this.tbSubmitted = new System.Windows.Forms.TextBox();
            this.tbOwner = new System.Windows.Forms.TextBox();
            this.dtpReminderDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.tbCompletePercentage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbModified = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbTimeSpent = new System.Windows.Forms.TextBox();
            this.dtpComplete = new System.Windows.Forms.DateTimePicker();
            this.chkLocked = new System.Windows.Forms.CheckBox();
            this.dupStatus = new System.Windows.Forms.DomainUpDown();
            this.dupPriority = new System.Windows.Forms.DomainUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtbResolution = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rtbProperties = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbStateName = new System.Windows.Forms.TextBox();
            this.tbWorkflowName = new System.Windows.Forms.TextBox();
            this.tbNextStates = new System.Windows.Forms.TextBox();
            this.tbPrevStates = new System.Windows.Forms.TextBox();
            this.tbWorkflowInstanceID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbCategory1 = new System.Windows.Forms.TextBox();
            this.tbCheckOutBy = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbCheckOutTime = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbAssignment = new System.Windows.Forms.TextBox();
            this.btnAssignToMySelf = new System.Windows.Forms.Button();
            this.btnMarkComplete = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.cbUnread = new System.Windows.Forms.CheckBox();
            this.btnRevokeTask = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtTaskId,
            this.toolStripButtonSave,
            this.toolStripButtonDelete,
            this.toolStripButtonPrint,
            this.toolStripButtonStartTask});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(794, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtTaskId
            // 
            this.txtTaskId.Image = global::Sys.Workflow.Properties.Resources.application_view_list;
            this.txtTaskId.Name = "txtTaskId";
            this.txtTaskId.Size = new System.Drawing.Size(54, 22);
            this.txtTaskId.Text = "Task#";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = global::Sys.Workflow.Properties.Resources.DeleteHS;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonDelete.Text = "Delete";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
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
            // toolStripButtonStartTask
            // 
            this.toolStripButtonStartTask.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonStartTask.Image = global::Sys.Workflow.Properties.Resources.DataContainer_MoveNextHS;
            this.toolStripButtonStartTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartTask.Name = "toolStripButtonStartTask";
            this.toolStripButtonStartTask.Size = new System.Drawing.Size(78, 22);
            this.toolStripButtonStartTask.Text = "Start Task";
            this.toolStripButtonStartTask.Click += new System.EventHandler(this.toolStripButtonStartTask_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Summary:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Submitted:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Start date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Due date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Status:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(211, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Priority:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(528, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "%Complete:";
            // 
            // chkReminder
            // 
            this.chkReminder.AutoSize = true;
            this.chkReminder.Location = new System.Drawing.Point(16, 192);
            this.chkReminder.Name = "chkReminder";
            this.chkReminder.Size = new System.Drawing.Size(74, 17);
            this.chkReminder.TabIndex = 2;
            this.chkReminder.Text = "Reminder:";
            this.chkReminder.UseVisualStyleBackColor = true;
            this.chkReminder.CheckedChanged += new System.EventHandler(this.chkReminder_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(466, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Owner:";
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(72, 26);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.ReadOnly = true;
            this.tbFrom.Size = new System.Drawing.Size(375, 20);
            this.tbFrom.TabIndex = 3;
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(72, 51);
            this.tbTo.Name = "tbTo";
            this.tbTo.ReadOnly = true;
            this.tbTo.Size = new System.Drawing.Size(375, 20);
            this.tbTo.TabIndex = 3;
            // 
            // tbSummary
            // 
            this.tbSummary.Location = new System.Drawing.Point(72, 78);
            this.tbSummary.Name = "tbSummary";
            this.tbSummary.Size = new System.Drawing.Size(375, 20);
            this.tbSummary.TabIndex = 3;
            // 
            // tbSubmitted
            // 
            this.tbSubmitted.Location = new System.Drawing.Point(525, 23);
            this.tbSubmitted.Name = "tbSubmitted";
            this.tbSubmitted.ReadOnly = true;
            this.tbSubmitted.Size = new System.Drawing.Size(153, 20);
            this.tbSubmitted.TabIndex = 3;
            // 
            // tbOwner
            // 
            this.tbOwner.Location = new System.Drawing.Point(525, 107);
            this.tbOwner.Name = "tbOwner";
            this.tbOwner.ReadOnly = true;
            this.tbOwner.Size = new System.Drawing.Size(153, 20);
            this.tbOwner.TabIndex = 3;
            // 
            // dtpReminderDate
            // 
            this.dtpReminderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReminderDate.Location = new System.Drawing.Point(85, 189);
            this.dtpReminderDate.Name = "dtpReminderDate";
            this.dtpReminderDate.Size = new System.Drawing.Size(104, 20);
            this.dtpReminderDate.TabIndex = 4;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(85, 140);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(104, 20);
            this.dtpStartDate.TabIndex = 4;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(85, 163);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(104, 20);
            this.dtpDueDate.TabIndex = 4;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDescription.Location = new System.Drawing.Point(3, 3);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(780, 189);
            this.rtbDescription.TabIndex = 5;
            this.rtbDescription.Text = "";
            // 
            // tbCompletePercentage
            // 
            this.tbCompletePercentage.Location = new System.Drawing.Point(590, 169);
            this.tbCompletePercentage.Name = "tbCompletePercentage";
            this.tbCompletePercentage.Size = new System.Drawing.Size(88, 20);
            this.tbCompletePercentage.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(466, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Modified:";
            // 
            // tbModified
            // 
            this.tbModified.Location = new System.Drawing.Point(525, 47);
            this.tbModified.Name = "tbModified";
            this.tbModified.ReadOnly = true;
            this.tbModified.Size = new System.Drawing.Size(153, 20);
            this.tbModified.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(354, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Complete:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(546, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Hours:";
            // 
            // tbTimeSpent
            // 
            this.tbTimeSpent.Location = new System.Drawing.Point(590, 141);
            this.tbTimeSpent.Name = "tbTimeSpent";
            this.tbTimeSpent.Size = new System.Drawing.Size(88, 20);
            this.tbTimeSpent.TabIndex = 3;
            // 
            // dtpComplete
            // 
            this.dtpComplete.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpComplete.Location = new System.Drawing.Point(412, 166);
            this.dtpComplete.Name = "dtpComplete";
            this.dtpComplete.Size = new System.Drawing.Size(104, 20);
            this.dtpComplete.TabIndex = 4;
            // 
            // chkLocked
            // 
            this.chkLocked.AutoSize = true;
            this.chkLocked.Location = new System.Drawing.Point(14, 251);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(79, 17);
            this.chkLocked.TabIndex = 2;
            this.chkLocked.Text = "Locked by:";
            this.chkLocked.UseVisualStyleBackColor = true;
            // 
            // dupStatus
            // 
            this.dupStatus.Location = new System.Drawing.Point(259, 142);
            this.dupStatus.Name = "dupStatus";
            this.dupStatus.Size = new System.Drawing.Size(85, 20);
            this.dupStatus.TabIndex = 6;
            // 
            // dupPriority
            // 
            this.dupPriority.Location = new System.Drawing.Point(258, 166);
            this.dupPriority.Name = "dupPriority";
            this.dupPriority.Size = new System.Drawing.Size(86, 20);
            this.dupPriority.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 276);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 221);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtbDescription);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(786, 195);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Description";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtbResolution);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(786, 195);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Resolution";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtbResolution
            // 
            this.rtbResolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbResolution.Location = new System.Drawing.Point(3, 3);
            this.rtbResolution.Name = "rtbResolution";
            this.rtbResolution.Size = new System.Drawing.Size(780, 189);
            this.rtbResolution.TabIndex = 0;
            this.rtbResolution.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rtbProperties);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(786, 195);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Properties";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rtbProperties
            // 
            this.rtbProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbProperties.Location = new System.Drawing.Point(3, 3);
            this.rtbProperties.Name = "rtbProperties";
            this.rtbProperties.Size = new System.Drawing.Size(780, 189);
            this.rtbProperties.TabIndex = 0;
            this.rtbProperties.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.tbStateName);
            this.tabPage4.Controls.Add(this.tbWorkflowName);
            this.tabPage4.Controls.Add(this.tbNextStates);
            this.tabPage4.Controls.Add(this.tbPrevStates);
            this.tabPage4.Controls.Add(this.tbWorkflowInstanceID);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(786, 195);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Workflow";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(79, 72);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "State:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(65, 46);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "Workflow:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(331, 39);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 13);
            this.label23.TabIndex = 1;
            this.label23.Text = "Next States:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(312, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "Previous States:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Workflow Instance ID:";
            // 
            // tbStateName
            // 
            this.tbStateName.Location = new System.Drawing.Point(127, 69);
            this.tbStateName.Name = "tbStateName";
            this.tbStateName.ReadOnly = true;
            this.tbStateName.Size = new System.Drawing.Size(153, 20);
            this.tbStateName.TabIndex = 3;
            // 
            // tbWorkflowName
            // 
            this.tbWorkflowName.Location = new System.Drawing.Point(127, 43);
            this.tbWorkflowName.Name = "tbWorkflowName";
            this.tbWorkflowName.ReadOnly = true;
            this.tbWorkflowName.Size = new System.Drawing.Size(153, 20);
            this.tbWorkflowName.TabIndex = 3;
            // 
            // tbNextStates
            // 
            this.tbNextStates.Location = new System.Drawing.Point(402, 36);
            this.tbNextStates.Name = "tbNextStates";
            this.tbNextStates.ReadOnly = true;
            this.tbNextStates.Size = new System.Drawing.Size(196, 20);
            this.tbNextStates.TabIndex = 3;
            // 
            // tbPrevStates
            // 
            this.tbPrevStates.Location = new System.Drawing.Point(402, 10);
            this.tbPrevStates.Name = "tbPrevStates";
            this.tbPrevStates.ReadOnly = true;
            this.tbPrevStates.Size = new System.Drawing.Size(196, 20);
            this.tbPrevStates.TabIndex = 3;
            // 
            // tbWorkflowInstanceID
            // 
            this.tbWorkflowInstanceID.Location = new System.Drawing.Point(127, 14);
            this.tbWorkflowInstanceID.Name = "tbWorkflowInstanceID";
            this.tbWorkflowInstanceID.ReadOnly = true;
            this.tbWorkflowInstanceID.Size = new System.Drawing.Size(153, 20);
            this.tbWorkflowInstanceID.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(466, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Company:";
            // 
            // tbCompany
            // 
            this.tbCompany.Location = new System.Drawing.Point(525, 75);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.ReadOnly = true;
            this.tbCompany.Size = new System.Drawing.Size(153, 20);
            this.tbCompany.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Category:";
            // 
            // tbCategory1
            // 
            this.tbCategory1.Location = new System.Drawing.Point(75, 110);
            this.tbCategory1.Name = "tbCategory1";
            this.tbCategory1.ReadOnly = true;
            this.tbCategory1.Size = new System.Drawing.Size(372, 20);
            this.tbCategory1.TabIndex = 3;
            // 
            // tbCheckOutBy
            // 
            this.tbCheckOutBy.Location = new System.Drawing.Point(86, 249);
            this.tbCheckOutBy.Name = "tbCheckOutBy";
            this.tbCheckOutBy.ReadOnly = true;
            this.tbCheckOutBy.Size = new System.Drawing.Size(244, 20);
            this.tbCheckOutBy.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(336, 251);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "at";
            // 
            // tbCheckOutTime
            // 
            this.tbCheckOutTime.Location = new System.Drawing.Point(362, 247);
            this.tbCheckOutTime.Name = "tbCheckOutTime";
            this.tbCheckOutTime.ReadOnly = true;
            this.tbCheckOutTime.Size = new System.Drawing.Size(153, 20);
            this.tbCheckOutTime.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 224);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Assignment:";
            // 
            // tbAssignment
            // 
            this.tbAssignment.Location = new System.Drawing.Point(85, 221);
            this.tbAssignment.Name = "tbAssignment";
            this.tbAssignment.ReadOnly = true;
            this.tbAssignment.Size = new System.Drawing.Size(430, 20);
            this.tbAssignment.TabIndex = 3;
            // 
            // btnAssignToMySelf
            // 
            this.btnAssignToMySelf.Location = new System.Drawing.Point(525, 218);
            this.btnAssignToMySelf.Name = "btnAssignToMySelf";
            this.btnAssignToMySelf.Size = new System.Drawing.Size(153, 23);
            this.btnAssignToMySelf.TabIndex = 8;
            this.btnAssignToMySelf.Text = "Assign task to myself";
            this.btnAssignToMySelf.UseVisualStyleBackColor = true;
            this.btnAssignToMySelf.Click += new System.EventHandler(this.btnAssignToMySelf_Click);
            // 
            // btnMarkComplete
            // 
            this.btnMarkComplete.Location = new System.Drawing.Point(525, 192);
            this.btnMarkComplete.Name = "btnMarkComplete";
            this.btnMarkComplete.Size = new System.Drawing.Size(153, 23);
            this.btnMarkComplete.TabIndex = 9;
            this.btnMarkComplete.Text = "Mark Complete";
            this.btnMarkComplete.UseVisualStyleBackColor = true;
            this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(375, 146);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "From:";
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorkDate.Location = new System.Drawing.Point(412, 142);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(104, 20);
            this.dtpWorkDate.TabIndex = 4;
            // 
            // cbUnread
            // 
            this.cbUnread.AutoSize = true;
            this.cbUnread.Location = new System.Drawing.Point(525, 250);
            this.cbUnread.Name = "cbUnread";
            this.cbUnread.Size = new System.Drawing.Size(61, 17);
            this.cbUnread.TabIndex = 2;
            this.cbUnread.Text = "Unread";
            this.cbUnread.UseVisualStyleBackColor = true;
            this.cbUnread.CheckedChanged += new System.EventHandler(this.cbUnread_CheckedChanged);
            // 
            // btnRevokeTask
            // 
            this.btnRevokeTask.Location = new System.Drawing.Point(581, 247);
            this.btnRevokeTask.Name = "btnRevokeTask";
            this.btnRevokeTask.Size = new System.Drawing.Size(97, 23);
            this.btnRevokeTask.TabIndex = 10;
            this.btnRevokeTask.Text = "Revoke task";
            this.btnRevokeTask.UseVisualStyleBackColor = true;
            this.btnRevokeTask.Click += new System.EventHandler(this.btnRevokeTask_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 497);
            this.Controls.Add(this.btnRevokeTask);
            this.Controls.Add(this.btnMarkComplete);
            this.Controls.Add(this.btnAssignToMySelf);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dupPriority);
            this.Controls.Add(this.dupStatus);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpWorkDate);
            this.Controls.Add(this.dtpComplete);
            this.Controls.Add(this.dtpReminderDate);
            this.Controls.Add(this.tbTimeSpent);
            this.Controls.Add(this.tbCompletePercentage);
            this.Controls.Add(this.tbOwner);
            this.Controls.Add(this.tbCategory1);
            this.Controls.Add(this.tbCheckOutBy);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.tbCheckOutTime);
            this.Controls.Add(this.tbModified);
            this.Controls.Add(this.tbSubmitted);
            this.Controls.Add(this.tbSummary);
            this.Controls.Add(this.tbAssignment);
            this.Controls.Add(this.tbTo);
            this.Controls.Add(this.tbFrom);
            this.Controls.Add(this.cbUnread);
            this.Controls.Add(this.chkLocked);
            this.Controls.Add(this.chkReminder);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TaskForm";
            this.Text = "Task";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TaskForm_FormClosed);
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkReminder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.TextBox tbSummary;
        private System.Windows.Forms.TextBox tbSubmitted;
        private System.Windows.Forms.TextBox tbOwner;
        private System.Windows.Forms.DateTimePicker dtpReminderDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrint;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.TextBox tbCompletePercentage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbModified;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbTimeSpent;
        private System.Windows.Forms.DateTimePicker dtpComplete;
        private System.Windows.Forms.CheckBox chkLocked;
        private System.Windows.Forms.DomainUpDown dupStatus;
        private System.Windows.Forms.DomainUpDown dupPriority;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbResolution;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbCategory1;
        private System.Windows.Forms.TextBox tbCheckOutBy;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbCheckOutTime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbAssignment;
        private System.Windows.Forms.Button btnAssignToMySelf;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartTask;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnMarkComplete;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.RichTextBox rtbProperties;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbStateName;
        private System.Windows.Forms.TextBox tbWorkflowName;
        private System.Windows.Forms.TextBox tbWorkflowInstanceID;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbNextStates;
        private System.Windows.Forms.TextBox tbPrevStates;
        private System.Windows.Forms.CheckBox cbUnread;
        private System.Windows.Forms.ToolStripLabel txtTaskId;
        private System.Windows.Forms.Button btnRevokeTask;
    }
}
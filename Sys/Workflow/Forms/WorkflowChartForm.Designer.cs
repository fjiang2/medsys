namespace Sys.Workflow.Forms
{
    partial class WorkflowChartForm
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
            this.workflowChartControl1 = new WorkflowChartControl();
            this.chkShowArgument = new System.Windows.Forms.CheckBox();
            this.chkShowValues = new System.Windows.Forms.CheckBox();
            this.chkShowLegend = new System.Windows.Forms.CheckBox();
            this.dupMeasureUnit = new System.Windows.Forms.DomainUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkColorEach = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(891, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // workflowChartControl1
            // 
            this.workflowChartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.workflowChartControl1.Location = new System.Drawing.Point(0, 25);
            this.workflowChartControl1.Name = "workflowChartControl1";
            this.workflowChartControl1.ReadOnly = false;
            this.workflowChartControl1.Size = new System.Drawing.Size(786, 540);
            this.workflowChartControl1.TabIndex = 2;
            // 
            // chkShowArgument
            // 
            this.chkShowArgument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowArgument.AutoSize = true;
            this.chkShowArgument.Checked = true;
            this.chkShowArgument.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowArgument.Location = new System.Drawing.Point(797, 43);
            this.chkShowArgument.Name = "chkShowArgument";
            this.chkShowArgument.Size = new System.Drawing.Size(82, 17);
            this.chkShowArgument.TabIndex = 3;
            this.chkShowArgument.Text = "Show Label";
            this.chkShowArgument.UseVisualStyleBackColor = true;
            this.chkShowArgument.CheckedChanged += new System.EventHandler(this.chkShowValues_CheckedChanged);
            // 
            // chkShowValues
            // 
            this.chkShowValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowValues.AutoSize = true;
            this.chkShowValues.Checked = true;
            this.chkShowValues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowValues.Location = new System.Drawing.Point(797, 67);
            this.chkShowValues.Name = "chkShowValues";
            this.chkShowValues.Size = new System.Drawing.Size(88, 17);
            this.chkShowValues.TabIndex = 4;
            this.chkShowValues.Text = "Show Values";
            this.chkShowValues.UseVisualStyleBackColor = true;
            this.chkShowValues.CheckedChanged += new System.EventHandler(this.chkShowValues_CheckedChanged);
            // 
            // chkShowLegend
            // 
            this.chkShowLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowLegend.AutoSize = true;
            this.chkShowLegend.Checked = true;
            this.chkShowLegend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowLegend.Location = new System.Drawing.Point(797, 90);
            this.chkShowLegend.Name = "chkShowLegend";
            this.chkShowLegend.Size = new System.Drawing.Size(92, 17);
            this.chkShowLegend.TabIndex = 4;
            this.chkShowLegend.Text = "Show Legend";
            this.chkShowLegend.UseVisualStyleBackColor = true;
            this.chkShowLegend.CheckedChanged += new System.EventHandler(this.chkShowLegend_CheckedChanged);
            // 
            // dupMeasureUnit
            // 
            this.dupMeasureUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dupMeasureUnit.Location = new System.Drawing.Point(797, 144);
            this.dupMeasureUnit.Name = "dupMeasureUnit";
            this.dupMeasureUnit.Size = new System.Drawing.Size(92, 20);
            this.dupMeasureUnit.TabIndex = 5;
            this.dupMeasureUnit.SelectedItemChanged += new System.EventHandler(this.dupMeasureUnit_SelectedItemChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(797, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Unit:";
            // 
            // chkColorEach
            // 
            this.chkColorEach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkColorEach.AutoSize = true;
            this.chkColorEach.Location = new System.Drawing.Point(800, 190);
            this.chkColorEach.Name = "chkColorEach";
            this.chkColorEach.Size = new System.Drawing.Size(78, 17);
            this.chkColorEach.TabIndex = 7;
            this.chkColorEach.Text = "Color Each";
            this.chkColorEach.UseVisualStyleBackColor = true;
            this.chkColorEach.CheckedChanged += new System.EventHandler(this.chkColorEach_CheckedChanged);
            // 
            // WorkflowChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 565);
            this.Controls.Add(this.chkColorEach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dupMeasureUnit);
            this.Controls.Add(this.chkShowLegend);
            this.Controls.Add(this.chkShowValues);
            this.Controls.Add(this.chkShowArgument);
            this.Controls.Add(this.workflowChartControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WorkflowChartForm";
            this.Text = "Workflow Chart";
            this.Load += new System.EventHandler(this.WorkflowChartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private WorkflowChartControl workflowChartControl1;
        private System.Windows.Forms.CheckBox chkShowArgument;
        private System.Windows.Forms.CheckBox chkShowValues;
        private System.Windows.Forms.CheckBox chkShowLegend;
        private System.Windows.Forms.DomainUpDown dupMeasureUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkColorEach;
    }
}
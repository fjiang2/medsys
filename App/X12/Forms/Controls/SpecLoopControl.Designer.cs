namespace X12.Forms
{
    partial class SpecLoopControl
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtRepeatMax = new System.Windows.Forms.MaskedTextBox();
            this.txtRepeatMin = new System.Windows.Forms.MaskedTextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtLoop = new System.Windows.Forms.TextBox();
            this.chkRequired = new System.Windows.Forms.CheckBox();
            this.txtSequence = new System.Windows.Forms.TextBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtRepeatMax);
            this.layoutControl1.Controls.Add(this.txtRepeatMin);
            this.layoutControl1.Controls.Add(this.txtDescription);
            this.layoutControl1.Controls.Add(this.txtLoop);
            this.layoutControl1.Controls.Add(this.chkRequired);
            this.layoutControl1.Controls.Add(this.txtSequence);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(633, 409);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtRepeatMax
            // 
            this.txtRepeatMax.Location = new System.Drawing.Point(244, 347);
            this.txtRepeatMax.Name = "txtRepeatMax";
            this.txtRepeatMax.Size = new System.Drawing.Size(377, 50);
            this.txtRepeatMax.TabIndex = 11;
            // 
            // txtRepeatMin
            // 
            this.txtRepeatMin.Location = new System.Drawing.Point(76, 347);
            this.txtRepeatMin.Name = "txtRepeatMin";
            this.txtRepeatMin.Size = new System.Drawing.Size(100, 50);
            this.txtRepeatMin.TabIndex = 10;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(76, 36);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(545, 307);
            this.txtDescription.TabIndex = 9;
            // 
            // txtLoop
            // 
            this.txtLoop.Location = new System.Drawing.Point(76, 12);
            this.txtLoop.Name = "txtLoop";
            this.txtLoop.Size = new System.Drawing.Size(238, 20);
            this.txtLoop.TabIndex = 5;
            // 
            // chkRequired
            // 
            this.chkRequired.Location = new System.Drawing.Point(318, 12);
            this.chkRequired.Name = "chkRequired";
            this.chkRequired.Size = new System.Drawing.Size(150, 20);
            this.chkRequired.TabIndex = 8;
            this.chkRequired.Text = "Requried";
            this.chkRequired.UseVisualStyleBackColor = true;
            // 
            // txtSequence
            // 
            this.txtSequence.Location = new System.Drawing.Point(536, 12);
            this.txtSequence.Name = "txtSequence";
            this.txtSequence.Size = new System.Drawing.Size(85, 20);
            this.txtSequence.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(633, 409);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtLoop;
            this.layoutControlItem2.CustomizationFormText = "Loop Name";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(306, 24);
            this.layoutControlItem2.Text = "Loop Name";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtDescription;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(613, 311);
            this.layoutControlItem6.Text = "Description";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.chkRequired;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(306, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(154, 24);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtSequence;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(460, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(153, 24);
            this.layoutControlItem4.Text = "Sequence";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtRepeatMin;
            this.layoutControlItem1.CustomizationFormText = "Repeat from";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 335);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(168, 54);
            this.layoutControlItem1.Text = "Repeat from";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtRepeatMax;
            this.layoutControlItem3.CustomizationFormText = "to";
            this.layoutControlItem3.Location = new System.Drawing.Point(168, 335);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(445, 54);
            this.layoutControlItem3.Text = "to";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 13);
            // 
            // SpecLoopControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "SpecLoopControl";
            this.Size = new System.Drawing.Size(633, 409);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.MaskedTextBox txtRepeatMax;
        private System.Windows.Forms.MaskedTextBox txtRepeatMin;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtLoop;
        private System.Windows.Forms.CheckBox chkRequired;
        private System.Windows.Forms.TextBox txtSequence;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}

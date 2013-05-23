namespace X12.Forms
{
    partial class SpecSegment1Control
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
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.txtSegmentName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSyntax = new System.Windows.Forms.TextBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtNotes);
            this.layoutControl1.Controls.Add(this.txtPurpose);
            this.layoutControl1.Controls.Add(this.txtSegmentName);
            this.layoutControl1.Controls.Add(this.txtDescription);
            this.layoutControl1.Controls.Add(this.txtSyntax);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(671, 504);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(71, 84);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(588, 211);
            this.txtNotes.TabIndex = 13;
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(71, 60);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(588, 20);
            this.txtPurpose.TabIndex = 8;
            // 
            // txtSegmentName
            // 
            this.txtSegmentName.Location = new System.Drawing.Point(71, 12);
            this.txtSegmentName.Name = "txtSegmentName";
            this.txtSegmentName.ReadOnly = true;
            this.txtSegmentName.Size = new System.Drawing.Size(588, 20);
            this.txtSegmentName.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(71, 36);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(588, 20);
            this.txtDescription.TabIndex = 6;
            // 
            // txtSyntax
            // 
            this.txtSyntax.Location = new System.Drawing.Point(71, 299);
            this.txtSyntax.Multiline = true;
            this.txtSyntax.Name = "txtSyntax";
            this.txtSyntax.Size = new System.Drawing.Size(588, 193);
            this.txtSyntax.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem10,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(671, 504);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtSegmentName;
            this.layoutControlItem4.CustomizationFormText = "Segment";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(651, 24);
            this.layoutControlItem4.Text = "Segment";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDescription;
            this.layoutControlItem3.CustomizationFormText = "X12 Name";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(651, 24);
            this.layoutControlItem3.Text = "Description";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPurpose;
            this.layoutControlItem5.CustomizationFormText = "X12 Purpose";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(651, 24);
            this.layoutControlItem5.Text = "Purpose";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtNotes;
            this.layoutControlItem10.CustomizationFormText = "X12  Notes";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(651, 215);
            this.layoutControlItem10.Text = "Notes";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(55, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtSyntax;
            this.layoutControlItem2.CustomizationFormText = "X12 Syntax";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 287);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(651, 197);
            this.layoutControlItem2.Text = "X12 Syntax";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 13);
            // 
            // X12Segment1Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "X12Segment1Control";
            this.Size = new System.Drawing.Size(671, 504);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.TextBox txtSegmentName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSyntax;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
    }
}

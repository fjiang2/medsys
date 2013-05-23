namespace X12.Forms
{
    partial class SpecMaintenance
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
            X12.Specification.ElementInstanceDpo dataElement21 = new X12.Specification.ElementInstanceDpo();
            X12.DpoClass.X12ElementTemplateDpo x12Element1Dpo1 = new X12.DpoClass.X12ElementTemplateDpo();
            X12.DpoClass.X12SegmentInstanceDpo x12Segment2Dpo1 = new X12.DpoClass.X12SegmentInstanceDpo();
            X12.DpoClass.X12LoopTemplateDpo x12LoopDpo1 = new X12.DpoClass.X12LoopTemplateDpo();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.x12Element2Control1 = new X12.Forms.SpecElement2Control();
            this.x12Element1Control1 = new X12.Forms.SpecElement1Control();
            this.x12Segment2Control1 = new X12.Forms.SpecSegment2Control();
            this.x12LoopControl1 = new X12.Forms.SpecLoopControl();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabControl1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.tabDataElement = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabLoop = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciLoop = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabSegment = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSegment = new DevExpress.XtraLayout.LayoutControlItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabDataElement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLoop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLoop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSegment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSegment)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(932, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = global::X12.Properties.Resources.saveHS;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.x12Element2Control1);
            this.layoutControl1.Controls.Add(this.x12Element1Control1);
            this.layoutControl1.Controls.Add(this.x12Segment2Control1);
            this.layoutControl1.Controls.Add(this.x12LoopControl1);
            this.layoutControl1.Controls.Add(this.treeView1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 25);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(932, 317, 319, 438);
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(932, 576);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // x12Element2Control1
            // 
            dataElement21.DefaultValueUsed = false;
            dataElement21.InsertIdentityOn = false;
            dataElement21.PersistentString = "null";
            dataElement21.ValName = null;
            dataElement21.ValScope = null;
            this.x12Element2Control1.Dpo = dataElement21;
            this.x12Element2Control1.Location = new System.Drawing.Point(408, 250);
            this.x12Element2Control1.Name = "x12Element2Control1";
            this.x12Element2Control1.Size = new System.Drawing.Size(500, 302);
            this.x12Element2Control1.TabIndex = 15;
            // 
            // x12Element1Control1
            // 
            x12Element1Dpo1.DefaultValueUsed = false;
            x12Element1Dpo1.InsertIdentityOn = false;
            x12Element1Dpo1.PersistentString = "{\r\n}";
            x12Element1Dpo1.ValName = null;
            x12Element1Dpo1.ValScope = null;
            this.x12Element1Control1.Dpo = x12Element1Dpo1;
            this.x12Element1Control1.Location = new System.Drawing.Point(408, 46);
            this.x12Element1Control1.Name = "x12Element1Control1";
            this.x12Element1Control1.Size = new System.Drawing.Size(500, 184);
            this.x12Element1Control1.TabIndex = 14;
            // 
            // x12Segment2Control1
            // 
            x12Segment2Dpo1.DefaultValueUsed = false;
            x12Segment2Dpo1.InsertIdentityOn = false;
            x12Segment2Dpo1.PersistentString = "{\r\n}";
            x12Segment2Dpo1.ValName = null;
            x12Segment2Dpo1.ValScope = null;
            this.x12Segment2Control1.Dpo = x12Segment2Dpo1;
            this.x12Segment2Control1.Location = new System.Drawing.Point(408, 46);
            this.x12Segment2Control1.Name = "x12Segment2Control1";
            this.x12Segment2Control1.ParentControl = null;
            this.x12Segment2Control1.Size = new System.Drawing.Size(500, 506);
            this.x12Segment2Control1.TabIndex = 13;
            this.x12Segment2Control1.WorkMode = Sys.ViewManager.Forms.WorkMode.Working;
            // 
            // x12LoopControl1
            // 
            x12LoopDpo1.DefaultValueUsed = false;
            x12LoopDpo1.InsertIdentityOn = false;
            x12LoopDpo1.PersistentString = "{\r\n}";
            x12LoopDpo1.ValName = null;
            x12LoopDpo1.ValScope = null;
            this.x12LoopControl1.Dpo = x12LoopDpo1;
            this.x12LoopControl1.Location = new System.Drawing.Point(408, 46);
            this.x12LoopControl1.Name = "x12LoopControl1";
            this.x12LoopControl1.ParentControl = null;
            this.x12LoopControl1.Size = new System.Drawing.Size(500, 506);
            this.x12LoopControl1.TabIndex = 12;
            this.x12LoopControl1.WorkMode = Sys.ViewManager.Forms.WorkMode.Working;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 28);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(380, 536);
            this.treeView1.TabIndex = 10;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.tabControl1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(932, 576);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.treeView1;
            this.layoutControlItem6.CustomizationFormText = "5010A Specification";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(384, 556);
            this.layoutControlItem6.Text = "5010A Specification";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(94, 13);
            // 
            // tabControl1
            // 
            this.tabControl1.CustomizationFormText = "tabbedControlGroup1";
            this.tabControl1.Location = new System.Drawing.Point(384, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabPage = this.tabDataElement;
            this.tabControl1.SelectedTabPageIndex = 2;
            this.tabControl1.Size = new System.Drawing.Size(528, 556);
            this.tabControl1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabLoop,
            this.tabSegment,
            this.tabDataElement});
            this.tabControl1.Text = "tabControl1";
            // 
            // tabDataElement
            // 
            this.tabDataElement.CustomizationFormText = "Data Element";
            this.tabDataElement.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.tabDataElement.Location = new System.Drawing.Point(0, 0);
            this.tabDataElement.Name = "tabDataElement";
            this.tabDataElement.Size = new System.Drawing.Size(504, 510);
            this.tabDataElement.Text = "Data Element";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.x12Element1Control1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(504, 188);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.x12Element2Control1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 188);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(504, 322);
            this.layoutControlItem2.Text = "Element Detail";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(94, 13);
            // 
            // tabLoop
            // 
            this.tabLoop.CustomizationFormText = "layoutControlGroup2";
            this.tabLoop.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciLoop});
            this.tabLoop.Location = new System.Drawing.Point(0, 0);
            this.tabLoop.Name = "tabLoop";
            this.tabLoop.Size = new System.Drawing.Size(504, 510);
            this.tabLoop.Text = "Loop";
            // 
            // lciLoop
            // 
            this.lciLoop.Control = this.x12LoopControl1;
            this.lciLoop.CustomizationFormText = "layoutControlItem2";
            this.lciLoop.Location = new System.Drawing.Point(0, 0);
            this.lciLoop.Name = "lciLoop";
            this.lciLoop.Size = new System.Drawing.Size(504, 510);
            this.lciLoop.Text = "Loop Specification";
            this.lciLoop.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciLoop.TextSize = new System.Drawing.Size(0, 0);
            this.lciLoop.TextToControlDistance = 0;
            this.lciLoop.TextVisible = false;
            // 
            // tabSegment
            // 
            this.tabSegment.CustomizationFormText = "layoutControlGroup3";
            this.tabSegment.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSegment});
            this.tabSegment.Location = new System.Drawing.Point(0, 0);
            this.tabSegment.Name = "tabSegment";
            this.tabSegment.Size = new System.Drawing.Size(504, 510);
            this.tabSegment.Text = "Segment";
            // 
            // lciSegment
            // 
            this.lciSegment.Control = this.x12Segment2Control1;
            this.lciSegment.CustomizationFormText = "layoutControlItem3";
            this.lciSegment.Location = new System.Drawing.Point(0, 0);
            this.lciSegment.Name = "lciSegment";
            this.lciSegment.Size = new System.Drawing.Size(504, 510);
            this.lciSegment.Text = "Segment Specification";
            this.lciSegment.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciSegment.TextSize = new System.Drawing.Size(0, 0);
            this.lciSegment.TextToControlDistance = 0;
            this.lciSegment.TextVisible = false;
            // 
            // SpecMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 601);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SpecMaintenance";
            this.Text = "X12 Segment Maintenance";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabDataElement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabLoop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLoop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSegment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSegment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.TreeView treeView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.TabbedControlGroup tabControl1;
        private DevExpress.XtraLayout.LayoutControlGroup tabLoop;
        private DevExpress.XtraLayout.LayoutControlItem lciLoop;
        private DevExpress.XtraLayout.LayoutControlGroup tabSegment;
        private DevExpress.XtraLayout.LayoutControlItem lciSegment;
        private DevExpress.XtraLayout.LayoutControlGroup tabDataElement;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private SpecLoopControl x12LoopControl1;
        private SpecSegment2Control x12Segment2Control1;
        private SpecElement1Control x12Element1Control1;
        private SpecElement2Control x12Element2Control1;
    }
}
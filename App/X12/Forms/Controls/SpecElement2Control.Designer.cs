namespace X12.Forms
{
    partial class SpecElement2Control
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgUsage = new DevExpress.XtraEditors.RadioGroup();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSituationalRule = new System.Windows.Forms.TextBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgUsage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.rgUsage);
            this.layoutControl1.Controls.Add(this.txtDescription);
            this.layoutControl1.Controls.Add(this.txtSituationalRule);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(494, 327);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 178);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(470, 137);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Code";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 92;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Definition";
            this.gridColumn2.FieldName = "Definition";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 360;
            // 
            // rgUsage
            // 
            this.rgUsage.Location = new System.Drawing.Point(12, 86);
            this.rgUsage.Name = "rgUsage";
            this.rgUsage.Size = new System.Drawing.Size(151, 72);
            this.rgUsage.StyleController = this.layoutControl1;
            this.rgUsage.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(90, 12);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(392, 54);
            this.txtDescription.TabIndex = 5;
            // 
            // txtSituationalRule
            // 
            this.txtSituationalRule.Location = new System.Drawing.Point(167, 86);
            this.txtSituationalRule.Multiline = true;
            this.txtSituationalRule.Name = "txtSituationalRule";
            this.txtSituationalRule.Size = new System.Drawing.Size(315, 72);
            this.txtSituationalRule.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(494, 327);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDescription;
            this.layoutControlItem2.CustomizationFormText = "Name";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(474, 58);
            this.layoutControlItem2.Text = "Name";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.rgUsage;
            this.layoutControlItem3.CustomizationFormText = "Usage";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 58);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(155, 92);
            this.layoutControlItem3.Text = "Usage";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtSituationalRule;
            this.layoutControlItem1.CustomizationFormText = "Situational Rule";
            this.layoutControlItem1.Location = new System.Drawing.Point(155, 58);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(319, 92);
            this.layoutControlItem1.Text = "Situational Rule";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.CustomizationFormText = "Code Definition";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 150);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(474, 157);
            this.layoutControlItem4.Text = "Code Definition";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(74, 13);
            // 
            // X12Element2Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "X12Element2Control";
            this.Size = new System.Drawing.Size(494, 327);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgUsage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.RadioGroup rgUsage;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSituationalRule;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}

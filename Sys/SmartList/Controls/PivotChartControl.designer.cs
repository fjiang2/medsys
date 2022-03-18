namespace Sys.SmartList
{
    partial class PivotChartControl
    {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel3 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ceShowRowGrandTotals = new DevExpress.XtraEditors.CheckEdit();
            this.ceShowColumnGrandTotals = new DevExpress.XtraEditors.CheckEdit();
            this.ceSelectionOnly = new DevExpress.XtraEditors.CheckEdit();
            this.ceChartDataVertical = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.checkShowPointLabels = new DevExpress.XtraEditors.CheckEdit();
            this.comboChartType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.paddingPanel = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceShowRowGrandTotals.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceShowColumnGrandTotals.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSelectionOnly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceChartDataVertical.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkShowPointLabels.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboChartType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ceShowRowGrandTotals);
            this.panelControl1.Controls.Add(this.ceShowColumnGrandTotals);
            this.panelControl1.Controls.Add(this.ceSelectionOnly);
            this.panelControl1.Controls.Add(this.ceChartDataVertical);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.checkShowPointLabels);
            this.panelControl1.Controls.Add(this.comboChartType);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(690, 62);
            this.panelControl1.TabIndex = 0;
            // 
            // ceShowRowGrandTotals
            // 
            this.ceShowRowGrandTotals.EditValue = true;
            this.ceShowRowGrandTotals.Location = new System.Drawing.Point(461, 37);
            this.ceShowRowGrandTotals.Name = "ceShowRowGrandTotals";
            this.ceShowRowGrandTotals.Properties.Caption = "Show Row Grand Totals";
            this.ceShowRowGrandTotals.Size = new System.Drawing.Size(180, 19);
            this.ceShowRowGrandTotals.TabIndex = 12;
            this.ceShowRowGrandTotals.CheckedChanged += new System.EventHandler(this.ceShowRowGrandTotals_CheckedChanged);
            // 
            // ceShowColumnGrandTotals
            // 
            this.ceShowColumnGrandTotals.Location = new System.Drawing.Point(461, 7);
            this.ceShowColumnGrandTotals.Name = "ceShowColumnGrandTotals";
            this.ceShowColumnGrandTotals.Properties.Caption = "Show Column Grand Totals";
            this.ceShowColumnGrandTotals.Size = new System.Drawing.Size(180, 19);
            this.ceShowColumnGrandTotals.TabIndex = 11;
            this.ceShowColumnGrandTotals.CheckedChanged += new System.EventHandler(this.ceShowColumnGrandTotals_CheckedChanged);
            // 
            // ceSelectionOnly
            // 
            this.ceSelectionOnly.EditValue = true;
            this.ceSelectionOnly.Location = new System.Drawing.Point(287, 36);
            this.ceSelectionOnly.Name = "ceSelectionOnly";
            this.ceSelectionOnly.Properties.Caption = "Chart Selection Only";
            this.ceSelectionOnly.Size = new System.Drawing.Size(180, 19);
            this.ceSelectionOnly.TabIndex = 9;
            this.ceSelectionOnly.CheckedChanged += new System.EventHandler(this.ceSelectionOnly_CheckedChanged);
            // 
            // ceChartDataVertical
            // 
            this.ceChartDataVertical.Location = new System.Drawing.Point(87, 37);
            this.ceChartDataVertical.Name = "ceChartDataVertical";
            this.ceChartDataVertical.Properties.Caption = "Generate Series From Columns";
            this.ceChartDataVertical.Size = new System.Drawing.Size(180, 19);
            this.ceChartDataVertical.TabIndex = 7;
            this.ceChartDataVertical.CheckedChanged += new System.EventHandler(this.ceChartDataVertical_CheckedChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Chart options:";
            // 
            // checkShowPointLabels
            // 
            this.checkShowPointLabels.Location = new System.Drawing.Point(287, 11);
            this.checkShowPointLabels.Name = "checkShowPointLabels";
            this.checkShowPointLabels.Properties.Caption = "Point Labels";
            this.checkShowPointLabels.Size = new System.Drawing.Size(90, 19);
            this.checkShowPointLabels.TabIndex = 4;
            this.checkShowPointLabels.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // comboChartType
            // 
            this.comboChartType.EditValue = "Line";
            this.comboChartType.Location = new System.Drawing.Point(89, 10);
            this.comboChartType.Name = "comboChartType";
            this.comboChartType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboChartType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboChartType.Size = new System.Drawing.Size(178, 20);
            this.comboChartType.TabIndex = 3;
            this.comboChartType.SelectedIndexChanged += new System.EventHandler(this.comboChartType_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Chart type:";
            // 
            // paddingPanel
            // 
            this.paddingPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.paddingPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.paddingPanel.Location = new System.Drawing.Point(0, 62);
            this.paddingPanel.Name = "paddingPanel";
            this.paddingPanel.Size = new System.Drawing.Size(690, 8);
            this.paddingPanel.TabIndex = 4;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 70);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.pivotGridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.chartControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(690, 400);
            this.splitContainerControl1.SplitterPosition = 176;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsChartDataSource.ProvideDataByColumns = false;
            this.pivotGridControl1.OptionsView.ShowFilterHeaders = true;
            this.pivotGridControl1.Size = new System.Drawing.Size(690, 218);
            this.pivotGridControl1.TabIndex = 2;
            // 
            // chartControl1
            // 
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.RuntimeHitTesting = false;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            pointSeriesLabel3.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            pointSeriesLabel3.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.SeriesTemplate.Label = pointSeriesLabel3;
            this.chartControl1.SeriesTemplate.View = lineSeriesView3;
            this.chartControl1.Size = new System.Drawing.Size(690, 176);
            this.chartControl1.TabIndex = 3;
            // 
            // PivotChartControl
            // 
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.paddingPanel);
            this.Controls.Add(this.panelControl1);
            this.Name = "PivotChartControl";
            this.Size = new System.Drawing.Size(690, 470);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceShowRowGrandTotals.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceShowColumnGrandTotals.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSelectionOnly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceChartDataVertical.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkShowPointLabels.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboChartType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddingPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.ComboBoxEdit comboChartType;
		private DevExpress.XtraEditors.CheckEdit checkShowPointLabels;
		private DevExpress.XtraEditors.PanelControl paddingPanel;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
		private DevExpress.XtraCharts.ChartControl chartControl1;
		private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit ceSelectionOnly;
        private DevExpress.XtraEditors.CheckEdit ceChartDataVertical;
		private DevExpress.XtraEditors.CheckEdit ceShowRowGrandTotals;
        private DevExpress.XtraEditors.CheckEdit ceShowColumnGrandTotals;
	}
}

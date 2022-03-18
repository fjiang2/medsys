namespace Sys.ViewManager.Forms
{
    partial class JGanttChart
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
            DevExpress.XtraCharts.GanttDiagram ganttDiagram1 = new DevExpress.XtraCharts.GanttDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.RangeBarSeriesLabel rangeBarSeriesLabel1 = new DevExpress.XtraCharts.RangeBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideGanttSeriesView sideBySideGanttSeriesView1 = new DevExpress.XtraCharts.SideBySideGanttSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.RangeBarSeriesLabel rangeBarSeriesLabel2 = new DevExpress.XtraCharts.RangeBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideGanttSeriesView sideBySideGanttSeriesView2 = new DevExpress.XtraCharts.SideBySideGanttSeriesView();
            DevExpress.XtraCharts.RangeBarSeriesLabel rangeBarSeriesLabel3 = new DevExpress.XtraCharts.RangeBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideGanttSeriesView sideBySideGanttSeriesView3 = new DevExpress.XtraCharts.SideBySideGanttSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ganttDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(rangeBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(rangeBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(rangeBarSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView3)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            ganttDiagram1.AxisX.GridLines.Visible = true;
            ganttDiagram1.AxisX.Interlaced = true;
            ganttDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            ganttDiagram1.AxisX.Range.SideMarginsEnabled = true;
            ganttDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            ganttDiagram1.AxisY.Label.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            ganttDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            ganttDiagram1.AxisY.Range.SideMarginsEnabled = true;
            ganttDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = ganttDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.EquallySpacedItems = false;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            series1.Label = rangeBarSeriesLabel1;
            series1.Name = "Planning";
            series1.ValueScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            series1.View = sideBySideGanttSeriesView1;
            series2.Label = rangeBarSeriesLabel2;
            series2.Name = "Production";
            series2.ValueScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            series2.View = sideBySideGanttSeriesView2;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartControl1.SeriesTemplate.Label = rangeBarSeriesLabel3;
            this.chartControl1.SeriesTemplate.View = sideBySideGanttSeriesView3;
            this.chartControl1.Size = new System.Drawing.Size(437, 430);
            this.chartControl1.TabIndex = 0;
            chartTitle1.Text = "Title";
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // JGanttChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl1);
            this.Name = "JGanttChart";
            this.Size = new System.Drawing.Size(437, 430);
            ((System.ComponentModel.ISupportInitialize)(ganttDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(rangeBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(rangeBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(rangeBarSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
    }
}

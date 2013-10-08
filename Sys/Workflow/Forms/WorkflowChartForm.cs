using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Sys.ViewManager.Forms;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Tie;
using Sys.Workflow.Collaborative.Protocols;
using Sys.ViewManager;

namespace Sys.Workflow.Forms
{
    public partial class WorkflowChartForm : BaseForm 
    {

        Series series0;
        public WorkflowChartForm(IWorkflowView workflowView)
            : this(workflowView, null)
        {
        }

        public WorkflowChartForm(IWorkflowView workflowView,  string[] stateNames)
            :this(workflowView,null,stateNames, ActivityPointType.None)
        { 
        }

        public WorkflowChartForm(IWorkflowView workflowView, WorkflowTracking workflowTracking, string[] stateNames, ActivityPointType pointType)
        {
            InitializeComponent();

            this.series0 = workflowChartControl1.Series0;

            this.Text = workflowView.Title;

            this.workflowChartControl1.WorkflowView(workflowView, stateNames);
            this.workflowChartControl1.Tracking(workflowTracking);
            this.workflowChartControl1.ActivityPointType = pointType;


            foreach (DateTimeMeasurementUnit ty in Enum.GetValues(typeof(DateTimeMeasurementUnit)))
            {
                if(ty!= DateTimeMeasurementUnit.Millisecond && ty!= DateTimeMeasurementUnit.Second) 
                    this.dupMeasureUnit.Items.Add(ty.ToString());
            }

            ((OverlappedGanttSeriesView)workflowChartControl1.Series0.View).ColorEach = false;

            RangeBarPointOptions pointOptions = (RangeBarPointOptions)series0.Label.PointOptions;
            pointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
        }

        private void WorkflowChartForm_Load(object sender, EventArgs e)
        {
            RangeBarPointOptions pointOptions = (RangeBarPointOptions)series0.Label.PointOptions;
            this.chkShowArgument.Checked = pointOptions.PointView == PointView.ArgumentAndValues || pointOptions.PointView == PointView.Argument;
            this.chkShowValues.Checked = pointOptions.PointView == PointView.ArgumentAndValues || pointOptions.PointView == PointView.Values;
            this.chkShowLegend.Checked = workflowChartControl1.ChartControl.Legend.Visible;

            this.chkShowLegend.Checked = workflowChartControl1.ChartControl.Legend.Visible;
            this.dupMeasureUnit.SelectedItem = workflowChartControl1.Diagram.AxisY.DateTimeMeasureUnit.ToString();

            this.chkColorEach.Checked = ((OverlappedGanttSeriesView)workflowChartControl1.Series0.View).ColorEach;
        }

        public WorkflowChartControl WorkflowChartControl { get { return this.workflowChartControl1; } }

        private void chkShowValues_CheckedChanged(object sender, EventArgs e)
        {
            RangeBarPointOptions pointOptions = (RangeBarPointOptions)series0.Label.PointOptions;
            RangeBarPointOptions legendPointOptions = (RangeBarPointOptions)series0.LegendPointOptions;
            RangeBarSeriesLabel seriesLabel = (RangeBarSeriesLabel)series0.Label;


            ((System.ComponentModel.ISupportInitialize)(workflowChartControl1.ChartControl)).BeginInit();
            
            seriesLabel.Visible = true;
            
            if (chkShowArgument.Checked && chkShowValues.Checked)
                pointOptions.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
            else if (chkShowArgument.Checked && !chkShowValues.Checked)
                pointOptions.PointView = DevExpress.XtraCharts.PointView.Argument;
            else if (!chkShowArgument.Checked && chkShowValues.Checked)
                pointOptions.PointView = DevExpress.XtraCharts.PointView.Values;
            else
                seriesLabel.Visible = false;

            ((System.ComponentModel.ISupportInitialize)(workflowChartControl1.ChartControl)).EndInit();
        }

        private void chkShowLegend_CheckedChanged(object sender, EventArgs e)
        {
            workflowChartControl1.ChartControl.Legend.Visible = chkShowLegend.Checked;
        }

        private void dupMeasureUnit_SelectedItemChanged(object sender, EventArgs e)
        {
            string name = (string)this.dupMeasureUnit.SelectedItem;

            if (name != null)
            {
                workflowChartControl1.Diagram.AxisY.DateTimeMeasureUnit =
                   (DateTimeMeasurementUnit)Enum.Parse(typeof(DateTimeMeasurementUnit), name);
            }
        }

        private void chkColorEach_CheckedChanged(object sender, EventArgs e)
        {
            ((OverlappedGanttSeriesView)workflowChartControl1.Series0.View).ColorEach = chkColorEach.Checked;
        }

    
    }
}

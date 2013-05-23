using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Tie;
using Sys.ViewManager;
using Sys.ViewManager.Forms;
using Sys.Workflow;
using Sys.ViewManager.DevEx;

namespace Sys.SmartList
{
    class WorkflowViewer : DataViewer
    {
        private Sys.Workflow.WorkflowChartControl workflowChartControl;

        private void InitializeComponent()
        {
            this.workflowChartControl = new Sys.Workflow.WorkflowChartControl();
            this.workflowChartControl.Dock = DockStyle.Fill;
        }

        public WorkflowViewer(Configuration item)
            : base(item)
        {
            InitializeComponent();
            this.viewControl = workflowChartControl;

            HostType.Register(typeof(System.Drawing.Color));
            HostType.Register(typeof(System.Convert));
            HostType.Register(typeof(DevExpress.XtraVerticalGrid.PropertyGridControl));
        }


        public override void InitializeViewLayout(VAL parameters)
        {
            if (Table0 == null)
                return;

            VirtualWorkflow workflow = new VirtualWorkflow(this.DataSet);
            string[] stateNames = null;
            this.workflowChartControl.WorkflowView(workflow, stateNames);
            this.workflowChartControl.Tracking(workflow.WorkflowTracking);

            customizedCode.Initialize();
            if (this.workflowChartControl.ActivityPointType == ActivityPointType.None)
                this.workflowChartControl.ActivityPointType = ActivityPointType.ActualTime;

            ContextMenuStrip contextMenuStrip = customizedCode.ContextMenu();
            if (contextMenuStrip != null)
            {
                workflowChartControl.ChartControl.ContextMenuStrip = contextMenuStrip;
            }
        }


        public override void DataPrintPreview()
        {
            if (!workflowChartControl.ChartControl.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting.v?.?.dll' is not found.", "Error");
                return;
            }

      

            string[] header = configuration.GetStringHeader();
            Printing print = new Printing(workflowChartControl.ChartControl, header, null);
            print.DataPrintPreview();
        }

        public override void DataPrint()
        {
            string[] header = configuration.GetStringHeader();
            Printing print = new Printing(workflowChartControl.ChartControl, header, null);
            print.DataPrint();
        }

    }
}

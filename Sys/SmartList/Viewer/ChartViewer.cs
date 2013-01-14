using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Tie;
using Sys.ViewManager;
using Sys.ViewManager.DevEx;
using Sys.ViewManager.Forms;

namespace Sys.SmartList
{
    class ChartViewer : DataViewer
    {
        private DevExpress.XtraCharts.ChartControl chartControl1 = new ChartControl();
        DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();

        private void InitializeComponent()
        {
            
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xyDiagram1)).BeginInit();

            xyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";

            this.chartControl1.Dock = DockStyle.Fill;
            //this.chartControl1.Diagram = xyDiagram1;

            ((System.ComponentModel.ISupportInitialize)(this.xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();


        }


        public ChartViewer(Configuration item)
            : base(item)
        {
            InitializeComponent();
            this.viewControl = chartControl1;

            HostType.Register(typeof(DevExpress.XtraCharts.ChartTitle).Assembly);
            HostType.Register(typeof(MarkerKind), true);

            HostType.Register(typeof(System.Drawing.Color));
            HostType.Register(typeof(System.Convert));
        }



        private void CreateSeries(DataSet dataSet)
        {
            int i = 0;
            foreach (DataTable table in dataSet.Tables)
            {
                DevExpress.XtraCharts.Series series1 = new Series("Name" + i, ViewType.Bar);
                series1.DataSource = table;
                series1.ArgumentDataMember = "Argument";
                series1.ValueDataMembers.AddRange("Value0","Value1"); 
                chartControl1.Series.Add(series1);
            }

            ChartTitle title = new DevExpress.XtraCharts.ChartTitle();
            title.Text = "Demo";
            chartControl1.Titles.Add(title);
            
        }




        public override void InitializeViewLayout(VAL parameters)
        {
            if (Table0 == null)
                return;

           // CreateSeries(base.DataSet);
            customizedCode.Initialize();

            ContextMenuStrip contextMenuStrip = customizedCode.ContextMenu();
            if (contextMenuStrip != null)
            {
                chartControl1.ContextMenuStrip = contextMenuStrip;
            }
        }


        public override void DataPrintPreview()
        {
            if (!chartControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting.v?.?.dll' is not found.", "Error");
                return;
            }

            DataTable dataTable = (DataTable)chartControl1.DataSource;
            //if (dataTable == null)
            //    return;


            string[] header = configuration.GetStringHeader();
            Printing print = new Printing(chartControl1, header, null);
            print.DataPrintPreview();
        }

        public override void DataPrint()
        {
            string[] header = configuration.GetStringHeader();
            Printing print = new Printing(chartControl1, header, null);
            print.DataPrint();
        }

    }
}

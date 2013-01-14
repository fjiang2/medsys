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
using Sys.Data;

namespace Sys.SmartList
{
    class GanttChartViewer : DataViewer
    {
        private DevExpress.XtraCharts.ChartControl ganttChartControl;
        private JGanttChart ganttChart;

        private void InitializeComponent()
        {
            this.ganttChart = new JGanttChart();
            this.ganttChartControl = ganttChart.ChartControl;
            this.ganttChart.Dock = DockStyle.Fill;
        }


        public GanttChartViewer(Configuration item)
            :base(item)
        {
            InitializeComponent();
            this.viewControl = ganttChart;

            //HostType.Register(typeof(DevExpress.XtraCharts.ChartControl).Assembly);
            HostType.Register(typeof(DevExpress.XtraCharts.ChartTitle).Assembly);
            //HostType.Register(new Type[] {
            //    typeof(DevExpress.XtraCharts.DateTimeFormat),
            //    typeof(DevExpress.XtraCharts.LegendAlignmentHorizontal),
            //    typeof(DevExpress.XtraCharts.LegendAlignmentVertical),
            //    typeof(DevExpress.XtraCharts.LegendDirection),
            //    typeof(DevExpress.XtraCharts.ChartTitle),

            //    typeof(DevExpress.XtraCharts.ConstantLine),
            //    typeof(DevExpress.XtraCharts.ConstantLineTitleAlignment),
            //    typeof(DevExpress.XtraCharts.GanttDiagram)
            //    });
            HostType.Register(typeof(MarkerKind),true);
    
            HostType.Register(typeof(System.Drawing.Color));
            HostType.Register(typeof(System.Convert));
        }

       
   
        private void CreateSeries(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                int seriesName = (int)dataRow["Series"];
                Series series1 = ganttChartControl.Series[seriesName];
                DateTime start = dataRow.IsNull<DateTime>("Start", DateTime.Now);
                DateTime stop = dataRow.IsNull<DateTime>("Stop", DateTime.Now);
                SeriesPoint sp = new SeriesPoint((string)dataRow["Task"], new DateTime[] { start, stop });
                sp.Tag = dataRow;
                series1.Points.Add(sp);
            }
        }

       
       

        public override void InitializeViewLayout(VAL parameters)
        {
            if (Table0 == null)
                return;

            customizedCode.Initialize();
            CreateSeries(Table0);

            ContextMenuStrip contextMenuStrip = customizedCode.ContextMenu();
            if (contextMenuStrip != null)
            {
                ganttChart.contextMenuStrip = contextMenuStrip;
            }
        }


         public override void DataPrintPreview()
         {
             if (!ganttChartControl.IsPrintingAvailable)
             {
                 MessageBox.Show("The 'DevExpress.XtraPrinting.v?.?.dll' is not found.", "Error");
                 return;
             }

             DataTable dataTable = (DataTable)ganttChartControl.DataSource;
             //if (dataTable == null)
             //    return;


             string[] header = configuration.GetStringHeader();
             Printing print = new Printing(ganttChartControl, header, null);
             print.DataPrintPreview(); 
         }

         public override void DataPrint()
         {
             string[] header = configuration.GetStringHeader();
             Printing print = new Printing(ganttChartControl, header, null);
             print.DataPrint();
         }

    }
}

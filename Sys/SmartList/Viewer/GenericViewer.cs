using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Tie;
using Sys.ViewManager;
using Sys.ViewManager.Forms;
using System.Drawing;

namespace Sys.SmartList
{
    class GenericViewer : DataViewer
    {
        Panel panel = new Panel();

        private void InitializeComponent()
        {
            this.panel.Dock = DockStyle.Fill;

        }


        public GenericViewer(Configuration item)
            : base(item)
        {
            InitializeComponent();
            this.viewControl = panel;

            HostType.AddReference(typeof(DevExpress.XtraCharts.ChartTitle).Assembly);
            HostType.AddReference(typeof(DevExpress.XtraCharts.ChartControl).Assembly);
            HostType.Register(typeof(MarkerKind), true);
            HostType.Register(typeof(System.Drawing.Color));
            HostType.Register(typeof(System.Convert));
            HostType.Register(typeof(DockStyle));  
        }




        public override void InitializeViewLayout(VAL parameters)
        {
            customizedCode.Initialize();

            ContextMenuStrip contextMenuStrip = customizedCode.ContextMenu();
            if (contextMenuStrip != null)
            {
                panel.ContextMenuStrip = contextMenuStrip;
            }
        }

        public override void DataPrintPreview()
        {
            if(!customizedCode.DataPrint())
                MessageBox.Show("Printing has not been supported yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
        }

        public override void DataPrint()
        {
            //string[] header = configuration.GetStringHeader();
            //Print print = new Print(chartControl1, header, null);
            //print.DataPrint();
        }

        //public Control AddGridControl(VAL exp)
        //{
        //    var gridControl1 = new DevExpress.XtraGrid.GridControl();
        //    gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;

        //    var gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
        //    gridControl1.ViewCollection.Add(gridView1);

        //    gridControl1.DataSource = Table0;
            
        //    gridView1.Columns.Clear();
        //    Grid.InitializeGridViewColumns(gridControl1, gridView1, Table0);

        //    ViewManager.Grid.GridViewSetting(gridView1);
            
        //    gridView1.ActiveFilterString = exp[1].Str;
        //    gridView1.ActiveFilterEnabled = true;
            
        //    return gridControl1;
        //}
    }
}

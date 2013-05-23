using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Customization;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using Tie;
using Sys.ViewManager;
using Sys.ViewManager.DevEx;

namespace Sys.SmartList
{
    class ReportViewer : DataViewer
    {
        private void InitializeComponent()
        {
            this.printControl1 = new DevExpress.XtraPrinting.Control.PrintControl();

            this.printControl1.BackColor = System.Drawing.Color.Empty;
            this.printControl1.ForeColor = System.Drawing.Color.Empty;
            this.printControl1.Dock = DockStyle.Fill;
            this.printControl1.IsMetric = false;
            this.printControl1.Location = new System.Drawing.Point(12, 154);
            this.printControl1.Name = "printControl1";
            this.printControl1.Size = new System.Drawing.Size(489, 345);
            this.printControl1.TabIndex = 2;
            this.printControl1.TooltipFont = new System.Drawing.Font("Tahoma", 8.25F);

        }


        private DevExpress.XtraPrinting.Control.PrintControl printControl1;
        XtraReport report = new XtraReport();

        public ReportViewer(Configuration item)
            :base(item)
        {
            InitializeComponent();

            HostType.Register(typeof(DevExpress.XtraReports.UI.XtraReport));

            this.viewControl = printControl1;
          
        }

        public XtraReport Report
        {
            get { return this.report; }
        }

        public override void InitializeViewLayout(VAL parameters)
        {
            if (Table0 == null)
                return;

            LoadReport(report);
            customizedCode.Initialize();

            // this.report.DataSource = this.DataSet;  //this statement is in SmartList configuration
            this.printControl1.PrintingSystem = this.report.PrintingSystem;
            this.report.CreateDocument(); 
        }


         public override void DataPrintPreview()
         {
             report.ShowPreviewDialog();
         }

         public override void DataPrint()
         {
             report.Print();
         }


         public void SaveReport(XtraReport report)
         {
             MemoryStream stream = new MemoryStream();
             report.SaveLayout(stream);
             this.configuration.RepxItem.Stream = stream;
         }

         public void LoadReport(XtraReport report)
         {
             MemoryStream stream = this.configuration.RepxItem.Stream;
             if(stream != null)
                 report.LoadLayout(stream);
         }
  

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
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
using Tie;
using Sys.ViewManager;
using Sys.ViewManager.DevEx;

namespace Sys.SmartList
{
    class PivotGridViewer : DataViewer
    {
        private void InitializeComponent()
        {
            this.pivotGridControl = new DevExpress.XtraPivotGrid.PivotGridControl();

            // 
            // 
            // pivotGridControl
            // 
            this.pivotGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.pivotGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl.Name = "pivotGridControl";
            this.pivotGridControl.Size = new System.Drawing.Size(669, 518);
            this.pivotGridControl.TabIndex = 9;

        }


        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl;
        

        public PivotGridViewer(Configuration item)
            :base(item)
        {
            InitializeComponent();

            HostType.Register(typeof(DevExpress.XtraPivotGrid.PivotGridControl));
            HostType.Register(typeof(DevExpress.XtraPivotGrid.PivotGridField));
            HostType.Register(typeof(DevExpress.XtraPivotGrid.PivotArea));
            HostType.Register(typeof(DevExpress.XtraPivotGrid.PivotGroupInterval));
            HostType.Register(typeof(DevExpress.Data.PivotGrid.PivotSummaryType));
            HostType.Register(typeof(DevExpress.Utils.FormatType));
            HostType.Register(typeof(DevExpress.Data.UnboundColumnType));

            this.viewControl = pivotGridControl;

            /// Pivot Grid Settings.
            Pivot.PivotGridSetting(this.pivotGridControl);
       
        }
        
        

        public override void InitializeViewLayout(VAL parameters)
        {
            if (Table0 == null)
                return;

             pivotGridControl.Fields.Clear();
            Pivot.InitializePivotGridColumns(pivotGridControl, Table0);

            customizedCode.Initialize();
        }


         public override void DataPrintPreview()
         {
             if (!pivotGridControl.IsPrintingAvailable)
             {
                 MessageBox.Show("The 'DevExpress.XtraPrinting.v?.?.dll' is not found.", "Error");
                 return;
             }

             DataTable dataTable = (DataTable)pivotGridControl.DataSource;
             if (dataTable == null)
                 return;


             string[] header = configuration.GetStringHeader();
             Printing print = new Printing(pivotGridControl, header, null);
             print.DataPrintPreview(); 
         }

         public override void DataPrint()
         {
             string[] header = configuration.GetStringHeader();
             Printing print = new Printing(pivotGridControl, header, null);
             print.DataPrint();
         }



         public void FirstDayOfWeek(DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventArgs e, string fieldName)
         {


             if (e.Field.FieldName != fieldName)
                 return;

             if (e.Field.Area != DevExpress.XtraPivotGrid.PivotArea.ColumnArea)
                 return;

             DevExpress.XtraPivotGrid.PivotDrillDownDataSource dataSource = e.CreateDrillDownDataSource();

             if (dataSource.RowCount == 0)
                 return;

             if (dataSource[0][e.Field] == null)
                 return;

             DateTime date = (DateTime)dataSource[0][e.Field.FieldName];
             int week = (int)e.Value;
             e.DisplayText = FirstDayOfWeek(date.Year, week).ToShortDateString();


         }


         public static DateTime FirstDayOfWeek(int year, int wknum)
         {
             DateTime foy = new DateTime(year, 1, 1);
             int offset = (int)System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)foy.DayOfWeek + 1;
             DateTime fdow = foy.AddDays(offset);
             System.Globalization.Calendar cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
             int frstwk = cal.GetWeekOfYear(foy, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
             if (frstwk <= 1)
                 wknum -= 1;
             DateTime result = fdow.AddDays(wknum * 7);
             return result;
         }

         public void pivotGrid_CustomSummary(object sender, DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventArgs e)
         {
             // this.InformationMessage = "HELLO........";

             if (e.DataField.Name != "pEfficiency")
                 return;

             decimal budget = 0M;
             decimal actual = 0M;

             // Get the record set corresponding to the current cell.
             DevExpress.XtraPivotGrid.PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
             // Iterate through the records
             for (int i = 0; i < ds.RowCount; i++)
             {
                 DevExpress.XtraPivotGrid.PivotDrillDownDataRow row = ds[i];
                 // Get the total sum.
                 budget += (decimal)row["Budget"];
                 actual += (decimal)row["Actual"];
             }

             if (actual != 0M)
             {
                 e.CustomValue = budget / actual;
             }
             else
             {
                 e.CustomValue = 0M;
             }

             //this.InformationMessage = "LOL........";
         }



    }
}

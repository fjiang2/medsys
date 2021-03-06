using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraCharts;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Collections;
using DevExpress.XtraPivotGrid;
using Sys.ViewManager;
using Sys.ViewManager.DevEx;

namespace Sys.SmartList 
{
	public partial class PivotChartControl : UserControl 
    {
        public PivotChartControl()
        {
			InitializeComponent();

            pivotGridControl1.OptionsChartDataSource.ProvideDataByColumns = ceChartDataVertical.Checked;
            pivotGridControl1.OptionsChartDataSource.SelectionOnly = ceSelectionOnly.Checked;
			pivotGridControl1.OptionsChartDataSource.ProvideColumnGrandTotals = ceShowColumnGrandTotals.Checked;
            pivotGridControl1.OptionsChartDataSource.ProvideRowGrandTotals = ceShowRowGrandTotals.Checked;

			ViewType[] restrictedTypes = new ViewType[] { 
                ViewType.PolarArea, 
                ViewType.PolarLine, 
                ViewType.SideBySideGantt,
				ViewType.SideBySideRangeBar, 
                ViewType.RangeBar, 
                ViewType.Gantt, 
                ViewType.PolarPoint, 
                ViewType.Stock, 
                ViewType.CandleStick,
				ViewType.Bubble
			};

			foreach(ViewType type in Enum.GetValues(typeof(ViewType))) 
            {
				if(Array.IndexOf<ViewType>(restrictedTypes, type) >= 0) 
                    continue;
				
                comboChartType.Properties.Items.Add(type);
			}
			comboChartType.SelectedItem = ViewType.Line;

			chartControl1.DataSource = pivotGridControl1;
			chartControl1.SeriesDataMember = "Series";
			chartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
			chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
            chartControl1.SeriesTemplate.LegendPointOptions.PointView = PointView.ArgumentAndValues;
		}

        public PivotGridControl PivotGridControl 
        { 
            get 
            {
                return this.pivotGridControl1; 
            } 
        }

        public ChartControl ChartControl
        {
            get
            {
                return this.chartControl1;
            }
        }


		public DataTable DataSource 
        {
            get
            {
                return (DataTable)pivotGridControl1.DataSource;
            }
            set
            {
                pivotGridControl1.Fields.Clear();
                pivotGridControl1.DataSource = value;
                pivotGridControl1.RefreshData();
                pivotGridControl1.BestFit();


                foreach (DataColumn c in value.Columns)
                {
                    DevExpress.XtraPivotGrid.PivotGridField f = new PivotGridField(c.Caption, DevExpress.XtraPivotGrid.PivotArea.FilterArea);
                    pivotGridControl1.Fields.Add(f);
                }


               // pivotGridControl1.Cells.MultiSelection.SetSelection(CreateSelectedPoints());
            }
		}

		private Point[] CreateSelectedPoints() 
        {
			Point[] points = new Point[pivotGridControl1.Cells.ColumnCount * 2];
			for(int i = 0; i < pivotGridControl1.Cells.ColumnCount; i++) 
            {
				points[i] = new Point(i, 0);
				points[i + pivotGridControl1.Cells.ColumnCount] = new Point(i, 2);
			}
			return points;
		}

        private void comboChartType_SelectedIndexChanged(object sender, EventArgs e) 
        {
			chartControl1.SeriesTemplate.ChangeView((ViewType)comboChartType.SelectedItem);
			if(chartControl1.Diagram is Diagram3D) 
            {
				Diagram3D diagram = (Diagram3D)chartControl1.Diagram;
				diagram.RuntimeRotation = true;
				diagram.RuntimeZooming = true;
				diagram.RuntimeScrolling = true;
			}
		}

		private void checkEdit1_CheckedChanged(object sender, EventArgs e) 
        {
			chartControl1.SeriesTemplate.Label.Visible = checkShowPointLabels.Checked;
		}

		private void ceChartDataVertical_CheckedChanged(object sender, EventArgs e) 
        {
		    pivotGridControl1.OptionsChartDataSource.ProvideDataByColumns = ceChartDataVertical.Checked;
		}

		private void ceSelectionOnly_CheckedChanged(object sender, EventArgs e) 
        {
			pivotGridControl1.OptionsChartDataSource.SelectionOnly = ceSelectionOnly.Checked;
		}

		private void ceShowColumnGrandTotals_CheckedChanged(object sender, EventArgs e) 
        {
			pivotGridControl1.OptionsChartDataSource.ProvideColumnGrandTotals = ceShowColumnGrandTotals.Checked;
		}

		private void ceShowRowGrandTotals_CheckedChanged(object sender, EventArgs e) 
        {
			pivotGridControl1.OptionsChartDataSource.ProvideRowGrandTotals = ceShowRowGrandTotals.Checked;
		}


        public void DataPrint(string[] header)
        {
            Printing printing = new Printing();
            printing.Header = header;
            printing.AddControl(this.pivotGridControl1);
            printing.AddControl(this.chartControl1);
            printing.DataPrintPreview(); 
        
        }
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
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
using DevExpress.XtraGrid.Views.BandedGrid;


namespace Sys.SmartList
{
    class BandedGridViewer : GridViewer
    {
    
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        //private JPivotTable2 pivotTable;
        
        public BandedGridViewer(Configuration item)
            : base(item)
        {
            this.bandedGridView1 = (BandedGridView)this.gridView1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
        }


        public override void InitializeViewLayout(VAL parameters)
        {
            if (Table0 == null)
                return;

            //DataTable0 = 
                customizedCode.ProcessDataSource(Table0);

            bandedColumns.Clear();
            bandedGridView1.Bands.Clear();
            bandedGridView1.OptionsView.ColumnAutoWidth = false;
            bandedGridView1.ActiveFilterString = "";
            gridControl.MainView = bandedGridView1;
            gridControl.DataSource = Table0;
            

            UserViewLayout = parameters;
            customizedCode.Initialize();
          

            bandedGridView1.DataController.RefreshData();
        }

        private List<string> bandedColumns = new List<string>();
        public void AddBand(string caption, string[] columnNames)
        {
            GridBand band = bandedGridView1.Bands.Add();
            band.Caption = caption;
            foreach (string columnName in columnNames)
            {
                BandedGridColumn column = new BandedGridColumn();
                DataColumn dataColumn = this.Table0.Columns[columnName]; 
                column.FieldName = dataColumn.ColumnName;
                column.Caption = dataColumn.Caption; 
                column.Visible = true;
                column.OptionsColumn.AllowEdit = false;
                band.Columns.Add(column);

                bandedColumns.Add(columnName);
            }
        }

        public void AddBand(VAL root)
        {
            GridBand band = bandedGridView1.Bands.Add();
            AddBand(band, root);
        }

        public void AddBand(GridBand band, VAL node)
        {
            //leaves
            VAL value = node["value"];
            VAL leaves = node["leaves"];
            
            band.Caption = value.Str;
            if (leaves.Defined)
            {

                for (int i = 0; i < leaves.Size; i++)
                {
                    VAL leaf = leaves[i];
                    string columnName = leaf["value"].Str;
                    VAL width = leaf["Width"];

                    BandedGridColumn column = new BandedGridColumn();
                    band.Columns.Add(column);
                    DataColumn dataColumn = this.Table0.Columns[columnName];
                    column.FieldName = dataColumn.ColumnName;
                    column.Caption = dataColumn.Caption;
                    column.Visible = true;
                    column.OptionsColumn.AllowEdit = false;
                    
                    //if(!width.IsNull)
                    //    column.Width = width.Intcon;
                    HostType.SetObjectProperties(column, leaf);
                    
                    //keep which data column has been in band already
                    bandedColumns.Add(columnName);
                }
                return;
            }



            //NODE
            VAL children = node["node"];
            for (int i = 0; i < children.Size; i++)
               AddBand(band.Children.Add(), children[i]);

       
        }

        //add rest of data columns into a Band
        public void AddRestBand(string caption)
        {
            GridBand band = bandedGridView1.Bands.Add();
            band.Caption = caption;
            foreach (DataColumn dataColumn in this.Table0.Columns)
            {
                if (bandedColumns.IndexOf(dataColumn.ColumnName) < 0)
                {
                    BandedGridColumn column = new BandedGridColumn();
                    column.FieldName = dataColumn.ColumnName;
                    column.Caption = dataColumn.Caption;
                    column.Visible = true;
                    column.OptionsColumn.AllowEdit = false;
                    band.Columns.Add(column);
                }
            }
        }

        public override VAL UserViewLayout
        {
            get
            {
                VAL v = new VAL();
                v["where"] = new VAL(bandedGridView1.ActiveFilter.Expression);

                VAL L = new VAL();
                foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in bandedGridView1.Columns)
                {
                    if (gridColumn.Visible)
                    {
                        L[gridColumn.FieldName] = new VAL(gridColumn.Width);
                    }
                }

                v["columns"] = L;
                return v;
            }
            
            set
            {
                if (value.Undefined)
                    return;

                VAL where = value["where"];
                if (where.Defined)
                {
                    bandedGridView1.ActiveFilterString = where.Str;
                    bandedGridView1.ActiveFilterEnabled = true;
                }


                VAL columns = value["columns"];
                if (columns.Defined)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in bandedGridView1.Columns)
                    {

                        gridColumn.Visible = false;
                        VAL column = columns[gridColumn.FieldName];

                        if (column.Undefined)
                            gridColumn.Visible = false;
                        else
                        {
                            gridColumn.Visible = true;
                            gridColumn.Width = column.Intcon;
                        }
                    }
                }

            }
        }
    }
}

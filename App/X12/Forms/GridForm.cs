using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Customization;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;


namespace X12.Forms
{
    public partial class GridForm : Form
    {
        public GridForm()
        {
            InitializeComponent();
        }

        public DataTable DataSource
        {
            set
            {
                gridView1.Columns.Clear();
                InitializeGridViewColumns(gridControl1, gridView1, value);
            }
        }


        public static void InitializeGridViewColumns(GridControl gridControl, GridView gridView1, DataTable dataTable)
        {
            gridControl.MainView = gridView1;
            gridView1.ActiveFilterString = "";

            gridControl.DataSource = dataTable;
            //this.gridControl.RefreshDataSource();
            gridView1.DataController.RefreshData();


            foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView1.Columns)
            {
                if (gridView1.DataRowCount < 200)
                    gridColumn.BestFit();

                if (!gridView1.OptionsBehavior.Editable)
                {
                    gridColumn.AppearanceCell.Options.UseTextOptions = true;
                    gridColumn.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;


                    DataColumn dataColumn = dataTable.Columns[gridColumn.FieldName];
                    if (dataColumn.DataType == typeof(string))
                    {
                        RepositoryItemMemoEdit repositoryItemMemoEdit1 = new RepositoryItemMemoEdit();
                        repositoryItemMemoEdit1.LinesCount = 0;
                        gridColumn.ColumnEdit = repositoryItemMemoEdit1;
                    }
                }
            }
        }

    }
}

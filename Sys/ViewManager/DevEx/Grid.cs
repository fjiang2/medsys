using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
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

namespace Sys.ViewManager.DevEx
{
    public class Grid
    {
        public static DataRow GetGridClickEx(DevExpress.XtraGrid.Views.Grid.GridView gridView, object sender)
        {
            GridHitInfo hi =
                gridView.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            try
            {
                if (hi.RowHandle >= 0)
                    return gridView.GetDataRow(hi.RowHandle);
                else if (gridView.FocusedRowHandle >= 0)
                    return null; //RowNotClicked
            }
            catch
            {
                return null;  //RowNotClicked
            }
            return null;
        }


       

        public static bool IsValidGridClick(string[] pArray)
        {
            if (pArray[0] == "RowNotClicked" || pArray[0] == null)
                return false;
            else
                return true;
        }



        public static DataSet GetViewableDataSet(DevExpress.XtraGrid.Views.Grid.GridView pGridView, DataSet pDataSet)
        {// Returns a clone of the passed in DataSet back
            DataSet ds = pDataSet.Clone();

            ArrayList dArray = new ArrayList();
            int nRowIndex = 0;
            int nRowHandle = pGridView.GetVisibleRowHandle(nRowIndex);

            while (nRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                dArray.Add(pGridView.GetDataRow(nRowHandle));
                nRowHandle = pGridView.GetNextVisibleRow(nRowIndex);
                nRowIndex++;
            }

            DataRow[] rowArray = new DataRow[dArray.Count];
            foreach (object x in dArray)
            {
                ds.Tables[0].ImportRow((DataRow)x);
            }
            return ds;
        }




        public static DataRow GetGridClickEx(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView, object sender)
        {
            DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitInfo hi =
                bandedGridView.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            try
            {
                if (hi.RowHandle >= 0)
                    return bandedGridView.GetDataRow(hi.RowHandle);
                else if (bandedGridView.FocusedRowHandle >= 0)
                    return null; //RowNotClicked
            }
            catch
            {
                return null;  //RowNotClicked
            }
            return null;
        }


    
        public static DataRow[] GetGridSelectedRows(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            int[] selectedRows = gridView.GetSelectedRows();
            DataRow[] rows = new DataRow[selectedRows.Length];

            int i = 0;
            foreach (int R in selectedRows)
            {
                DataRowView dataRowView = (System.Data.DataRowView)gridView.GetRow(R);
                if (dataRowView != null)
                    rows[i++] = dataRowView.Row;
            }

            return rows;
        }

        public static DataRowView[] GetGridSelectedRowViews(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            int[] selectedRows = gridView.GetSelectedRows();
            DataRowView[] rows = new DataRowView[selectedRows.Length];

            int i = 0;
            foreach (int R in selectedRows)
            {
                DataRowView dataRowView = (System.Data.DataRowView)gridView.GetRow(R);
                if (dataRowView != null)
                    rows[i++] = dataRowView;
            }

            return rows;
        }


        public static void GridViewSetting(DevExpress.XtraGrid.Views.Grid.GridView gridView1)
        {
            gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            gridView1.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            gridView1.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(190)))), ((int)(((byte)(243)))));
            gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            gridView1.Appearance.Empty.BackColor = System.Drawing.Color.White;
            gridView1.Appearance.Empty.Options.UseBackColor = true;
            gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            gridView1.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            gridView1.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            gridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            gridView1.Appearance.GroupButton.Options.UseForeColor = true;
            gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            gridView1.Appearance.GroupRow.Options.UseFont = true;
            gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            gridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.OddRow.Options.UseBackColor = true;
            gridView1.Appearance.OddRow.Options.UseForeColor = true;
            gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            gridView1.Appearance.Preview.Options.UseBackColor = true;
            gridView1.Appearance.Preview.Options.UseForeColor = true;
            gridView1.Appearance.Row.BackColor = System.Drawing.Color.White;
            gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            gridView1.Appearance.Row.Options.UseBackColor = true;
            gridView1.Appearance.Row.Options.UseForeColor = true;
            gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            gridView1.Appearance.VertLine.Options.UseBackColor = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
        }


        public static void SetGridEditable(DevExpress.XtraGrid.GridControl gridControl1, DevExpress.XtraGrid.Views.Grid.GridView gridView1)
        {
            gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            gridControl1.EmbeddedNavigator.Name = "";

            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }



        public static  void InitializeGridViewColumns(GridControl gridControl, GridView gridView1, DataTable dataTable)
        {
            gridControl.MainView = gridView1;
            gridView1.ActiveFilterString = "";

            gridControl.DataSource = dataTable;
            //gridView1.PopulateColumns();
            //this.gridControl.RefreshDataSource();
            gridView1.DataController.RefreshData();


            foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView1.Columns)
            {
                if (gridView1.DataRowCount < 200)
                    gridColumn.BestFit();

                DataColumn dataColumn = dataTable.Columns[gridColumn.FieldName];
                
                if (!gridView1.OptionsBehavior.Editable)
                {
                    gridColumn.AppearanceCell.Options.UseTextOptions = true;
                    gridColumn.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;


                    if (dataColumn.DataType == typeof(string))
                    {
                        RepositoryItemMemoEdit edit = new RepositoryItemMemoEdit();
                        edit.LinesCount = 0;
                        gridColumn.ColumnEdit = edit;
                    }
            
                }
                
                if (dataColumn.DataType == typeof(byte[]))
                {
                    RepositoryItemImageEdit edit = new RepositoryItemImageEdit();
                    gridColumn.ColumnEdit = edit;
                }

            }
        }


        public static void InitializeLayoutViewColumns(GridControl gridControl, LayoutView layoutView1, DataTable dataTable)
        {
            gridControl.MainView = layoutView1;
            layoutView1.ActiveFilterString = "";

            gridControl.DataSource = dataTable;
            layoutView1.DataController.RefreshData();

            foreach (LayoutViewColumn layoutViewColumn in layoutView1.Columns)
            {
                layoutViewColumn.Visible = true;
                layoutViewColumn.BestFit();

                DataColumn dataColumn = dataTable.Columns[layoutViewColumn.FieldName];
                if (dataColumn.DataType == typeof(string))
                {
                    RepositoryItemMemoEdit repositoryItemMemoEdit1 = new RepositoryItemMemoEdit();
                    repositoryItemMemoEdit1.LinesCount = 0;
                    layoutViewColumn.ColumnEdit = repositoryItemMemoEdit1;
                }

            }
        }


        public static void GridSaveAsExcel(DevExpress.XtraGrid.GridControl gridControl)
        {
            System.Windows.Forms.SaveFileDialog saveExportExcel;
            saveExportExcel = new System.Windows.Forms.SaveFileDialog();
            saveExportExcel.DefaultExt = "xls";
            saveExportExcel.FileName = "ExcelExport_" + DateTime.Today.Month + "_" + DateTime.Today.Day + "_" + DateTime.Today.Year;
            saveExportExcel.Filter = "Excel Files |*.xls";

            if (saveExportExcel.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                //DevExpress.XtraExport.IExportProvider provider = new DevExpress.XtraExport.ExportXlsProvider(saveExportExcel.FileName);
                //DevExpress.XtraGrid.Export.BaseExportLink link = gridControl.DefaultView.CreateExportLink(provider);
                //if (link != null)
                //{
                //    link.ExportCellsAsDisplayText = false;
                //    link.ExportTo(true);
                //}

                gridControl.DefaultView.ExportToXls(saveExportExcel.FileName);

                Cursor.Current = Cursors.Default;
            }
        }

   

        public static void GridSaveAsExcel(DevExpress.XtraGrid.GridControl gridControl, string excelName)
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.DefaultExt = "xls";
            dlg.FileName = excelName;
            dlg.Filter = "Excel Files |*.xls";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                gridControl.DefaultView.OptionsPrint.AllowCancelPrintExport = true;
                gridControl.DefaultView.OptionsPrint.ShowPrintExportProgress = true;
                gridControl.DefaultView.ExportToXls(dlg.FileName);
                Cursor.Current = Cursors.Default;
            }
        }

    }
}

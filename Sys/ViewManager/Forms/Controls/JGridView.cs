using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
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
using Sys.ViewManager;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Sys.Data;

namespace Sys.ViewManager.Forms
{


    public delegate void RowSelectedEventHandler(object sender, DataRowSelectedEventArgs e);

    public partial class JGridView : UserControl
    {
        private DataTable dataTable = null;
        private DataRow selectedDataRow = null;
        static DataRow[] clipboard = null;
        private ContextMenuStrip contextMenu = null;

        public bool ContextMenuEnabled = true;

        public event RowSelectedEventHandler RowMouseClick;
        public event RowSelectedEventHandler RowMouseDoubleClick;
        
        public JGridView()
        {
            InitializeComponent();
            DevEx.Grid.GridViewSetting(gridView1);
            DevEx.Grid.SetGridEditable(gridControl1, gridView1);
            AllowEdit = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridControl1.MouseClick += new MouseEventHandler(this.gridControl_Click);
            this.gridControl1.MouseDoubleClick += new MouseEventHandler(this.gridControl_DoubleClick);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gridView1_InvalidRowException);
            
        }

        void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            // Supress displaying error messagebox for row validation.
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        public bool AllowAddNew
        {

            set
            {                
                gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = value;
                gridControl1.EmbeddedNavigator.Buttons.Append.Visible = value;
                this.ContextMenuEnabled = value;
                if(value)
                   gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                else
                   gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
        }

        public bool AllowEdit
        {
            set
            {
                gridView1.OptionsBehavior.Editable = value;
                if (value==false)
                    AllowAddNew = false;
            }
        }

        public bool ReadOnly
        {
            get 
            {
                return !gridView1.OptionsBehavior.Editable;
            }
            set
            {
                gridView1.OptionsBehavior.Editable = !value;
                if (value == true)
                    AllowAddNew = false;
            }
        }


        public DevExpress.XtraGrid.GridControl GridControl
        {
            get
            {
                return gridControl1;
            }
        }

        public DevExpress.XtraGrid.Views.Grid.GridView GridView
        {
            get
            { 
                return gridView1; 
            }
        }

        public DataTable DataSource
        {
            get
            {
                return this.dataTable;
            }

            set
            {
                if (this.dataTable == null || IsTableStructureChanged(value))
                {
                    this.dataTable = value;

                    this.gridView1.Columns.Clear();
                    DevEx.Grid.InitializeGridViewColumns(gridControl1, gridView1, dataTable);
                }
                else
                {
                    this.dataTable.Clear();
                    this.dataTable.Merge(value);
                    this.dataTable.AcceptChanges();
                }
            }
        }

        public TableName TableName;

        /// <summary>
        /// Table Structure is changed?
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private bool IsTableStructureChanged(DataTable table)
        {
            if (this.dataTable.Columns.Count != table.Columns.Count)
                return true;

            foreach (DataColumn column in this.dataTable.Columns)
            {
                if (!table.Columns.Contains(column.ColumnName))
                    return true;
                
                if(table.Columns[column.ColumnName].DataType != column.DataType)
                    return true;
            }

            return false;
        }

        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                if (this.contextMenu == null)
                    return new ContextMenuStrip();
                else
                    return this.contextMenu;
            }
            set
            {
                this.contextMenu = value;
            }
        }


        public TableAdapter DataSave(TableName tableName)
        {
            return DataSave(tableName, null, null, null, null);
        }


        public TableAdapter DataSave(TableName tableName, string[] columnNames)
        {
            return DataSave(tableName, columnNames, null, null, null);
        }

        public TableAdapter DataSave(TableName tableName, string[] columnNames, Locator locator)
        {
            return DataSave(tableName, columnNames, locator, null, null);
        }

        public TableAdapter DataSave(TableName tableName, string[] columnNames, Locator locator, RowChangedHandler rowHandler, ValueChangedHandler columnHandler)
        {
            if (dataTable != null)
            {

                if (locator == null)
                {
                    locator = new Locator(tableName);
                }

                TableAdapter dt = new TableAdapter(this.dataTable, tableName, locator);
                
                if (rowHandler != null)
                    dt.DataRowChangedHandler += rowHandler;
                if (columnHandler != null)
                    dt.ValueChangedHandler = columnHandler;


                dt.AddFields(columnNames);
                dt.Save();

                return dt;
            }

            return null;
        }

        public DataRow[] SelectedRows
        {
            get
            {
                return DevEx.Grid.GetGridSelectedRows(gridView1);
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                if (this.selectedDataRow == null)
                {
                    if (dataTable != null && dataTable.Rows.Count > 0)  //return the first row
                        return dataTable.Rows[0];
                }

                return this.selectedDataRow;
            }
        }

        private ContextMenuStrip BuildEditContextMenu(DataRow dataRow, GridColumn gridColumn)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuEdit = new ToolStripMenuItem("Memo Edit");
            ToolStripMenuItem menuUndo = new ToolStripMenuItem("Undo");
            ToolStripMenuItem menuCut = new ToolStripMenuItem("Cut Rows");
            ToolStripMenuItem menuCopy = new ToolStripMenuItem("Copy Rows");
            ToolStripMenuItem menuPaste = new ToolStripMenuItem("Paste Rows");
            ToolStripMenuItem menuDelete = new ToolStripMenuItem("Delete Rows");
            contextMenuStrip.Items.Add(menuEdit);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            //contextMenuStrip.Items.Add(menuUndo);
            //contextMenuStrip.Items.Add(menuCut);
            contextMenuStrip.Items.Add(menuCopy);
            contextMenuStrip.Items.Add(menuPaste);
            contextMenuStrip.Items.Add(menuDelete);

            menuEdit.Image = global::Sys.ViewManager.Properties.Resources.EditTableHS;
            menuUndo.Image = global::Sys.ViewManager.Properties.Resources.Edit_UndoHS;
            menuCut.Image = global::Sys.ViewManager.Properties.Resources.CutHS;
            menuCopy.Image = global::Sys.ViewManager.Properties.Resources.CopyHS;
            menuPaste.Image = global::Sys.ViewManager.Properties.Resources.PasteHS;
            menuDelete.Image = global::Sys.ViewManager.Properties.Resources.DeleteHS;


            menuUndo.Enabled = true;
            menuCut.Enabled = SelectedRows.Length != 0;
            menuCopy.Enabled = menuCut.Enabled;
            menuPaste.Enabled = CanPaste;
            menuDelete.Enabled = menuCut.Enabled;
            

            //menuCut.ShortcutKeys = (Keys)Shortcut.CtrlX;
            //menuCopy.ShortcutKeys = (Keys)Shortcut.CtrlC;
            //menuPaste.ShortcutKeys = (Keys)Shortcut.CtrlV;

            EventHandler evenetHandler = delegate(object sender, EventArgs e)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                switch (menuItem.Text)
                {
                    case "Memo Edit":
                        if (gridColumn.ColumnEdit is RepositoryItemMemoEdit)
                        {
                            gridColumn.ColumnEdit = new RepositoryItemMemoExEdit();
                        }
                        else
                        {
                            gridColumn.ColumnEdit = new RepositoryItemMemoEdit();
                        }
                        break;

                    case "Undo":
                        break;

                    case "Cut Rows":
                        clipboard = SelectedRows;
                        break;

                    case "Copy Rows":
                        clipboard = SelectedRows;
                        break;

                    case "Paste Rows":
                        DataTablePaste(dataTable, clipboard);
                        gridView1.RefreshData();
                        break;

                    case "Delete Rows":
                        DataTableDelete(SelectedRows);
                        gridView1.RefreshData();
                        break;
                }

            };

            menuUndo.Click += evenetHandler;
            menuEdit.Click += evenetHandler;
            menuCut.Click += evenetHandler;
            menuCopy.Click += evenetHandler;
            menuPaste.Click += evenetHandler;
            menuDelete.Click += evenetHandler;

            return contextMenuStrip;
        }


        

        private void gridControl_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            DataRow dataRow = DevEx.Grid.GetGridClickEx(this.gridView1, sender);
            selectedDataRow = dataRow;

            GridHitInfo gridHitInfo = gridView1.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            if (gridHitInfo == null)
                return;

            GridColumn gridColumn = gridHitInfo.Column;
            //if (gridColumn == null)
            //    return;

            if(RowMouseClick != null)
                RowMouseClick(this, new DataRowSelectedEventArgs(dataRow, gridColumn));

            if (e.Button == MouseButtons.Right && gridView1.OptionsBehavior.Editable && ContextMenuEnabled)
            {
                contextMenu = BuildEditContextMenu(dataRow, gridColumn);
                //ContextMenuStrip contextMenuStrip = BuildEditContextMenu(dataRow, gridColumn);
                Point point = (sender as Control).PointToClient(Control.MousePosition);
                //contextMenuStrip.Show((Control)sender, point.X, point.Y);
                contextMenu.Show((Control)sender, point.X, point.Y);
            }
            return;

        }

        private void gridControl_DoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DataRow dataRow = DevEx.Grid.GetGridClickEx(this.gridView1, sender);
            if (dataRow == null)
                return;

            selectedDataRow = dataRow;
            
            GridHitInfo gridHitInfo = gridView1.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
            if (gridHitInfo == null)
                return;

            GridColumn gridColumn = gridHitInfo.Column;

            if(RowMouseDoubleClick != null)
                RowMouseDoubleClick(this, new DataRowSelectedEventArgs(dataRow, gridColumn));
        }



        private bool CanPaste
        {
            get
            {
                if (clipboard == null)
                    return false;

                if (clipboard.Length == 0)
                    return false;

                if (clipboard[0].Table.TableName != dataTable.TableName)
                    return false;

                return true;
            }
        }

        private bool DataTablePaste(DataTable dataTable, DataRow[] dataRows)
        {
            if (dataRows.Length == 0)
                return false;


            foreach (DataRow dataRow in dataRows)
            {
                if (dataTable.TableName != dataRow.Table.TableName)
                    continue;

                DataRow newRow = dataTable.NewRow();
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    newRow[dataColumn] = dataRow[dataColumn.ColumnName];
                }
                dataTable.Rows.Add(newRow);
            }

            //dataTable.AcceptChanges(); 
            return true;
        }

        
        private bool DataTableDelete(DataRow[] dataRows)
        {
            if (dataRows.Length == 0)
                return false;


            foreach (DataRow dataRow in dataRows)
            {
                dataRow.Delete();
                //dataRow.AcceptChanges();
            }

            
            return true;
        }


        public DataRowView FocusedRow
        {
            get
            {
                return
                     (DataRowView)gridView1.GetRow(gridView1.FocusedRowHandle);
            }
        }




        
        public void PrintPreview(string[] header)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting.v?.?.dll' is not found.", "Error");
                return;
            }

            DataTable dataTable = (DataTable)gridControl1.DataSource;
            if (dataTable == null)
            {
                MessageBox.Show(this, "There is no data to print.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            if (gridControl1.MainView != gridView1)
                return;

            if (gridView1.DataRowCount > 3000)
            {
                string message = string.Format(
                    "There is {0} Records.\r\nIt will take several minutes to process.\r\nClick OK to continue or click Cancel to return.",
                    gridView1.DataRowCount);
                
                if (MessageBox.Show(this, message, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    return;

            }

            DevEx.Printing printing = new DevEx.Printing(gridControl1);
            printing.Header = header;
            printing.DataPrintPreview();
        }

        public void PrintPrinting(string[] header)
        {
            DevEx.Printing printing = new DevEx.Printing(gridControl1);
            printing.Header = header;
            printing.DataPrint();
        }



        public void SetDataRowColor(string expression, Color BackColor, Color BackColor2, Color ForeColor)
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition.Appearance.BackColor = BackColor;
            styleFormatCondition.Appearance.BackColor2 = BackColor2;
            styleFormatCondition.Appearance.ForeColor = ForeColor;
            styleFormatCondition.Appearance.Options.UseBackColor = true;
            styleFormatCondition.ApplyToRow = true;
            styleFormatCondition.Expression = expression;
            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            gridView1.FormatConditions.Add(styleFormatCondition);           
        }       

        public void SetDataRowFont(string expression, Font font)
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition.Appearance.Font = font;
            styleFormatCondition.Appearance.Options.UseFont = true;
            styleFormatCondition.ApplyToRow = true;
            styleFormatCondition.Expression = expression;
            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            gridView1.FormatConditions.Add(styleFormatCondition);
        }




        public static JGridView Reinsert(Control.ControlCollection controls, JGridView jGridView1)
        {
            AnchorStyles anchor = jGridView1.Anchor;
            Point location = jGridView1.Location;
            Size size = jGridView1.Size;
            string name = jGridView1.Name;
            controls.Remove(jGridView1);
            
            jGridView1 = new Sys.ViewManager.Forms.JGridView();
            jGridView1.Location = location;
            jGridView1.Anchor = anchor;
            jGridView1.Size = size;
            jGridView1.Name = name;
            controls.Add(jGridView1);
            return jGridView1;
        }



    }


    public class DataRowSelectedEventArgs : EventArgs
    {
        private DataRow dataRow;
        private GridColumn gridColumn;

        public DataRowSelectedEventArgs(DataRow row, GridColumn gridColumn)
        {
            this.dataRow = row;
            this.gridColumn = gridColumn;
        }

        public DataRow Row { get { return this.dataRow; } }
        public GridColumn Column { get { return this.gridColumn; } }
    }


}

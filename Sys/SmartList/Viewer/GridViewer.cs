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
using Sys.ViewManager.DevEx;

namespace Sys.SmartList
{
    class GridViewer : DataViewer
    {
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridControl = new DevExpress.XtraGrid.GridControl();

            if (this.ViewMode == DataViewMode.BandedGrid)
                this.gridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            else
                this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();


            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;

            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(669, 518);
            this.gridControl.UseEmbeddedNavigator = true;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1
            });
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;


        }

        protected DevExpress.XtraGrid.GridControl gridControl;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public DataRow SelectedDataRow;
        public DataRowView SelectedDataRowView;


        public GridViewer(Configuration item)
            : base(item)
        {
            InitializeComponent();

            HostType.Register(typeof(System.Windows.Forms.ToolStripMenuItem));
            HostType.Register(typeof(System.Windows.Forms.ContextMenuStrip));
            HostType.Register(typeof(System.Convert));
            //HostType.Register(typeof(DevExpress.XtraGrid.Views.Grid.GridViewAppearances));

            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.viewControl = gridControl;

            Grid.GridViewSetting(this.gridView1);
            

            this.gridControl.DoubleClick += new System.EventHandler(this.gridControl_DoubleClick);
            this.gridControl.MouseClick += new MouseEventHandler(this.gridControl_Click);

        }


        private void gridControl_DoubleClick(object sender, System.EventArgs e)
        {
        }

        private void gridControl_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            //ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();

            //ToolStripMenuItem item = new ToolStripMenuItem("RED");
            //item.BackColor = Color.Red;
            //contextMenuStrip1.Items.Add(item);

            //item = new ToolStripMenuItem("BLUE");
            //item.BackColor = Color.Blue;
            //contextMenuStrip1.Items.Add(item);
            //contextMenuStrip1.Items.Add(new System.Windows.Forms.ToolStripSeparator());

            //item = new ToolStripMenuItem("Yellow");
            //contextMenuStrip1.Items.Add(item);
            //item.BackColor = Color.Yellow;

            //Point point1 = (sender as Control).PointToClient(Control.MousePosition);
            //contextMenuStrip1.Show((Control)sender, point1.X, point1.Y);
            //return;

            if (e.Button != MouseButtons.Right)
                return;

            DataRow dataRow = Grid.GetGridClickEx(this.gridView1, sender);
            DataRowView[] D = Grid.GetGridSelectedRowViews(this.gridView1);
            SelectedDataRow = dataRow;
            if (D.Length > 0)
                SelectedDataRowView = D[0];

            if (this.editMode)
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitInfo = gridView1.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
                if (gridHitInfo == null)
                    return;

                GridColumn gridColumn = gridHitInfo.Column;
                if (gridColumn == null)
                    return;

                ContextMenuStrip contextMenuStrip = BuildEditContextMenu(dataRow, gridColumn);
                Point point = (sender as Control).PointToClient(Control.MousePosition);
                contextMenuStrip.Show((Control)sender, point.X, point.Y);
                return;
            }



           // if (dataRow != null)
            {
                ContextMenuStrip contextMenuStrip = customizedCode.ContextMenu();
                if (contextMenuStrip != null)
                {
                    Point point = (sender as Control).PointToClient(Control.MousePosition);
                    contextMenuStrip.Show((Control)sender, point.X, point.Y);
                }
                return;
            }
        }

        private ContextMenuStrip BuildEditContextMenu(DataRow dataRow, GridColumn gridColumn)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem menuEdit = new ToolStripMenuItem("Memo Edit");
            ToolStripMenuItem menuCut = new ToolStripMenuItem("Cut Rows");
            ToolStripMenuItem menuCopy = new ToolStripMenuItem("Copy Rows");
            ToolStripMenuItem menuPaste = new ToolStripMenuItem("Paste Rows");
            contextMenuStrip.Items.Add(menuEdit);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add(menuCut);
            contextMenuStrip.Items.Add(menuCopy);
            contextMenuStrip.Items.Add(menuPaste);

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
                    case "Cut Mode":
                        break;
                    case "Copy Mode":
                        break;
                    case "Paste Mode":
                        break;
                }

            };

            menuEdit.Click += evenetHandler;
            menuCut.Click += evenetHandler;
            menuCopy.Click += evenetHandler;
            menuPaste.Click += evenetHandler;

            return contextMenuStrip;
        }


        public override void InitializeViewLayout(VAL parameters)
        {
            if (Table0 == null)
                return;

            //DataTable0 = 
            customizedCode.ProcessDataSource(Table0);

            this.gridView1.Columns.Clear();
            Grid.InitializeGridViewColumns(gridControl, gridView1, Table0);

            UserViewLayout = parameters;


           customizedCode.Initialize();
        }

        public DevExpress.XtraGrid.Views.Grid.GridOptionsView OptionsView 
        {
            get
            {
                return gridView1.OptionsView;
            }
        }

		public DevExpress.XtraGrid.Views.Grid.GridOptionsSelection OptionsSelection
		{
			get
			{
				return gridView1.OptionsSelection;
			}
		}

        public void SetDataRowBackColor(string expression, Color color)
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition.Appearance.BackColor = color;
            styleFormatCondition.Appearance.BackColor2 = color;
            styleFormatCondition.Appearance.Options.UseBackColor = true;
            styleFormatCondition.ApplyToRow = true;
            styleFormatCondition.Expression = expression;
            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            gridView1.FormatConditions.Add(styleFormatCondition);
        }

        public void SetDataRowColor(string expression, Color color)
        {
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition.Appearance.ForeColor = color;
            styleFormatCondition.Appearance.Options.UseForeColor = true;
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



        #region Printer
        public override void DataPrintPreview()
        {
            if (!gridControl.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting.v?.?.dll' is not found.", "Error");
                return;
            }

            DataTable dataTable = (DataTable)gridControl.DataSource;
            if (dataTable == null)
                return;

            if (gridControl.MainView != gridView1)
                return;

            if (gridView1.DataRowCount > 3000)
            {
                string message = string.Format("There is {0} Records.\r\nIt will take several minutes to process.\r\nClick OK to continue or click Cancel to return.",
                    gridView1.DataRowCount);
                if (MessageBox.Show(this.viewControl, message, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    return;

            }

            string[] header = configuration.GetStringHeader();
            Printing print = new Printing(gridControl, header, null);
            print.DataPrintPreview();

        }

        public override void DataPrint()
        {
            string[] header = configuration.GetStringHeader();
            Printing print = new Printing(gridControl, header, null);
            print.DataPrint();
        }

        #endregion


        protected override void SwitchViewEditMode(bool editMode)
        {
            if (editMode)
            {
                this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = true;
                this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = true;
                this.gridControl.EmbeddedNavigator.Buttons.Remove.Visible = true;
                this.gridControl.EmbeddedNavigator.Buttons.Append.Visible = true;
                this.gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = true;
                this.gridView1.OptionsSelection.MultiSelect = true;
            }
            else
            {
                this.gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                this.gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
                this.gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
                this.gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
                this.gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                this.gridView1.OptionsSelection.MultiSelect = false;
            }


            gridView1.OptionsBehavior.Editable = editMode;

            if (editMode)
            {
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            }


        }



        public override string ActivateView()
        {
            DataTable dataTable = (DataTable)gridControl.DataSource;
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            Grid.InitializeGridViewColumns(gridControl, gridView1, dataTable);

            gridControl.Focus();
            gridControl.MainView.LayoutChanged();
            Cursor.Current = currentCursor;
            return "Grid View";
        }

        public override VAL UserViewLayout
        {
            get
            {
                VAL v = new VAL();
                v["where"] = new VAL(gridView1.ActiveFilter.Expression);

                VAL L = new VAL();
                foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView1.Columns)
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
                    gridView1.ActiveFilterString = where.Str;
                    gridView1.ActiveFilterEnabled = true;
                }


                VAL columns = value["columns"];
                if (columns.Defined)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView1.Columns)
                    {

                        gridColumn.Visible = false;
                        VAL column = columns[gridColumn.FieldName];

                        if (!column.Defined)
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

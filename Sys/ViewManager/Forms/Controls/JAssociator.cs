using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data.Filtering;

namespace Sys.ViewManager.Forms
{
    public partial class JAssociator : UserControl
    {
        public event DataRowSelectedEventHandler SelectorChanged;
        public const string Flag = "[X]";

        public string WorkflowColumnName;
        public string S1ColumnName;
        public string S2ColumnName;

        public string S1Name;
        public string S2Name;

        private DataTable relation;
        private RepositoryItemCheckEdit checkEdit;

        public JAssociator()
        {
            InitializeComponent();

           // jSelector1.SplitContainer1.Panel1.Width = 200; 
            
            
            //gridView2.GridView.OptionsBehavior.Editable = false;
            this.checkEdit = new RepositoryItemCheckEdit();


            gridView1.RowMouseClick += new DataRowSelectedEventHandler(gridView1_MouseClick);
            gridView2.RowMouseClick += new DataRowSelectedEventHandler(gridView2_MouseClick);
            checkEdit.CheckedChanged += new EventHandler(checkEdit_CheckedChanged);  

        }



        void checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit checkEdit = (DevExpress.XtraEditors.CheckEdit)sender;

            if (gridView1.SelectedRow == null)
                return;

            DataRow row1 = gridView1.SelectedRow;
            DataRow row2 = gridView2.FocusedRow.Row;

            object key1 = row1[S1ColumnName];
            object key2 = row2[S2ColumnName];

            if (checkEdit.Checked)
            { 
                if(key1.Equals(key2))
                {
                    MessageBox.Show("cannot add a link to itself", "Warning");
                    checkEdit.Checked = false;
                    return;
                }
                else
                {
                    DataRow newRow = this.relation.NewRow();
                    newRow[S1Name] = key2;      //right hand grid is S1
                    newRow[S2Name] = key1;      //left hand grid is S2
                    newRow[WorkflowColumnName] = row1[WorkflowColumnName];
                    this.relation.Rows.Add(newRow);
                }
            }
            else
            {
                foreach (DataRow row in relation.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (row[S1Name].Equals(key2) && row[S2Name].Equals(key1))
                        {
                            row.AcceptChanges();    //mark sure new transition is in the DataTable:relation
                            row.Delete();
                            break;
                        }
                    }
                }

            }
            
            if (SelectorChanged != null)
                SelectorChanged(sender, new DataRowSelectedEventArgs(row2, gridView2.GridView.Columns[JAssociator.Flag]));
        }


        public bool AllowAddNew
        {
            set
            {
                gridView1.AllowAddNew = value;
                gridView2.AllowAddNew = value;
            }
        }


        /// <summary>
        /// Define 3 Tables
        ///     0. Left Grid 
        ///     1. Relation
        ///     2. Right Grid
        /// </summary>
        public virtual DataTable[] DataSource
        {
            set
            {
                gridView1.DataSource = value[0];
                this.relation = (DataTable)value[1];

                DataColumn dataColumn = value[2].Columns.Add(Flag, typeof(bool));
                gridView2.DataSource = value[2];
                gridView2.GridView.Columns[JAssociator.Flag].VisibleIndex = 0;
                gridView2.GridView.Columns[JAssociator.Flag].ColumnEdit = checkEdit;

                if (gridView1.DataSource.Rows.Count > 0)
                {
                    SelectS1Row(gridView1.DataSource.Rows[0]);
                }
            }
        }



        public JGridView GridView1
        {
            get
            {
                return this.gridView1;
            }
        }

        public JGridView GridView2
        {
            get
            {
                return this.gridView2;
            }
        }

        public JGridView[] GridView
        {
            get
            {
                return new JGridView[] { this.gridView1, this.gridView2 };
            }
        }

        public DataView GetFilteredData()
        {
            return GetFilteredData((GridView)gridView1.GridControl.MainView); 
        }

        public DataView GetFilteredData(ColumnView view)
        {
            if (view == null) return null;
            if (view.ActiveFilter == null || !view.ActiveFilterEnabled
                || view.ActiveFilter.Expression == "")
                return view.DataSource as DataView;

            DataTable table = ((DataView)view.DataSource).Table;
            DataView filteredDataView = new DataView(table);
            //filteredDataView.RowFilter = view.ActiveFilterCriteria.LegacyToString();
            filteredDataView.RowFilter = CriteriaToWhereClauseHelper.GetDataSetWhere(view.ActiveFilterCriteria);

            return filteredDataView;
        }



        private void SelectS1Row(DataRow dataRow)
        {
            object key1 = dataRow[S1ColumnName];

            foreach (DataRow row2 in gridView2.DataSource.Rows)
            {
                row2[Flag] = false;
            }

            relation.DefaultView.Sort = S2Name;
            DataRowView[] rows = relation.DefaultView.FindRows(key1);
            foreach (DataRow row2 in gridView2.DataSource.Rows)
            {
                foreach (DataRowView row in rows)
                {
                    if (row2[S2ColumnName].Equals(row[S1Name]))
                    {
                        row2[Flag] = true;
                        break;
                    }
                    else
                        row2[Flag] = false;
                }
            }
        }

        void gridView1_MouseClick(object sender, DataRowSelectedEventArgs e)
        {
            DataRow dataRow = e.Row;
            if (dataRow == null)
                return;

            SelectS1Row(dataRow);
            

        }

   

        void gridView2_MouseClick(object sender, DataRowSelectedEventArgs e)
        {
            DataRow dataRow = e.Row;
            if (dataRow == null)
                return;

            GridColumn gridColumn = e.Column;
            if (gridColumn == null)
                return;

            if (gridColumn.FieldName == JAssociator.Flag)
            {
            
            }
        }

    }
}

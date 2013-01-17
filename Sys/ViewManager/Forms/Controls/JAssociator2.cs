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
using System.Linq;

namespace Sys.ViewManager.Forms
{
    public partial class JAssociator2 : UserControl
    {
        public event RowSelectedEventHandler SelectorChanged;
        public const string Flag = "[X]";

        public string WorkflowColumnName;
        public string S1ColumnName;
        public string S2ColumnName;

        public string S1Name;
        public string S2Name;

        private DataTable relation;
        private RepositoryItemCheckEdit checkEdit;

        public JAssociator2()
        {
            InitializeComponent();

           // jSelector1.SplitContainer1.Panel1.Width = 200; 
            
            
            //gridView2.GridView.OptionsBehavior.Editable = false;
            this.checkEdit = new RepositoryItemCheckEdit();


            gridView1.RowMouseClick += new RowSelectedEventHandler(gridView1_MouseClick);
            gridView2.RowMouseClick += new RowSelectedEventHandler(gridView2_MouseClick);
            checkEdit.CheckedChanged += new EventHandler(checkEdit_CheckedChanged);  

        }



        void checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit checkEdit = (DevExpress.XtraEditors.CheckEdit)sender;

            if (gridView1.SelectedRow == null || gridView2.FocusedRow == null)
                return;

            DataRow[] rows1 = gridView1.SelectedRows;
            DataRow row2 = gridView2.FocusedRow.Row;

            this.Cursor = Cursors.WaitCursor;
            foreach (DataRow row1 in rows1)
            {
                if (checkEdit.Checked)
                {
                    if (!AddTransition(row1, row2))
                    {
                        MessageBox.Show(string.Format("cannot add a link to itself, {0} --> {1}",row1[S1ColumnName], row2[S2ColumnName]), "Warning");
                        checkEdit.Checked = false;
                        
                        this.Cursor = Cursors.Default;
                        return;
                    }
                }
                else
                    DeleteTransition(row1, row2);
            }
            this.Cursor = Cursors.Default;

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



      


        void gridView1_MouseClick(object sender, DataRowSelectedEventArgs e)
        {
            DataRow dataRow = e.Row;
            if (dataRow == null)
                return;

            this.Cursor = Cursors.WaitCursor;

            DataRow[] rows = gridView1.SelectedRows;
            if (rows.Length == 1)
            {
                SelectS1Row(dataRow);
            }
            else
            {
                SelectS1Row(rows);
            }

            this.Cursor = Cursors.Default;
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

        private bool ExistsTransition(object key1, object key2)
        {
            relation.DefaultView.Sort = S1Name;
            DataRowView[] S2 = relation.DefaultView.FindRows(key1);

            foreach (DataRowView row in S2)
            {
                if (row[S2Name].Equals(key2))
                    return true;
            }

            //foreach (DataRow rel in relation.Rows)
            //    if (rel.RowState != DataRowState.Deleted && rel[S1Name].Equals(key1) && rel[S2Name].Equals(key2))
            //        return true;

            return false;
        }


        private bool AddTransition(DataRow row1, DataRow row2)
        {
            object key1 = row1[S1ColumnName];
            object key2 = row2[S2ColumnName];

            if (key1.Equals(key2))
            {
                //MessageBox.Show(string.Format("cannot add a link to itself, {0} --> {1}", key1, key2), "Warning");
                return false;
            }
            else if (!ExistsTransition(key1, key2))
            {
                DataRow newRow = this.relation.NewRow();
                newRow[S1Name] = key1;      //left hand grid is S1
                newRow[S2Name] = key2;      //right hand grid is S2
                newRow[WorkflowColumnName] = row1[WorkflowColumnName];
                this.relation.Rows.Add(newRow);

            }

            return true;
        }


        private void DeleteTransition(DataRow row1, DataRow row2)
        {
            object key1 = row1[S1ColumnName];
            object key2 = row2[S2ColumnName];

            foreach (DataRow row in relation.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row[S1Name].Equals(key1) && row[S2Name].Equals(key2))
                    {
                        row.AcceptChanges();    //mark sure new transition is in the DataTable:relation
                        row.Delete();

                        return;
                    }
                }
            }

        }


        private void UpdateS2CheckBox(object key2, bool selected)
        {
            DataView dv2 = gridView2.DataSource.DefaultView;
            dv2.Sort = S2ColumnName;
            DataRowView[] S2 = dv2.FindRows(key2);
            foreach (DataRowView s2 in S2)
            {
                DataRow row2 = s2.Row;
                if (selected)
                {
                    if (row2[Flag] == DBNull.Value || !(bool)row2[Flag])      //don't fire event unnecessary
                        row2[Flag] = true;
                }
                else
                {
                    if (row2[Flag] == DBNull.Value || (bool)row2[Flag])
                        row2[Flag] = false;
                }
            }
        }

        public void LinkSelectedTransitions(bool isLink)
        {
            int L1 = gridView1.SelectedRows.Length;
            int L2 = gridView2.SelectedRows.Length;

            if (L1 == 0 || L2 == 0 )
                return;

            if (L1 * L2 > 200)
            {
                if (MessageBox.Show(
                    string.Format("You are about to {0} {1} X {2} = {3} dependencies.\r\nIt will take serveral minutes to completed.\r\nClick [Yes] to continue or [No] to cancel.",
                    isLink? "add" : "remove", L1, L2, L1*L2),
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            DataRow[] rows1 = gridView1.SelectedRows;
            DataRow[] rows2 = gridView2.SelectedRows;

            foreach (DataRow row2 in rows2)
            {
                foreach (DataRow row1 in rows1)
                {
                    if (isLink)
                        AddTransition(row1, row2);
                    else
                        DeleteTransition(row1, row2);
                }

                UpdateS2CheckBox(row2[S2ColumnName], isLink);
            }
        }



        private void SelectS1Row(DataRow s1)
        {
            object key1 = s1[S1ColumnName];

 
            relation.DefaultView.Sort = S1Name;
            DataRowView[] S2 = relation.DefaultView.FindRows(key1);
            foreach (DataRow row2 in gridView2.DataSource.Rows)
            {
                foreach (DataRowView s2 in S2)
                {
                    if (row2[S2ColumnName].Equals(s2[S2Name]))
                    {
                        if (row2[Flag] == DBNull.Value || !(bool)row2[Flag])
                            row2[Flag] = true;
                        goto L1;
                    }
                }

                if (row2[Flag]==DBNull.Value || (bool)row2[Flag])
                    row2[Flag] = false;
            L1: ;

            }
        }

        private void SelectS1Row(DataRow[] S1)
        {
            if (S1.Length == 0)
                return;

            DataTable dt;
            if (relation.GetChanges() != null)
            {
                dt = relation.Copy();
                dt.AcceptChanges(); //remove deleted data rows
            }
            else
                dt = relation;

            IEnumerable<DataRow> relations = dt.AsEnumerable();

            //return S2 
            IEnumerable<string> S2 = S1
                .Join(relations,
                    s1 => s1[S1ColumnName],
                    rel => rel[S1Name],
                    (s1, rel) => (string)rel[S2Name]
                );

            //find common transitions based on S1 mulptiple selections
            S2 = S2.GroupBy(s2 => s2, (s2, g) => g.Count() == S1.Length ? s2 : null);
            S2 = S2.Where(s2 => s2 != null);
            
            //speed up LINQ
            List<string> SS2 = new List<string>();
            foreach (string s2 in S2)
            {
                SS2.Add(s2);
            }

            foreach (DataRow row2 in gridView2.DataSource.Rows)
            {
                foreach (string s2 in SS2)
                {
                    if (row2[S2ColumnName].Equals(s2))
                    {
                        if (row2[Flag] == DBNull.Value || !(bool)row2[Flag])
                            row2[Flag] = true;
                        goto L1;
                    }
                }
            
                if (row2[Flag] == DBNull.Value || (bool)row2[Flag])
                    row2[Flag] = false;
            L1: ;
            }
        }
    }
}

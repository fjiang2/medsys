using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;

namespace Sys.ViewManager.Forms
{
    public partial class JTreeList : UserControl
    {

       // private DataTable dataTable = null;
        //private string[] caption;

        public JTreeList()
        {
            InitializeComponent();           
        }

     

        //public DataTable DataSource
        //{
        //    get
        //    {
        //        return this.dataTable;
        //    }

        //    set
        //    {
        //        this.dataTable = value;
        //        this.treeList1.Columns.Clear();
        //        InitializeTreeView(treeList1, dataTable);
        //    }
        //}

        public DataTable DataSource
        {
            get
            {
                return (DataTable)treeList1.DataSource;
            }
            set
            {
                //this.dataTable = value;
                //this.treeList1.Columns.Clear();
                this.treeList1.DataSource = value;
                //InitializeTreeView(treeList1, dataTable);
            }
        }


        public string ParentFieldName
        {
            set
            {
                this.treeList1.ParentFieldName = value;
            }
        }

        public string KeyFieldName
        {
            set
            {
                this.treeList1.KeyFieldName = value;
            }
        }

        public bool PopulateServiceColumns
        {
            set
            {
                treeList1.OptionsBehavior.PopulateServiceColumns = value;
            }
        }


        //public string[] Caption
        //{
        //    set
        //    {
        //        caption = value;
        //    }
        //}


        //private TreeListColumn[] getColumns()
        //{
        //    TreeListColumn[] cols = new TreeListColumn[caption.Length];

        //    for (int i = 0; i < caption.Length; i++)
        //    {
        //        TreeListColumn c = new TreeListColumn();
        //        c.Caption = caption[i];
        //        c.VisibleIndex = i;
        //        cols[i] = c;
        //    }
        //    return cols;
        //}


        public void InitializeTreeView(TreeList Treelist, DataTable DataTable)
        {
            //treeList1.Columns.AddRange(getColumns());        
            //Create Root Node
            //TreeDataRow source = new TreeDataRow(null, null);


            //foreach (DataRow row in dataTable.Rows)
            //{
            //    TreeDataRow node = new TreeDataRow(source, row);
            //}

           // this.DataSource = DataTable;
            

          
            ////this.gridControl.RefreshDataSource();
            //gridView1.DataController.RefreshData();


            //foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView1.Columns)
            //{
            //    if (gridView1.DataRowCount < 200)
            //        gridColumn.BestFit();

            //    if (!gridView1.OptionsBehavior.Editable)
            //    {
            //        gridColumn.AppearanceCell.Options.UseTextOptions = true;
            //        gridColumn.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;


            //        DataColumn dataColumn = dataTable.Columns[gridColumn.FieldName];
            //        if (dataColumn.DataType == typeof(string))
            //        {
            //            RepositoryItemMemoEdit repositoryItemMemoEdit1 = new RepositoryItemMemoEdit();
            //            repositoryItemMemoEdit1.LinesCount = 0;
            //            gridColumn.ColumnEdit = repositoryItemMemoEdit1;
            //        }
            //    }
            //}
        }
    }






    //public class TreeDataRow : TreeList.IVirtualTreeListData
    //{
    //    protected TreeDataRow Parent;
    //    protected ArrayList Child = new ArrayList();
    //    protected DataRow Data;

    //    public TreeDataRow(TreeDataRow parent, DataRow data)
    //    {
    //        // Specifies the parent node for the new node. 
    //        this.Parent = parent;
    //        // Provides data for the node's cell. 
    //        this.Data = data;
    //        if (this.Parent != null)
    //        {
    //            this.Parent.Child.Add(this);
    //        }
    //    }
    //    void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(
    //    VirtualTreeGetChildNodesInfo info)
    //    {
    //        info.Children = Child;
    //    }
    //    void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(
    //    VirtualTreeGetCellValueInfo info)
    //    {
    //        info.CellData = Data[info.Column.AbsoluteIndex];
    //    }

    //    void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
    //    {
    //        Data[info.Column.AbsoluteIndex] = info.NewCellData;
    //    }
    //}





}

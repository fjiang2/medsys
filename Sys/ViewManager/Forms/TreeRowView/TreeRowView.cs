using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sys.Data;
 
namespace Sys.ViewManager.Forms
{
    
    public class TreeRowView 
    {
        TreeView treeView;
        //TreeNode rootNode;

        public string IdField = "ID";
        public string ParentIdField ="ParentID";
        public string DisplayField = "Label";
        public string OrderByField = "OrderBy";
        public string ImageField = "";
        public string CheckedField = "";

        public delegate void AfterSelectHandler(object sender, TreeRowNodeEventArgs e);
        public event AfterSelectHandler SelectNode;


        DataTable dataTable;
        public TreeRowView(TreeView treeView, DataTable dataTable)
        {
            this.treeView = treeView;
            this.dataTable = dataTable;

            treeView.AfterSelect += delegate(object sender, TreeViewEventArgs e)
            {
                if (e.Action == TreeViewAction.ByMouse)
                {
                    TreeRowNode treeNode = (TreeRowNode)e.Node;
                    if (SelectNode != null)
                        SelectNode(this, new TreeRowNodeEventArgs(treeNode));
                }
            };

        }

        public DataTable DataTable
        {
            get
            {
                return this.dataTable;
            }

            set
            {
                this.dataTable = value;
            }
        }

        public TreeRowNode SearchTreeNode(int ID)
        {
            return SearchTreeNode(ID, treeView.Nodes);
        }

        private TreeRowNode SearchTreeNode(int ID, TreeNodeCollection nodes)
        {
            foreach (TreeNode treeNode in nodes)
            {
                TreeRowNode node = (TreeRowNode)treeNode;
                if ((int)node.DataRow[IdField] == ID)
                    return node;

                TreeRowNode result = SearchTreeNode(ID, node.Nodes);
                if (result != null)
                    return result;


            }
            
            return null;
        }
        
        
        public TreeRowNode NodeSelected
        {
            get
            {
                return (TreeRowNode)treeView.SelectedNode;
            }
            set
            {
                treeView.SelectedNode = value;
            }
        }

        public void BuildTreeView()
        {
            BuildTreeView(treeView.Nodes, 0, DisplayDelegate);
        }

        public void BuildTreeView(DisplayTreeRowNode d)
        {
            BuildTreeView(treeView.Nodes, 0, d);
        }

        public void BuildTreeView(TreeNode parentNode, int parentID, DisplayTreeRowNode d)
        {
            BuildTreeView(parentNode.Nodes, parentID, d);
        }

    
        public void BuildTreeView(TreeNodeCollection nodes, int parentID, DisplayTreeRowNode d)
        {
            DataRow[] dataRows = dataTable.Select(string.Format("{0}={1}", ParentIdField, parentID));
            int i = 0;
            foreach (DataRow dataRow in dataRows)
            {
                TreeNode treeNode2 = new TreeRowNode(dataRow, d, ImageField, CheckedField);
                if (dataRow.Table.Columns.Contains(OrderByField))
                {
                    dataRow[OrderByField] = i;
                    i += 2;
                }
                nodes.Add(treeNode2);
                BuildTreeView(treeNode2.Nodes, (int)dataRow[IdField], d);
            }
        }


        public void BuildTreeNode(TreeNodeCollection nodes, int ID)
        {
            BuildTreeNode(nodes, ID, DisplayDelegate);
        }
        
        public void BuildTreeNode(TreeNodeCollection nodes, int ID, DisplayTreeRowNode d)
        {
            DataRow[] dataRows = dataTable.Select(string.Format("{0}={1}", IdField, ID));
            if (dataRows.Length != 1)
                return;

            TreeNode treeNode2 = new TreeRowNode(dataRows[0], d, ImageField, CheckedField);
            nodes.Add(treeNode2);

            BuildTreeView(treeNode2.Nodes, (int)dataRows[0][IdField], d);
        }

        public string DisplayDelegate(DataRow dataRow)
        {
            return (string)dataRow[DisplayField];
        }

        public void SaveOrderBy(string tableName)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                string SQL = string.Format("UPDATE @TableName SET {0} = {1} WHERE {2} = {3}", OrderByField, row[OrderByField], IdField, row[IdField])
                    .Replace("@TableName", tableName);
                
                SQL.ExecuteNonQuery();
                
            }
        }
    }

   


    

}

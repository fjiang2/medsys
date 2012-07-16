using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Sys.ViewManager.Forms
{
    public delegate string DisplayTreeRowNode(DataRow dataRow);

    public class TreeRowNode : TreeNode
    {
        public const string TREE_ROW_NODE_SELECTED_IMAGE = "TREE_ROW_NODE_SELECTED_IMAGE";

        DataRow dataRow;

        public TreeRowNode(DataRow dataRow, DisplayTreeRowNode displayField, string imageField, string checkedField)
        {
            this.dataRow = dataRow;
            this.Text = displayField(dataRow);

            if (imageField != "")
            {
                if (dataRow.Table.Columns.Contains(imageField))
                {
                    this.ImageKey = dataRow[imageField].ToString();
                }
                else
                {
                    this.ImageKey = imageField;
                }

                this.SelectedImageKey = TREE_ROW_NODE_SELECTED_IMAGE;
            }

            if (checkedField != "")
            {
                this.Checked = (bool)dataRow[checkedField];
            }
        }

        public void Add(TreeRowNode dataRowTreeNode)
        {
            this.Nodes.Add(dataRowTreeNode);
        }

        public DataRow DataRow
        {
            get 
            { 
                return this.dataRow; 
            }
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}

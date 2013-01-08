using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.SmartList.DpoClass;
using Sys.Data;
using Sys.ViewManager.Forms;
using Sys.Security;
using Sys;

namespace Sys.SmartList
{

    public enum ImageIndices
    {
        Folder = 0,
        Item = 1
    }


    class CommandNodeDpo : Configuration, INTreeDpoNode, INTreeNode<CommandNodeDpo>
    {
        public CommandNodeDpo()
        {
            this.DataViewMode = DataViewMode.DataGrid;
            this.AccessLevel = SecurityLevel.PublicAccess;

            this.Ty = 4;

            this.Visible = true;
            this.Enabled = true;
            this.Released = true;
            this.Controlled = true;

            this.Owner_ID = Account.CurrentUser.UserID;

            this.Setting_Script = "";
            this.Sql_Command = "";
            this.User_Layout = "";
            this.Header_Footer = "";

            this.Help = "";
        }
    
        public CommandNodeDpo(DataRow dataRow)
            : base(dataRow)
        { 
        
        }

 

        #region ITreeDpoNode
        public CommandNodeDpo NodeItem { get { return this; } }
        public int NodeId { get { return this.ID; } }
        public int NodeParentId { get { return (int)this.ParentID; } set { this.ParentID = value; } }
        public string NodeText { get { return this.Label; } set { this.Label = value; } }
        public int NodeOrderBy 
        { 
            get 
            {
                return (int)this.OrderBy; 
            } 
            set 
            { 
                this.OrderBy = value; 
            } 
        }

        public int NodeImageIndex 
        { 
            get 
            {
                return this.Image_Index; 
            }
            set
            {
                this.Image_Index = value;
            }
        }

        public string NodeSelectedImageKey 
        {
            get
            {
                return TreeRowNode.TREE_ROW_NODE_SELECTED_IMAGE;
            }
        }

        public bool NodeChecked 
        {
            get
            {
                return false;
            }

            set
            {
                ;
            }
        }

        public bool NodeSave()
        {
            this.Enabled = true;
            this.Controlled = true;
            this.Save();
            
            return true;
        }

        public List<INTreeDpoNode> GetNodes(int parentID)
        {
            //SELECT * FROM {0} WHERE ParentID = @parentID ORDER BY OrderBy
            SqlClause sql = new SqlClause().SELECT.COLUMNS().FROM(this).WHERE( _ParentID.ColumnName() == parentID).ORDER_BY(_OrderBy);
            DataTable dt = sql.FillDataTable();

            List<INTreeDpoNode> list = new List<INTreeDpoNode>();
            foreach (DataRow dataRow in dt.Rows)
            {
                INTreeDpoNode dpo = new CommandNodeDpo(dataRow);
                list.Add(dpo);
            }

            return list;
        }

        public System.Drawing.Image IconImage { get { return null; }  }
        public string Statement { get { return null; } }
  

        #endregion





        public List<INTreeDpoNode> EntireCollection
        {
            get
            {
                //int parentID = 10;
                //SQL sql1 = new SqlBuilder().SELECT.COLUMNS().FROM(this).WHERE((EXPR)_ParentID == parentID & (EXPR)_Controlled == true).ORDER_BY(_OrderBy);


                //SELECT * FROM {0} ORDER BY OrderBy
                SqlClause sql = new SqlClause().SELECT.COLUMNS().FROM(this).ORDER_BY(_OrderBy);
                DataTable dt = sql.FillDataTable();

                List<INTreeDpoNode> list = new List<INTreeDpoNode>();
                foreach (DataRow dataRow in dt.Rows)
                {
                    INTreeDpoNode dpo = new CommandNodeDpo(dataRow);
                    list.Add(dpo);
                }

                return list;
            }
        }

     

        public override string ToString()
        {
            return string.Format("{0}/{1}::{2} {3}",ID, ParentID, OrderBy, Label);
        }
    }
}

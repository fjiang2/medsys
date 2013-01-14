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


    public class CommandNodeDpo : Configuration, INTreeDpoNode, INTreeNode<CommandNodeDpo>
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

        public IEnumerable<INTreeDpoNode> GetNodes(int parentID)
        {
            return new TableReader<CommandNodeDpo>(_ParentID.ColumnName() == parentID).ToList().OrderBy(dpo => dpo.OrderBy);
        }

        public System.Drawing.Image IconImage { get { return null; }  }
        public string Statement { get { return null; } }
  

        #endregion



        public override string ToString()
        {
            return string.Format("{0}/{1}::{2} {3}",ID, ParentID, OrderBy, Label);
        }
    }
}

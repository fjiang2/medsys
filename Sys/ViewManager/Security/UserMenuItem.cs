using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Sys.Data;
using Sys.ViewManager.Forms;

namespace Sys.ViewManager.Security
{

    public class UserMenuItem : DpoClass.UserMenuDpo, INTreeDpoNode, INTreeNode<UserMenuItem>
    {
        int imageIndex = -1;

        public UserMenuItem()
        { 
        }

        public UserMenuItem(int ID)
        {
            this.ID = ID;
            Load();
        }

        public UserMenuItem(DataRow dataRow)
            :base(dataRow)
        {
        }

        public UserMenuItem(string key)
        {
            UpdateObject(_Key_Name.ColumnName() == key);
        }

        public int MenuID
        {
            get { return ID; }
        }

        public int ImageIndex
        {
            get { return this.imageIndex; }
            set { this.imageIndex = value; }
        }

        public MenuItemType MenuType
        {
            get
            {
                return (MenuItemType)Ty;
            }
            set
            {

                Ty = (int)value;
            }
        }

        public FormPlace FormPlace
        {
            get { return (FormPlace)Form_Place; }
            set { Form_Place = (int)value; }
        }

        public static void AddSeperator(int parentID, int orderBy)
        {
            UserMenuItem dpo = new UserMenuItem();
            dpo.ParentID = parentID;
            dpo.OrderBy = orderBy;
            dpo.MenuType = MenuItemType.Separator;
            dpo.Label = "------";
            dpo.Visible = true;
            dpo.Released = true;
            dpo.Enabled = true;
            dpo.Controlled = false;
            dpo.Save();
        }

        #region ITreeDpoNode

        public UserMenuItem NodeItem { get { return this; } }
        public int NodeId { get { return this.ID; } }
        public int NodeParentId { get { return (int)this.ParentID; } set { this.ParentID = value; } }
        public string NodeText { get { return this.Label; } set { this.Label = value; } }
        public int NodeOrderBy
        {
            get
            {
                if (this.OrderBy == null)
                    return 0;

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
                return 0;
            }
            set
            { }
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
            this.Save();

            return true;
        }

        public IEnumerable<INTreeDpoNode> GetNodes(int parentID)
        {
            return new TableReader<UserMenuItem>
                (
                    (_ParentID.ColumnName() == parentID)
                    .AND(_Ty.ColumnName() == 0)
                    .AND(_Controlled.ColumnName() == 1)
                )
                .ToList()
                .OrderBy(dpo => dpo.OrderBy);
        }

        #endregion

        public string Statement
        {
            get { return this.Command; }
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", ID, Label);
        }
    }
}

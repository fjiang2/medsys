using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Sys.Data;
using Sys.ViewManager.Forms;

namespace Sys.ViewManager.Security
{

    public class UserMenuItem : DpoClass.UserMenuDpo, ITreeDpoNode , INTreeNode<UserMenuItem>
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

        public List<ITreeDpoNode> GetNodes(int parentID)
        {
            //@"SELECT ID, ParentID, Label FROM {0} WHERE Ty=0 AND Controlled=1 ORDER BY orderBy";
            SqlClause sql = new SqlClause()
                .SELECT
                .COLUMNS()
                .FROM(this)
                .WHERE(
                    _ParentID.ColumName() == parentID & _Ty.ColumName() == 0 & _Controlled.ColumName() == 1)
                .ORDER_BY(_OrderBy);
            DataTable dt = sql.FillDataTable();

            List<ITreeDpoNode> list = new List<ITreeDpoNode>();
            foreach (DataRow dataRow in dt.Rows)
            {
                ITreeDpoNode dpo = new UserMenuItem(dataRow);
                list.Add(dpo);
            }

            return list;
        }

        #endregion

    }
}

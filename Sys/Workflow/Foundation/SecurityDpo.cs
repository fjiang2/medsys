using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using System.Data;
using Sys.ViewManager.Forms;

namespace Sys.Workflow
{
    public class SecurityDpo : Dpo.wfSecurity, ITreeNodeDpo, ITreeIdentifierNode<SecurityDpo>
    {

        public SecurityDpo()
        {
        }

        public SecurityDpo(DataRow dataRow)
            :base(dataRow)
        {
        }

        #region ITreeDpoNode
        public SecurityDpo NodeItem { get { return this; } }
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
            return true;
        }

        public override bool Delete()
        {
            return true;
        }

        public List<ITreeNodeDpo> GetNodes(int parentID)
        {
            return null;
        }

        #endregion


        public List<ITreeNodeDpo> EntireCollection
        {
            get
            {
                string SQL = @"
                SELECT -ID AS ID, ParentID, Label, 0 AS OrderBy
                FROM {0}
                WHERE Released = 1
                UNION
                SELECT S.ID, -W.ID AS ParentID, S.Label, 0 AS OrderBy
                FROM {1} S
                INNER JOIN {0} W ON W.Name = S.Workflow_Name AND W.Released = 1
                ORDER BY ParentID, ID
                ";

                DataTable dt = SqlCmd.FillDataTable(SQL,
                    Sys.Workflow.Dpo.wfWorkflowDpo.TABLE_NAME,
                    Sys.Workflow.Dpo.wfStateDpo.TABLE_NAME
                    );

                List<ITreeNodeDpo> list = new List<ITreeNodeDpo>();
                foreach (DataRow dataRow in dt.Rows)
                {
                    ITreeNodeDpo dpo = new SecurityDpo(dataRow);
                    list.Add(dpo);
                }

                return list;
            }
        }
    }
}

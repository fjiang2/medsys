using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using X12.DpoClass;
using Sys.ViewManager.Forms;
using Sys;

namespace X12.Specification
{
    public class LoopTemplateDpo : X12LoopTemplateDpo, ITreeDpoNode, INTreeNode<LoopTemplateDpo> 
    {

        public LoopTemplateDpo()
        { 
        }

        public LoopTemplateDpo(DataRow dataRow)
            : base(dataRow)
        { 
        
        }

        public string Text
        {
            get
            {
                if(this.MaxRepeat==-1)
                    return string.Format("{0} - {1}(>1)", this.Name, this.Description.ToSentence());
                else if (this.MaxRepeat == 0)
                    return string.Format("{0} - {1}", this.Name, this.Description.ToSentence());
                else
                    return string.Format("{0} - {1}({2})", this.Name, this.Description.ToSentence(), this.MaxRepeat);
            }
        }


        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Name, this.Description.ToSentence());
        }

        #region ITreeDpoNode/ITreeIdentifierNode

      
        public LoopTemplateDpo NodeItem
        {
            get { return this; }
        }

        public int NodeId { get { return this.ID; } }
        public int NodeParentId { get { return (int)this.ParentID; } set { this.ParentID = value; } }
        public string NodeText { get { return this.ToString(); } set {} }
        public int NodeOrderBy
        {
            get
            {
                return this.Sequence;
            }
            set
            {
                this.Sequence = value;
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
                .WHERE(_ParentID.ColumnName() == parentID)
                .ORDER_BY(_Sequence);
            DataTable dt = sql.FillDataTable(); //new TableReader<LoopDpo>(new ColumnValue(_ParentID, parentID)).Table;

            List<ITreeDpoNode> list = new List<ITreeDpoNode>();
            foreach (DataRow dataRow in dt.Rows)
            {
                ITreeDpoNode dpo = new LoopTemplateDpo(dataRow);
                list.Add(dpo);
            }

            return list;
        }

        #endregion
    }
}

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
    public class LoopTemplateDpo : X12LoopTemplateDpo, INTreeDpoNode, INTreeNode<LoopTemplateDpo> 
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

        public IEnumerable<INTreeDpoNode> GetNodes(int parentID)
        {
            return new TableReader<LoopTemplateDpo>(_ParentID.ColumnName() == parentID).ToList().OrderBy(dpo => dpo.Sequence);
        }

        public System.Drawing.Image IconImage { get { return null; } }
        public string Statement { get { return null; } }

        #endregion
    }
}

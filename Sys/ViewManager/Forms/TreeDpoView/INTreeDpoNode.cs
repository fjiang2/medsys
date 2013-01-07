using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Sys;

namespace Sys.ViewManager.Forms
{
    public interface INTreeDpoNode 
    {
        int NodeId { get; }
        int NodeParentId { get; set; }
        string NodeText { get; set; }
        int NodeOrderBy { get; set; }
        int NodeImageIndex { get; set; }
        string NodeSelectedImageKey { get; }
        bool NodeChecked { get; set; }

        bool Delete();
        bool NodeSave();

        /// <summary>
        /// Dynamic loading nodes
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
    //    List<ITreeDpoNode> GetNodes(int parentID);

        Image IconImage { get; }
        string Expression { get; }
    }
}

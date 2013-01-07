using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Sys.ViewManager.Forms
{
    public interface INTreeDpoNode : ITreeDpoNode
    {
        Image IconImage { get; }
        string Expression { get; }
    }
}

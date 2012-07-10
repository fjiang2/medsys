using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Sys
{
    public interface ITreeIdentifierNode<T> where T : class
    {
        int NodeId { get; }
        int NodeParentId { get; set; }
        T NodeItem { get; }
    }
}

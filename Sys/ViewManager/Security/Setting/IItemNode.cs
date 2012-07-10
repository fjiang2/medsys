using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.ViewManager.Security
{
    public interface IItemNode
    {
        int ID { get; }
        int ParentID { get; }
        string Label { get; }
    }
}

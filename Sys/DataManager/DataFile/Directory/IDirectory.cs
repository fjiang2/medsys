using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.DataManager
{
    public interface IDirectory
    {
        string PhysicalDirectory { get; }
        string GetFilePath(string fileName);
    }
}

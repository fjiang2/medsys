using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Modules
{
    public interface IModule
    {
        void initialize();
        void finalize();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Modules
{
    public class IModuleImpl : IModule
    {
        public IModuleImpl()
        { 
        
        }

        public void initialize()
        {
            Library.CreateTable(this.GetType().Assembly);
        }

        public void finalize()
        { 
        }
    }
}

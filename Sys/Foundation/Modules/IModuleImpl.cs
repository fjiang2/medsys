using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Sys.Data;

namespace Sys.Modules
{
    public class IModuleImpl : IModule
    {
        Assembly assembly;

        public IModuleImpl(string moduleName)
        {
            this.assembly = Library.GetAssembly(moduleName);
        }

        public void initialize()
        {
            foreach (Type type in assembly.GetExportedTypes())
            {
                if (type.BaseType == typeof(DPObject))
                {
                    DPObject dpo = (DPObject)Activator.CreateInstance(type);
                    dpo.CreateTable();
                }
            }
        }

        public void finalize()
        { 
        }
    }
}

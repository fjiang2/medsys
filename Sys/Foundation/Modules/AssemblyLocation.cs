using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Sys.Foundation.DpoClass;
using Sys.Data.Manager;

namespace Sys.Modules
{
    public class AssemblyLocation: AssemblyDpo
    {
        Assembly assembly;

        public AssemblyLocation(Assembly assembly)
            :base(assembly.GetName().Name)
        {
            if (!Exists)
                throw new SysException("Assembly {0} is not regiested", assembly.GetName().Name);

            this.assembly = assembly;
        }

        public AssemblyLocation(string assemblyName)
            :base(assemblyName)
        {
            if (!Exists)
                throw new SysException("Assembly {0} is not regiested", assemblyName);

            this.assembly = Assembly.Load(assemblyName);
            if(assembly == null)
                throw new SysException("Assembly {0} doesn't exist", assemblyName);
        }

        /// <summary>
        /// Assembly physical path in the disk
        /// </summary>
        /// <returns></returns>
        public string Path()
        {
            Sys.IO.Path path = new Sys.IO.Path();
            return string.Format("{0}\\{1}", path.Solution, this.Location);
        }

        public string Path(string subpath)
        {
            if (string.IsNullOrEmpty(subpath))
                return Path();
            else
                return Path() + "\\" + subpath;
        }

    
    }
}

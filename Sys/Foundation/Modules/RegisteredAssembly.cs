using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Sys.Foundation.DpoClass;
using Sys.Data.Manager;
using Sys.Data;
using System.Data;

namespace Sys.Modules
{
    public class RegisteredAssembly: AssemblyDpo
    {
        private Assembly assembly;

        public RegisteredAssembly()
        { 
        }

  
        public override void Fill(DataRow dataRow)
        {
            base.Fill(dataRow);
            this.assembly = Assembly.Load(this.FullName);
        }

        public Assembly Assembly
        {
            get { return this.assembly;}
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

        public override string ToString()
        {
            return this.AssemblyName;
        }
    }
}

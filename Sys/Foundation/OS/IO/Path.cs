using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Sys.Data.Manager;

namespace Sys.IO
{
    public class Path
    {
        string[] paths;

        public Path()
            :this(Assembly.GetExecutingAssembly())
        { 
        
        }

        public Path(Assembly assembly)
        {
            string path = System.IO.Path.GetDirectoryName(assembly.GetName().CodeBase)
                .Replace("file:\\", "")
                .Replace("\\bin", "")
                .Replace("\\x86", "")
                .Replace("\\Debug", "");

            this.paths = path.Split(new char[] { '\\' });

        }

        private string partial(int n)
        {
            string path = paths[0];
            for (int i = 1; i < paths.Length - n; i++)
                path += "\\" + paths[i];

            return path;
        }

        public string SimplePath
        {
            get { return partial(0); }
        }

        public string Solution
        {
            get
            {
                return partial(3);
            }
        }

        public string Application
        {
            get
            {
                return partial(2);
            }
        }
    }
}

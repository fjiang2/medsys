using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

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
                return partial(2);
            }
        }

        public string Application
        {
            get
            {
                return partial(1);
            }
        }


        public static string ModulePath(Assembly assembly)
        {
            return ModulePath(assembly.GetName().Name);
        }

       

        public static string ModulePath(string moduleName)
        {
            Path path = new Path();

            if (moduleName.StartsWith("Sys."))
                return string.Format("{0}\\Sys\\{1}", path.Solution, moduleName.Substring(4));
            else if (moduleName.StartsWith("App."))
                return string.Format("{0}\\App\\{1}", path.Solution, moduleName.Substring(4));
            else
                return string.Format("{0}\\{1}",path.Application, moduleName);
        }



        public static string ModuleDpoPath(Assembly assembly)
        {
            return ModuleDpoPath(assembly.GetName().Name);
        }

        public static string ModuleDpoPath(string moduleName)
        {
            string path = ModulePath(moduleName) + "\\Dpo\\Class";
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }


        public static string ModulePackagePath(Assembly assembly)
        {
            return ModulePackagePath(assembly.GetName().Name);
        }

        public static string ModulePackagePath(string moduleName)
        {
            string path = ModulePath(moduleName) + "\\Dpo\\Package";
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }


    }
}

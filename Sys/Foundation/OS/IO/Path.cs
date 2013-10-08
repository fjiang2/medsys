using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Sys.Data.Manager;
using Sys.OS;

namespace Sys.IO
{
    public class Path
    {
        private string simplePath;
        private string solution;
        private string application;

        public Path()
            :this(Assembly.GetExecutingAssembly())
        { 
        
        }

        public Path(Assembly assembly)
        {
            if (!System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                string path = System.IO.Path.GetDirectoryName(assembly.GetName().CodeBase)
                    .Replace("file:\\", "")
                    .Replace("\\bin", "")
                    .Replace("\\x86", "")
                    .Replace("\\Debug", "");

                string[] paths = path.Split(new char[] { '\\' });

                this.simplePath = partial(paths, 0);        //C:\devel\medsys\App\Executable\Release
                this.solution = partial(paths, 2);          //C:\devel\medsys
                this.application = partial(paths, 1);       //C:\devel\medsys\App
            }
            else
            {
                string devel = Configuration.Instance.GetValue<string>("Path.devel");
                this.simplePath = System.IO.Path.GetDirectoryName(assembly.GetName().CodeBase);
                this.solution = devel+"\\medsys";
                this.application = this.solution+"\\App";
            }
        }

        private string partial(string[] paths, int n)
        {
            string path = paths[0];
            for (int i = 1; i < paths.Length - n; i++)
                path += "\\" + paths[i];

            return path;
        }

        public string SimplePath
        {
            get { return this.simplePath; }
        }

        public string Solution
        {
            get
            {
                return this.solution;
            }
        }

        public string Application
        {
            get
            {
                return this.application;
            }
        }
    }
}

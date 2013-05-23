using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sys.Security;
using Sys.Platform;
using Sys.OS;
using System.Reflection;
using System.IO;
using System.Drawing;
using Tie;
using Sys;
using Sys.Platform.Forms;



namespace App.Executable
{
    /// <summary>
    /// make Application target platform be .NET Framework 4.0, rather than .NET Framkework 4.0 Client Profile when Sys.Platform cannot be loaded
    /// </summary>
    static class Program
    {
        const string applicationName = "Median System";
        const string softwareCompanyName = "Datum Connect Inc.";
        const string softwareCompanyShortName = "datconn";

        [STAThread]
        static void Main()
        {

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            string executable = Assembly.GetExecutingAssembly().GetName().Name;
            string ini = string.Format("{0}\\{1}\\{2}\\{3}.ini", 
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                    softwareCompanyShortName, 
                    applicationName, 
                    executable);

            Icon applicationIcon = App.Executable.Properties.Resources.kiwi;


            //Form wizard = new Sys.Platform.Forms.InstallWizard();
            //Application.Run(wizard);
            //return;


            //Connect to SQLServer
            // case 1: if .ini file does not exist
            // case 2: uninstall software and then install again, in this case: .ini exists and database may not exist
            if (!Sys.Constant.Load(ini) || !SysInformation.ValidDatabase())
            {
                Form server = new Sys.Platform.Forms.Connect2ServerForm();
                System.Windows.Forms.Application.Run(server);

                if (server.DialogResult != DialogResult.OK)
                    return;
            }

            //exit silently if wrong databse is selected
            // or application database version is less than application executable version
            if (!SysInformation.Start(
                softwareCompanyName,
                App.Executable.Properties.Resources.logo,
                applicationIcon,
                applicationName,
                executable))
            {
                return;
            }

            //DataManager.Helper.Start();
            if (!LoginForm.Run(applicationIcon, true))
               return;

            SysInformation.Stop();
            Sys.Constant.Save(ini);
        }


 
    }
}

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
    static class Program
    {
        const string applicationName = "Median System";
        const string softwareCompanyName = "Datum Connect Inc.";

        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string executable = Assembly.GetExecutingAssembly().GetName().Name;
            string ini = executable + ".ini";
            Icon applicationIcon = App.Executable.Properties.Resources.kiwi;

            //Form wizard = new Sys.Platform.Forms.InstallWizard();
            //Application.Run(wizard);
            //return;


            //Connect to SQLServer
            if (!Sys.Constant.Load(ini))
            {
                Form server = new Sys.Platform.Forms.Connect2ServerForm();
                Application.Run(server);

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
                return;

            //DataManager.Helper.Start();
            if (!LoginForm.Run(applicationIcon))
               return;

            SysInformation.Stop();
            Sys.Constant.Save(ini);
        }


 
    }
}

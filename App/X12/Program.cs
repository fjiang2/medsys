﻿#define CREATE_DPOBJECT
//#define UPGRADE_DPOBJECT
//#define UPGRADE_PACKAGE
//#define UPGRADE_SQL_SERVER

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Security;
using Sys.Modules;

namespace X12
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connetionString = connetionString = "data source=localhost\\SQLEXPRESS;initial catalog=medsys;integrated security=SSPI;packet size=4096";
            ConnectionProvider provider = ConnectionProviderManager.RegisterDefaultProvider(connetionString);

            Assembly assembly = Assembly.GetExecutingAssembly();
            Manager mgr = new Manager(assembly);
            string path = Library.AssemblyPath(assembly, Setting.DPO_CLASS_PATH);

#if CREATE_DPOBJECT
            Manager.CreateClass(provider, new string[] {
                "medsys..[X12LoopTemplate]", 
                "medsys..[X12SegmentTemplate]", 
                "medsys..[X12SegmentInstance]", 
                "medsys..[X12ElementTemplate]", 
                "medsys..[X12ElementInstance]", 
                "medsys..[X12CodeDefinition]" 
                }, 
                path, "X12.Dpo", Level.Fixed, true, false, null); 
#endif

#if UPGRADE_DPOBJECT
            //Genernate Dpo Class
            Account.SetCurrentUser(new Account("devel"));
            mgr.UpgradeClass(Sys.IO.Path.ModuleDpoPath(assembly));
#endif      

#if UPGRADE_PACKAGE      
            //Update Dpo Package Data
            Account.SetCurrentUser(new Account("devel"));
            mgr.UpgradePackage(Sys.IO.Path.ModulePackagePath(assembly));
#endif

#if UPGRADE_SQL_SERVER      
            //Update SQL Server
            mgr.UpgradeRecords();
#endif


            //  temp.run();
          //   new Convert();
            Form form = new Forms.X12FileEditor();
            //Form form = new Forms.SpecMaintenance();
            //Form form = new Forms.Editor();

            form.WindowState = FormWindowState.Maximized;
            Application.Run(form);        
         
        }


       

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Security;
using Sys.Foundation.DpoClass;
using System.Drawing;
using System.Data.SqlClient;
using Sys.Data.Manager;
using Tie;
using Sys.OS;

namespace Sys
{
    public static class SysInformation
    {
        private static string softwareCompanyName;
        private static string applicationName;
        private static string executable;
        private static Bitmap logo;
        private static Icon icon;
       
        public static Version DatabaseVersion
        {
            get
            {
                string ver = (string)Configuration.Instance["Version.Database"];
                return new Version(ver);
            }
        }

      
        public static Version ApplicationVerison
        {
            get
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                    Version version = ad.CurrentVersion;
                    return version;
                }

                return new Version();
            }
        }

        public static string ApplicationVerisonText
        {
            get
            {
                string version = Sys.OS.App.ApplicationVersion();
                if (version != "0.0.0.0")
                    return string.Format("{0} - v{1}", SysInformation.ApplicatioName, version);
                else
                    return SysInformation.ApplicatioName + " Unreleased Version";
            }
        }

        public static string ApplicatioName
        {
            get { return SysInformation.applicationName; }
        }

        public static string SoftwareCompanyName
        {
            get { return SysInformation.softwareCompanyName; }
        }

        public static Bitmap Logo
        {
            get { return SysInformation.logo; }
        }

        public static Icon Icon
        {
            get { return SysInformation.icon; }
        }

        public static string Executable
        {
            get { return SysInformation.executable; }
        }

        public static string ComputerName
        {
            get { return (string)Profile.Instance["Computer"]; }
        }

        public static string CompanyName
        {
            get { return (string)Profile.Instance["Company"]; }
        }

        public static int CompanyID
        {
            get { return (int)Profile.Instance["CompanyID"]; }
        }

        public static void SetCompany(Company company)
        {
            Sys.Security.Profile.Instance.Add("Company", company.Name);
            Sys.Security.Profile.Instance.Add("CompanyID", company.Comany_ID);
        }


        /// <summary>
        /// Is valid this application database?
        /// </summary>
        /// <returns></returns>
        public static bool ValidDatabase()
        {
            SqlConnection conn =  (SqlConnection)Sys.Data.DataProviderManager.DefaultConnection.DbConnection;
            try
            {
                conn.Open();
                string SQL = string.Format("SELECT User_Name FROM {0} WHERE User_ID = {1}", UserDpo.TABLE_NAME, PredefinedUser.adminID);
                SqlCommand cmd = new SqlCommand(SQL, conn);
                string admin = (string)cmd.ExecuteScalar();
                
                if (admin != PredefinedUser.admin)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        public static bool Start(string softwareCompanyName, Bitmap logo, Icon icon, string applicationName, string executable)
        {
            if (!ValidDatabase())
                return false;
#if !DEBUG
            if (DatabaseVersion.Major < ApplicationVerison.Major)
                return false;
#endif

            Helper.Start();

            SysInformation.softwareCompanyName = softwareCompanyName;
            SysInformation.logo = logo;
            SysInformation.icon = icon;

            SysInformation.executable = executable;
            SysInformation.applicationName = applicationName;

            return true;
        }

        public static void Stop()
        {
            Stop(Active.Account);
            
            Sys.Security.Profile.Instance.Add("TimeLogout", DateTime.Now);
            Sys.Security.Profile.Instance.Save();
        }


        public static void LoadProfile()
        {
            Sys.Security.Profile.Instance.Load();

            Sys.Security.Profile.Instance.Add("Computer", System.Windows.Forms.SystemInformation.ComputerName);
            Sys.Security.Profile.Instance.Add("Version", App.ApplicationVersion());
            Sys.Security.Profile.Instance.Add("UserName", Active.Account.UserName);
            Sys.Security.Profile.Instance.Add("TimeLogin", DateTime.Now);

        }

        public static void Start(IAccount account)
        {
            if (Constant.SINGLE_USER_SYSTEM)
                return;

            logActivityDpo activity = new logActivityDpo();
            activity.User_Name = account.UserName;
            activity.Application_Name = SysInformation.ApplicatioName;
            activity.Computer_Name = System.Windows.Forms.SystemInformation.ComputerName;
            activity.DateEntered = DateTime.Now;
            activity.Version = App.ApplicationVersion();
            activity.Save();
        }


        private static void Stop(IAccount account)
        {
            if (Constant.SINGLE_USER_SYSTEM)
                return;

            logActivityDpo activity = new logActivityDpo();
            activity.User_Name = account.UserName;
            activity.Application_Name = SysInformation.ApplicatioName;
            activity.Computer_Name = System.Windows.Forms.SystemInformation.ComputerName;

            activity.Delete();
        }
    }
}

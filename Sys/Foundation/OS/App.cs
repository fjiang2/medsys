using System;
using System.Collections.Generic;
using System.Text;
using System.Deployment.Application;
using System.Reflection;
using System.Diagnostics;
using System.Net;

namespace Sys.OS
{
    public class App
    {

        public App()
        { }

        public static string ApplicationVersion()
        {
            string ver = "0.0.0.0";
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                Version version = ad.CurrentVersion;
                ver = string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            }

            return ver;
        }


        public static void AddShortcutToDesktop()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                if (ad.IsFirstRun)  //first time user has run the app since installation or update
                {
                    Assembly code = Assembly.GetExecutingAssembly();
                    string company = SysInformation.SoftwareCompanyName;
                    string description = SysInformation.Executable;
                    
                    //if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
                    //{
                    //    AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code, typeof(AssemblyCompanyAttribute));
                    //    company = ascompany.Company;
                    //}
                    
                    //if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
                    //{
                    //    AssemblyDescriptionAttribute asdescription =  (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code, typeof(AssemblyDescriptionAttribute));
                    //    description = asdescription.Description;
                    //}

                    if (company != string.Empty && description != string.Empty)
                    {
                        string desktopPath = string.Empty;
                        desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "\\", description, ".appref-ms");
                        
                        string shortcutName = string.Empty;
                        shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\\", company, "\\", description, ".appref-ms");


                        try
                        {
                            if(!System.IO.File.Exists(desktopPath))
                                System.IO.File.Copy(shortcutName, desktopPath, true);
                        }
                        catch (Exception)
                        { 
                        
                        }

                    }
                }
            }
        }

        public static void RestartApplication()
        {
            System.Diagnostics.Process.Start(Constant.PATH_EXECUTABLE_INSTALL);  

            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(SysInformation.Executable);
            foreach (System.Diagnostics.Process process in processes)
            {
                process.Kill();
            }
        }


        public static string IsNewerVersionAvailable()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();
                    if (info.UpdateAvailable)
                    {
                        Version version = info.AvailableVersion;
                        return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
                    }
                }
                catch (DeploymentDownloadException)
                {
                    //"The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message
                    return null;
                }
                catch (InvalidDeploymentException)
                {
                    //"Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message
                    return null;
                }
                catch (InvalidOperationException)
                {
                    //"This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message
                    return null;
                }                                             
            }

            return null;           
        }


        //private void InstallUpdateSyncWithInfo()
        //{
        //    UpdateCheckInfo info = null;

        //    if (ApplicationDeployment.IsNetworkDeployed)
        //    {
        //        ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

        //        try
        //        {
        //            info = ad.CheckForDetailedUpdate();

        //        }
        //        catch (DeploymentDownloadException dde)
        //        {
        //            MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
        //            return;
        //        }
        //        catch (InvalidDeploymentException ide)
        //        {
        //            MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
        //            return;
        //        }
        //        catch (InvalidOperationException ioe)
        //        {
        //            MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
        //            return;
        //        }

        //        if (info.UpdateAvailable)
        //        {
        //            Boolean doUpdate = true;

        //            if (!info.IsUpdateRequired)
        //            {
        //                DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
        //                if (!(DialogResult.OK == dr))
        //                {
        //                    doUpdate = false;
        //                }
        //            }
        //            else
        //            {
        //                // Display a message that the app MUST reboot. Display the minimum required version.
        //                MessageBox.Show("This application has detected a mandatory update from your current " +
        //                    "version to version " + info.MinimumRequiredVersion.ToString() +
        //                    ". The application will now install the update and restart.",
        //                    "Update Available", MessageBoxButtons.OK,
        //                    MessageBoxIcon.Information);
        //            }

        //            if (doUpdate)
        //            {
        //                try
        //                {
        //                    ad.Update();
        //                    MessageBox.Show("The application has been upgraded, and will now restart.");
        //                    Application.Restart();
        //                }
        //                catch (DeploymentDownloadException dde)
        //                {
        //                    MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
        //                    return;
        //                }
        //            }
        //        }
        //    }
        //}

        public static string IPAddress()
        {
           
            string hostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            IPAddress[] addr = ipEntry.AddressList;

            string s = "";
            for (int i = 0; i < addr.Length; i++)
            {
                if (s != "")
                    s += "/";
                s += addr[i].ToString();
            }

            return s;
        }    

    }
}

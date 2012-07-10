using System;
using System.Reflection;
using System.Windows.Forms;
using Sys.OS;

namespace Sys.Platform.Forms
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            this.logoPictureBox.Image = SysInformation.Logo;

            this.Text = String.Format("About {0}", SysInformation.ApplicatioName);
            
            this.labelVersion.Text = String.Format("Version {0}", App.ApplicationVersion());
            this.labelCopyright.Text = string.Format("Copyright © {0} 2012 - {1}", SysInformation.SoftwareCompanyName, DateTime.Today.Year);
            this.textBoxDescription.Text = AssemblyDescription 
                + "\r\n\r\nMicrosoft .NET Framework Version:" + version(typeof(object))
                + "\r\nDevExpress Version:" + version(typeof(DevExpress.XtraEditors.ButtonEdit))
                + "\r\nTie Version:" + version(typeof(Tie.VAL))
                + "\r\nSys Framework Version:" + version(this)
                + "\r\nAGS XMPP Version:" + version(typeof(agsXMPP.XmppClientConnection));

            
            this.labelProductName.Text = string.Format("Product Name: {0}", SysInformation.ApplicatioName);
            this.labelCompanyName.Text = string.Format("Company Name: {0}", SysInformation.CompanyName);
            
            this.okButton.Click += new EventHandler(okButton_Click);
        }


        private string version(object obj)
        {
            return obj.GetType().Assembly.GetName().Version.ToString();
        }

        private string version(Type type)
        {
            return type.Assembly.GetName().Version.ToString();
        }

        void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.OS;
using Sys.Security;
using System.Threading;

namespace Sys.Platform.Forms
{
    public partial class LoginForm : Form
    {

        private LoginForm()
        {
            InitializeComponent();
            this.picLogo.Image = SysInformation.Logo;

            this.Text = string.Format("Welcome to {0}",  SysInformation.ApplicatioName);
            this.lblApplicationName.Text = SysInformation.ApplicatioName;
            this.lblSoftwareCompany.Text = SysInformation.SoftwareCompanyName;

            foreach(Company company in Companies.List)
            {
              this.comboServerName.Items.Add(company);
            }

            this.comboServerName.SelectedIndex = 0;
        }

        private void chkForgotPassword_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Account account = new Account(txtUserName.Text, txtPassword.Text);
            try
            {
                if (!account.IsLogined())
                {
                    txtUserName.SelectAll();
                    txtUserName.Focus();
                    ep.SetError(txtUserName, "Unknown User ID or Passoword");
                    return;
                }

                Account.SetCurrentUser(account);

                if (account.MustChangePassword())
                {
                    var form = new ChangePassword();
                    form.UserName = txtUserName.Text;
                    if (form.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                        return;
                }

            }
            catch (Sys.SysException ex)
            {
                ep.SetError(txtUserName, ex.Message);
                return;
            }

        

            SysInformation.LoadProfile();

            Company company = (Company)this.comboServerName.SelectedItem;
            SysInformation.SetCompany(company);
            if (!string.IsNullOrEmpty(company.Default_DB))
                Constant.DB_APPLICATION = company.Default_DB;


            DialogResult = DialogResult.OK;
            //Close();
            
            txtUserName.Text = "";
            txtPassword.Text = "";

            this.Visible = false;
            MainForm main = new MainForm();

            switch (main.ShowDialog(this))
            {
                case System.Windows.Forms.DialogResult.Retry:
                    Account.CurrentUser.Logout();
                    this.Visible = true;
                    txtUserName.Focus();
                    break;

                case System.Windows.Forms.DialogResult.Abort:
                    Application.Exit();
                    break;
            }
        }


      

        private void Login_Load(object sender, EventArgs e)
        {
            txtUserName.SelectAll();
            txtUserName.Focus();
        }


        #region Application Entry

        /// <summary>
        /// Run application, logon is required.
        /// </summary>
        /// <param name="sysIcon"></param>
        /// <param name="loginIcon"></param>
        /// <returns>return true if application is login</returns>
        private static bool RunLogonRequired(Icon loginIcon)
        {
            var login = new LoginForm();
            login.Icon = loginIcon;
            Application.Run(login);
            
            return login.DialogResult != DialogResult.Cancel;
        }

        /// <summary>
        /// Run application without logon, default user: admin, company: the first company
        /// </summary>
        /// <param name="sysIcon"></param>
        private static void RunNotLogon()
        {
            Account account = new Account(PredefinedUser.singleuser, "password");
            Account.SetCurrentUser(account);
            SysInformation.LoadProfile();

            Company company = new Company(1);
            SysInformation.SetCompany(company);
            if (!string.IsNullOrEmpty(company.Default_DB))
                Sys.Constant.DB_APPLICATION = company.Default_DB;

            MainForm main = new MainForm();
            Application.Run(main);
        }


        public static bool Run(Icon loginIcon)
        {
            if (!Constant.SINGLE_USER_SYSTEM)
                return RunLogonRequired(loginIcon);
            else
            {
                LoginForm.RunNotLogon();
                return true;
            }
        }
        
        #endregion
    }
}

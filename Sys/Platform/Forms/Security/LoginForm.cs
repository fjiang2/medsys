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

            LoadCompanies();
        }

        private void LoadCompanies()
        {
            this.comboServiceName.SelectedItem = null;
            this.comboServiceName.Items.Clear();
            foreach (Company company in Companies.List)
            {
                this.comboServiceName.Items.Add(company);
            }

            if (Companies.List.Count != 0)
                this.comboServiceName.SelectedIndex = 0;
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
            catch (Sys.JException ex)
            {
                ep.SetError(txtUserName, ex.Message);
                return;
            }

        

            SysInformation.LoadProfile();

            Company company = (Company)this.comboServiceName.SelectedItem;
            if (company != null)
            {
                SysInformation.SetCompany(company);
                if (!string.IsNullOrEmpty(company.Default_DB))
                    Constant.DB_APPLICATION = company.Default_DB;
            }

            DialogResult = DialogResult.OK;
            //Close();
            
            txtUserName.Text = "";
            txtPassword.Text = "";

            this.Visible = false;

            MainForm main = new MainForm();
            Sys.Platform.Application.mainForm = main;

            switch (main.ShowDialog(this))
            {
                case System.Windows.Forms.DialogResult.Retry:
                    Account.CurrentUser.Logout();
                    this.Visible = true;
                    txtUserName.Focus();
                    break;

                case System.Windows.Forms.DialogResult.Abort:
                    System.Windows.Forms.Application.Exit();
                    break;
            }
        }


      

        private void Login_Load(object sender, EventArgs e)
        {
            txtUserName.SelectAll();
            txtUserName.Focus();
        }


        #region Application Entry

        static bool connectionAllowChange = false;

        /// <summary>
        /// Run application, logon is required.
        /// </summary>
        /// <param name="sysIcon"></param>
        /// <param name="loginIcon"></param>
        /// <returns>return true if application is login</returns>
        private static bool RunLogonRequired(Icon loginIcon)
        {
            Account account = new Account(SysInformation.UserName, "password");
            if (account.Windows_Authentication)
            {
                RunNotLogon(account);
                return true;
            }

            var login = new LoginForm();
            login.Icon = loginIcon;
            System.Windows.Forms.Application.Run(login);
            
            return login.DialogResult != DialogResult.Cancel;
        }

        /// <summary>
        /// Run application without logon, default user: admin, company: the first company
        /// </summary>
        /// <param name="sysIcon"></param>
        private static void RunNotLogon(Account account)
        {
            Account.SetCurrentUser(account);
            SysInformation.LoadProfile();

            Company company = new Company(1);
            SysInformation.SetCompany(company);
            if (!string.IsNullOrEmpty(company.Default_DB))
                Sys.Constant.DB_APPLICATION = company.Default_DB;

            MainForm main = new MainForm();
            Sys.Platform.Application.mainForm = main;
            System.Windows.Forms.Application.Run(main);
        }


        public static bool Run(Icon loginIcon, bool connectionAllowChange = false)
        {
            LoginForm.connectionAllowChange = connectionAllowChange;

            if (!Constant.SINGLE_USER_SYSTEM)
                return RunLogonRequired(loginIcon);
            else
            {
                LoginForm.RunNotLogon(new Account(PredefinedUser.singleuser, "password"));
                return true;
            }
        }
        
        #endregion

        private void picLogo_Click(object sender, EventArgs e)
        {
            if (!LoginForm.connectionAllowChange)
                return;

            Form server = new Sys.Platform.Forms.Connect2ServerForm();
            server.ShowDialog();

            if (server.DialogResult == DialogResult.OK)
                LoadCompanies();
        }

    }
}

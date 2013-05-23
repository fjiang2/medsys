using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Sys.ViewManager.Forms;

namespace Sys.Platform.Forms
{

    public partial class ChangePassword : BaseForm
    {
        public ChangePassword()
        {
            InitializeComponent();

            this.txtUserName.Text = account.User_Name;

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            this.txtUserName.Enabled = account.IsAdmin;

            if (account.IsAdmin)
            {
                this.txtUserName.Text = "";
                this.txtPass0.Enabled = false;
            }
        }
        
        public string UserName
        {
            get
            {
                return this.txtUserName.Text;
            }
            set
            {
                this.txtUserName.Text = value;
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (!Sys.Security.UserAccount.GoodPassword(txtPass1.Text))
            {
                ep.SetError(txtPass1, "Minimum 6 characters in length, contains uppercase/lowercase letter  and number");
                return;
            }

            if (txtPass1.Text != txtPass2.Text)
            {
                ep.SetError(txtPass2, "Passwords not match");
                return;
            }

            if (!Sys.Security.UserAccount.ExistedUserName(txtUserName.Text))
            {
                ep.SetError(txtUserName, "Unknown user name");
                return;
            }

    
            Sys.Security.Account act = new Sys.Security.Account(txtUserName.Text);

            //change password directly without verifying old password
            if (account.IsAdmin)
            {
                act.ChangePassword(txtPass1.Text);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
                return;
            }

            
            if (act.ChangePassword(txtPass0.Text, txtPass1.Text))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            
            ep.SetError(txtUserName, "Wrong user name or password");
            ep.SetError(txtPass0, "Wrong user name or password");
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            ep.SetError(txtUserName, "");
        }

        private void txtPass0_TextChanged(object sender, EventArgs e)
        {
            ep.SetError(txtPass0, "");
        }

        private void txtPass2_TextChanged(object sender, EventArgs e)
        {
            ep.SetError(txtPass2, "");
        }

        
    }
}

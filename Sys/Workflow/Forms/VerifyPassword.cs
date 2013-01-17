using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Sys.ViewManager.Utils;
using Sys.BusinessRules;
using Sys.Security;

namespace Sys.Workflow.Forms
{
    public partial class VerifyPassword : BaseForm
    {
        private string userName;

        public VerifyPassword()
        {
            InitializeComponent();
            this.userName = account.UserName;
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        public override void RuleDefinition(Sys.BusinessRules.ValidateProvider provider)
        {
            this.txtPassword.Validate(provider, delegate(Validator validator, object sender, EventArgs e)
            {
                if (txtPassword.Text == "")
                {
                    validator.error("You must enter valid passowrd.");
                    return;
                }
            });
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (userName != account.UserName)
            {
                UserAccount user = new UserAccount(this.userName);
                if (user.ValidatePlainPassword(txtPassword.Text))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                    this.validateProvider.SetError(txtPassword, "Invalid password.");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {

        }
    }
}

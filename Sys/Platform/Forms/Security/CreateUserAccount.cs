using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Sys.Security;
using Sys.BusinessRules;
using Sys.ViewManager.Utils;
using Sys.PersistentObjects.DpoClass;

namespace Sys.Platform.Forms
{
    public partial class CreateUserAccount : BaseForm
    {
        public CreateUserAccount()
        {
            InitializeComponent();
        }

        public override void RuleDefinition(BusinessRules.ValidateProvider provider)
        {
            this.txtUserName.Required(provider);
            
            this.txtUserName.Validate(provider, delegate(Validator validator, object sender, EventArgs e)
            {
                UserAccount acc = new UserAccount(txtUserName.Text);
                if (acc.Exists)
                    validator.error("User name exists");
            });

            this.txtPass1.Validate(provider, delegate(Validator validator, object sender, EventArgs e)
            {
                if(!UserAccount.GoodPassword(txtPass1.Text))
                    validator.error("Passwords is weak");
            });

            this.txtPass2.Validate(provider, delegate(Validator validator, object sender, EventArgs e)
            {
                if (txtPass1.Text != txtPass2.Text)
                    validator.error("Passwords are different");
            });

            this.dtpActivated.Validate(provider, delegate(Validator validator, object sender, EventArgs e)
            {
                if (dtpActivated.Value < DateTime.Today)
                    validator.error("activated date < today");
            });

            this.dtpExpired.Validate(provider, delegate(Validator validator, object sender, EventArgs e)
            {
                if (dtpActivated.Value >= dtpExpired.Value)
                    validator.error("expired date < activated date");
            });

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!this.RuleValidated())
                return;

            UserAccount dpo = new UserAccount();
            dpo.User_Name = txtUserName.Text;
            
            dpo.First_Name = txtFirstName.Text;
            dpo.Last_Name = txtLastName.Text;
            dpo.Email = txtEmailAddress.Text;

            
            dpo.Start_Date = dtpActivated.Value;
            dpo.End_Date = dtpExpired.Value;

            dpo.Inactive = false;

            dpo.ChangePassword(txtPass1.Text);  //function ChangePassword SAVES entire record

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            MessageBox.Show(string.Format("Account {0} created", dpo),
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}

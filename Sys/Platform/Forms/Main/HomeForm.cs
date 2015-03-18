using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Sys.OS;
using Sys.Data;

namespace Sys.Platform.Forms
{
    public partial class HomeForm : BaseForm
    {
        Form owner = null;

        public HomeForm(Form form)
        {
            InitializeComponent();
            this.iconImage = global::Sys.Platform.Properties.Resources.HomeHS;

            owner = form;
            this.txtComputerName.Text = SystemInformation.ComputerName;
            this.txtEmployeeName.Text = account.Name;
            this.txtCompanyName.Text = SysInformation.CompanyName;
            this.txtDepartment.Text = account.Department;


            if (this.account.IsDeveloper)
            {
                this.txtServerName.Text = DataProviderManager.DefaultDbConnection.DataSource;
            }
            else
            {
                this.lbServerName.Visible = false;
                this.txtServerName.Visible = false;
            }

            this.picAvatar.Image = account.AvatarImage;

        }

        private void linkLabelQS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void linkLabelPS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

    }
}

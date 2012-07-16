using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Security;
using Sys.ViewManager.Utils;
using Sys.Data;
using Sys.PersistentObjects.Dpo;
using Sys.ViewManager.Forms;
using Sys.ViewManager;
using Sys.ViewManager.Security;
using DevExpress.XtraEditors.Controls;
using Sys.ViewManager.Dpo;
using Sys.ViewManager.DevEx;
using Sys.ViewManager.Modules;
using Sys.BusinessRules;

namespace Sys.Platform.Forms
{
    public partial class AppLinkMaintenance : BaseForm
    {
        BindDpo<AppLinkDpo> bind;

        public AppLinkMaintenance()
        {
            InitializeComponent();
        }

        private void AppLinkMaintenance_Load(object sender, EventArgs e)
        {
            AppLinkDpo dpo = new AppLinkDpo();
            dpo.ID = 1;
            dpo.Load();

            bind = new BindDpo<AppLinkDpo>(dpo);
            //bind.BeforeSaving += bind_BeforeSaving;

            bind.Bind(txtID, AppLinkDpo._ID)
                .Bind(txtOrderBy, AppLinkDpo._OrderBy)
                .Bind(txtLabel, AppLinkDpo._Label)
                .Bind(txtDescription, AppLinkDpo._Description)
                .Bind(txtCommand, AppLinkDpo._Command)
                .Bind(picIcon, AppLinkDpo._Icon)
                .Reset();
        }

        public override void RuleDefinition(BusinessRules.ValidateProvider provider)
        {
            this.txtCommand.Required(provider);
            this.txtLabel.Required(provider);
        }
        

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (!this.RuleValidated())
                return;

            if (bind.ConfirmAndSave("Application Link"))
                this.InformationMessage = string.Format("Application Link [{0}]{1} is saved", txtID.Text, txtLabel.Text);
        }

        private void toolStripButtonCreate_Click(object sender, EventArgs e)
        {
            if (!this.RuleValidated())
                return;

            txtID.Text = "-1";
            if (bind.ConfirmAndSave())
                this.ShowInformation("Application Link is created.");
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = @"c:\";
            fileDialog.Filter = "PNG(*.png)|*.png|JPEG (*.jpg)|*.jpg|All|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picIcon.Image = Image.FromFile(fileDialog.FileName);
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            picIcon.Image = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string SQL = "SELECT ID, Label, Command FROM @AppLinks"
              .Replace("@AppLinks", AppLinkDpo.TABLE_NAME);

            LookUp lookup = new LookUp("Select Application", SQL.FillDataTable());
            DataRow dataRow = lookup.PopUp(this);
            if (dataRow == null)
                return;

            AppLinkDpo dpo = new AppLinkDpo();
            dpo.ID = (int)dataRow["ID"];
            dpo.Load();

            bind.Dpo = dpo;
            bind.Reset();
        }

     

   
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Sys.ViewManager;
using Tie;
using Sys.Data;
using Sys.ViewManager.Dpo;

namespace Sys.Platform.DataImporter
{
    public partial class DataImportWizard : BaseForm 
    {
        BindRow binding = null;
        TextBox tbMapping = new TextBox();
        DataImportManager dataImportManager;

        bool validated = false;

        public DataImportWizard()
        {
            InitializeComponent();
            var dpo = new Sys.ViewManager.Dpo.DataImportDpo();
            binding = new BindRow(dpo, new Locator("[Label]=@Label"));
            binding.Connect(this.tbTemplate, DataImportDpo._Label);
            binding.Connect(this.tbDescription, DataImportDpo._Description);
            binding.Connect(this.tbDataSource, DataImportDpo._DataSource);
            binding.Connect(this.tbClassName, DataImportDpo._ClassName);
            binding.Connect(this.tbMapping, DataImportDpo._Mapping);
        }

  
        private void btnTemplateLookUp_Click(object sender, EventArgs e)
        {
            LookUp lookUp = new LookUp(
                "Select import template", 
                "SELECT ID, Label, Description FROM @DataImports"
                    .Replace("@DataImports", Sys.ViewManager.Dpo.DataImportDpo.TABLE_NAME)
                    .FillDataTable()
                    );

            DataRow dataRow = lookUp.PopUp(this);
            if (dataRow == null)
                return;

            this.tbTemplate.Text = (string)dataRow["Label"];
            binding.Load();


            dataImportManager = new DataImportManager(this.tbTemplate.Text);
            SetColumnNameLookUp(this.repositoryItemLookUpEdit1, this.tbDataSource.Text);
            gridControl3.DataSource = DataImportManager.DecodeMapping(dataImportManager.Mapping);
            gridControl2.DataSource = gridControl3.DataSource;
        }

        private void SetColumnNameLookUp(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpEdit, string dataSource)
        {
            DataTable importDataSource = dataImportManager.DataSource;
            progressBar1.Maximum = importDataSource.Rows.Count;

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("columnName", typeof(string)));
            dt.Columns.Add(new DataColumn("columnType", typeof(string)));

            foreach (DataColumn dataColumn in importDataSource.Columns)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["columnName"] = dataColumn.ColumnName;
                dataRow["columnType"] = dataColumn.DataType.FullName;
                dt.Rows.Add(dataRow);

            }

            lookUpEdit.DataSource = dt;

        }



        private void btnRetrieveImportClass_Click(object sender, EventArgs e)
        {
            if (this.tbClassName.Text == "")
                return;

            try
            {
                dataImportManager = new DataImportManager(this.tbClassName.Text, this.tbDataSource.Text);
                gridControl3.DataSource = DataImportManager.DecodeMapping(dataImportManager.Mapping);
                gridControl2.DataSource = gridControl3.DataSource;

                if (this.tbDataSource.Text != "")
                    try
                    {
                        SetColumnNameLookUp(this.repositoryItemLookUpEdit1, this.tbDataSource.Text);
                    }
                    catch (Exception)
                    {
                        this.ErrorMessage = string.Format("{0} is invalid SQL statment.", this.tbDataSource.Text);
                    }
            }
            catch (Exception)
            {
                this.ErrorMessage = string.Format("{0} is invalid data importer class. it must implement interface IDataImporter.", this.tbClassName.Text);
            }
        }

        private ImportWork callback = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            string message = dataImportManager.Validate(gridControl3.DataSource as DataTable);
            if (message != null)
            {
                this.ErrorMessage = message;
                return;
            }

            callback = new ImportWork(this, dataImportManager);
            callback.WorkDoing += ImportWorkDoing;
            callback.WorkDone += ImportWorkDone;

            progressBar1.Value = 0;
            callback.StartWork();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (callback != null)
                callback.WorkCancelled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.tbTemplate.Text == "")
            {
                this.ErrorMessage = "Template field cannot be blank.";
                return;
            }

            this.tbMapping.Text = DataImportManager.EncodeMapping(gridControl3.DataSource as DataTable).ToString();
            binding.Save();

            this.InformationMessage = "Data importer template is saved.";
        }

        public void ImportWorkDoing(object middleResult)
        {
            string message = string.Format("Record: {0}", middleResult);
            this.ShowProgressBar(message);
            progressBar1.Value++;
        }

        public void ImportWorkDone(object result)
        {
            this.StopProgressBar();

            if (result == null)
                return;

            if (result is Exception)
            {
                this.ErrorMessage = (result as Exception).ToString();
                return;
            }

            bool b = (bool)result;
            if (b)
                this.InformationMessage = "Import completed.";
            else
                this.WarningMessage = "Import interrupted.";
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            this.Close();
        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            this.Close();
        }

        private void wizardControl1_PrevClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
         

        }

        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            DevExpress.XtraWizard.BaseWizardPage page = e.Page;
            e.Handled = !this.validated;
        }

        private void DataImportWizard_Load(object sender, EventArgs e)
        {

        }

        private void welcomeWizardPage1_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            //e.Valid = this.tbTemplate.Text != "";
            //if (!e.Valid)
            //    this.tbTemplate.BackColor = Color.Red;
            //else
            //    this.tbTemplate.BackColor = System.Drawing.SystemColors.Window;
        }

        private void tbTemplate_Validating(object sender, CancelEventArgs e)
        {
            this.validated = this.tbTemplate.Text != "";
            if (tbTemplate.Text == "")
                errorProvider1.SetError (tbTemplate,"Please enter data importer name");
            else
                errorProvider1.SetError (tbTemplate,"");
        }

        private void tbDataSource_Validating(object sender, CancelEventArgs e)
        {
            this.validated = this.tbDataSource.Text != "";
            if (tbDataSource.Text == "")
                errorProvider1.SetError(tbDataSource, "Please enter data source");
            else
                errorProvider1.SetError(tbDataSource, "");
        }

        private void btnRetrieveDataSource_Click(object sender, EventArgs e)
        {
            if (this.tbDataSource.Text != "")
                gridControl1.DataSource = SqlCmd.FillDataTable(this.tbDataSource.Text);
        }

        private void tbClassName_Validating(object sender, CancelEventArgs e)
        {
            this.validated = this.tbClassName.Text != "";
            if (tbClassName.Text == "")
                errorProvider1.SetError(tbClassName, "Please enter importer class name");
            else
                errorProvider1.SetError(tbClassName, "");
        }


        private void wizardPage3_PageValidating(object sender, DevExpress.XtraWizard.WizardPageValidatingEventArgs e)
        {
            string message = dataImportManager.Validate(gridControl3.DataSource as DataTable);
            e.Valid = message == null;
            if (!e.Valid)
                e.ErrorText = message;

        }

    }
}

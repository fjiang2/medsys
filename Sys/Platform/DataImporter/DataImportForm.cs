﻿using System;
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
using Sys.ViewManager.DpoClass;

namespace Sys.Platform.DataImporter
{
    public partial class DataImportForm : WinForm 
    {
        BindDpo<DataImportDpo> binding = null;
        TextBox tbMapping = new TextBox();
        DataImportManager dataImportManager;

        TextBox tbId = new TextBox();
        
        public DataImportForm()
        {
            InitializeComponent();
            
            this.ButtonDelete.Visible = false;
            this.ButtonRefreh.Visible = false;
            this.ButtonNew.Visible = false;
            this.ButtonSerach.Visible = false;
            this.ButtonPrint.Visible = false;

            var dpo = new DataImportDpo();
            binding = new BindDpo<DataImportDpo>(dpo);
            binding.Bind(this.tbId, DataImportDpo._ID);
            binding.Bind(this.tbTemplate, DataImportDpo._Label);
            binding.Bind(this.tbDescription, DataImportDpo._Description);
            binding.Bind(this.tbDataSource, DataImportDpo._DataSource);
            binding.Bind(this.tbClassName, DataImportDpo._ClassName);
            binding.Bind(this.tbMapping, DataImportDpo._Mapping);
            
        }

        private void btnTemplateLookUp_Click(object sender, EventArgs e)
        {
            TableName tableName = typeof(DataImportDpo).TableName();

            LookUp lookUp = new LookUp("Select template",
                DataExtension.FillDataTable(tableName.Provider, "SELECT ID, Label, Description FROM {0}", tableName.FullName));
            DataRow dataRow = lookUp.PopUp(this);
            if (dataRow == null)
                return;

            this.tbTemplate.Text = (string)dataRow["Label"];
            binding.Dpo = new DataImportDpo((int)dataRow["ID"]);


            dataImportManager = new DataImportManager(this.tbTemplate.Text);
            SetColumnNameLookUp(this.repositoryItemLookUpEdit1, this.tbDataSource.Text);
            gridControl1.DataSource = DataImportManager.DecodeMapping(dataImportManager.Mapping); 

        }


        private void SetColumnNameLookUp(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookUpEdit, string dataSource)
        {
            DataTable importDataSource = dataImportManager.DataSource;
            progressBar1.Maximum = importDataSource.Rows.Count;

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("columnName", typeof(string)));
            dt.Columns.Add(new DataColumn("columnType", typeof(string)));

            foreach(DataColumn dataColumn in importDataSource.Columns)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["columnName"] = dataColumn.ColumnName;
                dataRow["columnType"] = dataColumn.DataType.FullName;
                dt.Rows.Add(dataRow);

            }

            lookUpEdit.DataSource = dt;
            
        }


      


        public override bool DataSave()
        {
            if (this.tbTemplate.Text == "")
            {
                this.ErrorMessage = "Template field cannot be blank.";
                return false;
            }

            this.tbMapping.Text = DataImportManager.EncodeMapping(gridControl1.DataSource as DataTable).ToString();
            binding.Save();

            this.InformationMessage = "Data importer template is saved.";
            return true;
        }



        private void btnRetrieveClass_Click(object sender, EventArgs e)
        {
            if (this.tbClassName.Text == "")
                return;

            try
            {
                dataImportManager = new DataImportManager(this.tbClassName.Text, this.tbDataSource.Text);
                gridControl1.DataSource = DataImportManager.DecodeMapping(dataImportManager.Mapping);
                if(this.tbDataSource.Text!="")
                    try
                    {
                        SetColumnNameLookUp(this.repositoryItemLookUpEdit1, this.tbDataSource.Text);
                    }
                    catch(Exception)
                    {
                        this.ErrorMessage = string.Format("{0} is invalid SQL statment.", this.tbDataSource.Text);
                    }
            }
            catch (Exception)
            {
                this.ErrorMessage = string.Format("{0} is invalid data importer class. it must implement interface IDataImporter.", this.tbClassName.Text);
            }
        }

        private void DataImportForm_Load(object sender, EventArgs e)
        {

        }

        private ImportWork callback = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            
            string message = dataImportManager.Validate(gridControl1.DataSource as DataTable);
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
            
            Message message;
            if (result is Exception)
            {
                message = Message.Error(result.ToString());
                return;
            }
            else
            {
                bool b = (bool)result;
                if (b)
                    message = Message.Information("Import completed.");
                else
                    message = Message.Warning("Import interrupted.");
            }

            this.ShowMessageBox(message);
        }

      
    }
}

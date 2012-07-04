using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Data;
using Sys.DataManager;


namespace Sys.Platform.Forms
{
    public partial class InstallWizard : Form
    {
        public InstallWizard()
        {
            InitializeComponent();
        }



        private void wizardControl1_PrevClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {

        }


        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == this.pageWelcome)
            {
                this.pageConnectServer.AllowNext = false;
            }
            else if (e.Page == pageConnectServer)
            {
                this.pageCreateSystemTables.AllowNext = false;
                
                progressCreateSystemTables.ActionButton.Text = "Create System Table";
                progressCreateSystemTables.Action = delegate(Worker worker)
                {
                    Unpacking.CreateTable(Level.System, worker);
                };

                progressCreateSystemTables.Worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs e1)
                {
                    progressCreateSystemTables.ActionButton.Enabled = false;
                    this.pageCreateSystemTables.AllowNext = true;
                };

            }
            else if (e.Page == this.pageCreateSystemTables)
            {
                this.pageUnpackSystemdata.AllowNext = false;

                progressUnpackSystemData.ActionButton.Text = "Unpack System Data";
                progressUnpackSystemData.Action = delegate(Worker worker)
                {
                    Unpacking.Unpack(Level.System, worker, true);
                };

                progressUnpackSystemData.Worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs e1)
                {
                    progressUnpackSystemData.ActionButton.Enabled = false;
                    this.pageUnpackSystemdata.AllowNext = true;
                };
            }
            else if (e.Page == this.pageUnpackSystemdata)
            {
                this.pageCreateService.AllowNext = false;
            }
            else if (e.Page == this.pageCreateService)
            {
                this.pageCreateDefaultTables.AllowNext = false;

                progressCreateDefaultTables.ActionButton.Text = "Create Service Table";
                progressCreateDefaultTables.Action = delegate(Worker worker)
                {
                    Unpacking.CreateTable(Level.Default, worker);
                };

                progressCreateDefaultTables.Worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs e1)
                {
                    progressCreateDefaultTables.ActionButton.Enabled = false;
                    this.pageCreateDefaultTables.AllowNext = true;
                };
            }
            else if (e.Page == this.pageCreateDefaultTables)
            {
                this.pageUnpackDefaultData.AllowNext = false;

                progressUnpackDefaultData.ActionButton.Text = "Unpack Service Data";
                progressUnpackDefaultData.Action = delegate(Worker worker)
                {
                    Unpacking.Unpack(Level.Default, worker, true);
                };

                progressUnpackDefaultData.Worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs e1)
                {
                    progressUnpackDefaultData.ActionButton.Enabled = false;
                    this.pageUnpackDefaultData.AllowNext = true;
                };
            }
        }




        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            if (!sqlServerControl1.Connect())
                return;

            this.pageConnectServer.AllowNext = true;
        }


        #region Create Service/Company

        private void btnCreateService_Click(object sender, EventArgs e)
        {
            string databaseName = this.comboxDefaultDatabase.Text;

            //Check there is a database name
            if (databaseName == string.Empty)
            {
                MessageBox.Show("Please enter a database name");
                return; 
            }

            if (txtServiceName.Text == string.Empty)
            {
                MessageBox.Show("Please enter valid service name");
                return;
            }

            Sys.Security.Company company = new Sys.Security.Company();
            company.CreateService(txtServiceName.Text, databaseName);
            Const.DB_DEFAULT = databaseName;

            txtCreateServiceMessage.Text += string.Format("Serivce [{0}] has been created at {1}.\r\n", txtServiceName.Text, databaseName);

            this.pageCreateService.AllowNext = true;

        }

        private void comboxDefaultDatabase_DropDown(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //Remove old items
                comboxDefaultDatabase.Items.Clear();
                string[] databases = MetaDatabase.GetDatabaseNames();
                foreach (string database in databases)
                {
                    comboxDefaultDatabase.Items.Add(database);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


       

        #endregion

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            this.Close();
        }



    }
}

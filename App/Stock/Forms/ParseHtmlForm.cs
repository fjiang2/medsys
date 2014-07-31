using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sys.Data;
using Sys.ViewManager.Forms;
using Sys.BusinessRules;
using Stock.DpoClass;


namespace Stock.Forms
{
    public partial class ParseHtmlForm : BaseForm
    {
        private DailyFetch dailyFetch = new DailyFetch();

        public ParseHtmlForm()
        {
            InitializeComponent();
            progressBar1.Minimum = 1;

            this.Load += LoadHtmlForm_Load;
            
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnClose.Enabled = true;
        }

        void LoadHtmlForm_Load(object sender, EventArgs e)
        {

        }

        public override void RuleDefinition(ValidateProvider provider)
        {
        }

        private int Count
        {
            get
            {
                return dailyFetch.CompanyTable.Rows.Count;
            }
        }

       
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;


            int i = 1;
            int count = 0;
            foreach (DataRow row in dailyFetch.CompanyTable.Rows)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    CompanyDpo dpo = new CompanyDpo(row);
                    worker.ReportProgress((int)(100.0 * i / Count), new UserState { ith = i, Symbol = dpo.Symbol, Count = count });

                    //如果有新下载的html文件
                    if (dpo.Has_Insider_Transaction && dpo.Last_Processed_Time < dpo.Last_Downloaded_Time)
                    {
                        CompanyHistory company = new CompanyHistory(dpo.Symbol, dpo.CIK, dpo.Last_Downloaded_Time);

                        if (company.ParseTransaction())
                        {

                            foreach (DataRow row1 in company.Ownerships.Rows)
                            {
                                OwnershipDpo dpo1 = new OwnershipDpo(row1);
                                dpo1.Save();
                            }

                            foreach (DataRow row2 in company.Transactions.Rows)
                            {
                                TransactionDpo dpo2 = new TransactionDpo(row2);
                                dpo2.Save();
                            }

                            dpo.Last_Processed_Time = DateTime.Now;
                            dpo.Save();
                            
                            count++;
                        }
                    }

                    i++;

                }
            }

        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UserState state = (UserState)e.UserState;
            int ith =state.ith;
            txtSymbol.Text = state.Symbol;

            progressBar1.Value = ith;
            txtPercentage.Text = string.Format("{0}/{1}", ith, Count);
            lblStatus.Text = string.Format("Converting ... #{0} of file saved", state.Count);
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnStart.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnClose.Enabled = true;


            if ((e.Cancelled == true))
            {
                this.lblStatus.Text = "Converting Canceled!";
            }

            else if (!(e.Error == null))
            {
                this.lblStatus.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.lblStatus.Text = "Converting Completed."; 
            }

          
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            dailyFetch.ReadCompanies();
            progressBar1.Maximum = Count;

            backgroundWorker1.RunWorkerAsync();

            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.btnClose.Enabled = false;

            this.lblStatus.Text = "Converting...";
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();

                //this.btnStart.Enabled = true;
                //this.btnStop.Enabled = false;
                //this.btnClose.Enabled = true;

                this.lblStatus.Text = "Converting is stopped";
            }
            else
                this.lblStatus.Text = "Cannot stop this moment.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Data;
using Sys.ViewManager;
using Sys.ViewManager.Forms;
using DevExpress.XtraReports.UI;

namespace Sys.SmartList.Forms
{
    public partial class ReportMaintenanceForm : BaseForm
    {
        Configuration configuration;
        public ReportMaintenanceForm(Configuration configuration)
        {
            InitializeComponent();

            this.configuration = configuration;

            this.richTextBox1.SelectionChanged += JRichTextBoxPostionDelegate;
            this.richTextBox1.Text = this.configuration.RepxItem.repx;

            this.Text = string.Format("{0} : {1}", Text , configuration.Label);
        }


        private void JRichTextBoxPostionDelegate(object sender, System.EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            this.InformationMessage = new RichText(rtb).ToString(); 
        }

        private void btnBuildReport_Click(object sender, EventArgs e)
        {
            DpoReportStorage.Register(configuration);
            var form = new DevExpress.XtraReports.UserDesigner.XRDesignForm();
            string url = configuration.RepxItem.url;
            form.OpenReport(url);
            form.ShowDialog(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.configuration.RepxItem.repx = this.richTextBox1.Text;

            configuration.RepxItem.Save();
        }
    }
}

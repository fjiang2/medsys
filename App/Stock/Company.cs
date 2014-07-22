using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data;
using System.IO;
using System.Net;

namespace Stock
{
    public class Company
    {
        protected const string LOG_FOLDER = "C:\\log";
        const string searchCompanyFormat = "http://www.sec.gov/cgi-bin/browse-edgar?CIK={0}&Find=Search&owner=exclude&action=getcompany";
        const string getInsiderTransactionFormat = "http://www.sec.gov/cgi-bin/own-disp?action=getissuer&CIK={0}";

        WebClient client = new WebClient();
        private string symbol;

        public string CompanyName { get; private set; }
        public string CIK { get; private set; }
        public bool HasInsiderTransactions { get; private set; }

        public DataTable Fillings { get; private set; }
        public DataTable Ownerships { get; private set; }
        public DataTable Transactions { get; private set; }

        public Company()
        {
        }
        
        public void Download(string symbol)
        {
            this.symbol = symbol;

            GetCompanyInfo();

            //if (this.HasInsiderTransactions)
            //    GetInsiderTransactions(this.CIK);
        }

        public void Download(string symbol, string CIK, bool hasInsiderTransaction)
        {
            this.symbol = symbol;
            this.CIK = CIK;

            if (hasInsiderTransaction)
            {
                GetInsiderTransactions(this.CIK);
                this.HasInsiderTransactions = true;
            }
            else
            {
                GetCompanyInfo();

                if (this.HasInsiderTransactions)
                    GetInsiderTransactions(this.CIK);
            }
        }

        private void GetCompanyInfo()
        {
            Uri uri = new Uri(string.Format(searchCompanyFormat, symbol));
            string html = client.DownloadString(uri);

            var parser = new CompanyHtml(html, HtmlSource.Web);
            parser.ParseHtml();

            this.CompanyName = parser.CompanyName;
            this.CIK = parser.CIK;
            this.Fillings = parser.filling;
            this.HasInsiderTransactions = parser.HasInsiderTransactions;
        
        }

        private void GetInsiderTransactions(string cik)
        {
            Uri uri = new Uri(string.Format(getInsiderTransactionFormat, cik));
            string html = client.DownloadString(uri);

            SaveHtml(string.Format("{0}\\InsiderTransactions\\{1}\\{2}.html", LOG_FOLDER, DateTime.Today.ToString("yyyy-mm-dd"), symbol), html);


            var parser = new InsiderTransactionHtml(html, HtmlSource.Web);
            parser.ParseHtml();

            this.Ownerships = parser.ownership;
            this.Transactions = parser.transaction;
        }

        public static void SaveHtml(string path, string html)
        {
            string folder = Path.GetDirectoryName(path);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            using (var writer = new StreamWriter(path))
            {
                writer.Write(html);
            }
        }
    }
}

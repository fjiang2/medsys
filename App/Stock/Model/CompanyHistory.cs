using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Net;

namespace Stock
{
    public class CompanyHistory
    {
        protected const string LOG_FOLDER = "C:\\db\\edgar";

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


        private string transactionFileName;
        private string companyFileName;

        public CompanyHistory(string symbol, string CIK)
            : this(symbol, CIK, DateTime.Today)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="downloadedDate">used for html file name</param>
        public CompanyHistory(string symbol, string CIK, DateTime downloadedDate)
        {
            this.symbol = symbol;
            this.CIK = CIK;

            this.transactionFileName = MakeFileName("InsiderTransactions", downloadedDate);
            this.companyFileName = MakeFileName("Company", downloadedDate);
        }

        private string MakeFileName(string category, DateTime date)
        {
            return string.Format("{0}\\{1}\\{2}\\{3}.html", LOG_FOLDER, category, date.ToString("yyyy-MM-dd"), symbol);
        }
        
        
        public void DownloadCompanyInfo()
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
        

        
        public bool ParseTransaction()
        {
            if (!File.Exists(transactionFileName))
                return false;

            string html = ReadHtml(transactionFileName);

            var parser = new InsiderTransactionHtml(this.symbol, html, HtmlSource.Web);
            parser.ParseHtml();

            this.Ownerships = parser.ownership;
            this.Transactions = parser.transaction;

            return true;
        }

     

        public void DownloadTransaction()
        {
            if (!File.Exists(this.transactionFileName))
            {
                Uri uri = new Uri(string.Format(getInsiderTransactionFormat, this.CIK));
                string html = client.DownloadString(uri);
                SaveHtml(this.transactionFileName, html);
            }

        }

        
        public static string ReadHtml(string path)
        {
            var reader = new StreamReader(path);
            var html = reader.ReadToEnd();
            return html;
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

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
        const string searchCompanyFormat = "http://www.sec.gov/cgi-bin/browse-edgar?CIK={0}&Find=Search&owner=exclude&action=getcompany";
        const string getInsiderTransactionFormat = "http://www.sec.gov/cgi-bin/own-disp?action=getissuer&CIK={0}";

        WebClient client = new WebClient();
        private string symbol;

        public string CompanyName { get; set; }
        public string CIK { get; set; }

        public DataTable Fillings { get; private set; }
        public DataTable Ownerships { get; private set; }
        public DataTable Transactions { get; private set; }

        public Company(string symbol, bool hasInsiderTransaction)
        {
            this.symbol = symbol;
        }

        public void Download()
        {
            Uri uri = new Uri(string.Format(searchCompanyFormat, symbol));
            string html = client.DownloadString(uri);

            var parser = new CompanyHtml(html, HtmlSource.Web);
            parser.ParseHtml();

            this.CompanyName = parser.CompanyName;
            this.CIK = parser.CIK;
            this.Fillings = parser.filling;

            if (parser.HasInsiderTransactions)
                GetInsiderTransactions(this.CIK);
        }

        private void GetInsiderTransactions(string cik)
        {
            Uri uri = new Uri(string.Format(getInsiderTransactionFormat, cik));
            string html = client.DownloadString(uri);

            var parser = new InsiderTransactionHtml(html, HtmlSource.Web);
            parser.ParseHtml();

            this.Ownerships = parser.ownership;
            this.Transactions = parser.transaction;
        }
    }
}

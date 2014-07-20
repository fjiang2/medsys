using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Net;

namespace App.Stock
{
    public class DailyFetch
    {
        const string searchCompanyFormat = "http://www.sec.gov/cgi-bin/browse-edgar?CIK={0}&Find=Search&owner=exclude&action=getcompany";
        const string getInsiderTransactionFormat = "http://www.sec.gov/cgi-bin/own-disp?action=getissuer&CIK={0}";

        WebClient client = new WebClient();
       

        public DailyFetch()
        {
            Company company = new Company("AIR");
            company.Download();
        }

      

        public static void Test()
        {
            Uri uri = new Uri(@"http://www.sec.gov/cgi-bin/own-disp?action=getowner&CIK=0001213732");
            Uri uri2 = new Uri("http://www.sec.gov/cgi-bin/browse-edgar?action=getcompany&CIK=0001590197");

            //var parser = new App.Stock.HtmlParser(uri);
            //var parser = new App.Stock.HtmlParser("c:\\devel\\html\\Ownership Information ALCOA INC.htm");
            //var table = parser.ToTable();

            //string path = "c:\\devel\\html\\Ownership Information ALCOA INC.htm";
            string path = "c:\\devel\\html\\Ownership Information INTERNATIONAL BUSINESS MACHINES CORP.htm";
            StreamReader reader = new StreamReader(path);
            string html = reader.ReadToEnd();

            var parser = new InsiderTransactionHtml(html, HtmlSource.File);
            parser.ParseHtml();

            path = "c:\\devel\\html\\EDGAR Search Results AIR.htm";
            reader = new StreamReader(path);
            html = reader.ReadToEnd();

            var par1 = new CompanyHtml(html, HtmlSource.File);
            par1.ParseHtml();

            path = "c:\\devel\\html\\EDGAR Search Results-No insider transactions.htm";
            reader = new StreamReader(path);
            html = reader.ReadToEnd();

            var par2 = new CompanyHtml(html, HtmlSource.File);
            par2.ParseHtml();
        }
    }
}

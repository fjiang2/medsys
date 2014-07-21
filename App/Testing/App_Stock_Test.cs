using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Foundation.DpoClass;
using Sys.ViewManager.DpoClass;
using Sys.ViewManager.Security;
using Sys.ViewManager.Forms;
using Sys.Data.Comparison;
using Stock;


namespace App.Testing
{
    class App_Stock_Test
    {

        public static void Test()
        {
            Uri uri = new Uri(@"http://www.sec.gov/cgi-bin/own-disp?action=getowner&CIK=0001213732");
            Uri uri2 = new Uri("http://www.sec.gov/cgi-bin/browse-edgar?action=getcompany&CIK=0001590197");

            //var parser = new App.Stock.HtmlParser(uri);
            //var parser = new App.Stock.HtmlParser("c:\\devel\\html\\Ownership Information ALCOA INC.htm");
            //var table = parser.ToTable();

            //string path = "c:\\devel\\html\\Ownership Information ALCOA INC.htm";
            string html = ReadHtml("c:\\devel\\html\\Ownership Information INTERNATIONAL BUSINESS MACHINES CORP.htm");

            var parser = new InsiderTransactionHtml(html, HtmlSource.File);
            parser.ParseHtml();

            html = ReadHtml("c:\\devel\\html\\EDGAR Search Results AIR.htm");
            var parser1 = new CompanyHtml(html, HtmlSource.File);
            parser1.ParseHtml();

            html = ReadHtml("c:\\devel\\html\\EDGAR Search Results-No insider transactions.htm");
            var parser2 = new CompanyHtml(html, HtmlSource.File);
            parser2.ParseHtml();
        }

        public static string ReadHtml(string path)
        {
            var reader = new StreamReader(path);
            var html = reader.ReadToEnd();
            return html;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

using HtmlAgilityPack;

namespace Stock
{
    public class CompanyHtml : BaseHtml
    {

        public string CompanyName { get; set; }
        public string CIK { get; set; }
        public bool HasInsiderTransactions { get; set; }


        internal DataTable filling = new DataTable();


        public CompanyHtml(string html, HtmlSource source)
            : base(html, source)
        {
            filling.Columns.Add("Fillings", typeof(string));
            filling.Columns.Add("Format", typeof(string));
            filling.Columns.Add("Description", typeof(string));
            filling.Columns.Add("Date", typeof(DateTime));
            filling.Columns.Add("FileNumber", typeof(string));
            
            doc.LoadHtml(html);
        }

        public void ParseHtml()
        {

            ParseCompany();

            var tableNodes = doc.DocumentNode.SelectNodes("//table[@class='tableFile2']");

            ParseFilling(tableNodes[0]);
        }

        private void ParseCompany()
        {
            var companyInfoNodes = doc.DocumentNode.SelectNodes("//div[@class='companyInfo']");
            var companyInfoNode = companyInfoNodes[0];
            var companyInfo = companyInfoNode.SelectNodes("span[@class='companyName']");
            this.CompanyName = companyInfo[0].FirstChild.InnerText;
            var cik = companyInfo[0].SelectNodes("a")[0].InnerText;
            cik = cik.Replace("\r\n", "");
            this.CIK = cik.Replace("(see all company filings)", "").Trim();

            this.HasInsiderTransactions = companyInfoNode.InnerText.Replace("\r\n", "").IndexOf("insider transactions") >= 0;
        }

        private void ParseFilling(HtmlNode node)
        {
            string tag = "tbody/tr";
            if (htmlSource == HtmlSource.Web)
                tag = "tr";

            var rows = node
             .SelectNodes(tag)
             .Select(tr => tr
                 .Elements("td")
                 .Select(td => td.InnerText.Trim())
                 .ToArray()
                 )
             .ToArray();

            foreach (var row in rows.Skip(1))
            {
                DataRow dr = filling.NewRow();
                dr[0] = row[0].Replace("\r\n", "#").Replace("  ", "").Replace("#", " ");
                dr[1] = row[1].Replace("&nbsp;","");
                dr[2] = row[2].Replace("&nbsp;", "");
                dr[3] = DateTime.Parse(row[3]);
                dr[4] = row[4];
                filling.Rows.Add(dr);
            }

        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using Sys.Network;

namespace App.Stock
{
    public class HtmlParser
    {

        HtmlDocument document = new HtmlDocument();
        XmlDocument doc = new XmlDocument();

        public HtmlParser(Uri uri)
        {
            WebClient client = new WebClient();
            string html = client.DownloadString(uri);
            document.LoadHtml(html);
        }

        public HtmlParser(string path)
        {
            //using (StreamReader reader = new StreamReader(path))
            //{
            //    string html = reader.ReadToEnd();
            //    document.LoadHtml(html);
            //}

            //document.Load(path);
            doc.Load(path);
        }

        
        public DataTable ToTable()
        {
            var nodes = document.DocumentNode.SelectNodes("//table/tr");
            var table = new DataTable("MyTable");

            var headers = nodes[0]
                .Elements("th")
                .Select(th => th.InnerText.Trim());
            
            foreach (var header in headers)
            {
                table.Columns.Add(header);
            }

            var rows = nodes.Skip(1).Select(tr => tr
                .Elements("td")
                .Select(td => td.InnerText.Trim())
                .ToArray());

            foreach (var row in rows)
            {
                table.Rows.Add(row);
            }

            return table;
        }

    }
}

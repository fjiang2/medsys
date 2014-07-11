﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

using HtmlAgilityPack;

namespace App.Stock
{
    public class InsiderTransactionHtml
    {
        HtmlDocument doc = new HtmlDocument();

        public string CompanyName { get; set; }
        public string CIK { get; set; }


        DataTable ownership = new DataTable();
        DataTable transaction = new DataTable();

        public InsiderTransactionHtml(string html)
        {
            ownership.Columns.Add("Owner", typeof(string));
            ownership.Columns.Add("Filings", typeof(string));
            ownership.Columns.Add("TransactionDate", typeof(DateTime));
            ownership.Columns.Add("TypeofOwner", typeof(string));


            transaction.Columns.Add("Type", typeof(string));
            transaction.Columns.Add("Date", typeof(DateTime));
            transaction.Columns.Add("ReportingOwner", typeof(string));
            transaction.Columns.Add("Form", typeof(string));
            transaction.Columns.Add("Trans", typeof(string));
            transaction.Columns.Add("Modes", typeof(string));
            transaction.Columns.Add("Shares", typeof(double));
            transaction.Columns.Add("Owned", typeof(double));
            transaction.Columns.Add("No", typeof(string));
            transaction.Columns.Add("OwnerCIK", typeof(string));
            transaction.Columns.Add("SecurityName", typeof(string));
            transaction.Columns.Add("Deemed", typeof(string));


            transaction.Columns.Add("Exercise", typeof(string));
            transaction.Columns.Add("Nature", typeof(string));
            transaction.Columns.Add("Derivative", typeof(string));
            transaction.Columns.Add("SharesUnderlying", typeof(double));
            transaction.Columns.Add("Price", typeof(double));
            transaction.Columns.Add("Expires", typeof(DateTime));
            transaction.Columns.Add("SecurityUnderlying", typeof(string));


            doc.LoadHtml(html);
        }
        

        public void ParseHtml()
        {
            var tableNodes = doc.DocumentNode.SelectNodes("//table");

            ParseCompany(tableNodes[3]);
            ParseOwnerShip(tableNodes[6]);
            ParseTransaction(tableNodes[7]);
        }

        private void ParseCompany(HtmlNode node)
        {
            var rows = node
               .SelectNodes("tbody/tr")
               .Select(tr => tr
                   .Elements("td")
                   .Select(td => td.InnerText.Trim())
                   .ToArray()
                   )
               .ToArray();

            string x = rows[0][0];

            string[] L = x.Split(new char[] { '(' });
            this.CompanyName = L[0];
            this.CIK = L[1].Replace(")", "");
        }

        private void ParseOwnerShip(HtmlNode node)
        {
            //var headers = tableNode
            //    .Elements("th")
            //    .Select(th => th.InnerText.Trim());
            
            var rows = node
                .SelectNodes("tbody/tr")
                .Select(tr => tr
                    .Elements("td")
                    .Select(td => td.InnerText.Trim())
                    .ToArray()
                    )
                .ToArray();

            foreach (var row in rows.Skip(1))
            {
                DataRow dr = ownership.NewRow();
                dr[0] = row[0].Replace("\r\n", "#").Replace("  ", "").Replace("#", " ");
                dr[1] = row[1];
                dr[2] = DateTime.Parse(row[2]);
                dr[3] = row[3].Replace("&amp", "&");
                ownership.Rows.Add(dr);
            }

        }

        private void ParseTransaction(HtmlNode node)
        {
            var heads = node
             .SelectNodes("tbody/tr")
             .Select(tr => tr
                 .Elements("th")
                 .Select(td => td.InnerText.Trim())
                 .ToArray()
                 )
             .ToArray();


            var rows = node
                 .SelectNodes("tbody/tr")
                 .Select(tr => tr
                     .Elements("td")
                     .Select(td => td.InnerText.Trim())
                     .ToArray()
                     )
                 .ToArray();

            int i = 2;
            while (i < rows.Length)
            {
                int k = 0;
                var row = rows[i];
                DataRow dr = transaction.NewRow();
                dr["Type"] = row[k++];
                dr["Date"] = DateTime.Parse(row[k++]);
                dr["ReportingOwner"] = row[k++];
                dr["Form"] = row[k++];
                dr["Trans"] = row[k++];
                dr["Modes"] = row[k++];
                dr["Shares"] = double.Parse(row[k++]);
                k++;
                dr["Owned"] = double.Parse(row[k++]);
                dr["No"] = row[k++];
                dr["OwnerCIK"] = row[k++];
                dr["SecurityName"] = row[k++];
                dr["Deemed"] = row[k++];
                
                i++;
                if (i < rows.Length)
                {
                    row = rows[i];
                    if (row[0] == "")
                    {
                        k = 1;
                        dr["Exercise"] = row[k++];
                        dr["Nature"] = row[k++];
                        dr["Derivative"] = row[k++];
                        dr["SharesUnderlying"] = ParseDouble(row[k++]);
                        dr["Price"] = ParseDouble(row[k++]);
                        k++;
                        k++;
                        dr["Expires"] = ParseDate(row[k++]);
                        dr["SecurityUnderlying"] = row[k++];

                        i++;
                    }
                }

                transaction.Rows.Add(dr);
            }
        }

        private object ParseDouble(string value)
        {
            if (value == "")
                return DBNull.Value;

            if (value.StartsWith("$"))
                value = value.Substring(1);
                
            return double.Parse(value);
        }

        private object ParseDate(string value)
        {
            if (value == "" || value=="-")
                return DBNull.Value;
            else
                return DateTime.Parse(value);
        }

        void xx()
        {
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Value", typeof(decimal));

            int count = 0;
            decimal rowValue = 0;
            bool isDecimal = false;
            foreach (var row in doc.DocumentNode.SelectNodes("//table[@summary='Table Name']/tbody/tr"))
            {
                DataRow dr = dt.NewRow();
                foreach (var cell in row.SelectNodes("td"))
                {
                    if ((count % 2 == 0))
                    {
                        dr["Name"] = cell.InnerText.Replace("&nbsp;", " ");
                    }
                    else
                    {
                        isDecimal = decimal.TryParse((cell.InnerText.Replace(".", "")).Replace(",", "."), out rowValue);
                        if (isDecimal)
                        {
                            dr["Value"] = rowValue;
                        }
                        dt.Rows.Add(dr);
                    }
                    count++;
                }
            }
        }

      
    }
}

using System;
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
    public class ParseHtml
    {
        protected HtmlDocument doc = new HtmlDocument();


        protected ParseHtml(string html)
        {
            doc.LoadHtml(html);
        }


        protected object ParseDouble(string value)
        {
            if (value == "")
                return DBNull.Value;

            if (value.StartsWith("$"))
                value = value.Substring(1);

            return double.Parse(value);
        }

        protected object ParseDate(string value)
        {
            if (value == "" || value == "-")
                return DBNull.Value;
            else
                return DateTime.Parse(value);
        }
    }
}

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
    public enum HtmlSource
    {
        File,
        Web
    }

    public class BaseHtml
    {

        //const string getInsiderTransactionFormat = "http://www.sec.gov/cgi-bin/own-disp?action=getissuer&CIK={0}";
        //const string getInsiderTrasctionIssuer = "http://www.sec.gov/cgi-bin/own-disp?action=getissuer&CIK=0001144215";
        //const string getInsiderTrasctionReportingOwner = "http://www.sec.gov/cgi-bin/own-disp?action=getissuer&CIK=0001144215";


        protected string html;
        protected HtmlDocument doc = new HtmlDocument();
        protected HtmlSource htmlSource;

        protected BaseHtml(string html, HtmlSource source)
        {
            this.html = html;
            doc.LoadHtml(html);
            this.htmlSource = source;

        }

        protected object ParseString(string value, int length)
        {
            if (value.Length < length)
                return value;

            return value.Substring(0, length-3) + "...";
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
            if (value == "" || value == "-" || value =="0000-00-00" )
                return DBNull.Value;
            else
                return DateTime.Parse(value);
        }

        
     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.CodeBuilder
{
    class Format
    {
        protected int tab = 0;
        protected StringBuilder code = new StringBuilder();

        private static string[] TABS = new string[] { "", "\t", "\t\t", "\t\t\t", "\t\t\t\t", "\t\t\t\t\t" };
        public Format()
        { 
        
        }

        public Format Add(string str)
        {
            code.Append(TAB).AppendLine(str);
            return this;
        }

        public Format AddFormat(string format, params object[] args)
        {
            code.Append(TAB).AppendFormat(format, args).AppendLine();
            return this;
        }

        protected string Tab(int n)
        {
            return new string('\t', n);
        }

        public string TAB
        {
            get
            {
                if (tab < TABS.Length)
                    return TABS[tab];

                return new string('\t', tab);
            }
        }

        public override string ToString()
        {
            return code.ToString();
        }
    }
}

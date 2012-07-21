using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.CodeBuilder
{
    class Statements : List<string>
    {
        int tab;

        public Statements(int tab)
        {
            this.tab = tab;
        }

        public string Code
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                string TAB1 = new string('\t', tab);
                string TAB2 = new string('\t', tab + 1);

                sb.Append(TAB1).AppendLine("{");
                foreach (string sent in this)
                {
                    if (sent == "")
                        sb.AppendLine();
                    else
                        sb.Append(TAB2).Append(sent).AppendLine(";");
                }

                sb.Append(TAB1).AppendLine("}");
                return sb.ToString();
            }
        }

        public override string ToString()
        {
            return Code;
        }
    }
}

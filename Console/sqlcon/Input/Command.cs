using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlcon
{
    class Command
    {
        public readonly bool badcommand = false;
        public string wildcard { get; private set; }
        public string[] Segments { get; set; }

        public string Action { get; private set; }
        public string args { get; private set; }
        public string arg1 { get; private set; }
        public string arg2 { get; private set; }


        public readonly bool HasHelp;
        public readonly bool IsStruct;
        public readonly bool IsVertical;
        public readonly bool HasWhere;
        public readonly bool HasPage;

        public readonly int top;

        public Command(string line, Configuration cfg)
        {
            this.wildcard = null;
            this.Segments = new string[0];
            this.IsStruct = false;
            this.IsVertical = false;
            this.top = cfg.Limit_Top;

            if (string.IsNullOrEmpty(line))
                return;


            int k = parseAction(line);
            this.args = line.Substring(k);

            string[] L;
            this.badcommand = !parseArgument(this.args, out L);

            if (L.Length > 0)
                this.arg1 = L[0];

            if (L.Length > 1)
                this.arg2 = L[1];

            for (int i = 0; i < L.Length; i++)
            {
                string a = L[i];
                switch (a)
                {
                    case "/s":
                        IsStruct = true;
                        break;

                    case "/t":
                        IsVertical = true;
                        break;

                    case "/w":
                        HasWhere = true;
                        break;

                    case "/p":
                        HasPage = true;
                        break;

                    case "/all":
                        top = 0;
                        break;

                    case "/?":
                        HasHelp = true;
                        break;

                    default:
                        if (a.StartsWith("/"))
                        {
                            if (a.StartsWith("/top"))
                                int.TryParse(a.Substring(4), out top);
                        }
                        else
                        {
                            if (this.Segments.Length == 0)
                                this.Segments = parsePath(a);
                            else
                            {
                                this.badcommand = true;
                            }
                        }
                        break;
                }
            }
        }

        private int parseAction(string line)
        {
            int k = 0;
            char[] buf = new char[200];
            while (k < line.Length)
            {
                if (line[k] == ' ' || line[k] == '.' || line[k] == '\\' || line[k] == '"')
                {
                    break;
                }

                buf[k] = line[k];
                k++;
            }

            this.Action = new string(buf, 0, k).ToLower();
            while (k < line.Length && line[k] == ' ')
                k++;
            return k;
        }


        private bool parseArgument(string args, out string[] result)
        {
            if (args.Length == 0)
            {
                result = new string[] { };
                return true;
            }

            List<string> L = new List<string>();

            char[] buf = new char[5000];
            int k = 0;
            int i = 0;

            while (k < args.Length)
            {
                if (args[k] == ' ')
                {
                    if (i > 0)
                    {
                        L.Add(new string(buf, 0, i));
                        i = 0;
                    }
                }
                else if (args[k] == '"')
                {
                    k++;
                    while (k < args.Length && args[k] != '"')
                    {
                        buf[i++] = args[k];
                        k++;
                    }

                    if (k == args.Length)
                    {
                        stdio.ShowError("Unclosed quotation mark after the character string \"");
                        result = new string[] { };
                        return false;
                    }

                    L.Add(new string(buf, 0, i));
                    i = 0;
                }
                else
                    buf[i++] = args[k];

                k++;
            }

            if (i > 0)
                L.Add(new string(buf, 0, i));

            result = L.ToArray();
            return true;
        }

        private string[] parsePath(string path)
        {
            this.wildcard = null;

            if (string.IsNullOrEmpty(path))
                return new string[0];

            string[] segments = path.Split('\\');
            int n1 = 0;
            int n2 = segments.Length - 1;

            if (string.IsNullOrEmpty(segments[n1]))
                segments[n1] = "\\";

            if (segments[n2] == "")
                return segments.Take(n2).ToArray();

            if (segments[n2].IndexOf('*') >= 0 || segments[n2].IndexOf('?') >= 0)
            {
                wildcard = segments[n2];
                return segments.Take(n2).ToArray();
            }

            return segments;
        }
    }
}

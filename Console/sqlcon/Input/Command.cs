using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlcon
{
    class Command
    {
        public string wildcard { get; private set; }
        public string[] Segments { get; set; }

        public string Action { get; private set; }
        public string arg1 { get; private set; }
        public string arg2 { get; private set; }


        public readonly bool HasHelp;
        public readonly bool IsStruct;
        public readonly bool IsVertical;
        public readonly bool HasWhere;

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

            string[] L = new string[0];
            if (line.StartsWith("cd.") || line.StartsWith("cd\\"))
            {
                this.Action = "cd";
                L = line.Substring(2).Split(' ');
            }
            else
            {
                int index = line.IndexOf(' ');
                if (index > 0)
                {
                    this.Action = line.Substring(0, index).ToLower();
                    if (line.Length > index + 1)
                        L = line.Substring(index + 1).Split(' ');
                }
                else
                {
                    this.Action = line;
                }
            }

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
                            this.Segments = parsePath(a);
                        }
                        break;
                }
            }
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

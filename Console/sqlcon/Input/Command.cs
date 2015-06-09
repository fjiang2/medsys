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
        public string[] Segments { get; private set; }

        public bool HasHelp { get; private set; }

        public bool IsStruct { get; private set; }
        public bool IsVertical { get; private set; }

        public string Action { get; private set; }

        public string arg1 { get; private set; }
        public string arg2 { get; private set; }

        public Command(string line)
        {
            this.wildcard = null;
            this.Segments = new string[0];
            this.IsStruct = false;
            this.IsVertical = false;

            if (string.IsNullOrEmpty(line))
                return;

            string[] L = line.Split(' ');
            if (L.Length == 0)
                return;
            
            this.Action = L[0].ToLower();
            if (L.Length > 1)
                this.arg1 = L[1];

            if (L.Length > 2)
                this.arg2 = L[2];

            for (int i = 1; i < L.Length; i++)
            {
                switch (L[i])
                {
                    case "/s":
                        IsStruct = true;
                        break;

                    case "/t":
                        IsVertical = true;
                        break;

                    case "/?":
                        HasHelp = true;
                        break;

                    default:
                        this.Segments = parsePath(L[i]);
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

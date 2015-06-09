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

        public Command(string line)
        {
            this.wildcard = null;
            this.Segments = new string[0];
            this.IsStruct = false;
            this.IsVertical = false;

            if (string.IsNullOrEmpty(line))
                return;

            string[] L = line.Split(' ');
            foreach (string l in L)
            {
                switch (l)
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
                        this.Segments = parsePath(line);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlcon
{
    class PathName
    {
        public readonly string wildcard = null;
        public readonly string name = null;
        private string[] fullSegments = new string[0];
        public readonly string[] segments = new string[0];

        public PathName(string fullName)
        {

            if (string.IsNullOrEmpty(fullName))
                fullSegments = new string[0];

            else
            {
                fullSegments = fullName.Split('\\');
                int n1 = 0;
                int n2 = fullSegments.Length - 1;

                if (string.IsNullOrEmpty(fullSegments[n1]))
                    fullSegments[n1] = "\\";

                if (fullSegments[n2] == "")
                {
                    wildcard = null;
                    name = null;
                    fullSegments = fullSegments.Take(n2).ToArray();
                    segments = fullSegments;
                }
                else if (fullSegments[n2].IndexOf('*') >= 0 || fullSegments[n2].IndexOf('?') >= 0)
                {
                    wildcard = fullSegments[n2];
                    name = null;
                    fullSegments = fullSegments.Take(n2).ToArray();
                    segments = fullSegments;
                }
                else
                {
                    wildcard = null;
                    name = fullSegments[n2];
                    segments = fullSegments.Take(n2).ToArray();
                }
            }
        }


        public string[] FullSegments
        {
            get
            {
                return this.fullSegments;
            }
        }
    }
}

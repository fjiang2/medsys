using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X12.File
{
    public class LoopName
    {
        string name;

        public LoopName(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public override string ToString()
        {
            return this.name;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return name.Equals(((LoopName)obj).Name);
        }
    }
}

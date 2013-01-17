using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X12.File
{
    public class SegmentName
    {
        public static SegmentName DefaultName = new SegmentName("C");

        string name;

        public SegmentName(string name)
        {
            this.name = name;
        }

        public SegmentName(SegmentType type)
        {
            this.name = type.ToString();
        }

        public string Name
        {
            get { return this.name; }
        }

        public SegmentType Type
        {
            get { return (SegmentType)Enum.Parse(typeof(SegmentType), this.name); }
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
            return name.Equals(((SegmentName)obj).name);
        }
    }
}

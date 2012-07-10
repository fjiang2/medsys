using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public class RevisionAttribute :Attribute
    {
        long revision;

        public RevisionAttribute(int ver)
        {
            this.revision = ver;
        }

        public long Revision { get { return this.revision; } }

        public override string ToString()
        {
            return string.Format("Revision={0}", revision);
        }
    }
}

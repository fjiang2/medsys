using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X12.File
{
    class SegmentLineCollection : List<SegmentLine>
    {
        LoopLine loop;

        internal SegmentLineCollection(LoopLine loop)
        {
            this.loop = loop;
        }


        public LoopLine Loop
        {
            get { return this.loop; }
        }



        public override string ToString()
        {
            return string.Join<SegmentLine>("\n", this);
        }
    }
}

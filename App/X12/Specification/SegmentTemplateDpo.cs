using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X12.DpoClass;
using Sys.Data;
using System.Data;
using Sys;

namespace X12.Specification
{
    class SegmentTemplateDpo : X12SegmentTemplateDpo
    {
        public SegmentTemplateDpo()
        { 
        }

        public SegmentTemplateDpo(DataRow dataRow)
            :base(dataRow)
        {
        }

        public override string ToString()
        {
            return string.Format("0 - 1", this.Name, this.Description.ToSentence());
        }
    }
}

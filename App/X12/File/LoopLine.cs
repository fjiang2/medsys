using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys;
using X12.Specification;

namespace X12.File
{
    public class LoopLine
    {
        private LoopName name;
        private SegmentLineCollection segments;

        public LoopLine(LoopName name)
        {
            this.name = name;
            this.segments = new SegmentLineCollection(this);
        }

        public LoopName Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// All segments of this loop
        /// </summary>
        internal SegmentLineCollection Segments
        {
            get { return this.segments; }
        }

        /// <summary>
        /// One loop may have many segments with same segment name
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public SegmentLine[] this[SegmentName segment]
        {
            get
            {
                return this.segments.Where(line => line.SegmentName == segment.Name).ToArray();
            }
        }

        public DataElement[] this[SegmentName segment, int ordinal]
        {
            get
            {
                return this.segments.Where(line => line.SegmentName == segment.Name).Select(line => line[ordinal]).ToArray();
            }
        }

        public bool HasSegment(SegmentName segment)
        {
            foreach (SegmentLine line in this.segments)
            {
                if (line.SegmentName == segment.Name)
                    return true;
            }

            return false;
        }

        public string Text
        {
            get 
            {
                if (this.name.Name == "ERROR")
                    return string.Format("ERROR (line:{0})",this.segments[0].LineNumber);

                var theLoop = Spec5010A.Instance.GetLoopTemplates().Where(dpo => dpo.Name == this.name.Name).First();
                if (this.segments.Count != 0)
                    return string.Format("{0} - {1} (line:{2} +{3})",
                        this.name,
                        theLoop.Description.ToSentence(),
                        this.segments[0].LineNumber,
                        this.segments.Count);
                else
                {
                    return string.Format("{0} - {1}",
                          this.name,
                          theLoop.Description.ToSentence());
                }
            }
        }

        public override string ToString()
        {
            return name.ToString();
        }
    }
}

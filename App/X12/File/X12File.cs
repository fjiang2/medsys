using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys;
using X12.DpoClass;
using X12.Specification;

namespace X12.File
{
    public class X12File : X12Base
    {
        Parser parser;

        public X12File(string fileName)
            : base(fileName)
        {
        }

        public void Parse(Worker worker)
        {
            this.parser = new Parser(lines, worker);
            parser.Parse();
        }

        public MessageBuilder Messages
        {
            get { return this.parser.Messages; }
        }

        public string[] Segments
        {
            get
            {
                string[] segments = lines.AsEnumerable().Select(line => line.SegmentName).Distinct().ToArray();
                return segments;
            }
        }

        public Tree<LoopLine> Consumer
        {
            get { return this.parser.Consumer; }
        }


        private IEnumerable<SegmentLine> GetSegmentLines(SegmentName segment)
        {
            var segLines = this.lines.Where(line => line.SegmentName == segment.Name);
            if (segLines.Count() == 0)
                segLines = this.lines;
            return segLines;
        }

        private IEnumerable<SegmentLine> GetSegmentLines(LoopName loop)
        {
            var segLines = this.lines.Where(line => line.LoopName == loop.Name);
            return segLines;
        }

        public string ToText(SegmentName segment)
        {
            var segLines = GetSegmentLines(segment);

            return string.Join<SegmentLine>("\n", segLines);
        }

        public string ToText(LoopName loop)
        {
            var segLines = GetSegmentLines(loop);

            return string.Join<SegmentLine>("\n", segLines);
        }

        public DataTable ToTable(SegmentName segment)
        {
            IEnumerable<SegmentLine> segLines = GetSegmentLines(segment);
            return ToTable(segLines, segment);
        }

        public DataTable ToTable(LoopName loop)
        {
            SegmentName segment = SegmentName.DefaultName;
            IEnumerable<SegmentLine> segLines = GetSegmentLines(loop);
            return ToTable(segLines, segment);
        }


        public DataTable ToTable(IEnumerable<SegmentLine> segLines, SegmentName segment)
        {
            int max = 0;
            foreach (SegmentLine line in segLines)
            {
                if (line.Count > max)
                    max = line.Count;
            }

            DataTable dt = new DataTable();
            DataColumn column;
            column = new DataColumn("Line", typeof(int));           dt.Columns.Add(column);
            column = new DataColumn("Loop", typeof(string));        dt.Columns.Add(column);
            column = new DataColumn("Segment", typeof(string));     dt.Columns.Add(column);

            for (int i = 1; i < max; i++)
            {
                column = new DataColumn(string.Format("{0}{1:00}", segment, i), typeof(string));
                dt.Columns.Add(column);
            }

          

            foreach (SegmentLine line in segLines)
            {
                DataRow row = dt.NewRow();
                line.ToDataRow(row);
                dt.Rows.Add(row);
            }

            dt.AcceptChanges();

            return dt;
        }
    }
}

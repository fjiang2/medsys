using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using X12.Specification;

namespace X12.File
{
    public class SegmentLine : List<DataElement>
    {
        public const char ELEMENT_DELIMITER = '*';
        public const char SEGMENT_DELIMITER = '~';
        public const int _LINEWIDTH = 6;
        public const int _LOOPWIDTH = 6;


        private int lineNumber;     //line number
        
        //result of parsing
        private string loopName;
        private SegmentInstanceDpo segment;

        public SegmentLine(int lineNumber)
        {
            this.lineNumber = lineNumber;
            this.loopName = "";
        }

        public SegmentLine(string lineWithNumber)
            : this(int.Parse(lineWithNumber.Substring(0, _LINEWIDTH)), lineWithNumber.Substring(_LINEWIDTH + _LOOPWIDTH + 2))
        {
            this.loopName = lineWithNumber.Substring(_LINEWIDTH + 1, _LOOPWIDTH).Trim();
        }

        public SegmentLine(int lineNumber, string line)
        {

            this.lineNumber = lineNumber;
            this.loopName = "";

            string[] elements = line.Split(new char[] { ELEMENT_DELIMITER });

            for (int i = 0; i < elements.Length; i++)
                this.Add(new DataElement(i, elements[i]));

        }

        public string LoopName
        {
            get { return this.loopName; }
            set { this.loopName = value; }
        }

        internal SegmentInstanceDpo Segment
        {
            get { return this.segment; }
            set { this.segment = value; }
        }

        public int LineNumber
        {
            get { return this.lineNumber; }
        }

        public string SegmentName
        {
            get
            {
                return (string)this[0].Value;
            }
        }

        public SegmentName Name
        {
            get { return new SegmentName(SegmentName); }
        }


        public void AddElement(string element)
        {
            this.Add(new DataElement(this.Count, element));
        }
        
        public string Text
        {
            get
            {
                return string.Join<DataElement>(new string(new char[]{ELEMENT_DELIMITER}), this);
            }
        }


        public void ToDataRow(DataRow row)
        {
            row[0] = lineNumber;
            row[1] = loopName;
            for (int i = 0; i < this.Count; i++)
                row[i + 2] = this[i].Value;
        }

        public void ToLine(DataRow row)
        {
            //find the last non-null element
            int count = row.Table.Columns.Count;
            for (int i = row.Table.Columns.Count - 1; i > 1; i--)       //row[0] -> number of line#
            {
                if (!row.IsNull(i))
                {
                    count = i;
                    break;
                }
            }

            count--;    //remove Column:Line, Column:Loop
            
            //add extra elements
            for (int i = 0; i < count; i++)
            {
                int k = i + 2;
                if (i < this.Count)
                    this[i] = new DataElement(i, row[k]);
                else
                { 
                    if(row.IsNull(k))
                        this.Add(new DataElement(i));
                    else
                        this.Add(new DataElement(i, row[k]));
                }
            }
        }



        public override string ToString()
        {
            return string.Format("{0:000000} {1,-6} {2}", lineNumber, loopName, Text);
        }

    }
}

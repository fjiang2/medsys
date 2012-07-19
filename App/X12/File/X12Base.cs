using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace X12.File
{
    public class X12Base
    {
        string fileName;
        protected List<SegmentLine> lines;


        public X12Base(string fileName)
        {
            this.fileName = fileName;

            StreamReader sr = new StreamReader(fileName);
            string x12 = sr.ReadToEnd();
            sr.Close();

            Initialize(x12);

        }

        protected void Initialize(string x12)
        {

            x12 = x12.Replace("\r\n", "").Replace("\n", "").Trim();

            string[] L = x12.Split(new char[] { SegmentLine.SEGMENT_DELIMITER }, StringSplitOptions.RemoveEmptyEntries);

            this.lines = new List<SegmentLine>();
            for (int i = 0; i < L.Length; i++)
            {
                this.lines.Add(new SegmentLine(i + 1, L[i]));
            }
        }

        protected string Finalize()
        {
            string wave = new string(new char[] { SegmentLine.SEGMENT_DELIMITER });
            return string.Join(wave, lines.Select(line => line.Text)) + wave;
        }

        public void RemoveLine(int number)
        {
            lines.RemoveAt(number - 1);
            Initialize(Finalize());
            this[SegmentType.SE][0][1].Value = System.Convert.ToString(int.Parse(this[SegmentType.SE][0][1].Text) - 1);
        }

        public void InsertLine(int number, string line)
        {
            this.lines.Insert(number - 1, new SegmentLine(number, line));

            lines.RemoveAt(number - 1);
            Initialize(Finalize());
            this[SegmentType.SE][0][1].Value = System.Convert.ToString(int.Parse(this[SegmentType.SE][0][1].Text) + 1);
        }

        public string FileName
        {
            get { return this.fileName; }
        }


        public SegmentLine this[int lineNumber]
        {
            get
            {
                return this.lines[lineNumber-1];
            }
            set 
            {
                this.lines[ lineNumber-1 ] = value;
            }
        }

        public SegmentLine[] this[LoopName loop]
        {
            get
            {
                return this.lines.Where(line => line.LoopName == loop.Name).ToArray();
            }
        }

        public SegmentLine[] this[SegmentName segmentName]
        {
            get
            {
                return this.lines.Where(segment => segment.Name.Equals(segmentName)).ToArray();
            }
        }

        public SegmentLine[] this[SegmentType segmentType]
        {
            get
            {
                return this.lines.Where(segment => segment.Name.Type == segmentType).ToArray();
            }
        }

        public int TotoalLine
        {
            get { return this.lines.Count; }
        }

        public string Text
        {
            get
            {
                return string.Join<SegmentLine>("\n", lines);
            }
        }

        public void SaveAs(string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(Finalize());
            sw.Close();
        }

        public void Save()
        {
            SaveAs(this.fileName);
        }



  
    }
}

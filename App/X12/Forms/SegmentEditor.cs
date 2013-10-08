using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using X12.File;

namespace X12.Forms
{
    public partial class SegmentEditor : Form
    {
        public SegmentEditor(SegmentLine segmentLine)
        {
            InitializeComponent();
            
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(SegmentEditor_KeyDown);

            segmentEdit1.SegmentLine = segmentLine;
            this.Text = string.Format("Line={0}, {1} {2}", segmentLine.LineNumber, segmentLine.LoopName, segmentLine.Segment.Text);
        }

        void SegmentEditor_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Escape)
           {
               e.Handled = true;
               this.Close();
           }
        }
    }
}

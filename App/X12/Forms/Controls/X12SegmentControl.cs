using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using X12.File;

namespace X12.Forms
{

    /// <summary>
    /// support two way editing either edit text or grid
    /// </summary>
    public partial class X12SegmentControl : UserControl
    {
        private X12File x12;
        private SegmentName segment;
        private LoopName loop;
        
        enum Flag { None, Text, Row };
        Flag flag = Flag.None;

        public X12SegmentControl()
        {
            InitializeComponent();
        }

        public bool AllowCellMerge
        {
            get
            {
                return this.gridView1.OptionsView.AllowCellMerge;
            }
            set
            {
                this.gridView1.OptionsView.AllowCellMerge = value;
            }
        }

        public int SetDataSource(X12File x12, SegmentName segment)
        {
            this.x12 = x12;
            this.segment = segment;

            string text = x12.ToText(segment);
            DataTable table = x12.ToTable(segment);

            return Init(text, table);
        }

        public int SetDataSource(X12File x12, LoopName loop)
        {
            this.x12 = x12;
            this.loop = loop;

            string text = x12.ToText(loop);
            DataTable table = x12.ToTable(loop);

            return Init(text, table);
        }


        public int SetDataSource(X12File x12, LoopLine loop)
        {
            this.x12 = x12;

            string text = string.Join<SegmentLine>("\n", loop.Segments); ;
            SegmentName segment = SegmentName.DefaultName;
            DataTable table = x12.ToTable(loop.Segments, segment);

            return Init(text, table);
        }

        private int Init(string text, DataTable table)
        {
            gridView1.Columns.Clear();
            table.RowChanged += new DataRowChangeEventHandler(table_RowChanged);

            richTextBox1.Text = text;
            GridForm.InitializeGridViewColumns(gridControl1, gridView1, table);

            return table.Rows.Count;
        }

        void table_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (this.flag == Flag.Text)
                return;

            this.flag = Flag.Row;

            if (e.Row.RowState == DataRowState.Modified)
            { 
                int number = (int)e.Row[0];
                SegmentLine line = x12[number];
                line.ToLine(e.Row);

                if(this.segment !=null )
                    richTextBox1.Text = x12.ToText(segment);
                else if(this.loop != null)
                    richTextBox1.Text = x12.ToText(loop);

                e.Row.AcceptChanges();
            }

            this.flag = Flag.None;
        }

     

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.flag == Flag.Row)
                return;

            this.flag = Flag.Text;

            string[] lines = richTextBox1.Text.Split(new char[]{'\n'});
            foreach (string line in lines)
            {
                SegmentLine seg = new SegmentLine(line);
                
                if (!this.x12[seg.LineNumber].Text.Equals(seg.Text))
                {
                    this.x12[seg.LineNumber] = seg;
                    DataTable table = (DataTable)gridControl1.DataSource;
                    foreach (DataRow row in table.Rows)
                    {
                        if ((int)row[0] == seg.LineNumber)
                        {
                            seg.ToDataRow(row);
                            break;
                        }
                    }
                    
                    break;
                }
            }

            this.flag = Flag.None;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow = Sys.ViewManager.DevEx.Grid.GetGridClickEx(this.gridView1, sender);
            if (dataRow != null)
            {
                int lineNumber = (int)dataRow[0];
                SegmentLine segmentLine = this.x12[lineNumber];

                //not compiled yet
                if (segmentLine.Segment == null)
                    return;

                SegmentEditor editor = new SegmentEditor(segmentLine);
                editor.ShowDialog(this);
                return;
            }
        }


    }
}

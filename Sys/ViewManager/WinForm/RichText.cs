using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sys.ViewManager.Forms
{
    public class RichText
    {
           
        RichTextBox rtf;

        public RichText(RichTextBox rtf)
        {
            this.rtf = rtf;
        }

        public void WriteTime(DateTime time)
        {
            rtf.SelectionStart = rtf.Text.Length;
            rtf.SelectionColor = Color.Gray;
            rtf.SelectionAlignment = HorizontalAlignment.Right;
            rtf.AppendText(time.TimeAgoStamp());
            NewLine();
        }

        public void WriteText(string text)
        {
            if (text == null)
                return;

            rtf.AppendText(text);
        }


        public void WriteTitle(string title)
        {
            if (title == null)
                return;

            rtf.SelectionColor = Color.Black;
            rtf.SelectionAlignment = HorizontalAlignment.Left;
            Font font = rtf.SelectionFont;
            rtf.SelectionFont = new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Underline | FontStyle.Bold);
            rtf.AppendText(title);
            rtf.SelectionFont = font;
            NewLine();
        }

        public void WriteComment(string comment)
        {
            if (comment == null)
                return;

            rtf.SelectionAlignment = HorizontalAlignment.Left;
            rtf.AppendText(comment);
            NewLine();
            NewLine();
        }

        public void NewLine()
        {
            rtf.AppendText("\r\n");
        }

        #region Line/Column/Position

        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int GetCaretPos(ref Point lpPoint);

        private int GetCorrection(int index)
        {
            Point pt1 = Point.Empty;
            GetCaretPos(ref pt1);
            Point pt2 = rtf.GetPositionFromCharIndex(index);

            if (pt1 != pt2)
                return 1;
            else
                return 0;
        }

        public int Line
        {
            get
            {
                return GetLine(rtf.SelectionStart);
            }
        }

        public int Column
        {
            get
            {
                return GetColumn(rtf.SelectionStart);
            }
        }

        public int Position
        {
            get { return rtf.SelectionStart; }
        }

        private int GetLine(int index)
        {
            int correction = GetCorrection(index);
            return rtf.GetLineFromCharIndex(index) - correction + 1;
        }

        private int GetColumn(int index1)
        {
            int correction = GetCorrection(index1);
            Point p = rtf.GetPositionFromCharIndex(index1 - correction);

            if (p.X == 1)
                return 1;

            p.X = 0;
            int index2 = rtf.GetCharIndexFromPosition(p);

            int col = index1 - index2 + 1;

            return col;
        }

        #endregion


        public void GotoLine(string lineDelimiter, int line, Color color)
        {
            string text = rtf.Text;

            int start = 0;
            while (line > 1)
            {
                start = text.IndexOf(lineDelimiter, start) + 1;
                line--;
            }

            int end = text.IndexOf(lineDelimiter, start);
            rtf.SelectionStart = start;
            rtf.SelectionLength = end - start;
            rtf.SelectionColor = color;
            rtf.SelectionLength = 0;
            rtf.Focus();
        }

        
        public override string ToString()
        {
            return  string.Format("Ln {0}, Col {1}, Pos {2}", this.Line, this.Column, this.Position);
        }

   
    }
}

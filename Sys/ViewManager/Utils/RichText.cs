using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sys.ViewManager.Utils
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

    


    }
}

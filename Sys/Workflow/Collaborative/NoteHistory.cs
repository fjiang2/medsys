using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace Sys.Workflow.Collaborative
{
    class NoteHistory
    {
        RichTextBox rtf;
        string stateName;

        public NoteHistory(RichTextBox rtf, string stateName)
        {
            this.rtf = rtf;
            this.stateName = stateName;
        }


        public void AddNote(NoteDpo dpo)
        {

            Sys.Security.Account account = Sys.Security.Account.CurrentUser;
            string name = string.Format("{0} {1} ({2})", account.FirstName, account.LastName, account.UserName);
            WriteName(name);
            WriteStates(dpo.S1_Name, dpo.S2_Name);

            rtf.SelectionColor = Color.Gray;
            rtf.SelectionAlignment = HorizontalAlignment.Right;
            rtf.AppendText(DateTime.Now.TimeStamp());
            rtf.AppendText("\r\n");

            rtf.SelectionColor = CommentColor(dpo.S1_Name, dpo.S2_Name);
            WriteComment(dpo.Comment);

        }

        public void WriteNote(string name, string S1, string S2, DateTime time, string comment)
        {
            WriteName(name);
            WriteStates(S1, S2);

            rtf.SelectionStart = rtf.Text.Length;
            rtf.SelectionColor = Color.Gray;
            rtf.SelectionAlignment = HorizontalAlignment.Right;
            rtf.AppendText(time.TimeAgoStamp());
            rtf.AppendText("\r\n");

            rtf.SelectionColor = CommentColor(S1, S2);
            WriteComment(comment);

        }

        private Color CommentColor(string S1, string S2)
        {
            if (S1 == S2)
                return Color.Black;

            //sent
            if (S1 == stateName)
                return Color.Blue;

            //received
            if (S2 == stateName)
                return Color.Brown;

            return Color.Black;
        }

        private void WriteName(string name)
        {
            rtf.SelectionColor = Color.Black;
            rtf.SelectionAlignment = HorizontalAlignment.Left;
            Font font = rtf.SelectionFont;
            rtf.SelectionFont = new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Underline);
            rtf.AppendText(name);
            rtf.SelectionFont = font;
        }

        private void WriteStates(string S1, string S2)
        {
            Font font = rtf.SelectionFont;
            rtf.SelectionFont = new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Italic);
            rtf.SelectionAlignment = HorizontalAlignment.Left;
            rtf.SelectionColor = Color.Gray;

            if(S1==S2)
                rtf.AppendText(" wrote note:\r\n");
            else if (S1 == stateName)
                rtf.AppendText(string.Format(" wrote to [{0}]: \r\n", S2));
            else if (S2 == stateName)
                rtf.AppendText(string.Format(" wrote from [{0}]: \r\n", S1));

            rtf.SelectionFont = font;

        }


        private void WriteComment(string comment)
        {

            rtf.SelectionAlignment = HorizontalAlignment.Left;
            rtf.AppendText(comment);
            rtf.AppendText("\r\n\r\n");
        }

 
    }
}

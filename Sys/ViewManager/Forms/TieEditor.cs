using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Sys.ViewManager;
using System.Diagnostics;
using Tie;

namespace Sys.ViewManager.Forms
{
    public partial class TieEditor : BaseForm
    {
        private TieEditor(string sourceCode, string message , int cur)
        {
            InitializeComponent();
            if (account.UserID != 1227)
                toolStripButtonRun.Visible = false; 

            this.richTextBox1.AcceptsTab = true;

            this.richTextBox1.Text = sourceCode;
            this.statusStrip1.Items[1].Text = message;
            this.richTextBox1.SelectionStart = cur;


        }

        private TieEditor(string title, string sourceCode)
        {
            InitializeComponent();
            if (account.UserID != 1227)
                toolStripButtonRun.Visible = false; 

            this.Text = title;

            this.richTextBox1.AcceptsTab = true;

            this.richTextBox1.Text = sourceCode;
            this.statusStrip1.Items[1].Text = "";
            this.richTextBox1.SelectionStart = 0;
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            int line = JRichTextBox.Line(rtb);
            int col = JRichTextBox.Column(rtb);
            int pos = rtb.SelectionStart;

            this.statusStrip1.Items[0].Text = "Ln " + line + ", Col " + col;
        
        }


        public static string Show(PositionException e)
        {
            return TieEditor.Show(e.Position.CodePiece, e.Message, e.Position.Cursor);
        }

        public static string Show(string sourceCode, string message, int cur)
        {
            TieEditor tieException = new TieEditor(sourceCode, message, cur);
            
            if (tieException.ShowDialog() == DialogResult.Yes)
                return tieException.richTextBox1.Text;
            else
                return null;
        }


        public static string Show(ContainerControl owner, string title, string script)
        {
            TieEditor tieException = new TieEditor(title, script);

            //if (tieException.PopUp(owner, FormPlace.Floating) == DialogResult.Yes)
            if (tieException.ShowDialog() == DialogResult.Yes)
                    return tieException.richTextBox1.Text;
            else
                return null;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {
            TieScript script = new TieScript();
            script.Execute(this.richTextBox1.Text);
        }

    }


}

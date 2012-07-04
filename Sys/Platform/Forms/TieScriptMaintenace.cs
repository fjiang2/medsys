using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Data;
using Sys.Foundation.Dpo;
using Sys.ViewManager.Forms;

namespace Sys.Platform.Forms
{
    public partial class TieScriptMaintenace : BaseForm
    {
        public TieScriptMaintenace()
        {
            InitializeComponent();
            this.richTextBox1.AcceptsTab = true;

            this.richTextBox1.SelectionChanged += new EventHandler(richTextBox1_SelectionChanged);
        }


        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            int line = JRichTextBox.Line(rtb);
            int col = JRichTextBox.Column(rtb);
            int pos = rtb.SelectionStart;

            this.statusStrip1.Items[0].Text = "Ln " + line + ", Col " + col;

        }

        private string ModuleName
        {
            get { return this.comboModules.Text; }
        }

        private void comboModules_DropDown(object sender, EventArgs e)
        {
            comboModules.Items.Clear();
            DataTable dt = new TableReader<ScriptDpo>("Released = 1").Table;
            foreach (DataRow row in dt.Rows)
            {
                comboModules.Items.Add(row[ScriptDpo._Module]);
            }
        }

        private void comboModules_TextChanged(object sender, EventArgs e)
        {
            if (ModuleName != null)
            {
                ScriptDpo dpo = new ScriptDpo(ModuleName);
                richTextBox1.Text = dpo.Script;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (ModuleName == "")
                return;

            ScriptDpo dpo = new ScriptDpo(ModuleName);
            dpo.Script = richTextBox1.Text;
            dpo.Save();

            this.InformationMessage = string.Format("Tie Module [{0}] is saved.", ModuleName);
        }

  
    }
}

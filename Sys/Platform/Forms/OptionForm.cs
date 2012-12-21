using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;

namespace Sys.Platform.Forms
{
    public partial class OptionForm : BaseForm
    {
        public OptionForm()
        {
            InitializeComponent();

           // Tie.HostType.Register(typeof(OptionForm));
        }

        public static void MenuAction(string command)
        {
            MessageBox.Show(command);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = "command";
            this.ShortcutManager.Add(false, command, command, typeof(OptionForm), "MenuAction", new object[] { command });
        }
    }
}

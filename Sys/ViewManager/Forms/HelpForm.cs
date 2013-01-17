using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Modules;

namespace Sys.ViewManager.Forms
{
    public partial class HelpForm : BaseForm
    {
        public HelpForm(string title, string html)
        {
            InitializeComponent();
            this.allAccess = true;

            this.Text = "Help: " + title;
            webBrowser1.DocumentText = html;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
 
    }
}

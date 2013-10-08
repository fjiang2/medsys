using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sys.Platform.Forms
{
    public partial class AuthorizeForm : Form
    {
        public AuthorizeForm(string formName)
        {
            InitializeComponent();
            this.Text += string.Format(" Form [{0}]",formName);
        }

        private void btnRequestMail_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
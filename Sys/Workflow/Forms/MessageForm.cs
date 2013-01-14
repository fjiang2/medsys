using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sys.Workflow.Forms
{
    public partial class MessageForm : ActivityWinForm
    {
        public MessageForm()
        {
            InitializeComponent();
            
        }

        public string Message
        {
            set
            {
                this.richTextBox1.Text = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

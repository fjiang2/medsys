using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace X12.Forms
{
    public partial class InputBox : Form
    {
        string value;

        public InputBox()
        {
            InitializeComponent();
        }

        public string Label
        {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }

        public string Message
        {
            get { return this.label2.Text; }
            set { this.label2.Text = value; }
        }

        public string Mask
        {
            get { return this.txtValue.Mask; }
            set { this.txtValue.Mask = value; }
        }

        public string Value
        {
            get { return this.txtValue.Text; }
            set { this.txtValue.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.value = txtValue.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.value = "";
            this.Close();
        }
    }
}

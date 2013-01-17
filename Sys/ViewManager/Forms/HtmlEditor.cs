﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sys.ViewManager.Forms
{
    public partial class HtmlEditor : Form
    {
        public HtmlEditor()
        {
            InitializeComponent();
        }

        public string HtmlText
        {
            get
            {
                return this.richEditControl1.HtmlText;
            }
            set
            {
                this.richEditControl1.HtmlText = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}

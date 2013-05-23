using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Text.RegularExpressions;

namespace Sys.Platform
{
    public partial class MailTemplateForm : Form
    {

        
        public MailTemplateForm()
        {
            InitializeComponent();


            //foreach (DataRow dr in dt.Rows)
            //{
            //    ListViewItem item = new ListViewItem(dr[0].ToString(), 0);
            //    item.SubItems.Add(dr[1].ToString());
            //    lvKeywords.Items.Add(item);
            //}

        }
    


        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
        }

        private void showMessage(string format, params object[] args)
        {
            string s = string.Format(format, args);
            this.toolStripStatusLabel1.Text = s;
        }

    }
}
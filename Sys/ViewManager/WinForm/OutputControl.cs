using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraNavBar;
using Sys.ViewManager.Forms;
using Tie;
using Sys.Security;

namespace Sys.ViewManager.Forms
{
    public partial class OutputControl : RichTextBox
    {
        MessageManager manager;

        public OutputControl()
        {
            InitializeComponent();
            this.ReadOnly = true;

            this.manager = new MessageManager();
            manager.MessageChanged += new MessageManager.MessageHandler(manager_MessageChanged);
            manager.MessageCleared += new EventHandler(manager_MessageCleared);
        }

        void manager_MessageCleared(object sender, EventArgs e)
        {
            this.Text = "";
        }

        private void manager_MessageChanged(object sender, MessageEventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            foreach (Message item in e.Errors)
            {
                builder.AppendLine(item.Description);
            }

            this.Text += builder.ToString();

        }
        public MessageManager Manager
        {
            get { return this.manager; }
        }
    }
}

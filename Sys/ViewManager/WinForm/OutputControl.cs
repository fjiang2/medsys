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
using DevExpress.XtraBars.Docking;

namespace Sys.ViewManager.Forms
{
    public partial class OutputControl : RichTextBox, IDockable
    {
        MessageManager manager;

        public OutputControl()
        {
            InitializeComponent();
            this.ReadOnly = true;

            this.manager = new MessageManager(this);
            manager.Committed += new EventHandler(manager_Committed);
            manager.Cleared += new EventHandler(manager_Cleared);
        }

        public void ActivateDockPanel()
        {
            if (this.Tag is DockPanel)
            {
                DockPanel dockPanel = (DockPanel)this.Tag;
                dockPanel.DockManager.ActivePanel = dockPanel;
            }
        }


        void manager_Cleared(object sender, EventArgs e)
        {
            this.Text = "";
        }

        private void manager_Committed(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            var messages = ((MessageManager)sender).Messages;
            foreach (Message item in messages)
            {
                builder.AppendLine(item.Description);
            }

            this.Text += builder.ToString();
            this.ScrollToCaret();
        }
        public MessageManager Manager
        {
            get { return this.manager; }
        }
    }
}

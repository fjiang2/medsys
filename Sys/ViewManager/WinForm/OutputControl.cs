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
    public partial class OutputControl : RichTextBox, IDockPanel
    {
        MessageManager manager;

        public OutputControl()
        {
            InitializeComponent();
            this.ReadOnly = true;

            this.manager = new MessageManager(this);
            manager.MessageChanged += new MessageManager.MessageHandler(manager_MessageChanged);
            manager.MessageCleared += new EventHandler(manager_MessageCleared);
        }

        public void ActivateDockPanel()
        {
            if (this.Tag is DockPanel)
            {
                DockPanel dockPanel = (DockPanel)this.Tag;
                dockPanel.DockManager.ActivePanel = dockPanel;
            }
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
            this.ScrollToCaret();
        }
        public MessageManager Manager
        {
            get { return this.manager; }
        }
    }
}

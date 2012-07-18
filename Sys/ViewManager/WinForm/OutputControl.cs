using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraNavBar;
using Sys.ViewManager.Forms;
using Tie;
using Sys.Security;
using DevExpress.XtraBars.Docking;

namespace Sys.ViewManager.Forms
{
    public partial class OutputControl : RichTextBox
    {
        MessageManager manager;

        public OutputControl()
        {
            InitializeComponent();
            this.ReadOnly = true;

            this.manager = MessageManager.Instance;
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
            var messages = this.manager.GetMessages(MessagePlace.OutputWindow);
            if (messages.Count() == 0)
                return;

            this.Text = "";
        }

        private void manager_Committed(object sender, EventArgs e)
        {
            var messages = this.manager.GetMessages(MessagePlace.OutputWindow);
            if (messages.Count() == 0)
                return;

            StringBuilder builder = new StringBuilder();
            foreach (Message item in messages)
            {
                builder.AppendLine(item.Description);
            }

            this.Text += builder.ToString();
            this.ScrollToCaret();

            manager.RemoveMessages(MessagePlace.OutputWindow);
            ActivateDockPanel();
        }
       
    }
}

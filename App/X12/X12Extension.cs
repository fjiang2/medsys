using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys;
using System.Windows.Forms;
using System.Reflection;

namespace X12
{
    static class X12Extension
    {

        public static bool TabPageExists(this TabControl tabControl, string text)
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                if (tabPage.Text == text)
                {
                    tabControl.SelectedTab = tabPage;
                    return true;
                }
            }

            return false;
        }

        public static TabPage AddTabPage(this TabControl tabControl, string text, Control control)
        {
            control.Dock = DockStyle.Fill;
            TabPage page = new TabPage(text);
            page.Controls.Add(control);
            tabControl.TabPages.Add(page);
            tabControl.SelectedTab = page;

            return page;
        }

    }
}

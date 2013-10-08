using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Sys.ViewManager.Modules;
using DevExpress.XtraBars;
using Sys.ViewManager.Security;

namespace Sys.ViewManager.Manager
{
    public class WindowManager
    {
        BarSubItem menuWindow;
        MenuConsumer menuConsumer;

        public WindowManager(MenuConsumer menuConsumer)
        {
            this.menuConsumer = menuConsumer;
            menuWindow = menuConsumer.AddBarSubItem("&Window");

            BarButtonItem menu = menuConsumer.AddBarButtonItem(menuWindow,"Show All");
            menu.ItemClick += delegate(object sender, ItemClickEventArgs e)
            {
                ShowAllWindows();
            };

            menu = menuConsumer.AddBarButtonItem(menuWindow, "Hide All");
            menu.ItemClick += delegate(object sender, ItemClickEventArgs e)
            {
                HideFloatingWindows();
            };

            menu = menuConsumer.AddBarButtonItem(menuWindow, "Close All");
            menu.ItemClick += delegate(object sender, ItemClickEventArgs e)
            {
                CloseAllWindows();
            };

        
        }

        public BarSubItem MenuWindow
        {
            get { return this.menuWindow; }
        }
        
        List<BaseForm> windows = new List<BaseForm>();
        private void ShowAllWindows()
        {
            foreach (BaseForm form in windows)
                form.Visible = true;
        }

        private void HideFloatingWindows()
        {
            foreach (BaseForm form in windows)
            {
                if(form.MdiParent == null)  //hide non-dock windows
                    form.Visible = false;
            }
        }

        public int Count
        {
            get
            {
                return windows.Count;
            }
        }

        public void CloseAllWindows()
        {
            while (windows.Count > 0)
            {
                Form form = windows[windows.Count - 1];
                form.Close();
            }
        }

        public void AddWindow(BaseForm form)
        {
            int identSuffix = 0;
            Regex regex = new Regex(@"\((?<idx>[0-9]{1,})\)$");



            //provide sequential naming for windowJumperIdent
            foreach (LinkPersistInfo temp in menuWindow.LinksPersistInfo)
            {
                BarItem item = temp.Item;

                if (item.Caption.IndexOf(form.Text) == 0)
                {
                    if (regex.IsMatch(item.Caption))
                        identSuffix = Convert.ToInt16(regex.Matches(item.Caption)[0].Groups["idx"].Value) + 1;
                    else
                        identSuffix = 1;
                }
            }
            string title = String.Empty;

            if (identSuffix == 0)
                title = form.Text;
            else
                title = form.Text + " (" + identSuffix + ")";

            //add this form to the WindowJumper - don't add any that have no title.
            if (title.Trim() != "")
            {
                ((System.ComponentModel.ISupportInitialize)(this.menuConsumer.BarManager)).BeginInit();
                BarButtonItem item = menuConsumer.AddBarButtonItem(menuWindow, title, menuWindow.LinksPersistInfo.Count == 3);  //3 fixed menu items 
                ((System.ComponentModel.ISupportInitialize)(this.menuConsumer.BarManager)).EndInit();

                item.ItemClick += delegate(object sender, ItemClickEventArgs e)
                {
                    try
                    {
                        if (form.MdiParent != null)     //hide float windows when tabbed form is activated
                            HideFloatingWindows();

                        if (form.WindowState == FormWindowState.Minimized)
                            form.WindowState = FormWindowState.Normal;
                        
                        form.Visible = true;

                        form.BringFormToFront();
                        form.Focus();
                    }
                    catch (Exception)
                    {
                        RemoveWindow(title, form);
                    }
                };

                FormClass formClass = new FormClass(form);
                if (formClass.Exists)
                    item.Glyph = formClass.IconImage;
                //else
                //    item.Glyph = form.Icon.ToBitmap();

                windows.Add(form);


                form.FormClosed += delegate(object sender, FormClosedEventArgs e)
                {
                    RemoveWindow(title, form);
                };
            }


        }



        private void RemoveWindow(string title, BaseForm form)
        {

            //remove this from from the WindowJumper
            foreach (LinkPersistInfo temp in menuWindow.LinksPersistInfo)
            {
                BarItem item = temp.Item;
                if (item.Caption == title)
                {
                    menuWindow.LinksPersistInfo.Remove(temp);
                    menuConsumer.BarManager.Items.Remove(temp.Item);
                    windows.Remove(form);
                    return;
                }
            }
        }


    }
}

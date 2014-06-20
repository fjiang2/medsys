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
using Sys.ViewManager.Security;

namespace Sys.ViewManager.Manager
{
    public partial class ShortcutControl : NavBarControl
    {
        
        private NavBarGroup favorites = new DevExpress.XtraNavBar.NavBarGroup();
        private NavBarGroup recentlyused = new DevExpress.XtraNavBar.NavBarGroup();
        private NavBarGroup apps = new DevExpress.XtraNavBar.NavBarGroup();
        private ContainerControl owner;

        private Dictionary<NavBarItemLink, TaskData> navBarLinks = new Dictionary<NavBarItemLink, TaskData>();

  
        
        public ShortcutControl(ContainerControl owner)
        {
            InitializeComponent();

            this.owner = owner;

            this.favorites.Caption = "Favorites";
            this.recentlyused.Caption = "Recent";
            this.apps.Caption = "Applications";

            this.favorites.SmallImage = global::Sys.ViewManager.Properties.Resources.star;
            this.apps.SmallImage = global::Sys.ViewManager.Properties.Resources.windows;

            this.ActiveGroup = this.favorites;
            this.ContentButtonHint = null;
            this.Groups.AddRange(
                    new DevExpress.XtraNavBar.NavBarGroup[] 
                    {
                        this.favorites,
                        this.recentlyused,
                        this.apps
                    }
            );

            this.Location = new System.Drawing.Point(22, 12);
            this.Name = "navBarControl1";
            this.OptionsNavPane.ExpandedWidth = 240;
            this.Size = new System.Drawing.Size(240, 300);
            this.TabIndex = 0;
            this.Text = "Shortcuts";

            favorites.Expanded = true;
            recentlyused.Expanded = true;
            apps.Expanded = false;

            //AddApp("Intranet", "http://intranet", global::Sys.ViewManager.Properties.Resources.world_link);
            //AddApp("Microsoft Excel", "EXCEL.EXE", global::Sys.ViewManager.Properties.Resources.page_excel);
            //AddApp("Microsoft Word", "WINWORD.EXE", global::Sys.ViewManager.Properties.Resources.word);

            AppLink appLink = new AppLink(Account.CurrentUser);
            foreach (DpoClass.AppLinkDpo dpo in appLink.Links)
            {
                Image map;
                if (dpo.IconImage != null)
                    map = dpo.IconImage;
                else if(dpo.Command.StartsWith("http://"))
                    map = global::Sys.ViewManager.Properties.Resources.Web;
                else
                    map = global::Sys.ViewManager.Properties.Resources.application;

                AddApp(dpo.Label, dpo.Command, map);
            }

            Load();

            //this.Add(false, "Demo", "Hello World", this.GetType(), "func", new object[] { });
        }


        //public static void func()
        //{
        //    MessageBox.Show("Hello World");
        //}



        #region User defined group 

        public NavBarGroup AddGroup(string text)
        {
            NavBarGroup group = new DevExpress.XtraNavBar.NavBarGroup();
            group.Caption = text;
            this.Groups.Add(group);

            return group;
        }

        public void AddItem(NavBarGroup group, string key, string caption, Type hostType, string func, object[] args)
        {
            TaskData task = new TaskData(key, false, caption, hostType, func, args);
            TaskItem item = new TaskItem(task);

            item.LinkClicked += delegate(object sender, NavBarLinkEventArgs e)
            {
                Cursor = Cursors.WaitCursor;
                object result = task.Evaluate();
                Cursor = Cursors.Default;

            };

            this.Items.Add(item);
            NavBarItemLink link = group.ItemLinks.Add(item);
        }

        #endregion


        private bool AddApp(string caption, string app, Image image)
        {
            NavBarItem item = new NavBarItem();

            item.Caption = caption;
            //item.LargeImage = image;
            item.SmallImage = image;

            item.LinkClicked += delegate(object sender, NavBarLinkEventArgs e)
            {
                Cursor = Cursors.WaitCursor;
                System.Diagnostics.Process.Start(app);
                Cursor = Cursors.Default;
            };

            this.Items.Add(item);
            NavBarItemLink link = apps.ItemLinks.Add(item);

            return true;
        }

        #region  Shortcuts Persistence

        private VAL Persistent(string key)
        {
            VAL shortCuts = VAL.Array();
            if (Profile.Instance.Memory[key].Undefined)
                Profile.Instance.Memory[key] = shortCuts;
            else
                shortCuts = Profile.Instance.Memory[key];
    
            return shortCuts;
        }

        public void Load()
        {
            VAL shortCuts = Persistent("ShortCuts");
            for(int i= 0; i<shortCuts.Size; i++)
            {
                VAL val = shortCuts[i];
                
                if (!val.IsList)        
                    continue;
                
                TaskData task = new TaskData(val);
                AddItem(task);
            }
        }

        public void Save()
        {
            VAL shortCuts = VAL.Array();
            foreach (TaskData task in navBarLinks.Values)
            {
                shortCuts.Add(task.GetVAL());
            }

            Profile.Instance.Memory["ShortCuts"] = shortCuts;
        }

        #endregion


        internal bool Add(bool pinned, Form form)
        {
            Type ty = form.GetType();
            TaskData task = new TaskData(ty.FullName, pinned, form.Text, ty, new object[] { });

            return AddItem(task);
        }

        public bool Add(bool pinned, string key, string caption, Type formClassType, object[] args)
        {
            key = formClassType.FullName + "#" + key.ToIdent(); 
            TaskData task = new TaskData(key, pinned, caption, formClassType, args);

            return AddItem(task);
        }

        public bool Add(bool pinned, Guid key, string caption, Type hostType, string func, object[] args)
        {
            TaskData task = new TaskData(key.ToString(), pinned, caption, hostType, func, args);

            return AddItem(task);
        }

        public bool Add(bool pinned, UserMenuItem menuItem, Type hostType, string func, object[] args)
        {
            System.Guid key;
            if(!Guid.TryParse(menuItem.Key_Name, out key))
            {
                key = System.Guid.NewGuid();
                menuItem.Key_Name = key.ToString();
                menuItem.Save();
            }
            else
            {
                key = new System.Guid(menuItem.Key_Name);
            }

            string caption = menuItem.Label;
            this.BeginInit();
            bool result = this.Add(pinned, key, caption, hostType, func, args);
            this.EndInit();

            return result;
        }


        private bool AddItem(TaskData task)
        {
            NavBarGroup group;

            if (task.pinned)
                group = favorites;
            else
            {
                group = recentlyused;
            }

            this.ActiveGroup = group;

            if (AdjustItem(task, group))
            {
                return AddItem(task, group);
            }
            else
                return false;
        }


        //move [Recent] Item to [Favorite], keep last 10 tasks on the [Recent]
        private bool AdjustItem(TaskData task, NavBarGroup group)
        {

            foreach (KeyValuePair<NavBarItemLink, TaskData> kvp in navBarLinks)
            {
                TaskData t = kvp.Value;
                if (t.Key == task.Key)
                {
                    if (!t.pinned)
                    {
                        if (task.pinned)
                        {
                            //move from recently to favorites
                            t.pinned = true;
                            recentlyused.ItemLinks.Remove(kvp.Key);
                            favorites.ItemLinks.Add(kvp.Key);
                            Save();
                        }
                        else
                        {
                            //update time
                            t.time = DateTime.Now;
                            // group.ItemLinks.Sort(new TaskLink(t));    //sort [Recently Used]
                        }
                    }
                    return false;
                }
            }

            if (group == recentlyused)
            {
                while(recentlyused.ItemLinks.Count >= 10)   //keep last 10 tasks
                    RemoveOldestUnpinnedTask();
            }

            return true;
        }

        private bool AddItem(TaskData task, NavBarGroup group)
        {
            try
            {
                TaskItem item = new TaskItem(task);

                item.LinkClicked += delegate(object sender, NavBarLinkEventArgs e)
                {
                    Cursor = Cursors.WaitCursor;
                    object result = task.Evaluate();

                    if (task.ty == TaskDataType.NewBaseForm)
                    {
                        BaseForm form = (BaseForm)result;
                        if (form != null)
                            form.PopUp(owner);
                    }

                    Cursor = Cursors.Default;

                };

                this.Items.Add(item);
                NavBarItemLink link = group.ItemLinks.Add(item);
                this.navBarLinks.Add(link, task);

                if (task.pinned)
                    group.ItemLinks.SortByCaption();
                else
                    group.ItemLinks.Sort(item);         //Sort by time WinForm openned


            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        private bool RemoveOldestUnpinnedTask()
        {
            DateTime time = DateTime.Now;
            NavBarItemLink link = null;

            foreach (KeyValuePair<NavBarItemLink, TaskData> kvp in navBarLinks)
            {
                TaskData task = kvp.Value;
                if (!task.pinned)
                {
                    if (task.time < time)
                    {
                        time = task.time;
                        link = kvp.Key;
                    }
                }
            }

            if (link == null)
                return false;

            recentlyused.ItemLinks.Remove(link);
            this.navBarLinks.Remove(link);
            return true;

        
        }

        private bool RemoveNavBarItem(NavBarItemLink link)
        {
            if (link == null)
                return false;

            if (navBarLinks.ContainsKey(link))
                navBarLinks.Remove(link);

            link.Dispose();
            return true;

        }


        private ContextMenuStrip BuildContextMenu(NavBarItemLink link)
        {
            if (!navBarLinks.ContainsKey(link))
                return null;

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem menuDelete = new ToolStripMenuItem("Delete", global::Sys.ViewManager.Properties.Resources.DeleteHS);
            menuDelete.Enabled = link != null;

            ToolStripMenuItem menuMove = new ToolStripMenuItem("Move to Favorite", global::Sys.ViewManager.Properties.Resources.star);

            TaskData task = navBarLinks[link];
            menuMove.Enabled = !task.pinned; 

            menuDelete.Click += delegate(object sender, EventArgs e)
            {
                if (RemoveNavBarItem(link))
                    Save();
            };


            menuMove.Click += delegate(object sender, EventArgs e)
            {
                task.pinned = true;
                recentlyused.ItemLinks.Remove(link);
                favorites.ItemLinks.Add(link);
                Save();
            };

            contextMenuStrip.Items.Add(menuDelete);
            contextMenuStrip.Items.Add(menuMove);

            return contextMenuStrip;
        }

        private void NavBarArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;


            Point point = (sender as Control).PointToClient(Control.MousePosition);
            NavBarHitInfo navBarHitInfo = this.CalcHitInfo(point);


            if (navBarHitInfo.Link != null)
            {
                ContextMenuStrip contextMenuStrip = BuildContextMenu(navBarHitInfo.Link);
                if(contextMenuStrip != null)
                    contextMenuStrip.Show((Control)sender, point.X, point.Y);
            }

        }

    }
}

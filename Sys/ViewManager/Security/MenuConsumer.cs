using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;
using Tie;
using System.Reflection;
using Sys.ViewManager.Forms;
using Sys.Data;
using Sys.Security;
using Sys.Foundation.Dpo;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using Sys.ViewManager.Manager;

namespace Sys.ViewManager.Security
{

    public enum MenuItemType
    {
        MenuItem = 0,
        Separator = 1,
        ToolBar = 2
    }


    public class MenuConsumer
    {
        UserRoleAccount collector;

        private MenuRuntime eventHandlerInstance;

        private IMainForm mainForm;
        private FormDockManager formDockManager;
        private BarManager barManager;
        private Bar menuBar;

        ImageList imageList = new ImageList();
        IdentifierTree<UserMenuItem> tree;
        List<UserMenuItem> items;

        private int id = 0;

        public MenuConsumer(IMainForm mainForm, FormDockManager formDockManager, BarManager barManager, Bar menuBar)
        {
            this.mainForm = mainForm;
            this.formDockManager = formDockManager;
            this.barManager = barManager;
            this.menuBar = menuBar;

            this.collector = (UserRoleAccount)Account.CurrentUser;

            

            if (collector.IsDeveloper || collector.IsAdmin)
            {
              
                IEnumerable<UserMenuItem> menus;

#if PACKAGE    
                menus = new Package.UserMenuDpoPackage().ToList<UserMenuItem>();
#else
                menus = new DPList<UserMenuItem>(new TableReader<UserMenuItem>().Table).ToList();
#endif

                menus = menus.Where(dpo => dpo.Visible).OrderBy(dpo => dpo.OrderBy);

                if (collector.IsDeveloper)
                {
                    items = menus.ToList();
                }
                else
                  items = menus.Where(dpo => dpo.Released).ToList();
               
            }
            else
            {
                string SQL = @"
            SELECT	* 
            FROM	@UserMenus 
            WHERE	Visible=1 AND Released = 1 AND (Controlled=0 
		            OR ID IN (SELECT ID 
					            FROM @ItemPermissions 
			  	               WHERE Ty ={0} AND Visible=1 AND Role_ID IN (SELECT Role_ID FROM @UserRoles WHERE User_ID = {1})
                     ))
            ORDER BY OrderBy
            ";

                DataTable dataTable;
                SQL = SQL
                    .Replace("@UserMenus", Dpo.UserMenuDpo.TABLE_NAME)
                    .Replace("@ItemPermissions", Dpo.ItemPermissionDpo.TABLE_NAME)
                    .Replace("@UserRoles", UserRoleDpo.TABLE_NAME);

                dataTable = SqlCmd.FillDataTable(SQL,
                    (int)SecurityType.MenuItem,
                    collector.UserID);

                items = new DPList<UserMenuItem>(dataTable).ToList().OrderBy(dpo => dpo.OrderBy).ToList();
            }

            int imageIndex = 0;
            foreach (UserMenuItem item in items)
            {
                if (item.IconImage != null)
                {
                    imageList.Images.Add(item.ID.ToString(), item.IconImage);
                    item.ImageIndex = imageIndex++;
                }
            }

         
            this.tree = new IdentifierTree<UserMenuItem>(items, 0);
			eventHandlerInstance = new MenuRuntime(this,  this.mainForm);
        }

        public ImageList ImageList
        {
            get { return this.imageList; }
        }


        public BarManager BarManager
        {
            get { return this.barManager; }
        }


        public UserMenuItem this[string label]
        {
            get
            {
                return this.items.Where(dpo => dpo.Label == label).FirstOrDefault();
            }
        }

        public UserMenuItem this[int Id]
        {
            get
            {
                return this.items.Where(dpo => dpo.ID == Id).FirstOrDefault();
            }
        }


        public BarButtonItem AddBarButtonItem(BarSubItem subItem, string caption)
        {
            return AddBarButtonItem(subItem, caption, false);
        }

        public BarButtonItem AddBarButtonItem(BarSubItem subItem, string caption, bool seperator)
        {
            BarButtonItem item = NewButtonItem(caption);

            barManager.Items.Add(item);
            subItem.LinksPersistInfo.Add(new LinkPersistInfo(item, seperator));

            return item;
        }

        public BarSubItem AddBarSubItem(BarSubItem subItem, string caption)
        {
            BarSubItem item = NewSubItem(caption);

            barManager.Items.Add(item);
            subItem.LinksPersistInfo.Add(new LinkPersistInfo(item));

            return item;
        }

        public BarSubItem AddBarSubItem(string caption)
        {
            BarSubItem item = NewSubItem(caption);
            barManager.Items.Add(item);
            menuBar.LinksPersistInfo.Add(new LinkPersistInfo(item));

            return item;
        }

        private BarSubItem NewSubItem(string caption)
        {
            BarSubItem item = new BarSubItem(barManager, caption);
            item.Id = id++;
            item.Name = string.Format("iSubItem{0}", item.Id);
            
            return item;
        }

        private BarButtonItem NewButtonItem(string caption)
        {
            BarButtonItem item = new BarButtonItem(barManager, caption);
            item.Id = id++;
            item.Name = string.Format("iSubItem{0}", item.Id);

            return item;
        }

        #region Build MenuBar from UserMenuDpo

        public void Build()
        {
            foreach (TreeNode<UserMenuItem> node in tree.Nodes)
            {
                UserMenuItem item = node.Item;
                if (item.Controlled && !item.Visible)
                    continue;

                switch (item.MenuType)
                {
                    case MenuItemType.MenuItem:
                        BarSubItem subItem = AddBarSubItem(item.Label);
                        subItem.Enabled = item.Enabled;
                        Build(subItem, node);
                        
                        if (item.Command != "")
                            AddMenuItem(item, subItem);
                        
                            break;

                    case MenuItemType.Separator:
                        break;
                }

            }

        }

      
        private void Build(BarItem menuItem, TreeNode<UserMenuItem> parentNode)
        {
            if (parentNode.Nodes.Count == 0)
                return;

            if (!(menuItem is BarSubItem))
                throw new NotImplementedException();

            foreach (TreeNode<UserMenuItem> node in parentNode.Nodes)
            {

                UserMenuItem item = node.Item;
                if(item.Controlled && !item.Visible)
                    continue;

                BarItem barItem;

                if (node.Nodes.Count == 0)
                    barItem = AddBarButtonItem((BarSubItem)menuItem, item.Label, item.MenuType == MenuItemType.Separator);
                else
                    barItem = AddBarSubItem((BarSubItem)menuItem, item.Label);

                barItem.Enabled = item.Enabled;
                barItem.Glyph = item.IconImage;
                //barItem.ItemShortcut = new BarShortcut(Shortcut.AltF1);


                if (item.Command != "")
                    AddMenuItem(item, barItem);

                if (!item.Released)
                {
                    barItem.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red;
                    barItem.ItemAppearance.Normal.BackColor = System.Drawing.Color.LightBlue;
                }

                Build(barItem, node);
            }

        }


        private void AddMenuItem(UserMenuItem menuItem, BarItem item)
        {
         
            string methodName = "menuItem_Click";
            item.Tag = menuItem;

            Type menuItemType = item.GetType();
            EventInfo eventInfo = menuItemType.GetEvent("ItemClick");
            
             
            Type handlerType = eventInfo.EventHandlerType;
            Delegate d = Delegate.CreateDelegate(handlerType, eventHandlerInstance, methodName);
            eventInfo.AddEventHandler(item, d);
        }

        #endregion



        public BarButtonItem AddWebLink(BarSubItem parentItem, string title, string url)
        {
            BarButtonItem menu = new BarButtonItem(barManager, title);
            menu.ItemClick += delegate(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            {
                string instanceId = title;
                BaseForm form = new BaseForm(instanceId);
                form.Text = title;
                form.ShowInTaskbar = false;

                var browser = new WebBrowser();
                form.Controls.Add(browser);
                browser.Dock = DockStyle.Fill;
                browser.Navigate(url);

                mainForm.Show(form, FormPlace.TabbedAera);
            };

            barManager.Items.Add(menu);
            parentItem.LinksPersistInfo.Add(new LinkPersistInfo(menu));

            return menu;
        }


        public DockPanel AddDockPanel(string menuCaption)
        {
            UserMenuItem menuItem = this[menuCaption];
            
            //this user is not allowed to access this menu item
            if (menuItem == null)
                return null;

            Memory DS = new Memory();
            DS["owner"] = VAL.Boxing(mainForm.Form);
            Control control = (Control)Script.Evaluate("", menuItem.Command, DS, new MyFunction1()).HostValue;
            DockPanel dockPanel =  AddDockPanel(menuItem, control);
            control.Tag = dockPanel;
            
            return dockPanel;
        }



        /// <summary>
        /// Add UserControl defined on UserMenus into DockPanel
        /// </summary>
        /// <param name="menuItem"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public DockPanel AddDockPanel(UserMenuItem menuItem, Control control)
        {
            DockPanel dockPanel = formDockManager[new Guid(menuItem.Key_Name)];
            if (dockPanel == null)
            {
                dockPanel = formDockManager.AddPanel(menuItem.Label, control, (DockingStyle)menuItem.Form_Place);
                dockPanel.ID = new Guid(menuItem.Key_Name);
                dockPanel.ImageIndex = menuItem.ImageIndex;
            }
            else
            {
                dockPanel.Show();
            }

            formDockManager.DockManager.ActivePanel = dockPanel;
            return dockPanel;
        }
    }

    class MyFunction1 : IUserDefinedFunction
    {
        public MyFunction1()
        { }

        public VAL Function(string func, VAL parameters, Memory DS)
        {
            switch (func)
            {
                //peel OpenControl function
                //return OpenControl(new System.Windows.Forms.RichTextBox()); ==  return new System.Windows.Forms.RichTextBox();
                case "OpenControl":  
                    if (parameters.Size == 1)
                    {
                        return parameters[0];
                    }
                    break;
            }

            return null;

        }
    }
}

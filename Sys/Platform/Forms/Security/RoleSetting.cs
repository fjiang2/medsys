using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.ViewManager.Forms;
using Sys.Data;
using Sys.ViewManager;
using Sys.ViewManager.Security;
using Sys.Security;
using Sys.Foundation.DpoClass;
using Sys.ViewManager.DevEx;

namespace Sys.Platform.Forms
{
    public partial class RoleSetting : BaseForm
    {
        
        int currentRoleID= -1;
        JDataTableControl dtControl;
        FormStore securityWinForm;
        List<HookTree> hooks = new List<HookTree>();

        ContextMenuStrip treeViewContextMenuStrip = new ContextMenuStrip();
        ContextMenuStrip xtraGridContextMenuStrip = new ContextMenuStrip();

        public RoleSetting()
            : this(0)
        { 

        }

        public RoleSetting(int roleID)
        {
            InitializeComponent();
            treeView1.ImageList = new ImageList();
            treeView1.ImageList.Images.Add("a", global::Sys.Platform.Properties.Resources.folder);
            treeView1.ImageList.Images.Add("Invisible", global::Sys.Platform.Properties.Resources.contrast_low);
            treeView1.ImageList.Images.Add("Visible", global::Sys.Platform.Properties.Resources.weather_sun);
            treeView1.ImageList.Images.Add("Package", global::Sys.Platform.Properties.Resources.box);
            treeView1.AfterSelect += new TreeViewEventHandler(treeView11_TreeViewEventHandler);
            treeView1.KeyDown += new KeyEventHandler(treeView1_KeyDownHandler);

            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            this.gridControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseClick);

            currentRoleID = roleID;
            this.lblCurrentRole.Text = (string)SqlCmd.ExecuteScalar("SELECT Role_Name FROM {0} WHERE Role_ID={1}", RoleDpo.TABLE_NAME, roleID); 
        }
        
        private void SecuritySetting_Load(object sender, EventArgs e)
        {
            //TreeView
            TreeNode formObject = new TreeNode("FORM");
            treeView1.Nodes.Add(formObject);

            securityWinForm = new FormStore(formObject);
            securityWinForm.Load(currentRoleID);
            
            
            string SQL = @"SELECT ID, ParentID, Label FROM {0} WHERE Ty=0 AND Controlled=1 ORDER BY orderBy";
            DataTable definition = SqlCmd.FillDataTable(SQL, Sys.ViewManager.DpoClass.UserMenuDpo.TABLE_NAME);
            HookTree hook = new HookTree(treeView1, "MENU", definition, SecurityType.MenuItem);
            hooks.Add(hook);

            SQL = @"SELECT ID, ParentID, Label FROM {0} WHERE ParentID IS NOT NULL AND Access_Level <> {1}";
            definition = SqlCmd.FillDataTable(SQL, Sys.SmartList.DpoClass.CommandDpo.TABLE_NAME, (int)SecurityLevel.PrivateAccess);
            hook = new HookTree(treeView1, "SMART LIST", definition, SecurityType.SmartList);
            hooks.Add(hook);


            SQL = @"
                SELECT -ID AS ID, ParentID, Label
                FROM {0}
                WHERE Released = 1
                UNION
                SELECT S.ID, -W.ID AS ParentID, S.Label
                FROM {1} S
                INNER JOIN {0} W ON W.Name = S.Workflow_Name AND W.Released = 1
                ORDER BY ParentID, ID
            ";
            definition = SqlCmd.FillDataTable(SQL,
                Sys.Workflow.DpoClass.wfWorkflowDpo.TABLE_NAME,
                Sys.Workflow.DpoClass.wfStateDpo.TABLE_NAME
                );
            hook = new HookTree(treeView1, "WORKFLOW", definition, SecurityType.Workflow);
            hooks.Add(hook);

            foreach (HookTree h in hooks)
                h.Load(currentRoleID);
            
            treeView1.Sort();
            BuildTreeViewContextMenuStrip();
            

            //Roles Management
            DataTable dataTable = Role.AllRoles();
            dtControl = new JDataTableControl(gridControl1, dataTable, new RoleDpo().TableName, new RoleDpo().Locator);
            dtControl.Fields.Add(dataTable.Columns[RoleDpo._Role_ID]);
            dtControl.Fields.Add(dataTable.Columns[RoleDpo._Role_Name]);
            dtControl.Fields.Add(dataTable.Columns[RoleDpo._Parent_Role_ID]);
            dtControl.Fields.Add(dataTable.Columns[RoleDpo._Description]);
            BuildXtraGridContextMenuStrip();

            if (account.IsAdmin)
            {
                this.btnSave.Visible = true;
                this.btnSave.Enabled = true;
            }
        }


        public void AddSecurityEntity(string label, DataTable definition, SecurityType type)
        {
            ItemNode entitity = new ItemNode(0, label);
            treeView1.Nodes.Add(entitity);
            ItemStore securitySmartList = new ItemStore(entitity, definition);
            securitySmartList.Load(type, currentRoleID);
        }

        #region TreeView
        private EntityNode SelectedEntity
        {
            get
            {
                if (treeView1.SelectedNode is EntityNode)
                {
                    EntityNode entity = (EntityNode)treeView1.SelectedNode;
                    return entity;
                }
                else
                    return null;
            }
        }

        private void BuildTreeViewContextMenuStrip()
        {
            ToolStripMenuItem menuEnabled = new ToolStripMenuItem("Enabled");
            ToolStripMenuItem menuVisible = new ToolStripMenuItem("Visible");
            ToolStripMenuItem menuSetAllEnabled = new ToolStripMenuItem("Children Nodes Enabled");
            ToolStripMenuItem menuClearAllEnabled = new ToolStripMenuItem("Children Nodes Disabled");
            ToolStripMenuItem menuSetAllVisible = new ToolStripMenuItem("Children Nodes Visible");
            ToolStripMenuItem menuClearAllVisible = new ToolStripMenuItem("Children Nodes Invisible");

            ToolStripMenuItem menuSetAll = new ToolStripMenuItem("Children Nodes Enabled+Visible");
            ToolStripMenuItem menuClearAll = new ToolStripMenuItem("Children Nodes Disabled+Invisible");
            

            treeViewContextMenuStrip.Items.Add(menuEnabled);
            treeViewContextMenuStrip.Items.Add(menuSetAllEnabled);
            treeViewContextMenuStrip.Items.Add(menuClearAllEnabled);
            treeViewContextMenuStrip.Items.Add(new ToolStripSeparator());
            treeViewContextMenuStrip.Items.Add(menuVisible);
            treeViewContextMenuStrip.Items.Add(menuSetAllVisible);
            treeViewContextMenuStrip.Items.Add(menuClearAllVisible);
            treeViewContextMenuStrip.Items.Add(new ToolStripSeparator());
            treeViewContextMenuStrip.Items.Add(menuSetAll);
            treeViewContextMenuStrip.Items.Add(menuClearAll);

            menuEnabled.CheckOnClick = true;
            menuVisible.CheckOnClick = true;
            menuSetAllVisible.Image = treeView1.ImageList.Images["Visible"];
            menuClearAllVisible.Image = treeView1.ImageList.Images["Invisible"];


            menuEnabled.ShortcutKeys = (Keys)Shortcut.F2;
            menuSetAllEnabled.ShortcutKeys = (Keys)Shortcut.F3;
            menuClearAllEnabled.ShortcutKeys = (Keys)Shortcut.F4;

            menuVisible.ShortcutKeys = (Keys)Shortcut.F5;
            menuSetAllVisible.ShortcutKeys = (Keys)Shortcut.F6;
            menuClearAllVisible.ShortcutKeys = (Keys)Shortcut.F7;

            menuSetAll.ShortcutKeys = (Keys)Shortcut.F8;
            menuClearAll.ShortcutKeys = (Keys)Shortcut.F9;

            foreach (ToolStripItem item in treeViewContextMenuStrip.Items)
            {
                if(item is ToolStripMenuItem)
                    (item as ToolStripMenuItem).ShowShortcutKeys = true; 
            }
            
            //Initialize
            treeViewContextMenuStrip.Opening += delegate(object sender, CancelEventArgs e)
             {

                 if (treeView1.SelectedNode is EntityNode)
                 {
                     EntityNode entity = (EntityNode)treeView1.SelectedNode;
                     menuEnabled.Checked = entity.Enabled;
                     menuVisible.Checked = entity.Visible;
                 }

             };

            //-------------------------------------------------------------------------------------------
            menuEnabled.CheckedChanged += delegate(object sender, EventArgs e)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                if (treeView1.SelectedNode is EntityNode)
                {
                    EntityNode entity = (EntityNode)treeView1.SelectedNode;
                    entity.Checked = menuItem.Checked;
                }
            };


            menuVisible.CheckedChanged += delegate(object sender, EventArgs e)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                if (treeView1.SelectedNode is EntityNode)
                {
                    EntityNode entity = (EntityNode)treeView1.SelectedNode;
                    entity.Visible = menuItem.Checked;
                }
    
            };


            EventHandler childrenNodeHandler = delegate(object sender, EventArgs e)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                if (treeView1.SelectedNode is EntityNode)
                {
                    EntityNode entity = (EntityNode)treeView1.SelectedNode;
                    
                    switch(menuItem.Text)
                    {
                        case "Children Nodes Enabled":
                            entity.SetChildrenNodes("Enabled", true);
                            break;
                        case "Children Nodes Disabled":
                            entity.SetChildrenNodes("Enabled", false);
                            break;
                        case "Children Nodes Visible":
                            entity.SetChildrenNodes("Visible", true);
                            break;
                        case "Children Nodes Invisible":
                            entity.SetChildrenNodes("Visible", false);
                            break;

                        case "Children Nodes Enabled+Visible":
                            entity.SetChildrenNodes("Enabled", true);
                            entity.SetChildrenNodes("Visible", true);
                            break;

                        case "Children Nodes Disabled+Invisible":
                            entity.SetChildrenNodes("Enabled", false);
                            entity.SetChildrenNodes("Visible", false);
                            break;
                    }

                }
            };

            menuSetAllEnabled.Click += childrenNodeHandler;
            menuClearAllEnabled.Click += childrenNodeHandler;
            menuSetAllVisible.Click += childrenNodeHandler;
            menuClearAllVisible.Click += childrenNodeHandler;
            menuSetAll.Click += childrenNodeHandler;
            menuClearAll.Click += childrenNodeHandler;


        }


        public void treeView11_TreeViewEventHandler(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                TreeNode treeNode = e.Node;
                if (e.Node is EntityNode)
                {
                    EntityNode entity = (EntityNode)e.Node;
                    //lbStatus.Text = entity.Value;
                }
            }

        }


        public void treeView1_KeyDownHandler(object sender, KeyEventArgs e)
        {
            TreeNode treeNode = treeView1.SelectedNode;
            if (!(treeNode is EntityNode))
                return;

            EntityNode entity = (EntityNode)treeNode;
            switch (e.KeyCode)
            {
                case Keys.F2:
                    entity.Checked = !entity.Checked;
                    break;

                case Keys.F3:
                    entity.SetChildrenNodes("Enabled", true);
                    break;

                case Keys.F4:
                    entity.SetChildrenNodes("Enabled", false);
                    break;

                case Keys.F5:
                    entity.Visible = !entity.Visible;
                    break;

                case Keys.F6:
                    entity.SetChildrenNodes("Visible", true);
                    break;

                case Keys.F7:
                    entity.SetChildrenNodes("Visible", false);
                    break;

                case Keys.F8:
                    entity.SetChildrenNodes("Visible", true);
                    entity.SetChildrenNodes("Enabled", true);
                    break;

                case Keys.F9:
                    entity.SetChildrenNodes("Visible", false);
                    entity.SetChildrenNodes("Enabled", false);
                    break;
            }
        }


        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node is EntityNode)
                {
                    EntityNode entity = (EntityNode)e.Node;
                    entity.Visible = !entity.Visible;
                }
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node is EntityNode)
                {
                    EntityNode entity = (EntityNode)e.Node;
                    ((TreeView)sender).SelectedNode = entity;
                    treeViewContextMenuStrip.Show((Control)sender, e.X, e.Y);
                }

                
            }

        }


        private void cbExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (cbExpand.Checked)
                treeView1.ExpandAll();
            else
                treeView1.CollapseAll();
        }


        #endregion 



        public override object MaintenanceEntry
        {
            set
            {
                object[] x = (object[]) value; 
                lblCurrentRole.Text = (string)x[1];
            }
        }

  
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            dtControl.Save();
            securityWinForm.Save(currentRoleID);
            foreach (HookTree hook in hooks)
                hook.Save(currentRoleID);

            this.InformationMessage = "Role defintiion is saved.";
            
            this.Cursor = Cursors.Default;
        }


        private void toolStripButtonClean_Click(object sender, EventArgs e)
        {

            SqlCmd.ExecuteScalar("DELETE FROM {0} WHERE Role_ID NOT IN (SELECT Role_ID FROM {1})", Sys.ViewManager.DpoClass.FormPermissionDpo.TABLE_NAME, RoleDpo.TABLE_NAME);
            SqlCmd.ExecuteScalar("DELETE FROM {0} WHERE Role_ID NOT IN (SELECT Role_ID FROM {1})", Sys.ViewManager.DpoClass.ItemPermissionDpo.TABLE_NAME, RoleDpo.TABLE_NAME);
            this.InformationMessage ="Role definition is cleaned.";
        }




        struct CloneRoleArgument
        {
            public int from;
            public int to;
            public int current;

            public void Clear()
            {
                from = -1;
                to = -1;
                current = -1;
            }
        };
        
        CloneRoleArgument cloneRoleArgument = new CloneRoleArgument();

        private void gridControl1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { 
                DataRow dataRow = Grid.GetGridClickEx(this.gridView1, sender);
                if (dataRow != null)
                {
                    int roleID = (int)dataRow["Role_ID"];
                    cloneRoleArgument.current = roleID;
                    xtraGridContextMenuStrip.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        private void gridControl1_DoubleClick(object sender, System.EventArgs e)
        {
            DataRow dataRow = Grid.GetGridClickEx(this.gridView1, sender);
            if (dataRow != null)
            {
                lblCurrentRole.Text = dataRow["Role_Name"] as string;
                currentRoleID = (int)dataRow["Role_ID"];
                securityWinForm.Load(currentRoleID);
                foreach (HookTree hook in hooks)
                    hook.Load(currentRoleID);
                return;
            }
        }


        private void BuildXtraGridContextMenuStrip()
        {
            ToolStripMenuItem menuCopy = new ToolStripMenuItem("Copy Role");
            ToolStripMenuItem menuPaste = new ToolStripMenuItem("Paste Role");

            xtraGridContextMenuStrip.Items.Add(menuCopy);
            xtraGridContextMenuStrip.Items.Add(menuPaste);

            menuCopy.Image = global::Sys.Platform.Properties.Resources.CopyHS;
            menuPaste.Image = global::Sys.Platform.Properties.Resources.PasteHS;

            //Initialize
            xtraGridContextMenuStrip.Opening += delegate(object sender, CancelEventArgs e)
             {
                 if (treeView1.SelectedNode is EntityNode)
                 {
                     menuCopy.Enabled = true;
                     menuPaste.Enabled = cloneRoleArgument.from > 0 ;
                 }
             };

        
            EventHandler RowHandler = delegate(object sender, EventArgs e)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                switch (menuItem.Text)
                {
                    case "Copy Role":
                        cloneRoleArgument.from = cloneRoleArgument.current; 
                        break;
                    
                    case "Paste Role":
                        cloneRoleArgument.to = cloneRoleArgument.current;
                        //
                        ItemNode.CloneIRole(cloneRoleArgument.from, cloneRoleArgument.to);
                        EntityNode.CloneFormRole(cloneRoleArgument.from, cloneRoleArgument.to);
                        cloneRoleArgument.Clear();
                        break;
                }
            };

            menuCopy.Click += RowHandler;
            menuPaste.Click += RowHandler;


        }



       
   

    

    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.Security;
using Sys.Data;
using Sys.PersistentObjects.DpoClass;
using Sys.ViewManager.Forms;
using Sys.ViewManager;
using Sys.ViewManager.Security;
using DevExpress.XtraEditors.Controls;
using Sys.Foundation.DpoClass;
using Sys.ViewManager.DpoClass;
using Sys.ViewManager.DevEx;
using Sys.ViewManager.Modules;
using Sys.Platform.Securtity;
using Tie;

namespace Sys.Platform.Forms
{
    public partial class MenuMaintenance : BaseForm
    {
        BindDpo<UserMenuDpo> bind;
        TextBox txtKeyName = new TextBox();

        public MenuMaintenance()
        {
            InitializeComponent();

            this.FormClosed += new FormClosedEventHandler(MenuMaintenance_FormClosed);

            this.rgFormPlace.LoadEnum<FormPlace>();
            this.rgMenuType.LoadEnum<MenuItemType>();

            TreeNode node = treeForm.Nodes.Add("FORM");
            new FormTree().BuildWinFormTree(node);
            node.Expand();
            treeForm.AfterSelect += new TreeViewEventHandler(treeForm_AfterSelect);

            RefreshMenuTree();
            treeMenu.AfterSelect += new TreeViewEventHandler(treeMenu_AfterSelect);

            foreach (string x in Sys.Modules.Library.AssemblyNames)
            {
                comboModule.Items.Add(x);
            }

        }

        void MenuMaintenance_FormClosed(object sender, FormClosedEventArgs e)
        {
            treeMenu.SaveOrderBy();
        }


        private void MenuMaintenance_Load(object sender, EventArgs e)
        {
            UserMenuDpo dpo = new UserMenuDpo();
            dpo.ID = 1;
            dpo.Load();

            bind = new BindDpo<UserMenuDpo>(dpo);
            bind.BeforeSaving += bind_BeforeSaving;

            bind.Bind(txtID, UserMenuDpo._ID)
                .Bind(txtParentID, UserMenuDpo._ParentID)
                .Bind(txtOrderBy, UserMenuDpo._OrderBy)
                .Bind(rgMenuType, UserMenuDpo._Ty)

                .Bind(txtLabel, UserMenuDpo._Label)
                .Bind(txtDescription, UserMenuDpo._Description)

                .Bind(txtCommand, UserMenuDpo._Command)

                .Bind(chkControlled, UserMenuDpo._Controlled)
                .Bind(chkReleased, UserMenuDpo._Released)
                .Bind(chkVisible, UserMenuDpo._Visible)
                .Bind(chkEnabled, UserMenuDpo._Enabled)

                .Bind(comboModule, UserMenuDpo._Module)
                .Bind(picIcon, UserMenuDpo._Icon)
                .Bind(txtFormClass, UserMenuDpo._Form_Class)
                .Bind(rgFormPlace, UserMenuDpo._Form_Place)
                .Bind(txtKeyName, UserMenuDpo._Key_Name)

                .Reset();

        }

        public override void RuleDefinition(BusinessRules.ValidateProvider provider)
        {
            this.txtLabel.Required(provider);
        }

      

        private void UpdateCommand()
        {
            string formName = txtFormClass.Text;
            if (formName == "")
                return;

            FormPlace place = (FormPlace)rgFormPlace.GetEnum();

            if (place == FormPlace.TabbedAera)
                txtCommand.Text = "OpenForm(\"@form\", new object[]{});".Replace("@form", formName);
            else
            {
                txtCommand.Text = "OpenForm(FormPlace.@place, \"@form\", new object[]{});"
                    .Replace("@form", formName)
                    .Replace("@place", place.ToString());
            }
        }

        private void RefreshMenuTree()
        {
            treeMenu.Nodes.Clear();
            TreeNode root = new TreeNode("MENU");
            treeMenu.Nodes.Add(root);
            treeMenu.ToNodeText = dpo => string.Format("[{0}] {1}", dpo.NodeId, dpo.NodeText);
            treeMenu.DataSource = new TableReader<UserMenuItem>().ToList().OrderBy(dpo => dpo.OrderBy);
            treeMenu.BuildTreeView(root, 0);
            root.Expand();
            treeMenu.AllowDrop = true;
        }

      

        private void LoadMenuItem(int ID)
        {
            UserMenuDpo menuDpo = new UserMenuDpo();
            menuDpo.ID = ID;
            menuDpo.Load();

            bind.Dpo = menuDpo;
            bind.Reset();


        }


      

  
   
        #region Save Menu Item
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveMenuItem();
        }

        private void toolStripButtonCreateMenuItem_Click(object sender, EventArgs e)
        {
            txtID.Text = "-1";
            SaveMenuItem();

            if (saved)
                this.ShowMessageBox(Message.Information("Menu Item is created."));
        }


        private void SaveMenuItem()
        {
            if (!this.RuleValidated())
                return;


            if (string.IsNullOrEmpty(bind.Dpo.Key_Name))
                txtKeyName.Text = Guid.NewGuid().ToString();

            bind.SaveDpo();

            if (saved)
            {
                RefreshMenuTree();

                string formName = txtFormClass.Text;
                if (formName != "")
                {
                    //keep form class icon into database
                    FormClass dpo = new FormClass(formName);
                    dpo.Form_Class = formName;
                    dpo.Label = txtLabel.Text;
                    dpo.IconImage = this.picIcon.Image;
                    dpo.Save();
                }

                this.InformationMessage = string.Format("Menu [{0}]{1} is saved", txtID.Text, txtLabel.Text);
            }
        }

        bool saved = true;
        private void bind_BeforeSaving(object sender, BindDpoEventArgs e)
        {
            saved = true;

            if (e.mode == SaveMode.Update)
            {
                if (MessageBox.Show("This menu item is going to be overwritten, continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) 
                    != System.Windows.Forms.DialogResult.Yes)
                {
                    //default allow to overwrite
                    e.confirmed = false;
                    saved = false;
                }
            }
        }

        #endregion


        void treeForm_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                FormNode2 treeNode = (FormNode2)e.Node;
                if (treeNode != null)
                {
                    txtFormClass.Text = treeNode.Text;
                    string formName = txtFormClass.Text;

                    UpdateCommand();
                    comboModule.Text = Tie.HostType.GetType(formName).Assembly.GetName().Name;

                    FormClass dpo = new FormClass(formName);
                    if (dpo.Exists)
                    {
                        picIcon.Image = dpo.IconImage;
                    }
                }
            }
        }

        void treeMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                NTreeNode<UserMenuItem> treeNode = (NTreeNode<UserMenuItem>)e.Node;
                if (treeNode != null)
                    LoadMenuItem(treeNode.Item.NodeId);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string SQL = "SELECT ID, Label, Command FROM @UserMenus"
                .Replace("@UserMenus", Sys.ViewManager.DpoClass.UserMenuDpo.TABLE_NAME);

            LookUp lookup = new LookUp("Select Menu Item", DataExtension.FillDataTable<Sys.ViewManager.DpoClass.UserMenuDpo>(SQL));
            DataRow dataRow = lookup.PopUp(this);
            if (dataRow == null)
                return;

            LoadMenuItem((int)dataRow[UserMenuDpo._ID]);
        }


        private void rgFormPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum x = rgFormPlace.GetEnum();
            if (x == null)
                return;

            UpdateCommand();

        }

        private void rgMenuType_SelectedIndexChanged(object sender, EventArgs e)
        {
     
            object x = rgMenuType.GetEnum();
            if (x == null)
                return;

            //if ((int)x == (int)MenuItemType.Separator)
            //{
            //    this.txtLabel.Text = "------";
            //    this.txtDescription.Text = "";
            //    this.txtCommand.Text = "";
            //    this.comboModule.Text = "";
            //}
        }


        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = @"c:\";
            fileDialog.Filter = "PNG(*.png)|*.png|JPEG (*.jpg)|*.jpg|All|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picIcon.Image = Image.FromFile(fileDialog.FileName);
                }
                catch (Exception)
                { 
                }
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            picIcon.Image = null;
        }

    


    }
}

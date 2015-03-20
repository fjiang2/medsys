using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Sys.ViewManager;
using Sys.Data;
using Sys.Data.Manager;
using System.Reflection;
using Tie;

namespace Sys.Platform.Forms
{
    public partial class TableExplorer : WinForm
    {
        TableName selectedTableName;
        TreeNode root;

        public TableExplorer(string text, TableName tableName)
            : base(tableName.FullName)
        {

            InitializeComponent();
            ButtonDelete.Visible = false;
            ButtonNew.Visible = false;
            ButtonSerach.Visible = false;
            ButtonOpen.Visible = false;
            splitContainer1.Panel1Collapsed = true;

            this.Text = text;

            AddTabPage(tableName);

        }


        public TableExplorer()
        {
            InitializeComponent();
            ButtonDelete.Visible = false;
            ButtonNew.Visible = false;
            ButtonSerach.Visible = false;
            ButtonOpen.Visible = true;


            if (!account.IsDeveloper)
                return;

            treeView1.ImageList = new ImageList();
            treeView1.ImageList.Images.Add("database", global::Sys.Platform.Properties.Resources.database);
            treeView1.ImageList.Images.Add("datatable", global::Sys.Platform.Properties.Resources.database_table);

            foreach (var provider in ConnectionProviderManager.Instance.Providers)
            {
                string[] databaseNames;
                

                try
                {
                    databaseNames = provider.GetDatabaseNames();
                }
                catch (Exception) // no permisson to access this server
                {
                    MessageBox.Show(string.Format("not allowed to access server: {0}", provider.Name), 
                        "Warning", 
                        System.Windows.Forms.MessageBoxButtons.OK);
                    
                    continue;
                }

                root = treeView1.Nodes.Add(provider.Name);
                foreach (string name in databaseNames)
                {
                    TreeNode treeNode = new DatabaseNode(provider, name);
                    treeNode.ImageKey = "database";
                    treeNode.SelectedImageKey = treeNode.ImageKey;
                    root.Nodes.Add(treeNode);
                }
            }

            treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
            treeView1.MouseDoubleClick += new MouseEventHandler(treeView1_MouseDoubleClick);
            //treeView1.ExpandAll();

            treeView1.ContextMenuStrip = new ContextMenuStrip();
            ShowTreeViewContextMenu(treeView1.ContextMenuStrip);

            tabControl1.ContextMenuStrip = new ContextMenuStrip();
            ShowTabContextMenu(tabControl1.ContextMenuStrip);
        }


        #region treeView1.AfterSelect/MouseDoubleClick

        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                TreeNode treeNode = e.Node;
                if (treeNode is DatabaseNode && treeNode.Nodes.Count == 0)
                {
                    DatabaseNode databaseNode = (DatabaseNode)treeNode;
                    Cursor.Current = Cursors.WaitCursor;

                    TableName[] names = databaseNode.DatabaseName.GetTableNames();

                    //you are not allowed to open this database
                    if (names.Length == 0)
                        return;

                    foreach (var tname in names)
                    {
                        TreeNode node = new TableNode(tname);
                        node.ImageKey = "datatable";
                        node.SelectedImageKey = node.ImageKey;
                        treeNode.Nodes.Add(node);
                    }

                    treeNode.ExpandAll();

                    Cursor.Current = Cursors.Default;
                    return;
                }
                else
                    treeNode.ExpandAll();

            }
        }

        void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode treeNode = treeView1.SelectedNode;

            if (treeNode is TableNode)
            {
                TableNode tableNode = (TableNode)treeNode;
                Cursor.Current = Cursors.WaitCursor;

                AddTabPage(tableNode.TableName);
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion


        #region Show Context Menu on treeView1 and tabControl1

        private void ShowTreeViewContextMenu(ContextMenuStrip contextMenuStrip)
        {
            ToolStripMenuItem menuViewColumns = new ToolStripMenuItem("View Columns ...");
            contextMenuStrip.Items.Add(menuViewColumns);

            menuViewColumns.Click += delegate(object sender, EventArgs e)
            {
                TreeNode node = treeView1.SelectedNode;
                if (node is TableNode)
                {
                    TableNode tableNode = (TableNode)node;
                    TableName tname = tableNode.TableName;
                    DataTable table = InformationSchema.TableSchema(tname);
                    AddTabPage(tname, table, true);
                    return;
                }
            };
        }


        private void ShowTabContextMenu(ContextMenuStrip contextMenuStrip)
        {
            ToolStripMenuItem menuItemClose = new ToolStripMenuItem("Close");
            contextMenuStrip.Items.Add(menuItemClose);
            ToolStripMenuItem menuItemCloseAll = new ToolStripMenuItem("Close All But this");
            contextMenuStrip.Items.Add(menuItemCloseAll);

            menuItemClose.Click += delegate(object sender, EventArgs e)
            {
                if (tabControl1.SelectedTab != null)
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            };

            menuItemCloseAll.Click += delegate(object sender, EventArgs e)
            {
                foreach (TabPage page in tabControl1.TabPages)
                {
                    if (tabControl1.SelectedTab != page)
                        tabControl1.TabPages.Remove(page);
                }
            };
        }

        #endregion


        private void AddTabPage(TableName tname, DataTable table, bool readOnly)
        {
            this.selectedTableName = tname;
            //this.Text = "Table Explorer (" + tname + ")";

            table.TableName = tname.FullName;

            TabPage page = new TabPage(tname.ToString());
            JGridView jGridView1 = new JGridView();
            jGridView1.Dock = DockStyle.Fill;
            page.Controls.Add(jGridView1);
            jGridView1.DataSource = table;
            jGridView1.TableName = tname;
            jGridView1.ReadOnly = readOnly;

            this.tabControl1.TabPages.Add(page);
            this.tabControl1.SelectedTab = page;
        }

        private void AddTabPage(TableName tname)
        {
            DataTable table = SqlCmd.FillDataTable(tname.Provider, string.Format("SELECT * FROM {0}", tname));
            AddTabPage(tname, table, false);
        }



        private void DataTableExplorer_Load(object sender, EventArgs e)
        {
        }

        public override object MaintenanceEntry
        {
            set
            {
                AddTabPage( (TableName)value);
            }
        }

        #region Data Save/Print

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage page = tabControl1.SelectedTab;
            if (page == null)
                return;

            this.selectedTableName = SelectedGrid.TableName;

        }

        private JGridView SelectedGrid
        {
            get
            {
                TabPage page = tabControl1.SelectedTab;
                if (page == null)
                    return null;

                JGridView grid = (JGridView)page.Controls[0];
                return grid;
            }
        }

        public override bool DataSave()
        {
            if (SelectedGrid == null || SelectedGrid.ReadOnly)
                return false;

            if (MessageBox.Show(this, "Are you sure to save your changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return false;

            TableAdapter dt = SelectedGrid.DataSave(SelectedGrid.TableName);
            if (dt == null)
            {
                this.InformationMessage = "Data is not saved.";
                return false;
            }
            this.InformationMessage = "Data is saved.";
            return true;
        }


        public override bool DataPrint()
        {
            if (SelectedGrid != null)
            {
                this.SelectedGrid.PrintPreview(new string[] { "", this.Text, "" });
                return true;
            }
            else
                return false;
        }

        #endregion



        protected override bool AddShortCut(bool pinned)
        {
            TableName tname = this.selectedTableName;

            if (tname == null)
            {
                base.AddShortCut(pinned);
                return true;
            }

            string key = tname.GetHashCode().ToString();
            string caption = "TE:" + tname;

            if (this.ShortcutManager.Add(pinned, key, caption, this.GetType(), new object[] { this.Text, tname }))
            {
                this.InformationMessage = string.Format("Table Editor:[{0}] is added.", tname);
                this.ShortcutManager.Save();

                return true;
            }

            return false;
        }

        protected override void Appearance(VAL p, bool saved)
        {
            base.Appearance(p, saved);

            if (saved)
            {
                p["SplitterDistance"] = new VAL(this.splitContainer1.SplitterDistance);
            }
            else
            {
                if (p["SplitterDistance"].Defined)
                {
                    this.splitContainer1.SplitterDistance = p["SplitterDistance"].Intcon;
                }
            }
        }

        //protected override void ShowHelpForm()
        //{
        //    HelpForm helpForm = new HelpForm(this.GetType().FullName + this.tableName);
        //    helpForm.Text = "Help:Table Editor " + this.tableName;
        //    helpForm.PopUp(this);
        //}
    }


    #region DatabaseNode / TableNode

    class DatabaseNode : TreeNode
    {
        ConnectionProvider provider;
        DatabaseName databaseName;

        public DatabaseNode(ConnectionProvider handle, string databaseName)
            : base(databaseName)
        {
            this.provider = handle;
            this.databaseName = new DatabaseName(this.provider, this.Text); 
        }

        public DatabaseName DatabaseName
        {
            get 
            {
                return databaseName;
            }
        }

        //public DataProvider Provider
        //{
        //    get { return this.provider; }
        //}

        
    }

    class TableNode : TreeNode
    {
        TableName tableName;

        public TableNode(TableName tableName)
            : base(tableName.Name)
        {
            this.tableName = tableName;
        }

        public TableName TableName
        {
            get { return this.tableName; }
        }
      
    }

    #endregion


}

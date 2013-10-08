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

            foreach (var pair in DataProviderManager.Instance.Providers)
            {
                DataTable dataTable;
                try
                {
                    dataTable = SqlCmd.FillDataTable(pair.Key, "SELECT name FROM sys.databases ORDER BY Name");
                    dataTable.TableName = "databases";
                }
                catch (Exception) // no permisson to access this server
                {
                    MessageBox.Show(string.Format("not allowed to access server: {0}", DataProviderManager.Instance.GetConnection((int)pair.Key).Name), 
                        "Warning", 
                        System.Windows.Forms.MessageBoxButtons.OK);
                    
                    continue;
                }

                root = treeView1.Nodes.Add(pair.Value.Name);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    TreeNode treeNode = new DatabaseNode(pair.Key, dataRow["Name"] as string);
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
                    DataTable dt = SqlCmd.FillDataTable(databaseNode.Provider,
                        "USE [{0}] ; SELECT Name FROM sys.Tables ORDER BY Name",
                        databaseNode.DatabaseName);

                    //you are not allowed to open this database
                    if (dt == null)
                        return;

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        TableName name = new TableName(databaseNode.Provider, databaseNode.DatabaseName, (string)dataRow["name"]);

                        TreeNode node = new TableNode(name);
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

                    string SQL = @"
            USE [{0}]
            SELECT 
                c.name AS ColumnName,
                ty.name AS DataType,
                c.max_length AS Length,
                c.is_nullable AS Nullable,
                c.precision,
                c.scale,
                c.is_identity AS IsIdentity
             FROM sys.tables t 
                  INNER JOIN sys.columns c ON t.object_id = c.object_id 
                  INNER JOIN sys.types ty ON ty.system_type_id =c.system_type_id AND ty.name<>'sysname'
            WHERE t.name = '{1}' 
            ORDER BY c.column_id 
            ";
                    DataTable table = SqlCmd.FillDataTable(tname.Provider, 
                        SQL,
                        tname.DatabaseName.Name,
                        tname.Name);
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
        DataProvider provider;

        public DatabaseNode(DataProvider handle, string databaseName)
            : base(databaseName)
        {
            this.provider = handle;
        }

        public string DatabaseName
        {
            get { return this.Text; }
        }

        public DataProvider Provider
        {
            get { return this.provider; }
        }
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

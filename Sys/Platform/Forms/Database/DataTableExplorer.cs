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

namespace Sys.Platform.Forms
{
    public partial class DataTableExplorer : WinForm
    {
        string tableName;
        TreeNode root;

        public DataTableExplorer()
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


            DataTable dataTable = SqlCmd.FillDataTable("SELECT name FROM sys.databases ORDER BY Name");
            dataTable.TableName = "databases";

            root = treeView1.Nodes.Add("Databases");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TreeNode treeNode = new TreeNode(dataRow["Name"] as string);
                treeNode.ImageKey = "database";
                treeNode.SelectedImageKey = treeNode.ImageKey;
                root.Nodes.Add(treeNode); 
            }

            treeView1.AfterSelect += delegate(object sender, TreeViewEventArgs e)
            {
                if (!account.IsDeveloper)
                    return;

                if (e.Action == TreeViewAction.ByMouse)
                {
                    TreeNode treeNode = e.Node;
                    if (treeNode.Parent == root && treeNode.Nodes.Count == 0)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        DataTable dt = SqlCmd.FillDataTable("USE {0} ; SELECT Name FROM sys.Tables ORDER BY Name", treeNode.Text);

                        foreach (DataRow dataRow in dt.Rows)
                        {
                            TreeNode node = new TreeNode(string.Format("{0}..[{1}]", treeNode.Text, dataRow["name"]));
                            node.ImageKey = "datatable";
                            node.SelectedImageKey = node.ImageKey;
                            treeNode.Nodes.Add(node);
                        }

                        treeNode.ExpandAll();
 
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                    
                    if (treeNode.Parent != null && treeNode.Parent.Parent == root)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        this.tableName = treeNode.Text;
                        this.Text = "Data Table Editor [" + this.tableName +"]";
                        
                        DataLoad();
                        Cursor.Current = Cursors.Default;
                    }
                }
            };


            treeView1.ExpandAll();

            if (account.IsDeveloper)
            {
                treeView1.ContextMenuStrip = new ContextMenuStrip();
                DpoGenerateMenu(treeView1.ContextMenuStrip);
            }
        }

        private void DpoGenerateMenu(ContextMenuStrip contextMenuStrip)
        {
            ToolStripMenuItem menuSysDpo = new ToolStripMenuItem("Generate DPO ...");
          
            contextMenuStrip.Items.Add(menuSysDpo);
          
            menuSysDpo.Click += delegate(object sender, EventArgs e)
            {
                TreeNode node = treeView1.SelectedNode;
                string tableName = node.Text; //database..tablename

                if (tableName.IndexOf(".") == -1)
                {
                    string databaseName = node.Text;
                    Form f = new DpoGenForm(databaseName);
                    f.ShowDialog(this);
                    return;
                }
            };


           
         
        }



        public DataTableExplorer(string text, string tableName)
            :base(tableName)
        {

            InitializeComponent();
            ButtonDelete.Visible = false;
            ButtonNew.Visible = false;
            ButtonSerach.Visible = false;
            ButtonOpen.Visible = false;
            splitContainer1.Panel1Collapsed = true;

            this.Text = text;

            this.tableName = tableName;
            DataLoad();

        }

        private void DataTableExplorer_Load(object sender, EventArgs e)
        {
            if (account.IsDeveloper)
            {
                jGridView1.Visible = true;
                jGridView1.Enabled = true;
            }
        }

        public override object MaintenanceEntry
        {
            set
            {
                this.tableName = (string)value;
                DataLoad();
            }
        }

        public override bool DataLoad()
        {
            DataTable dataTable = SqlCmd.FillDataTable("SELECT * FROM "+ this.tableName);
            dataTable.TableName = this.tableName;
            jGridView1.DataSource = dataTable;
            return true;

        }

        public override bool DataSave()
        {

            if (MessageBox.Show(this, "Are you sure to save your changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return false;

            TableAdapter dt =jGridView1.DataSave();
            if(dt == null)
            {
                this.InformationMessage = "Data is not saved.";
                return false;
            }
            this.InformationMessage = "Data is saved.";
            return true;
        }


        public override bool DataPrint()
        {
            this.jGridView1.PrintPreview(new string[] {"", this.Text, ""});
            return true;
        }

    


        protected override bool AddShortCut(bool pinned)
        {
            if (this.tableName == null)
            {
                base.AddShortCut(pinned);
                return true;
            }

            string key =  this.tableName;
            string caption = "TE:" + this.tableName;

            if (this.ShortcutManager.Add(pinned, key, caption, this.GetType(), new object[] { this.Text, this.tableName}))
            {
                this.InformationMessage = string.Format("Table Editor:[{0}] is added.", this.tableName);
                this.ShortcutManager.Save();

                return true;
            }

            return false;
        }


        //protected override void ShowHelpForm()
        //{
        //    HelpForm helpForm = new HelpForm(this.GetType().FullName + this.tableName);
        //    helpForm.Text = "Help:Table Editor " + this.tableName;
        //    helpForm.PopUp(this);
        //}
    }



}

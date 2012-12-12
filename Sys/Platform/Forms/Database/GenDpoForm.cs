using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.Data.Manager;
using Sys.ViewManager.Forms;
using Sys.ViewManager.DevEx;
using Sys.Data;
using Sys.Modules;
using System.Threading;
using Sys.OS;


namespace Sys.Platform.Forms
{

    public partial class GenDpoForm : BaseForm
    {
        TableDpoDictionary dpoDict;
        string rootPath = "C:\\temp";
        private BackgroundWorker worker;

        DataProvider provider;

        public GenDpoForm()
            : this(Sys.Constant.DB_APPLICATION)
        { 
        
        }
        
        public GenDpoForm(string databaseName)
        {
            
            InitializeComponent();
            this.imageList1.Images.Add(global::Sys.Platform.Properties.Resources.BreakpointHS);
            this.imageList1.Images.Add(global::Sys.Platform.Properties.Resources.bullet_green);
            this.imageList1.Images.Add(global::Sys.Platform.Properties.Resources.bullet_black);
            treeTables.ImageList = this.imageList1;

#if DEBUG
            Sys.IO.Path path = new IO.Path();
            rootPath = path.Solution;
#endif
            this.txtPath.Text = rootPath;

            this.rgModifier.LoadEnum<AccessModifier>();
            this.rgModifier.SetEnum(AccessModifier.Public);

            this.rgDpoLevel.LoadEnum<Level>();
            this.rgDpoLevel.SetEnum(Level.Application);

            
            foreach (string x in Library.AssemblyNames)
            {
                comboModule.Items.Add(x);
            }

            this.dpoDict = Library.GetTableDpoDict();
            treeTables.AfterSelect += new TreeViewEventHandler(treeTables_AfterSelect);

            foreach (var provider in DataProviderManager.Instance.Providers)
            {
                comboServer.Items.Add(new MyProvider(provider));
            }
            this.comboServer.SelectedIndex = 0;

            this.comboDatabase.SelectedItem = databaseName;
      
        }

        private void chkShowNewTables_CheckedChanged(object sender, EventArgs e)
        {
            showTreeTables(chkShowNewTables.Checked);
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNode node in treeTables.Nodes)
            {
                node.Checked = chkCheckAll.Checked;
            }
        }


        void treeTables_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            node.SelectedImageIndex = 0;

            string tableName = node.Text;
            this.txtTableName.Text = tableName;

            ClassTableName tname = new ClassTableName(this.provider, DatabaseName, tableName);
            
            this.txtTableId.Text = tname.Id.ToString();

            if (dpoDict.ContainsKey(tname))
            {
                Type ty = dpoDict[tname];
                string moduleName = ty.Assembly.GetName().Name;

                this.comboModule.SelectedItem = moduleName;
                this.txtAssembly.Text = ty.Assembly.FullName;
                this.txtClass.Text = ty.Name;

                if(ty.IsPublic)
                    this.Modifier = Data.Manager.AccessModifier.Public;
                else 
                    this.Modifier = Data.Manager.AccessModifier.Internal;


                DPObject dpo = (DPObject)Activator.CreateInstance(ty);
                this.Level = dpo.Level;
                this.Pack = dpo.IsPack;
                this.HasProvier = dpo.HasProvider;

                this.txtNamespace.Enabled = false;
                this.txtClass.Enabled = false;
                this.btnBrowse.Enabled = false;
                this.comboModule.Enabled = false;
            }
            else
            {
                LogDpoClass log = new LogDpoClass(tname);
                if (log.Exists)
                {
                    this.comboModule.SelectedIndex = -1;
                    this.txtAssembly.Text = "";
                    
                    this.txtNamespace.Text = log.name_space;
                    this.txtPath.Text = log.path;

                    this.Modifier = (AccessModifier)log.modifier;
                    this.Level = (Level)log.table_level;
                    this.Pack = log.packed;
                    this.HasProvier = log.has_provider;
                }
                else
                {
                    this.Modifier = AccessModifier.Public;
                    this.Level = Level.Fixed;
                    this.Pack = false;
                    this.HasProvier = true;
                }
 
                this.txtClass.Text = tname.ClassName;

                this.txtNamespace.Enabled = !log.Exists;
                this.txtClass.Enabled = !log.Exists;
                this.btnBrowse.Enabled = !log.Exists;
                this.comboModule.Enabled = !log.Exists;
            }
        }

        private void showTreeTables(bool showNewTables)
        {
            treeTables.Nodes.Clear();

            TableName tname = new TableName(this.provider, DatabaseName, "any");
            
            this.txtDatabaseId.Text = tname.DatabaseId.ToString();
            string[] tableNames = MetaDatabase.GetTableNames(new DatabaseName(provider, DatabaseName));
            if (showNewTables)
            {
                foreach (string tableName in tableNames)
                {
                    TableName name = new TableName(this.provider, DatabaseName, tableName);

                    if (dpoDict.ContainsKey(name))
                        continue;
                    else
                    {
                        LogDpoClass log = new LogDpoClass(name);
                        if (log.Exists)
                            continue;
                    }

                    TreeNode node = new TreeNode(tableName);
                    node.ImageIndex = 2;
                    treeTables.Nodes.Add(node);
                }
            }
            else
            {
                foreach (string tableName in tableNames)
                {
                    TreeNode node = new TreeNode(tableName);
                    TableName name = new TableName(this.provider, DatabaseName, tableName);

                    if (dpoDict.ContainsKey(name))
                        node.ImageIndex = 1;
                    else
                    {
                        LogDpoClass log = new LogDpoClass(name);
                        if (log.Exists)
                            node.ImageIndex = 1;
                        else
                            node.ImageIndex = 2;
                    }

                    treeTables.Nodes.Add(node);
                }
            }
        }

        private void SetNamespaceAndPath()
        {
            string moduleName = (string)this.comboModule.SelectedItem;

            if (chkFolder.Checked && Level == Level.Fixed)
                this.txtNamespace.Text = string.Format("{0}.{1}.{2}", moduleName, Setting.DPO_CLASS_SUB_NAMESPACE, DatabaseName);
            else
                this.txtNamespace.Text = string.Format("{0}.{1}", moduleName, Setting.DPO_CLASS_SUB_NAMESPACE);


            this.txtPath.Text = Library.AssemblyPath(moduleName, Setting.DPO_CLASS_PATH);
            if (chkFolder.Checked && Level == Level.Fixed)
                this.txtPath.Text += string.Format("\\{0}", DatabaseName);
        }

        private AccessModifier Modifier
        {
            get
            {
                return  (AccessModifier)this.rgModifier.GetEnum();
            }
            set
            {
                this.rgModifier.SetEnum(value);
            }
        }


        private Level Level
        {
            get
            {
                return (Level)rgDpoLevel.GetEnum();
            }
            set
            {
                rgDpoLevel.SetEnum(value);
            }
        }

        public bool Pack
        {
            get { return chkPack.Checked; }
            set { this.chkPack.Checked = value; }
        }

        public bool HasProvier
        {
            get { return chkHasProvider.Checked; }
            set { this.chkHasProvider.Checked = value; }
        }

        private string Path
        {
            get
            {
                return this.txtPath.Text;
            }
           
        }

        private string Namespace
        {
            get
            {
                return this.txtNamespace.Text;
            }
    
        }

        private bool MustGenerate
        {
            get
            {
                return this.chkMustGenerate.Checked;
            }
        }

        private string DatabaseName
        {
            get
            {
                return this.comboDatabase.Text;
            }
        }

        private string TableName { get { return this.txtTableName.Text; } }

    

      

        private void btnGenDpoClass_Click(object sender, EventArgs e)
        {
            this.txtOutput.Text = "";

            string className = this.txtClass.Text;
            ClassTableName ctname = new ClassTableName(this.provider, DatabaseName, TableName);

            ClassName cname = new ClassName(Namespace, Modifier, className);
            ctname.SetProperties(this.Level, this.Pack, this.HasProvier);

            if (className == "" || TableName == "" || Namespace == "")
            {
                this.ErrorMessage = "class or namespace name is not defined";
                
                return;
            }
            try
            {
                if (ctname.GenTableDpo(Path, this.chkMustGenerate.Checked, cname, true, dpoDict))
                {
                    if (treeTables.SelectedNode.ImageIndex == 2)
                    {
                        treeTables.SelectedNode.ImageIndex = 1;
                        //dpoDict.Add(tname, typeof(
                    }

                    this.txtOutput.Text = string.Format("class {0} is created from {1} at {2}", cname, ctname, Path);
                }
                else
                    this.txtOutput.Text = string.Format("class {0} matches table {1}, not generate class", cname, ctname);
            }
            catch (Exception ex)
            {
                this.ShowMessageBox(ex);
            }
        }


        private void btnUpgradeDpo_Click(object sender, EventArgs e)
        {
            this.txtOutput.Text = "";
            this.Cursor = Cursors.WaitCursor;

            string output = "";
            foreach (TreeNode node in treeTables.Nodes)
            {
                if (!node.Checked)
                    continue;

                ClassTableName ctname = new ClassTableName(this.provider, DatabaseName, node.Text);
                if (!dpoDict.ContainsKey(ctname))
                    continue;

                Type ty = dpoDict[ctname];
                string path = Library.AssemblyPath(ty.Assembly, Setting.DPO_CLASS_PATH);  

                DPObject dpo = (DPObject)Activator.CreateInstance(ty);
                ClassName cname = new ClassName(dpo);
                ctname.SetProperties(dpo.Level, dpo.IsPack, dpo.HasProvider);

                if (ctname.GenTableDpo(path, this.chkMustGenerate.Checked, cname, true, dpoDict))
                    output += string.Format("class {0} is upgraded from table {1} at {2}\r\n", cname, ctname, path);
                else
                    output += string.Format("class {0} is skipped from table {1}\r\n", cname, ctname);
            }

            if(output != "")
                this.txtOutput.Text = output;
            else
                this.txtOutput.Text = "Nothing is upgraded, make sure the tables checked before upgrading";

            this.Cursor = Cursors.Default;

        }

        private void btnCreateNewDpo_Click(object sender, EventArgs e)
        {

            if (Namespace == "")
            {
                this.WarningMessage = "namespace is not defined.";
                return;
            }
            this.txtOutput.Text = "";
            this.Cursor = Cursors.WaitCursor;

            string output = "";
            foreach (TreeNode node in treeTables.Nodes)
            {
                if (!node.Checked)
                    continue;

                ClassTableName ctname = new ClassTableName(this.provider, DatabaseName, node.Text);
                ctname.SetProperties(this.Level, this.Pack, this.HasProvier);
                
                if (dpoDict.ContainsKey(ctname))
                    continue;

                string path = Path;
                if (chkFolder.Checked)
                    path = Path + "\\" + ctname.SubNamespace;

               ClassName cname = new ClassName(Namespace, Modifier, ctname, chkFolder.Checked);
                
               try
                {
                    if (ctname.GenTableDpo(path, this.chkMustGenerate.Checked, cname, true, dpoDict))
                    {
                        if (node.ImageIndex == 2)
                            node.ImageIndex = 1;

                        output += string.Format("class {0} is created from table {1} at {2}\r\n", cname, ctname, path);
                    }
                }
                catch (Exception ex)
                {
                    this.ShowMessageBox(ex);
                }
            }

            if (output != "")
                this.txtOutput.Text = output;
            else
                this.txtOutput.Text = "Nothing is created, make sure the tables checked before creating";

            this.Cursor = Cursors.Default;

        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            fileDialog.SelectedPath = Path;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = fileDialog.SelectedPath;
            }
        }

        private void rgDpoLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        #region Generate Dictionary and SP
        
        private void toolStripButtonGenDict_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            progressBar1.Visible = true;
            txtCounter.Visible = true;
            DatabaseName db = new DatabaseName(provider, this.DatabaseName);

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += delegate(object s, ProgressChangedEventArgs e1)
            {
                progressBar1.Value = e1.ProgressPercentage;
                txtCounter.Text = string.Format("{0} % completed.", e1.ProgressPercentage);
            };

            worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs e1)
            {
                progressBar1.Visible = false;
                txtCounter.Visible = false;
                this.InformationMessage = string.Format("database [{0}] dictionary are updated.", DatabaseName);
            };


            worker.DoWork += delegate(object s, DoWorkEventArgs e1)
            {
                db.RegisterEntireDatabase(worker);
            };

            worker.RunWorkerAsync();
            this.Cursor = Cursors.Default;
        }


   
        

        private void toolStripButtonGenSP_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                Sys.Data.Manager.SpDatabase sp = new SpDatabase(new DatabaseName(provider, DatabaseName), Path);
                int count = sp.Generate(Namespace, "sa", "password");
                this.InformationMessage = string.Format("{0} stored procedures are updated at database [{1}].", count, DatabaseName);
            }
            catch (Exception ex)
            {
                this.ShowMessageBox(ex);
            }

            this.Cursor = Cursors.Default;
        }


        #endregion

        private void chkFolder_CheckedChanged(object sender, EventArgs e)
        {
            SetNamespaceAndPath();
        }

        private void comboModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetNamespaceAndPath();
            Assembly asm = Library.Instance.GetAssembly((string)comboModule.SelectedItem);
            this.txtAssembly.Text = asm.FullName;
        }


   
    
        private void comboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            showTreeTables(false);
        }

        private void comboServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.provider = ((MyProvider)comboServer.SelectedItem).Provider;
            
            comboDatabase.Items.Clear();
            foreach (string db in MetaDatabase.GetDatabaseNames(this.provider))
                comboDatabase.Items.Add(db);


            this.comboDatabase.SelectedIndex= 0;
           
        }

       
    }


    class MyProvider
    {
        DataProvider provider;
        string text;
        
        public MyProvider(KeyValuePair<DataProvider, DataProviderConnection> pair)
        {
            this.provider = pair.Key;
            this.text = pair.Value.Name;
        }

        public DataProvider Provider
        {
            get { return this.provider; }
        }

        public override string ToString()
        {
            return this.text;
        }
    }
}

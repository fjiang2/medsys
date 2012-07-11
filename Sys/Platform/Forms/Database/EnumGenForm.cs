using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Sys.DataManager;
using Sys.ViewManager.DevEx;
using Sys.Modules;
using System.Reflection;

namespace Sys.Platform.Forms
{
    public partial class EnumGenForm : BaseForm
    {
        string rootPath = "C:\\temp";
        EnumTypeManager manager;
        List<Type> enumList;

        public EnumGenForm()
        {
            InitializeComponent();

            this.imageList1.Images.Add(global::Sys.Platform.Properties.Resources.BreakpointHS);
            this.imageList1.Images.Add(global::Sys.Platform.Properties.Resources.bullet_green);
            this.imageList1.Images.Add(global::Sys.Platform.Properties.Resources.bullet_black);
            treeEnumList.ImageList = this.imageList1;


#if DEBUG
            Sys.IO.Path path = new IO.Path();
            rootPath = path.Solution;
#endif
            this.txtPath.Text = rootPath;

            this.rgModifier.LoadEnum<AccessModifier>();
            this.rgModifier.SetEnum(AccessModifier.Public);

            string[] assemblies = Library.RegisteredAssemblyNames;
            foreach (string x in assemblies)
            {
                comboModule.Items.Add(x);
            }


            treeEnumList.AfterSelect += new TreeViewEventHandler(treeEnumList_AfterSelect);

            this.manager = new EnumTypeManager();
            this.enumList = Library.GetEnumTypeList();
            BuildTree(this.manager.Types);
        }


        void treeEnumList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            node.SelectedImageIndex = 0;

            string name = node.Text;

            if (enumList.Exists(item => item.Name == name))
            {
                Type ty = enumList.Find(item => item.Name == name);
                string moduleName = ty.Assembly.GetName().Name;

                this.comboModule.SelectedItem = moduleName;
                this.txtAssembly.Text = ty.Assembly.FullName;
                this.txtClass.Text = ty.Name;

                if (ty.IsPublic)
                    this.Modifier = DataManager.AccessModifier.Public;
                else
                    this.Modifier = DataManager.AccessModifier.Internal;

                this.txtNamespace.Enabled = false;
                this.txtClass.Enabled = false;
                this.btnBrowse.Enabled = false;
                this.comboModule.Enabled = false;
            }
            else
            {
                this.txtClass.Text = name;

                this.Modifier = DataManager.AccessModifier.Public;

                this.txtNamespace.Enabled = true;
                this.txtClass.Enabled = true;
                this.btnBrowse.Enabled = true;
                this.comboModule.Enabled = true;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Field", typeof(string)));
            dt.Columns.Add(new DataColumn("Value", typeof(int)));

            EnumType enumType = (EnumType)node.Tag;
            foreach (var field in enumType.Fields)
            {
                DataRow row = dt.NewRow();
                row["Field"] = field.Feature;
                row["Value"] = field.Value;

                dt.Rows.Add(row);
            }

            dt.AcceptChanges();
            gridFields.DataSource = dt;

        }


        private void BuildTree(List<EnumType> types)
        {
            treeEnumList.Nodes.Clear();

            foreach (EnumType type in types)
            {
                TreeNode node = new TreeNode(type.Name);
                node.Tag = type;
                if (enumList.Exists(item => item.Name == type.Name))
                    node.ImageIndex = 1;
                else
                    node.ImageIndex = 2;

                treeEnumList.Nodes.Add(node);
            }
        }

        private void SetNamespaceAndPath()
        {
            string moduleName = (string)this.comboModule.SelectedItem;
            this.txtNamespace.Text = moduleName + "";
            this.txtPath.Text = Sys.IO.Path.ModulePath(moduleName);
        }

        private AccessModifier Modifier
        {
            get
            {
                return (AccessModifier)this.rgModifier.GetEnum();
            }
            set
            {
                this.rgModifier.SetEnum(value);
            }
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


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            fileDialog.SelectedPath = Path;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = fileDialog.SelectedPath;
            }
        }

        private void btnGenEnum_Click(object sender, EventArgs e)
        {

        }

        private void btnUpgradeEnums_Click(object sender, EventArgs e)
        {

        }

        private void btnNewEnums_Click(object sender, EventArgs e)
        {

        }

        private void comboModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetNamespaceAndPath();
            Assembly asm = Library.GetRegisteredAssembly((string)comboModule.SelectedItem);
            this.txtAssembly.Text = asm.FullName;
        }
    }
}

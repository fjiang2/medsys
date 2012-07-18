using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Data;
using Sys.ViewManager.Forms;
using Sys.Data.Manager;
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

        private EnumType selectedEnumType;

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
                    this.Modifier = Data.Manager.AccessModifier.Public;
                else
                    this.Modifier = Data.Manager.AccessModifier.Internal;

                this.txtNamespace.Enabled = false;
                this.txtClass.Enabled = false;
                this.btnBrowse.Enabled = false;
                this.comboModule.Enabled = false;
            }
            else
            {
                this.txtClass.Text = name;

                this.Modifier = Data.Manager.AccessModifier.Public;

                this.txtNamespace.Enabled = true;
                this.txtClass.Enabled = true;
                this.btnBrowse.Enabled = true;
                this.comboModule.Enabled = true;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Field", typeof(string)));
            dt.Columns.Add(new DataColumn("Value", typeof(int)));
            dt.Columns.Add(new DataColumn("Caption", typeof(string)));

            EnumType enumType = (EnumType)node.Tag;
            foreach (var field in enumType.Fields)
            {
                DataRow row = dt.NewRow();
                row["Field"] = field.Feature;
                row["Value"] = field.Value;
                row["Caption"] = field.Label;

                dt.Rows.Add(row);
            }

            dt.AcceptChanges();
            gridFields.DataSource = dt;

            this.selectedEnumType = enumType;
        }

        private EnumType GetEnumTypeFromGrid()
        {
            DataTable dt = gridFields.DataSource;

            EnumField dpo;
            List<EnumField> fields = new List<EnumField>();
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    dpo = new EnumField();
                    dpo.Category = selectedEnumType.Name;
                    dpo.Feature = (string)row["Field"];
                    dpo.Value = (int)row["Value"];
                    dpo.Label = row.IsNull<string>("Caption",null);

                    fields.Add(dpo);
                    dpo.Save();
                    row.AcceptChanges();
                }
                else
                {
                    row.RejectChanges();
                    dpo = new EnumField(selectedEnumType.Name, (string)row["Field"]);
                    dpo.Delete();
                    row.AcceptChanges();
                }
            }

            EnumType enumType = new EnumType(fields);

            this.selectedEnumType = enumType;

            //Update TreeNode
            treeEnumList.SelectedNode.Tag = enumType;

            //update EnumType
            this.manager.Types.Add(enumType);

            return enumType;
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


        private void comboModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetNamespaceAndPath();
            Assembly asm = Library.GetRegisteredAssembly((string)comboModule.SelectedItem);
            this.txtAssembly.Text = asm.FullName;
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
            this.Cursor = Cursors.WaitCursor;

            string className = this.txtClass.Text;
            ClassName cname = new ClassName(Namespace, Modifier, className);

            try
            {
                GetEnumTypeFromGrid();
                this.MessageManager.Clear();
                if (!selectedEnumType.Validate(this.MessageManager))
                {
                    this.ErrorMessage = "Invalid enum definition, " + this.MessageManager.ToString();
                    this.MessageManager.Commit();
                    return;
                }

                string sourceCode = selectedEnumType.ToCode(this.Namespace);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(string.Format("{0}\\{1}.cs", this.Path, selectedEnumType.Name));
                sw.Write(sourceCode);
                sw.Close();

                if (this.treeEnumList.SelectedNode.ImageIndex == 2)
                {
                    treeEnumList.SelectedNode.ImageIndex = 1;
                }

                this.InformationMessage = string.Format("enum {0} is created at {1}", cname, Path);
            }
            catch (Exception ex)
            {
                this.ShowMessageBox(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnNewEnums_Click(object sender, EventArgs e)
        {
            string name = "";
            if (InputTool.InputBox("Input enum type name", "Enum Name:", ref name) == System.Windows.Forms.DialogResult.OK)
            { 
                TreeNode node = new TreeNode(name);
                node.Tag = new EnumType(name);
                this.treeEnumList.Nodes.Add(node);
            }
        }

        private void btnGenDict_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.MessageManager.Clear();

            foreach (Type type in this.enumList)
            {
                EnumType enumType = new EnumType(type);
                enumType.Save();

                Message message = Message
                    .Information(string.Format("enum {0} is saved into database", type.FullName))
                    .At(new MessageLocation(typeof(EnumField).TableName().ToString()));
                
                this.MessageManager.Add(message);
            }
            
            this.MessageManager.Commit();
            this.InformationMessage = "Completed to generate Enum Dictionary";

            this.Cursor = Cursors.Default;
        }

     
    }
}

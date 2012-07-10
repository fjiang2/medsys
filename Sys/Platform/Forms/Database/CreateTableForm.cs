using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Sys.Data;
using System.Reflection;
using Sys.Modules;
using Sys.DataManager;
using Sys.IO;

namespace Sys.Platform.Forms
{
    public partial class CreateTableForm : BaseForm
    {
        Assembly asm;

        public CreateTableForm()
        {
            InitializeComponent();

            if (!account.IsAdmin)
                return;

            string[] assemblies = Library.RegisteredAssemblyNames;
            foreach (string x in assemblies)
            {
                comboModule.Items.Add(x);
            }

            comboModule.SelectedIndex = 0;
        }

       


        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            this.txtOuput.Text = "";
            
            if (asm == null)
                return;

            this.txtOuput.Text = Unpacking.CreateTable(asm);
        }


        private void btnCreateAllTable_Click(object sender, EventArgs e)
        {
            this.txtOuput.Text = CreateTable();
        }

        public static string CreateTable()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Assembly asm in Library.GetRegisteredAssemblies())
            {
                sb.AppendLine(Unpacking.CreateTable(asm));
            }
            
            return sb.ToString();
        }


        private void comboModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.Load((string)(comboModule.SelectedItem));
            LoadAssembly(assembly, false);

        }




        private void btnPackModule_Click(object sender, EventArgs e)
        {
            this.txtOuput.Text = "";

            if (asm == null)
                return;

            this.txtOuput.Text = Pack(asm, this.externalAssembly);
        }

        private void btnPackAll_Click(object sender, EventArgs e)
        {
            this.txtOuput.Text = Pack();
        }


        bool externalAssembly = false;
        private void LoadAssembly(Assembly assembly, bool external)
        {
            this.externalAssembly = external;
            this.asm = assembly;
            this.txtAssembly.Text = asm.FullName;

            string output = "";
            foreach (Type type in asm.GetTypes())
            {
                if (type.BaseType == typeof(DPObject))
                {
                    DPObject dpo = (DPObject)Activator.CreateInstance(type);
                    if (dpo.HasAttribute<TableAttribute>())
                    {
                        output += string.Format("class {0} \t-->\t table {1}\r\n", type.FullName, dpo.TableName);
                    }
                }
            }

            this.txtDpoClass.Text = output;

        }

        private static string Pack()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Assembly asm in Library.GetRegisteredAssemblies())
            {
                //don't pack data for PersistentObjects, all data can be re-created
                //if (asm == typeof(DPObject).Assembly)
                //    continue;

                sb.AppendLine(asm.FullName);
                sb.Append(Pack(asm, false));
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static string Pack(Assembly assembly, bool external)
        {

            StringBuilder sb = new StringBuilder();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.BaseType != typeof(DPObject))
                    continue;

                TableAttribute[] A = type.GetAttributes<TableAttribute>();
                if (A.Length == 0 || !A[0].Pack)
                    continue;


                Packing packing = new Packing(type);
                packing.Pack();

                if (!packing)
                {
                      sb.AppendLine(string.Format("Table {0} is empty.", packing.TableName));
                }
                else
                {
                    string path;
                    if(external)
                        path = new Path(assembly).SimplePath + "\\Package";
                    else
                        path = Sys.IO.Path.ModulePackagePath(assembly);

                    string fileName = string.Format("{0}\\{1}.cs", path, packing.ClassName);
                    File.WriteFile(fileName, packing.ToString());

                    sb.AppendLine(string.Format("Table {0} packed into {1}.", packing.TableName, fileName));
                }
            }


            return sb.ToString();

        }

        private void btnUnpackModule_Click(object sender, EventArgs e)
        {
            //Unpacking.Unpack(
        }

      
        private void btnBrowseModule_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Assembly asm = Assembly.LoadFile(fileDialog.FileName);
                LoadAssembly(asm, true);
            }
        }

    }
}

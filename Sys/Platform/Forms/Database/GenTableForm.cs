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
using Sys.Data.Manager;
using Sys.IO;

namespace Sys.Platform.Forms
{
    public partial class GenTableForm : BaseForm
    {
        Assembly asm;

        public GenTableForm()
        {
            InitializeComponent();

            if (!account.IsAdmin)
                return;

            foreach (string x in Library.AssemblyNames)
            {
                comboModule.Items.Add(x);
            }

            
        }

        private void CreateTableForm_Load(object sender, EventArgs e)
        {
            comboModule.SelectedIndex = 0;
        }



        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            if (asm == null)
                return;

            this.ShowMessage(Unpacking.CreateTable(asm), MessagePlace.OutputWindow);
        }


        private void btnCreateAllTable_Click(object sender, EventArgs e)
        {
            this.ShowMessage(CreateTable(), MessagePlace.OutputWindow);
        }

        public static MessageBuilder CreateTable()
        {
            MessageBuilder messages = new MessageBuilder();
            foreach (Assembly asm in Library.Assemblies)
            {
                messages.AddRange(Unpacking.CreateTable(asm));
            }

            return messages;
        }


        private void comboModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.Load((string)(comboModule.SelectedItem));
            LoadAssembly(assembly, false);

        }




        private void btnPackModule_Click(object sender, EventArgs e)
        {
            
            if (asm == null)
                return;

            MessageBuilder messages = Pack(asm, this.externalAssembly);
            if (messages.Count() == 0)
                this.ShowMessageBox(Message.Warning("No table needs to be packed."));
            else
                this.ShowMessage(messages, MessagePlace.OutputWindow);
        }

        private void btnPackAll_Click(object sender, EventArgs e)
        {
           this.ShowMessage(Pack(), MessagePlace.OutputWindow);
        }


        bool externalAssembly = false;
        private void LoadAssembly(Assembly assembly, bool external)
        {
            this.externalAssembly = external;
            this.asm = assembly;
            this.txtAssembly.Text = asm.FullName;

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Namcespace", typeof(string)));
            dt.Columns.Add(new DataColumn("Class", typeof(string)));
            dt.Columns.Add(new DataColumn("Database", typeof(string)));
            dt.Columns.Add(new DataColumn("Table", typeof(string)));
            dt.Columns.Add(new DataColumn("Package", typeof(bool)));
            foreach (Type type in asm.GetTypes())
            {
                if (type.BaseType == typeof(DPObject))
                {
                    DPObject dpo = (DPObject)Activator.CreateInstance(type);
                    if (dpo.HasAttribute<TableAttribute>())
                    {
                        TableAttribute[] A = type.GetAttributes<TableAttribute>();
                        DataRow row = dt.NewRow();
                        int i = 0;
                        row[i++] = type.Namespace;
                        row[i++] = type.Name;
                        row[i++] = dpo.TableName.DatabaseName;
                        row[i++] = dpo.TableName.Name;
                        row[i++] = A[0].Pack;
                        dt.Rows.Add(row);
                    }
                }
            }

            this.jGridView1.ReadOnly = true;
            this.jGridView1.DataSource = dt;

        }

        private MessageBuilder Pack()
        {
            MessageBuilder messages = new MessageBuilder();
            foreach (Assembly asm in Library.Assemblies)
            {
                //don't pack data for PersistentObjects, all data can be re-created
                //if (asm == typeof(DPObject).Assembly)
                //    continue;

                messages.Add(Message.Information(asm.FullName));
                messages.AddRange(Pack(asm, false));
            }
            return messages;
            
        }

        private static MessageBuilder Pack(Assembly assembly, bool external)
        {

            MessageBuilder messages = new MessageBuilder();
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
                      messages.Add(new Message(MessageLevel.Warning, string.Format("Table {0} is empty.", packing.TableName)));
                }
                else
                {
                    string path;
                    if(external)
                        path = new Path(assembly).SimplePath + "\\"+ Setting.DPO_PACKAGE_PATH;
                    else
                        path = Library.AssemblyPath(assembly, Setting.DPO_PACKAGE_PATH);

                    string fileName = string.Format("{0}.cs", packing.ClassName);
                    File.WriteFile(path, fileName, packing.ToString());

                    messages.Add(new Message(MessageLevel.Information, string.Format("Table {0} packed into {1}\\{2}.", packing.TableName, path, fileName)));
                }
            }


            return messages;

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

        private void txtAssembly_TextChanged(object sender, EventArgs e)
        {

        }

   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.ViewManager.Forms;

namespace Sys.Platform.Securtity
{
    class FormTree
    {
        public const string BaseTypeNodeText = ": Base Types";

        public FormTree()
        { 
        }
        
        public void BuildWinFormTree(TreeNode parent)
        {
             
            string[] assemblies = Sys.Modules.Library.RegisteredAssemblyNames;
            foreach (string x in assemblies)
            {
                Assembly assembly = null;
                foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (asm.GetName().Name == x)
                    {
                        assembly = asm;
                        break;
                    }
                }

                if (assembly == null)
                {
                    try
                    {
                        assembly = Assembly.Load(x);
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        throw e;
                    }
                }

                TreeNode treeNode = new TreeNode(assembly.FullName.Substring(0, assembly.FullName.IndexOf(",")));
                treeNode.ImageKey = "Package";
                treeNode.SelectedImageKey = treeNode.ImageKey;
                parent.Nodes.Add(treeNode);
                BuildAssembly(treeNode, assembly);

            }

        }

        private void BuildAssembly(TreeNode parent, Assembly assembly)
        {
            foreach (Type type in assembly.GetExportedTypes())
                BuildClass(parent, type);
        }

        private void BuildClass(TreeNode parent, Type type)
        {
            if (!type.IsSubclassOf(typeof(BaseForm)))
                return;

            FormNode2 entity = new FormNode2(type);
            parent.Nodes.Add(entity);

            if (type.BaseType.Name != typeof(BaseForm).Name)
            {
                FormNode2 baseNode = new FormNode2(BaseTypeNodeText, BaseTypeNodeText);
                entity.Nodes.Add(baseNode);
                BuildClass(baseNode, type.BaseType);
            }

        }
      
    }
}

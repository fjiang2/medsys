using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Tie;
using Sys.OS;
using Sys.ViewManager.Forms;

namespace Sys.ViewManager.Security
{
    public class FormStore
    {
        static object[] checkedClasses;
        public const string BaseTypeNodeText = ": Base Types";

  
        public static bool IsCheckedClass(string className)
        {
            if(checkedClasses ==null)
                checkedClasses = (object[])Configuration.Instance["Security.Classes"];

            foreach (object c in checkedClasses)
                if ((string)c == className)
                    return true;

            return false;
        }

        public FormStore(TreeNode parent)
        {
            checkedClasses = (object[])Configuration.Instance["Security.Classes"];


            foreach (string x in Sys.Modules.Library.AssemblyNames)
            {
                Assembly assembly = null;
                try
                {
                    assembly = Assembly.Load(x as string);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    throw e;
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
                BuildClass(parent, type, EntityNodeType.Class);
        }


        List<EntityNode> winFormList = new List<EntityNode>();
        private void BuildClass(TreeNode parent, Type type, EntityNodeType entityType)
        {
            if (type.IsSubclassOf(typeof(BaseForm)))
            {
                EntityNode entity = new EntityNode(type);
                parent.Nodes.Add(entity);
                if (entityType == EntityNodeType.Class)
                {
                    winFormList.Add(entity);
                }

                if (type.BaseType.Name != typeof(BaseForm).Name)
                {
                    EntityNode baseNode = new EntityNode(EntityNodeType.BaseClass, BaseTypeNodeText, BaseTypeNodeText);
                    entity.Add(baseNode);
                    BuildClass(baseNode, type.BaseType, EntityNodeType.BaseClass);
                }

                BuildFields(parent.GetType(), entity, type);
            }

        }



        private void BuildFields(Type grandParent, EntityNode parent, Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo info in fields)
            {
            
                bool userControl = info.FieldType.IsSubclassOf(typeof(UserControl)); 
                if (IsCheckedClass(info.FieldType.FullName) || userControl)
                {
                    EntityNode entity = new EntityNode(info);
                    parent.Add(entity);

                    if (userControl)
                    {
                        if (grandParent != info.FieldType)
                             BuildFields(type, entity, info.FieldType);
                    }

                }

            }

            return;
        }

 
        public void Load(int roleID)
        {
            EntityNode.Load(roleID, SecurityType.WinForm, winFormList);
        }

        public void Save(int roleID)
        {
            EntityNode.Save(roleID, SecurityType.WinForm, winFormList);
        }
        
    

    }
}

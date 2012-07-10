using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.ViewManager.Forms;
using Sys.ViewManager;
using Sys.Data;
using Sys.ViewManager.Security;
using Sys.Security;
using Sys.PersistentObjects.Dpo;

namespace Sys.ViewManager.Security
{
    public class HookTree
    {
        ItemStore store;
        SecurityType type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="label"></param>
        /// <param name="definition">DataTable must include 3 columns [ID], [ParentID], [Label]</param>
        /// <param name="type"></param>
        public HookTree(TreeView treeView, string label, DataTable definition, SecurityType type)
        {
            this.type = type;
            ItemNode entitity = new ItemNode(0, label);
            treeView.Nodes.Add(entitity);
            this.store = new ItemStore(entitity, definition);
        }

        public void Load(int currentRoleID)
        {
            store.Load(type, currentRoleID);
        }

        public void Save(int currentRoleID)
        {
            store.Save(type, currentRoleID);
        }
    }
}

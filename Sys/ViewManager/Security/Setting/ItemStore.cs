using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace Sys.ViewManager.Security
{
    public class ItemStore
    {
        ItemNode parent;

        public ItemStore(ItemNode parent, DataTable dataTable)
        {
            this.parent = parent;
            BuildMenu(dataTable, parent, 0);
            return;
        }

        private void BuildMenu(DataTable dataTable, ItemNode parent, int parentID)
        {
            DataRow[] dataRows = dataTable.Select(string.Format("ParentID={0}", parentID));
            foreach (DataRow dataRow in dataRows)
            {
                string label = dataRow["Label"].ToString();
                int id = (int)dataRow["ID"];

                ItemNode entity = new ItemNode(id, label);
                if (id < 0)
                    entity.Enabled = false;

                parent.Nodes.Add(entity);
                BuildMenu(dataTable, entity, id);
            }
        }

        public void Load(SecurityType ty, int roleID)
        {
            ItemNode.Load(parent, ty, roleID);
        }

        public void Save(SecurityType ty, int roleID)
        {
            ItemNode.Save(parent, ty, roleID);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Tie;
using System.Data;
using Sys.Data;
using Sys.ViewManager.DpoClass;



namespace Sys.ViewManager.Security
{



    public class ItemNode : EntityNode
    {
        const string visible = "visible";
        const string enabled = "enabled";


        public ItemNode(int id, string label)
            : base(EntityNodeType.Independent, id.ToString(), string.Format("{1} [{0}]", id, label))
        {

        }

        protected override VAL Collect()
        {
            VAL val = new VAL();
            if (Visible)
                val[visible] = new VAL(Visible);

            if (Enabled)
                val[enabled] = new VAL(Enabled);
            
            return val;
        }

        protected override void Fill(VAL val)
        {
            VAL p = val[visible];

            if (p.Defined)
                Visible = p.Boolcon;
            else
                Visible = false;

            p = val[enabled];
            if (p.Defined)
                Enabled = p.Boolcon;
            else
                Enabled = false;

            return;
        }

        public void Save(int roleID, SecurityType ty)
        {
            string v = this.Value;
            if (v != "null")
            {
                ItemPermission permission = new ItemPermission();
                permission.Role_ID = roleID;
                permission.Ty = (int)ty;
                permission.ID = Int32.Parse(this.Name);
                permission.Visible = Visible;
                permission.Enabled = Enabled;
                permission.Save();
            }
            
            foreach (TreeNode treeNode in this.Nodes)
            {
                if (treeNode is ItemNode)
                {
                    ItemNode entity = (ItemNode)treeNode;
                    entity.Save(roleID, ty);
                }
            }
        }

        public void Load(DataTable dataTable)
        {
            Clear();
            if (dataTable == null)
                return;

            DataRow[] x = dataTable.Select(string.Format("ID={0}", this.Name));

            if (x.Length != 0)
            {
                this.Visible = (bool)x[0]["Visible"];
                this.Enabled = (bool)x[0]["Enabled"];
            }

            foreach (TreeNode treeNode in this.Nodes)
            {
                if (treeNode is ItemNode)
                {
                    ItemNode entity = (ItemNode)treeNode;
                    entity.Load(dataTable);
                }
            }

        }


        public static void Save(ItemNode entity, SecurityType ty, int roleID)
        {
            ItemPermission permission = new ItemPermission();
            permission.TableName.SqlDelete("{0}={1} AND {2}={3}", ItemPermission._Role_ID, roleID, ItemPermission._Ty, (int)ty);
            entity.Save(roleID, ty);
        }
        
        public static void Load(ItemNode entity, SecurityType ty, int roleID)
        {
            ItemPermission permission = new ItemPermission();
            DataTable dataTable = new TableReader<ItemPermission>("{0}={1} AND {2}={3}", ItemPermission._Role_ID, roleID, ItemPermission._Ty, (int)ty).Table;
            entity.Load(dataTable);
        }

        public static void CloneIRole(int from, int to)
        {
            ItemPermission permission = new ItemPermission();
            DataTable dataTable = new TableReader<ItemPermission>("{0}={1}", ItemPermission._Role_ID, from).Table;
            permission.TableName.SqlDelete("{0}={1}", ItemPermission._Role_ID, to);

            foreach (DataRow dr in dataTable.Rows)
            {
                permission = new ItemPermission(dr);
                permission.Role_ID = to;
                permission.Save();
            }

        }
    }
}

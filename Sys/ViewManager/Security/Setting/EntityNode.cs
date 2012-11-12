using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Tie;
using System.Data;
using Sys.Data;



namespace Sys.ViewManager.Security
{

 

  

    public class EntityNode : TreeNode
    {
        EntityNodeType ty = EntityNodeType.None;
        
        //Field
        public EntityNode(FieldInfo fieldInfo)
        {
            this.Text = string.Format("{0} {1}", fieldInfo.FieldType.Name, fieldInfo.Name);
            this.Name = fieldInfo.Name;
            this.ty = EntityNodeType.Field;
            
            Visible = false;
            Enabled = false;
        }


        //Class
        public EntityNode(Type type)
        {
            this.Text = string.Format("{0} : {1}", type.FullName, type.BaseType.Name);
            this.Name = type.FullName;
            this.ty = EntityNodeType.Class;

            Visible = false;
            Enabled = false;            
        }

        //Base Class
        public EntityNode(EntityNodeType type, string key, string label)
        {
            this.Text = label;
            this.Name = key;
            this.ty = type;

            Visible = false;
            Enabled = false;
        }



        public int Add(EntityNode securityEntity)
        {
            return this.Nodes.Add(securityEntity);
        }

        public bool Enabled
        {
            get
            {
                return this.Checked;
            }
            set
            {
                this.Checked = value;
            }
        }

        public bool Visible
        {
            get
            {
                return this.ImageKey == "Visible";
            }
            set
            {
                this.ImageKey = value ? "Visible" : "Invisible";
                this.SelectedImageKey = this.ImageKey;
                
            }
        
        }


        public void SetChildrenNodes(string property, bool value)
        {
            if (property == "Visible")
                Visible = value;
            else if (property == "Enabled")
                Enabled = value;

            foreach (TreeNode treeNode in this.Nodes)
            {
                if (treeNode is EntityNode)
                {
                    EntityNode entity = (EntityNode)treeNode;
                    if (property == "Visible")
                        entity.Visible = value;
                    else if (property == "Enabled")
                        entity.Enabled = value;

                    entity.SetChildrenNodes(property, value);
                }
            }
        }

        protected virtual VAL Collect()
        {
            VAL val = new VAL();
            if(Visible)
                val["visible"] = new VAL(Visible);
            
            if(Enabled)
                val["enabled"] = new VAL(Enabled);
            
            if (this.Nodes.Count > 0)
            {
                VAL L2 = new VAL();
                foreach (TreeNode treeNode in this.Nodes)
                {
                    if (treeNode is EntityNode)
                    {
                        EntityNode entity = (EntityNode)treeNode;
                        VAL p = entity.Collect();
                        if (!p.IsNull)
                            L2[entity.Name] = p;
                    }
                }
                
                if (!L2.IsNull)
                    val["nodes"] = L2;
            }
            return val;
        }

        protected virtual void Fill(VAL val)
        {
            VAL p = val["visible"];

            if (p.Defined)
                Visible = p.Boolcon;
            else
                Visible = false;

            p = val["enabled"];
            if (p.Defined)
                Enabled = p.Boolcon;
            else
                Enabled = false;

            if (this.Nodes.Count > 0)
            {
                VAL L2 = val["nodes"];
                if (L2.Undefined)
                    return;

                foreach (TreeNode treeNode in this.Nodes)
                {
                    if (treeNode is EntityNode)
                    {
                        EntityNode entity = (EntityNode)treeNode;
                        p = L2[entity.Name];
                        if (p.Defined)
                             entity.Fill(p);
                    }
                }
            }
            return;
        }

        public string Value
        {
            get
            {
                return Collect().ToString();
            }
            set
            {
                Fill(Script.Evaluate(value));
            }
        }

        public void Clear()
        {
            Visible = false;
            Enabled = false;
            foreach (TreeNode treeNode in this.Nodes)
            {
                if (treeNode is EntityNode)
                {
                    EntityNode entity = (EntityNode)treeNode;
                    entity.Visible = false;
                    entity.Enabled = false;
                    entity.Clear();
                }
            }
        }
        
        public override string ToString()
        {
            return string.Format("{0}: {1}/{2}", Text, Visible ? "V" : "I",  (Enabled ? "E" : "D"));             
        }


        public static void Load(int roleID, SecurityType ty, List<EntityNode> list)
        {
            //"Role_ID={0} AND Ty={1}"
            DataTable dataTable = new TableReader<FormPermission>(
                FormPermission._Role_ID.ColumnName() == roleID 
                & FormPermission._Ty.ColumnName() == ty).Table;
            
            foreach (EntityNode entity in list)
            {
                entity.Clear();
            }

            if (dataTable == null)
                return;

            foreach (EntityNode entity in list)
            {
                DataRow[] x = dataTable.Select(string.Format("Key_Name='{0}'", entity.Name));
                if (x.Length == 0)
                    continue;
                else
                    entity.Value = x[0]["Value"].ToString();
            }

        }

        public static void Save(int roleID, SecurityType ty, List<EntityNode> list)
        {
            FormPermission permission = new FormPermission();

            foreach (EntityNode entity in list)
            {
                string v = entity.Value;
                if (v != "null")
                {
                    permission.Role_ID = roleID;
                    permission.Ty = (int)ty;
                    permission.Key_Name = entity.Name;
                    permission.Value = v;
                    permission.Save();
                }
                else
                {
                    permission.Role_ID = roleID;
                    permission.Ty = (int)ty;
                    permission.Key_Name = entity.Name;
                    permission.Delete();
                }
            }

        }

        public static void CloneFormRole(int from, int to)
        {
            FormPermission permission = new FormPermission();

            int ty = (int)SecurityType.WinForm;
            //Role_ID={0} AND Ty={1}
            DataTable dataTable = new TableReader<FormPermission>(
                FormPermission._Role_ID.ColumnName() == from
                & FormPermission._Ty.ColumnName() == ty)
                .Table;

            permission.TableName.SqlDelete("Role_ID={0} AND Ty={1}", to, ty);
            foreach (DataRow dr in dataTable.Rows)
            {
                permission = new FormPermission(dr);
                permission.Role_ID = to;
                permission.Save();
            }

        }
    

    }
}

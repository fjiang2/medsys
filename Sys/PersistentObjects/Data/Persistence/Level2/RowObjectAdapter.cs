using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Sys.Data
{
    class RowObjectAdapter : RowAdapter
    {
        private PersistentObject obj;


        public RowObjectAdapter(PersistentObject obj)
            : this(obj, new Selector())
        {
            this.obj = obj;
        }

        public RowObjectAdapter(PersistentObject obj, Selector columnNames)
            : base( obj.TableName, obj.Locator, obj.NewRow)
        {
            this.obj = obj;
            this.transaction = obj.Transaction;
            Connect(columnNames);
            
        }

        private RowObjectAdapter Connect(Selector columnNames)
        {

            foreach (FieldInfo fieldInfo in Reflex.GetPublicFields(obj))
            {
                ColumnAttribute attribute = Reflex.GetColumnAttribute(fieldInfo);

                if (attribute != null && this.Row.Table.Columns.Contains(attribute.ColumnNameSaved))
                {
                    DataField field = this.fields.Add(attribute.ColumnNameSaved, attribute.SqlDbType);
                    ColumnAdapter column = new ColumnAdapter(field);
                    this.Connect(column);

                    column.Field.Identity = attribute.Identity;
                    column.Field.Primary = attribute.Primary;

                    if (attribute.Identity || ! columnNames.Exists(attribute.ColumnNameSaved))
                        column.Field.Saved = false;
                    else
                        column.Field.Saved = attribute.Saved;
                }
            }

            //in case of ColumnAttribute not setup Identity and Primary Keys
            fields.UpdatePrimaryIdentity(obj.Primary, obj.Identity);

            return this;
        }



        public void Apply()
        {
            foreach (FieldInfo fieldInfo in Reflex.GetPublicFields(obj))
            {
                ColumnAttribute a = Reflex.GetColumnAttribute(fieldInfo);
                if (a != null && this.Row.Table.Columns.Contains(a.ColumnNameSaved))
                {
                    if (fieldInfo.GetValue(obj) == null)
                        this.Row[a.ColumnNameSaved] = System.DBNull.Value;
                    else
                        this.Row[a.ColumnNameSaved] = fieldInfo.GetValue(obj);
                }

            }

            this.Fill();
        }




    }
}

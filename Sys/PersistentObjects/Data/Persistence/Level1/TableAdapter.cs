using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Sys.Data
{
    public class TableAdapter
    {
        private ColumnAdapterCollection columns;
        private DataFieldCollection fields;
        private DataTable dataTable;
        private TableName tableName;
        private Locator locator;

        public TableAdapter(DataTable dataTable, TableName tableName, Locator locator)
        {
            this.dataTable = dataTable;
            this.tableName = tableName;
            this.locator = locator;

            this.columns = new ColumnAdapterCollection();
            this.fields = new DataFieldCollection();
        }


        public void AddFields(string[] columnNames)
        {
            if (columnNames == null)
            {
                this.Fields.Add(tableName);
                foreach (DataField field in this.Fields)
                {
                    columns.Add(new ColumnAdapter(field));
                }
            }
            else
            {
                foreach (string name in columnNames)
                {
                    DataField field = this.Fields.Add(dataTable.Columns[name]);
                    columns.Add(new ColumnAdapter(field));
                }
            }

            this.Fields.UpdatePrimaryIdentity(tableName);

        }

        protected RowAdapter GetPersistentRow()
        {
            return new RowAdapter(this.fields, this.columns, this.TableName, this.Locator);
        }

        public DataTable DataTable
        { 
            get { return dataTable; } 
        }

        public TableName TableName
        { 
            get { return tableName; } 
        }

        public ColumnAdapterCollection Columns
        { 
            get { return columns; } 
        }

        public DataFieldCollection Fields
        {
            get { return fields; }
        }

        public Locator Locator
        {
            get { return this.locator;}
        }


        public DataRow AddDataRow(DataRow dataRow)
        {
            DataRow r = dataTable.NewRow();
            foreach (DataColumn c in dataTable.Columns)
            {
                r[c] = dataRow[c.ColumnName];
            }

            dataTable.Rows.Add(r);
            
            return r;
        }

        
#region Load/Save/Delete in SQL server

        public virtual bool Load()
        {
            RowAdapter d = GetPersistentRow(); 

            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow.RowState == DataRowState.Deleted)
                    continue;

                d.UpdateColumnValue(dataRow);
                d.Load();
                foreach (ColumnAdapter column in columns)
                {
                    dataRow[column.Field.Name] = d.Row[column.Field.Name];
                }
            }
            dataTable.AcceptChanges();

            return true ;
        }

       

        public virtual bool Save()
        {
            bool saved = SaveOnly();
            dataTable.AcceptChanges();
            
            return saved;
        }

        public virtual bool SaveOnly()
        {
            bool saved = false;
            RowAdapter d = GetPersistentRow();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow.RowState != DataRowState.Deleted)
                {
                    d.UpdateColumnValue(dataRow);

                    if (DataRowChangedHandler != null)
                        d.RowChanged += DataRowChangedHandler;

                    if (ValueChangedHandler != null)
                        d.ValueChangedHandler = ValueChangedHandler;

                    if (dataRow.RowState != DataRowState.Unchanged)
                    {
                        saved = d.Save();
                    }
                }
                else
                {
                    dataRow.RejectChanges();
                    d.UpdateColumnValue(dataRow);

                    if (DataRowChangedHandler != null)
                        d.RowChanged += DataRowChangedHandler;

                    if (ValueChangedHandler != null)
                        d.ValueChangedHandler = ValueChangedHandler;

                    d.Delete();
                    dataRow.Delete();
                }
            }


            return saved;
        }

        public virtual bool Delete()
        {
            bool deleted = false;
            RowAdapter d = new RowAdapter(this.fields, this.columns, this.TableName, this.Locator); 

            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    dataRow.RejectChanges();
                    d.UpdateColumnValue(dataRow);
                    
                    if (DataRowChangedHandler != null)
                        d.RowChanged += DataRowChangedHandler;

                    if (ValueChangedHandler != null)
                        d.ValueChangedHandler = ValueChangedHandler;

                    deleted = d.Delete();

                    if (deleted)
                        dataRow.Delete();
                }
            }

            dataTable.AcceptChanges();
            return deleted;
        }
#endregion


        public RowChangedHandler DataRowChangedHandler = null;
        public ValueChangedHandler ValueChangedHandler = null;


        public static TableAdapter WriteDataTable(DataTable dataTable, TableName tname, string[] columnNames, Locator locator, RowChangedHandler rowChangedHandler)
        {
            if (dataTable == null)
                return null;

            TableAdapter dt = new TableAdapter(dataTable, tname, locator);

            if(rowChangedHandler != null)
                dt.DataRowChangedHandler += rowChangedHandler;


            if (columnNames == null)
                dt.Fields.Add(tname);
            else
            {
                foreach (string name in columnNames)
                {
                    dt.Fields.Add(dataTable.Columns[name]);
                }
            }

            dt.Fields.UpdatePrimaryIdentity(tname);
            dt.Save();

            return dt;
        }

    }
}

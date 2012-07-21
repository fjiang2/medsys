using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data
{
    public abstract class BaseRowAdapter: System.Collections.IEnumerable
    {
        protected ColumnAdapterCollection columns;
        protected DataFieldCollection fields;

        private TableName tableName;
        protected Locator locator;

        private DataRow loadedRow = null;    //existing row
        private bool? exists = null;

        public BaseRowAdapter(TableName tname, Locator locator)
        {
            this.columns = new ColumnAdapterCollection();
            this.fields = new DataFieldCollection(); 

            this.tableName = tname;
            this.locator = locator;          
        }

        public TableName TableName 
        { 
            get { return this.tableName; } 
        }

        protected void UpdateWhere(Locator where)
        {
            this.locator = where;
        }



        public override string ToString()
        {
            return string.Join<ColumnAdapter>(",", columns);
        }


        public System.Collections.IEnumerator GetEnumerator()
        {
            return columns.GetEnumerator();
        }

        protected SqlTrans transaction = null;
        public void SetTransaction(SqlTrans transaction)
        {
            this.transaction = transaction;
        }




        protected void Validate()
        {
            MetaTable metaTable = tableName.GetCachedMetaTable();
            foreach (ColumnAdapter column in columns)
            {
                DataField field = column.Field;
                if (field.Saved || field.Primary)
                {
                    MetaColumn metaColumn = metaTable[field.Name];

                    if (!metaColumn.Nullable && (column.Value == System.DBNull.Value || column.Value == null))
                        throw new Sys.JException("Column[{0}] value cannot be null", field.Name);

                    if (metaColumn.Oversize(column.Value))
                        throw new Sys.JException("Column[{0}] is oversize, limit={1}, actual={2}", field.Name, metaColumn.Length, ((string)(column.Value)).Length);
                }
            }
        }


        private bool insertIdentityOn = false;
        public bool InsertIdentityOn
        {
            get { return this.insertIdentityOn; }
            set { this.insertIdentityOn = value; }
        }


        public ValueChangedHandler ValueChangedHandler
        {
            set
            {
                foreach (ColumnAdapter column in columns)
                {
                    column.ValueChanged += value;
                }
            }
        }


        #region private SQL Query String Template
        private string selectCommandTemplate
        {
            get { return string.Format("SELECT {0} FROM {1} WHERE {2}", "{0}", tableName, locator); }
        }

        private string updateCommandTemplate
        {
            get { return string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, "{0}", locator); }
        }

        private string insertCommandTemplate
        {
            get { return string.Format("INSERT {0}({1}) VALUES({2}) {3}", tableName, "{0}", "{1}", "{2}"); }
        }

        private string deleteCommandTemplate
        {
            get { return string.Format("DELETE FROM {0} WHERE {1}", tableName, locator); }
        }


        #endregion


        #region private Select/Update/Insert/Delete/Where Query String

        protected string updateQuery()
        {
            string SQL = "";

            foreach (DataField field in fields)
            {
                if (field.Saved)
                {
                    if (SQL != "")
                        SQL += ",";

                    SQL += field.UpdateString();
                }
            }

            SQL = string.Format(updateCommandTemplate, SQL);

            return SQL;
        }

        protected string insertQuery()
        {

            string SQL0 = "";
            string SQL1 = "";
            string SQL2 = "";

            bool hasIdentity = false;
            foreach (DataField field in fields)
            {
                if (SQL0 != "")
                    SQL0 += ",";

                if (SQL1 != "")
                    SQL1 += ",";

                if (field.Identity)
                {
                    hasIdentity = true;

                    if (!this.InsertIdentityOn)
                        SQL2 = string.Format(";SET @{0}=@@IDENTITY", field.Name);  //bug : only suport one identity column 
                    else
                    {
                        string[] s = field.InsertString();
                        SQL0 += s[0];
                        SQL1 += s[1];
                    }
                }
                else if (field.Saved)
                {
                    string[] s = field.InsertString();
                    SQL0 += s[0];
                    SQL1 += s[1];
                }
            }


            if (this.InsertIdentityOn && hasIdentity)
            {
                string SQL = string.Format(insertCommandTemplate, SQL0, SQL1, "");
                return string.Format("SET IDENTITY_INSERT {0} ON; {1}; SET IDENTITY_INSERT {0} OFF", tableName, SQL);
            }

            return string.Format(insertCommandTemplate, SQL0, SQL1, SQL2);
        }

        protected string selectQuery()
        {
            string selector = string.Join(",", fields.Select(field => string.Format("[{0}]", field.Name))); ;
            return string.Format(selectCommandTemplate, selector);
        }

        protected string deleteQuery()
        {
            return deleteCommandTemplate;
        }

        #endregion

    
        protected DataRow LoadRecord()
        {
            if (RefreshRow())
            {
                foreach (ColumnAdapter column in this.columns)
                    column.UpdateValue(this.loadedRow);
            }

            return this.loadedRow;
        }



     

        protected bool RefreshRow()
        {
            SqlCmd sqlCmd = new SqlCmd(selectQuery());
            foreach (ColumnAdapter column in columns)
            {
                column.AddParameter(sqlCmd);
            }

            DataTable dt = sqlCmd.ReadDataTable();

            if (dt.Rows.Count == 0)
            {
                this.loadedRow = dt.NewRow();
                this.exists = false;
                return false;
            }

            if (dt.Rows.Count > 1 && this.locator.Unique)
                throw new ApplicationException("ERROR: Row is not unique.");

            this.loadedRow = dt.Rows[0];
            this.exists = true;
            return true;
        
        }

        public bool Exists
        {
            get
            {
                if (this.exists == null)
                {
                    return RefreshRow();
                }
                else
                    return (bool)exists;
            }
        }


        /// <summary>
        /// Row loaded from SQL Server
        /// </summary>
        public DataRow Row1
        {
            get
            {
                if (this.exists == null)
                {
                    RefreshRow();
                    return this.loadedRow;
                }
                else
                    return this.loadedRow;
            }
        }


   

    }
}

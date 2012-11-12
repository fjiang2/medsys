using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Sys.Data;
using System.Reflection;
using System.Linq;
using Tie;
using Sys.Data.Manager;
using Sys.PersistentObjects.DpoClass;

namespace Sys.Data
{
    class MetaTable
    {
        private TableName tname;
        
        private MetaTable(TableName tname)
        {
            this.tname = tname;
        }


        #region Metadata Table pool
        private static DataPool<TableName, MetaTable> pool = new DataPool<TableName, MetaTable>(20);
        internal static MetaTable GetCachedInstance(TableName tname)
        {
            return pool.GetItem(tname);
        }

        internal static MetaTable GetInstance(TableName tname)
        {
            return new MetaTable(tname);
        }

        #endregion


        public override string ToString()
        {
            return string.Format("{0}..[{1}], Id={2}", tname.DatabaseName, tname.Name, TableID);
        }

        private void LoadSchema()
        {
            //Column Name must match class MetadataColumn
            string SQL = @"
            USE {0}
            SELECT 
                c.name AS ColumnName,
                ty.name AS DataType,
                c.max_length AS Length,
                c.is_nullable AS Nullable,
                c.precision,
                c.scale,
                c.is_identity AS IsIdentity,
                NULL AS ColumnID,
                NULL AS label
             FROM sys.tables t 
                  INNER JOIN sys.columns c ON t.object_id = c.object_id 
                  INNER JOIN sys.types ty ON ty.system_type_id =c.system_type_id AND ty.name<>'sysname'
            WHERE t.name = '{1}' 
            ORDER BY c.column_id 
            ";

            DataTable dt1 = SqlCmd.FillDataTable(tname.Provider, SQL, tname.DatabaseName, tname.Name);
            var list = new TableReader<dictDataColumnDpo>( dictDataColumnDpo._table_id.ColumnName() == TableID).ToList();

            this._columns = new MetaColumnCollection();
            foreach (DataRow row in dt1.Rows)
            {
                var result = list.Where(column=>column.name == (string)row["ColumnName"]).FirstOrDefault();
                if (result != null)
                {
                    row["ColumnID"] = result.column_id;
                    
                    if(result.label!=null)
                        row["label"] = result.label;
                }

                this._columns.Add(new MetaColumn(row));
            }

            this._identity = new IdentityKeys(this._columns);

        
        }



        private MetaColumnCollection _columns = null;
        internal MetaColumnCollection Columns
        {
            get
            {
                if (this._columns == null)
                {
                    LoadSchema();
                    this._columns.UpdatePrimary(this.Primary);
                    this._columns.UpdateForeign(this.Foreign);
                }

                return this._columns;
            }
        }



        private IdentityKeys _identity = null;
        public IdentityKeys Identity
        {
            get
            {
                if (this._columns == null)
                {
                    LoadSchema();
                    this._columns.UpdatePrimary(this.Primary);
                    this._columns.UpdateForeign(this.Foreign);
                } 
                
                return this._identity;
            }
        }



        private PrimaryKeys _primary = null;
        public PrimaryKeys Primary
        {
            get
            {
                if (this._primary == null)
                   this._primary = new PrimaryKeys(tname);

                return this._primary;
            }
        }

        private ForeignKeys _foreign = null;
        public ForeignKeys Foreign
        {
            get
            {
                if (this._foreign == null)
                    this._foreign = new ForeignKeys(tname);

                return this._foreign;
            }
        }



        private int _tableID = -1;
        public int TableID
        {
            get
            {
                if (this._tableID == -1)
                    this._tableID = DictTable.GetId(tname);

                return this._tableID;
            }
        }

        public int ColumnId(string columnName)
        {
            int[] L = this.Columns.Where(column => column.ColumnName == columnName).Select(column => column.ColumnID).ToArray();
            if (L.Length == 0)
                return -1;
            else
                return L[0];
        }
  


        internal MetaColumn this[string columnName]
        {
            get
            {
                foreach (MetaColumn column in this.Columns)
                {
                    if (column.ColumnName == columnName)
                        return column;
                }

                return null;

            }
        }


        public bool ColumnExists(string columnName)
        {
            return this[columnName] != null;
        }

   

        public DataRow NewRow()
        {
            return EmptyDataTable.NewRow();
        }

        private DataTable _thisDataTable = null;
        public DataTable EmptyDataTable
        {
            get
            {
                if (_thisDataTable == null)
                {
                    _thisDataTable = SqlCmd.FillDataTable(tname.Provider, "SELECT TOP 1 * FROM {0}", tname);
                    _thisDataTable.Rows.Clear();
                }

                return _thisDataTable;
            }
        }
  
        public bool Exists
        {
            get
            {
                return MetaDatabase.TableExists(tname);
            }
        }


        public string DatabaseName { get { return this.tname.DatabaseName.Name; } }
        public string TableName { get { return this.tname.Name; } }


        #region Table Attribute Generate

      
        /// <summary>
        /// [TableName.Level] is not updated in [this.tname], then parameter [level] must be passed in
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public string GetTableAttribute(Level level, bool pack)
        {
            string comment = string.Format("//Primary Keys = {0};  Identity = {1};", Primary, Identity);
            string attr = "";
            switch (level)
            {

                case Level.Application:
                    if (pack)
                        attr = string.Format(@"[Table(""{0}"", Level.Application)]", tname.Name);
                    else
                        attr = string.Format(@"[Table(""{0}"", Level.Application, Pack = false)]", tname.Name);
                    break;
                
                case Level.System:
                    if(pack)
                        attr = string.Format(@"[Table(""{0}"", Level.System)]", tname.Name);
                    else
                        attr = string.Format(@"[Table(""{0}"", Level.System, Pack = false)]", tname.Name);
                    break;
                 
                case Level.Fixed:
                    attr = string.Format(@"[Table(""{0}..[{1}]"")]", tname.DatabaseName, tname.Name);
                    break;
            }
                
            return string.Format("{0}    {1}",attr, comment);
        }

   

        #endregion




        //------------------------------------------------------------------------------------

      
        public Locator DefaultLocator()
        {
            return new Locator(this.Primary);
        }



    

        public string GenerateCREATE_TABLE()
        {
            string fields = string.Join(",\r\n", Columns.Select(column => column.GetSQLField()));
            return CREATE_TABLE(fields, this.Primary);

        }



        public static string CREATE_TABLE(string fields, PrimaryKeys primary)
        {

            string primaryKey = "";
            if (primary.Length > 0)
                primaryKey = string.Format("\tPRIMARY KEY({0})", string.Join(",", primary.Keys.Select(key => string.Format("[{0}]", key))));


            string SQL = @"
CREATE TABLE [dbo].[{0}]
(
{1}
{2}
) 
";
            return string.Format(SQL, "{0}", fields, primaryKey);
        }
    }


}

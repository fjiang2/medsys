using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sys.Data;

namespace Sys.Data.Manager
{
    class DataTableDpoClass : IMetaTable
    {

        DataTable table;
        ClassTableName tableName;

        MetaColumnCollection _columns;
        IdentityKeys _identity;
        ComputedColumns _computedColumns;

        public DataTableDpoClass(DataTable table)
        {
            this.table = table;
            this.tableName = new ClassTableName(DataProvider.DefaultProvider, "memory", table.TableName);



            this._columns = new MetaColumnCollection(this);
            foreach (DataColumn c in table.Columns)
            {
                this._columns.Add(new DtColumn(c));
            }

            this._identity = new IdentityKeys(this._columns);
            this._computedColumns = new ComputedColumns(this._columns);

            this._columns.UpdatePrimary(this.Primary);
            this._columns.UpdateForeign(this.Foreign);
        }

        public TableName TableName 
        {
            get
            {
                return tableName;
            }
            
        }
        
        public int TableID
        {
            get
            {
                return -1;
            }
        }

        public IIdentityKeys Identity 
        {
            get
            {
                return _identity;
            }
        }

        public IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{});
            }
        }

        public IForeignKeys Foreign
        {
            get
            {
                return new ForeignKeys(new ForeignKey[] {});
            }
        }

        public MetaColumnCollection Columns 
        {
            get
            {
                return null;
            }
        }

    }


    class DtColumn : IMetaColumn
    {
        DataColumn column;
        public DtColumn(DataColumn column)
        { 
            this.column = column;
        }

        public string ColumnName 
        { 
            get 
            { 
                return column.ColumnName; 
            } 
        }

        public string DataType 
        { 
            get 
            { 
                return column.ColumnName; 
            } 
        }

        public short Length 
        { 
            get 
            { 
                return (short)column.MaxLength; 
            } 
        }

        public bool Nullable 
        { 
            get 
            { 
                return column.AllowDBNull; 
            } 
        }

        public byte precision 
        { 
            get 
            { 
                return 0; 
            } 
        }

        public byte scale 
        { 
            get 
            { 
                return 0; 
            } 
        }

        public bool IsIdentity { get { return column.AutoIncrement; } }

        public bool IsComputed 
        { 
            get 
            { 
                return false; 
            } 
        }

        public int ColumnID
        {
            get 
            { 
                return -1; 
            }
        }

        public IForeignKey ForeignKey 
        {
            get
            {
                return null;
            }
            set
            {
            } 
        }
        
        public SqlDbType SqlDbType 
        { 
            get
            {
                return SqlDbType.NVarChar;
            } 
        }

        public int AdjuestedLength 
        {
            get
            {
                return this.Length;
            }
        }
    }
}


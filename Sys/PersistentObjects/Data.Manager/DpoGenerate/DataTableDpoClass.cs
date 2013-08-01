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
            this.tableName = new ClassTableName(DataProvider.DefaultProvider, "MEM", table.TableName);



            this._columns = new MetaColumnCollection(this);
            foreach (DataColumn c in table.Columns)
            {
                this._columns.Add(new DtColumn(c));
            }

            this._identity = new IdentityKeys(this._columns);
            this._computedColumns = new ComputedColumns(this._columns);

            this._columns.UpdatePrimary(this.PrimaryKeys);
            this._columns.UpdateForeign(this.ForeignKeys);
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
                return 0;
            }
        }

        public IIdentityKeys Identity 
        {
            get
            {
                return _identity;
            }
        }

        public IPrimaryKeys PrimaryKeys
        {
            get
            {
                return new PrimaryKeys(new string[]{});
            }
        }

        public IForeignKeys ForeignKeys
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
                return this._columns;
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
                return column.DataType.ToCType().ToString().ToLower(); 
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


        public bool IsPrimary
        {
            get
            {
                return false;
            }
        }

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
        
        public CType CType 
        { 
            get
            {
                return column.DataType.ToCType();
            } 
        }

    }
}


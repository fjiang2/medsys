//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
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
   

    class MetaTable : ITable
    {
        private TableName tableName;
        
        private MetaTable(TableName tname)
        {
            this.tableName = tname;
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
            return string.Format("{0}..[{1}], Id={2}", tableName.DatabaseName.Name, tableName.Name, TableID);
        }

        private void LoadSchema()
        {
            //Column Name must match class MetadataColumn
            string SQL = @"
            USE [{0}]
            SELECT 
                c.name AS ColumnName,
                ty.name AS DataType,
                c.max_length AS Length,
                c.is_nullable AS Nullable,
                c.precision,
                c.scale,
                c.is_identity AS IsIdentity,
                c.is_computed AS IsComputed,
                NULL AS ColumnID,
                NULL AS label
             FROM sys.tables t 
                  INNER JOIN sys.columns c ON t.object_id = c.object_id 
                  INNER JOIN sys.types ty ON ty.system_type_id =c.system_type_id AND ty.name<>'sysname'
            WHERE t.name = '{1}' 
            ORDER BY c.column_id 
            ";

            DataTable dt1 = SqlCmd.FillDataTable(tableName.Provider, SQL, tableName.DatabaseName.Name, tableName.Name);
            
            List<dictDataColumnDpo> list; 
            if (MetaDatabase.TableExists(typeof(dictDataColumnDpo).TableName()))
            {
                int tableId = this.TableID;
                list = new TableReader<dictDataColumnDpo>(dictDataColumnDpo._table_id.ColumnName() == tableId).ToList();
            }
            else
                list = new List<dictDataColumnDpo>();  //when dictDataColumnDpo doesn't exist

            this._columns = new ColumnCollection(this);
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
            this._computedColumns = new ComputedColumns(this._columns);

            this._columns.UpdatePrimary(this.PrimaryKeys);
            this._columns.UpdateForeign(this.ForeignKeys);

        }



        private ColumnCollection _columns = null;
        public ColumnCollection Columns
        {
            get
            {
                if (this._columns == null)
                    LoadSchema();

                return this._columns;
            }
        }


        #region Primary/Foreign Key

        private PrimaryKeys _primary = null;
        public IPrimaryKeys PrimaryKeys
        {
            get
            {
                if (this._primary == null)
                   this._primary = new PrimaryKeys(tableName);

                return this._primary;
            }
        }

        private ForeignKeys _foreign = null;
        public IForeignKeys ForeignKeys
        {
            get
            {
                if (this._foreign == null)
                    this._foreign = new ForeignKeys(tableName);

                return this._foreign;
            }
        }


        #endregion


        
        #region Identity/Computed column
        
        private IdentityKeys _identity = null;
        public IIdentityKeys Identity
        {
            get
            {
                if (this._columns == null)
                    LoadSchema();

                return this._identity;
            }
        }


        private ComputedColumns _computedColumns = null;
        public ComputedColumns ComputedColumns
        {
            get
            {
                if (this._columns == null)
                    LoadSchema();

                return this._computedColumns;
            }
        }

        #endregion


        private int _tableID = -1;
        public int TableID
        {
            get
            {
                if (this._tableID == -1)
                    this._tableID = DictTable.GetId(tableName);

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
                    _thisDataTable = SqlCmd.FillDataTable(tableName.Provider, "SELECT TOP 1 * FROM {0}", tableName);
                    _thisDataTable.Rows.Clear();
                }

                return _thisDataTable;
            }
        }
  
        public bool Exists
        {
            get
            {
                return MetaDatabase.TableExists(tableName);
            }
        }


        public TableName TableName 
        { 
            get { return this.tableName; } 
        }


        #region Table Attribute Generate

      
        /// <summary>
        /// [TableName.Level] is not updated in [this.tname], then parameter [level] must be passed in
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        internal static string GetTableAttribute(ITable metaTable, ClassTableName ctname)
        {
            string comment = string.Format("//Primary Keys = {0};  Identity = {1};", metaTable.PrimaryKeys, metaTable.Identity);
            StringBuilder attr = new StringBuilder("[Table(");
            TableName tableName = metaTable.TableName;
            switch (ctname.Level)
            {

                case Level.Application:
                    attr.AppendFormat("\"{0}\", Level.Application", tableName.Name);
                    break;
                
                case Level.System:
                    attr.AppendFormat("\"{0}\", Level.System", tableName.Name);
                    break;
                 
                case Level.Fixed:
                    attr = attr.AppendFormat("\"{0}..[{1}]\", Level.Fixed", tableName.DatabaseName.Name, tableName.Name);
                    break;
            }

            
            if (ctname.HasProvider)
            {
                if (!tableName.Provider.Equals(DataProvider.DefaultProvider))
                {
                    attr.AppendFormat(", Provider = {0}", (int)tableName.Provider);
                }
            }

            if (!ctname.Pack)
                attr.AppendFormat(", Pack = false", tableName.Name);

            attr.Append(")]");

            return string.Format("{0}    {1}", attr, comment);
        }

   

        #endregion




        //------------------------------------------------------------------------------------

      
        public Locator DefaultLocator()
        {
            return new Locator(this.PrimaryKeys);
        }



    

        internal static string GenerateCREATE_TABLE(ITable metaTable)
        {
            string fields = string.Join(",\r\n", metaTable.Columns.Select(column => Sys.Data.MetaColumn.GetSQLField(column)));
            return CREATE_TABLE(fields, metaTable.PrimaryKeys);

        }



        public static string CREATE_TABLE(string fields, IPrimaryKeys primary)
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

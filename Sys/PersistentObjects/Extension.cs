using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using Sys.PersistentObjects.DpoClass;

namespace Sys.Data.Manager
{
    public static class Extension
    {


        #region Table Attribute Generate


        /// <summary>
        /// [TableName.Level] is not updated in [this.tname], then parameter [level] must be passed in
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        internal static string GetTableAttribute(this ITable metaTable, ClassTableName ctname)
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
                if (!tableName.Provider.Equals(ConnectionProviderManager.DefaultProvider))
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


       

        public static void DpoExample()
        {
            var transaction = new SqlTrans();
            var dpo1 = new Sys.PersistentObjects.DpoClass.dictDatabaseDpo();
            var dpo2 = new Sys.PersistentObjects.DpoClass.dictDataTableDpo();

            transaction.Add(dpo1);
            transaction.Add(dpo2);

            dpo1.Save();
            dpo2.Insert();

            transaction.Commit();
        }




        public static TableSchema GetSchema(this TableName tname)
        {
            var schema = new TableSchema(tname);
            UpdateTableAndColumnID(schema);
            return schema;
        }

        private static void UpdateTableAndColumnID(this TableSchema schema)
        {
            TableName tname = schema.TableName; 
            int tableId = DictTable.GetId(tname);
            if (tableId == -1)
                return;

            schema._tableID = tableId;

            List<dictDataColumnDpo> list;
            if (typeof(dictDataColumnDpo).TableName().Exists())
            {
                list = new TableReader<dictDataColumnDpo>(dictDataColumnDpo._table_id.ColumnName() == tableId).ToList();
            }
            else
                list = new List<dictDataColumnDpo>();  //when dictDataColumnDpo doesn't exist

            foreach (ColumnSchema col in schema.Columns)
            {
                var result = list.Where(column => column.name == col.ColumnName).FirstOrDefault();
                if (result != null)
                {
                    col.ColumnID = result.column_id;

                    if (result.label != null)
                        col.label = result.label;
                }

            }
        }


        public static int DatabaseId(this DatabaseName databaseName)
        {
            return DictDatabase.GetId(databaseName);
        }

        public static int DatabaseId(this TableName tableName)
        {
            return tableName.DatabaseName.DatabaseId();
        }
    }
}

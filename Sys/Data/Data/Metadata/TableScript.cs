using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data.Comparison;

namespace Sys.Data
{
    class TableScript
    {
        public static readonly string GO = "GO";

        TableName tableName;

        public TableScript(TableName name)
        {
            this.tableName = name;
        }

        #region INSERT/UPDATE/DELETE

        public string INSERT(DataRow row)
        {
            var direct = RowCompare.Direct(row);
            var x1 = direct.Select(p => "[" + p.ColumnName + "]");
            var x2 = direct.Select(p => p.ToScript());

            return string.Format(insertCommandTemplate,
                string.Join(",", x1),
                string.Join(",", x2)
                );
        }

        public string UPDATE(RowCompare compare)
        {
            return string.Format(updateCommandTemplate, compare.Set, compare.Where);
        }

        public string DELETE(DataRow row, IPrimaryKeys primaryKey)
        {
            var L1 = new List<ColumnPair>();
            foreach (var column in primaryKey.Keys)
            {
                L1.Add(new ColumnPair { ColumnName = column, Value = row[column] });
            }

            return string.Format(deleteCommandTemplate, string.Join<ColumnPair>(" AND ", L1));
        }
        
        #endregion

        #region CREATE/DROP Table

        public string CREATE_TABLE()
        {
            TableSchema schema1 = new TableSchema(tableName);
            string format = TableSchema.GenerateCREATE_TABLE(schema1);
            string script = string.Format(format, tableName.Name);
            return script;
        }

        public string DROP_TABLE()
        {
            string script = string.Format("DROP TABLE [{0}]", tableName.Name);
            return script;
        }
        
        #endregion


        #region Add/Alter/Drop Column

        public string ADD_COLUMN(IColumn column)
        {
            return string.Format("ALTER TABLE [{0}] ADD {1}", tableName.Name, ColumnSchema.GetSQLField(column));
        }

        public string ALTER_COLUMN(IColumn column)
        {
            return string.Format("ALTER TABLE [{0}] ALTER COLUMN {1}", tableName.Name, ColumnSchema.GetSQLField(column));
        }

        public string DROP_COLUMN(IColumn column)
        {
            return string.Format("ALTER TABLE [{0}] DROP  COLUMN {1}", tableName.Name, column.ColumnName);
        }

        #endregion

        #region Primary Key

        public string ADD_PRIMARY_KEY(IPrimaryKeys primaryKey)
        {
            return string.Format("ALTER TABLE [{0}] ADD PRIMARY KEY ({1})", tableName.Name, string.Join(",", primaryKey.Keys));
        }

        public string DROP_PRIMARY_KEY(IPrimaryKeys primaryKey)
        {
            return string.Format("ALTER TABLE [{0}] DROP CONSTRAINT ({1})", tableName.Name, primaryKey.ConstraintName);
        }

        #endregion

        #region Foreign Key

        public string DROP_FOREIGN_KEY(IForeignKey foreignKey)
        {
            return string.Format("ALTER TABLE [{0}] DROP CONSTRAINT ({1})", tableName.Name, foreignKey.Constraint_Name);
        }

        public string ADD_FOREIGN_KEY(IForeignKey foreignKey)
        {
            string reference = string.Format(" [{0}]([{1}])", foreignKey.PK_Table, foreignKey.PK_Column);
            return string.Format("ALTER TABLE [{0}] ADD CONSTRAINT [{1}] FOREIGN KEY ([{2}])\nREFERENCES {3}",
                tableName.Name,
                foreignKey.Constraint_Name,
                foreignKey.FK_Column,
                reference
                );
        }

        #endregion

        #region Insert/Update/Delete template
        
        private string updateCommandTemplate
        {
            get { return string.Format("UPDATE [{0}] SET {1} WHERE {2}", tableName.Name, "{0}", "{1}"); }
        }

        private string insertCommandTemplate
        {
            get { return string.Format("INSERT INTO [{0}]({1}) VALUES({2})", tableName.Name, "{0}", "{1}"); }
        }

        private string deleteCommandTemplate
        {
            get { return string.Format("DELETE FROM [{0}] WHERE {1}", tableName.Name, "{0}"); }
        }
        
        #endregion

    }
}

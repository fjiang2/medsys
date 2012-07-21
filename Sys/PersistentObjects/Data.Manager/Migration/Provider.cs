using System;
using System.Collections.Generic;
using System.Data;
using Sys.Data;
using Sys.PersistentObjects.DpoClass;

namespace Sys.Data.Manager
{
	
	public class Provider 
	{
	
        public Provider()
		{
		}
        
        public bool TableExists(TableName table)
        {
            return MetaDatabase.TableExists(table);
        }

        public void AddPrimaryKey(string name, TableName table, params string[] columns)
        {
            if (ConstraintExists(table, name))
                throw new JException("Primary key {0} already exists", name);

            SqlCmd.ExecuteNonQuery("ALTER TABLE {0} ADD CONSTRAINT {1} PRIMARY KEY ({2}) ", table, name, string.Join(",", columns));
        }

        public void RemoveForeignKey(TableName table, string name)
		{
			RemoveConstraint(table, name);
		}

        public  void RemoveConstraint(TableName table, string name)
		{
			if (TableExists(table) && ConstraintExists(table, name))
			{
				SqlCmd.ExecuteNonQuery("ALTER TABLE {0} DROP CONSTRAINT {1}", table, name);
			}
		}


        public void RemoveTable(TableName name)
		{
			if (TableExists(name))
                SqlCmd.ExecuteNonQuery("DROP TABLE {0}", name);
		}

        public void RenameTable(TableName oldName, TableName newName)
		{
			if (TableExists(newName))
				throw new JException("Table with name '{0}' already exists", newName);

			if (TableExists(oldName))
                SqlCmd.ExecuteNonQuery("ALTER TABLE {0} RENAME TO {1}", oldName, newName);
		}







        #region Column Operation Add/Rename/Remove/Change/

        public bool ColumnExists(TableName table, string column)
        {
            return table.GetCachedMetaTable().ColumnExists(column);
        }

        public void AddColumn(TableName table, string column, SqlDbType type, int size, object defaultValue)
        {
            if (ColumnExists(table, column))
                throw new JException("Column {0}.{1} already exists", table, column);

            SqlCmd.ExecuteNonQuery("ALTER TABLE {0} ADD {1} {2} NULL", table, column, type);
        }


        public void RenameColumn(TableName tableName, string oldColumnName, string newColumnName)
		{
			if (ColumnExists(tableName, newColumnName))
                throw new JException("Table '{0}' has column named '{1}' already", tableName, newColumnName);

			if (ColumnExists(tableName, oldColumnName))
                SqlCmd.ExecuteNonQuery("ALTER TABLE {0} RENAME COLUMN {1} TO {2}", tableName, oldColumnName, newColumnName);
		}

        public void RemoveColumn(TableName table, string column)
		{
			if (ColumnExists(table, column))
			{
                DeleteColumnConstraints(table, column);
                SqlCmd.ExecuteNonQuery("ALTER TABLE {0} DROP COLUMN {1} ", table, column);
			}
		}
     
        public void ChangeColumn(TableName table, string sqlColumn)
		{
            if (!ColumnExists(table, sqlColumn))
                throw new JException("Column {0}.{1} does not exist", table, sqlColumn);

            SqlCmd.ExecuteNonQuery("ALTER TABLE {0} ALTER COLUMN {1}", table, sqlColumn);
		}

        #endregion




        public void AddUniqueConstraint(string name, TableName table, params string[] columns)
		{
			if (ConstraintExists(table, name))
				throw new JException("Constraint {0} already exists", name);
				
            SqlCmd.ExecuteNonQuery("ALTER TABLE {0} ADD CONSTRAINT {1} UNIQUE({2}) ", table, name, string.Join(", ", columns));
		}

        public void AddCheckConstraint(string name, TableName table, string checkSql)
		{
			if (ConstraintExists(table, name))
                throw new JException("Constraint {0} already exists", name);

            SqlCmd.ExecuteNonQuery("ALTER TABLE {0} ADD CONSTRAINT {1} CHECK ({2}) ", table, name, checkSql);
		}


        public bool PrimaryKeyExists(TableName table, string name)
		{
			return ConstraintExists(table, name);
		}


        public bool ConstraintExists(TableName table, string name)
        {
            return SqlCmd.FillDataRow("SELECT TOP 1 * FROM sysobjects WHERE id = object_id('{0}')", name) != null;
        }


        private void DeleteColumnConstraints(TableName table, string column)
        {
            string SQL = string.Format(
                @"SELECT cont.name 
                 FROM sysobjects cont, SYSCOLUMNS col, SYSCONSTRAINTS cnt  
                 WHERE cont.parent_obj = col.id AND cnt.constid = cont.id AND cnt.colid=col.colid 
                       AND col.name = '{1}' AND col.id = object_id('{0}')",
                table, column);

            List<string> constraints = new List<string>();
            DataTable dt = SqlCmd.FillDataTable(SQL);
            foreach (DataRow row in dt.Rows)
            {
                RemoveForeignKey(table, (string)row[0]);
            }
        }




        private List<long> appliedMigrations;
        public List<long> AppliedMigrations
		{
			get
			{
                if (appliedMigrations == null)
                {
                    appliedMigrations = new List<long>();
                    var dpc = new DPCollection<MigrationVersionDpo>(new TableReader<MigrationVersionDpo>().Table);
                    foreach(MigrationVersionDpo ver in dpc)
                    {
                        appliedMigrations.Add(ver.Version);
                    }
                }
				return appliedMigrations;
			}
		}

        public void MigrationApplied(int version)
		{

            MigrationVersionDpo ver = new MigrationVersionDpo();
            ver.Version = version;
            ver.Save();
			appliedMigrations.Add(version);
		}
		
		public void MigrationUnApplied(int version)
		{
            MigrationVersionDpo ver = new MigrationVersionDpo();
            ver.Version = version;
            ver.Delete();
			appliedMigrations.Remove(version);
		}


	}
}

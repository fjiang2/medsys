using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data.Manager;

namespace Sys.Data
{
    public class TableName : IComparable<TableName>, IComparable
    {
        protected DataProviderHandle handle = DataProviderHandle.DEFAULT_PROVIDER;
        protected string databaseName;
        protected string tableName;
       
        public TableName(string fullTableName)
        {
            ParseTableName(fullTableName, this);

            if (this.databaseName == "")
                this.databaseName = MetaDatabase.CurrentDatabaseName;
        }

        public TableName(string databaseName, string tableName)
        {
            this.databaseName = databaseName;
            this.tableName = tableName;
        }

       
        public int CompareTo(object obj)
        {
            return CompareTo((TableName)obj);
        }

        public int CompareTo(TableName n)
        {
            return string.Format("{0}::{1}",this.handle, FullName).CompareTo(n);
        }

        public override bool Equals(object obj)
        {
            TableName name = (TableName)obj;
            return FullName.Equals(name.FullName) && this.handle.Equals(name.handle);
        }

        public override int GetHashCode()
        {
            return FullName.GetHashCode()*100 + this.handle.GetHashCode();
        }
    
        public string Name
        {
            get { return this.tableName; }
        }
        
        public string DatabaseName
        {
            get { return this.databaseName; }
        }

    
        public string FullName
        {
            get 
            {
                //Visual Studio 2010 Windows Form Design Mode, does not support format [database]..[table]
                return string.Format("{0}..[{1}]", this.databaseName, this.tableName);  
            }
        }

        public DataProviderHandle Handle
        {
            get { return this.handle; }
            set { this.handle = value; }
        }
            
            
        public override string ToString()
        {
            return FullName;
        }


        
        public int Id
        {
            get
            {
                return this.GetCachedMetaTable().TableID;
            }
        }



        public int ColumnId(string columnName)
        {
            if (Id == -1)
                return -1;

            return this.GetCachedMetaTable().ColumnId(columnName);
        }


        public int DatabaseId
        {
            get
            {
                return DictDatabase.GetId(this.databaseName);
            }
        }

 

        private static void ParseTableName(string fullTableName, TableName tname)
        {
            //tableName may have format like [db.dbo.tableName], [db..tableName], or [tableName]
            string[] t = fullTableName.Split(new char[] { '.' });

            string databaseName = "";
            string tableName = "";
            if (t.Length > 1)
            {
                databaseName = t[0];
                tableName = t[2];
            }
            else
                tableName = fullTableName;

            tname.databaseName = databaseName.Replace("[", "").Replace("]", "");
            tname.tableName = tableName.Replace("[", "").Replace("]", "");
        }


    }
}

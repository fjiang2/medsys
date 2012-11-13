using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        string tableName;

        public bool DefaultValueUsed;
        public Level Level;
        public bool Pack = true;
        public int Provider = (int)DataProvider.DefaultProvider;

        public TableAttribute(string tableName)
            : this(tableName, Level.Fixed)
        {
        }

        public TableAttribute(string tableName, Level level)
        {
            this.tableName = tableName;
            this.Level = level;
            this.DefaultValueUsed = false;
        }

        public TableName TableName
        {
            get 
            {
                TableName name;
                DataProvider provider = new DataProvider(this.Provider);
                switch (this.Level)
                {
                    case Level.System:
                        name = new TableName(provider, Const.DB_SYSTEM, this.tableName);
                        break;

                    case Level.Application:
                        name = new TableName(provider, Const.DB_APPLICATION, this.tableName);
                        break; 

                    default:
                        name = new TableName(provider, this.tableName);
                         break;
                }

                return name;
            }
        }

    }
}

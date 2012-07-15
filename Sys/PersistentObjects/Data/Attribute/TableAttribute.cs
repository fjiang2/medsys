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
                switch (this.Level)
                {
                    case Level.System:
                        return new TableName(Const.DB_SYSTEM, this.tableName);

                    case Level.Application:
                        return new TableName(Const.DB_APPLICATION, this.tableName);
                         

                    default:
                         return new TableName(this.tableName);
                }
            }
        }

    }
}

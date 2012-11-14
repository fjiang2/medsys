using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        private string tableName;
        private Level level;
        private Provider provider;

        public bool DefaultValueUsed = false;
        public bool Pack = true;
       

        public TableAttribute(string tableName, Level level)
            :this(tableName, level, Provider.DefaultDataSource)
        {
            this.tableName = tableName;
            this.level = level;
        }

        public TableAttribute(string tableName, Level level, Provider provider)
        {
            this.tableName = tableName;
            this.level = level;
            this.provider = provider;
        }

        public Level Level
        {
            get { return this.level; }
        }

        public TableName TableName
        {
            get 
            {
                TableName tname;
                DataProvider dataProvider = new DataProvider((int)this.provider);
                switch (this.Level)
                {
                    case Level.System:
                        tname = new TableName(dataProvider, Const.DB_SYSTEM, this.tableName);
                        break;

                    case Level.Application:
                        tname = new TableName(dataProvider, Const.DB_APPLICATION, this.tableName);
                        break; 

                    default:
                        tname = new TableName(dataProvider, this.tableName);
                        break;
                }

                return tname;
            }
        }

    }
}

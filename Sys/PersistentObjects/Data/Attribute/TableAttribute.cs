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
        public int Provider = (int)DataProvider.DEFAULT_HANDLE;

        public bool DefaultValueUsed = false;
        public bool Pack = true;
       

        public TableAttribute(string tableName, Level level)
        {
            this.tableName = tableName;
            this.level = level;
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
                DataProvider dataProvider = new DataProvider(this.Provider);
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

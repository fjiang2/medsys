using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data
{
    public class PrimaryKeys
    {
        private string[] keys;

        public PrimaryKeys(string[] columns)
        {
            this.keys = columns;
        }

        public PrimaryKeys(TableName tname)
        { 
            string SQL = @"
            USE {0}
            SELECT c.COLUMN_NAME 
                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk, 
                     INFORMATION_SCHEMA.KEY_COLUMN_USAGE c 
                WHERE pk.TABLE_NAME = '{1}' 
                      AND CONSTRAINT_TYPE = 'PRIMARY KEY' 
                      AND c.TABLE_NAME = pk.TABLE_NAME 
                      AND c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
            ";

            this.keys = SqlCmd.FillDataTable(SQL, tname.DatabaseName, tname.Name).ToArray<string>(0);
        
        }

        public string[] Keys
        {
            get
            {
                return this.keys;
            }
        }

        public int Length { get { return this.Keys.Length; } }

        public override string ToString()
        {
            return string.Join(" + ", keys);
        }

    }
}

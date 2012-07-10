using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data
{
    public class IdentityKeys
    {
        private string[] keys;

        public IdentityKeys()
        {
            this.keys = new string[0];
        }

        public IdentityKeys(string[] columns)
        {
            this.keys = columns;
        }

        internal IdentityKeys(MetaColumnCollection columns)
        {
            this.keys = columns.Where(column => column.IsIdentity).Select(column => column.ColumnName).ToArray();
        }

        public IdentityKeys(TableName tname)
        { 
            string SQL = @"
            USE {0}
            SELECT c.name
            FROM sys.tables t 
	            JOIN sys.columns c ON t.object_id = c.object_id 
            WHERE t.name = '{1}' AND c.is_identity = 1";

            this.keys = SqlCmd.FillDataTable(SQL, tname.DatabaseName, tname.Name).GetArray<string>(0);
        
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
            return string.Join(" , ", keys);
        }

    }
}

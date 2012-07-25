using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data
{
    class ForeignKeys
    {
        private ForeignKey[] keys;

        public ForeignKeys(ForeignKey[] columns)
        {
            this.keys = columns;
        }

        public ForeignKeys(TableName tname)
        { 
            string SQL = @"
USE {0}
SELECT  FK_Table = FK.TABLE_NAME ,
        FK_Column = CU.COLUMN_NAME ,
        PK_Table = PK.TABLE_NAME ,
        PK_Column = PT.COLUMN_NAME ,
        Constraint_Name = C.CONSTRAINT_NAME
FROM    INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
        INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
        INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
        INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
        INNER JOIN ( SELECT i1.TABLE_NAME ,
                            i2.COLUMN_NAME
                     FROM   INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                            INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                     WHERE  i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                   ) PT ON PT.TABLE_NAME = PK.TABLE_NAME
WHERE FK.TABLE_NAME='{1}'       
            ";

            this.keys = new DPList<ForeignKey>(SqlCmd.FillDataTable(SQL, tname.DatabaseName, tname.Name)).ToArray();
        
        }

        public ForeignKey[] Keys
        {
            get
            {
                return this.keys;
            }
        }

        public int Length { get { return this.Keys.Length; } }

        public override string ToString()
        {
            return string.Join <ForeignKey>(" + ", keys);
        }

    }


    class ForeignKey : PersistentObject
    {
#pragma warning disable

        public string FK_Table;
        public string FK_Column;
        public string PK_Table;
        public string PK_Column;
        public string Constraint_Name;

#pragma warning restore

        public ForeignKey()
        { 
        }

        public ForeignKey(DataRow dataRow)
            : base(dataRow)
        { 
        }

        public override string ToString()
        {
            return string.Format("TABLE {0} CONSTRAINT {1} FOREIGN KEY({2}) REFERENCES {3}({4})", FK_Table, Constraint_Name, FK_Column, PK_Table, PK_Column);
        }
    }
}

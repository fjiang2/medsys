//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data
{
    public interface IForeignKeys
    {
        IForeignKey[] Keys { get; }
        int Length { get; }
    }

    public interface IForeignKey
    {
        string FK_Table { get;  }
        string FK_Column { get; }
        string PK_Table { get; }
        string PK_Column { get;}
        
        string DatabaseName { get; set; }
        DataProvider Provider { get; set; }
    }

    class ForeignKeys : IForeignKeys
    {
        private IForeignKey[] keys;

        public ForeignKeys(IForeignKey[] columns)
        {
            this.keys = columns;
        }

        public ForeignKeys(TableName tname)
        { 
            string SQL = @"
USE [{0}]
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

            this.keys = new DPList<ForeignKey>(SqlCmd.FillDataTable(tname.Provider, SQL, tname.DatabaseName.Name, tname.Name)).ToArray();
            foreach (var key in this.keys)
            {
                key.DatabaseName = tname.DatabaseName.Name;
                key.Provider = tname.Provider;
            }
        }

        public IForeignKey[] Keys
        {
            get
            {
                return this.keys;
            }
        }

        public int Length { get { return this.keys.Length; } }

        public override string ToString()
        {
            return string.Join <IForeignKey>(" + ", keys);
        }

    }


    class ForeignKey : PersistentObject, IForeignKey
    {
#pragma warning disable

        [Column("DatabaseName", CType.NVarChar, Primary = true)]
        public string DatabaseName { get; set; }

        [Column("FK_Table", CType.NVarChar, Primary = true)]
        public string FK_Table { get; set; }

        [Column("FK_Column", CType.NVarChar, Primary = true)]
        public string FK_Column { get; set; }

        [Column("PK_Table", CType.NVarChar)]
        public string PK_Table { get; set; }

        [Column("PK_Column", CType.NVarChar)]
        public string PK_Column { get; set; }

        [Column("Constraint_Name", CType.NVarChar)]
        public string Constraint_Name { get; set; }

#pragma warning restore

        public DataProvider Provider { get; set; }

        public ForeignKey()
        { 
        }

        public ForeignKey(DataRow dataRow)
            : base(dataRow)
        { 
        }

    
        internal static string GetAttribute(IForeignKey key, Type pkTableType)
        {
            return GetAttribute(key, pkTableType.FullName);
        }

        internal static string GetAttribute(IForeignKey key, string dpoClassFullName)
        {
            return string.Format("[{0}(typeof({1}), {1}._{2})]",
                typeof(ForeignKeyAttribute).Name.Replace("Attribute", ""),
                dpoClassFullName,
                key.PK_Column);
        }


        public override string ToString()
        {
            return string.Format("TABLE {0} CONSTRAINT {1} FOREIGN KEY({2}) REFERENCES {3}({4})", FK_Table, Constraint_Name, FK_Column, PK_Table, PK_Column);
        }
    }
}

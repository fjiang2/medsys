﻿//--------------------------------------------------------------------------------------------------//
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
    


    class ForeignKeys : IForeignKeys
    {
        private IForeignKey[] keys;

        public ForeignKeys(IForeignKey[] columns)
        {
            this.keys = columns;
        }

        public ForeignKeys(TableName tname)
        { 

            DataTable table = InformationSchema.ForeignKeySchema(tname);
            
            table.Columns.Add("DatabaseName", typeof(string));
            table.Columns.Add("Provider", typeof(DataProvider));
            foreach (DataRow row in table.Rows)
            {
                row["DatabaseName"] = tname.DatabaseName.Name;
                row["Provider"] = tname.Provider;
            }

            table.AcceptChanges();

            this.keys = new DPList<ForeignKey>(table).ToArray();
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
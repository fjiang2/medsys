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
            USE [{0}]
            SELECT c.name
            FROM sys.tables t 
	            JOIN sys.columns c ON t.object_id = c.object_id 
            WHERE t.name = '{1}' AND c.is_identity = 1";

            this.keys = SqlCmd.FillDataTable(tname.Provider, SQL, tname.DatabaseName.Name, tname.Name).ToArray<string>(0);
        
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

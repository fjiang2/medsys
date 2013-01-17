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
using Sys.Data;
using Sys.PersistentObjects.DpoClass;

namespace Sys.Data.Manager
{
    class DictColumn : dictDataColumnDpo
    {
        public DictColumn()
        { 
        }


        public static void RegisterOnly(int table_id, string columnName)
        {
            dictDataColumnDpo dpo = new dictDataColumnDpo();
            dpo.table_id = table_id;
            dpo.name = columnName;
            dpo.version = Const.Revision;
            dpo.Save();
        }


        /// <summary>
        /// TableName.ColumnId(string columnName) may have good performance, it is cached in MetaTable pool
        /// </summary>
        /// <param name="table_id"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static int GetId(int table_id, string columnName)
        {
            dictDataColumnDpo dpo = new dictDataColumnDpo();
            dpo.table_id = table_id;
            dpo.name = columnName;
            dpo.Load();

            if (dpo.Exists)
                return dpo.column_id;
            else
                return -1;
        }
    }
}

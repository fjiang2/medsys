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
using Sys.Data.Manager;

namespace Sys.Data
{
    public class TableWriter<T> where T : class,  IDPObject, new()
    {
        private DataTable dataTable;

        public TableWriter(DataTable dataTable)
        {
            this.dataTable = dataTable;
        }

        public TableWriter(TableReader<T> reader)
            :this(reader.Table)
        {
        }

        public TableWriter(IEnumerable<T> collection)
            :this(collection.ToTable<T>())
        {
        }

        public TableWriter(DPList<T> list)
            :this(list.Table)
        {
        }


        private TableName TableName
        {
            get
            {
                return typeof(T).TableName();
            }
        }

        public DataTable Table
        {
            get
            {
                return this.dataTable;
            }
        }


        public void Save()
        {
            T dpo = new T();
            TableAdapter.WriteDataTable(dataTable, dpo.TableName, dpo.Locator, null, null, null);
        }

        public override string ToString()
        {
            return string.Format("TableWriter<{0}> Count={1}", typeof(T).FullName, this.dataTable.Rows.Count);
        }
    }
}

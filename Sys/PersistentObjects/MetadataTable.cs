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
using System.Text;
using System.Data;
using System.IO;
using Sys.Data;
using System.Reflection;
using System.Linq;
using Tie;
using Sys.PersistentObjects.DpoClass;

namespace Sys.Data.Manager
{
    class MetadataTable : MetaTable
    {
        public MetadataTable(TableName tname)
            :base(tname)
        { 
        }

        private int _tableID = -1;
        public override int TableID
        {
            get
            {
                if (this._tableID == -1)
                    this._tableID = DictTable.GetId(tableName);

                return this._tableID;
            }
        }


        protected override void LoadSchema()
        {
            base.LoadSchema();

            List<dictDataColumnDpo> list;
            if (MetaDatabase.TableExists(typeof(dictDataColumnDpo).TableName()))
            {
                int tableId = this.TableID;
                list = new TableReader<dictDataColumnDpo>(dictDataColumnDpo._table_id.ColumnName() == tableId).ToList();
            }
            else
                list = new List<dictDataColumnDpo>();  //when dictDataColumnDpo doesn't exist

            foreach (MetaColumn col in base._columns)
            {
                var result = list.Where(column => column.name == col.ColumnName).FirstOrDefault();
                if (result != null)
                {
                    col.ColumnID = result.column_id;

                    if (result.label != null)
                        col.label = result.label;
                }

            }

            
        }


    }
}
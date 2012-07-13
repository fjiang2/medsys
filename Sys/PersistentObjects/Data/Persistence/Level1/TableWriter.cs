
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

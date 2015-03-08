using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sys.Data.Comparison
{
    class RowCompare
    {
        private TableCompare table;
        private List<ColumnPair> L1;
        private List<ColumnPair> L2;

        public RowCompare(TableCompare table, DataRow row1, DataRow row2)
        {
            this.table = table;
            Difference(row1, row2);
        }



        private void Difference(DataRow row1, DataRow row2)
        {

            L1 = new List<ColumnPair>();
            L2 = new List<ColumnPair>();

            foreach (var column in table.NonPkColumns)
            {
                if (!row1[column].Equals(row2[column]))
                    L2.Add(new ColumnPair { ColumnName = column, Value = row1[column] });
            }

            foreach (var column in table.PkColumns.Keys)
            {
                L1.Add(new ColumnPair { ColumnName = column, Value = row1[column] });
            }
        }

        public string Where
        {
            get
            {
                return string.Join<ColumnPair>(" AND ", L1);
            }
        }

        public string Set
        {
            get
            {
                return string.Join<ColumnPair>(", ", L2);
            }
        }


        public static bool Compare(string[] columns, DataRow row1, DataRow row2)
        { 
            foreach(var column in columns)
            {
                if(!row1[column].Equals(row2[column]))
                    return false;
            }

            return true;
        }

        public static IEnumerable<ColumnPair> Direct(DataRow row)
        {
            List<ColumnPair> list = new List<ColumnPair>();
            foreach (DataColumn column in row.Table.Columns)
            {
                if(row[column] != DBNull.Value)
                    list.Add(new ColumnPair { ColumnName = column.ColumnName, Value = row[column] });
            }

            return list;
        }
    }
}

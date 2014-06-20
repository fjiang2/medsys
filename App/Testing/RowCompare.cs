using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace App.Testing
{
    class RowCompare
    {
        TableCompare table;

        public RowCompare(TableCompare table, DataRow row1, DataRow row2)
        {
            this.table = table;
            Difference(row1, row2);
        }


        private List<ColumnPair> L1 = new List<ColumnPair>();
        private List<ColumnPair> L2 = new List<ColumnPair>();

        private void Difference(DataRow row1, DataRow row2)
        {
            L1.Clear();
            L2.Clear();

            foreach (var column in table.NonPkColumns)
            {
                if (!row1[column].Equals(row2[column]))
                    L2.Add(new ColumnPair { ColumnName = column, Value = row1[column] });
            }

            foreach (var column in table.PkColumns)
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
                return string.Join<ColumnPair>(",", L2);
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
    }
}

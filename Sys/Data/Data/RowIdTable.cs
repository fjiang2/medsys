using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sys.Data
{
    public class RowIdTable
    {
        private DataTable table;
        private List<byte[]> R = new List<byte[]>();

        public RowIdTable(DataTable table)
        {
            this.table = table;

            int i = 0;
            int index = -1;

            DataColumn C1 = null;
            foreach (DataColumn column in table.Columns)
            {
                if (column.ColumnName == SqlExpr.PHYSLOC)
                {
                    C1 = column;
                    index = i;
                    break;
                }

                i++;
            }

            if (C1 == null)
                return;

            i = 1;
            foreach (DataRow row in table.Rows)
            {
                R.Add((byte[])row[index]);
                row[index + 1] = i++;
            }

            table.Columns.Remove(C1);
            table.AcceptChanges();
        }


        public DataTable Table { get { return this.table; } }
        public List<byte[]> RL { get { return this.R; } }


        public void Update(SqlBuilder builder)
        { 
            
        }
    }
}

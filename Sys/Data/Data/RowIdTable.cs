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
        private bool hasPhysloc = false;

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
                    this.hasPhysloc = true;
                    C1 = column;
                    index = i;
                    break;
                }

                i++;
            }

            if (C1 == null)
                return;

            i = 0;
            foreach (DataRow row in table.Rows)
            {
                R.Add((byte[])row[index]);
                row[index + 1] = i++;
            }

            table.Columns.Remove(C1);
            table.AcceptChanges();
        }

        public bool HasPhysloc
        {
            get { return hasPhysloc; }
        }

        public DataTable Table { get { return this.table; } }

        public byte[] PhysLoc(int rowId)
        {
            if (rowId < 0 || rowId > R.Count - 1)
                throw new IndexOutOfRangeException("RowId is out of range");

            byte[] B = R[rowId];
            
            return B;
        }


     
    }
}

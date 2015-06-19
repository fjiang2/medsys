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
        public readonly TableName TableName;
        private DataTable table;
        private List<byte[]> LOC = new List<byte[]>();
        private bool hasPhysloc = false;

        public RowIdTable(TableName tname, DataTable table)
        {
            this.TableName = tname;
            this.table = table;

            int i = 0;
            int index = -1;

            DataColumn col = null;
            foreach (DataColumn column in table.Columns)
            {
                if (column.ColumnName == SqlExpr.PHYSLOC)
                {
                    this.hasPhysloc = true;
                    col = column;
                    index = i;
                    break;
                }

                i++;
            }

            if (col == null)
                return;

            i = 0;
            foreach (DataRow row in table.Rows)
            {
                LOC.Add((byte[])row[index]);
                row[index + 1] = i++;
            }

            table.Columns.Remove(col);
            table.AcceptChanges();
        }

        public bool HasPhysloc
        {
            get { return hasPhysloc; }
        }

        public DataTable Table { get { return this.table; } }

        public byte[] PhysLoc(int rowId)
        {
            if (rowId < 0 || rowId > LOC.Count - 1)
                throw new IndexOutOfRangeException("RowId is out of range");

            return LOC[rowId];
        }


        public object this[string column, int rowId]
        { 
            get
            {
                return table.Rows[rowId][column];
            }
            set
            {
                var builder = WriteValue(column, rowId, value);
                new SqlCmd(builder).ExecuteNonQuery();
                table.AcceptChanges();
            }
        }
     
        public SqlBuilder WriteValue(string column, int rowId, object value)
        {
            table.Rows[rowId][column] = value;
            return new SqlBuilder().UPDATE(TableName).SET(column.Assign(value)).WHERE(PhysLoc(rowId));
        }
     

        public Column[] Columns
        {
            get
            {
                List<Column> L = new List<Column>();
                foreach (DataColumn column in table.Columns)
                {
                    if(column.ColumnName != SqlExpr.ROWID)
                        L.Add(new Column(this, column));
                }

                return L.ToArray();
            }
        }
    }

    public class Column
    {
        private DataColumn column;
        private RowIdTable table;

        internal Column(RowIdTable table, DataColumn name)
        {
            this.table = table;
            this.column = name;
        }

        public object this[int rowId]
        {
            get 
            {
                return table.Table.Rows[rowId][column];
            }
            set
            {
                table.Table.Rows[rowId][column] = value;
            }
        }

        public override string ToString()
        {
            return column.ColumnName;
        }
    }
}

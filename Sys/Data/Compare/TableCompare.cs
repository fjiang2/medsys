using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sys.Data;

namespace Sys.Data.Comparison
{
    class TableCompare
    {
        #region Implemetation

        internal IPrimaryKeys PkColumns;
        internal string[] NonPkColumns;

        private TableName tableName1;
        private TableName tableName2;

        public TableCompare(TableName name1, TableName name2)
        {
            tableName1 = name1;
            tableName2 = name2;
        }

        private string tableName
        {
            get { return tableName1.Name; }
        }

        public string Compare(IPrimaryKeys pk)
        {
            var dt1 = new TableReader(tableName1).Table;
            var dt2 = new TableReader(tableName2).Table;

            return Compare(pk, dt1, dt2);
        }

        private string Compare(IPrimaryKeys pk, DataTable table1, DataTable table2)
        {
            this.PkColumns = pk;
            this.NonPkColumns = table1.Columns.OfType<DataColumn>().Select(row => row.ColumnName).Except(PkColumns.Keys).ToArray();

            StringBuilder builder = new StringBuilder();
            TableScript script = new TableScript(tableName1);
            
            foreach (DataRow row1 in table1.Rows)
            {
                var row2 = table2.AsEnumerable().Where(row => RowCompare.Compare(PkColumns.Keys, row, row1)).FirstOrDefault();

                if (row2 != null)
                {
                    if (!RowCompare.Compare(NonPkColumns, row1, row2))
                    {
                        var compare = new RowCompare(this, row1, row2);

                        builder.AppendLine(script.UPDATE(compare));
                    }
                }
                else
                {
                    builder.Append(script.INSERT(row1));
                    builder.AppendLine();
                }
            }

            if (builder.ToString() != string.Empty)
                builder.AppendLine(TableScript.GO);

            return builder.ToString();
        }

    
        #endregion


       

    }
}

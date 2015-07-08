using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sys.Data.Comparison
{
    public class DatabaseSchemaCompare
    {
        string[] PkColumns = new string[] { "SchemaName", "TableName", "ColumnName" };
        string[] NonPkColumns;

        public DatabaseSchemaCompare(DataTable table1, DataTable table2)
        {
            this.NonPkColumns = table1.Columns.OfType<DataColumn>().Select(row => row.ColumnName).Except(PkColumns).ToArray();

        }

        private List<ColumnPair> Difference(DataRow row1, DataRow row2)
        {
            List<ColumnPair> L1;
            List<ColumnPair> L2;

            L1 = new List<ColumnPair>();
            L2 = new List<ColumnPair>();

            foreach (var column in NonPkColumns)
            {
                if (!row1[column].Equals(row2[column]))
                    L2.Add(new ColumnPair(column, row1[column])) ;
            }

            foreach (var column in PkColumns)
            {
                L1.Add(new ColumnPair(column, row1[column]));
            }

            return L2;
        }

        private string Compare(DataTable table1, DataTable table2)
        {
         
            StringBuilder builder = new StringBuilder();
            
            List<DataRow> R2 = new List<DataRow>();
            foreach (DataRow row1 in table1.Rows)
            {
                var row2 = table2.AsEnumerable().Where(row => RowCompare.Compare(PkColumns, row, row1)).FirstOrDefault();

                if (row2 != null)
                {
                    if (!RowCompare.Compare(NonPkColumns, row1, row2))
                    {
                        var difference = Difference(row1, row2);

                        builder.Append("UPDATE:").Append(difference);
                    }
                    
                    R2.Add(row2);
                }
                else
                {
                    builder.Append("INSERT:").Append(row1);
                    builder.AppendLine();
                }
            }


            foreach (DataRow row2 in table2.Rows)
            {
                if (R2.IndexOf(row2) < 0)
                {
                    builder.AppendLine("DELETE:").Append(row2);
                }
            }

            if (builder.ToString() != string.Empty)
                builder.AppendLine(TableScript.GO);

            return builder.ToString();
        }
    }
}

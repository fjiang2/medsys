using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sys.Data;

namespace App.Testing
{
    public class TableCompare
    {
        string tableName;
        public readonly string[] PkColumns;
        public readonly string[] NonPkColumns;

        DataTable table1;
        DataTable table2;

        public TableCompare(string tableName, string[] pk, DataTable table1, DataTable table2)
        {
            this.tableName = tableName;
            this.PkColumns = pk;

            this.table1 = table1;
            this.table2 = table2;

            this.NonPkColumns = table1.Columns.OfType<DataColumn>().Select(row => row.ColumnName).Except(pk).ToArray();
        }

        public string Compare()
        {
            int count = 0;
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row1 in table1.Rows)
            {
                var row2 = table2.AsEnumerable().Where(row => RowCompare.Compare(PkColumns, row, row1)).FirstOrDefault();

                if (row2 != null)
                {
                    if (!RowCompare.Compare(NonPkColumns, row1, row2))
                    {
                        count++;
                        var compare = new RowCompare(this, row1, row2);
                        
                        builder.AppendFormat(updateCommandTemplate, compare.Set, compare.Where);
                        builder.AppendLine();
                    }
                }
                else
                {
                    //builder.AppendFormat(insertCommandTemplate, row1["ORD"], row1[pk]);
                    builder.AppendLine();
                }
            }

            string script = builder.ToString();
            return script;
        }



        private string updateCommandTemplate
        {
            get { return string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, "{0}", "{1}"); }
        }

        private string insertCommandTemplate
        {
            get { return string.Format("INSERT {0}({1}) VALUES({2}) {3}", tableName, "{0}", "{1}", "{2}"); }
        }


    }
}

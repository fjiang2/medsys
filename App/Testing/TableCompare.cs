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

        private TableCompare(string tableName, string[] pk, DataTable table1, DataTable table2)
        {
            this.tableName = tableName;
            this.PkColumns = pk;

            this.table1 = table1;
            this.table2 = table2;

            this.NonPkColumns = table1.Columns.OfType<DataColumn>().Select(row => row.ColumnName).Except(pk).ToArray();
        }

        private string Compare()
        {
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row1 in table1.Rows)
            {
                var row2 = table2.AsEnumerable().Where(row => RowCompare.Compare(PkColumns, row, row1)).FirstOrDefault();

                if (row2 != null)
                {
                    if (!RowCompare.Compare(NonPkColumns, row1, row2))
                    {
                        var compare = new RowCompare(this, row1, row2);

                        builder.AppendFormat(updateCommandTemplate, compare.Set, compare.Where);
                        builder.AppendLine();
                    }
                }
                else
                {
                    var direct = RowCompare.Direct(row1);
                    var x1 = direct.Select(p => "[" + p.ColumnName + "]");
                    var x2 = direct.Select(p => p.ToScript());
                    
                    builder.AppendFormat(insertCommandTemplate,
                        string.Join(",", x1),
                        string.Join(",", x2)
                        );
                    
                    builder.AppendLine();
                }
            }

            return builder.ToString();
        }

     

        private string updateCommandTemplate
        {
            get { return string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, "{0}", "{1}"); }
        }

        private string insertCommandTemplate
        {
            get { return string.Format("INSERT {0}({1}) VALUES({2})", tableName, "{0}", "{1}"); }
        }


        public static string CompareTableData(string tableName, string[] primaryKeys, DataProvider pvd1, DataProvider pvd2)
        {
            string SQL = string.Format("SELECT * FROM {0}", tableName);

            var dt1 = new SqlCmd(pvd1, SQL).FillDataTable();
            var dt2 = new SqlCmd(pvd2, SQL).FillDataTable();

            TableCompare compare = new TableCompare(tableName, primaryKeys, dt1, dt2);
            string script = compare.Compare();

            return script;
        }
    }
}

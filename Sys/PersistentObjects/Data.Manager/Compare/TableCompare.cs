using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sys.Data;

namespace Sys.Data.Manager
{
    public class TableCompare
    {
        #region Implemetation

        private string tableName;
        internal string[] PkColumns;
        internal string[] NonPkColumns;

        private TableCompare(string tableName)
        {
            this.tableName = tableName;
        }

        private string Compare(string[] pk, TableName from, TableName to)
        {
            var dt1 = new TableReader(from).Table;
            var dt2 = new TableReader(to).Table;

            return Compare(pk, dt1, dt2);
        }

        private string Compare(string[] pk, DataTable table1, DataTable table2)
        {
            this.PkColumns = pk;
            this.NonPkColumns = table1.Columns.OfType<DataColumn>().Select(row => row.ColumnName).Except(PkColumns).ToArray();

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
                    builder.Append(InsertIntoValues(row1));
                    builder.AppendLine();
                }
            }

            return builder.ToString();
        }

        private string InsertIntoValues(DataRow row)
        {
            var direct = RowCompare.Direct(row);
            var x1 = direct.Select(p => "[" + p.ColumnName + "]");
            var x2 = direct.Select(p => p.ToScript());

            return string.Format(insertCommandTemplate,
                string.Join(",", x1),
                string.Join(",", x2)
                );
        }

        private string updateCommandTemplate
        {
            get { return string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, "{0}", "{1}"); }
        }

        private string insertCommandTemplate
        {
            get { return string.Format("INSERT {0}({1}) VALUES({2})", tableName, "{0}", "{1}"); }
        }

        #endregion


        public static string Difference(string connFrom, string connTo, string tableName, string[] primaryKeys)
        {
            var pvd1 = DataProviderManager.Register("Source", DataProviderType.SqlServer, connFrom);
            var pvd2 = DataProviderManager.Register("Sink", DataProviderType.SqlServer, connTo);

            TableName tname1 = new TableName(pvd1, tableName);
            TableName tname2 = new TableName(pvd2, tableName);

            string script = TableCompare.Difference(tname1, tname2, tableName, primaryKeys);
            return script;
        }


        public static string Difference(TableName from, TableName to, string tableName, string[] primaryKeys)
        {
            TableCompare compare = new TableCompare(tableName);
            return compare.Compare(primaryKeys, from, to);
        }

        public static string Rows(string tableName, DataProvider provider)
        {
            string SQL = string.Format("SELECT * FROM [{0}]", tableName);

            var dt1 = new SqlCmd(provider, SQL).FillDataTable();

            TableCompare compare = new TableCompare(tableName);

            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in dt1.Rows)
                builder.Append(compare.InsertIntoValues(row)).AppendLine();

            return builder.ToString();
        }
    }
}

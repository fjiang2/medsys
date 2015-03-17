using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Sys.Data;

namespace SqlCompare
{
    static class Helper
    {


        public static void ToConsole<T>(this IEnumerable<T> source)
        {
            var properties = typeof(T).GetProperties();
            string[] headers = properties.Select(p => p.Name).ToArray();
            
            Func<T, object[]> selector = row =>
                {
                    var values = new object[headers.Length];
                    int i=0;
                    
                    foreach (var propertyInfo in properties)
                    {
                        values[i++] = propertyInfo.GetValue(row);
                    }
                    return values;
                };

            source.ToConsole(headers, selector);
        }

        public static void ToConsole<T>(this IEnumerable<T> source, string[] headers, Func<T, object[]> selector)
        {

            var D = new ConsoleTable(headers.Length);

            D.MeasureWidth(headers);
            foreach (var row in source)
            {
                D.MeasureWidth(selector(row));
            }

            D.DisplayLine();
            D.DisplayLine(headers);
            D.DisplayLine();

            if (source.Count() == 0)
                return;

            foreach (var row in source)
            {
                D.DisplayLine(selector(row));
            }

            D.DisplayLine();
        }

        public static void ToConsole(this DbDataReader reader, int maxRow = 0)
        {
            while (reader.HasRows)
            {
                DataTable schemaTable = reader.GetSchemaTable();

                var schema = schemaTable
                    .AsEnumerable()
                    .Select(row => new {
                        Name = row.Field<string>("ColumnName"),
                        Size = row.Field<int>("ColumnSize"),
                        Type = row.Field<Type>("DataType")
                    });

                string[] headers = schema.Select(row => row.Name).ToArray();

                var D = new ConsoleTable(headers.Length);

                D.MeasureWidth(schema.Select(row => row.Size).ToArray());
                D.MeasureWidth(headers);
                D.MeasureWidth(schema.Select(row => row.Type).ToArray());

                D.DisplayLine();
                D.DisplayLine(headers);
                D.DisplayLine();

                if (!reader.HasRows)
                {
                    stdio.WriteLine("<0 row>");
                    return;
                }

                object[] values = new object[headers.Length];
                int count = 0;
                bool limited = false;
                while (reader.Read())
                {
                    reader.GetValues(values);
                    D.DisplayLine(values);

                    if (++count == maxRow)
                    {
                        limited = true;
                        break;
                    }

                }

                D.DisplayLine();
                stdio.WriteLine("<{0} row{1}> {2}",
                    count,
                    count > 1 ? "s" : "",
                    limited ? "limit reached" : ""
                    );

                reader.NextResult();
            }

        }


        public static void ToConsole(this DataTable table)
        {

            List<string> list = new List<string>();
            foreach (DataColumn column in table.Columns)
                list.Add(column.ColumnName);

            string[] headers = list.ToArray();

            var D = new ConsoleTable(headers.Length);

            D.MeasureWidth(headers);
            foreach (DataRow row in table.Rows)
            {
                D.MeasureWidth(row.ItemArray);
            }

            D.DisplayLine();
            D.DisplayLine(headers);
            D.DisplayLine();

            if (table.Rows.Count == 0)
                return;

            foreach (DataRow row in table.Rows)
            {
                D.DisplayLine(row.ItemArray);
            }

            D.DisplayLine();
            stdio.WriteLine("<{0} row{1}>", table.Rows.Count, table.Rows.Count > 1 ? "s" : "");
        }


        public static bool parse(this string arg, out string t1, out string t2)
        {
            if (string.IsNullOrEmpty(arg) || arg.StartsWith("/"))
            {
                t1 = null;
                t2 = null;
                return false;
            }

            string[] x = arg.Split(':');
            if (x.Length == 1)
            {
                t1 = x[0];
                t2 = x[0];
            }
            else
            {
                t1 = x[0];
                t2 = x[1];
            }

            return true;
        }



        public static bool IsGoodConnectionString(this SqlConnectionStringBuilder cs)
        {
            SqlConnection conn = new SqlConnection(cs.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(name) FROM sys.tables", conn);
                cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }


        public static DataTable ForeignKeySchema(this TableName tableName)
        {
            string SQL = @"
SELECT  FK.TABLE_NAME AS FK_Table,
        CU.COLUMN_NAME AS FK_Column,
        PK.TABLE_NAME AS PK_Table,
        PT.COLUMN_NAME AS PK_Column,
        C.CONSTRAINT_NAME AS Constraint_Name 
FROM    INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
        INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
        INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
        INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
        INNER JOIN ( SELECT i1.TABLE_NAME ,
                            i2.COLUMN_NAME
                     FROM   INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                            INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                     WHERE  i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                   ) PT ON PT.TABLE_NAME = PK.TABLE_NAME
WHERE FK.TABLE_NAME='{1}'       
            ";

            return Use(tableName, SQL);

        }


        public static DataTable PrimaryKeySchema(this TableName tableName)
        {
            string SQL = @"
            SELECT c.COLUMN_NAME, pk.CONSTRAINT_NAME
                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk, 
                     INFORMATION_SCHEMA.KEY_COLUMN_USAGE c 
                WHERE pk.TABLE_NAME = '{0}' 
                      AND CONSTRAINT_TYPE = 'PRIMARY KEY' 
                      AND c.TABLE_NAME = pk.TABLE_NAME 
                      AND c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
            ";


            return Use(tableName, SQL);

        }

        private static DataTable Use(this TableName tableName, string script)
        {
            StringBuilder builder = new StringBuilder();

            if (tableName.Provider.DpType != DbProviderType.SqlCe)
            {
                builder.AppendFormat("USE [{0}] ", tableName.DatabaseName.Name).AppendLine();
            }

            builder.AppendFormat(script, tableName.Name);

            return SqlCmd.FillDataTable(tableName.Provider, builder.ToString());

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Sys.Data.Comparison
{
    public class Compare
    {
        DataProvider pvd1;
        DataProvider pvd2;

        public Compare(DataProvider pvd1, DataProvider pvd2)
        {
            this.pvd1 = pvd1;
            this.pvd2 = pvd2;
        }

        #region compare database schema/data
        public string DatabaseSchemaDifference(DatabaseName dname1, DatabaseName dname2)
        {
            string[] names = dname1.GetDependencyTableNames();

            StringBuilder builder = new StringBuilder();
            foreach (string tableName in names)
            {
#if DEBUG
                Console.WriteLine(tableName);
#endif
                try
                {
                    string sql = TableSchemaDifference(new TableName(dname1, tableName), new TableName(dname2, tableName));
                    builder.Append(sql);
#if DEBUG
                    if (sql != string.Empty)
                        Console.WriteLine(sql);
#endif
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error:" + ex.Message);
                }
            }

            return builder.ToString();
        }

        public string DatabaseDifference(DatabaseName dname1, DatabaseName dname2, string[] excludedTables)
        {
            string[] names = dname1.GetDependencyTableNames();
            excludedTables = excludedTables.Select(row => row.ToUpper()).ToArray();

            StringBuilder builder = new StringBuilder();
            foreach (string tableName in names)
            {
                TableName tname1 = new TableName(dname1, tableName);
                TableName tname2 = new TableName(dname2, tableName);

                Console.WriteLine(tname1);

                if (excludedTables.Contains(tableName.ToUpper()))
                {
                    Console.WriteLine("skip to compare data on table {0}", tableName);
                    continue;
                }

                string[] primaryKeys = InformationSchema.PrimaryKeySchema(tname1).ToArray<string>(0);
                if (primaryKeys.Length == 0)
                {
                    Console.WriteLine("undefined primary key");
                    continue;
                }

                if (DatabaseSchema.Exists(tname2))
                {
                    builder.Append(TableDifference(tname1, tname2, primaryKeys));
                }
                else
                {
                    builder.Append(Compare.GenerateRows(tname1, new TableReader(tname1)));
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }

        #endregion


        #region compare table schema/data

        public string TableSchemaDifference(TableName tableName1, TableName tableName2)
        {

            string sql;

            if (DatabaseSchema.Exists(tableName2))
            {
                TableSchemaCompare compare = new TableSchemaCompare(tableName1, tableName2);
                sql = compare.Compare();
            }
            else
            {
                sql = tableName1.GenerateScript();
            }

            return sql;
        }




        public string TableDifference(TableName tableName1, TableName tableName2, out bool pk)
        {
            string[] primaryKeys = InformationSchema.PrimaryKeySchema(tableName1).ToArray<string>(0);
            pk = primaryKeys.Length > 0;
            string script = string.Empty;

            if (pk)
                script = TableDifference(tableName1, tableName2, primaryKeys);

            return script;
        }


        public string TableDifference(TableName tableName1, TableName tableName2, string[] primaryKeys)
        {
            TableCompare compare = new TableCompare(tableName1, tableName2);
            IPrimaryKeys keys = new PrimaryKeys(primaryKeys);
            return compare.Compare(keys);
        }

        #endregion


        #region create all rows


        private static string GenerateRows(TableName tableName, TableReader reader)
        {

            var table = reader.Table; ;

            TableScript script = new TableScript(tableName);

            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in table.Rows)
                builder.Append(script.INSERT(row)).AppendLine();

            if (table.Rows.Count > 0)
                builder.AppendLine(TableScript.GO);

            return builder.ToString();
        }

        public static void GenerateRows(StreamWriter writer, TableName tableName, string where)
        {
            string sql = string.Format("SELECT * FROM {0}", tableName);
            if (where != null)
                sql = string.Format("SELECT * FROM {0} WHERE {1}", tableName, where);

            SqlCmd cmd = new SqlCmd(tableName.Provider, sql);
            TableScript script = new TableScript(tableName);

            int count = 0;
            cmd.Execute(
                reader =>
                {
                    DataTable schema = reader.GetSchemaTable();

                    string[] columns = schema.AsEnumerable().Select(row => row.Field<string>("ColumnName")).ToArray();
                    object[] values = new object[columns.Length];

                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            reader.GetValues(values);
                            writer.WriteLine(script.INSERT(columns, values));

                            count++;
                            if (count % 5000 == 0)
                                writer.WriteLine(TableScript.GO);

                        }
                        reader.NextResult();
                    }
                });

            if (count != 0)
                writer.WriteLine(TableScript.GO);

        }



        #endregion

    }
}

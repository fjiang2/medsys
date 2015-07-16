﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Sys.Data.Comparison
{
    public static class Compare
    {
       

        #region compare database schema/data
        public static string DatabaseSchemaDifference(DatabaseName dname1, DatabaseName dname2)
        {
            TableName[] names = dname1.GetDependencyTableNames();

            StringBuilder builder = new StringBuilder();
            foreach (TableName tableName in names)
            {
#if DEBUG
                Console.WriteLine(tableName.ShortName);
#endif
                try
                {
                    string sql = TableSchemaDifference(tableName, new TableName(dname2, tableName.SchemaName, tableName.Name));
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


        public static string DatabaseSchemaDifference(string xmlSchema1, string xmlSchema2)
        {
            ConnectionProvider pvd = ConnectionProviderManager.DefaultProvider;
            DataTable dbSchema1;
            DataTable dbSchema2; 
            DataSet ds2 = new DataSet();
            using (var reader = new System.IO.StreamReader(xmlSchema1))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                dbSchema1 = ds.Tables[0];
            }

            using (var reader = new System.IO.StreamReader(xmlSchema2))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                dbSchema2 = ds.Tables[0];
            }

         
            DatabaseName dname1 = new DatabaseName(pvd, "left");
            DatabaseName dname2 = new DatabaseName(pvd, "right");

            TableName[] tnames1 = InformationSchema.TableNameRange(dname1, dbSchema1);
            TableName[] tnames2 = InformationSchema.TableNameRange(dname2, dbSchema2);

            StringBuilder builder = new StringBuilder();
            foreach (TableName tname1 in tnames1)
            {
#if DEBUG
                Console.WriteLine(tname1.ShortName);
#endif
                try
                {
                    string sql = string.Empty;
                    TableName tname2 = tnames2.FirstOrDefault(row => row.SchemaName == tname1.SchemaName && row.Name == tname1.Name);
                    if (tname2!=null)
                    {
                        TableSchemaCompare compare = new TableSchemaCompare(tname1, tname2);
                        sql = compare.Compare(dbSchema1, dbSchema2);
                    }
                    else
                    {
                        sql = tname1.GenerateScript(dbSchema1);
                    }

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

        public static string DatabaseDifference(DatabaseName dname1, DatabaseName dname2, string[] excludedTables)
        {
            TableName[] names = dname1.GetDependencyTableNames();
            excludedTables = excludedTables.Select(row => row.ToUpper()).ToArray();

            StringBuilder builder = new StringBuilder();
            foreach (TableName tableName in names)
            {
                TableName tname1 = tableName;
                TableName tname2 = new TableName(dname2, tableName.SchemaName, tableName.Name);

                TableSchema schema1 = new TableSchema(tname1);
                TableSchema schema2 = new TableSchema(tname2);
                
                Console.WriteLine(tname1.ShortName);

                if (excludedTables.Contains(tableName.ShortName.ToUpper()))
                {
                    Console.WriteLine("skip to compare data on table {0}", tableName.ShortName);
                    continue;
                }

                if (schema1.PrimaryKeys.Length == 0)
                {
                    Console.WriteLine("undefined primary key");
                    continue;
                }

                if (DatabaseSchema.Exists(tname2))
                {
                    builder.Append(TableDifference(schema1, schema2, schema1.PrimaryKeys.Keys));
                }
                else
                {
                    builder.Append(Compare.GenerateRows(schema1, new TableReader(tname1)));
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }

        #endregion


        #region compare table schema/data

        public static string TableSchemaDifference(TableName tableName1, TableName tableName2)
        {

            string sql;

            if (DatabaseSchema.Exists(tableName2))
            {
                TableSchemaCompare compare = new TableSchemaCompare(tableName1, tableName2);
                sql = compare.Compare(null, null);
            }
            else
            {
                sql = tableName1.GenerateScript();
            }

            return sql;
        }

        public static string TableDifference(TableSchema schema1, TableSchema schema2, string[] primaryKeys)
        {
            TableCompare compare = new TableCompare(schema1, schema2);
            IPrimaryKeys keys = new PrimaryKeys(primaryKeys);
            return compare.Compare(keys);
        }

        #endregion


        #region create all rows


        private static string GenerateRows(TableSchema schema, TableReader reader)
        {

            var table = reader.Table; ;

            TableScript script = new TableScript(schema);

            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in table.Rows)
                builder.Append(script.INSERT(row)).AppendLine();

            if (table.Rows.Count > 0)
                builder.AppendLine(TableScript.GO);

            return builder.ToString();
        }

        public static int GenerateRows(StreamWriter writer, TableSchema schema, Locator where)
        {
            TableName tableName = schema.TableName;
            string sql = string.Format("SELECT * FROM {0}", tableName);
            if (where != null)
                sql = string.Format("SELECT * FROM {0} WHERE {1}", tableName, where);

            SqlCmd cmd = new SqlCmd(tableName.Provider, sql);
            TableScript script = new TableScript(schema);

            int count = 0;
            cmd.Execute(
                reader =>
                {
                    DataTable schema1 = reader.GetSchemaTable();

                    string[] columns = schema1.AsEnumerable().Select(row => row.Field<string>("ColumnName")).ToArray();
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

            return count;
        }

        public static string GenerateRowTemplate(TableSchema schema)
        {
            TableName tableName = schema.TableName;
            TableScript script = new TableScript(schema);
            return script.INSERT( schema.Columns);
        }

        #endregion

    }
}

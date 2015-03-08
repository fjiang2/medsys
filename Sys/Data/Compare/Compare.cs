﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data.Comparison
{
    public class Compare
    {
        DataProvider pvd1;
        DataProvider pvd2;

        public Compare(string connectionString1, string connectionString2)
        {
            this.pvd1 = DataProviderManager.Register("Source", DataProviderType.SqlServer, connectionString1);
            this.pvd2 = DataProviderManager.Register("Sink", DataProviderType.SqlServer, connectionString2);
        }
        
        public Compare(DataProvider pvd1, DataProvider pvd2)
        {
            this.pvd1 = pvd1;
            this.pvd2 = pvd2;
        }

        public string DatabaseSchemaDifference(string db1, string db2)
        {

            DatabaseName dname1 = new DatabaseName(pvd1, db1);
            DatabaseName dname2 = new DatabaseName(pvd2, db2);

            string[] names = DatabaseSchema.GetTableNames(dname1);
            
            StringBuilder builder = new StringBuilder();
            foreach (string tableName in names)
            {
#if DEBUG
                Console.WriteLine(tableName);
#endif
                try
                {
                    string sql = TableSchemaDifference(tableName, tableName);
                    builder.Append(sql);
#if DEBUG
                    if (sql != string.Empty)
                        Console.WriteLine(sql);
#endif
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
            }

            return builder.ToString();
        }

        public string TableSchemaDifference(string tableName1, string tableName2)
        {
            TableName tname1 = new TableName(pvd1, tableName1);
            TableName tname2 = new TableName(pvd2, tableName2);

            string script;

            if (DatabaseSchema.TableExists(tname2))
            {
                TableSchemaCompare compare = new TableSchemaCompare(tname1, tname2);
                script = compare.Compare();
            }
            else
            {
                script = new TableScript(tname1).CREATE_TABLE();
            }

            return script;
        }


        public string TableDifference(string tableName1, string tableName2)
        {
            TableName tname1 = new TableName(pvd1, tableName1);
            TableName tname2 = new TableName(pvd2, tableName2);
            
            string[] primaryKeys = InformationSchema.PrimaryKeySchema(tname1).ToArray<string>(0);
            string script = TableDifference(tname1, tname2, primaryKeys);
            return script;
        }

        public string TableDifference(string tableName, string[] primaryKeys)
        {
            TableName tname1 = new TableName(pvd1, tableName);
            TableName tname2 = new TableName(pvd2, tableName);

            string script = TableDifference(tname1, tname2, primaryKeys);
            return script;
        }

        private string TableDifference(TableName from, TableName to, string[] primaryKeys)
        {
            TableCompare compare = new TableCompare(from, to);
            IPrimaryKeys keys = new PrimaryKeys(primaryKeys);
            return compare.Compare(keys);
        }


        public string AllRows(string tableName, string where)
        {
            var tname = new TableName(pvd1, tableName);
            if (string.IsNullOrEmpty(where))
                return Compare.AllRows(tname, new TableReader(tname));
            else
                return Compare.AllRows(tname, new TableReader(tname, where, new object[] { }));

        }

        private static string AllRows(TableName tableName)
        {
            return Compare.AllRows(tableName, new TableReader(tableName));
        }

        private static string AllRows(TableName tableName, TableReader reader)
        {

            var dt1 = reader.Table;;

            TableScript script = new TableScript(tableName);

            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in dt1.Rows)
                builder.Append(script.INSERT(row)).AppendLine();

            return builder.ToString();
        }


        public string DatabaseDifference(string db1, string db2)
        {
            
            DatabaseName dname1 = new DatabaseName(pvd1, db1);
            DatabaseName dname2 = new DatabaseName(pvd2, db2);

            string[] names = DatabaseSchema.GetTableNames(dname1);

            StringBuilder builder = new StringBuilder();
            foreach (string tableName in names)
            {

                TableName tname1 = new TableName(dname1, tableName);
                TableName tname2 = new TableName(dname2, tableName);

                Console.WriteLine(tname1);

                string[] primaryKeys = InformationSchema.PrimaryKeySchema(tname1).ToArray<string>(0);
                if (primaryKeys.Length == 0)
                {
                    Console.WriteLine("undefined primary key");
                    continue;
                }

                if (DatabaseSchema.TableExists(tname2))
                {
                    builder.Append(TableDifference(tname1, tname2, primaryKeys));
                }
                else
                {
                    builder.Append(Compare.AllRows(tname1));
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }


      
    }
}

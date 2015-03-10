using System;
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

        public Compare(DataProvider pvd1, DataProvider pvd2)
        {
            this.pvd1 = pvd1;
            this.pvd2 = pvd2;
        }

        #region compare database schema/data
        public string DatabaseSchemaDifference(DatabaseName dname1, DatabaseName dname2)
        {
            string[] names = dname1.GetTableNames();

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

        public string DatabaseDifference(DatabaseName dname1,  DatabaseName dname2, string[] excludedTables)
        {
            string[] names = dname1.GetTableNames();
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
                    builder.Append(Compare.AllRows(tname1));
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
        public static string AllRows(TableName tableName, string where)
        {

            if (string.IsNullOrEmpty(where))
                return Compare.AllRows(tableName, new TableReader(tableName));
            else
                return Compare.AllRows(tableName, new TableReader(tableName, where, new object[] { }));

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

        #endregion



    }
}

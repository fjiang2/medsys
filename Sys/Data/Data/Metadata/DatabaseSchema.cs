//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data.Comparison;

namespace Sys.Data
{
    public static class DatabaseSchema
    {

        public static bool Exists(this DatabaseName databaseName)
        {
            try
            {
                switch (databaseName.Provider.DpType)
                {
                    case DbProviderType.SqlDb:
                        return SqlCmd.FillDataRow(databaseName.Provider, "SELECT * FROM sys.databases WHERE name = '{0}'", databaseName.Name) != null;
                    case DbProviderType.SqlCe:
                        return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public static void CreateDatabase(this DatabaseName databaseName)
        {
            SqlCmd.ExecuteNonQuery(databaseName.Provider, "CREATE DATABASE {0}", databaseName.Name);
        }

        public static bool Exists(this TableName tname)
        {
            try
            {
                if (!Exists(tname.DatabaseName))
                    return false;

                switch (tname.Provider.DpType)
                {
                    case DbProviderType.SqlDb:
                        return SqlCmd.FillDataRow(tname.Provider, "USE [{0}] ; SELECT * FROM sys.Tables WHERE Name='{1}'", tname.DatabaseName.Name, tname.Name) != null;

                    case DbProviderType.SqlCe:
                        return SqlCmd.FillDataRow(tname.Provider, "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='TABLE' AND TABLE_NAME='{0}'", tname.Name) != null;
                }
            }
            catch (Exception)
            {
            }

            return false;
        }


        public static string CurrentDatabaseName(this ConnectionProvider provider)
        {
            switch (provider.DpType)
            {
                case DbProviderType.SqlDb:
                    {
                        return (string)SqlCmd.ExecuteScalar(provider, "SELECT DB_NAME()");
                        //var connection = new SqlCmd(provider, string.Empty).DbProvider.DbConnection;
                        //return connection.Database.ToString();
                    }

                case DbProviderType.SqlCe:
                    return "Database" ;

                default:
                    throw new NotSupportedException();
            }
        }


        public static string[] GetDatabaseNames(this ConnectionProvider provider)
        {
            switch (provider.DpType)
            {
                case DbProviderType.SqlDb:
                    return SqlCmd.FillDataTable(provider, "SELECT Name FROM sys.databases ORDER BY Name").ToArray<string>("name");

                case DbProviderType.SqlCe:
                    return new string[] {"Database"};

                default:
                    throw new NotSupportedException();
            }
        }

        public static TableName[] GetTableNames(this DatabaseName databaseName)
        {
            switch (databaseName.Provider.DpType)
            {
                case DbProviderType.OleDb:
                case DbProviderType.SqlDb:
                    return SqlCmd
                        .FillDataTable(databaseName.Provider, 
                            "USE [{0}] ; SELECT SCHEMA_NAME(schema_id) AS SchemaName, name as TableName FROM sys.Tables ORDER BY Name", 
                            databaseName.Name)
                        .AsEnumerable()
                        .Select(row=> new TableName(databaseName, row.Field<string>("SchemaName"), row.Field<string>("TableName")))
                        .ToArray();

                default:
                    return new TableName[0];
            }

        }

        public static TableName[] GetViewNames(this DatabaseName databaseName)
        {
            return SqlCmd
                .FillDataTable(databaseName.Provider, 
                    "USE [{0}] ; SELECT  SCHEMA_NAME(schema_id) SchemaName, name AS TableName FROM sys.views ORDER BY name", 
                    databaseName.Name)
                    .AsEnumerable()
                    .Select(row=>new TableName(databaseName, row.Field<string>(0), row.Field<string>(1)))
                    .ToArray();
        }


        public static string GenerateScript(this TableName tableName)
        {
            TableSchema schema1 = new TableSchema(tableName);

            string sql;
            var script = new TableScript(schema1);
            sql = script.CREATE_TABLE();

            StringBuilder builder = new StringBuilder(sql);
            builder.AppendLine(TableScript.GO);

            var fk1 = schema1.ForeignKeys;
            if (fk1.Keys.Length > 0)
            {
                foreach (var fk in fk1.Keys)
                {
                    builder.AppendLine(script.ADD_FOREIGN_KEY(fk)).AppendLine(TableScript.GO);
                }

            }

            sql = builder.ToString();
            return sql;
        }

        public static string GenerateScript(this DatabaseName databaseName)
        {
            StringBuilder builder = new StringBuilder();
            TableName[] history = GetDependencyTableNames(databaseName);

            foreach (var tableName in history)
            {
                Console.WriteLine("generate CREATE TABLE [{0}]", tableName);
                try
                {
                    builder.AppendLine(tableName.GenerateScript());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("failed to generate CREATE TABLE [{0}],{1}", tableName, ex.Message);
                }
            }

            return builder.ToString();
        }

        public static string GenerateDropTableScript(this DatabaseName databaseName)
        {
            string drop = @"
IF OBJECT_ID('{0}') IS NOT NULL
  DROP TABLE [{0}]
";
            TableName[] history = GetDependencyTableNames(databaseName);
            StringBuilder builder = new StringBuilder();
            foreach (var tableName in history.Reverse())
            {
                builder.AppendFormat(drop, tableName)
                    .AppendLine(TableScript.GO);
            }

            return builder.ToString();
        }

        public static TableName[] GetDependencyTableNames(this DatabaseName databaseName)
        {
            string sql = @"
SELECT  
		FK.TABLE_SCHEMA AS FK_SCHEMA,
		FK.TABLE_NAME AS FK_Table,
		PK.TABLE_SCHEMA AS FK_SCHEMA,
        PK.TABLE_NAME AS PK_Table
  FROM  INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
        INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
        INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
        INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
        INNER JOIN ( SELECT i1.TABLE_NAME ,
                            i2.COLUMN_NAME
                     FROM   INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                            INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                     WHERE  i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                   ) PT ON PT.TABLE_NAME = PK.TABLE_NAME
 WHERE FK.TABLE_NAME <> PK.TABLE_NAME
";

            var dt = new SqlCmd(databaseName.Provider, sql)
                .FillDataTable()
                .AsEnumerable();

            var dict = dt.GroupBy(
                    row => new TableName(databaseName, (string)row[0], (string)row[1]), 
                    (Key, rows) => new { Fk = Key, Pk = rows.Select(row => new TableName(databaseName, (string)row[2], (string)row[3])).ToArray() })
                .ToDictionary(row => row.Fk, row => row.Pk);


            TableName[] names = databaseName.GetTableNames();

            List<TableName> history = new List<TableName>();

            foreach (var tname in names)
            {
                if (history.IndexOf(tname) < 0)
                    Iterate(tname, dict, history);
            }
            
            return history.ToArray();
        }

        private static void Iterate(TableName tableName, Dictionary<TableName, TableName[]> dict, List<TableName> history)
        {
            if (!dict.ContainsKey(tableName))
            {
                if (history.IndexOf(tableName) < 0)
                {
                    history.Add(tableName);
                }
            }
            else
            {
                foreach (var name in dict[tableName])
                    Iterate(name, dict,  history);

                if (history.IndexOf(tableName) < 0)
                {
                    history.Add(tableName);
                }
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sys.Data
{
    class SqlSchemaProvider : SchemaProvider
    {
        private static string[] __sys_tables = { "master", "model", "msdb", "tempdb" };

        public SqlSchemaProvider(ConnectionProvider provider)
            : base(provider)
        {
        }

        public override bool Exists(DatabaseName dname)
        {
            try
            {
                //string SQL = string.Format("SELECT * FROM sys.databases WHERE name = '{0}'", dname.Name);
                //return DataExtension.FillDataRow(dname.Provider, SQL) != null;

                string SQL = "EXEC sp_databases";
                var dnames = DataExtension.FillDataTable(provider, SQL).ToArray<string>("DATABASE_NAME");
                return dnames.FirstOrDefault(row => row.ToLower().Equals(dname.Name.ToLower())) != null;
            }
            catch (Exception)
            {
            }
            return false;
        }


        public override bool Exists(TableName tname)
        {
            try
            {
                if (!Exists(tname.DatabaseName))
                    return false;

                var tnames = GetTableNames(tname.DatabaseName);
                return tnames.FirstOrDefault(row => row.Name.ToUpper() == tname.Name.ToUpper() && row.SchemaName.ToUpper() == tname.SchemaName.ToUpper()) != null;

            }
            catch (Exception)
            {
            }

            return false;
        }

        public override DatabaseName[] GetDatabaseNames() 
        {
            string SQL = "SELECT Name as DATABASE_NAME FROM sys.databases ORDER BY Name"; //Used for SQL Server 2008+
            SQL = "EXEC sp_databases";
            string[] dnames;
            switch (provider.DpType)
            {
                case DbProviderType.SqlDb:
                    dnames = DataExtension.FillDataTable(provider, SQL).ToArray<string>("DATABASE_NAME");
                    List<string> L = new List<string>();
                    foreach (var dname in dnames)
                    {
                        if (!__sys_tables.Contains(dname))
                            L.Add(dname);
                    }

                    dnames = L.ToArray();
                    break;

                case DbProviderType.SqlCe:
                    dnames = new string[] { "Database" };
                    break;

                default:
                    throw new NotSupportedException();
            }

            return dnames.Select(dname => new DatabaseName(provider, dname)).ToArray();
        }

        public override TableName[] GetTableNames(DatabaseName dname)
        {
            if (dname.Provider.Version >= 2005)
            {
                var table = DataExtension.FillDataTable(dname.Provider,
                         "USE [{0}] ; SELECT SCHEMA_NAME(schema_id) AS SchemaName, name as TableName FROM sys.Tables ORDER BY SchemaName,Name",
                             dname.Name);
                if (table != null)
                {
                    return table
                        .AsEnumerable()
                        .Select(row => new TableName(dname, row.Field<string>("SchemaName"), row.Field<string>("TableName")))
                        .ToArray();
                }
            }
            else
            {

                var table = DataExtension.FillDataTable(dname.Provider, "USE [{0}] ; EXEC sp_tables", dname.Name);
                if (table != null)
                {
                    return table
                        .AsEnumerable()
                        .Where(row => row.Field<string>("TABLE_TYPE") == "TABLE")
                        .Select(row => new TableName(dname, row.Field<string>("TABLE_OWNER"), row.Field<string>("TABLE_NAME")))
                        .ToArray();
                }
            }

            return new TableName[] { };
        }

        public override TableName[] GetViewNames(DatabaseName dname)
        {
            if (dname.Provider.Version >= 2005)
            {
                var table = DataExtension
                .FillDataTable(dname.Provider,
                    "USE [{0}] ; SELECT  SCHEMA_NAME(schema_id) SchemaName, name FROM sys.views ORDER BY name",
                    dname.Name);

                if (table != null)
                    return table.AsEnumerable()
                    .Select(row => new TableName(dname, row.Field<string>(0), row.Field<string>(1)) { IsViewName = true })
                    .ToArray();
            }
            else
            {
                var table = DataExtension.FillDataTable(dname.Provider, "USE [{0}] ; EXEC sp_tables", dname.Name);
                if (table != null)
                {
                    return table
                        .AsEnumerable()
                        .Where(row => row.Field<string>("TABLE_TYPE") == "VIEW")
                        .Select(row => new TableName(dname, row.Field<string>("TABLE_OWNER"), row.Field<string>("TABLE_NAME")) { IsViewName = true })
                        .ToArray();
                }
            }

            return new TableName[] { };
        }


        public override DataTable GetTableSchema(TableName tname)
        {
            return InformationSchema.SqlTableSchema(tname);
        }

        public override DataTable GetDatabaseSchema(DatabaseName dname)
        {
            //return GetServerSchema(dname.ServerName).Tables[dname.Name];

            return InformationSchema.SqlServerSchema(dname.ServerName, new DatabaseName[] { dname }).Tables[dname.Name];
        }

        public override DataSet GetServerSchema(ServerName sname)
        {
            return InformationSchema.SqlServerSchema(sname, sname.GetDatabaseNames());
        }

        public override DataTable GetDependencySchema(DatabaseName dname)
        {
            string sql = @"
SELECT  
		FK.TABLE_SCHEMA AS FK_SCHEMA,
		FK.TABLE_NAME AS FK_Table,
		PK.TABLE_SCHEMA AS PK_SCHEMA,
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

            var dt = new SqlCmd(dname.Provider, sql).FillDataTable();
            return dt;
        }
    }
}

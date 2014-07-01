﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Sys.Data
{
    public class InformationSchema
    {

        public static DataTable TableSchema(TableName tableName)
        {
            DataTable dt1;
            string SQL;

            switch (tableName.Provider.DpType)
            {

                //Column Name must match class MetadataColumn
                case DbProviderType.SqlDb:
                    SQL = @"
            USE [{0}]
            SELECT 
                c.name AS ColumnName,
                ty.name AS DataType,
                c.max_length AS Length,
                c.is_nullable AS Nullable,
                c.precision,
                c.scale,
                c.is_identity AS IsIdentity,
                c.is_computed AS IsComputed
             FROM sys.tables t 
                  INNER JOIN sys.columns c ON t.object_id = c.object_id 
                  INNER JOIN sys.types ty ON ty.system_type_id =c.system_type_id AND ty.name<>'sysname'
            WHERE t.name = '{1}' 
            ORDER BY c.column_id";
                    dt1 = SqlCmd.FillDataTable(tableName.Provider, SQL, tableName.DatabaseName.Name, tableName.Name);
                    break;

                case DbProviderType.SqlCe:
                    SQL = @"
            SELECT 
                c.COLUMN_NAME AS ColumnName,
                c.DATA_TYPE AS DataType,
                c.CHARACTER_MAXIMUM_LENGTH AS Length,
                CASE WHEN c.IS_NULLABLE='YES' THEN 1 ELSE 0 END AS Nullable,
                c.NUMERIC_PRECISION AS precision,
                c.NUMERIC_SCALE AS scale,
                c.AUTOINC_INCREMENT AS IsIdentity,
                0 AS IsComputed
             FROM INFORMATION_SCHEMA.COLUMNS c 
            WHERE c.TABLE_NAME = '{0}' 
            ORDER BY c.ORDINAL_POSITION";
                    dt1 = SqlCmd.FillDataTable(tableName.Provider, SQL, tableName.Name);
                    break;

                default:
                    throw new NotSupportedException();
            }

            return dt1;

        }

        public static DataTable PrimaryKeySchema(TableName tableName)
        { 
            string SQL = @"
            SELECT c.COLUMN_NAME 
                FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk, 
                     INFORMATION_SCHEMA.KEY_COLUMN_USAGE c 
                WHERE pk.TABLE_NAME = '{0}' 
                      AND CONSTRAINT_TYPE = 'PRIMARY KEY' 
                      AND c.TABLE_NAME = pk.TABLE_NAME 
                      AND c.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
            ";


            return Use(tableName, SQL);

        }

        public static DataTable ForeignKeySchema(TableName tableName)
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
WHERE FK.TABLE_NAME='{0}'       
            ";

            return Use(tableName, SQL);

        }


        public static DataTable IdentityKeySchema(TableName tableName)
        {
            if (tableName.Provider.DpType != DbProviderType.SqlCe)
            {
                string SQL = @"
            SELECT c.name
            FROM sys.tables t 
	            JOIN sys.columns c ON t.object_id = c.object_id 
            WHERE t.name = '{0}' AND c.is_identity = 1";

                return Use(tableName, SQL);
            }
            else
                return SqlCmd.FillDataTable(
          @"SELECT c.COLUMN_NAME AS Name
            FROM INFORMATION_SCHEMA.COLUMNS c
            WHERE c.TABLE_NAME = '{0}' AND c.AUTOINC_INCREMENT = 1", tableName.Name);
        }

        private static DataTable Use(TableName tableName, string script)
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
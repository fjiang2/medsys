using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Sys.Data
{
    public static class InformationSchema
    {

        private static string SQL_SCHEMA = @"
SELECT 
	--SCHEMA_NAME(t.schema_id) AS SchemaName,
	--t.name AS TableName,
    c.name AS ColumnName,
    ty.name AS DataType,
    c.max_length AS Length,
    c.is_nullable AS Nullable,
    c.precision,
    c.scale,
    CASE WHEN p.CONSTRAINT_NAME IS NOT NULL THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS IsPrimary,
    c.is_identity AS IsIdentity,
    c.is_computed AS IsComputed,
    d.definition,
	p.CONSTRAINT_NAME AS PKContraintName,
	f.PK_Schema,
	f.PK_Table,
	f.PK_Column,
	f.Constraint_Name AS FKContraintName
    FROM sys.tables t 
        INNER JOIN sys.columns c ON t.object_id = c.object_id 
        INNER JOIN sys.types ty ON ty.system_type_id =c.system_type_id AND ty.name<>'sysname' AND ty.is_user_defined = 0
        LEFT JOIN sys.Computed_columns d ON t.object_id = d.object_id AND c.name = d.name
		LEFT JOIN (SELECT pk.TABLE_NAME, k.COLUMN_NAME, pk.CONSTRAINT_NAME
					FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS pk 
						INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE k ON  k.TABLE_NAME = pk.TABLE_NAME AND k.CONSTRAINT_NAME = pk.CONSTRAINT_NAME
						WHERE pk.CONSTRAINT_TYPE = 'PRIMARY KEY'
						) p	ON p.TABLE_NAME = t.name  AND p.COLUMN_NAME = c.name
		LEFT JOIN (SELECT   FK.TABLE_SCHEMA AS FK_Schema,
							FK.TABLE_NAME AS FK_Table,
							CU.COLUMN_NAME AS FK_Column,
							PK.TABLE_SCHEMA AS PK_Schema,
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
				   ) f ON f.FK_Table = t.name AND f.FK_Column = c.name
{0}
ORDER BY t.name, c.column_id
";

        public static DataTable TableSchema(this TableName tableName)
        {
            DataTable dt1;
            string SQL = string.Format(SQL_SCHEMA, "WHERE t.name='{0}'");
            dt1 = Use(tableName, SQL);

            return dt1;
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


        public static DataSet DatabaseSchema(this DatabaseName dname)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("USE [{0}] ", dname.Name).AppendLine();
            builder.AppendLine(string.Format(SQL_SCHEMA, ""));

            DataSet ds = new SqlCmd(dname.Provider, builder.ToString()).FillDataSet();
            ds.DataSetName = dname.Name;
            ds.Tables[0].TableName = "COLUMN";
            return ds;
        }
    }
}

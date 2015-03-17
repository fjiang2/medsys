using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sys.Data;

namespace SqlCompare
{
    static class DbSchema
    {

        private static DataTable Use(this TableName tableName, string script)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("USE [{0}] ", tableName.DatabaseName.Name).AppendLine();

            builder.AppendFormat(script, tableName.Name);

            return SqlCmd.FillDataTable(tableName.Provider, builder.ToString());

        }

        private static DataTable Use(this DatabaseName databaseName, string script)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("USE [{0}] ", databaseName.Name).AppendLine();

            builder.Append(script);

            return SqlCmd.FillDataTable(databaseName.Provider, builder.ToString());

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
            WHERE FK.TABLE_NAME='{0}'       
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

        public static DataTable IdentityKeySchema(this TableName tableName)
        {
            string SQL = @"
                SELECT 
	            t.name AS TableName,
	            c.name AS ColumnName
            FROM sys.tables t 
	            JOIN sys.columns c ON t.object_id = c.object_id 
            WHERE t.name = '{0}' AND 
	                c.is_identity = 1
            ORDER BY t.name
            ";
            return Use(tableName, SQL);

        }

        public static DataTable AllView(this DatabaseName databaseName)
        {
            string SQL = @"
            SELECT SCHEMA_NAME(schema_id) AS schema_name
		            ,name AS view_name
		            ,OBJECTPROPERTYEX(OBJECT_ID,'IsIndexed') AS IsIndexed
		            ,OBJECTPROPERTYEX(OBJECT_ID,'IsIndexable') AS IsIndexable
            FROM sys.views
            ";
            return Use(databaseName, SQL);

        }

        public static DataTable ViewSchema(this TableName tableName)
        {
            string SQL = @"
             SELECT 
	            VCU.TABLE_NAME, 
	            COL.COLUMN_NAME,
	            COL.DATA_TYPE,
	            COL.IS_NULLABLE
            FROM INFORMATION_SCHEMA.VIEW_COLUMN_USAGE AS VCU
	            JOIN INFORMATION_SCHEMA.COLUMNS AS COL
	            ON  COL.TABLE_SCHEMA  = VCU.TABLE_SCHEMA
	            AND COL.TABLE_CATALOG = VCU.TABLE_CATALOG
	            AND COL.TABLE_NAME    = VCU.TABLE_NAME
	            AND COL.COLUMN_NAME   = VCU.COLUMN_NAME
            WHERE VCU.VIEW_NAME = '{0}'
            ";
            return Use(tableName, SQL);

        }

        public static DataTable AllProc(this DatabaseName databaseName)
        {
            string SQL = @"
        SELECT Routine_Name , DATA_TYPE, ROUTINE_TYPE
          FROM master.information_schema.routines 
         WHERE Routine_Name IN (SELECT name FROM dbo.sysobjects)";
            
            return Use(databaseName, SQL);

        }
    }
}

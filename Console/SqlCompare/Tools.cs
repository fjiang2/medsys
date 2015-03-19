using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys.Data;

namespace SqlCompare
{
    static class Tools
    {
        public static void FindColumn(this ConnectionProvider provider, string match)
        {
            string sql = "SELECT name AS TableName FROM sys.tables WHERE name LIKE @PATTERN";
            var dt = new SqlCmd(provider, sql, new { PATTERN = "%" + match + "%" }).FillDataTable();
            dt.ToConsole();

            sql = @"
 SELECT 
	t.name as TableName,
    c.name AS ColumnName,
    ty.name AS DataType,
    c.max_length AS Length,
    CASE c.is_nullable WHEN 0 THEN 'NOT NULL' WHEN 1 THEN 'NULL' END AS Nullable
FROM sys.tables t 
        INNER JOIN sys.columns c ON t.object_id = c.object_id 
        INNER JOIN sys.types ty ON ty.system_type_id =c.system_type_id AND ty.name<>'sysname'
        LEFT JOIN sys.Computed_columns d ON t.object_id = d.object_id AND c.name = d.name
WHERE c.name LIKE @PATTERN
ORDER BY c.name, c.column_id
";
            dt = new SqlCmd(provider, sql, new { PATTERN = "%" + match + "%" }).FillDataTable();
            dt.ToConsole();
        }
    }
}

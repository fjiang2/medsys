﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data.Comparison
{
    class TableSchemaCompare
    {
        TableName tableName1;
        TableName tableName2;

        public TableSchemaCompare(TableName name1, TableName name2)
        {
            tableName1 = name1;
            tableName2 = name2;
        }

        public string Compare()
        {
            TableSchema schema1 = new TableSchema(tableName1);
            TableSchema schema2 = new TableSchema(tableName2);

            StringBuilder builder = new StringBuilder();
            TableScript scrpit = new TableScript(tableName1);

            foreach (ColumnSchema column in schema1.Columns)
            {
                if (schema2.Columns.Where(c => c.ColumnName == column.ColumnName).Count() == 0)
                {
                    builder.AppendLine(scrpit.ADD_COLUMN(column));
                }
                else if (schema2.Columns.Where(c =>
                    c.ColumnName.Equals(column.ColumnName) 
                    && (!c.CType.Equals(column.CType)
                    || !c.Nullable.Equals(column.Nullable)
                    || !c.Precision.Equals(column.Precision)
                    || !c.Scale.Equals(column.Scale)
                    ))
                    .Count() != 0)
                {
                    builder.AppendLine(scrpit.ALTER_COLUMN(column));
                }
            }

            var pk1 = schema1.PrimaryKeys;
            var pk2 = schema2.PrimaryKeys;
            
            if (pk2.Keys.Length == 0)
            {
                if (pk1.Keys.Length > 0)
                {
                    builder.AppendLine(scrpit.ADD_PRIMARY_KEY(pk1));
                    builder.AppendLine("GO");
                }
            }
            else 
            {
                if (pk1.Keys.Length > 0 && !Equals(pk1.Keys, pk2.Keys))
                {
                    builder.AppendLine(scrpit.DROP_PRIMARY_KEY(pk1));
                    builder.AppendLine(scrpit.ADD_PRIMARY_KEY(pk1));
                    builder.AppendLine("GO");
                }
            }

            var fk1 = schema1.ForeignKeys;
            var fk2 = schema2.ForeignKeys;

            if (fk2.Keys.Length == 0)
            {
                if (fk1.Keys.Length > 0)
                {
                    foreach (var fk in fk1.Keys)
                    {
                        builder.AppendLine(scrpit.ADD_FOREIGN_KEY(fk));
                    }

                    builder.AppendLine("GO");
                }
            }
            else
            {
                if (fk1.Keys.Length > 0)
                {
                    foreach (var k1 in fk1.Keys)
                    {
                        if (fk2.Keys.Where(k2 => k2.Constraint_Name.Equals(k1.Constraint_Name)).Count() == 0)
                        {
                            builder.AppendLine(scrpit.DROP_FOREIGN_KEY(k1));
                            builder.AppendLine(scrpit.ADD_FOREIGN_KEY(k1));
                            builder.AppendLine("GO");
                        }
                    }
                }
            }


            return builder.ToString();
        }

        private static bool Equals(string[] A1, string[] A2)
        {
            if (A1.Length != A2.Length)
                return false;

            foreach (string a1 in A1)
            {
                if (!A2.Contains(a1))
                    return false;
            }

            return true;
        }

       
      
    }
}
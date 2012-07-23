using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data.Persistence.Level4
{
    /// <summary>
    /// n..n table mapping(many-to-many)
    /// T1: mapping table, e.g. Table UserRoles
    /// T2: many table, e.g. Table Roles
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class TableReader<T1, T2>
        where T1 : class,  IDPObject, new() 
        where T2 : class,  IDPObject, new() 
    {

        DataSet dataset;

        public TableReader(MappedColumn column1, MappedColumn column2, object value)
        {
            string tableName1 =  typeof(T1).TableName().ToString();
            string tableName2 =  typeof(T2).TableName().ToString();

            string sql = @"
SELECT * FROM @T1 WHERE {1} = {4}
SELECT * FROM @T2 WHERE {2} IN (SELECT {3} FROM @T1 WHERE {1} = {4})
";
            sql = sql
                .Replace("@T1", tableName1)
                .Replace("@T2", tableName2);

            sql = string.Format(sql, column1.ColumnName, column1.MappedColumnName, column2.ColumnName, column2.MappedColumnName, new SqlValue(value));

            this.dataset = SqlCmd.FillDataSet(sql);
            
            this.dataset.Tables[0].TableName = tableName1;
            this.dataset.Tables[1].TableName = tableName2;
        }

        public DataTable ManyTable
        {
            get { return this.dataset.Tables[0]; }
        }

        public DataTable MapTable
        {
            get { return this.dataset.Tables[0]; }
        }

    }


  
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using Sys.Data.Manager;

namespace Sys.Data
{
    public class TableReader
    {
        private DataTable table;
        private string sql;


        public TableReader(string sql)
        {
            this.sql = sql;
            this.table = SqlCmd.FillDataTable(sql);
        }

        public TableReader(SqlBuilder sql)
            :this(sql.Script)
        {
        }

        public TableReader(TableName tableName)
            :this(string.Format("SELECT * FROM {0}", tableName))
        {
        }

        public TableReader(TableName tableName, string where, params object[] args)
            :this( string.Format("SELECT * FROM {0} WHERE {1}", tableName, string.Format(where, args)))
        {
        }

        public TableReader(TableName tableName, string[] orderBy, string where, params object[] args)
            : this(string.Format("SELECT * FROM {0} WHERE {1} ORDER BY {2}", 
                    tableName, 
                    string.Format(where, args), 
                    string.Join(",",orderBy)
            ))
        {
        }

        public TableReader(TableName tableName, string[] groupBy, string[] orderBy, string where, params object[] args)
            : this(string.Format("SELECT * FROM {0} WHERE {1} GROUP BY {2} ORDER BY {3}", 
                    tableName, 
                    string.Format(where, args),
                    string.Join(",", groupBy),
                    string.Join(",", orderBy)
            ))
        {
        }

        public TableReader(TableName tableName, params ColumnValue[] ands)
            :this(string.Format("SELECT * FROM {0} WHERE {1}", tableName, string.Join<ColumnValue>(" AND ", ands)))
        {
        }

        public DataTable Table
        {
            get
            {
                return this.table;
            }
        }

        public List<T> ToList<T>() where T: class, IDPObject, new()
        {
            return new DPList<T>(this).ToList();
        }

        public override string ToString()
        {
            return this.sql;
        }

    }


    public class TableReader<T> where T : class,  IDPObject, new()
    {
        TableReader reader;

        public TableReader()
        {
            this.reader = new TableReader(TableName);
        }

        public TableReader(SqlExpr where)
        {
            this.reader = new TableReader(new SqlBuilder().SELECT.COLUMNS().FROM(TableName).WHERE(where));
        }

        public TableReader(string where, params object[] args)
        {
            this.reader = new TableReader(TableName, where, args);
        }


        public TableReader(params ColumnValue[] ands)
        {
            this.reader = new TableReader(TableName, ands);
        }

        private TableName TableName
        {
            get
            {
                return typeof(T).TableName();
            }
        }

        public DataTable Table
        {
            get
            {
                return this.reader.Table;
            }
        }

        public List<T> ToList()
        {
            //List<T> list = new List<T>();
            //foreach (DataRow dataRow in Table.Rows)
            //{
            //    T t = new T();
            //    t.Fill(dataRow);
            //    list.Add(t);
            //}
            //return this.list;

            return new DPList<T>(this).ToList();
        }


        public override string ToString()
        {
            return this.reader.ToString();
        }
    }
}

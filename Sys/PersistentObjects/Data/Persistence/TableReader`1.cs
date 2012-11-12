
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using Sys.Data.Manager;

namespace Sys.Data
{
  
    public class TableReader<T> where T : class,  IDPObject, new()
    {
        TableReader reader;

        public TableReader()
        {
            this.reader = new TableReader(TableName);
        }

        public TableReader(SqlExpr where)
        {
            this.reader = new TableReader(TableName, new SqlClause().SELECT.COLUMNS().FROM(TableName).WHERE(where).Clause);
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

        /// <summary>
        /// override T.Fill(DataRow) to initialize varibles in the class T, if typeof(T).BaseType != typeof(DPObject)
        /// </summary>
        /// <returns></returns>
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

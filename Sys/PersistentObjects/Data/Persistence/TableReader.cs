
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

        public TableReader(SqlClause sql)
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

    
        public DataTable Table
        {
            get
            {
                return this.table;
            }
        }

        /// <summary>
        /// override T.Fill(DataRow) to initialize varibles in the class T, if typeof(T).BaseType != typeof(DPObject)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> ToList<T>() where T: class, IDPObject, new()
        {
            return new DPList<T>(this).ToList();
        }

        public override string ToString()
        {
            return this.sql;
        }

    }


    
}

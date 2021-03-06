﻿//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;

namespace Sys.Data
{
    /// <summary>
    /// Read records from data base server into data table 
    /// </summary>
    public class TableReader
    {
        private DataTable table;
        private string sql;


        internal TableReader(TableName tableName, string sql)
        {
            this.sql = sql;
            SqlCmd cmd = new SqlCmd(tableName.Provider, sql);
            this.table = cmd.FillDataTable();
        }

       
        /// <summary>
        /// read all records in the table defined
        /// </summary>
        /// <param name="tableName"></param>
        public TableReader(TableName tableName)
            : this(tableName, string.Format("SELECT * FROM {0}", tableName))
        {
        }

        /// <summary>
        /// read records by filiter
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <param name="args"></param>
        public TableReader(TableName tableName, string where, params object[] args)
            :this(tableName, string.Format("SELECT * FROM {0} WHERE {1}", tableName, string.Format(where, args)))
        {
        }

        /// <summary>
        /// read records by filter
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        public TableReader(TableName tableName, SqlExpr where)
            : this(tableName, new SqlBuilder().SELECT.COLUMNS().FROM(tableName).WHERE(where).Clause)
        { 
        
        }
    
        /// <summary>
        /// return data table retrieved from data base server
        /// </summary>
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

        /// <summary>
        /// returns SQL clause
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.sql;
        }

    }


    
}

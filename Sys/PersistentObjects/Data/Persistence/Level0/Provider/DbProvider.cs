//--------------------------------------------------------------------------------------------------//
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
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

namespace Sys.Data
{
    public abstract class DbProvider
    {
        protected readonly DataProviderConnection connection;
        protected readonly string script;
        public readonly DbConnection DbConnection;

        public DbProvider(string script, DataProviderConnection connection)
        {
            this.script = script;
            this.connection = connection;

            this.DbConnection = this.connection.NewDbConnection;
        }

        

        public DbType DbType
        {
            get { return this.connection.DbType; }
        }

        public abstract DbDataAdapter DbDataAdapter
        {
            get;
        }

        public abstract DbCommand NewDbCommand
        {
            get;
        }

        public abstract void FillDataSet(DataSet dataSet);

        public abstract void FillDataTable(DataSet dataSet, string tableName);

        public abstract void FillDataTable(DataTable table);

        public abstract DbParameter AddParameter(string parameterName, object value);
        

        public static DbProvider Factory(string script, DataProviderConnection connection)
        {
            switch (connection.DbType)
            {
                case DbType.SqlDb:
                    return new SqlProvider(script, connection);

                case DbType.OleDb:
                    return new OleDbProvider(script, connection);

                case DbType.SqlCe:
                    return new SqlCeProvider(script, connection);
            }

            throw new NotImplementedException();
        }
        
    }
}

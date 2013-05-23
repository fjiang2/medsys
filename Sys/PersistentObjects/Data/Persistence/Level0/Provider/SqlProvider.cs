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
using System.Data.SqlClient;
using System.Data;

namespace Sys.Data
{
    class SqlProvider : DbProvider
    {
        public SqlProvider(string script, DataProviderConnection connection)
            : base(script, connection)
        { 
        }

      

        protected override DbDataAdapter NewDbDataAdapter()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = (SqlCommand)base.DbCommand;
            return adapter;
        }

        protected override DbCommand NewDbCommand()
        {
            return new SqlCommand(script, (SqlConnection)DbConnection);
        }

        public override DbParameter AddParameter(string parameterName, Type type)
        {
            SqlParameter param = new SqlParameter(parameterName, type.ToSqlDbType());
            DbCommand.Parameters.Add(param);
            return param;
        }
      

        public override DbParameter AddParameter(string parameterName, object value)
        {
            SqlDbType dbType = SqlDbType.NVarChar;
            if (value is Int32)
                dbType = SqlDbType.Int;
            else if (value is DateTime)
                dbType = SqlDbType.DateTime;
            else if (value is Double)
                dbType = SqlDbType.Float;
            else if (value is Decimal)
                dbType = SqlDbType.Decimal;
            else if (value is Boolean)
                dbType = SqlDbType.Bit;
            else if (value is string && ((string)value).Length > 4000)
                dbType = SqlDbType.NText;

            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            DbCommand.Parameters.Add(param);
            return param;
        }

    }
}

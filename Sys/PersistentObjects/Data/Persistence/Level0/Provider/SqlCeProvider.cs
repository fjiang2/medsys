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
using System.Data.SqlServerCe;
using System.Data;

namespace Sys.Data
{
    class SqlCeProvider : DbProvider
    {
        public SqlCeProvider(string script, DataProviderConnection connection)
            : base(script, connection)
        { 
        }

       

        public override DbDataAdapter DbDataAdapter
        {
            get
            {
                return new SqlCeDataAdapter();
            }
        }

        public override DbCommand NewDbCommand
        {
            get
            {
                return new SqlCeCommand(script, (SqlCeConnection)DbConnection);
            }
        }


        public override void FillDataSet(DataSet dataSet)
        {
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            adapter.SelectCommand = (SqlCeCommand)NewDbCommand;
            adapter.Fill(dataSet);
        }

        public override void FillDataTable(DataSet dataSet, string tableName)
        {
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            adapter.SelectCommand = (SqlCeCommand)NewDbCommand;
            adapter.Fill(dataSet, tableName);
        }

        public override void FillDataTable(DataTable table)
        {
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            adapter.SelectCommand = (SqlCeCommand)NewDbCommand;
            adapter.Fill(table);
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

            SqlCeParameter param = new SqlCeParameter(parameterName, dbType);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            return param;
        }

    }
}

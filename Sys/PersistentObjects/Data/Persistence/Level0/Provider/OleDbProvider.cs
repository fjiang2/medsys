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
using System.Data.OleDb;
using System.Data;

namespace Sys.Data
{
    class OleDbProvider : DbProvider
    {
        public OleDbProvider(string script, DataProviderConnection connection)
            :base(script,connection)
        { 
        
        }

     

        public override DbDataAdapter DbDataAdapter
        {
            get
            {
                return new OleDbDataAdapter();
            }
        }

        public override DbCommand NewDbCommand
        {
            get
            {
                return new OleDbCommand(script, (OleDbConnection)DbConnection);
            }
        }

        public override void FillDataSet(DataSet dataSet)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = (OleDbCommand)NewDbCommand;
            adapter.Fill(dataSet);
        }

        public override void FillDataTable(DataSet dataSet, string tableName)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = (OleDbCommand)NewDbCommand;
            adapter.Fill(dataSet, tableName);
        }

        public override void FillDataTable(DataTable table)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = (OleDbCommand)NewDbCommand;
            adapter.Fill(table);
        }

        public override DbParameter AddParameter(string parameterName, object value)
        {
            OleDbType dbType = OleDbType.WChar;
            if (value is Int32)
                dbType = OleDbType.Integer;
            else if (value is DateTime)
                dbType = OleDbType.Date;
            else if (value is Double)
                dbType = OleDbType.Double;
            else if (value is Decimal)
                dbType = OleDbType.Decimal;
            else if (value is Boolean)
                dbType = OleDbType.Boolean;
            else if (value is string && ((string)value).Length > 4000)
                dbType = OleDbType.BSTR;

            OleDbParameter param = new OleDbParameter(parameterName, dbType);
            param.Value = value;
            param.Direction = ParameterDirection.Input;
            return param;

        }

    }
}

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
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.SqlServerCe;
using Tie;

namespace Sys.Data
{
  
  
    public class DataProviderConnection : IValizable
    {
        private DataProviderType providerType;
        private string connectionString;
        private string name;

        internal DataProviderConnection(string name, DataProviderType type, string connectionString)
        {
            this.name = name;
            this.providerType = type;
            this.connectionString = connectionString;
        }


        internal DbType DbType
        {
            get
            {
                switch (providerType)
                {
                    case DataProviderType.SqlServer:
                        return DbType.SqlDb;

                    case DataProviderType.SqlServerCe:
                        return DbType.SqlCe;

                    default:
                        return DbType.OleDb;
                }
            }
        }

        public DbConnection NewDbConnection
        {
            get
            {
                switch (DbType)
                {
                    case DbType.SqlDb:
                        return new SqlConnection(connectionString);

                    case DbType.OleDb:
                        return new OleDbConnection(connectionString);

                    case DbType.SqlCe:
                        return new SqlCeConnection(connectionString);
                }

                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get { return this.name; }
        }
     
        public override string ToString()
        {
            return string.Format("{0}({1})",this.name, this.connectionString);
        }


        internal DataProviderConnection(VAL val)
        {
            this.name = val["name"].Str;
            this.providerType = (DataProviderType)val["type"].Intcon;
            this.connectionString = val["connection"].Str;
        }

        public VAL GetValData()
        {
            VAL val = new VAL();
            val["name"] = new VAL(this.name);
            val["type"] = new VAL((int)this.providerType);
            val["connection"] = new VAL(this.connectionString);

            return val;
        }
    }

   
}


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
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using Tie;

namespace Sys.Data
{
    public class DataProvider : IValizable, IComparable<DataProvider>, IComparable
    {
        internal const int DEFAULT_HANDLE = 0;
        internal const int USER_HANDLE_BASE = DEFAULT_HANDLE + 1000;
     
        private int handle;

        internal DataProvider(int handle, string name, DataProviderType type, string connectionString)
        {
            this.handle = handle;
            this.Name = name;
            this.Type = type;
            this.ConnectionString = connectionString;
        }

        internal int Handle { get { return this.handle; } }
        
        public string Name { get; private set; }
        public DataProviderType Type {get; private set;}
        public string ConnectionString { get; private set; }

        public override bool Equals(object obj)
        {
            DataProvider name = (DataProvider)obj;
            return this.handle.Equals(name.handle) ;
        }

        public override int GetHashCode()
        {
            return this.handle.GetHashCode();
        }


        public int CompareTo(object obj)
        {
            return CompareTo((DataProvider)obj);
        }

        public int CompareTo(DataProvider provider)
        {
            return handle.CompareTo(provider.handle);
        }


        public override string ToString()
        {
            return string.Format("Provider Handle={0} Name={1}", this.handle, this.Name);
        }

        public static explicit operator int(DataProvider provider)
        {
            return provider.handle;
        }

        public DataProvider(VAL val)
        {
            this.handle = val.Intcon;
        }

        public void SetVAL(VAL val)
        {
            this.Name = val["name"].Str;
            this.Type = (DataProviderType)val["type"].Intcon;
            this.ConnectionString = val["connection"].Str;
        }
        public VAL GetVAL()
        {
            VAL val = new VAL();
            val["name"] = new VAL(this.Name);
            val["type"] = new VAL((int)this.Type);
            val["connection"] = new VAL(this.ConnectionString);

            return val;
        }
       
        internal DbProviderType DpType
        {
            get
            {
                switch (Type)
                {
                    case DataProviderType.SqlServer:
                        return DbProviderType.SqlDb;

                    case DataProviderType.SqlServerCe:
                        return DbProviderType.SqlCe;

                    default:
                        return DbProviderType.OleDb;
                }
            }
        }

        public DbConnection NewDbConnection
        {
            get
            {
                switch (DpType)
                {
                    case DbProviderType.SqlDb:
                        return new SqlConnection(ConnectionString);

                    case DbProviderType.OleDb:
                        return new OleDbConnection(ConnectionString);

                }

                throw new NotImplementedException();
            }
        }
    }
}

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
    public class ConnectionProvider : IValizable, IComparable<ConnectionProvider>, IComparable
    {
        internal const int DEFAULT_HANDLE = 0;
        internal const int USER_HANDLE_BASE = DEFAULT_HANDLE + 1000;

        internal ConnectionProvider(int handle, string name, ConnectionProviderType type, string connectionString)
        {
            this.Handle = handle;
            this.Name = name;
            this.Type = type;

            SetDbConnectionString(connectionString);
        }

    
        public string Name { get; private set; }

        internal int Handle { get; private set;}
        internal ConnectionProviderType Type { get; private set; }
        
        internal string ConnectionString 
        { 
            get { return this.ConnectionBuilder.ConnectionString; }
        }

        internal DbConnectionStringBuilder ConnectionBuilder { get; private set; }

        private void SetDbConnectionString(string connectionString)
        {
            if (Type == ConnectionProviderType.SqlServer)
                this.ConnectionBuilder = new SqlConnectionStringBuilder(connectionString);
            else
                this.ConnectionBuilder = new OleDbConnectionStringBuilder(connectionString);
        }

        public string Catalog
        {
            get { return ConnectionBuilder["Initial Catalog"].ToString(); }
            set { ConnectionBuilder["Initial Catalog"] = value; }
        }


        public string DataSource
        {
            get { return ConnectionBuilder["Data Source"].ToString(); }
            set { ConnectionBuilder["Data Source"] = value; }

        }

      

        public override bool Equals(object obj)
        {
            ConnectionProvider pvd = (ConnectionProvider)obj;
            return this.Handle.Equals(pvd.Handle) ;
        }

        public override int GetHashCode()
        {
            return this.Handle.GetHashCode();
        }


        public int CompareTo(object obj)
        {
            return CompareTo((ConnectionProvider)obj);
        }

        public int CompareTo(ConnectionProvider provider)
        {
            return Handle.CompareTo(provider.Handle);
        }


        public override string ToString()
        {
            return string.Format("Provider Handle={0} Name={1}", this.Handle, this.Name);
        }

        public string ToSimpleString()
        {
            return string.Format("{0}\\{1}", this.Name, this.Catalog);
        }

        public static explicit operator int(ConnectionProvider provider)
        {
            return provider.Handle;
        }

        public ConnectionProvider(VAL val)
        {
            SetVAL(val);
        }

        public void SetVAL(VAL val)
        {
            this.Handle = val["handle"].Intcon;
            this.Name = val["name"].Str;
            this.Type = (ConnectionProviderType)val["type"].Intcon;
            SetDbConnectionString(val["connection"].Str);
        }


        public VAL GetVAL()
        {
            VAL val = new VAL();
            val["handle"] = new VAL(this.Handle);
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
                    case ConnectionProviderType.SqlServer:
                        return DbProviderType.SqlDb;

                    case ConnectionProviderType.SqlServerCe:
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

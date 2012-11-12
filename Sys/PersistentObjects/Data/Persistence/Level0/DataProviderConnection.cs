using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using Tie;

namespace Sys.Data
{
  
    internal enum DbType
    {
        OleDb,
        SqlDb
    }

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

                    default:
                        return DbType.OleDb;
                }
            }
        }

        public DbConnection DbConnection
        {
            get
            {
                if (DbType == DbType.SqlDb)
                    return new SqlConnection(connectionString);
                else
                    return new OleDbConnection(connectionString);
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


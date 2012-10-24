using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Sys.Data
{
  
    internal enum DbType
    {
        OleDb,
        SqlDb
    }

    public class DataProvider
    {
        private DataProviderType providerType;
        private string connectionString;

        internal DataProvider(DataProviderType type, string connectionString)
        {
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

        public DbCommand DbCommand(string script)
        {
            return DbCommand(script, this.DbConnection);
        }

        public DbCommand DbCommand(string script, DbConnection connection)
        {
             DbCommand command;

            if (DbType == DbType.SqlDb)
                command = new SqlCommand(script, (SqlConnection)connection);
            else
                command = new OleDbCommand(script, (OleDbConnection)connection);

            if (script.Contains(" "))  //Stored Procedure Name does not contain a space letter
                command.CommandType = CommandType.Text;
            else
                command.CommandType = CommandType.StoredProcedure;

            return command;
        }


        internal string ConnectionString
        {
            get { return this.connectionString; }
        }

        public override string ToString()
        {
            return this.connectionString;;
        }
    }

   
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sys.Data
{
    class XmlSchemaProvider : SchemaProvider
    {
        DataSet dbSchema;

        public XmlSchemaProvider(ConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
            dbSchema = new DataSet();
            using (var reader = new System.IO.StreamReader(connectionProvider.DataSource))
            {
                dbSchema = new DataSet();
                dbSchema.ReadXml(reader);
                if (dbSchema.Tables.Count == 0)
                    throw new Exception(string.Format("error in xml schema file: {0}", connectionProvider));
            }

        }

      
        public override DatabaseName[] GetDatabaseNames()
        {
            return new DatabaseName[] { provider.DefaultDatabaseName };
        }

        public override TableName[] GetTableNames(DatabaseName databaseName)
        {
            return InformationSchema.XmlTableNames(databaseName, dbSchema.Tables[0]);
        }

        public override TableName[] GetViewNames(DatabaseName dname)
        {
            return new TableName[] { };
        }

        public override DataTable GetTableSchema(TableName tableName)
        {
            return InformationSchema.XmlTableSchema(tableName, dbSchema.Tables[0]);
        }

        public override DataSet GetDatabaseSchema(DatabaseName dname)
        {
            return dbSchema;
        }

        public override DataTable GetDependencySchema(DatabaseName dname)
        {
            throw new NotImplementedException();
        }
    }
}

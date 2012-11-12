using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public class DatabaseName
    {
        private DataProvider provider = DataProvider.DefaultProvider;
        private string databaseName;

        public DatabaseName(string databaseName)
            :this(DataProvider.DefaultProvider, databaseName)
        { 

        }

        public DatabaseName(DataProvider handle, string databaseName)
        {
            this.provider = handle;
            this.databaseName = databaseName;
        }

        public string Name
        {
            get { return this.databaseName; }
        }

        internal DataProvider Provider
        {
            get { return this.provider; }
            set { this.provider = value; }
        }

        public override int GetHashCode()
        {
            return databaseName.GetHashCode() + this.provider.GetHashCode() * 1000000;
        }

        public override bool Equals(object obj)
        {
            DatabaseName name = (DatabaseName)obj;
            return databaseName.Equals(name.databaseName) && this.provider.Equals(name.provider);
        }

        public override string ToString()
        {
            return this.databaseName;
        }
    }
}

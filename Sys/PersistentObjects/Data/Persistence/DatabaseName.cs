using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public class DatabaseName
    {
        private DataProvider provider;
        private string name;

        public DatabaseName(string databaseName)
            :this(DataProvider.DefaultProvider, databaseName)
        { 

        }

        public DatabaseName(DataProvider handle, string databaseName)
        {
            this.provider = handle;
            this.name = databaseName;
        }

        public string Name
        {
            get { return this.name; }
        }

        internal DataProvider Provider
        {
            get { return this.provider; }
            set { this.provider = value; }
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + this.provider.GetHashCode() * 324819;
        }

        public override bool Equals(object obj)
        {
            DatabaseName dname = (DatabaseName)obj;
            return this.name.Equals(dname.name) && this.provider.Equals(dname.provider);
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}

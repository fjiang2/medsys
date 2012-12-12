using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data.Manager;

namespace Sys.Data
{
    public class DatabaseName : IComparable<DatabaseName>, IComparable
    {
        private DataProvider provider;
        private string name;

        public DatabaseName(DataProvider provider, string databaseName)
        {
            this.provider = provider;
            this.name = databaseName;
        }

        public string Name
        {
            get { return this.name; }
        }

        public int Id
        {
            get
            {
                return DictDatabase.GetId(this);
            }
        }

        internal DataProvider Provider
        {
            get { return this.provider; }
        }

        public int CompareTo(object obj)
        {
            return CompareTo((DatabaseName)obj);
        }

        public int CompareTo(DatabaseName n)
        {
            if (this.provider.CompareTo(n.provider) == 0)
               return this.name.CompareTo(n.name);

            return this.provider.CompareTo(n.provider);
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
            return string.Format("{0}, {1}", this.provider, this.name);
        }
    }
}

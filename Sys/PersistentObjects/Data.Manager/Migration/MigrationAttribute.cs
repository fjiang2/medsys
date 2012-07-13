using System;

namespace Sys.Data.Manager
{
    public class MigrationAttribute : Attribute
    {
        private long version;
        private bool ignore = false;

        public MigrationAttribute(long version)
        {
            Version = version;
        }

        public long Version
        {
            get { return version; }
            private set { version = value; }
        }

        public bool Ignore
        {
            get { return ignore; }
            set { ignore = value; }
        }
    }
}

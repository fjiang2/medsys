using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public struct DataProviderHandle
    {
        const int DEFAULT_HANDLE = 0;
        const int USER_HANDLE_BASE_ = DEFAULT_HANDLE + 1000;

        internal static readonly DataProviderHandle DEFAULT_PROVIDER = new DataProviderHandle(DEFAULT_HANDLE);
        internal static readonly DataProviderHandle USER_BASE_PROVIDER = new DataProviderHandle(USER_HANDLE_BASE_);
     
        private int handle;

        private DataProviderHandle(int handle)
        {
            this.handle = handle;
        }

        public static DataProviderHandle operator ++(DataProviderHandle handle)
        {
            return new DataProviderHandle(handle.handle + 1);
        }

        public override bool Equals(object obj)
        {
            DataProviderHandle name = (DataProviderHandle)obj;
            return this.handle.Equals(name.handle) ;
        }

        public override int GetHashCode()
        {
            return this.handle.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Data Provider Handle={0}", this.handle);
        }
    }
}

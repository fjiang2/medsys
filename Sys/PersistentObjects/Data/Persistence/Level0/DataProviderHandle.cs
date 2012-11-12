using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tie;

namespace Sys.Data
{
    public struct DataProviderHandle : IValizable
    {
        const int DEFAULT_HANDLE = 0;
        const int USER_HANDLE_BASE = DEFAULT_HANDLE + 1000;

        internal static readonly DataProviderHandle DefaultProviderHandle = new DataProviderHandle(DEFAULT_HANDLE);
        internal static readonly DataProviderHandle Handle1 = new DataProviderHandle(DEFAULT_HANDLE + 1);
        internal static readonly DataProviderHandle Handle2 = new DataProviderHandle(DEFAULT_HANDLE + 2);
        internal static readonly DataProviderHandle Handle3 = new DataProviderHandle(DEFAULT_HANDLE + 3);
        internal static readonly DataProviderHandle Handle4 = new DataProviderHandle(DEFAULT_HANDLE + 4);

        internal static readonly DataProviderHandle USER_PROVIDER_HANDLE_BASE = new DataProviderHandle(USER_HANDLE_BASE);
     
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
            return string.Format("Handle={0}", this.handle);
        }


        public DataProviderHandle(VAL val)
        {
            this.handle = val.Intcon;
        }

        public VAL GetValData()
        {
            return new VAL(this.handle);
        }
    }
}

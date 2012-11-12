using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tie;

namespace Sys.Data
{
    public struct DataProvider : IValizable
    {
        const int DEFAULT_HANDLE = 0;
        const int USER_HANDLE_BASE = DEFAULT_HANDLE + 1000;

        internal static readonly DataProvider DefaultProvider = new DataProvider(DEFAULT_HANDLE);
        internal static readonly DataProvider Handle1 = new DataProvider(DEFAULT_HANDLE + 1);
        internal static readonly DataProvider Handle2 = new DataProvider(DEFAULT_HANDLE + 2);
        internal static readonly DataProvider Handle3 = new DataProvider(DEFAULT_HANDLE + 3);
        internal static readonly DataProvider Handle4 = new DataProvider(DEFAULT_HANDLE + 4);

        internal static readonly DataProvider USER_PROVIDER_HANDLE_BASE = new DataProvider(USER_HANDLE_BASE);
     
        private int handle;

        private DataProvider(int handle)
        {
            this.handle = handle;
        }

        public static DataProvider operator ++(DataProvider handle)
        {
            return new DataProvider(handle.handle + 1);
        }

        public override bool Equals(object obj)
        {
            DataProvider name = (DataProvider)obj;
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

        public int Handle
        {
            get { return this.handle; }
        }

                
        public DataProvider(VAL val)
        {
            this.handle = val.Intcon;
        }

        public VAL GetValData()
        {
            return new VAL(this.handle);
        }
    }
}

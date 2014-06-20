//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tie;

namespace Sys.Data
{
    public struct DataProvider : IValizable, IComparable<DataProvider>, IComparable
    {
        internal const int DEFAULT_HANDLE = 0;
        internal const int USER_HANDLE_BASE = DEFAULT_HANDLE + 1000;
        internal static readonly DataProvider DefaultProvider = new DataProvider(DEFAULT_HANDLE);
     
        private int handle;

        internal DataProvider(int handle)
        {
            this.handle = handle;
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


        public int CompareTo(object obj)
        {
            return CompareTo((DataProvider)obj);
        }

        public int CompareTo(DataProvider n)
        {
            return handle.CompareTo(n.handle);
        }


        public override string ToString()
        {
            DataProviderConnection connection = DataProviderManager.Instance.GetConnection(this);

            if (connection != null)
                return string.Format("Provider Handle={0} Name={1}", this.handle, connection.Name);
            else
                return string.Format("Provider Handle={0}", this.handle);
        }

        public static explicit operator int(DataProvider provider)
        {
            return provider.handle;
        }

        public DataProvider(VAL val)
        {
            this.handle = val.Intcon;
        }

        public void SetVAL(VAL val)
        {
            this.handle = val.Intcon;
        }

        public VAL GetVAL()
        {
            return new VAL(this.handle);
        }
    }
}

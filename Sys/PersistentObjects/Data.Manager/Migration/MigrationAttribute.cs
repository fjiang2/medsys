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

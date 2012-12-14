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

namespace Sys.Data.Manager
{
    
    public abstract class Migration
    {
        private MigrationProvider provider;

        public string Name
        {
            get { return GetType().Name; }
        }

        public abstract void Up();

        public virtual void AfterUp()
        {
        }

        public abstract void Down();

        public virtual void AfterDown()
        {
        }

        public MigrationProvider Database
        {
            get { return provider; }
            set { provider = value; }
        }

        public virtual void InitializeOnce(string[] args)
        {
        }
    }
}

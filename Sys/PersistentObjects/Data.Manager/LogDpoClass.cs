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
using System.Data;
using Sys.PersistentObjects.DpoClass;

namespace Sys.Data.Manager
{
    public class LogDpoClass : logDpoClassDpo
    {
        public LogDpoClass()
        { 
        }

        public LogDpoClass(DataRow row)
            : base(row)
        { 
        }

        public LogDpoClass(TableName tname)
        {
            this.table_id = tname.Id;
            this.user_id = Active.Account.UserID;
            this.Load();
        }

        public static void Log(ClassTableName tname, string path, ClassName cname)
        {
            logDpoClassDpo log = new logDpoClassDpo();
            log.table_id = tname.Id;
            log.user_id = Active.Account.UserID;
            log.path = path;
            log.name_space = cname.Namespace;
            log.modifier = (int)cname.Modifier;
            log.class_name = cname.Class;
            log.table_level = (int)tname.Level;
            log.packed = tname.Pack;

            log.Save();
        }
    }
}

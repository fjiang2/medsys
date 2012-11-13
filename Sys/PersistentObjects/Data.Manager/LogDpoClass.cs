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

        public LogDpoClass(ClassTableName tname)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.ViewManager.Dpo;

namespace Sys.ViewManager.Security
{
    class FormPermission : FormPermissionDpo
    {

        public FormPermission()
        { }

        public FormPermission(DataRow dataRow)
            : base(dataRow)
        { 
        
        }


        public FormPermission(int roleID, string keyName)
        {
            this.Role_ID = roleID;
            this.Key_Name = keyName;
            Load();
        }
    }
}

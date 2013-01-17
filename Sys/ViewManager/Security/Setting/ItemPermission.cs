using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.ViewManager.DpoClass;


namespace Sys.ViewManager.Security
{
    class ItemPermission : ItemPermissionDpo
    {

        public ItemPermission()
        { }

        public ItemPermission(DataRow dataRow)
            : base(dataRow)
        { 
        
        }


        public ItemPermission(int roleID, int ty, int id)
        {
            this.Role_ID = roleID;
            this.Ty = ty;
            this.ID = id;
            Load();
        }
    }
}

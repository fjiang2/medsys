using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Sys.Data;
using Sys.Foundation.DpoClass;

namespace Sys.Security
{
    public class UserRole : UserRoleDpo
    {

        public UserRole()
        {
        }

        public UserRole(DataRow dataRow)
            : base(dataRow)
        { 
        
        }

        public UserRole(int userID, int roleID)
        {
            User_ID = userID;
            Role_ID = roleID;
            Load();
        }



  
    }
}

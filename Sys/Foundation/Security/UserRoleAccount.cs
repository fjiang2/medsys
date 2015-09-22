using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Sys.Data;

namespace Sys.Security
{
 
    public class UserRoleAccount : UserAccount
    {
        protected List<int> roles = new List<int>();

        public UserRoleAccount()
        { 
        }

        public UserRoleAccount(string userName)
            : base(userName)
        {
        }

        //for admin
        public UserRoleAccount(int userID)
            : base(userID)
        {
            GetRoles(roles);
        }

        public List<int> Roles
        {
            get { return roles; }
        }

        public bool AddRole(int roleID)
        {
            if (roles.Contains(roleID))
                return false;

            roles.Add(roleID);

            UserRole userRole = new UserRole();
            userRole.User_ID = UserID;
            userRole.Role_ID = roleID;
            userRole.Save();

            return true;
        }

        public bool RemoveRole(int roleID)
        {
            if (!roles.Contains(roleID))
                return false;

            roles.Remove(roleID);

            UserRole userRole = new UserRole(UserID, roleID);
            if (userRole.Exists)
                userRole.Delete();

            return true;
        }

        public bool HasRole(int roleID)
        {
            return roles.IndexOf(roleID) >= 0;
        }

        public bool HasRole(PredefinedRole roleID)
        {
            return roles.IndexOf((int)roleID) >= 0;
        }

        public bool IsAdmin
        {
            get 
            {
                if (this.User_ID == PredefinedUser.adminID)
                    return true;
                
                if (IsDeveloper)
                    return true;
                
                return HasRole(PredefinedRole.admin); 
            }
        }

        public bool IsDeveloper
        {
            get 
            {
                if (this.User_ID == PredefinedUser.develID)
                    return true;

                return HasRole(PredefinedRole.devel); 
            }
        }

        public bool IsSecurityAdmin
        {
            get { return HasRole(PredefinedRole.security); }
        }
       

        protected override void EnterLoginedState()
        {
            base.EnterLoginedState();

            GetRoles(roles);
        }

        protected override void ExitLoginedState()
        {
            roles = null;
            base.ExitLoginedState();
        }

        private void GetRoles(List<int> roles)
        {
            TableName tableName = typeof(UserRole).TableName();

            DataTable dt = DataExtension.FillDataTable(
                tableName.Provider,
                string.Format("SELECT Role_ID FROM {0} WHERE User_ID={1}", tableName.FullName, this.User_ID));

            foreach (DataRow row in dt.Rows)
            {
                int roleID = (int)row[UserRole._Role_ID];
                if (roles.IndexOf(roleID) == -1)
                    roles.Add(roleID);

            }

        }
    }
}

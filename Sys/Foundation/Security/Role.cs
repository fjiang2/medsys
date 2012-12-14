using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Sys.Data;
using Sys.Foundation.DpoClass;

namespace Sys.Security
{
    public class Role : IComparer<Role>
    {
        public int Role_ID;		//int(4) not null
        public DateTime? Date_Activated;		//datetime(8) null
        public DateTime? Date_Expired;		//datetime(8) null


        public Role(int roleID)
            : this(roleID, null, null)
        { 
        
        }
        
        public Role(int roleID, DateTime? activated, DateTime? expired)
        {
            this.Role_ID = roleID;
            this.Date_Activated = activated;
            this.Date_Expired = expired;
        }

        public int Compare(Role x, Role y)
        {
            return y.Role_ID.CompareTo(x.Role_ID);
        }

        public bool IsActive
        {
            get
            {
                return NotActivatedLimit && NotExpiredLimit;
            }
        }


        private bool NotActivatedLimit
        {

            get
            {
                if (Date_Activated == null)
                    return true;

                return DateTime.Now >= (DateTime)Date_Activated;
            }
        }

        private bool NotExpiredLimit
        {
            get
            {
                if (Date_Expired == null)
                    return true;

                return DateTime.Now <= (DateTime)Date_Expired;
            }
        }

        public static DataTable AllRoles()
        {
            return new TableReader<RoleDpo>(RoleDpo._Role_ID.ColumnName() != (int)PredefinedRole.devel).Table;
        }

        public static DataTable UserRoles(string userName)
        {
            TableName tableName = typeof(UserDpo).TableName();
            string SQL = @"
                SELECT U.User_ID, User_Name, First_Name, Last_Name, R.Role_ID, Role_Name 
                  FROM {0} U 
 	                   INNER JOIN {1} UR ON U.User_ID=UR.User_ID 
	                   INNER JOIN {2} R ON UR.Role_ID = R.Role_ID AND R.Role_ID <> {4}
                WHERE User_Name = '{3}' 
            ";

            return SqlCmd.FillDataTable(
                tableName.Provider,
                SQL,
                UserDpo.TABLE_NAME,
                UserRoleDpo.TABLE_NAME,
                RoleDpo.TABLE_NAME,
                userName,
                (int)PredefinedRole.devel);
        }


    }
}

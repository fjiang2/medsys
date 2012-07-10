using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Sys.Data;
using Sys.DataManager;

namespace Sys.Security
{
    public class Account : UserRoleAccount 
    {
        /// <summary>
        /// used by Visual Studio in BaseForm designer. don't read database server because database connection string is not initialized
        /// </summary>
        private Account()
        {
            this.User_ID = 1;
            this.User_Name = PredefinedUser.admin;
            this.Inactive = false;
        }

        public Account(string employeeID)
            :base(employeeID)
        {
        }


        public Account(string employeeID, string password)
            : base(employeeID)
        {
            if (!Login(password))
                return;

        }

        public string EmployeeID
        { 
            get { return UserName; } 
        }

        
        public string EmailAddress
        {
            get
            {
                return Email;
            }
        }

        public string FullEmailAddress
        {
            get
            {
                return string.Format("\"{0} {1}\"<{2}>", FirstName, LastName, Email);
            }
        }


        public override string ToString()
        {
            return string.Format("{0} {1}({2})", FirstName, LastName, UserName);
        }

      
        public static bool SwitchAccount(string userName)
        {
            Account account = new Account(userName);
            if (account.IsLogined())
            {
                Active.SetCurrentUser(account);
                return true;
            }

            return false;
        }

        public override void Logout()
        {
            base.Logout();
            Active.SetCurrentUser(null);
        }






        public static void SetCurrentUser(Account account)
        {
            #if DEBUG
            designMode = false;
            #endif

            Active.SetCurrentUser(account);
        }

        #if DEBUG
        /// <summary>
        ///  used for Visual Studio Design Mode, becuase DB_SYSTEM is not set yet
        /// </summary>
        private static bool designMode = true;
        #endif

        public static Account CurrentUser
        {
            get
            {
#if DEBUG
                if (designMode)
                {
                    Account temp = new Account();
                    SetCurrentUser(temp);
                    return temp;
                }
#endif
                return (Account)Active.Account;
            }
        }

 
    }

}

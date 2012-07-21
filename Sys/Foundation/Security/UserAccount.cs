using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System;
using System.Text;
using System.Security.Cryptography;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Foundation.DpoClass;

namespace Sys.Security
{

    public class UserAccount: UserDpo, IAccount
    {
        private bool isLogined = false;
        private int tryTimes;

        public UserAccount()
        { 
        }

        public UserAccount(string userName)
        {
            this.User_Name = userName;
            this.Load();

            if (Exists)
            {
                //prevent people change devel, admin and ignore ID
                if (userName == PredefinedUser.devel)
                    this.User_ID = PredefinedUser.develID;

                else if (userName == PredefinedUser.admin)
                    this.User_ID = PredefinedUser.adminID;
                
                else if (userName == PredefinedUser.singleuser)
                    this.User_ID = PredefinedUser.singleuserID;
            }
            else
            {
                this.User_ID = PredefinedUser.unknownID;
                this.User_Name = PredefinedUser.unknown;

                this.First_Name = "";
                this.Last_Name = "Unknown";
            }
        }


        public UserAccount(int userID)
        {
            SetLocator(new string[] {UserDpo._User_ID});
            this.User_ID = userID;
            Load();
        }

        protected override int DPObjectId
        {
            get
            {
                return this.User_ID;
            }
        }

        public virtual bool Login(string password)
        {
            if (this.UserName == PredefinedUser.singleuser)
            {
                EnterLoginedState();
                return true;
            }

            if (!this.Exists)
                return false;

            if(Inactive)
                throw new JException(MessageCode.AccountClosed, "Account is closed, contact with supervisor.");


            tryTimes = tryTimes - 1;
            if (IsLocked())
                throw new JException(MessageCode.AccountLocked, "Account is locked, contact with supervisor.");

            //check start date 
            if (Start_Date != null && System.DateTime.Now < Start_Date)
                 return false;

            //check expired date 
            if (End_Date != null && System.DateTime.Now > End_Date)
                 return false;
             
            if (Password == null)
            {
                //password has not set yet, set default password
                ChangePassword(Constant.POLICY_DEFAULT_PASSWORD);
            }
            else
            {
                if (!isPasswordValid(password, this.Password))
                    return false;
            }

            EnterLoginedState();
            return true;
        }


        public bool MustChangePassword()
        {
            if (User_ID == PredefinedUser.adminID || User_ID == PredefinedUser.develID)
                return false;

            return Password_Changed_DT != null && DateTime.Now > Password_Changed_DT + new TimeSpan(Constant.POLICY_PASSWORD_EXPRIED_DAYS, 0, 0, 0, 0);
        }

        public virtual void Logout()
        {
            ExitLoginedState();
        }

        public bool IsLogined()
        {
            return isLogined;
        }

        public bool IsLocked()
        {
            //turn off this option currently. To turn on this option, remove 'False' and place '_TryTimes <= 0' 
            return false;
            //_TryTimes <= 0 
        }

        protected virtual void EnterLoginedState()
        {
            isLogined = true;
        }

        protected virtual void ExitLoginedState()
        {
            isLogined = false;
            User_ID = 0;
        }


        /// <summary>
        /// Minimum 6 characters in length,Contains 3/4 of the following items:
        /// - Uppercase Letters
        /// - Lowercase Letters
        /// - Numbers
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool GoodPassword(string password)
        {
            if (password.Length < 6)
                return false;

            int UL = 0;
            int LL = 0;
            int N = 0;
            int other = 0;
            foreach (char ch in password)
            {
                if (char.IsUpper(ch))
                    UL++;
                else if (char.IsLower(ch))
                    LL++;
                else if (char.IsNumber(ch))
                    N++;
                else
                    other++;
            }

            if (UL < 1|| LL<1 || N<1)
                return false;
            
            return true;
        }

        public bool ValidatePassword(string password)
        {
            return isPasswordValid(password, this.Password);
        }

        public bool ValidatePlainPassword(string plainPassword)
        {
            return this.Plain_Password == plainPassword;
        }

        public bool ChangePassword(string password, string newPassword)
        {
            if (isPasswordValid(password, this.Password))
            {
                return ChangePassword(newPassword);
            }
            return false;
        }
        

        #region Password 
        
        public bool ChangePassword(string newPassword)
        {
            this.Password = passwordText2Bytes(newPassword);
            this.Password_Changed_DT = DateTime.Now;
            Save();

            return true;
        }

        private static bool isPasswordValid(string text, byte[] bytes)
        {
            byte[] bin = passwordText2Bytes(text);

            if (bin.Length != bytes.Length)
            {
                return false;
            }

            for (int i = 0; i <= bin.Length - 1; i++)
            {
                if (bin[i] != bytes[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static byte[] passwordText2Bytes(string text)
        {
            return SHA1Managed.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
        }
        
        #endregion

        public string FullName
        {
            get { return string.Format("{0}, {1}",Last_Name, First_Name); }
        }
        
        public string Name
        {
            get { return FirstName + " " + LastName; }
        }

        public string ESignature
        {
            get { return string.Format("{0}{1}{2}",First_Name.Trim(),Last_Name.Trim(),User_Name.Trim()); }
        }

        public string FirstName
        {
            get { return First_Name; }
        }

        public string LastName
        {
            get { return Last_Name; }
        }

        public string UserName
        {
            get { return User_Name; }
        }

     
        public int UserID
        {
            get { return User_ID; }
        }

     
        public static bool ExistedUserName(string userName)
        {
            UserAccount account = new UserAccount(userName);
            return account.Exists;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", Name, UserName);
        }
    }
}

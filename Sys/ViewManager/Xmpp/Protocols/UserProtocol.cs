using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using System.Data;
using Sys.Security;
using Sys.ViewManager;
using Sys.Data;

namespace Sys.Xmpp
{
    public class UserProtocol :  IValizable 
    {
        public const string USER_ID = "ID";
        public const string USER_NAME = "UserName";
        public const string FULL_NAME = "FullName";

        public int ID;
        public string UserName;
        public string FullName;

        public UserProtocol(DataRow dataRow)
        {
            this.ID = (int)dataRow["User_ID"];
            this.UserName = (string)dataRow["User_Name"];
            this.FullName = (string)dataRow["Full_Name"];
        }

        public UserProtocol(VAL val)
        {
            this.ID = val[USER_ID].Intcon;
            this.UserName = val[USER_NAME].Str;
            this.FullName = val[FULL_NAME].Str;
        }

        public UserProtocol(Account account)
        {
            this.ID = account.UserID;
            this.UserName = account.UserName;
            this.FullName = account.Name;
        }

   
        public VAL GetVAL()
        {
            VAL user = new VAL();
            user[USER_ID] = new VAL(this.ID);
            user[USER_NAME] = new VAL(this.UserName);
            user[FULL_NAME] = new VAL(this.FullName);
            
            return user;
        }

        public void SetVAL(VAL val)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("{0}({1})",FullName, UserName);
        }
    }
}

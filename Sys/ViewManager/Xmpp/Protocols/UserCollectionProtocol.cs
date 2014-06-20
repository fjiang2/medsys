using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tie;
using Sys.ViewManager;
using Sys.Data;

namespace Sys.Xmpp
{
    public class UserCollectionProtocol : List<UserProtocol>, IValizable
    {

        public UserCollectionProtocol()
        {
        
        }

        public UserCollectionProtocol(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                UserProtocol user = new UserProtocol(dataRow);
                this.Add(user);
            }
        }

        public UserCollectionProtocol(VAL users)
        {
            for (int i = 0; i < users.Size; i++)
            {
                UserProtocol user = new UserProtocol(users[i]);
                this.Add(user);
            }
        }

        public VAL GetVAL()
        {
            VAL users = VAL.Array();
            foreach (UserProtocol user in this)
            {
                users.Add(user.GetVAL());
            }
            return users;
        }

        public void SetVAL(VAL val)
        {
            throw new NotImplementedException();
        }

        public void Add(UserCollectionProtocol users)
        {
            foreach (UserProtocol user in users)
            {
                if(this.IndexOf(user)<0)
                     this.Add(user);
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < this.Count; i++)
            {
                if (i != 0)
                    s += ",";
                s += this[i].ToString();
            }

            return s;
        }
    }
}

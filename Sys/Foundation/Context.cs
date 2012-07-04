using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afs
{
    public static class Context
    {
        public static Afs.Security.UserAccount Account
        {
            get
            {
                return Afs.Security.Account.CurrentUser;
            }
        }
    }
}

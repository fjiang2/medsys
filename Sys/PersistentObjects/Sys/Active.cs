using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    public class Active
    {
        private static IAccount account = null;

        public static IAccount Account
        {
            get { return Active.account; }
        }

        public static void SetCurrentUser(IAccount account)
        {
            Active.account = account;
        }
    }
}

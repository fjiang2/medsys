using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Security
{
    public class PredefinedUser
    {
        public const int develID = 0;
        public const int adminID = 1;
        public const int ignoreID = 2;
        public const int unknownID = -1;

        public const string devel = "devel";
        public const string admin = "admin";
        public const string unknown = "unknown";

        /// <summary>
        /// No logon required
        /// </summary>
        public const string ignore = "ignore";  
    }
}

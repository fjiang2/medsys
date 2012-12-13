using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    /// <summary>
    /// system message code
    /// </summary>
    public enum MessageCode
    {
        /// <summary>
        /// nothing
        /// </summary>
        None = 0,

        /// <summary>
        /// password expired
        /// </summary>
        PasswordExpried =1001,

        /// <summary>
        /// user account closed
        /// </summary>
        AccountClosed = 1002,

        /// <summary>
        /// account is locked
        /// </summary>
        AccountLocked = 1003,

        /// <summary>
        /// record is overwritten
        /// </summary>
        RecordOverwritten =2011,

        /// <summary>
        /// table does not exist
        /// </summary>
        TableNotExist = 2012
    }

}

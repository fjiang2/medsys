using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys
{
    /// <summary>
    /// message level
    /// </summary>
    public enum MessageLevel
    {
        /// <summary>
        /// no error
        /// </summary>
        None = 0,

        /// <summary>
        /// information level
        /// </summary>
        Information = 1,

        /// <summary>
        /// warning level
        /// </summary>
        Warning = 2,

        /// <summary>
        /// error level
        /// </summary>
        Error = 3,

        /// <summary>
        /// fatal error level
        /// </summary>
        Fatal = 4,

        /// <summary>
        /// used to confirm the error message
        /// </summary>
        Confirmation = 5
    }
}

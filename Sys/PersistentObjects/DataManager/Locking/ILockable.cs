using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.DataManager
{
    public interface ILockable
    {
        /// <summary>
        /// if RECORD is locked, please use Table ID as LockType
        /// </summary>
        int LockType { get; }

        /// <summary>
        /// if RECORD is locked, please use Row ID as LockID
        /// </summary>
        int LockID { get; }
    }
}

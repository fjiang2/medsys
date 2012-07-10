using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public enum Level
    {
        /// <summary>
        /// Database name is fixed, cannot change unless source code changed
        /// </summary>
        Fixed,

        Default,

        /// <summary>
        /// System tables
        /// </summary>
        System

    }
}

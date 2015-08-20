using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace Sys.Data
{
    public class SqlExceptionEventArgs
    {
        public readonly Exception Exception;
        public readonly DbCommand Command;

        public SqlExceptionEventArgs(DbCommand cmd, Exception ex)
        {
            this.Command = cmd;
            this.Exception = ex;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;

namespace Sys.Data.Manager
{
    public interface IPacking
    {
      //  void Pack();
        void Unpack(JBackgroundWorker worker, SqlTrans transaction, bool insert);
        void Unpack(SqlTrans transaction, bool insert);
        int Count { get; }
        string TableName { get; }
        Level Level { get; }
    }
}

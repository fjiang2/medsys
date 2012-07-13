using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data.Manager
{
    public interface ILogable
    {
        void AddLog(LogTransaction transaction);
        void RemoveLog();
        bool Logged();
    }
}

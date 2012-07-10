using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.DataManager
{
    public interface ILogable
    {
        void AddLog(LogTransaction transaction);
        void RemoveLog();
        bool Logged();
    }
}

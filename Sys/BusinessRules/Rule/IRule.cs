using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.BusinessRules
{
    interface IRule
    {
        int ErrorCode { get; }
        string RuleDescription { get; }
        string RuleScript { get; }
    }
}

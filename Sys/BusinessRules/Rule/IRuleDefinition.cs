using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.BusinessRules
{
    public interface IRuleDefinition
    {
        void RuleDefinition(ValidateProvider provider);
    }
}

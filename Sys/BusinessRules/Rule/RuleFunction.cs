using System;
using System.Collections.Generic;
using System.Text;
using Tie;

namespace Sys.BusinessRules
{
    public class RuleFunction : IUserDefinedFunction
    {
        public RuleFunction()
        { 
        }

        public VAL Function(string func, VAL parameters, Memory facts)
        {
            VAL L0 = parameters[0];
            
            SeverityLevel severityLevel = SeverityLevel.None;
            string message = "";

            if (func == "error" || func == "warning" || func == "information" || func == "fatal")
            {

                Rule rule = (Rule)facts["$ActiveRule"].value;

                if (func == "error")
                    severityLevel = SeverityLevel.Error;
                else if (func == "warning")
                    severityLevel = SeverityLevel.Warning;
                else if (func == "information")
                    severityLevel = SeverityLevel.Information;
                else if (func == "fatal")
                    severityLevel = SeverityLevel.Fatal;


                if (parameters.Size > 1)
                    message = parameters[1].ToString2();
                else
                    message = rule.ToString();

                RuleEvent ruleEvent = new RuleEvent(rule.ErrorCode, L0.ToString2(), severityLevel, message);

                rule.Add(ruleEvent);
                
                return new VAL((int)severityLevel);
            }

            else
                return null;
        }

    }
}

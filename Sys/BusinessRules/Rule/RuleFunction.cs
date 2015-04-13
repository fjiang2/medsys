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
            
            MessageLevel severityLevel = MessageLevel.None;
            string message = "";

            if (func == "error" || func == "warning" || func == "information" || func == "fatal")
            {

                Rule rule = (Rule)facts["$ActiveRule"].Value;

                if (func == "error")
                    severityLevel = MessageLevel.Error;
                else if (func == "warning")
                    severityLevel = MessageLevel.Warning;
                else if (func == "information")
                    severityLevel = MessageLevel.Information;
                else if (func == "fatal")
                    severityLevel = MessageLevel.Fatal;


                if (parameters.Size > 1)
                    message = parameters[1].ToSimpleString();
                else
                    message = rule.ToString();

                RuleEvent ruleEvent = new RuleEvent(rule.ErrorCode, L0.ToSimpleString(), severityLevel, message);

                rule.Add(ruleEvent);
                
                return new VAL((int)severityLevel);
            }

            else
                return null;
        }

    }
}

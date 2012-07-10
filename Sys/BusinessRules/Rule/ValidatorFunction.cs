using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using System.Windows.Forms;

namespace Sys.BusinessRules
{
    public class ValidatorFunction : IUserDefinedFunction
    {
        public ValidatorFunction()
        { 
        }

        public VAL Function(string func, VAL parameters, Memory facts)
        {
            int size = parameters.Size;
            if (size > 2)
                throw new Exception(string.Format("Too many parameters {0}({1} in validator function)", func, parameters.ToString2()));

            VAL L0 = size > 0 ? parameters[0] : null;
            VAL L1 = size > 1 ? parameters[1] : null;
            
            Control control;
            string message = "";
            
            if(size == 2)
                control = (Control)L0.HostValue;
            else
                control = (Control)facts["$THIS"].HostValue;


            SeverityLevel severityLevel = SeverityLevel.None;

            if (func == "error" || func == "warning" || func == "information" || func == "fatal")
            {

                Validator validator = (Validator)facts["$ActiveValidator"].value;

                if (func == "error")
                    severityLevel = SeverityLevel.Error;
                else if (func == "warning")
                    severityLevel = SeverityLevel.Warning;
                else if (func == "information")
                    severityLevel = SeverityLevel.Information;
                else if (func == "fatal")
                    severityLevel = SeverityLevel.Fatal;


                if (size == 2)
                    message = L1.ToString2();
                else if (size == 1)
                    message = L0.ToString2();
                else
                    message = validator.ToString();

            
                RuleEvent ruleEvent = new RuleEvent(control.Name, severityLevel, message);
                validator.Add(control, ruleEvent);

                return new VAL((int)severityLevel);
            }

            else
                return null;
        }

    }
}


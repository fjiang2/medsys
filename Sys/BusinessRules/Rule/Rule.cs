using System;
using System.Collections.Generic;
using System.Text;
using Sys.Data;
using Tie;

namespace Sys.BusinessRules
{
  

    class Rule  
    {
        public readonly int ErrorCode;

        IRule rule;
        List<RuleEvent> ruleEvents;

        public Rule(IRule rule)
        {
            this.rule = rule;
            ruleEvents = new List<RuleEvent>();
            this.ErrorCode = rule.ErrorCode;
        }

        public void Add(RuleEvent ruleEvent)
        {
            ruleEvents.Add(ruleEvent);
        }

        public override String ToString()
        {
            return String.Format("{0} {1}", ErrorCode, rule.RuleDescription);
        }


        public bool CheckRule(string scope, Memory fact, IUserDefinedFunction ruleFunction, Dictionary<string, RuleEvent> brokenRules)
        { 
            bool passed = true;
          
            try
                {
                    fact.AddHostObject("$ActiveRule", this);
                    Script.Execute(scope, rule.RuleScript, fact, ruleFunction);

                    foreach (RuleEvent ruleEvent in this.ruleEvents)
                    {
                        string keyName = ruleEvent.keyName;

                        if (scope != "")
                           keyName = scope + "." + keyName;
                        
                        if (ruleEvent.SeverityLevel != SeverityLevel.None)
                        {
                            if (brokenRules.ContainsKey(keyName))
                                brokenRules.Remove(keyName);

                            brokenRules.Add(keyName, ruleEvent);

                            if (ruleEvent.SeverityLevel == SeverityLevel.Error || ruleEvent.SeverityLevel == SeverityLevel.Fatal)
                                passed = false;
                        }
                    }
                    

                }
                catch (CompilingException e1)
                {
                    passed = false;
                    throw new ApplicationException(String.Format("[Syntax] {0} at Rule={1}", e1.Message, ErrorCode));
                }
                catch (RuntimeException e2)
                {
                    passed = false;
                    throw new ApplicationException(String.Format("[Runtime] {0} at Rule={1}", e2.Message, ErrorCode));
                }
                catch(Exception e3)
                {
                    passed = false;
                    throw new ApplicationException(String.Format("[Runtime] {0} at Rule={1}", e3.Message, ErrorCode));
                }

            return passed;
        }



        protected string ConvertRule(string antecedent, string consequent, SeverityLevel severityLevel, string trace, string message)
        {
            string func = "error";

            switch (severityLevel)
            {
                case SeverityLevel.Information:
                    func = "information"; 
                    break;
                
                case SeverityLevel.Warning:
                    func = "warning"; 
                    break;
                
                case SeverityLevel.Error:
                    func = "error"; 
                    break;
                
                case SeverityLevel.Fatal:
                    func = "fatal"; 
                    break;
            }

            StringBuilder logic = new StringBuilder();
            if (antecedent == "")
            {
                if (consequent == "")
                    logic.Append("true");
                else
                    logic.Append("!(").Append(consequent).Append(")");
            }
            else
            {
                if (consequent == "")
                    logic.Append(antecedent);
                else
                    logic.Append("(").Append(antecedent).Append(") && !(").Append(consequent).Append(")");
            }


            string business_rule = string.Format("if ({0}) {1}(\"{2}\",\"{3}\");", logic, func, trace, message);

            return business_rule;
        }

 


    }
}

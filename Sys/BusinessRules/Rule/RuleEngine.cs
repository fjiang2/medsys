using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using System.Windows.Forms;
using System.Reflection;

namespace Sys.BusinessRules
{

    public class RuleEngine  
    {
        private static RuleEngine engine= null;
        
        private RuleFunction ruleFunction;
        private RuleCollection rules;

        private RuleEngine()
        {
            this.ruleFunction = new RuleFunction();
            this.rules = null;
        }

        public static RuleEngine Instance
        {
            get
            {
                if (engine == null)
                    engine = new RuleEngine();

                return engine;
            }
        }

        public void ReadRules(int workflowInstanceID, string workflowName, string stateName)
        {
            rules = new RuleCollection(workflowName, workflowInstanceID, stateName);
        }

        public void ReadRules(string stateName)
        {
            rules = new RuleCollection("System.Windows.Forms.Form", -1, stateName);
        }


        internal bool CheckRules(string scope, Memory fact, Dictionary<string,RuleEvent> brokenRules)
        {
            if (rules == null)
                throw new ApplicationException("Business rules are not loaded");

            bool passed = true;
            foreach(Rule rule in rules)
            {
                if(! rule.CheckRule(scope, fact, ruleFunction,  brokenRules))
                    passed = false;
            }
            return passed;
        }



    }

}

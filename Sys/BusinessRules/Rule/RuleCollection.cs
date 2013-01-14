using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using Sys.Data;
using Sys.BusinessRules.DpoClass;

namespace Sys.BusinessRules
{

    class RuleCollection : IEnumerable<Rule>, IEnumerable
    {
        string workflowName;
        int workflowInstanceID;
        string stateName;

        List<Rule> rules;

        public RuleCollection(string workflowName,  int workflowInstanceID, string stateName)
        {
            rules = new List<Rule>();
            this.workflowName = workflowName;
            this.workflowInstanceID = workflowInstanceID;
            this.stateName = stateName;

            ReadRules();
        }

        private void ReadRules()
        {
            string andStateName = "";
            if (stateName != "")
                andStateName = string.Format(" AND State_Name='{0}'", stateName);

            string andException = "";
            if (workflowInstanceID != -1)
                andException = string.Format(" AND NOT(Error_Code IN (SELECT Error_Code FROM {0} WHERE WorkflowInstance_ID = {1}))",
                    RuleExceptionDpo.TABLE_NAME,
                    workflowInstanceID);

            string SQL = @"
                SELECT * 
                FROM {0} 
                WHERE Workflow_Name = '{1}' 
                    AND Released = 1
                    {2} 
                    {3} 
                ";

            TableName tableName = typeof(RuleDpo).TableName();
            DataTable dt = SqlCmd.FillDataTable(tableName.Provider, SQL, tableName.FullName, workflowName, andStateName, andException);


            foreach (DataRow row in dt.Rows)
            {
                RuleDpo dpo = new RuleDpo(row);
                Rule rule = new Rule(dpo);
                rules.Add(rule);
            }

            return;
        }

        public IEnumerator<Rule> GetEnumerator()
        {
            return rules.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return rules.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return rules.Count;
            }
        }


        public Rule this[int index]
        {
            get
            {
                return rules[index];
            }
        }

    
    }
}

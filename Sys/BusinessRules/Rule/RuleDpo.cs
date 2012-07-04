using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.BusinessRules.Dpo;
using Sys.DataManager;

namespace Sys.BusinessRules
{
    internal class RuleDpo : SysRuleDpo, IRule
    {
        public RuleDpo()
        {
            this.Released = false;
            this.Creator = Active.Account.UserID;
            this.Date_Created = DateTime.Now;
         
        }

        public RuleDpo(DataRow dataRow)
            :base(dataRow)
        {
        }

        public override DataRow Save()
        {
            this.Modifier = Active.Account.UserID;
            this.Date_Modified = DateTime.Now;

            return base.Save();
        }



        public int ErrorCode
        {
            get
            {
                return this.Error_Code;
            }
        }

        public string RuleDescription
        {
            get
            {
                return this.Label;
            }
        }

        public string RuleScript
        {
            get
            {
                return this.Business_Rule;
            }
        }

        public SeverityLevel SeverityLevel
        {
            get { return (SeverityLevel)this.Severity_Level; }
            set { this.Severity_Level = (int)value; }
        }


        public override string ToString()
        {
            return string.Format("RULE[{0}] {1}", this.Error_Code, this.Label);
        }
    }
}

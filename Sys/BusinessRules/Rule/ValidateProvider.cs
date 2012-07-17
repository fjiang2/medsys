using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Tie;
using System.Text.RegularExpressions;
using System.Data;
using Sys;

namespace Sys.BusinessRules
{
    public class ValidateProvider
    {
        ErrorProvider errorProvider;
        ToolTip toolTip;

        List<Validator> validators = new List<Validator>();
       

        internal ValidateProvider(Form form, ToolTip toolTip, ErrorProvider errorProvider)
        {
            this.errorProvider = errorProvider;
            this.toolTip = toolTip;
        }

        internal void DisplayMessage(RuleEvent ruleEvent, Control control)
        {
            WinFormEngine.ApplyControl(ruleEvent, errorProvider, control);
            WinFormEngine.ApplyControl(ruleEvent, toolTip, control);
        }

        #region Display Message On Controls
        
        private Dictionary<Control, RuleEvent> messages = new Dictionary<Control, RuleEvent>();
        
        public void DisplayMessageOn(Control control, string message)
        {
            RuleEvent ruleEvent = new RuleEvent(control.Name, MessageLevel.Error, message);
            ruleEvent.OriginalColor = control.BackColor;
            DisplayMessage(ruleEvent, control);
            messages.Add(control, ruleEvent);
        }
        
        public void ClearMessageOn(Control control)
        {
            if (messages.ContainsKey(control))
            {
                RuleEvent ruleEvent = messages[control];
                DisplayMessage(ruleEvent, control);
                messages.Remove(control);
            }
        }

        #endregion


        /// <summary>
        /// ValidationHandler fired during ValidateProvider.Passed invoked
        /// must use validator.error(control, "message"), cannot use validator.error("message"); becuase no contorl defined.
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        public Validator Add(ValidationHandler handler)
        {
            Validator validator = Validator.Add(this, null, handler);
            validators.Add(validator);
            return validator;
        }

        /// <summary>
        /// ValidationHandler fired during ValidateProvider.Passed invoked
        /// </summary>
        /// <param name="control"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public Validator Add(Control control, ValidationHandler handler)
        {
            Validator validator = Validator.Add(this, control, handler);
            validators.Add(validator);
            return validator;
        }

        /// <summary>
        /// ValidationEventHandler fired during event triggered
        /// </summary>
        /// <param name="control"></param>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public Validator Add(Control control, string eventName, ValidationEventHandler handler)
        {
            Validator validator = Validator.Add(this, control, eventName, handler);
            validators.Add(validator);
            return validator;
        }

        public Validator Add(Control control, string eventName, string script, Memory memory)
        {
            Validator validator = Validator.Add(this, control, eventName, script, memory);
            validators.Add(validator);
            return validator;
        }

        internal Validator Add(Validator validator)
        {
            validators.Add(validator);
            return validator;
        }

        /// <summary>
        /// Validate all ValidationHandler, and return 
        /// </summary>
        public bool passed = false;
        public bool Passed 
        { 
            get 
            { 
                return this.passed; 
            } 
        }

        public bool Validate()
        {
            foreach (Validator validator in validators)
                validator.Validate();

            foreach (Validator validator in validators)
            {
                if (!validator.Passed)
                    return passed = false;
            }
            return passed = true;
        }
        

        public void SetError(Control control, string message)
        {
            this.errorProvider.SetError(control, message);
        }

        internal void SetIconAlignment(Control control, ErrorIconAlignment value)
        {
            this.errorProvider.SetIconAlignment(control, value);
        }

        internal void SetIconPadding(Control control, int padding)
        {
            this.errorProvider.SetIconPadding(control, padding);
        }

        /// <summary>
        /// Search errorCode
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="severityLevel"></param>
        /// <returns></returns>
        public bool Exist(int errorCode, MessageLevel severityLevel)
        {
            foreach (Validator validator in validators)
            {
                RuleEvent ruleEvent = validator.Search(errorCode);
                if (ruleEvent != null && ruleEvent.MessageLevel == severityLevel)
                {
                    return true;
                }
            }

            return false;
        }

        private List<RuleEvent> BrokenRules
        {
            get
            {
                List<RuleEvent> rules = new List<RuleEvent>();
                foreach (Validator validator in validators)
                {
                    validator.BrokenRules(rules);
                }

                return rules;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (RuleEvent ruleEvent in BrokenRules)
            {
                sb.Append(ruleEvent.ToString()).Append("\r\n");
            }
            
            return sb.ToString();
        }

        /// <summary>
        /// Convert Broken rules into DatTable format
        /// </summary>
        /// <returns></returns>
        public DataTable ToDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("NO", typeof(int));
            dt.Columns.Add("Code", typeof(int));
            dt.Columns.Add("Severity", typeof(string));
#if DEBUG
            dt.Columns.Add("Place", typeof(string));
#endif
            dt.Columns.Add("Message", typeof(string));

            DataRow row;
            int i = 0;
            foreach (RuleEvent ruleEvent in BrokenRules)
            {
                row = dt.NewRow();
                row["NO"] = ++i;
                
                if(ruleEvent.ErrorCode != -1 )
                    row["Code"] = ruleEvent.ErrorCode;
#if DEBUG
                row["Place"] = ruleEvent.keyName;
#endif                
                row["Severity"] = ruleEvent.MessageLevel.ToString();
                row["Message"] = ruleEvent.Message;
                dt.Rows.Add(row);
            }

            return dt;
        }

        public IEnumerable<Message> ToMessageList()
        {
            List<Message> list = new List<Message>();
            foreach (RuleEvent ruleEvent in BrokenRules)
            { 
                Message message = new Message(MessageLevel.None, ruleEvent.Message);
                
                if(ruleEvent.ErrorCode != -1 )
                    message.Code = ruleEvent.ErrorCode;
                
                message.Level = ruleEvent.MessageLevel;
#if DEBUG
                message.Location =  ruleEvent.keyName;
#endif                
                list.Add(message);
            }

            return list;
        }
    }
}

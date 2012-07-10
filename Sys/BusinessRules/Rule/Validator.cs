using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Tie;
using System.Text.RegularExpressions;


namespace Sys.BusinessRules
{
    public delegate void ValidationEventHandler(Validator validator, object sender, EventArgs e);
    public delegate void ValidationHandler(Validator validator, object sender);

    public class Validator
    {
        private ValidateProvider provider;
        private Control control;

        string eventName="";
        object what;

        Dictionary<Control, RuleEvent> ruleEvents;
        Memory DS;

        bool attached = false;  //attach to another Validator;

        private Validator(Validator validator, object handler)
        {
            this.ruleEvents = validator.ruleEvents;
            this.provider = validator.provider;
            this.control = validator.control;
            this.what = handler;
            this.attached = true;
           
        }

        public Validator Add(ValidationHandler handler)
        {
            Validator x =  new Validator(this, handler);
            this.provider.Add(x);
            return x;
        }

        public Validator Add(string eventName, ValidationEventHandler handler)
        {
            Validator x = new Validator(this, handler);
            x.Init(eventName, handler);
            
            this.provider.Add(x);
            return x;
        }


        public Validator Add(string eventName, string script, Memory memory)
        {
            Validator x = new Validator(this, script);
            x.Init(eventName, script);
            x.DS = memory;
            
            this.provider.Add(x);
            return x;
     
        }



        private Validator(ValidateProvider provider, Control control, object what)
        {
            this.ruleEvents = new Dictionary<Control, RuleEvent>();
            this.provider = provider;
            this.control = control;
            this.what = what;
        }


        internal static Validator Add(ValidateProvider provider, Control control, ValidationHandler handler)
        {
            Validator x = new Validator(provider, control, handler);
            return x;
        }


        internal static Validator Add(ValidateProvider provider, Control control, string eventName, ValidationEventHandler handler)
        {
            Validator x = new Validator(provider, control, handler);
            x.Init(eventName, handler);
            return x;
        }

        internal static Validator Add(ValidateProvider provider, Control control, string eventName, string script, Memory memory)
        {
            Validator x = new Validator(provider, control, script);
            x.Init(eventName, script);
            x.DS = memory;
            return x;
        }


       


        private void Init(string eventName, object what)
        {
            this.eventName = eventName;

            Type type = control.GetType();
            EventInfo eventInfo = type.GetEvent(eventName);
            if (eventInfo == null)
                throw new Exception(string.Format("event {0} does not exist in the control {1}.",eventName, control));


            string funcName;
            if (what is ValidationEventHandler)
                funcName = "Callback1";
            else
                funcName = "Callback2";

            MethodInfo methodInfo = this.GetType().GetMethod(funcName, BindingFlags.NonPublic | BindingFlags.Instance);

            Delegate d = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, methodInfo);
            eventInfo.AddEventHandler(control, d);

        }


        private void Callback1(object sender, EventArgs e)
        {
            this.clearRuleEvents();

            ((ValidationEventHandler)what)(this, sender, e);
            
            foreach(KeyValuePair<Control,RuleEvent> kvp in ruleEvents)
                this.provider.DisplayMessage(kvp.Value, kvp.Key);
        }




        /**
         *    validateProvider.Add(textBox2, "TextChanged", @"
              delegate(validator, sender, e)
              {
                if (!Regex.IsMatch(sender.Text, patternZip))
                    validator.error('Zip code must be 5 digits');
              }  
            ", DS);
         * 
         * */
        private void Callback2(object sender, EventArgs e)
        {
            this.clearRuleEvents();

            DS.Add("$ActiveValidator", VAL.NewHostType(this));
            DS.Add("$THIS", VAL.NewHostType(this.control));
            DS.Add("sender", VAL.NewHostType(sender));
            DS.Add("e", VAL.NewHostType(e));
            string code = string.Format("{0}($ActiveValidator, sender, e)", (string)what);
            Script.Evaluate("$THIS", code, DS, new ValidatorFunction());

            foreach (KeyValuePair<Control, RuleEvent> kvp in ruleEvents)
                this.provider.DisplayMessage(kvp.Value, kvp.Key);

        }

        internal void Add(Control control, RuleEvent ruleEvent)
        {
            if (ruleEvents.ContainsKey(control))
            {
                RuleEvent r = ruleEvents[control];
                r.Update(ruleEvent);
                
                return;
            }

            ruleEvents.Add(control, ruleEvent);
            ruleEvent.OriginalColor = control.BackColor;
        }

        private void clearRuleEvents()
        {
            foreach (Control control in ruleEvents.Keys)
                clear(control);

        }

        public void clear(Control control)
        {
            if (ruleEvents.ContainsKey(control))
                ruleEvents[control].Clear();
        }

        public void error(Control control, string message)
        {
            RuleEvent ruleEvent = new RuleEvent(control.Name, SeverityLevel.Error, message);
            Add(control, ruleEvent);
        }
        
        public void error(Control[] controls, string message)
        {
            foreach (Control control in controls)
                error(control, message);
        }

        public void error(Control control, int errorCode, string message)
        {
            RuleEvent ruleEvent = new RuleEvent(errorCode, control.Name, SeverityLevel.Error, message);
            Add(control, ruleEvent);
        }

        public void warning(Control control, string message)
        {
            RuleEvent ruleEvent = new RuleEvent(control.Name, SeverityLevel.Warning, message);
            Add(control, ruleEvent);
        }

        public void fatal(Control control, string message)
        {
            RuleEvent ruleEvent = new RuleEvent(control.Name, SeverityLevel.Fatal, message);
            Add(control, ruleEvent);
        }
        
        public void information(Control control, string message)
        {
            RuleEvent ruleEvent = new RuleEvent(control.Name, SeverityLevel.Information, message);
            Add(control, ruleEvent);
        }
        
        public void confirm(Control control, int errorCode, string message)
        {
            RuleEvent ruleEvent = new RuleEvent(errorCode, control.Name, SeverityLevel.Confirmation, message);
            Add(control, ruleEvent);
        }
        
        public void confirm(Control control, string message)
        {
            RuleEvent ruleEvent = new RuleEvent(control.Name, SeverityLevel.Confirmation, message);
            Add(control, ruleEvent);
        }

        public void clear()
        {
            clear(this.control);
        }

        public void error(string message)
        {
            error(control, message);
        }

        public void error(int errorCode, string message)
        {
            error(control, errorCode, message);
        }

        public void warning(string message)
        {
            warning(control, message);
        }

        public void fatal(string message)
        {
            fatal(control, message);
        }

        public void information(string message)
        {
            information(control, message);
        }

        public void confirm(string message)
        {
            confirm(control, message);
        }

        public void confirm(int errorCode, string message)
        {
            confirm(control, errorCode, message);
        }

        internal bool Validate()
        {
            if (this.what is ValidationHandler)
            {
                this.clearRuleEvents();

                ((ValidationHandler)what)(this, this.control);

                foreach (KeyValuePair<Control, RuleEvent> kvp in ruleEvents)
                    this.provider.DisplayMessage(kvp.Value, kvp.Key);

                return true;
            }
            
            return false;
        }

        public bool Passed
        {
            get
            {
                foreach (RuleEvent ruleEvent in ruleEvents.Values)
                {
                    if (!ruleEvent.Passed)
                        return false;
                }


                return true;
            }
        }

        internal void BrokenRules(List<RuleEvent> rules)
        {
            if (this.attached)
                return;

            foreach (RuleEvent ruleEvent in ruleEvents.Values)
            {
                if (ruleEvent.SeverityLevel != SeverityLevel.None)
                    rules.Add(ruleEvent);
            }

        }

        internal RuleEvent Search(int errorCode)
        {
            foreach (RuleEvent ruleEvent in ruleEvents.Values)
            {
                if (ruleEvent.ErrorCode == errorCode)
                    return ruleEvent;
            }

            return null;
        }

        public ErrorIconAlignment Alignment
        {
            set
            {
                this.provider.SetIconAlignment(control, value);
            }
        }

        public int Padding
        {
            set
            {
                this.provider.SetIconPadding(control, value);
            }
        }

        public override string ToString()
        {
             return string.Format("{0} event={1} #rules={2}", this.control, eventName, ruleEvents.Count);
        }
    }
}

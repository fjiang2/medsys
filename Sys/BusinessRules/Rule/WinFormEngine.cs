using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using Tie;

namespace Sys.BusinessRules
{
    public class WinFormEngine
    {
        RuleEngine engine1;
        ValidateProvider engine2;
        
        private Form form;
        private ToolTip toolTip = null;
        private ErrorProvider errorProvider = null;

        public WinFormEngine(Form form)
            :this(form, null, null)
        {
        }


        public WinFormEngine(Form form, ToolTip toolTip, ErrorProvider errorProvider)
        {
            this.form = form;

            if (toolTip != null)
                this.toolTip = toolTip;
            else
                this.toolTip = GetToolTip(form);

            if (errorProvider != null)
                this.errorProvider = errorProvider;
            else
                this.errorProvider = GetErrorProvider(form);

            this.engine1 = RuleEngine.Instance;
            this.engine2 = new ValidateProvider(form, this.toolTip, this.errorProvider);
        }


        public ValidateProvider ValidatorProvider
        {
            get
            {
                return this.engine2;
            }
        }

        public RuleEngine RuleEngine
        {
            get
            {
                return this.engine1;
            }
        }


        #region Apply/Clear Control
        internal static void ApplyControl(RuleEvent ruleEvent, ToolTip toolTip, Control control)
        {
            if (ruleEvent.SeverityLevel != SeverityLevel.None)
            {
                control.BackColor = ruleEvent.ErrorColor;
                toolTip.SetToolTip(control, ruleEvent.ToString());
            }
            else
                ClearControl(ruleEvent, toolTip, control);
        }

        
        internal static void ClearControl(RuleEvent ruleEvent, ToolTip toolTip, Control control)
        {
            control.BackColor = ruleEvent.OriginalColor;
            toolTip.SetToolTip(control, "");
        }

        internal static void ClearControl(ToolTip toolTip, Control control)
        {
            control.BackColor = System.Drawing.SystemColors.Control;
            toolTip.SetToolTip(control, "");
        }

        internal static void ApplyControl(RuleEvent ruleEvent, ErrorProvider errorProvider, Control control)
        {
            if (ruleEvent.SeverityLevel == SeverityLevel.Confirmation && !ruleEvent.Confirmed)
            {
                ruleEvent.Confirmed = DialogResult.Yes == MessageBox.Show(ruleEvent.ToString(), "Ignore the error and continue ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            }
            
            if (!ruleEvent.Passed)
            {
                errorProvider.SetError(control, ruleEvent.ToString());
            }
            else
                ClearControl(errorProvider, control);
        }

        internal static void ClearControl(ErrorProvider errorProvider, Control control)
        {
            
            errorProvider.SetError(control, "");
            errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(control, 0); 
 
        }

        //internal static void ApplyControl(ErrorProvider errorProvider, Control control, string message)
        //{
        //    if (message != "" && message != null)
        //    {
        //        errorProvider.SetError(control, message);
        //    }
        //    else
        //        ClearControl(errorProvider, control);
        //}

        #endregion


        #region Generate ToolTip and ErrorProvider

        public static ToolTip GetToolTip(Form form)
        {
            Type type = form.GetType();

            ToolTip toolTip = null;
            
            //search ToolTip and ErrorProvider
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.FieldType == typeof(ToolTip))
                {
                    toolTip = (ToolTip)fieldInfo.GetValue(form);
                    break;
                }
            }

            //ToolTip is not defined in form, then add new ToolTip
            if (toolTip == null)
            {
                FieldInfo fieldInfo = type.GetField("components", BindingFlags.Instance | BindingFlags.NonPublic);
                System.ComponentModel.IContainer components = (System.ComponentModel.IContainer)fieldInfo.GetValue(form);
                if (components == null)
                    components = new System.ComponentModel.Container();
                toolTip = new System.Windows.Forms.ToolTip(components);
            }

            return toolTip;
        }

        public static ErrorProvider GetErrorProvider(Form form)
        {
            Type type = form.GetType();

            ErrorProvider errorProvider = null;

            //search ToolTip and ErrorProvider
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.FieldType == typeof(ErrorProvider))
                {
                    errorProvider = (ErrorProvider)fieldInfo.GetValue(form);
                    break;
                }
            }

            if (errorProvider == null)
            {
                FieldInfo fieldInfo = type.GetField("components", BindingFlags.Instance | BindingFlags.NonPublic);
                System.ComponentModel.IContainer components = (System.ComponentModel.IContainer)fieldInfo.GetValue(form);
                if (components == null)
                    components = new System.ComponentModel.Container();
                errorProvider = new System.Windows.Forms.ErrorProvider(components);
            }
            return errorProvider;
        }
        
        #endregion

        internal void ApplyRules(Dictionary<string, RuleEvent> brokenRules)
        {
            toolTip.ToolTipTitle = "Business Rule Checking:";
            foreach (Control control in form.Controls)
            {
                if (brokenRules.ContainsKey(control.Name))
                {
                    RuleEvent ruleEvent = brokenRules[control.Name];
                    ApplyControl(ruleEvent, toolTip, control);
                    ApplyControl(ruleEvent, errorProvider, control);
                }
                else
                {
                    ClearControl(toolTip, control);
                    ClearControl(errorProvider, control);
                }
            }

        }


        public bool ApplyForm()
        {
            Type type = form.GetType();

            //read rules from SQL Server
            engine1.ReadRules(type.FullName);

            Memory facts = new Memory();
            Script.SyncInstance(facts, form, false);

            //extract facts from Windows Form
            string scope = "";
            Dictionary<string, RuleEvent> brokenRules = new Dictionary<string, RuleEvent>();
            engine1.CheckRules(scope, facts, brokenRules);
            ApplyRules(brokenRules);


            //if want to change value of windows form
            Script.SyncInstance(facts, form, true);


            return brokenRules.Count == 0;
        }
    }
}

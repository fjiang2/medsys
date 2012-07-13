using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tie;
using Sys.Xmpp;
using Sys.BusinessRules;
using Sys.ViewManager.Manager;
using Sys.Security;
using Sys.Data.Manager;

namespace Sys.ViewManager.Forms
{

    public partial class BaseUserControl : UserControl, IRuleDefinition
    {
        protected Account account = Account.CurrentUser;
        protected ValidateProvider validateProvider;

        protected BaseForm form;

        public BaseUserControl()
        {
        
        }

        public BaseUserControl(BaseForm form)
            :this()
        {
            this.form = form;
            this.validateProvider = form.ValidateProvider;
            this.state = form.WorkMode;
        }

        public virtual void Connect(BaseForm form)
        {
           this.form = form;
           this.validateProvider = form.ValidateProvider;
           this.state = form.WorkMode;
        }

        private ContainerControl owner = null;
        public ContainerControl ParentControl
        {
            get { return owner; }
            set { owner = value; }
        }

        protected void ShowMessageOn(Control control, string message)
        {
            if (message != "" && message != null)
                this.validateProvider.DisplayMessageOn(control, message);
            else
                this.validateProvider.ClearMessageOn(control);
        }


        WorkMode state = WorkMode.Working;
        public WorkMode WorkMode
        {
            get { return this.state; }
            set
            {
                if (state == value)
                    return;

                this.state = value;

                Editable(state);
            }

        }

        protected virtual void Editable(WorkMode state)
        {
            switch (state)
            {
                case WorkMode.Reading:
                case WorkMode.Reviewing:
                    BaseForm.EnableControls(this.Controls, false);
                    break;

                case WorkMode.Working:
                    BaseForm.EnableControls(this.Controls, true);
                    break;
            }

        }

      


        public virtual void RuleDefinition(ValidateProvider provider)
        {
        }


        #region Log

        protected LogTransaction BeginLog()
        {
            if (form.logTransaction == null)
                form.logTransaction = LogTransaction.BeginTransaction(new TransactionType(form.GetType()));

            return form.logTransaction;
        }

        protected LogTransaction BeginLog(TransactionLogeeType typeName)
        {
            if( form.logTransaction == null)
                form.logTransaction = LogTransaction.BeginTransaction(typeName, new TransactionType(form.GetType()));

            return form.logTransaction;
        }

        protected void BeginLog(params ILogable[] logs)
        {
            BeginLog();
            foreach (ILogable log in logs)
                AddLog(log);
        }

        protected void AddLog(ILogable log)
        {
            form.logTransaction.Add(log);
        }

        protected void RemoveLog(ILogable log)
        {
            form.logTransaction.Remove(log);
        }

        protected void EndLog()
        {
            form.logTransaction.EndTransaction();
            form.logTransaction = null;
        }

        #endregion

    }
}

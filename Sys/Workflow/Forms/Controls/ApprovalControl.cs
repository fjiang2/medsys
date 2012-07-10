using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tie;
using Sys.Workflow.Collaborative;
using Sys.ViewManager.Forms;
using Sys.ViewManager.Utils;
using Sys.BusinessRules;
using Sys.Security;

namespace Sys.Workflow.Forms
{
    public partial class ApprovalControl : ActivityUserControl
    {
        public const string CONTEXT_REASON = "ApprovalReason";

        protected ActivityResult approvalResult = ActivityResult.None;

        public ApprovalControl()
        {
            InitializeComponent();

            this.tbUserName.Text = account.UserName;
            this.txtFullName.Text = account.FullName;


     
            this.tbUserName.ReadOnly = true;
        }

        public ApprovalControl(string approvalStateName)
            : this()
        {
            this.approvalStateName = approvalStateName;
        }

        public ActivityResult ApprovalResult
        {
            get
            {
                return this.approvalResult;
            }
        }


        private void ApprovalControl_Load(object sender, EventArgs e)
        {
         
            string reason = "";

            if (LoadResult(ref reason))
            {

                this.txtReason.Text = reason;

                if (approvalResult == ActivityResult.Approved)
                {
                    radioApprove.BackColor = Color.Green;
                    radioApprove.Checked = true;
                }
                else if (approvalResult == ActivityResult.Disputed)
                {
                    radioDispute.BackColor = Color.Green;
                    radioDispute.Checked = true;
                }
                else if (approvalResult == ActivityResult.Rejected)
                {
                    radioReject.BackColor = Color.Green;
                    radioReject.Checked = true;
                }

            }

            this.radioApprove.CheckedChanged += new EventHandler(button_Clicked);
            this.radioDispute.CheckedChanged += new EventHandler(button_Clicked);
            this.radioReject.CheckedChanged += new EventHandler(button_Clicked);

         }

        protected virtual bool LoadResult(ref string reason)
        {
            if (activity == null)
                return false;

            approvalResult = activity.Data.ActivityResult;

            if (activity.Context[CONTEXT_REASON].Defined)
            {
                reason = activity.Context[CONTEXT_REASON].Str;
            }
            else
                reason = "";

            return true;
        }

        public string Label
        {
            get
            {
                return this.linkTitle.Text;
            }
            set
            {
                this.linkTitle.Text = value;
            }
        }

        public LinkLabel LinkTitle { get { return this.linkTitle; } }

        public RichTextBox Description
        {
            get
            {
                return this.txtDescription;
            }
        }

        public override bool DataSave()
        {
            //if (!this.validateProvider.Passed)
            //    return false;
         
            SaveResult(this.txtReason.Text);
            return true;
        }

        public string Reason
        {
            get
            {
                return this.txtReason.Text;
            }
            set
            {
                this.txtReason.Text = value;
            }
        }

        private string approvalStateName = null;

        protected virtual void SaveResult(string reason)
        {
            activity.Data.ActivityResult = approvalResult;
            this.activity.Context[CONTEXT_REASON] = new VAL(reason);

            if (reason == "")
                return;

            if (this.approvalStateName == null)
                throw new ApplicationException("illegal approval state.");

            NoteDpo noteDpo = new NoteDpo(activity, approvalStateName);
            noteDpo.Comment = "Reason:\r\n" + reason;
            noteDpo.Save();
        }


        void button_Clicked(object sender, EventArgs e)
        {
           if(this.activity == null)
               return ;
           
            string text = ((RadioButton)sender).Text;

            if (this.tbUserName.Text != account.UserName)
            {
                VerifyPassword form = new VerifyPassword();
                form.UserName = this.tbUserName.Text;
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            switch (text)
            {
                case "Approve":
                    approvalResult = ActivityResult.Approved;
                    break;

                case "Dispute":
                    approvalResult = ActivityResult.Disputed;
                    break;

                case "Reject":
                    approvalResult = ActivityResult.Rejected;
                   break;
            }

        
            //if (Changed != null)
            //{
            //   Changed(this, new ActivityEventArgs(activity.Data.ActivityResult));
            //}

        }

        public override void RuleDefinition(ValidateProvider provider)
        {
            this.txtReason.Validate(provider, delegate(Validator validator, object sender, EventArgs e)
            {
                if (txtReason.Text == "" && (radioDispute.Checked || radioReject.Checked))
                {
                    //                    validator.Padding = 30;     //don't overlap SEARCH button
                    validator.error("You must enter a dispution or rejecttion reason.");
                    return;
                }
            });

            this.tbUserName.Validate(provider, delegate(Validator validator, object sender, EventArgs e)
            {
                if (tbUserName.Text == "")
                {
                    validator.error("Employee id cannot be blank");
                    return;
                }
                
                UserAccount user = new UserAccount( this.tbUserName.Text);
                if (!user.Exists)
                    validator.error("Invalid employee id");

                 return;
            });


            this.grpAction.Validate(provider, delegate(Validator validator, object sender)
            {
                if(!radioApprove.Checked && !radioDispute.Checked  && !radioReject.Checked)
                {
                    validator.error("Must choose either Approve, Dispute or Reject");
                    return;
                }
            });


        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
        }


        private void tbUserName_Leave(object sender, EventArgs e)
        {

          
        }
     
    }
}

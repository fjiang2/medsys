using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.DataManager;
using Sys.ViewManager;
using Sys.BusinessRules;
using Sys.Data;
using Sys.Workflow.Forms;
using Sys.Workflow;

namespace Sys.Platform.Forms
{
    public partial class DpoApprovalControl : ApprovalControl
    {
        private IApproval approval;

        public DpoApprovalControl()
        {
            InitializeComponent();
        }

        public DpoApprovalControl(string approvalStateName)
            :base(approvalStateName)
        {
            InitializeComponent();
        }

        public IApproval Approval
        {
            get
            { 
                return this.approval;
            }
            set
            {
                this.approval = value;
            }
        }


        protected override bool LoadResult(ref string reason)
        {
            if (approval.ApprovalAction == ApprovalAction.None)
                return false;

            switch (approval.ApprovalAction)
            {
                case ApprovalAction.Approved:
                    approvalResult = ActivityResult.Approved;
                    break;

                case ApprovalAction.Rejected:
                    approvalResult = ActivityResult.Rejected;
                    break;

                case ApprovalAction.Disputed:
                    approvalResult = ActivityResult.Disputed;
                    break;
            }

           // reason = approval.History;

            return true;
        }

        protected override void SaveResult(string reason)
        {
            switch (approvalResult)
            {
                case ActivityResult.Approved:
                    this.approval.Approve();
                    break;

                case ActivityResult.Rejected:
                    this.approval.Reject(reason);
                    break;

                case ActivityResult.Disputed:
                    this.approval.Dispute(reason);
                    break;
            }

            
        }


        public override bool DataSave()
        {
            if (!base.DataSave())
                return false;
            
            this.approval.SaveApproval(); 
            return true;
        }


        public static ActivityResult GetApprovalResult(Control.ControlCollection controls)
        {

            int A = 0;
            int D = 0;
            int R = 0;
            int n = 0;
            foreach (Control control in controls)
            {
                if (control is DpoApprovalControl)
                {
                    DpoApprovalControl approvalControl = (DpoApprovalControl)control;
                    n++;

                    switch (approvalControl.ApprovalResult)
                    {
                        case ActivityResult.Approved:
                            A++;
                            break;

                        case ActivityResult.Disputed:
                            D++;
                            break;

                        case ActivityResult.Rejected:
                            R++;
                            break;
                    }
                }
            }

            if (A == n)
                return ActivityResult.Approved;
            else if (R == n)
                return ActivityResult.Rejected;
            else
                return ActivityResult.Disputed;
        }

    }
}

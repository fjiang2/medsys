using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tie;

namespace Sys.Workflow.Forms
{
    public partial class ActivityForm : ActivityWinForm 
    {
        public ActivityForm(string stateName)
        {
            InitializeComponent();

            tbStateId.Text = stateName;

            //validation.Add(tbStateId, "TextChanged", delegate(Control control, object sender, EventArgs e)
            //{
            //    return ((TextBox)control).Text != "";
            //}, "Requred");
        }


        public bool Yes
        {
            get { return this.chkBranch.Checked; }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            this.CompleteActivity();
        }

        private void btnNotify_Click(object sender, EventArgs e)
        {
            this.activity.NotifyListeners(string.Format("Activity {0} is completed at {1}", this.activity, DateTime.Now)); 
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            this.activity.ListenTo(this.tbListenedState.Text); 
        }

        public override void UpdateWorkflowContext(VAL workflowContext, VAL activityContext)
        {
            workflowContext["Yes"] = new VAL(this.chkBranch.Checked);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Workflow.Collaborative;
using Tie;

namespace Sys.Workflow.Forms
{

    public partial class FeedbackUserControl : ActivityUserControl
    {
        public event ActivityEventHandler Completed;

        private NoteDpo noteDpo;
        private bool reviewMode = true;


        public FeedbackUserControl()
        {
            InitializeComponent();
        }

        private void FeedbackUserControl_Load(object sender, EventArgs e)
        {
            this.cbReopen.Visible = false;
            this.btnSend.Enabled = false;
        }

        public bool ReviewMode
        {
            get
            {
                return this.reviewMode;
            }
            set
            {
                if( this.reviewMode == value)
                    return;

                this.reviewMode = value;
                this.cbReopen.Visible = value;

                if (activity == null)
                    return;

                this.dudStates.Items.Clear();
                AddConnectedStates(this.activity);
            }
        }

        public void LoadHistory()
        {
            AddConnectedStates(activity);

            this.dudStates.SelectedIndex = 0;
            NoteDpo.LoadHistory(activity, this.tbHistory);

            this.tbHistory.SelectionStart = this.tbHistory.Text.Length;
            this.tbHistory.ScrollToCaret();
        }

        private void AddConnectedStates(CollaborativeActivity activity)
        {
            //add current state
            this.dudStates.Items.Add(new StateItem(activity.State, StateDirection.Selfbound));

            if (this.reviewMode)
            {
                foreach (State state in activity.State.PrevStates)
                {
                    //if(this.dudStates.Items.IndexOf(state.StateName) == -1)
                    this.dudStates.Items.Add(new StateItem(state, StateDirection.Inbound));
                }
            }


            foreach (State state in activity.State.NextStates)
            {
                //if (this.dudStates.Items.IndexOf(state.StateName) == -1)
                this.dudStates.Items.Add(new StateItem(state, StateDirection.Outbound));
            }
        }

        private StateItem SelectedStateItem
        {
            get
            {
                return (StateItem)this.dudStates.SelectedItem;
            }
        }

        private void AddNote()
        {
            AddNote("");
        }

        private void AddNote(string text)
        {
            if (this.dudStates.SelectedIndex == -1)
                return;

            this.noteDpo = new NoteDpo(activity, SelectedStateItem.StateName );
            this.noteDpo.Add(text + this.tbNote.Text, this.tbHistory);
            this.noteDpo.Save();

            this.tbNote.Text = "";

            this.tbHistory.SelectionStart = this.tbHistory.Text.Length;
            this.tbHistory.ScrollToCaret();
        }

        
        private void btnSend_Click(object sender, EventArgs e)
        {
            //must enter note
            if (this.tbNote.Text == "")
                return;

            if (this.cbReopen.Checked)
            {
                AddNote(string.Format("REOPEN [{0}]:\r\n ", this.SelectedStateItem.StateName));
                if (Completed != null)
                {
                    this.activity.Context[CollaborativeActivity.CONTEXT_TARGET_STATE] = new VAL(this.SelectedStateItem.StateName);
                    Completed(sender, new ActivityEventArgs(ActivityResult.Reopen, this.SelectedStateItem.StateName));
                }
            }
            else
                AddNote();
        }

        private void tbNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddNote(); 
                e.Handled = true;
            }
        }

     

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            this.tbHistory.Text = "";
            NoteDpo.LoadHistory(activity, this.tbHistory);

            this.tbHistory.SelectionStart = this.tbHistory.Text.Length;
            this.tbHistory.ScrollToCaret();
        }

        private void dudStates_SelectedItemChanged(object sender, EventArgs e)
        {
            if (this.dudStates.SelectedIndex == -1)
                return;

            switch (SelectedStateItem.Type)
            {
                case StateDirection.Inbound:
                    this.cbReopen.Visible = true;
                    this.cbReopen.Text = string.Format("Submit [{0}] and Reopen [{1}]", activity.State.StateName, SelectedStateItem.StateName);
                    this.lblAction.Text = "Response to";
                    break;

                case StateDirection.Outbound:
                    this.cbReopen.Visible = false;
                    this.lblAction.Text = "Notify to";
                    break;
                
                case StateDirection.Selfbound:
                    this.cbReopen.Visible = false;
                    this.lblAction.Text = "Write note";
                    break;
            }
        }

        private void tbNote_TextChanged(object sender, EventArgs e)
        {
            this.btnSend.Enabled = tbNote.Text != "";
        }

      

    }

    enum StateDirection
    { 
        Inbound,
        Outbound,
        Selfbound
    }

    class StateItem
    {
        private string text;
        private StateDirection type;

        public StateItem(State state, StateDirection type)
        {
            this.text = state.StateName;
            this.type = type;
        }

        public StateDirection Type
        {
            get
            {
                return this.type;
            }
        }

        public string StateName
        {
            get
            {
                return this.text;
            }
        }


        public override string ToString()
        {
            switch (type)
            {
                case StateDirection.Inbound:
                    return text + "->";

                case StateDirection.Outbound:
                    return "->" + text;

                case StateDirection.Selfbound:
                    return  "^" + text;
            }

            return "";
        }
    }

}

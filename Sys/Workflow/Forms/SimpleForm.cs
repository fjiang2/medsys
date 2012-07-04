using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;

namespace Sys.Workflow.Forms
{
    public partial class SimpleForm : ActivityWinForm
    {
        
        public SimpleForm()
        {
            InitializeComponent();
            Init();
        }

        public SimpleForm(CollaborativeActivity activity)
            : base(activity)
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
         
        }


        private void Form_Load(object sender, EventArgs e)
        {
            if (activity == null)
                return;

            this.toolStripLabelStateName.Text = activity.State.StateName;
            this.toolStripLabelStateName.ToolTipText = activity.State.Data.Title;

        }

        public void AddWorkControl(Control control)
        {
            if (control is ActivityUserControl)
                ((ActivityUserControl)control).Connect(this);

            this.Controls.Add(control);
        }


        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            DataSaveAsDraft();
        }

        private void toolStripButtonSubmit_Click(object sender, EventArgs e)
        {
            Submit();
        }

        private void toolStripButtonHistory_Click(object sender, EventArgs e)
        {
            DataHistory();
        }

        /// <summary>
        /// Button History is still enabled after Activity completed
        /// </summary>
        protected override void Editable(WorkMode state)
        {
            base.Editable(state);

            if (state == WorkMode.Reviewing || state == WorkMode.Reading)
            {
                toolStripButtonHistory.Enabled = true;
                toolStripButtonExit.Enabled = true;
            }
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            DataCancel();
            this.Close();
        }

        private void toolStripButtonValidate_Click(object sender, EventArgs e)
        {
            this.RuleValidated();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using Tie;

namespace Sys.Workflow.Forms
{
    public partial class CollectForm : ActivityWinForm
    {
        private SplitterPanel workPanel;
        public CollectForm()
        {
            InitializeComponent();
            Init();
        }

        public CollectForm(CollaborativeActivity activity)
            : base(activity)
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.workPanel = this.splitContainer1.Panel1;
            this.feedbackUserControl1.Connect(this);
            this.feedbackUserControl1.ReviewMode = false;
        }


        public double WorkPanelWidth
        {
            get
            {
                return splitContainer1.SplitterDistance*1.0 / this.Size.Width;
            }
            set
            {
                splitContainer1.SplitterDistance = (int)(this.Size.Width * value);
            }
        }

        private void CollectForm_Load(object sender, EventArgs e)
        {
            if (activity != null)
            {
                this.toolStripLabelStateName.Text = activity.State.StateName;
                this.toolStripLabelStateName.ToolTipText = activity.State.Data.Title;
            }

            if (workPanel.Controls.Count == 1)
                workPanel.Controls[0].Dock = DockStyle.Fill;

//            ResizePanel(workPanel);


            this.feedbackUserControl1.LoadHistory();
            
        }

        public void AddWorkControl(Control control)
        {
            if (control is ActivityUserControl)
                ((ActivityUserControl)control).Connect(this);

            workPanel.Controls.Add(control);
        }


        //public override bool DataSave()
        //{
        //    bool result = true;
        //    foreach (Control control in workPanel.Controls)
        //    {
        //        if (control is ActivityUserControl)
        //        {
        //            ActivityUserControl auc = (ActivityUserControl)control;
        //            if (!auc.DataSave())
        //                result = false;
        //        }
        //    }
            
        //    return result;
        //}

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


        protected override void Appearance(VAL p, bool saved)
        {
             base.Appearance(p, saved);

            //code below does not work properly, because Dockmanager will change WorkPanelWidth automatically

             if (saved)
             {
                 p["WorkPanelWidth"] = new VAL(WorkPanelWidth);
             }
             else
             {
                 if (p["WorkPanelWidth"].Defined)
                 {
                     WorkPanelWidth = p["WorkPanelWidth"].Doublecon;
                 }
             }
        }
    }
}

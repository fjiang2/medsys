using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms;
using System.Linq;
using Tie;

namespace Sys.Workflow.Forms
{
    public partial class ReviewForm : ActivityWinForm
    {
        private SplitterPanel reviewPanel;
        private SplitterPanel workPanel;
        private SplitterPanel feedbackPanel;

        public ReviewForm()
        {
            InitializeComponent();
            Init();
        }

        public ReviewForm(CollaborativeActivity activity)
            : base(activity)
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.feedbackUserControl1.Connect(this);

            this.reviewPanel = this.splitContainer2.Panel1;
            this.workPanel = this.splitContainer2.Panel2;
            this.feedbackPanel = this.splitContainer1.Panel2;
        }

        public double ReviewPanelHeight
        {
            get
            {
                return splitContainer2.SplitterDistance * 1.0 / this.Size.Height;
            }
            set
            {
                splitContainer2.SplitterDistance = (int)(this.Size.Height * value);
            }
        }

        public double ReviewPanelWidth
        {
            get
            {
                return splitContainer1.SplitterDistance * 1.0 / this.Size.Width;
            }
            set
            {
                splitContainer1.SplitterDistance = (int)(this.Size.Width * value);
            }
        }



        #region Form_Load/AddWorkControl/AddReviewControl

        private void ReviewForm_Load(object sender, EventArgs e)
        {
            this.toolStripLabelStateName.Text = activity.State.StateName;
            this.toolStripLabelStateName.ToolTipText = activity.State.Data.Title;

            if (reviewPanel.Controls.Count == 1)
                reviewPanel.Controls[0].Dock = DockStyle.Fill;

            if (workPanel.Controls.Count == 1)
                workPanel.Controls[0].Dock = DockStyle.Fill;

//            ResizePanel(reviewPanel);
//            ResizePanel(workPanel);


            this.feedbackUserControl1.LoadHistory();

            this.feedbackUserControl1.Completed += new ActivityEventHandler(feedbackUserControl1_Completed);

            

        }

        public void AddReviewControl(ActivityUserControl control)
        {
            int height = 0;
            foreach (Control c in reviewPanel.Controls)
            {
                height += c.Height;
            }

            control.Location = new Point(0, height);

            control.WorkMode = WorkMode.Reviewing;
            control.Connect(this);
            reviewPanel.Controls.Add(control);

            height += control.Height;
            //splitContainer2.SplitterDistance = height;
        }

        public void AddWorkControl(Control control)
        {
            int height = 0;
            foreach (Control c in workPanel.Controls)
            {
                height += c.Height;
            }

            control.Location = new Point(0, height);

            if (control is ActivityUserControl)
                ((ActivityUserControl)control).Connect(this);

            workPanel.Controls.Add(control);

            //height += control.Height;
            //workPanel.Height = height;
        }

        #endregion

        void feedbackUserControl1_Completed(object sender, ActivityEventArgs e)
        {
            activity.Data.ActivityResult = e.status;
            Submit();
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
            //activity.Data.ActivityResult = ActivityResult.None;
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

            if (saved)
            {
                p["ReviewPanelWidth"] = new VAL(ReviewPanelWidth);
                p["ReviewPanelHeight"] = new VAL(ReviewPanelHeight);
            }
            else
            {
                if (p["ReviewPanelWidth"].Defined)
                {
                    ReviewPanelWidth = p["ReviewPanelWidth"].Doublecon;
                }
                if (p["ReviewPanelHeight"].Defined)
                {
                    ReviewPanelHeight = p["ReviewPanelHeight"].Doublecon;
                }
            }
        }
    }
}

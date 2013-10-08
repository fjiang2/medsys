using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Sys.ViewManager.Forms
{
    public partial class WinForm : BaseForm
    {
        public WinForm()
            :this(null)
        {
   
        }

        public WinForm(string instanceID)
            : base(instanceID)
        {
            InitializeComponent();
            this.toolStripButtonNote.Visible = false;
            this.toolStripDropDownButtonLink.Visible = false;
            this.toolStripButtonOpen.Visible = false;
            this.toolStripButtonHistory.Visible = false;
            this.toolStripButtonClear.Visible = false;
            this.toolStripButtonValidate.Visible = false;
        }

        protected ToolStripButton ButtonOpen
        { get { return toolStripButtonOpen; } }

        protected ToolStripButton ButtonSave
        { get { return toolStripButtonSave; } }

        protected ToolStripButton ButtonDelete
        { get { return toolStripButtonDelete; } }

        protected ToolStripButton ButtonPrint
        { get { return toolStripButtonPrint; } }

        protected ToolStripButton ButtonRefreh
        { get { return toolStripButtonRefresh; } }


        protected ToolStripButton ButtonNew
        { get { return toolStripButtonNew; } }


        protected ToolStripButton ButtonSerach
        { get { return toolStripButtonSearch; } }

        protected ToolStripButton ButtonHistory
        { get { return toolStripButtonHistory; } }

        protected ToolStripButton ButtonClear
        { get { return toolStripButtonClear; } }

        protected ToolStripButton ButtonNote
        { get { return toolStripButtonNote; } }


        protected ToolStripButton ButtonValidate
        { get { return toolStripButtonValidate; } }


        private void toolStripButtonReportIssue_Click(object sender, EventArgs e)
        {

        }


        private void toolStripButtonMinimize_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonMaximize_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonFavorite_Click(object sender, EventArgs e)
        {
            AddShortCut(true);
        }

        private void toolStripButtonNote_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonHelp_Click(object sender, EventArgs e)
        {
            ShowHelpForm();
        }


        protected virtual void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            this.DataSave();
        }

        protected virtual void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            this.DataDelete();
        }

        protected virtual void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            this.DataLoad(); 
        }

      

        protected virtual void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            
        }

        protected virtual void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            this.DataPrint();
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            this.DataClear();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            this.DataOpen();
        }

        protected virtual void toolStripButtonHistory_Click(object sender, EventArgs e)
        {
            this.DataHistory();
        }

        protected virtual void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            this.DataClear();
        }

        protected virtual void toolStripButtonValidate_Click(object sender, EventArgs e)
        {
            this.RuleValidated();
        }
    }
}

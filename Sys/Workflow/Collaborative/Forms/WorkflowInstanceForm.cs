using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tie;
using Sys.ViewManager.Forms;
using Sys.ViewManager;
using Sys.Workflow.Forms;
using Sys.Data;


namespace Sys.Workflow.Collaborative.Forms
{
    public partial class WorkflowInstanceForm : ActivityWinForm  
    {
        Workflow workflow;
        BindDpo<WorkflowInstanceDpo> bind;

        public WorkflowInstanceForm(Workflow workflow, bool newInstance)
        {
            InitializeComponent();

            this.workflow = workflow;
            
            bind = new BindDpo<WorkflowInstanceDpo>(new WorkflowInstanceDpo());
            bind.Bind(this.tbWorkflowInstanceID, WorkflowInstanceDpo._ID);
            bind.Bind(this.tbLabel, WorkflowInstanceDpo._Label);
            bind.Bind(this.tbDescription, WorkflowInstanceDpo._Description);
            bind.Bind(this.dtpWorkDate, WorkflowInstanceDpo._Work_Date);
            bind.Bind(this.dtpCompleteDate, WorkflowInstanceDpo._Complete_Date);

            if (workflow != null)
            {
                this.tbWorkflowName.Enabled = false; 
                this.tbWorkflowName.Text = workflow.WorkflowName;
                this.tbWorkflowDescription.Text = ((WorkflowDpo)(workflow.Data)).Description;  
            }


            if (newInstance)
            {
                WorkflowDpo workflowDpo = (WorkflowDpo)(workflow.Data);

                VAL val = Script.Evaluate(workflowDpo.Metadata, Sys.Security.Profile.Instance.Memory);

                if (val["Label"].Defined)
                    this.tbLabel.Text = val["Label"].Str;
                else
                    this.tbLabel.Text = workflowDpo.Label;

                if (val["Description"].Defined)
                    this.tbDescription.Text = val["Description"].Str;
                else
                    this.tbDescription.Text = workflowDpo.Description;
            }

       
        }

        private void WorkflowInstanceForm_Load(object sender, EventArgs e)
        {
            if (!account.IsDeveloper)
            {
                btnSave.Visible = false;
                btnEditHeap.Visible = false;
                linkWorkflow.Enabled = false;
            }
        }

      
        private void btnInstanceLookup_Click(object sender, EventArgs e)
        {
            LookUp lookUp = new LookUp("Select Workflow", 
                new TableReader(bind.Dpo.TableName,"Workflow_Name='{0}'", this.tbWorkflowName.Text).Table
                );

            lookUp.Text = "Workflow Instance";
            DataRow wfInstanceRow = lookUp.PopUp(this);
            if (wfInstanceRow != null)
            {
                int wfInstanceID = (int)wfInstanceRow[WorkflowInstanceDpo._ID];
                bind.Dpo = new WorkflowInstanceDpo(wfInstanceRow);
                bind.Reset();
            }
        }
        
        private void btnNewWorkflowInstance_Click(object sender, EventArgs e)
        {
            CollaborativeWorkflowInstance workflowInstance = CollaborativeWorkflowInstance.NewInstance(workflow, typeof(WorkflowInstanceDpo));
            WorkflowInstanceDpo wfInstance = (WorkflowInstanceDpo)workflowInstance.Data;
            wfInstance.Label = this.tbLabel.Text;
            wfInstance.Description = this.tbDescription.Text;
            workflowInstance.Save();

            //create the initial activities
            workflowInstance.Start();

            this.Close();
        }

        private void linkWorkflow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BaseForm form = new Collaborative.Forms.WorkflowForm(this.tbWorkflowName.Text);
            form.PopUp(this);
        }

        private void btnEditHeap_Click(object sender, EventArgs e)
        {
            WorkflowInstanceDpo wfInstance = (WorkflowInstanceDpo)bind.Dpo;
            if (wfInstance.ID > 0)
            {
                CollaborativeWorkflowInstance wfi = CollaborativeWorkflowInstance.NewInstance(wfInstance.ID, typeof(WorkflowInstanceDpo));
                WorkflowEditor wfEditor = new WorkflowEditor(wfi);
                wfEditor.PopUp(this, FormPlace.Floating);

                //string result = TieEditor.Show(this, "Edit Workflow Instance Heap",  wfInstance.Heap);
                //if (result != null)
                //    wfInstance.Heap = result;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WorkflowInstanceDpo wfInstance = (WorkflowInstanceDpo)bind.Dpo;
            if (wfInstance.ID > 0)
                bind.SaveDpo();
        }

      
    }
}
